using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bolsa_de_trabajo.Models
{
    public class CandidatesToJobs
    {
        [Key]
        public int IdCandidatesToJobs { get; set; }


        [ForeignKey("Jobs")]
        public int JobId { get; set; }
        public Jobs Jobs { get; set; }

        [ForeignKey("Candidates")]
        public int CandidateId { get; set; }
        public Candidates Candidates { get; set; }

    }
}
