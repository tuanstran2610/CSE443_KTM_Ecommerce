using System.ComponentModel.DataAnnotations;

namespace CSE443_KTM_Ecommerce.ViewModels
{
    public class EditInfoViewModel
    {
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string Password { get; set; }
    }
}
