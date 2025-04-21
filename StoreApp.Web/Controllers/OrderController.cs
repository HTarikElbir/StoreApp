using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;
using StoreApp.Data.Entities;
using StoreApp.Web.Models;

namespace StoreApp.Web.Controllers;

public class OrderController : Controller
{
    private Cart _cart;
    private IOrderRepository _orderRepository;
    
    public OrderController(Cart cartService, IOrderRepository orderRepository)
    {
        _cart = cartService;
        _orderRepository = orderRepository;
    }
    // GET
    public IActionResult Checkout()
    {
        return View(new OrderModel() { Cart = _cart });
    }
    
    //Post
    [HttpPost]
    public IActionResult Checkout(OrderModel orderModel)
    {
        if (_cart.CartItems.Count == 0)
        {
            ModelState.AddModelError("Cart", "There are no items in the cart.");
        }

        if (ModelState.IsValid)
        {
            var order = new Order
            {
                Name = orderModel.Name,
                AddressLine = orderModel.AddressLine,
                City = orderModel.City,
                Phone = orderModel.Phone,
                Email = orderModel.Email,
                OrderDate = DateTime.Now,
                OrderItems = _cart.CartItems.Select(i => new OrderItem
                {
                    ProductId = i.Product.Id,
                    Price = (double)i.Product.Price,
                    Quantity = i.Quantity
                }).ToList()
            };
            
            _orderRepository.SaveOrder(order);
            _cart.Clear();
            return RedirectToPage("/Completed", new { OrderId= order.OrderId});
        }
        else
        {
            orderModel.Cart = _cart;
            return View(orderModel);
        }
        
        
       
    }
}