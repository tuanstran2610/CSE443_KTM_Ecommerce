using System.ComponentModel.DataAnnotations;
using CSE443_KTM_Ecommerce.Models;

namespace CSE443_KTM_Ecommerce.ViewModels
{
    public class CheckoutViewModel
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public List<CartItem> CartItems { get; set; }       // Danh sách sản phẩm trong giỏ hàng
    }
}
