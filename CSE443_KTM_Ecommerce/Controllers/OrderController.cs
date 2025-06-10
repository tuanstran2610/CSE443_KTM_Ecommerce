using Microsoft.AspNetCore.Mvc;

namespace CSE443_KTM_Ecommerce.Controllers
{
    public class OrderController : Controller
    {
        // GET: OrderController
        public ActionResult OrderList()
        {
            return View();
        }
        
        public ActionResult OrderDetail()
        {
            return View();
        }

    }
}
