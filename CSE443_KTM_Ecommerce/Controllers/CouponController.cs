using Microsoft.AspNetCore.Mvc;
using CSE443_KTM_Ecommerce.Models;
using CSE443_KTM_Ecommerce.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CSE443_KTM_Ecommerce.Controllers
{
    public class CouponController : Controller
    {
        private readonly KTMDbContext _context;
        private const int PageSize = 10;
        private readonly ILogger<CouponController> _logger;

        public CouponController(KTMDbContext context, ILogger<CouponController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult CouponAdd()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CouponAdd([FromForm] Coupon coupon)
        {
            _logger.LogInformation("Attempting to add new coupon: {@Coupon}", coupon);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state: {@ModelState}", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return View(coupon);
            }

            try
            {
                // Set default values
                coupon.CreatedAt = DateTime.Now;
                coupon.UpdatedAt = DateTime.Now;
                coupon.CouponCode = coupon.CouponCode?.ToUpper();

                // Add to database
                _context.Coupons.Add(coupon);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Successfully added new coupon with ID: {CouponId}", coupon.Id);
                TempData["SuccessMessage"] = "Coupon created successfully!";
                return RedirectToAction(nameof(CouponList));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating coupon");
                ModelState.AddModelError("", "An error occurred while creating the coupon: " + ex.Message);
                return View(coupon);
            }
        }

        public async Task<IActionResult> CouponEdit(int id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon == null)
            {
                return NotFound();
            }
            return View(coupon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CouponEdit(int id, [FromForm] Coupon coupon)
        {
            if (id != coupon.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(coupon);
            }

            try
            {
                var existingCoupon = await _context.Coupons.FindAsync(id);
                if (existingCoupon == null)
                {
                    return NotFound();
                }

                // Update properties
                existingCoupon.CouponCode = coupon.CouponCode?.ToUpper();
                existingCoupon.CouponType = coupon.CouponType;
                existingCoupon.CouponMinSpend = coupon.CouponMinSpend;
                existingCoupon.CouponMaxSpend = coupon.CouponMaxSpend;
                existingCoupon.CouponCount = coupon.CouponCount;
                existingCoupon.CouponStatus = coupon.CouponStatus;
                existingCoupon.StartTime = coupon.StartTime;
                existingCoupon.EndTime = coupon.EndTime;
                existingCoupon.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Coupon updated successfully!";
                return RedirectToAction(nameof(CouponList));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Coupons.AnyAsync(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<IActionResult> CouponList(int page = 1)
        {
            var query = _context.Coupons
                .Where(c => c.DeletedAt == null)
                .AsQueryable();

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
            page = Math.Max(1, Math.Min(page, totalPages));

            var coupons = await query
                .OrderByDescending(c => c.CreatedAt)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            var viewModel = new CouponListViewModel
            {
                Coupons = coupons,
                CurrentPage = page,
                TotalPages = totalPages,
                TotalItems = totalItems,
                PageSize = PageSize
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            try
            {
                _logger.LogInformation("Attempting to delete coupon with ID: {CouponId}", id);

                var coupon = await _context.Coupons.FindAsync(id);
                if (coupon == null)
                {
                    _logger.LogWarning("Coupon not found with ID: {CouponId}", id);
                    return Json(new { success = false, message = "Coupon not found" });
                }

                // Soft delete
                coupon.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
                
                _logger.LogInformation("Successfully deleted coupon with ID: {CouponId}", id);
                return Json(new { success = true, message = "Coupon deleted successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting coupon {CouponId}", id);
                return Json(new { success = false, message = "An error occurred while deleting the coupon: " + ex.Message });
            }
        }
    }

    public class CouponListViewModel
    {
        public IEnumerable<Coupon> Coupons { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
    }
}
