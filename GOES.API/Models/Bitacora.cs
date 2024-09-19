using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOES.API.Models
{
    public class Bitacora
    {
        [Key]
        public int Id { get; set; }  // Clave primaria autoincremental

        public string CandidatoCodigo { get; set; }  // Clave foránea como string

        public string Modificacion { get; set; }
        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        [ForeignKey("CandidatoCodigo")]
        public virtual HojaDeVida HojaDeVida { get; set; }  // Relación muchos a 1 con HojaDeVida usando CandidatoCodigo
    }
}
