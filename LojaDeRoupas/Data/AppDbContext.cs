using Microsoft.EntityFrameworkCore;
using LojaDeRoupas.Models;

namespace LojaDeRoupas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Clothing> Clothings { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ClothingColor> ClothingColors { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClothingColor>()
                .HasKey(cc => new { cc.ClothingId, cc.ColorId });
        }
        
    }
}