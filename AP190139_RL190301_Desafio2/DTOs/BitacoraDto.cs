    public class BitacoraDto
    {
        public string CandidatoCodigo { get; set; }  // Código del candidato
        public string Modificacion { get; set; }     // Descripción de las modificaciones
        public DateTime FechaModificacion { get; set; } = DateTime.Now;  // Fecha de la modificación
    }

