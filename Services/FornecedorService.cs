using MvcMovie.Models;
using MvcMovie.Repositorio.interfaces;
using MvcMovie.Services.interfaces;

namespace MvcMovie.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;

        public FornecedorService(IFornecedorRepositorio fornecedorRepository)
        {
            _fornecedorRepositorio = fornecedorRepository;
        }

        public async Task<List<Fornecedor>> GetAllFornecedorsAsync()
        {
            return await _fornecedorRepositorio.GetAllAsync();
        }

        public async Task<Fornecedor?> GetFornecedorByIdAsync(int? fornecedId)
        {
            return await _fornecedorRepositorio.GetByIdAsync(fornecedId);
        }
        public async Task<Fornecedor?> FindIdAsync(int? fornecedId)
        {
            return await _fornecedorRepositorio.FindIdAsync(fornecedId);
        }

        public async Task AddNewFornecedorAsync(Fornecedor client)
        {
            await _fornecedorRepositorio.AddAsync(client);
        }

        public async Task<Fornecedor?> UpdateFornecedorAsync(Fornecedor? client)
        {
            var fornecedorAtualizado = await _fornecedorRepositorio.UpdateAsync(client);
            if (fornecedorAtualizado == null)
                return null;
            return fornecedorAtualizado;
        }

        public async Task DeleteFornecedorAsync(Fornecedor? fornecedor)
        {
            if (fornecedor != null)
            {
                await _fornecedorRepositorio.DeleteAsync(fornecedor);
            }
        }

    }
}