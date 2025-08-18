using inkTHINK.Domain.Entities;
using inkTHINK.Domain.Interfaces;
using inkTHINK.Infrastructure.Data;

namespace inkTHINK.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _db;
    public IGenericRepository<Contribuyente> Contribuyentes { get; }
    public IGenericRepository<TaxRule> TaxRules { get; }
    public IGenericRepository<Calculo> Calculos { get; }

    public UnitOfWork(AppDbContext db)
    {
        _db = db;
        Contribuyentes = new GenericRepository<Contribuyente>(_db);
        TaxRules = new GenericRepository<TaxRule>(_db);
        Calculos = new GenericRepository<Calculo>(_db);
    }

    public async Task<int> SaveChangesAsync() => await _db.SaveChangesAsync();
    public void Dispose() => _db.Dispose();
}