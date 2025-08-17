namespace inkTHINK.Infrastructure.Data;

public static class Seed
{
    public static async Task EnsureSeedAsync(AppDbContext db)
    {
        await db.Database.MigrateAsync();

        if (!await db.TaxRules.AnyAsync())
        {
            db.TaxRules.AddRange(
                new TaxRule { Tipo = "ITBIS", Version = "v1", ParamsJson = "{\"tasa\":0.18}", VigenteDesde = DateTime.UtcNow.Date },
                new TaxRule { Tipo = "ISR", Version = "v1", ParamsJson = "{\"tramos\":[[416220.00,0.00],[624329.00,0.15],[867123.00,0.20],[9.9E99,0.25]],\"deduccionBasica\":0.0}", VigenteDesde = DateTime.UtcNow.Date }
            );
            await db.SaveChangesAsync();
        }
    }
}