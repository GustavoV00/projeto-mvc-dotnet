

using MvcMovie.Models;

namespace MvcMovie.Repositorio.interfaces
{
    public interface IClienteRepositorio
    {
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int? id);
        Task<Cliente?> FindIdAsync(int? id);
        Task AddAsync(Cliente? cliente);
        Task<Cliente?> UpdateAsync(Cliente? cliente);
        Task DeleteAsync(Cliente cliente);

    }

}
