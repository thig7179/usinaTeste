using Microsoft.AspNetCore.Mvc;
using Usina.Web.Models;
using Usina.Web.Services.IService;

namespace Usina.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService ?? throw new ArgumentNullException(nameof(clienteService));
        }
        public async Task<IActionResult> ClienteIndex()
        {
            
            return View();
        }
        public async Task<IActionResult> CreateCliente()
        {
            return View();
        }

        public async Task<IActionResult> ObterClientes()
        {
            var clientes = await _clienteService.FindAll();

            return Json(clientes);
        }

        public async Task<IActionResult> CadastrarCliente(Cliente model)
        {
            if(ModelState.IsValid)
            {
                var response = await _clienteService.CreateCliente(model);
                if(response != null) return RedirectToAction(nameof(ClienteIndex));
            }
            return View(model);
        }


        public async Task<IActionResult> UpdateCliente(Cliente model)
        {
            if (ModelState.IsValid)
            {
                var response = await _clienteService.UpdateCliente(model);
                if (response != null) return RedirectToAction(nameof(ClienteIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> ObterClientePorCodigo(long codigo)
        {
            var cliente = await _clienteService.FindClienteByCodigo(codigo);
            return Json(cliente);
        }

        public async Task<IActionResult> DeletarCliente(long codigo)
        {

             var response = await _clienteService.DeleteClienteByCodigo(codigo);
            if (response) 
                return RedirectToAction(nameof(ClienteIndex));
            return View(response);
        }
    }
}
