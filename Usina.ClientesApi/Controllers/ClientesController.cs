using Microsoft.AspNetCore.Mvc;
using Usina.ClientesApi.Repositories;
using Usina.ClientesApi.Models;
using Usina.ClientesApi.Data.ValueObject;

namespace Usina.ClientesApi.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesRepository _clienteRepository;

        public ClientesController(IClientesRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ClienteVO>>>ObterTodosClientes()
        {
            var clientes = await _clienteRepository.FindAll();
            return Ok(clientes);
        }

        [HttpGet("{codigo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteVO>> ObterClientePorCodigo(long codigo)
        {
            var cliente = await _clienteRepository.FindByCodigo(codigo);
            if (cliente == null) return NotFound();

            return Ok(cliente);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ClienteVO>> AdicionarCliente([FromBody] ClienteVO vo)
        {     
            if (vo == null) return BadRequest();
            var cliente = await _clienteRepository.Create(vo);
            return Ok(cliente);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteVO>> AtualizarCliente([FromBody] ClienteVO cliente)
        {
            if (cliente == null)
                return BadRequest();
            var existingCliente = await _clienteRepository.Update(cliente);
            return Ok(existingCliente);
        }

        [HttpDelete("{codigo}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteVO>> ExcluirCliente(long codigo)
        {
            //var existingCliente = _clienteRepository.FindByCodigo(codigo);
            await _clienteRepository.Delete(codigo);
            return NoContent();
        }
    }
}
