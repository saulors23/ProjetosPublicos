using ICommerceNetCore.Data;
using ICommerceNetCore.Models;
using ICommerceNetCore.Repositories;

namespace ICommerceNetCore.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        #region Consulta todos os Clientes do Cadastro
        public async Task<List<ClienteModel>> GetClientes()
        {
            try
            {
                var listaClientes = await _clienteRepository.GetClientes();
                
                if (listaClientes != null && listaClientes is List<ClienteModel>)
                {
                    return listaClientes;
                }

                return new List<ClienteModel>();                                
            }
            catch (Exception ex)
            {
                return new List<ClienteModel>();
            }    
        }
        #endregion

        #region Consulta Cliente por Id
        public ClienteModel GetClienteById(int id)
        {
            return _clienteRepository.GetClienteById(id);
        }
        #endregion

        #region Adiciona um Novo Cliente
        public bool CpfExists(string cpf)
        {            
            return _clienteRepository.CpfExists(cpf);
        }
        public void AddCliente(ClienteModel cliente)
        {
            _clienteRepository.AddCliente(cliente);
        }
        #endregion

        #region Edita os Dados de um Cliente
        public void UpdateCliente(ClienteModel cliente)
        {
            _clienteRepository.UpdateCliente(cliente);
        }
        #endregion

        #region Exclui os Dados de um Cliente
        public void DeleteCliente(int id)
        {
            _clienteRepository.DeleteCliente(id);
        }
        #endregion
    }
}
