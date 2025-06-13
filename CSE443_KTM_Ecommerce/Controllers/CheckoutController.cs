using Microsoft.AspNetCore.Mvc;

namespace CSE443_KTM_Ecommerce.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
