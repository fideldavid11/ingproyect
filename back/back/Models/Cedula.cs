using System.ComponentModel.DataAnnotations.Schema;

namespace back.Models
{
    public class Cedula
    {
        public int ID { get; set; }
        public string? CedulaNumber { get; set; }
        public string? FullName { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Sexo { get; set; }
        public string? TipoSangre { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Ocupacion { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string? ColegioElectoral { get; set; }
        public string? UbicacionColegio { get; set; }
        public string? DireccionResidencia { get; set; }
        public string? Sector { get; set; }
        public string? Municipio { get; set; }
        public string? Foto { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; } // Campo para la imagen
    }
}
