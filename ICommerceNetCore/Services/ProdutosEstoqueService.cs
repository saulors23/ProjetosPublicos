using ICommerceNetCore.Models;
using ICommerceNetCore.Repositories;

namespace ICommerceNetCore.Services
{
    public class ProdutosEstoqueService : IProdutosEstoqueService
    {
        private readonly IProdutosEstoqueRepository _produtosEstoqueRepository;

        public ProdutosEstoqueService(IProdutosEstoqueRepository produtosEstoqueRepository)
        {
            _produtosEstoqueRepository = produtosEstoqueRepository;
        }

        #region Consulta todos os Produtos do Estoque no Cadastro
        public async Task<List<ProdutosEstoqueModel>> GetProdutosEstoque()
        {
            try
            {
                var listaProdutosEstoque = await _produtosEstoqueRepository.GetProdutosEstoque();

                return listaProdutosEstoque;
            }
            catch (Exception ex)
            {                
                return new List<ProdutosEstoqueModel>();                
            }
        }
        #endregion

        #region Adiciona um Novo Produto
        public bool ProdutoEstoqueExists(string codigo)
        {
            return _produtosEstoqueRepository.ProdutoEstoqueExists(codigo);
        }

        public void AddProdutosEstoque(ProdutosEstoqueModel produtosEstoque)
        {
            _produtosEstoqueRepository.AddProdutosEstoque(produtosEstoque);
        }
        #endregion
    }
}
