using StoreApp.Data.Entities;

namespace StoreApp.Web.Models;

public class Cart
{
    public List<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual void AddItem(Product product, int quantity)
    {
        var item = CartItems.Where(p => p.Product.Id == product.Id).FirstOrDefault();

        if (item == null)
        {
            CartItems.Add(new CartItem { Product = product, Quantity = quantity });
        }
        else
        {
            item.Quantity += quantity;
        }
    }

    public virtual void RemoveItem(Product product)
    {
        CartItems.RemoveAll(p => p.Product.Id == product.Id);
    }

    public decimal GetTotal()
    {
        return CartItems.Sum(p => p.Product.Price * p.Quantity);
    }

    public virtual void Clear()
    {
        CartItems.Clear();
    }
}

public class CartItem
{
    public int CartItemId { get; set; }
    public Product Product { get; set; } = new();
    public int Quantity { get; set; }
}