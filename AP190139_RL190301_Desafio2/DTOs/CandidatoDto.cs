using System;
using System.ComponentModel.DataAnnotations;

public class CandidatoDto
{
    [Required]
    public string Nombre { get; set; }

    [Required]
    public string Apellidos { get; set; }

    [Required]
    [Phone]
    public string Telefono { get; set; }

    [Required]
    [EmailAddress]
    public string CorreoElectronico { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime FechaNacimiento { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Contrasena { get; set; }
}
