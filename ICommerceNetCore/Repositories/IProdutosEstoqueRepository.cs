using ICommerceNetCore.Models;

namespace ICommerceNetCore.Repositories
{
    public interface IProdutosEstoqueRepository
    {
        Task<List<ProdutosEstoqueModel>> GetProdutosEstoque();
        //ProdutosEstoqueModel GetProdutosEstoqueById(int id);
        bool ProdutoEstoqueExists(string codigo);                          
        void AddProdutosEstoque(ProdutosEstoqueModel produtoEstoque);
        //        void UpdateProdutosEstoque(ProdutosEstoqueModel produtosEstoque);
        //        void DeleteProdutosEstoque(int id);
    }
}
