using CSE443_KTM_Ecommerce.Data;
using CSE443_KTM_Ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSE443_KTM_Ecommerce.Components
{
    public class CartMiniViewComponent : ViewComponent
    {
        private readonly KTMDbContext _context;
        private readonly UserManager<User> _userManager;

        public CartMiniViewComponent(KTMDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int itemCount = 0;

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                itemCount = await _context.CartItems.Where(ci => ci.Cart.UserId == user.Id).CountAsync();       
            }

            return View(itemCount);
        }
    }

}
