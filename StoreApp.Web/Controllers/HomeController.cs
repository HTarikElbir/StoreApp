using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;

namespace StoreApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreRepository _storeRepository;
        public HomeController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        
        // GET: HomeController
        public ActionResult Index() => View();
        
    }
}
