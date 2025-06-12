using CSE443_KTM_Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSE443_KTM_Ecommerce.Models;
using System.Reflection;
using CSE443_KTM_Ecommerce.Models;


namespace CSE443_KTM_Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly KTMDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<ProductController> _logger;

        
        public ProductController(KTMDbContext context, IWebHostEnvironment env, ILogger<ProductController> logger)
        {
            _context = context;
            _env = env;
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

        // GET: ProductController
        public async Task<IActionResult> ProductList(int page = 1)
        {
            int pageSize = 10;

            var query = _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductType);

            var totalItems = await query.CountAsync();

            var products = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            return View(products);
        }

        // GET: ProductController/ProductAdd
        public async Task<IActionResult> ProductAdd()
        {
            ViewBag.Categories = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
            ViewBag.ProductTypes = new SelectList(await _context.ProductTypes.ToListAsync(), "Id", "Name");
            return View();
        }

        // POST: ProductController/ProductAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductAdd(Product product, List<IFormFile> images)
        {
            if (ModelState.IsValid)
            {
                // Handle image uploads
                if (images != null && images.Count > 0)
                {
                    foreach (var image in images)
                    {
                        if (image.Length > 0)
                        {
                            var fileName = Path.GetFileNameWithoutExtension(image.FileName);
                            var extension = Path.GetExtension(image.FileName);
                            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                            var path = Path.Combine(_env.WebRootPath, "images/product", fileName);

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await image.CopyToAsync(stream);
                            }

                            var productImage = new ProductImage
                            {
                                ImagePath = "/images/product/" + fileName,
                                Product = product
                            };

                            product.ProductImages.Add(productImage);
                        }
                    }
                }

                product.CreatedAt = DateTime.Now;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ProductList));
            }

            ViewBag.Categories = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
            ViewBag.ProductTypes = new SelectList(await _context.ProductTypes.ToListAsync(), "Id", "Name");
            return View(product);
        }

        // GET: ProductController/ProductEdit/5
        public IActionResult ProductEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            // Lấy danh sách file ảnh vật lý trong folder
            var productImage = product.ProductImages.FirstOrDefault();
            string folderPath = productImage?.ImagePath;
            string fullFolderPath = string.IsNullOrEmpty(folderPath) ? null : Path.Combine(_env.WebRootPath, folderPath);
            List<string> imageFiles = new List<string>();
            if (!string.IsNullOrEmpty(fullFolderPath) && Directory.Exists(fullFolderPath))
            {
                imageFiles = Directory.GetFiles(fullFolderPath, "*.png")
                    .Select(f => Path.Combine(folderPath, Path.GetFileName(f)).Replace("\\", "/"))
                    .ToList();
            }
            ViewBag.PhysicalImages = imageFiles;

            // Populate ViewBag with categories and product types
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewBag.ProductTypes = new SelectList(_context.ProductTypes, "Id", "Name", product.ProductTypeId);

            return View(product);
        }

        // POST: ProductController/ProductEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProductEdit(int id, [FromForm] Product product)
        {
            try
            {
                if (id != product.Id)
                {
                    return Json(new { success = false, message = "Invalid product ID" });
                }

                Console.WriteLine($"Received CategoryId: {product.CategoryId}");
                Console.WriteLine($"Received ProductTypeId: {product.ProductTypeId}");

                ModelState.Remove("Category");
                ModelState.Remove("ProductType");

                if (ModelState.IsValid)
                {
                    var existingProduct = _context.Products
                        .Include(p => p.ProductImages)
                        .FirstOrDefault(p => p.Id == id);

                    if (existingProduct == null)
                    {
                        return Json(new { success = false, message = "Product not found" });
                    }

                    // Update product properties
                    existingProduct.Name = product.Name;
                    existingProduct.CategoryId = product.CategoryId;
                    existingProduct.Brand = product.Brand;
                    existingProduct.Weight = product.Weight;
                    existingProduct.Warranty = product.Warranty;
                    existingProduct.Size = product.Size;
                    existingProduct.Quantity = product.Quantity;
                    existingProduct.Dimensions = product.Dimensions;
                    existingProduct.Description = product.Description;
                    existingProduct.Fabric = product.Fabric;
                    existingProduct.ProductTypeId = product.ProductTypeId;
                    existingProduct.Price = product.Price;
                    existingProduct.Status = product.Status;
                    existingProduct.Featured = product.Featured;
                    existingProduct.UpdatedAt = DateTime.Now;

                    _context.SaveChanges();
                    return Json(new { success = true });
                }

                // Log ModelState errors
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                
                Console.WriteLine("Validation errors:");
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }

                return Json(new { 
                    success = false, 
                    message = "Validation failed", 
                    errors = errors 
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return Json(new { 
                    success = false, 
                    message = "An error occurred while updating the product",
                    error = ex.Message 
                });
            }
        }

        // POST: ProductController/UploadImage/5
        [HttpPost]
        public IActionResult UploadImage(int id, IFormFile file, int imageNumber)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return Json(new { success = false, message = "No file uploaded" });

                // Lấy folder path từ ProductImage đầu tiên
                var productImage = _context.ProductImages.FirstOrDefault(pi => pi.ProductId == id);
                if (productImage == null)
                    return Json(new { success = false, message = "Product image folder not found" });

                string folderPath = "img/" + productImage.ImagePath; // Thêm prefix 'img/' vào đường dẫn
                string fullFolderPath = Path.Combine(_env.WebRootPath, folderPath);

                // Tạo thư mục nếu chưa có
                if (!Directory.Exists(fullFolderPath))
                    Directory.CreateDirectory(fullFolderPath);

                // Lưu file với tên số thứ tự
                string fileName = $"{imageNumber}.png";
                string filePath = Path.Combine(fullFolderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return Json(new { success = true, message = "Image uploaded successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // POST: ProductController/DeleteImage/5
        [HttpPost]
        public IActionResult DeleteImage(int id, int imageNumber)
        {
            try
            {
                var image = _context.ProductImages.Find(id);
                if (image == null)
                {
                    return Json(new { success = false, message = "Image not found" });
                }

                var imagePath = Path.Combine(_env.WebRootPath, "img", image.ImagePath, $"{imageNumber}.png");
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

                var folderPath = Path.Combine(_env.WebRootPath, "img", image.ImagePath);
                var remainingImages = Directory.GetFiles(folderPath, "*.png");
                if (remainingImages.Length == 0)
                {
                    Directory.Delete(folderPath);
                    _context.ProductImages.Remove(image);
                    _context.SaveChanges();
                }

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
