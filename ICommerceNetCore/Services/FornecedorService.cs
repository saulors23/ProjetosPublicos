using ICommerceNetCore.Data;
using ICommerceNetCore.Models;
using ICommerceNetCore.Repositories;

namespace ICommerceNetCore.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        #region Consulta todos os Fornecedores do Cadastro
        public async Task<List<FornecedorModel>> GetFornecedores()
        {
            try
            {
                var listaFornecedores = await _fornecedorRepository.GetFornecedores();
                
                if (listaFornecedores != null && listaFornecedores is List<FornecedorModel>)
                {
                    return listaFornecedores;
                }

                return new List<FornecedorModel>();
            }
            catch (Exception ex)
            {
                return new List<FornecedorModel>();
            }
        }
        #endregion

        #region Consulta Fornecedor por Id
        public FornecedorModel GetFornecedorById(int id)
        {
            return _fornecedorRepository.GetFornecedorById(id);
        }
        #endregion

        #region Adiciona um Novo Fornecedor
        public bool CnpjExists(string cnpj)
        {            
            return _fornecedorRepository.CnpjExists(cnpj);
        }
        public void AddFornecedor(FornecedorModel fornecedor)
        {
            _fornecedorRepository.AddFornecedor(fornecedor);
        }
        #endregion

        #region Edita os Dados de um Fornecedor
        public void UpdateFornecedor(FornecedorModel fornecedor)
        {
            _fornecedorRepository.UpdateFornecedor(fornecedor);
        }
        #endregion

        #region Exclui os Dados de um Fornecedor
        public void DeleteFornecedor(int id)
        {
            _fornecedorRepository.DeleteFornecedor(id);
        }
        #endregion
    }
}
