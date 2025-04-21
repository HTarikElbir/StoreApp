using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Data.Abstract;
using StoreApp.Web.Helpers;
using StoreApp.Web.Models;

namespace StoreApp.Web.Pages;

public class CartModel : PageModel
{
    private IStoreRepository _repository;

    public CartModel(IStoreRepository repository)
    {
        _repository = repository;
    }
    
    public Cart? Cart{ get; set; }
    public void OnGet()
    {
        Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(); 
    }

    public IActionResult OnPost(int Id)
    {
        var product = _repository.Products.FirstOrDefault(p => p.Id == Id);

        if (product != null)
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.AddItem(product,1);
            HttpContext.Session.SetJson("cart", Cart);
        }
        
        return RedirectToPage("/Cart");
    }

    public IActionResult OnPostRemove(int Id)
    {
        Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        var product = Cart.CartItems.First(p => p.Product.Id == Id).Product;
        Cart?.RemoveItem(product);
        HttpContext.Session.SetJson("cart", Cart);
        return RedirectToPage("/Cart");
    }
}