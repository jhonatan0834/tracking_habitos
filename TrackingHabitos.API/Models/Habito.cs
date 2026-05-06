namespace TrackingHabitos.API.Models
{
    public class Habito
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Frecuencia { get; set; } = string.Empty;
        public bool EstaActivo { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Relación con Usuario
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}