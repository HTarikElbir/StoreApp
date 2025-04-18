using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Web.Models;

namespace StoreApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly int _pageSize = 3;
        private readonly IStoreRepository _storeRepository;
        public HomeController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        
        // GET: HomeController
        public ActionResult Index(string category, int page = 1)
        {
            return View(new ProductListViewModel
            {
                Products = _storeRepository.GetProductsByCategory(category,page,_pageSize)
                    .Select(p=>new ProductViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                    }),
                PageInfo = new PageInfo
                {
                    ItemsPerPage = _pageSize,
                    CurrentPage = page,
                    TotalItems = _storeRepository.GetProductsCount(category)
                }
            });
        }
        
    }
}
