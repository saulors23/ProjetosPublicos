using ICommerceNetCore.Models;

namespace ICommerceNetCore.Services
{
    public interface IClienteService
    {
        Task<List<ClienteModel>> GetClientes();
        ClienteModel GetClienteById(int id);
        bool CpfExists(string cpf);                          
        void AddCliente(ClienteModel cliente);
        void UpdateCliente(ClienteModel cliente);
        void DeleteCliente(int id);
    }
}
