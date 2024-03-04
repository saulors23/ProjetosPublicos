using ICommerceNetCore.Models;

namespace ICommerceNetCore.Repositories
{
    public interface IFornecedorRepository
    {
        Task<List<FornecedorModel>> GetFornecedores();
        FornecedorModel GetFornecedorById(int id);
        bool CnpjExists(string cnpj);                          
        void AddFornecedor(FornecedorModel fornecedor);
        void UpdateFornecedor(FornecedorModel fornecedor);
        void DeleteFornecedor(int id);
    }
}
