namespace inkTHINK.Infrastructure.Config;

public static class DbConfig
{
    public static IServiceCollection AddAppDb(this IServiceCollection services, string? connString)
    {
        if (string.IsNullOrWhiteSpace(connString))
            throw new ArgumentException("La cadena de conexión no puede ser nula", nameof(connString));

        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connString));
        return services;
    }
}
