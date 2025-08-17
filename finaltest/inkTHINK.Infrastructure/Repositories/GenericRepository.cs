namespace inkTHINK.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbContext _ctx;
    private readonly DbSet<T> _set;

    public GenericRepository(DbContext ctx)
    {
        _ctx = ctx;
        _set = _ctx.Set<T>();
    }

    public async Task AddAsync(T entity) => await _set.AddAsync(entity);
    public void Delete(T entity) => _set.Remove(entity);
    public async Task<IEnumerable<T>> GetAllAsync() => await _set.ToListAsync();
    public async Task<T?> GetByIdAsync(int id) => await _set.FindAsync(id);
    public void Update(T entity) => _set.Update(entity);
}