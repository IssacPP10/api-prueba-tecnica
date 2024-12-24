namespace RegistroConsultaFallas.Models
{
    public class FallaCreateDto
    {
        public string NombreEquipo { get; set; }
        public string DescripcionFalla { get; set; }
        public DateTime FechaFalla { get; set; }
        public string NombrePropietario { get; set; }
        public string Email { get; set; }
    }
}
