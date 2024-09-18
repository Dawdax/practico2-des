using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bolsa_de_trabajo.Models
{
    public class CV
    {
        [Key]
        public int IdCv { get; set; }

        [Required(ErrorMessage = "El campo de formación académica es requerido")]
        public string Education { get; set; }

        [Required(ErrorMessage = "El campo de experiencia laboral es requerido")]
        public string WorkExperience { get; set; }

        [Required(ErrorMessage = "El campo de referencias personales es requerido")]
        public string PersonalReferences { get; set; }

        [Required(ErrorMessage = "El campo de idiomas es requerido")]
        public string Lenguages { get; set; }

        [ForeignKey("Candidates")]
        public int CandidateId { get; set; }

        public Candidates Candidate { get; set; }

    }
}
