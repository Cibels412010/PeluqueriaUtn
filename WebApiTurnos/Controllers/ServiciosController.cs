using BackTurnos.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTurnos.Models;

namespace WebApiTurnos.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ServiciosController : Controller
    {
        //instancio servicio
        private readonly IPeluqueriaServicio _service;

        //inyecto dependencia
        public ServiciosController(IPeluqueriaServicio service)
        {
            _service = service;
        }

        // GET: ServiciosController
        [HttpGet]
        public async Task<IActionResult> GetAllServicios()
        {
            return Ok(await _service.MostrarTodos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServicio(int id)
        {
            var producto = await _service.MostrarUno(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost("Servicio")]

        public async Task<IActionResult> SaveServicio(TServicio servicio)
        {
            var result = await _service.Guardar(servicio);
            if (result != null)
            {
                return Ok(result);

            }
            return BadRequest("No se pudo gurdar");
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicio(int id)
        {
            await _service.DarBaja(id);
            return NoContent();
        }



    }
}
