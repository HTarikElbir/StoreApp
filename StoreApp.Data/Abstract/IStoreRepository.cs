using StoreApp.Data.Entities;

namespace StoreApp.Data.Abstract;

public interface IStoreRepository
{
    IQueryable<Product> Products { get; }
    IQueryable<Category> Categories { get; }
    
    void AddProduct(Product product);
}