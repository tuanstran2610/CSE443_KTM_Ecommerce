using Microsoft.AspNetCore.Mvc;

namespace CSE443_KTM_Ecommerce.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        public ActionResult UserList()
        {
            return View();
        }
        
        public ActionResult UserDetail()
        {
            return View();
        }



    }
}
