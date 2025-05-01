using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
        modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted).Property(p => p.Price).HasPrecision(18, 2);
        modelBuilder.Entity<Sale>().Property(s => s.TotalPrice).HasPrecision(18, 2);
        modelBuilder.Entity<Sale>().HasOne(s => s.Product).WithMany().IsRequired(false);

        base.OnModelCreating(modelBuilder);
    }
}