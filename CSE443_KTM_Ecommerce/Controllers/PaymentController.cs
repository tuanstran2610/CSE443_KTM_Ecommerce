using Microsoft.AspNetCore.Mvc;

namespace CSE443_KTM_Ecommerce.Controllers
{
    public class PaymentController : Controller
    {
        // GET: PaymentController
        public ActionResult PaymentList()
        {
            return View();
        }
        
        public ActionResult PaymentOrder()
        {
            return View();
        }

    }
}
