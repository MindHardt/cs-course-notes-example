using Microsoft.EntityFrameworkCore;
using Web.Components;
using Web.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(db =>
{
    db.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")).EnableSensitiveDataLogging();
});

// Add services to the container.
builder.Services.AddRazorComponents();

var app = builder.Build();

await using (var scope = app.Services.CreateAsyncScope())
{
    await scope.ServiceProvider.GetRequiredService<DataContext>().Database.MigrateAsync();
}

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>();

app.Run();
