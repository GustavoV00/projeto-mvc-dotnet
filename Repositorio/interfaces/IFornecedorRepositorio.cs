using MvcMovie.Models;

namespace MvcMovie.Repositorio.interfaces
{
    public interface IFornecedorRepositorio
    {
        Task<List<Fornecedor>> GetAllAsync();
        Task<Fornecedor?> GetByIdAsync(int? id);
        Task<Fornecedor?> FindIdAsync(int? id);
        Task AddAsync(Fornecedor? fornecedor);
        Task<Fornecedor?> UpdateAsync(Fornecedor? fornecedor);
        Task DeleteAsync(Fornecedor fornecedor);

    }

}
