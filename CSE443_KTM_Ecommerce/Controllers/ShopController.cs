using CSE443_KTM_Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;

namespace CSE443_KTM_Ecommerce.Controllers
{
    public class ShopController : Controller
    {

        private readonly KTMDbContext _context;
        public ShopController(KTMDbContext context)
        {
            _context = context;
        }
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
