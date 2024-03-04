using ICommerceNetCore.Models;
using ICommerceNetCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ICommerceNetCore.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutosEstoqueService _produtosEstoqueService;
        private readonly IFornecedorService _fornecedorService;

        public ProdutosController(IProdutosEstoqueService produtosEstoqueService, IFornecedorService fornecedorService)
        {
            _produtosEstoqueService = produtosEstoqueService;
            _fornecedorService = fornecedorService;
        }

        #region Consulta todos os Produtos no Estoque do Cadastro
        public async Task<IActionResult> Index()
        {
            try
            {
                var produtos = await _produtosEstoqueService.GetProdutosEstoque();

                if (produtos == null || produtos.Count == 0)
                {
                    return View(new List<ProdutosEstoqueModel>()); 
                }

                return View(produtos);
            }
            catch (Exception ex)
            {
                throw new Exception(@"[Não foi possível concluir a execução de Consulta]", ex);
            }
        }
        #endregion

        public async Task<IActionResult> Create()
        {
            try
            {
                var fornecedores = await _fornecedorService.GetFornecedores();

                if (fornecedores != null && fornecedores.Any())
                {
                    ViewBag.Fornecedores = fornecedores
                    .Select(f => new SelectListItem { Value = f.Id.ToString(), Text = f.Razao_Social })
                    .ToList();
                }
                else
                {
                    ViewBag.Fornecedores = new List<SelectListItem>();
                }

                var model = new ProdutosEstoqueModel();

                return View(model);
            }
            catch (Exception ex)
            {
                return View(new ProdutosEstoqueModel());
            }
        }

        #region Adiciona um novo Produto ao Estoque no Cadastro
        [HttpPost]
        public async Task<IActionResult> Create(ProdutosEstoqueModel produtosEstoque)
        {
            if (ModelState.IsValid)
            {                
                if (_produtosEstoqueService.ProdutoEstoqueExists(produtosEstoque.Codigo))
                {
                    ViewBag.CodigoExistsError = "O Código do Produto Informado já Existe no Sistema.";

                    var fornecedores = await _fornecedorService.GetFornecedores();

                    ViewBag.Fornecedores = fornecedores
                        .Select(f => new SelectListItem { Value = f.Id.ToString(), Text = f.Razao_Social })
                        .ToList();

                    ViewBag.IsReloadedPage = true;

                    return View(produtosEstoque);
                }
                
                _produtosEstoqueService.AddProdutosEstoque(produtosEstoque);

                TempData["CreateSuccess"] = true;

                return RedirectToAction("Index");
            }

            var fornecedoresForInvalidModel = await _fornecedorService.GetFornecedores();
            ViewBag.Fornecedores = fornecedoresForInvalidModel
                .Select(f => new SelectListItem { Value = f.Id.ToString(), Text = f.Razao_Social })
                .ToList();            

            return View(produtosEstoque);
        }
        #endregion
    }
}
