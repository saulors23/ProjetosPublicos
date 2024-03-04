using ICommerceNetCore.Services;
using Microsoft.AspNetCore.Mvc;
using ICommerceNetCore.Models;
using ICommerceNetCore.Data;
using Microsoft.EntityFrameworkCore;

namespace ICommerceNetCore.Controllers
{
    public class ClientesController : Controller
    {      
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        #region Consulta todos os Clientes do Cadastro
        public async Task<IActionResult> Index()
        {
            try
            {
                var clientes = await _clienteService.GetClientes();

                if (clientes == null || clientes.Count == 0)
                {
                    return View(new List<ClienteModel>()); 
                }

                return View(clientes);
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

        #region Adiciona um novo cliente no Cadastro
        [HttpPost]
        public IActionResult Create(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {                
                if (_clienteService.CpfExists(cliente.Cpf))
                {                    
                    ViewBag.CpfExistsError = "O CPF do(a) Cliente Informado já Existe no Sistema.";

                    ViewBag.IsReloadedPage = true;

                    return View(cliente);
                }

                _clienteService.AddCliente(cliente);

                TempData["CreateSuccess"] = true;

                return RedirectToAction("Index");
            }
            return View(cliente);
        }
        #endregion

        #region Edita dados do Cliente no Cadastro        
        public IActionResult Edit(int id)
        {
            try
            {
                var cliente = _clienteService.GetClienteById(id);

                if (cliente == null)
                {
                    return NotFound(); 
                }

                return View(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception(@"[Erro ao obter o cliente por ID: {ex.Message}]", ex);

                return RedirectToAction("Index"); 
            }
        }
        [HttpPost]
        public IActionResult Edit(int id, ClienteModel cliente)
        {
            try
            {
                if (id != cliente.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _clienteService.UpdateCliente(cliente);
                    
                    TempData["EditSuccess"] = true;

                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Erro ao editar o cliente. Entre em contato com o suporte.");
                return View(cliente); 
            }
        }
        #endregion

        #region Exclusão de Cadastro de Cliente
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cliente = _clienteService.GetClienteById(id);

                if (cliente == null)
                {
                    return NotFound(); 
                }
                return View(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception(@"[Erro ao obter o cliente por ID: {ex.Message}]", ex);

                return RedirectToAction("Index"); 
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _clienteService.DeleteCliente(id);
               
                TempData["DeleteSuccess"] = true;

                return RedirectToAction("Index");             
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Erro ao Excluir o cliente. Entre em contato com o suporte.");
                return RedirectToAction("Index"); 
            }
        }
        #endregion
    }
}
