
using Microsoft.AspNetCore.Mvc;
using TrackingHabitos.API.Data;
using TrackingHabitos.API.Models;
using TrackingHabitos.API.Repositories;

namespace TrackingHabitos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _repository;

        public UsuariosController(AppDbContext context)
        {
            _repository = new UsuarioRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _repository.GetAllAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _repository.GetByIdAsync(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            var nuevo = await _repository.CreateAsync(usuario);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Usuario usuario)
        {
            if (id != usuario.Id) return BadRequest();
            await _repository.UpdateAsync(usuario);
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