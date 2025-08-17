namespace inkTHINK.Infrastructure.Repositories;

public class RuleProvider : IRuleProvider
{
    private readonly AppDbContext _db;
    public RuleProvider(AppDbContext db) => _db = db;

    public string GetParamsJson(string tipo)
    {
        var regla = _db.TaxRules.AsNoTracking()
            .Where(r => r.Tipo == tipo && (r.VigenteHasta == null || r.VigenteHasta >= DateTime.UtcNow.Date))
            .OrderByDescending(r => r.VigenteDesde)
            .FirstOrDefault();
        if (regla == null) throw new InvalidOperationException($"No hay reglas activas para {tipo}");
        return regla.ParamsJson;
    }
}