using Microsoft.EntityFrameworkCore;
using TrackingHabitos.API.Data;
using TrackingHabitos.API.Models;

namespace TrackingHabitos.API.Repositories
{
    public class HabitoRepository
    {
        private readonly AppDbContext _context;

        public HabitoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Habito>> GetAllAsync()
        {
            return await _context.Habitos
                .Include(h => h.Usuario)
                .ToListAsync();
        }

        public async Task<Habito?> GetByIdAsync(int id)
        {
            return await _context.Habitos
                .Include(h => h.Usuario)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<List<Habito>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _context.Habitos
                .Where(h => h.UsuarioId == usuarioId)
                .ToListAsync();
        }

        public async Task<Habito> CreateAsync(Habito habito)
        {
            _context.Habitos.Add(habito);
            await _context.SaveChangesAsync();
            return habito;
        }

        public async Task<bool> UpdateAsync(Habito habito)
        {
            _context.Habitos.Update(habito);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var habito = await _context.Habitos.FindAsync(id);
            if (habito == null) return false;
            _context.Habitos.Remove(habito);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}