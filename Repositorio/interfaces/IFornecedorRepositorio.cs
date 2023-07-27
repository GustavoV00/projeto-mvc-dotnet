using MvcMovie.Models;

namespace MvcMovie.Repositorio.interfaces
{
    public interface IFornecedorRepositorio
    {
        // Obtem todos os fornecedores
        Task<List<Fornecedor>> GetAllAsync();

        // Obtem fornecedor por Id
        Task<Fornecedor?> GetByIdAsync(int? id);

        // Obtem o fornecedor pelo Id mas com o método FindAsync
        Task<Fornecedor?> FindIdAsync(int? id);

        // Cria um novo fornecedor
        Task AddAsync(Fornecedor? fornecedor);

        // Atualiza um novo fornecedor
        Task<Fornecedor?> UpdateAsync(Fornecedor? fornecedor);

        // Deleta um fornecedo
        Task DeleteAsync(Fornecedor fornecedor);

    }

}
