using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;
using GOES.API.DTOs;

namespace GOES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HojaDeVidaController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public HojaDeVidaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // POST: api/HojaDeVida/ingresarHojaDeVida
        [HttpPost("ingresarHojaDeVida")]
        public async Task<IActionResult> IngresarHojaDeVida([FromBody] HojaDeVidaDto hojaDto, [FromQuery] string candidatoCodigo)
        {
            // Se asegura que CandidatoCodigo sea obligatorio
            if (string.IsNullOrEmpty(candidatoCodigo))
            {
                return BadRequest("CandidatoCodigo es obligatorio.");
            }

            var hojaDeVida = new
            {
                CandidatoCodigo = candidatoCodigo,  // Usar el CandidatoCodigo que llega en el query
                FormacionAcademica = hojaDto.FormacionAcademica,
                ExperienciaProfesional = hojaDto.ExperienciaProfesional,
                ReferenciasPersonales = hojaDto.ReferenciasPersonales,
                Idiomas = hojaDto.Idiomas
            };

            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("GOES_DB")))
            {
                var query = @"INSERT INTO HojaDeVida (CandidatoCodigo, FormacionAcademica, ExperienciaProfesional, ReferenciasPersonales, Idiomas)
                              VALUES (@CandidatoCodigo, @FormacionAcademica, @ExperienciaProfesional, @ReferenciasPersonales, @Idiomas)";

                var result = await db.ExecuteAsync(query, hojaDeVida);
                if (result > 0)
                    return Ok("Hoja de vida registrada exitosamente.");
                else
                    return BadRequest("Error al registrar la hoja de vida.");
            }
        }

        // PUT: api/HojaDeVida/actualizarHojaDeVida
        [HttpPut("actualizarHojaDeVida")]
        public async Task<IActionResult> ModificarHojaDeVida([FromQuery] string candidatoCodigo, [FromBody] HojaDeVidaDto hojaDto, [FromQuery] string modificacion)
        {
            // Validar que CandidatoCodigo sea proporcionado
            if (string.IsNullOrEmpty(candidatoCodigo))
            {
                return BadRequest("CandidatoCodigo es obligatorio.");
            }

            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("GOES_DB")))
            {
                // Actualizar Hoja de Vida
                var queryHojaDeVida = @"UPDATE HojaDeVida 
                                        SET FormacionAcademica = @FormacionAcademica, 
                                            ExperienciaProfesional = @ExperienciaProfesional, 
                                            ReferenciasPersonales = @ReferenciasPersonales, 
                                            Idiomas = @Idiomas 
                                        WHERE CandidatoCodigo = @CandidatoCodigo";

                var resultHojaDeVida = await db.ExecuteAsync(queryHojaDeVida, new
                {
                    CandidatoCodigo = candidatoCodigo,  // Pasamos CandidatoCodigo como parámetro
                    FormacionAcademica = hojaDto.FormacionAcademica,
                    ExperienciaProfesional = hojaDto.ExperienciaProfesional,
                    ReferenciasPersonales = hojaDto.ReferenciasPersonales,
                    Idiomas = hojaDto.Idiomas
                });

                if (resultHojaDeVida > 0)
                {
                    // Registrar en Bitácora
                    var queryBitacora = @"INSERT INTO Bitacora (CandidatoCodigo, Modificacion, FechaModificacion)
                                          VALUES (@CandidatoCodigo, @Modificacion, @FechaModificacion)";

                    var resultBitacora = await db.ExecuteAsync(queryBitacora, new
                    {
                        CandidatoCodigo = candidatoCodigo,  // CandidatoCodigo también en Bitácora
                        Modificacion = modificacion,  // Descripción de la modificación
                        FechaModificacion = DateTime.Now
                    });

                    if (resultBitacora > 0)
                        return Ok("Hoja de vida modificada y bitácora actualizada exitosamente.");
                    else
                        return Ok("Hoja de vida modificada, pero no se pudo registrar en la bitácora.");
                }
                else
                {
                    return BadRequest("Error al modificar la hoja de vida.");
                }
            }
        }

        // GET: api/HojaDeVida/hojadevida/{codigo}
        [HttpGet("hojadevida/{codigo}")]
        public async Task<IActionResult> GetHojaDeVida(string codigo)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("GOES_DB")))
            {
                var query = "SELECT * FROM HojaDeVida WHERE CandidatoCodigo = @CandidatoCodigo";
                var hojaDeVida = await db.QueryFirstOrDefaultAsync(query, new { CandidatoCodigo = codigo });
                if (hojaDeVida != null)
                    return Ok(hojaDeVida);
                else
                    return NotFound("Hoja de vida no encontrada.");
            }
        }
    }
}
