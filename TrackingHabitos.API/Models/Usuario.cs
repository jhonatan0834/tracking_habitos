namespace TrackingHabitos.API.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public int Xp { get; set; } = 0;
        public int Nivel { get; set; } = 1;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}