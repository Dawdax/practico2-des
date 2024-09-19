using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace GOES.API.Models
{
    public class HojaDeVida
    {
        [Key, ForeignKey("Candidato")]
        public string CandidatoCodigo { get; set; }  // Clave primaria y foránea para relacionarse con Candidato

        public string FormacionAcademica { get; set; }
        public string ExperienciaProfesional { get; set; }
        public string ReferenciasPersonales { get; set; }
        public string Idiomas { get; set; }

        public virtual Candidato Candidato { get; set; }  // Relación 1 a 1 con Candidato
        public virtual ICollection<Bitacora> Bitacoras { get; set; }  // Relación 1 a muchos con Bitacora
    }
}
