using CSE443_KTM_Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSE443_KTM_Ecommerce.Models;

namespace CSE443_KTM_Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly KTMDbContext _context;
        private readonly IWebHostEnvironment _env;
        
        public ProductController(KTMDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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

            // Populate ViewBag with categories and product types
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name", product.CategoryId);
            ViewBag.ProductTypes = new SelectList(_context.ProductTypes.ToList(), "Id", "Name", product.ProductTypeId);

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
                var product = _context.Products
                    .Include(p => p.ProductImages)
                    .FirstOrDefault(p => p.Id == id);

                if (product == null)
                {
                    return Json(new { success = false, message = "Product not found" });
                }

                if (file == null || file.Length == 0)
                {
                    return Json(new { success = false, message = "No file uploaded" });
                }

                // Get the folder path from the first image if exists
                string folderPath = product.ProductImages.FirstOrDefault()?.ImagePath;
                if (string.IsNullOrEmpty(folderPath))
                {
                    return Json(new { success = false, message = "Product folder path not found" });
                }

                // Create the full physical path
                var fullPath = Path.Combine(_env.WebRootPath, "img", folderPath);
                Console.WriteLine($"Full path: {fullPath}");
                
                // Create directory if it doesn't exist
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                    Console.WriteLine($"Created directory: {fullPath}");
                }

                // Save the file with the specified number
                var fileName = $"{imageNumber}.png";
                var filePath = Path.Combine(fullPath, fileName);
                Console.WriteLine($"File path: {filePath}");

                // Save the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    Console.WriteLine($"File saved successfully to: {filePath}");
                }

                return Json(new { success = true, message = "Image uploaded successfully" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading image: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                return Json(new { success = false, message = $"Error uploading image: {ex.Message}" });
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
