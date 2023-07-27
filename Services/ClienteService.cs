using MvcMovie.Models;
using MvcMovie.Repositorio.interfaces;
using MvcMovie.Services.interfaces;

namespace MvcMovie.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteService(IClienteRepositorio clientRepository)
        {
            _clienteRepositorio = clientRepository;
        }

        public async Task<List<Cliente>> GetAllClientsAsync()
        {
            return await _clienteRepositorio.GetAllAsync();
        }

        public async Task<Cliente?> GetClientByIdAsync(int? clientId)
        {
            return await _clienteRepositorio.GetByIdAsync(clientId);
        }
        public async Task<Cliente?> FindIdAsync(int? clientId)
        {
            return await _clienteRepositorio.FindIdAsync(clientId);
        }

        public async Task AddNewClientAsync(Cliente client)
        {
            await _clienteRepositorio.AddAsync(client);
        }

        public async Task<Cliente?> UpdateClientAsync(Cliente? client)
        {
            var clienteAtualizado = await _clienteRepositorio.UpdateAsync(client);
            if (clienteAtualizado == null)
                return null;
            return clienteAtualizado;
        }

        public async Task DeleteClientAsync(Cliente? cliente)
        {
            if (cliente != null)
            {
                await _clienteRepositorio.DeleteAsync(cliente);
            }
        }

        // Other business logic and data access methods related to clients can be added here
    }
}