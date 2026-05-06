using Microsoft.AspNetCore.Mvc;
using TrackingHabitos.API.Data;
using TrackingHabitos.API.Models;
using TrackingHabitos.API.Repositories;

namespace TrackingHabitos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabitosController : ControllerBase
    {
        private readonly HabitoRepository _repository;

        public HabitosController(AppDbContext context)
        {
            _repository = new HabitoRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var habitos = await _repository.GetAllAsync();
            return Ok(habitos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var habito = await _repository.GetByIdAsync(id);
            if (habito == null) return NotFound();
            return Ok(habito);
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetByUsuario(int usuarioId)
        {
            var habitos = await _repository.GetByUsuarioIdAsync(usuarioId);
            return Ok(habitos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Habito habito)
        {
            var nuevo = await _repository.CreateAsync(habito);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Habito habito)
        {
            if (id != habito.Id) return BadRequest();
            await _repository.UpdateAsync(habito);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _repository.DeleteAsync(id);
            if (!resultado) return NotFound();
            return NoContent();
        }
    }
}