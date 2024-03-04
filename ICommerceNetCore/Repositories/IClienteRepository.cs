using ICommerceNetCore.Models;

namespace ICommerceNetCore.Repositories
{
    public interface IClienteRepository
    {        
        Task<List<ClienteModel>> GetClientes();
        ClienteModel GetClienteById(int id);
        bool CpfExists(string cpf);                          
        void AddCliente(ClienteModel cliente);
        void UpdateCliente(ClienteModel cliente);
        void DeleteCliente(int id);
    }
}
