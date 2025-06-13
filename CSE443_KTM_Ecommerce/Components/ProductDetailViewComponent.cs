using CSE443_KTM_Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSE443_KTM_Ecommerce.Components
{
    public class ProductDetailViewComponent : ViewComponent
    {
        private readonly KTMDbContext _context;

        public ProductDetailViewComponent(KTMDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var product = await _context.Products.Include(p => p.ProductImages).Include(p => p.Category).Include(p => p.ProductType)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
            {
                return Content("<div class='text-danger text-center p-5'>Product not found.</div>");
            }

            return View(product);
        }
    }

}
