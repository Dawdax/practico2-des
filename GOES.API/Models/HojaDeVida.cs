namespace GOES.API.Models
{
    public class HojaDeVida
    {
        public int Id { get; set; }
        public int CandidatoId { get; set; }
        public string FormacionAcademica { get; set; }
        public string ExperienciaProfesional { get; set; }
        public string ReferenciasPersonales { get; set; }
        public string Idiomas { get; set; }
    }
}
