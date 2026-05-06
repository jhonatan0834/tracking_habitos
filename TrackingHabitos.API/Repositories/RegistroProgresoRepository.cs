using Microsoft.EntityFrameworkCore;
using TrackingHabitos.API.Data;
using TrackingHabitos.API.Models;

namespace TrackingHabitos.API.Repositories
{
    public class RegistroProgresoRepository
    {
        private readonly AppDbContext _context;

        public RegistroProgresoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroProgreso>> GetAllAsync()
        {
            return await _context.RegistrosProgreso
                .Include(r => r.Habito)
                .ToListAsync();
        }

        public async Task<RegistroProgreso?> GetByIdAsync(int id)
        {
            return await _context.RegistrosProgreso
                .Include(r => r.Habito)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<RegistroProgreso>> GetByHabitoIdAsync(int habitoId)
        {
            return await _context.RegistrosProgreso
                .Where(r => r.HabitoId == habitoId)
                .ToListAsync();
        }

        public async Task<RegistroProgreso> CreateAsync(RegistroProgreso registro)
        {
            _context.RegistrosProgreso.Add(registro);
            await _context.SaveChangesAsync();
            return registro;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var registro = await _context.RegistrosProgreso.FindAsync(id);
            if (registro == null) return false;
            _context.RegistrosProgreso.Remove(registro);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}