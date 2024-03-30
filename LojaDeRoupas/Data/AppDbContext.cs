using Microsoft.EntityFrameworkCore;
using LojaDeRoupas.Models;

namespace LojaDeRoupas.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Clothing> Clothings { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Brand> Brands { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Color>().HasKey(c => new { c.ClothingId, c.Id });
        modelBuilder.Entity<Brand>().HasKey(b => new { b.ClothingId, b.Id });
    }
}