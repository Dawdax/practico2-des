using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GOES.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOES.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BitacoraController : ControllerBase
    {
        private readonly GoesDbContext _context;

        public BitacoraController(GoesDbContext context)
        {
            _context = context;
        }

        // GET: api/Bitacora
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bitacora>>> GetBitacora()
        {
            return await _context.Bitacora.ToListAsync();
        }

        // GET: api/Bitacora/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bitacora>> GetBitacora(int id)
        {
            var bitacora = await _context.Bitacora.FindAsync(id);

            if (bitacora == null)
            {
                return NotFound();
            }

            return Ok(bitacora);
        }

        // GET: api/Bitacora/candidato/5
        [HttpGet("candidato/{candidatoId}")]
        public async Task<ActionResult<IEnumerable<Bitacora>>> GetBitacoraByCandidato(int candidatoId)
        {
            var bitacoras = await _context.Bitacora
                .Where(b => b.Id == candidatoId)
                .ToListAsync();

            if (bitacoras == null || !bitacoras.Any())
            {
                return NotFound();
            }

            return Ok(bitacoras);
        }
    }
}
