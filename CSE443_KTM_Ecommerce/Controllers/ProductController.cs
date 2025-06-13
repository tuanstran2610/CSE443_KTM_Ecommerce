using CSE443_KTM_Ecommerce.Data;
using CSE443_KTM_Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CSE443_KTM_Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        private readonly KTMDbContext _context;
        private readonly ILogger<ProductController> _logger;

        public ProductController(KTMDbContext context, ILogger<ProductController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IActionResult> Detail( int id)
        {
            _logger.LogInformation($"Product Id : {id}");
            var product = await _context.Products.Include(p => p.Category).Include(p => p.ProductImages).Include(p => p.ProductType).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            var relatedCategoryProducts = await _context.Products.Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductType).
                Where(p => p.Category.Name == product.Category.Name && p.Id != product.Id).ToListAsync();
            ViewBag.Product = product;
            ViewBag.RelatedCategoryProducts = relatedCategoryProducts;
            return View();
        }
        
        public async Task<IActionResult> Search([FromQuery(Name  = "brand")] string? brand , [FromQuery(Name = "name")] string? name,
            [FromQuery(Name = "minPrice")]  decimal? minPrice, [FromQuery(Name ="maxPrice")]  decimal?  maxPrice,
            [FromQuery(Name = "category") ] string? category, [FromQuery(Name = "type")] string? type, [FromQuery(Name = "title")] string? title
        )
        {
            IQueryable<Product> query = _context.Products.Include(p => p.ProductImages).
                Include(p => p.Category)
               .Include(p => p.ProductType)
               .AsQueryable();
            // Apply filters based on provided query parameters
            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(p => p.Name.ToLower().Contains(title.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(brand))
            {
                // Case-insensitive search for brand
                query = query.Where(p => p.Brand.ToLower().Contains(brand.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                
                query = query.Where(p => p.Name.ToLower().Contains(name.ToLower()));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }
            
            var categoryCounts = await query
                .Where(p => p.Category != null) // Ensure product has a category to group by
                .GroupBy(p => new { p.Category.Id, p.Category.Name }) // Group by Category ID and Name
                .Select(g => new CategoryCountViewModel
                {
                    CategoryId = g.Key.Id,
                    CategoryName = g.Key.Name,
                    ProductCount = g.Count() // Count products in this group
                })
                .OrderByDescending(c => c.ProductCount) // Order by most products
                .ToListAsync();
            if (!string.IsNullOrWhiteSpace(category) &&  category != "All")
            {
                query = query.Where(p => p.Category.Name == category);
            }
            if (!string.IsNullOrWhiteSpace(type))
            {
                query = query.Where(p => p.ProductType.Name == type);
            }
            var searchResults =await query.ToListAsync();
            //var categories = _context.Categories.Include(c => c.Products).Where()
            // Pass the search parameters to the view for display or to pre-fill the search form
            ViewBag.CategoryCounts = categoryCounts;
            ViewBag.Brand = brand;
            ViewBag.Name =name;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;
            ViewBag.SearchProductResults = searchResults;
            return View();
            
        }
        public async Task<IActionResult> GetProductsByBrand([FromQuery(Name  ="brand")] string brand)
        {
            var products =await _context.Products.Where(p => p.Brand == brand).Include(p => p.Category).Include(p => p.ProductType)
                .Include(p => p.ProductImages).ToListAsync();
            return View();
        }
        public ActionResult ProductList()
        {
            return View();
        }
        
        public ActionResult ProductAdd()
        {
            return View();
        }    
        public ActionResult ProductEdit()
        {
            return View();
        }


    }
}
