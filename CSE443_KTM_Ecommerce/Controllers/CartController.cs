using CSE443_KTM_Ecommerce.Data;
using CSE443_KTM_Ecommerce.Extensions;
using CSE443_KTM_Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
namespace CSE443_KTM_Ecommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly KTMDbContext _context;
        public CartController(KTMDbContext context)
        {
            _context = context;   
        }
        public IActionResult Index()
        {
            return View();
        }

        // 
        //private List<CartItem> GetCart()
        //{
        //    var cart = HttpContext.Session.Get("cart") as List<CartItem>;
        //    if (cart == null)
        //    {
        //        cart = new List<CartItem>();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}
       
        public async Task<IActionResult> AddToCart([FromBody] int productId , [FromBody]  int quantity)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(p => p.Id == productId);
            if(product == null)
            {
                return NotFound();
            }
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                var cart = HttpContext.Session.GetObject<Cart>("cart") ?? new Cart();
                var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
                if (existingItem != null)
                {
                    existingItem.Quantity+= quantity;
                }
                else
                {
                    cart.CartItems.Add(new CartItem
                    {
                        ProductId = productId,
                        Price = product.Price,
                        Quantity = quantity,
                        Product = product
                    });
                    HttpContext.Session.SetObject("cart", cart);
                }
                TempData["CartItemNumber"] = cart.CartItems.Count();
                return PartialView("_SidebarCartPartial", cart.CartItems.ToList());
            }
        }   
    }
}
