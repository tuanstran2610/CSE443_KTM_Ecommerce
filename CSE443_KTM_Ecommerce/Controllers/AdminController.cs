using CSE443_KTM_Ecommerce.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSE443_KTM_Ecommerce.Models;
using CSE443_KTM_Ecommerce.Enum;

namespace CSE443_KTM_Ecommerce.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminController : Controller
    {
        private readonly KTMDbContext _context;

        public AdminController(KTMDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Get total revenue
            var totalRevenue = await _context.Orders
                .Where(o => o.Status == OrderStatus.COMPLETED)
                .SumAsync(o => o.OrderTotalPrice);

            // Get total orders
            var totalOrders = await _context.Orders.CountAsync();

            // Get pending orders count
            var pendingOrders = await _context.Orders
                .CountAsync(o => o.Status == OrderStatus.PENDING);

            // Get total users
            var totalUsers = await _context.Users.CountAsync();

            // Get recent orders
            var recentOrders = await _context.Orders
                .Include(o => o.User)
                .OrderByDescending(o => o.CreatedAt)
                .Take(5)
                .ToListAsync();

            // Get top selling products
            var topProducts = await _context.OrderDetails
                .Include(od => od.Product)
                .GroupBy(od => od.Product)
                .Select(g => new
                {
                    Product = g.Key,
                    TotalSold = g.Sum(od => od.Quantity),
                    TotalRevenue = g.Sum(od => od.Price * od.Quantity)
                })
                .OrderByDescending(x => x.TotalSold)
                .Take(5)
                .ToListAsync();

            // Get monthly revenue data for chart
            var monthlyRevenue = await _context.Orders
                .Where(o => o.Status == OrderStatus.COMPLETED)
                .Select(o => new
                {
                    Year = o.CreatedAt.Year,
                    Month = o.CreatedAt.Month,
                    Revenue = o.OrderTotalPrice
                })
                .ToListAsync();

            var monthlyRevenueData = monthlyRevenue
                .GroupBy(x => new { x.Year, x.Month })
                .Select(g => new
                {
                    Month = new DateTime(g.Key.Year, g.Key.Month, 1),
                    Revenue = g.Sum(x => x.Revenue)
                })
                .OrderBy(x => x.Month)
                .Take(12)
                .ToList();

            ViewBag.TotalRevenue = totalRevenue;
            ViewBag.TotalOrders = totalOrders;
            ViewBag.PendingOrders = pendingOrders;
            ViewBag.TotalUsers = totalUsers;
            ViewBag.RecentOrders = recentOrders;
            ViewBag.TopProducts = topProducts;
            ViewBag.MonthlyRevenue = monthlyRevenueData;

            return View();
        }
    }
}
