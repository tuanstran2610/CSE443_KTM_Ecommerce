using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CSE443_KTM_Ecommerce.Models;
using CSE443_KTM_Ecommerce.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CSE443_KTM_Ecommerce.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly KTMDbContext _context;
        private const int PageSize = 5;

        public RoleController(UserManager<User> userManager, RoleManager<Role> roleManager, KTMDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        // GET: RoleController
        public async Task<IActionResult> RoleList(int page = 1)
        {
            var rolesQuery = _roleManager.Roles;

            var totalItems = await rolesQuery.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
            page = Math.Clamp(page, 1, totalPages);

            var pagedRoles = await rolesQuery
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            var roleViewModels = new List<RoleListItemViewModel>();

            foreach (var role in pagedRoles)
            {
                var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name);
                roleViewModels.Add(new RoleListItemViewModel
                {
                    Id = role.Id,
                    Name = role.Name,
                    UsersCount = usersInRole.Count
                });
            }

            var viewModel = new RoleListViewModel
            {
                Roles = roleViewModels,
                CurrentPage = page,
                TotalPages = totalPages,
                TotalItems = totalItems,
                PageSize = PageSize
            };

            return View(viewModel);
        }

        
        public IActionResult RoleAdd()
        {
            return View();
        }
        public async Task<IActionResult> UserCountByRole()
        {
            var allRoles = await _roleManager.Roles.ToListAsync();

            var roleCounts = allRoles.Select(role => new RoleUserCountViewModel
            {
                RoleName = role.Name,
                UserCount = _context.UserRoles.Count(ur => ur.RoleId == role.Id)
            }).ToList();

            return View(roleCounts);
        }

        
        [HttpPost]
        public async Task<IActionResult> RoleAdd(Role role)
        {
            if (ModelState.IsValid)
            {
                role.Name = role.Name.ToUpper();
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(RoleList));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(role);
        }
        
        public async Task<IActionResult> RoleEdit(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> RoleEdit(Role role)
        {
            if (ModelState.IsValid)
            {
                var existingRole = await _roleManager.FindByIdAsync(role.Id.ToString());
                if (existingRole == null)
                {
                    return NotFound();
                }

                existingRole.Name = role.Name.ToUpper();
                var result = await _roleManager.UpdateAsync(existingRole);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(RoleList));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(role);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersInRole(int id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id.ToString());
                if (role == null)
                {
                    return Json(new { success = false, message = "Role not found" });
                }

                var users = await _context.Users
                    .Where(u => u.Roles.Any(r => r.Id == id))
                    .Select(u => new { u.Id, u.UserName })
                    .ToListAsync();

                return Json(new { success = true, users });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while fetching users" });
            }
        }

        [HttpPost("Role/DeleteRole/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id.ToString());
                if (role == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy role" });
                }

                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return Json(new { success = true });
                }

                return Json(new { 
                    success = false, 
                    message = string.Join(", ", result.Errors.Select(e => e.Description)) 
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
    public class RoleListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UsersCount { get; set; }
    }
    
    public class RoleListViewModel
    {
        public List<RoleListItemViewModel> Roles { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
    }
    public class RoleUserCountViewModel
    {
        public string RoleName { get; set; }
        public int UserCount { get; set; }
    }



}