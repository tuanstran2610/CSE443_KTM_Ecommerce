using Microsoft.AspNetCore.Identity;

namespace CSE443_KTM_Ecommerce.Models
{
    public class Role : IdentityRole<int>
    {
        public Role()
        {
            
        }
        public Role(string roleName) :base(roleName) { }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
