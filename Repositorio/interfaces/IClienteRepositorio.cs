

using MvcMovie.Models;

namespace MvcMovie.Repositorio.interfaces
{
    public interface IClienteRepositorio
    {

        /// <summary>
        /// Obtem todos os Clientes
        /// <summary>
        Task<List<Cliente>> GetAllAsync();

        // Obtem o cliente pelo Id
        Task<Cliente?> GetByIdAsync(int? id);

        // Obtem o cliente pelo Id mas com o método FindAsync
        Task<Cliente?> FindIdAsync(int? id);

        // Cadastra um novo cliente
        Task AddAsync(Cliente? cliente);

        // Atualiza um novo cliente
        Task<Cliente?> UpdateAsync(Cliente? cliente);

        // Deleta o cliente
        Task DeleteAsync(Cliente cliente);

    }

}
