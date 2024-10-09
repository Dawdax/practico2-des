using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GOES.API.Models
{
    public class GoesDbContext : IdentityDbContext<Usuario>
    {
        public GoesDbContext(DbContextOptions<GoesDbContext> options)
            : base(options)
        {
        }

        public DbSet<HojaDeVida> HojaDeVida { get; set; }
        public DbSet<Bitacora> Bitacora { get; set; }
    }
}
