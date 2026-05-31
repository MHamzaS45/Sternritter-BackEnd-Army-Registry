// Database Context 
// manage connection b/w entity and database

using Microsoft.EntityFrameworkCore;
using Wandenreich.Api.Models;

namespace Wandenreich.Api.Data;

public class WandenreichDbContext : DbContext
{
    public WandenreichDbContext(DbContextOptions<WandenreichDbContext> options) 
    : base(options)
    {
    }
 
    // Expose Sternritter and RoyalGuard tables  for queries
    public DbSet<Sternritter> Sternritters => Set<Sternritter>();
    public DbSet<RoyalGuard> RoyalGuards => Set<RoyalGuard>();

    protected override void
    OnModelCreating(ModelBuilder modelBuilder)
    { 
        // Fluent api for column constraints. Keeps validation logic seperate from the model itself
        modelBuilder.Entity<Sternritter>(entity 
    => 
        {
            entity.HasKey(e => e.Id); 
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Letter).IsRequired().HasMaxLength(5);
            entity.Property(e => e.Schrift).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Position).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Image).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Ability).IsRequired().HasMaxLength(500);

        });

        modelBuilder.Entity<RoyalGuard>(entity => 
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
        });

    }

}