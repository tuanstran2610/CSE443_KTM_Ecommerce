﻿using CSE443_KTM_Ecommerce.Data;
using CSE443_KTM_Ecommerce.Enum;
using CSE443_KTM_Ecommerce.Extensions;
using CSE443_KTM_Ecommerce.Models;
using CSE443_KTM_Ecommerce.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
namespace CSE443_KTM_Ecommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly KTMDbContext _context;
        private readonly UserManager<User> _userManager;
        //private List<CartItem> _cartItems = new List<CartItem>();

        public CartController(KTMDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identityUser = await _userManager.GetUserAsync(User);
                var user = await _context.Users.Include(u => u.Cart).FirstOrDefaultAsync(u => u.Id == identityUser.Id);
                if (user == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                ViewBag.Cart = user.Cart;
                var cartItems = await _context.CartItems.Include(ci => ci.Cart).Include(ci => ci.Product)
                    .Include(ci => ci.Product.ProductImages)
                    .Where(ci => ci.Cart.Id == user.Cart.Id).ToListAsync();
                ViewBag.CartItems = cartItems;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

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


        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartRequest addToCartRequest)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(p => p.Id == addToCartRequest.ProductId);
            if (product == null)
            {
                return NotFound();
            }
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                var actualUser = await _context.Users
                                      .Include(u => u.Cart)
                                          .ThenInclude(c => c.CartItems)
                                      .FirstOrDefaultAsync(u => u.Id == user.Id);
                var cart = actualUser.Cart;
                if (cart == null)
                {
                    cart = new Cart
                    {
                        UserId = user.Id,
                        CartItems = new List<CartItem>()
                    };
                    user.Cart = cart;
                    _context.Carts.Add(cart);
                }
                var existingItem = cart.CartItems.FirstOrDefault(p => p.ProductId == addToCartRequest.ProductId);

                if (existingItem != null)
                {
                    existingItem.Quantity += addToCartRequest.Quantity;
                }
                else
                {
                    cart.CartItems.Add(new CartItem
                    {
                        ProductId = addToCartRequest.ProductId,
                        Price = product.Price,
                        Quantity = addToCartRequest.Quantity,
                        Product = product,
                    });
                }
                _context.SaveChanges();
                var cartItemCount = cart.CartItems.Sum(ci => ci.Quantity);
                return Json(new { success = true, count = cartItemCount });
            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart([FromBody] int cartItemId)
        {
            var user = await _userManager.GetUserAsync(User);
            var actualUser = await _context.Users
                .Include(u => u.Cart)
                .ThenInclude(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(u => u.Id == user.Id);
            var cart = actualUser?.Cart;

            if (cart != null)
            {
                var itemToRemove = cart.CartItems.FirstOrDefault(ci => ci.Id == cartItemId);
                if (itemToRemove != null)
                {
                    cart.CartItems.Remove(itemToRemove);
                    _context.CartItems.Remove(itemToRemove);
                    await _context.SaveChangesAsync();

                    var totalPrice = cart.CartItems.Sum(ci => ci.Price * ci.Quantity);
                    var itemCount = cart.CartItems.Sum(ci => ci.Quantity);

                    return Json(new { success = true, total = totalPrice, count = itemCount });
                }
            }

            return Json(new { success = false });
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCart(List<CartItemUpdateModel> cartItems)
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == user.Id);

            if (cart == null)
            {
                return RedirectToAction("Index");
            }

            foreach (var item in cartItems)
            {
                var ci = cart.CartItems.FirstOrDefault(c => c.Id == item.Id);
                if (ci != null)
                {
                    if (item.Quantity > 0)
                    {
                        ci.Quantity = item.Quantity;
                    }
                }
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // View Product Detail  - Popup window backend handling 

        public IActionResult GetProductDetail([FromQuery(Name = "productId")] int productId)
        {
            return ViewComponent("ProductDetail", new { productId });
        }

        [HttpGet("/CartMini")]
        public IActionResult GetMiniCart()
        {
            return ViewComponent("CartMini");
        }
        [HttpGet("/CartView")]
        public IActionResult GetCartView()
        {
            return ViewComponent("Cart");
        }


        public async Task<IActionResult> Checkout()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identityUser = await _userManager.GetUserAsync(User);
                var user = await _context.Users
                    .Include(u => u.Cart)
                    .FirstOrDefaultAsync(u => u.Id == identityUser.Id);

                // Kiểm tra null an toàn
                if (user == null || user.Cart == null)
                {
                    return RedirectToAction("Login", "Account"); 
                }

                var cartItems = await _context.CartItems
                    .Include(ci => ci.Cart)
                    .Include(ci => ci.Product)
                    .ThenInclude(p => p.ProductImages)
                    .Where(ci => ci.Cart.Id == user.Cart.Id)
                    .ToListAsync();

                var model = new CheckoutViewModel
                {
                    FullName = user.FullName,
                    Address = user.Address,
                    PhoneNumber = user.PhoneNumber,
                    CartItems = cartItems
                };

                return View(model);
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(CheckoutViewModel model, string PaymentMethod)
        {
            var identityUser = await _userManager.GetUserAsync(User);
            var user = await _context.Users
                .Include(u => u.Cart)
                .ThenInclude(c => c.CartItems)
                .FirstOrDefaultAsync(u => u.Id == identityUser.Id);

            if (user?.Cart?.CartItems == null || !user.Cart.CartItems.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            decimal total = user.Cart.CartItems.Sum(ci => ci.Price * ci.Quantity);

            var order = new Order
            {
                UserId = user.Id,
                OrderTotalPrice = (double)total,
                DeliveryAddress = model.Address,
                DeliveryId = 1, 
                CreatedAt = DateTime.Now,
                Status = OrderStatus.PENDING,
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(); 

            foreach (var cartItem in user.Cart.CartItems)
            {
                var detail = new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    Price = (double)cartItem.Price
                };
                _context.OrderDetails.Add(detail);
            }

            var payment = new Payment
            {
                OrderId = order.Id,
                Method = PaymentMethod,
                Amount = total,
                PaymentStatus = "Pending",
                PaymentDate = DateTime.Now
            };
            _context.Payments.Add(payment);

            _context.CartItems.RemoveRange(user.Cart.CartItems);

            await _context.SaveChangesAsync();

            return View("OrderSuccess", order);
        }



    }
}
