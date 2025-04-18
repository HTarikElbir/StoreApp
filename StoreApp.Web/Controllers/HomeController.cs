using AutoMapper;
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
        private readonly IMapper _mapper;
        public HomeController(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }
        
        // GET: HomeController
        public ActionResult Index(string category, int page = 1)
        {
            return View(new ProductListViewModel
            {
                Products = _storeRepository.GetProductsByCategory(category,page,_pageSize)
                    .Select(product=> _mapper.Map<ProductViewModel>(product)),
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
