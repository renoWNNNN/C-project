using Microsoft.EntityFrameworkCore;
using SPAKLY.Modelos;

namespace SPAKLY.Datos

{
public class SPAKLYDbContext : DbContext
{
    public SPAKLYDbContext(DbContextOptions<SPAKLYDbContext> options)
        : base(options) {}

    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Productos> Productos { get; set; }
    public DbSet<Ordenes> Ordenes { get; set; }
    public DbSet<DetallePedido> DetallePedido { get; set; }
    public DbSet<Envio> Envios { get; set; }

}
    
    }
    

