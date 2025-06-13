using System.ComponentModel.DataAnnotations;


namespace CSE443_KTM_Ecommerce.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string? FullName { get; set; }
        public string? Address { get; set; }
    }
}
