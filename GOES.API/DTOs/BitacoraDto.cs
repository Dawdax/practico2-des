namespace GOES.API.DTOs
{
    public class BitacoraDto
    {
        public string CandidatoCodigo { get; set; }  // Se recibe para crear el registro en la bitácora
        public string Modificacion { get; set; }
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
