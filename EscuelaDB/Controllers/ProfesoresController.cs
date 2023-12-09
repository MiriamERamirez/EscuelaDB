using EscuelaDB.Models;
using EscuelaDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace EscuelaDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesoresController: ControllerBase
    {
        private readonly ProfesoresService _profesoresService;

        public ProfesoresController(ProfesoresService profesoresService) => _profesoresService = profesoresService;

        [HttpGet]
        public async Task<List<Profesor>> Get() =>
            await _profesoresService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Profesor>> Get(string id)
        {
            var profesor = await _profesoresService.GetAsync(id);

            if (profesor is null)
            {
                return NotFound();
            }

            return profesor;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Profesor newProfesor)
        {
            await _profesoresService.CreateAsync(newProfesor);

            return CreatedAtAction(nameof(Get),new {id = newProfesor.Id}, newProfesor);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Profesor updateProfesor)
        {
            var profesor = await _profesoresService.GetAsync(id);

            if (profesor is null)
            {
                return NotFound();
            }
            
            updateProfesor.Id = profesor.Id;

            await _profesoresService.UpdateAsync(id, updateProfesor);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var profesor = await _profesoresService.GetAsync(id);

            if (profesor is null)
            {
                return NotFound();
            }

            await _profesoresService.RemoveAsync(id);

            return NoContent();
        }
    }
}
