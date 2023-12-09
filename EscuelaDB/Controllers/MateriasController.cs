using EscuelaDB.Models;
using EscuelaDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace EscuelaDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriasController : ControllerBase
    {
        private readonly MateriasService _materiasService;

        public MateriasController(MateriasService materiasService) => _materiasService = materiasService;

        [HttpGet]
        public async Task<List<Materia>> Get() =>
            await _materiasService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Materia>> Get(string id)
        {
            var materia = await _materiasService.GetAsync(id);

            if (materia is null)
            {
                return NotFound();
            }

            return materia;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Materia newMateria)
        {
            await _materiasService.CreateAsync(newMateria);

            return CreatedAtAction(nameof(Get), new { id = newMateria.Id }, newMateria);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Materia updateMateria)
        {
            var materia = await _materiasService.GetAsync(id);

            if (materia is null)
            {
                return NotFound();
            }

            updateMateria.Id = materia.Id;

            await _materiasService.UpdateAsync(id, updateMateria);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var materia = await _materiasService.GetAsync(id);

            if (materia is null)
            {
                return NotFound();
            }

            await _materiasService.RemoveAsync(id);

            return NoContent();
        }
    }
}
