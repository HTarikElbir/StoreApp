using StoreApp.Data.Abstract;
using StoreApp.Data.Entities;

namespace StoreApp.Data.Concrete;

public class EfStoreRepository: IStoreRepository
{
    private readonly StoreDbContext _context;

    public EfStoreRepository(StoreDbContext context)
    {
        _context = context;
    }
    
    public IQueryable<Product> Products => _context.Products;
    
    public void AddProduct(Product product)
    {
        throw new NotImplementedException();
    }
}