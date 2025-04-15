using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Entities;

namespace StoreApp.Data.Concrete;

public class StoreDbContext: DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(
            new List<Product>()
            {
                new () { Id = 1, Name = "IPhone X", Price = 10000, Description = "Good", Category = "Phone"},
                new () { Id = 2, Name = "IPhone 11", Price = 20000, Description = "Good", Category = "Phone"},
                new () { Id = 3, Name = "IPhone 12", Price = 30000, Description = "Good", Category = "Phone"},
                new () { Id = 4, Name = "IPhone 13", Price = 40000, Description = "Good", Category = "Phone"},
                new () { Id = 5, Name = "IPhone 14", Price = 50000, Description = "Good", Category = "Phone"},
            });
    }
}