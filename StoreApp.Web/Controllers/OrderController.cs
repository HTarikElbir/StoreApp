using Microsoft.AspNetCore.Mvc;
using StoreApp.Web.Models;

namespace StoreApp.Web.Controllers;

public class OrderController : Controller
{
    private Cart cart;
    public OrderController(Cart cartService)
    {
        cart = cartService;
    }
    // GET
    public IActionResult Checkout()
    {
        return View(new OrderModel() { Cart = cart });
    }
}