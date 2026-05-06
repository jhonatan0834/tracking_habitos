using Microsoft.AspNetCore.Mvc;
using TrackingHabitos.API.Data;
using TrackingHabitos.API.Models;
using TrackingHabitos.API.Repositories;

namespace TrackingHabitos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroProgresoController : ControllerBase
    {
        private readonly RegistroProgresoRepository _repository;

        public RegistroProgresoController(AppDbContext context)
        {
            _repository = new RegistroProgresoRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var registros = await _repository.GetAllAsync();
            return Ok(registros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var registro = await _repository.GetByIdAsync(id);
            if (registro == null) return NotFound();
            return Ok(registro);
        }

        [HttpGet("habito/{habitoId}")]
        public async Task<IActionResult> GetByHabito(int habitoId)
        {
            var registros = await _repository.GetByHabitoIdAsync(habitoId);
            return Ok(registros);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegistroProgreso registro)
        {
            var nuevo = await _repository.CreateAsync(registro);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
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