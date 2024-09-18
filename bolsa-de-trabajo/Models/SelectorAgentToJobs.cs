using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bolsa_de_trabajo.Models
{
    public class SelectorAgentToJobs
    {
        [Key]
        public int IdSelectorAgentToJobs { get; set; }


        [ForeignKey("Jobs")]
        public int JobId { get; set; }
        public Jobs Jobs { get; set; }

        [ForeignKey("SelectorAgent")]
        public int SelectorAgentId { get; set; }
        public SelectorAgent SelectorAgent { get; set; }
    }
}
