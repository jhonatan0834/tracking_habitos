using Microsoft.EntityFrameworkCore;
using TrackingHabitos.API.Models;

namespace TrackingHabitos.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Habito> Habitos { get; set; }
        public DbSet<RegistroProgreso> RegistrosProgreso { get; set; }
    }
}