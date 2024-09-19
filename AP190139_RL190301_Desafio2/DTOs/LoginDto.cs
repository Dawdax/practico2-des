using System.ComponentModel.DataAnnotations;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string CorreoElectronico { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Contrasena { get; set; }
}
