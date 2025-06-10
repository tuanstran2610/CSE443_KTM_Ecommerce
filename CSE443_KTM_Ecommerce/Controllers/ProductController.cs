using Microsoft.AspNetCore.Mvc;

namespace CSE443_KTM_Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult ProductList()
        {
            return View();
        }
        
        public ActionResult ProductAdd()
        {
            return View();
        }

        
        public ActionResult ProductEdit()
        {
            return View();
        }


    }
}
