using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using MvcMovie.Repositorio.interfaces;

namespace MvcMovie.Repositorio
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private readonly MvcMovieContext _dbContext;
        public FornecedorRepositorio(MvcMovieContext context)
        {
            _dbContext = context;
        }

        public async Task DeleteAsync(Fornecedor fornecedor)
        {
            if (fornecedor != null)
            {
                _dbContext.Fornecedor.Remove(fornecedor);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task AddAsync(Fornecedor? fornecedor)
        {
            if (fornecedor != null)
            {
                _dbContext.Add(fornecedor);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task<List<Fornecedor>> GetAllAsync()
        {
            return await _dbContext.Fornecedor.ToListAsync();
        }

        public async Task<Fornecedor?> GetByIdAsync(int? id)
        {
            if (id == null)
                return null;
            return await _dbContext.Fornecedor
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Fornecedor?> FindIdAsync(int? id)
        {
            if (id == null)
                return null;
            return await _dbContext.Fornecedor
                .FindAsync(id);
        }

        public async Task<Fornecedor?> UpdateAsync(Fornecedor? fornecedor)
        {
            if (fornecedor != null)
            {
                _dbContext.Fornecedor.Update(fornecedor);
                await _dbContext.SaveChangesAsync();
                var fornecedorAtualizado = await GetByIdAsync(fornecedor.Id);
                if (fornecedorAtualizado == null)
                    return null;
                return fornecedorAtualizado;
            }
            return null;
        }

    }
}