namespace inkTHINK.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Contribuyente> Contribuyentes => Set<Contribuyente>();
    public DbSet<TaxRule> TaxRules => Set<TaxRule>();
    public DbSet<Calculo> Calculos => Set<Calculo>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaxRule>().Property(x => x.ParamsJson).HasColumnType("TEXT");
        modelBuilder.Entity<Calculo>().Property(x => x.RequestSnapshot).HasColumnType("TEXT");
        modelBuilder.Entity<Calculo>().Property(x => x.ResultSnapshot).HasColumnType("TEXT");
        modelBuilder.Entity<Calculo>().Property(x => x.ReglasVersionadas).HasColumnType("TEXT");
    }
}
