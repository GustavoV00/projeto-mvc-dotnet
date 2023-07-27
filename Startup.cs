using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcMovie.Data;
using MvcMovie.Models;
using MvcMovie.Repositorio;
using MvcMovie.Repositorio.interfaces;
using MvcMovie.Services;
using MvcMovie.Services.interfaces;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddDbContext<MvcMovieContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("MvcMovieContext")));
        // var connectionString = Configuration.GetConnectionString("MvcProject");

        // services.AddDbContext<MvcMovieContext>(options => options.UserS)
        services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
        services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IFornecedorService, FornecedorService>();

        services.AddControllersWithViews();


        // Add other services and configurations
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
    {
        if (env.IsDevelopment())
        {
            // app.UseDeveloperExceptionPage();
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        SeedData.Initialize(serviceProvider);

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });

    }
}