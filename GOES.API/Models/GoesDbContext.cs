using Microsoft.EntityFrameworkCore;

namespace GOES.API.Models
{
    public class GoesDbContext : DbContext
    {
        public GoesDbContext(DbContextOptions<GoesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<HojaDeVida> HojasDeVida { get; set; }
        public DbSet<Bitacora> Bitacora { get; set; }
    }
}
