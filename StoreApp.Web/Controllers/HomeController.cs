using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;
using StoreApp.Web.Models;

namespace StoreApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly int pageSize = 3;
        private readonly IStoreRepository _storeRepository;
        public HomeController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        
        // GET: HomeController
        public ActionResult Index(int page = 1)
        {
            var products = _storeRepository
                .Products
                .Skip((page - 1) * pageSize) 
                .Select(p => new ProductViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        //Category = p.Category,
                    }).Take(pageSize);
            
            return View(new ProductListViewModel
            {
                Products = products,
                PageInfo = new PageInfo
                {
                    ItemsPerPage = pageSize,
                    CurrentPage = page,
                    TotalItems = _storeRepository.Products.Count()
                }
            });
        }
        
    }
}
