using CSE443_KTM_Ecommerce.Data;
using CSE443_KTM_Ecommerce.Models;
using CSE443_KTM_Ecommerce.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSE443_KTM_Ecommerce.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class OrderController : Controller
    {
        private readonly KTMDbContext _context;

        public OrderController(KTMDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OrderList()
        {
            var orders = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Include(o => o.Coupon)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();

            ViewBag.Orders = orders;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetails(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Include(o => o.Coupon)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return Json(new { success = false, message = "Order not found" });
            }

            var orderDetails = order.OrderDetails.Select(od => new
            {
                productName = od.Product.Name,
                quantity = od.Quantity,
                price = od.Price,
                total = od.Quantity * od.Price
            }).ToList();

            return Json(new
            {
                success = true,
                orderDetails = orderDetails,
                totalAmount = order.OrderTotalPrice,
                deliveryAddress = order.DeliveryAddress,
                coupon = order.Coupon != null ? new
                {
                    code = order.Coupon.CouponCode,
                } : null,
                status = order.Status.ToString(),
                createdAt = order.CreatedAt.ToString("dd/MM/yyyy HH:mm"),
                completedAt = order.CompletedAt?.ToString("dd/MM/yyyy HH:mm")
            });
        }

        [HttpPost]
        public async Task<IActionResult> AcceptOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return Json(new { success = false, message = "Order not found" });
            }

            if (order.Status != OrderStatus.PENDING)
            {
                return Json(new { success = false, message = "Order is not in pending status" });
            }

            order.Status = OrderStatus.COMPLETED;
            order.CompletedAt = DateTime.Now;
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }
    }
}
