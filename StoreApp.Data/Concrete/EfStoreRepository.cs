using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Data.Entities;

namespace StoreApp.Data.Concrete;

public class EfStoreRepository: IStoreRepository
{
    private StoreDbContext _context;

    public EfStoreRepository(StoreDbContext context)
    {
        _context = context;
    }
    
    public IQueryable<Product> Products => _context.Products;
    public IQueryable<Category> Categories => _context.Categories;
    
    public void AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public int GetProductsCount(string category)
    {
        return category == null
            ? Products.Count()
            : Products.Include(p => p.Categories)
                .Where(p => p.Categories.Any(u => u.Url == category)).Count();
    }

    public IEnumerable<Product> GetProductsByCategory(string category, int page, int pageSize)
    {
        var products = Products;

        if (!string.IsNullOrEmpty(category))
        {
            products = products.Include(p => p.Categories)
                .Where(p => p.Categories.Any(u => u.Url == category));
        }

        return products.Skip((page - 1) * pageSize).Take(pageSize);
    }
}