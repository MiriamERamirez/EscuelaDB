using EscuelaDB.Models;
using EscuelaDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace EscuelaDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalificacionesController : ControllerBase
    {
        private readonly CalificacionesService _calificacionesService;

        public CalificacionesController(CalificacionesService calificacionesService) => _calificacionesService = calificacionesService;

        [HttpGet]
        public async Task<List<Calificacion>> Get() =>
            await _calificacionesService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Calificacion>> Get(string id)
        {
            var calificacion = await _calificacionesService.GetAsync(id);

            if (calificacion is null)
            {
                return NotFound();
            }

            return calificacion;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Calificacion newCalificacion)
        {
            await _calificacionesService.CreateAsync(newCalificacion);

            return CreatedAtAction(nameof(Get), new { id = newCalificacion.Id }, newCalificacion);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Calificacion updateCalificacion)
        {
            var calificacion = await _calificacionesService.GetAsync(id);

            if (calificacion is null)
            {
                return NotFound();
            }

            updateCalificacion.Id = calificacion.Id;

            await _calificacionesService.UpdateAsync(id, updateCalificacion);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var calificacion = await _calificacionesService.GetAsync(id);

            if (calificacion is null)
            {
                return NotFound();
            }

            await _calificacionesService.RemoveAsync(id);

            return NoContent();
        }
    }
}
