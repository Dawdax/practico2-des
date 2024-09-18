using System.ComponentModel.DataAnnotations;

namespace bolsa_de_trabajo.Models
{
    public class Jobs
    {
        [Key]
        public int IdJobs { get; set; }

        [Required(ErrorMessage = "El campo de titulo es requerido")]
        [StringLength(250)]
        public string Title { get; set; }

        [Required(ErrorMessage = "El campo de descripción es requerido")]
        public string Desciption { get; set; }

        [Display(Name = "Fecha de finalización")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "El campo de fecha de finalización es requerido")]
        public DateOnly EndDate { get; set; }

        public ICollection<Candidates> Candidates { get; set; }
        public ICollection<SelectorAgent> Agents { get; set; }
    }
}
