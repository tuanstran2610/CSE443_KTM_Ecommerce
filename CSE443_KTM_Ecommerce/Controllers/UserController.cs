using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CSE443_KTM_Ecommerce.Models;
using CSE443_KTM_Ecommerce.Data;
using Microsoft.EntityFrameworkCore;
using CSE443_KTM_Ecommerce.Enum;

namespace CSE443_KTM_Ecommerce.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly KTMDbContext _context;
        private const int PageSize = 10;
        private readonly ILogger<UserController> _logger;

        public UserController(
            UserManager<User> userManager,
            KTMDbContext context,
            ILogger<UserController> logger)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> UserDetail(int id)
        {
            try
            {
                var user = await _context.Users
                    .Include(u => u.Roles)
                    .Include(u => u.Cart)
                    .FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                {
                    return NotFound();
                }

                // Get user roles
                var userRoles = await _userManager.GetRolesAsync(user);
                user.Roles = await _context.Roles
                    .Where(r => userRoles.Contains(r.Name))
                    .ToListAsync();

                // Get user orders
                var orders = await _context.Orders
                    .Include(o => o.Coupon)
                    .Include(o => o.Delivery)
                    .Include(o => o.Payment)
                    .Where(o => o.UserId == id)
                    .OrderByDescending(o => o.CreatedAt)
                    .ToListAsync();

                var viewModel = new UserDetailViewModel
                {
                    User = user,
                    Orders = orders,
                    TotalOrders = orders.Count,
                    TotalSpent = orders.Sum(o => o.OrderTotalPrice),
                    LastOrderDate = orders.FirstOrDefault()?.CreatedAt
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading user details for ID: {UserId}", id);
                TempData["ErrorMessage"] = "An error occurred while loading user details.";
                return RedirectToAction(nameof(UserList));
            }
        }

        public async Task<IActionResult> UserList(int page = 1)
        {
            try
            {
                var query = _context.Users
                    .Include(u => u.Roles)
                    .AsQueryable();

                var totalItems = await query.CountAsync();
                var totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
                page = Math.Max(1, Math.Min(page, totalPages));

                var users = await query
                    .OrderByDescending(u => u.CreatedAt)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                    .ToListAsync();

                // Get roles for each user
                foreach (var user in users)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    user.Roles = await _context.Roles
                        .Where(r => userRoles.Contains(r.Name))
                        .ToListAsync();
                }

                // Get order statistics
                var orderStats = await GetOrderStatistics();

                var viewModel = new UserListViewModel
                {
                    Users = users,
                    CurrentPage = page,
                    TotalPages = totalPages,
                    TotalItems = totalItems,
                    PageSize = PageSize,
                    OrderStatistics = orderStats
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading user list");
                TempData["ErrorMessage"] = "An error occurred while loading the user list.";
                return View(new UserListViewModel());
            }
        }

        private async Task<OrderStatistics> GetOrderStatistics()
        {
            var today = DateTime.Today;
            var yesterday = today.AddDays(-1);

            var todayOrders = await _context.Orders
                .Where(o => o.CreatedAt.Date == today)
                .ToListAsync();

            var yesterdayOrders = await _context.Orders
                .Where(o => o.CreatedAt.Date == yesterday)
                .ToListAsync();

            var totalOrders = await _context.Orders.CountAsync();
            var totalRevenue = await _context.Orders.SumAsync(o => o.OrderTotalPrice);

            var todayRevenue = todayOrders.Sum(o => o.OrderTotalPrice);
            var yesterdayRevenue = yesterdayOrders.Sum(o => o.OrderTotalPrice);

            var revenueChange = yesterdayRevenue == 0 ? 100 : 
                ((todayRevenue - yesterdayRevenue) / yesterdayRevenue) * 100;

            var orderChange = yesterdayOrders.Count == 0 ? 100 :
                ((todayOrders.Count - yesterdayOrders.Count) / (double)yesterdayOrders.Count) * 100;

            return new OrderStatistics
            {
                TotalOrders = totalOrders,
                TotalRevenue = totalRevenue,
                TodayOrders = todayOrders.Count,
                OrderChange = orderChange,
                RevenueChange = revenueChange
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
                if (user == null)
                {
                    return Json(new { success = false, message = "User not found" });
                }

                // Check if user has any orders
                var hasOrders = await _context.Orders.AnyAsync(o => o.UserId == id);
                if (hasOrders)
                {
                    return Json(new { success = false, message = "Cannot delete user that has orders" });
                }

                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return Json(new { success = true, message = "User deleted successfully" });
                }

                return Json(new { 
                    success = false, 
                    message = string.Join(", ", result.Errors.Select(e => e.Description)) 
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting user with ID: {UserId}", id);
                return Json(new { success = false, message = "An error occurred while deleting the user" });
            }
        }
    }

    public class UserListViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public OrderStatistics OrderStatistics { get; set; }
    }

    public class UserDetailViewModel
    {
        public User User { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public int TotalOrders { get; set; }
        public double TotalSpent { get; set; }
        public DateTime? LastOrderDate { get; set; }
    }

    public class OrderStatistics
    {
        public int TotalOrders { get; set; }
        public double TotalRevenue { get; set; }
        public int TodayOrders { get; set; }
        public double OrderChange { get; set; }
        public double RevenueChange { get; set; }
    }
}
