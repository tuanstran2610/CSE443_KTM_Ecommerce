using Microsoft.AspNetCore.Mvc;

namespace CSE443_KTM_Ecommerce.Controllers
{
    public class RoleController : Controller
    {
        // GET: RoleController
        public ActionResult RoleList()
        {
            return View();
        }
        
        public ActionResult RoleAdd()
        {
            return View();
        }
        
        public ActionResult RoleEdit()
        {
            return View();
        }

    }
}
