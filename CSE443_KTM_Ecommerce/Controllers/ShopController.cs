using Microsoft.AspNetCore.Mvc;

namespace CSE443_KTM_Ecommerce.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShopList()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }
    }
}
