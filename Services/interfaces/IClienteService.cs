using MvcMovie.Models;


namespace MvcMovie.Services.interfaces
{
    public interface IClienteService
    {
        Task<List<Cliente>> GetAllClientsAsync();
        Task<Cliente?> GetClientByIdAsync(int? clientId);
        Task<Cliente?> FindIdAsync(int? clientId);
        Task AddNewClientAsync(Cliente client);
        Task<Cliente?> UpdateClientAsync(Cliente? client);
        Task DeleteClientAsync(Cliente cliente);
    }
}