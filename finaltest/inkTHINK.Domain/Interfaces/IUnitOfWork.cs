namespace inkTHINK.Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Contribuyente> Contribuyentes { get; }
    IGenericRepository<TaxRule> TaxRules { get; }
    IGenericRepository<Calculo> Calculos { get; }
    Task<int> SaveChangesAsync();
}