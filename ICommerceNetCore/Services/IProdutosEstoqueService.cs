using ICommerceNetCore.Models;

namespace ICommerceNetCore.Services
{
    public interface IProdutosEstoqueService
    {
        Task<List<ProdutosEstoqueModel>> GetProdutosEstoque();
        //ProdutosEstoqueModel GetProdutosEstoqueById(int id);
        bool ProdutoEstoqueExists(string codigo);                          
        void AddProdutosEstoque(ProdutosEstoqueModel produtosEstoque);
        //        void UpdateProdutosEstoque(ProdutosEstoqueModel produtosEstoque);
        //        void DeleteProdutosEstoque(int id);

    }
}
