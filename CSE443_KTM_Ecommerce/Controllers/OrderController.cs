using CSE443_KTM_Ecommerce.Data;
using CSE443_KTM_Ecommerce.Enum;
using CSE443_KTM_Ecommerce.Models;
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
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();

            // Count orders by status
            ViewBag.PendingOrders = orders.Count(o => o.Status == OrderStatus.PENDING);
            ViewBag.CompletedOrders = orders.Count(o => o.Status == OrderStatus.COMPLETED);

            return View(orders);
        }

        public async Task<IActionResult> OrderDetail(int id)
        {
            var order = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Include(o => o.Coupon)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetails(int id)
        {
            var order = await _context.Orders
                .Include(o => o.User)
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
            }).ToList();

            var response = new
            {
                success = true,
                orderId = order.Id,
                status = order.Status.ToString(),
                createdAt = order.CreatedAt.ToString("dd/MM/yyyy HH:mm"),
                completedAt = order.CompletedAt?.ToString("dd/MM/yyyy HH:mm"),
                deliveryAddress = order.DeliveryAddress,
                totalAmount = order.OrderTotalPrice,
                orderDetails = orderDetails,
                coupon = order.Coupon != null ? new
                {
                    code = order.Coupon.CouponCode,
                } : null
            };

            return Json(response);
        }

        [HttpPost("Order/AcceptOrder/{id}")]
        public async Task<IActionResult> AcceptOrder(int id)
        {
            try
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
                order.CompletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Order accepted successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error accepting order: " + ex.Message });
            }
        }
        
        [HttpPost("Order/DeleteOrder/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var order = await _context.Orders
                    .Include(o => o.OrderDetails)
                    .FirstOrDefaultAsync(o => o.Id == id);

                if (order == null)
                {
                    return Json(new { success = false, message = "Order not found" });
                }

                if (order.Status == OrderStatus.COMPLETED)
                {
                    return Json(new { success = false, message = "Cannot delete completed order" });
                }

                // Remove order details first
                _context.OrderDetails.RemoveRange(order.OrderDetails);
                
                // Then remove the order
                _context.Orders.Remove(order);
                
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Order deleted successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error deleting order: " + ex.Message });
            }
        }
    }
}
