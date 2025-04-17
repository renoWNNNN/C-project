using Microsoft.EntityFrameworkCore;
using SPAKLY.Modelos;

namespace SPAKLY.Datos

{
    public class SPAKLYDbContext : DbContext
    {
        public SPAKLYDbContext(DbContextOptions<SPAKLYDbContext> options)
            : base(options) {}

        public DbSet<Cliente> Clientes { get; set; }
    }
}