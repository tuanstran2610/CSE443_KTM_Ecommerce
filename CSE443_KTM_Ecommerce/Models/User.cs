using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSE443_KTM_Ecommerce.Models
{
    public class User : IdentityUser<int>
    {

        public string? FullName { get; set; }
        public string? Address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Role> Roles { get; set; } = new List<Role>();
        public Cart Cart { get; set; }
    }
}
