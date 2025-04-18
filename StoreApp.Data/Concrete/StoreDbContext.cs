using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Entities;

namespace StoreApp.Data.Concrete;

public class StoreDbContext: DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .HasMany(e => e.Categories)
            .WithMany(e => e.Products)
            .UsingEntity<ProductCategory>();
        
        modelBuilder.Entity<Category>()
            .HasIndex(u => u.Url)
            .IsUnique();
        
        modelBuilder.Entity<Product>().HasData(
            new List<Product>()
            {
                new () { Id = 1, Name = "IPhone X", Price = 10000, Description = "Good"},
                new () { Id = 2, Name = "IPhone 11", Price = 20000, Description = "Good"},
                new () { Id = 3, Name = "IPhone 12", Price = 30000, Description = "Good"},
                new () { Id = 4, Name = "IPad 11", Price = 40000, Description = "Good"},
                new () { Id = 5, Name = "IPad", Price = 50000, Description = "Good"},
            });

        modelBuilder.Entity<Category>().HasData(
            new List<Category>()
            {
                new () { Id = 1, Name = "Phone", Url = "phone"},
                new () { Id = 2, Name = "Pc", Url = "pc"},
                new () { Id = 3, Name = "Tablet", Url = "tablet"},
                new () { Id = 4, Name = "Electronic", Url = "electronic"},
            }
        );

        modelBuilder.Entity<ProductCategory>().HasData(
            new List<ProductCategory>()
            {
                new ProductCategory() { ProductId = 1, CategoryId = 1},
                new ProductCategory() { ProductId = 1, CategoryId = 4},
                new ProductCategory() { ProductId = 2, CategoryId = 1},
                new ProductCategory() { ProductId = 2, CategoryId = 4},
                new ProductCategory() { ProductId = 3, CategoryId = 1},
                new ProductCategory() { ProductId = 3, CategoryId = 4},
                new ProductCategory() { ProductId = 4, CategoryId = 3},
                new ProductCategory() { ProductId = 4, CategoryId = 4},
                new ProductCategory() { ProductId = 5, CategoryId = 3},
                new ProductCategory() { ProductId = 5, CategoryId = 4},
            });
    }
}