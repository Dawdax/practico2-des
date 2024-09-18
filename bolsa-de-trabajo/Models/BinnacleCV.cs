using System.ComponentModel.DataAnnotations;

namespace bolsa_de_trabajo.Models
{
    public class BinnacleCV
    {
        [Key]
        public int IdBinnacleCV { get; set; }

        public int CVId { get; set; }
        public CV CV { get; set; }

        [Required(ErrorMessage = "El campo de 'sobre los cambios' académica es requerido")]
        public string Changes { get; set; }

        public DateTime ChangeDate { get; set; }

        public string Education { get; set; }

        public string WorkExperience { get; set; }

        public string PersonalReferences { get; set; }

        public string Lenguages { get; set; }
    }
}
