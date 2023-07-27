using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using MvcMovie.Repositorio.interfaces;

namespace MvcMovie.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly MvcMovieContext _dbContext;
        public ClienteRepositorio(MvcMovieContext context)
        {
            _dbContext = context;
        }

        public async Task DeleteAsync(Cliente cliente)
        {
            if (cliente != null)
            {
                _dbContext.Cliente.Remove(cliente);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task AddAsync(Cliente? cliente)
        {
            if (cliente != null)
            {
                _dbContext.Add(cliente);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _dbContext.Cliente.ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int? id)
        {
            if (id == null)
                return null;
            return await _dbContext.Cliente
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Cliente?> FindIdAsync(int? id)
        {
            if (id == null)
                return null;
            return await _dbContext.Cliente
                .FindAsync(id);
        }

        public async Task<Cliente?> UpdateAsync(Cliente? cliente)
        {
            if (cliente != null)
            {
                _dbContext.Cliente.Update(cliente);
                await _dbContext.SaveChangesAsync();
                var clienteAtualizado = await GetByIdAsync(cliente.Id);
                if (clienteAtualizado == null)
                    return null;
                return clienteAtualizado;
            }
            return null;
        }

    }
}