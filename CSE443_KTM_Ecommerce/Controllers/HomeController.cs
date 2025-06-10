using System.Diagnostics;
using CSE443_KTM_Ecommerce.Data;
using CSE443_KTM_Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSE443_KTM_Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KTMDbContext _context;

        public HomeController(ILogger<HomeController> logger, KTMDbContext context)
        {
            _logger = logger;
            _context = context;
        }

            public IActionResult Index()
            {
            var categories = _context.Categories
                 .Include(c => c.Products)
                  .ThenInclude(p => p.ProductImages)
                  .ToList();
            var featuredProducts = _context.Products
                 .Where(p => p.Featured)
                  .Include(p => p.ProductImages).Include(p => p.Category)
                 .ToList();
            var normalProducts  = _context.Products
                 .Where(p => p.Featured == false)
                 .Include(p => p.ProductImages).Include(p => p.Category)
                 .ToList();
            var topSoldProduct = _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .OrderByDescending(p => p.SoldQuantity)
                .FirstOrDefault();
            ViewBag.TopSoldProduct = topSoldProduct;
            ViewBag.FeaturedProducts = featuredProducts;
            ViewBag.NormalProducts = normalProducts;
            ViewBag.Categories = categories;
                return View();
            }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        
        public IActionResult BlogDetail()
        {
            return View();
        }
        
        
        public IActionResult Checkout()
        {
            return View();
        }
        
        public IActionResult Login()
        {
            return View();
        }
        
        public IActionResult NotFound()
        {
            return View();
        }
        public IActionResult Service()
        {
            return View();
        }
        public IActionResult Accordion()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
