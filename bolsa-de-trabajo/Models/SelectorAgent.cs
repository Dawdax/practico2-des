using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bolsa_de_trabajo.Models
{
    public class SelectorAgent
    {
        [Key]
        public int IdSelectorAgent { get; set; }

        [Required(ErrorMessage = "El campo de nombres es requerido")]
        [StringLength(200)]
        public string names { get; set; }

        [Required(ErrorMessage = "El campo de apellidos es requerido")]
        [StringLength(250)]
        public string lastName { get; set; }

        [Required(ErrorMessage = "El campo de teléfono es requerido")]
        [StringLength(50)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El campo de fecha de nacimiento es requerido")]
        public DateOnly Birthdate { get; set; }

        [Required(ErrorMessage = "El campo de email es requerido")]
        [StringLength(250)]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo de contraseña es requerido")]
        [StringLength(250)]
        public string Password { get; set; }

        public ICollection<SelectorAgentToJobs> selectorAgentToJobs { get; set; }

    }
}
