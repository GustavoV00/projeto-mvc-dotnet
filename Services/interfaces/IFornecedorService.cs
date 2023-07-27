
using MvcMovie.Models;


namespace MvcMovie.Services.interfaces
{
    public interface IFornecedorService
    {
        Task<List<Fornecedor>> GetAllFornecedorsAsync();
        Task<Fornecedor?> GetFornecedorByIdAsync(int? fornecedorId);
        Task<Fornecedor?> FindIdAsync(int? fornecedorId);
        Task AddNewFornecedorAsync(Fornecedor fornecedor);
        Task<Fornecedor?> UpdateFornecedorAsync(Fornecedor? fornecedor);
        Task DeleteFornecedorAsync(Fornecedor fornecedor);
    }
}