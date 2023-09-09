using data.repositorio;
using data.Repositorio;
using Microsoft.AspNetCore.Mvc;
using model;

namespace Parcial.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class VentasController : ControllerBase
        {
            public readonly iVentaRepository _VentaRepository;
            public VentasController(iVentaRepository VentaRepository)
            {
                _VentaRepository = VentaRepository;
    
            }
            [HttpPost]
            public async Task<IActionResult> InsertVenta([FromBody] Venta venta)
            {
                if (venta == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var created = await _VentaRepository.InsertVenta(venta);
                return Ok(created);
           
            }
        }
    }