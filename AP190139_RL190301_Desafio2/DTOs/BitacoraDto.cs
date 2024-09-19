namespace AP190139_RL190301_Desafio2.DTOs  // Cambia 'YourProjectNamespace' por el namespace de tu proyecto
{
    public class BitacoraDto
    {
        public string CandidatoCodigo { get; set; }
        public string Modificacion { get; set; }
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
