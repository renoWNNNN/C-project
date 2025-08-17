var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<TaxRuleService>();
builder.Services.AddScoped<ITaxService, TaxService>();

// Registrar DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public class TaxService : ITaxService
{
    public object CalculateIncomeTax(decimal amount)
    {
        throw new NotImplementedException();
    }

    public object CalculateITBIS(decimal amount)
    {
        throw new NotImplementedException();
    }
}

public interface ITaxService
{
    object CalculateIncomeTax(decimal amount);
    object CalculateITBIS(decimal amount);
}