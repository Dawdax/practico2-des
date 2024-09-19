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

        // GET: api/Candidato/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidato(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("GOES_DB")))
            {
                var query = "SELECT * FROM Candidato WHERE Id = @Id";
                var candidato = await db.QueryFirstOrDefaultAsync(query, new { Id = id });
                if (candidato != null)
                    return Ok(candidato);
                else
                    return NotFound("Candidato no encontrado");
            }
        }

        // POST: api/Candidato/hojadevida
        [HttpPost("hojadevida")]
        public async Task<IActionResult> CrearHojaDeVida([FromBody] HojaDeVidaDto hojaDto)
        {
            var hojaDeVida = new
            {
                CandidatoId = hojaDto.CandidatoId,
                FormacionAcademica = hojaDto.FormacionAcademica,
                ExperienciaProfesional = hojaDto.ExperienciaProfesional,
                ReferenciasPersonales = hojaDto.ReferenciasPersonales,
                Idiomas = hojaDto.Idiomas
            };

            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("GOES_DB")))
            {
                var query = @"INSERT INTO HojaDeVida (CandidatoId, FormacionAcademica, ExperienciaProfesional, ReferenciasPersonales, Idiomas)
                              VALUES (@CandidatoId, @FormacionAcademica, @ExperienciaProfesional, @ReferenciasPersonales, @Idiomas)";

                var result = await db.ExecuteAsync(query, hojaDeVida);
                if (result > 0)
                    return Ok("Hoja de vida registrada exitosamente");
                else
                    return BadRequest("Error al registrar la hoja de vida");
            }
        }

        // PUT: api/Candidato/hojadevida/5
        [HttpPut("hojadevida/{id}")]
        public async Task<IActionResult> ModificarHojaDeVida(int id, [FromBody] HojaDeVidaDto hojaDto)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("GOES_DB")))
            {
                var query = @"UPDATE HojaDeVida 
                              SET FormacionAcademica = @FormacionAcademica, 
                                  ExperienciaProfesional = @ExperienciaProfesional, 
                                  ReferenciasPersonales = @ReferenciasPersonales, 
                                  Idiomas = @Idiomas 
                              WHERE CandidatoId = @CandidatoId AND Id = @Id";

                var result = await db.ExecuteAsync(query, new
                {
                    Id = id,
                    CandidatoId = hojaDto.CandidatoId,
                    FormacionAcademica = hojaDto.FormacionAcademica,
                    ExperienciaProfesional = hojaDto.ExperienciaProfesional,
                    ReferenciasPersonales = hojaDto.ReferenciasPersonales,
                    Idiomas = hojaDto.Idiomas
                });

                if (result > 0)
                    return Ok("Hoja de vida modificada exitosamente");
                else
                    return BadRequest("Error al modificar la hoja de vida");
            }
        }

        // GET: api/Candidato/hojadevida/5
        [HttpGet("hojadevida/{id}")]
        public async Task<IActionResult> GetHojaDeVida(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("GOES_DB")))
            {
                var query = "SELECT * FROM HojaDeVida WHERE CandidatoId = @Id";
                var hojaDeVida = await db.QueryFirstOrDefaultAsync(query, new { Id = id });
                if (hojaDeVida != null)
                    return Ok(hojaDeVida);
                else
                    return NotFound("Hoja de vida no encontrada");
            }
        }
    }
}
