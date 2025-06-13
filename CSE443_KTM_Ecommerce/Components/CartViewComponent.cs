using CSE443_KTM_Ecommerce.Data;
using CSE443_KTM_Ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSE443_KTM_Ecommerce.Components
{
    public class CartViewComponent:ViewComponent
    {
        private readonly KTMDbContext _context;
        private readonly UserManager<User> _userManager;

        public CartViewComponent(KTMDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View(new Cart { CartItems = new List<CartItem>() });
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

            var cart = await _context.Carts
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Product)
                        .ThenInclude(p => p.ProductImages)
                .FirstOrDefaultAsync(c => c.UserId == user.Id);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = user.Id,
                    CartItems = new List<CartItem>()
                };
            }

            return View(cart);
        }
    }
}
