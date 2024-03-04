using ICommerceNetCore.Services;
using Microsoft.AspNetCore.Mvc;
using ICommerceNetCore.Models;
using ICommerceNetCore.Data;
using Microsoft.EntityFrameworkCore;

namespace ICommerceNetCore.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedoresController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        #region Consulta todos os Fornecedores do Cadastro
        public async Task<IActionResult> Index()
        {
            try
            {
                var fornecedores = await _fornecedorService.GetFornecedores();

                if (fornecedores == null || fornecedores.Count == 0)
                {
                    return View(new List<FornecedorModel>()); 
                }

                return View(fornecedores);
            }
            catch (Exception ex)
            {
                throw new Exception(@"[Não foi possível concluir a execução de Consulta]", ex);
            }
        }
        #endregion

        public IActionResult Create()
        {
            return View();
        }

        #region Adiciona um novo Fornecdor no Cadastro
        [HttpPost]
        public IActionResult Create(FornecedorModel fornecedor)
        {
            if (ModelState.IsValid)
            {                
                if (_fornecedorService.CnpjExists(fornecedor.Cnpj))
                {                    
                    ViewBag.CnpjExistsError = "O CNPJ do(a) Fornecedor(a) Informado já Existe no Sistema.";
                    
                    ViewBag.IsReloadedPage = true;

                    return View(fornecedor);
                }

                _fornecedorService.AddFornecedor(fornecedor);

                TempData["CreateSuccess"] = true;

                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }
        #endregion

        #region Edita dados do Fornecedor no Cadastro        
        public IActionResult Edit(int id)
        {
            try
            {
                var fornecedor = _fornecedorService.GetFornecedorById(id);

                if (fornecedor == null)
                {
                    return NotFound(); 
                }

                return View(fornecedor);
            }
            catch (Exception ex)
            {
                throw new Exception(@"[Erro ao obter o fornecedor por ID: {ex.Message}]", ex);
                return RedirectToAction("Index"); 
            }
        }
        [HttpPost]
        public IActionResult Edit(int id, FornecedorModel fornecedor)
        {
            try
            {
                if (id != fornecedor.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _fornecedorService.UpdateFornecedor(fornecedor);
                    
                    TempData["EditSuccess"] = true;

                    return RedirectToAction("Index");
                }
                return View(fornecedor);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Erro ao editar o fornecedor. Entre em contato com o suporte.");
                return View(fornecedor); 
            }
        }
        #endregion

        #region Exclusão de Cadastro de Fornecdor
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var fornecedor = _fornecedorService.GetFornecedorById(id);

                if (fornecedor == null)
                {
                    return NotFound(); 
                }
                return View(fornecedor);
            }
            catch (Exception ex)
            {
                throw new Exception(@"[Erro ao obter o fornecedor por ID: {ex.Message}]", ex);

                return RedirectToAction("Index"); 
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _fornecedorService.DeleteFornecedor(id);
                
                TempData["DeleteSuccess"] = true;

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Erro ao Excluir o fornecedor. Entre em contato com o suporte.");
                return RedirectToAction("Index"); 
            }
        }
        #endregion
    }
}