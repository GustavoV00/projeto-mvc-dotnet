using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any() && context.Cliente.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Rating = "R",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Rating = "R",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Rating = "R",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Rating = "R",
                    Price = 3.99M
                }
            );

            context.Cliente.AddRange(
                new Cliente
                {
                    Nome = "Nome1",
                    Sobrenome = "Sobrenome1",
                    Email = "email1@email1.com",
                    Endereco = "Endereco1",
                },
                new Cliente
                {
                    Nome = "Nome2",
                    Sobrenome = "Sobrenome2",
                    Email = "email2@email2.com",
                    Endereco = "Endereco1",
                },
                new Cliente
                {
                    Nome = "Nome3",
                    Sobrenome = "Sobrenome3",
                    Email = "email3@email3.com",
                    Endereco = "Endereco3",
                },
                new Cliente
                {
                    Nome = "Nome4",
                    Sobrenome = "Sobrenome4",
                    Email = "email4@email4.com",
                    Endereco = "Endereco4",
                }
            );

            context.SaveChanges();
        }
    }
}