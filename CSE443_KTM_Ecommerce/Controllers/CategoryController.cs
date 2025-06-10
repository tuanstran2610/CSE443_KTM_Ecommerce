using Microsoft.AspNetCore.Mvc;

namespace CSE443_KTM_Ecommerce.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
        public ActionResult CategoryList()
        {
            return View();
        }
        
        public ActionResult CategoryAdd()
        {
            return View();
        }
        
        public ActionResult CategoryEdit()
        {
            return View();
        }

    }
}
