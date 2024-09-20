using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Threading.Tasks;
using GOES.API.DTOs;


namespace GOES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CandidatoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // POST: api/Candidato/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CandidatoDto candidatoDto)
        {
            // Generar código único basado en los apellidos
            var codigo = $"{candidatoDto.Apellidos.Substring(0, 2).ToUpper()}{new Random().Next(10000000, 99999999)}";

            // Crear el objeto de candidato
            var candidato = new
            {
                Codigo = codigo,
                Nombre = candidatoDto.Nombre,
                Apellidos = candidatoDto.Apellidos,
                Telefono = candidatoDto.Telefono,
                CorreoElectronico = candidatoDto.CorreoElectronico,
                FechaNacimiento = candidatoDto.FechaNacimiento,
                Contrasena = candidatoDto.Contrasena
            };

            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("GOES_DB")))
            {
                var query = @"INSERT INTO Candidato (Codigo, Nombre, Apellidos, Telefono, CorreoElectronico, FechaNacimiento, Contrasena)
                      VALUES (@Codigo, @Nombre, @Apellidos, @Telefono, @CorreoElectronico, @FechaNacimiento, @Contrasena)";

                var result = await db.ExecuteAsync(query, candidato);
                if (result > 0)
                    return Ok(new { Message = "Candidato registrado exitosamente", Codigo = codigo });
                else
                    return BadRequest("Error al registrar el candidato");
            }
        }


        // GET: api/Candidato/{codigo}
        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetCandidato(string codigo)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("GOES_DB")))
            {
                var query = "SELECT * FROM Candidato WHERE Codigo = @Codigo";
                var candidato = await db.QueryFirstOrDefaultAsync(query, new { Codigo = codigo });
                if (candidato != null)
                    return Ok(candidato);
                else
                    return NotFound("Candidato no encontrado");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("GOES_DB")))
            {
                var query = "SELECT Codigo FROM Candidato WHERE CorreoElectronico = @CorreoElectronico AND Contrasena = @Contrasena";
                var candidatoCodigo = await db.QueryFirstOrDefaultAsync<string>(query, new { loginDto.CorreoElectronico, loginDto.Contrasena });
                if (candidatoCodigo != null)
                    return Ok(new { Codigo = candidatoCodigo });  // Devolver el código del candidato
                else
                    return Unauthorized("Correo o contraseña incorrectos");
            }
        }


    }
}
