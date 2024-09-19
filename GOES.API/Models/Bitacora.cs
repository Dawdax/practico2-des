namespace GOES.API.Models
{
    public class Bitacora
    {
        public int Id { get; set; }
        public int CandidatoId { get; set; }
        public string Modificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
