using System.ComponentModel.DataAnnotations;

namespace GOES.API.Models
{
    public class Candidato
    {
        [Key]
        public string Codigo { get; set; }  // Clave primaria como string

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Contrasena { get; set; }

        public virtual HojaDeVida HojaDeVida { get; set; }  // Relación 1 a 1 con HojaDeVida
    }
}
