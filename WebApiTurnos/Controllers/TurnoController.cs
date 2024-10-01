using BackTurnos.Servicio;
using Microsoft.AspNetCore.Mvc;
using WebApiTurnos.Models;

namespace WebApiTurnos.Controllers
{
        [ApiController]
        [Route("Api/[controller]")]
    public class TurnoController : Controller
    {
        private readonly PeluqueriaServicio _service;
        public TurnoController(PeluqueriaServicio servicio)
        {
            _service = servicio;
        }

        // GET: ServiciosController
        [HttpGet]
        public async Task<IActionResult> GetAllTurnos()
        {
            return Ok(await _service.MostrarTurnos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTurno(int id)
        {
            var producto = await _service.MostrarUnTurno (id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost("Turno")]

        public async Task<IActionResult> SaveTurno(TTurno turno)
        {
            var result = await _service.GuardarTurno(turno);
            if (result != null)
            {
                return Ok(result);

            }
            return BadRequest("No se pudo guardar");
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurno(int id)
        {
            await _service.DarBajaTurno(id);
            return NoContent();
        }
    }
}
