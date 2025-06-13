using Microsoft.AspNetCore.Mvc;

namespace CSE443_KTM_Ecommerce.Controllers
{
    public class CouponController : Controller
    {
        // GET: CouponController
        public ActionResult CouponList()
        {
            return View();
        }
        
        public ActionResult CouponAdd()
        {
            return View();
        }

    }
}
