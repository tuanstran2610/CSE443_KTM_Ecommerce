using CSE443_KTM_Ecommerce.Models;
using System.Collections.Generic;

namespace CSE443_KTM_Ecommerce.ViewModels
{
    public class RoleListViewModel
    {
        public IEnumerable<Role> Roles { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
    }
} 