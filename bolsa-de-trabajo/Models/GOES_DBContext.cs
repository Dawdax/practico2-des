using Microsoft.EntityFrameworkCore;

namespace bolsa_de_trabajo.Models
{
    public class GOES_DBContext : DbContext
    {
        public GOES_DBContext(DbContextOptions<GOES_DBContext> options) : base(options) 
        {

        }
        public DbSet<Jobs> Jobs { get; set;}
        public DbSet<SelectorAgent> SelectorAgent { get; set; }
        public DbSet<Candidates> Candidates { get; set; }

    }
}
