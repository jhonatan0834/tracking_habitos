namespace TrackingHabitos.API.Models
{
    public class RegistroProgreso
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Nota { get; set; } = string.Empty;
        public bool Completado { get; set; } = false;

        // Relación con Habito
        public int HabitoId { get; set; }
        public Habito? Habito { get; set; }
    }
}