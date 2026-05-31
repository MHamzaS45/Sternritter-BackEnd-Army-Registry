using Microsoft.EntityFrameworkCore;
using Wandenreich.Api.Data;
using Wandenreich.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Register the db context class with SQLite as the provider
builder.Services.AddDbContext<WandenreichDbContext>(options =>
    options.UseSqlite("Data Source=wandenreich.db"));
// register repo in DI container, to tell which concrete class to provide
// Sternritter repository
builder.Services.AddScoped<ISternritterRepository, SternritterRepository>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();


/// Verify compilation and database connection
/// dotnet run