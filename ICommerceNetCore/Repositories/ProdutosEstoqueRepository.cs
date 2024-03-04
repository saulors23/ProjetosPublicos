using ICommerceNetCore.Data;
using ICommerceNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ICommerceNetCore.Repositories
{
    public class ProdutosEstoqueRepository : IProdutosEstoqueRepository
    {
        private readonly AppDbContext _context;

        public ProdutosEstoqueRepository(AppDbContext context)
        {
            _context = context;
        }

        #region Lista todos os Produtos do Estoque no Cadastro
        public async Task<List<ProdutosEstoqueModel>> GetProdutosEstoque()
        {
            try
            {
                var listaProdutosEstoque = await _context.TB_PRODUTOS.AsNoTracking().ToListAsync();

                if (listaProdutosEstoque.Count == 0)
                {
                    return new List<ProdutosEstoqueModel>();
                }

                return listaProdutosEstoque.Select(p => new ProdutosEstoqueModel
                {
                    Id = p.Id,
                    Codigo = p.Codigo,
                    Descricao = p.Descricao,
                    Marca = p.Marca,
                    Preco_Custo = p.Preco_Custo,
                    Preco_Venda = p.Preco_Venda,
                    Estoque_Min = (int)p.Estoque_Min,
                    Estoque_Max = (int)p.Estoque_Max,
                    Data_Fabricacao = p.Data_Fabricacao,
                    Data_Validade = p.Data_Validade,
                    Fornecedor = p.Fornecedor
                }).ToList();
            }
            catch (Exception ex)
            {                
                Console.WriteLine($"Erro ao obter produtos: {ex.Message}");
                return new List<ProdutosEstoqueModel>();
            }
        }
        #endregion

        #region Adiciona um Novo Produto
        public bool ProdutoEstoqueExists(string codigo)
        {            
            return _context.TB_PRODUTOS.Any(c => c.Codigo == codigo);
        }

        public void AddProdutosEstoque(ProdutosEstoqueModel produtosEstoque)
        {
            _context.TB_PRODUTOS.Add(produtosEstoque);
            _context.SaveChanges();
        }
        #endregion
    }
}
