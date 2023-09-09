using data.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;

namespace Parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly iClienteRepository _ClienteRepository;
        public ClienteController(iClienteRepository ClienteRepository)
        {
            _ClienteRepository = ClienteRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getCliente()
        {
            return Ok(await _ClienteRepository.getCliente());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getClientesbyId(int id)
        {
            return Ok(await _ClienteRepository.getClienteById(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _ClienteRepository.InsertCliente(cliente);
            return Ok(created);
        }
        [HttpPut]
        public async Task<IActionResult> updateCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var update = await _ClienteRepository.UpdateCliente(cliente);
            return Ok(update);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            return Ok(await _ClienteRepository.deleteCliente(id));
        }
    }
}

