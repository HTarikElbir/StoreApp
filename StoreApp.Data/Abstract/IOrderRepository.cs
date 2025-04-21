using StoreApp.Data.Entities;

namespace StoreApp.Data.Abstract;

public interface IOrderRepository
{
    IQueryable<Order> Orders { get; }
    
    void SaveOrder(Order order);
}