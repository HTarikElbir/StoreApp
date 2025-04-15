using StoreApp.Data.Entities;

namespace StoreApp.Data.Abstract;

public interface IStoreRepository
{
    IQueryable<Product> Products { get; }
    
    void AddProduct(Product product);
}