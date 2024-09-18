using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bolsa_de_trabajo.Models
{
    public class Candidates
    {
        [Key]
        public int IdCandidates { get; set; }

        [Required(ErrorMessage = "El campo de nombres es requerido")]
        [StringLength(200)]
        public string names { get; set; }

        [Required(ErrorMessage = "El campo de apellidos es requerido")]
        [StringLength(250)]
        public string lastName { get; set; }

        [Required(ErrorMessage = "El campo de teléfono es requerido")]
        [StringLength(50)]
        public string Phone { get; set; }

        [ForeignKey("Jobs")]
        public int JobId { get; set; }
        public Jobs Jobs { get; set; }

        public CV CV { get; set; }

    }
}
