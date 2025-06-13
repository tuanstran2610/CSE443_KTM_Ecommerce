using CSE443_KTM_Ecommerce.Models;
using CSE443_KTM_Ecommerce.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Encodings.Web;
namespace CSE443_KTM_Ecommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _roleManager = roleManager;

        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register() => View();

        // POST: /Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            //Console.WriteLine("[POST] Register called");

            if (!ModelState.IsValid)
                return View(model);
            //{
            //    foreach (var value in ModelState.Values)
            //    {
            //        foreach (var error in value.Errors)
            //        {
            //            Console.WriteLine("❌ Model error: " + error.ErrorMessage);
            //        }
            //    }

            //    return View(model);
            //}


            var user = new User 
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName,
                Address = model.Address,
                CreatedAt = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("CUSTOMER"))
                {
                    await _roleManager.CreateAsync(new Role { Name = "CUSTOMER" });
                }
                // Tạo token xác minh email
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
                var confirmationLink = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    token = encodedToken
                }, protocol: HttpContext.Request.Scheme);

                await _emailSender.SendEmailAsync(
                    model.Email,
                    "Verify your account",
                    $"Please verify your account by <a href='{HtmlEncoder.Default.Encode(confirmationLink)}'>clicking here</a>."
                );

                return RedirectToAction("RegisterConfirmation");
            }

    
            foreach (var error in result.Errors)
            {
                Console.WriteLine("❌ Identity Error: " + error.Description);
                ModelState.AddModelError(string.Empty, error.Description);
                TempData["Error"] += error.Description + "<br/>";
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult RegisterConfirmation() => View();

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(int userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return NotFound();

            var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);
            return View(result.Succeeded ? "ConfirmEmailSuccess" : "ConfirmEmailFailed");
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login() => View();

        // POST: /Account/Login
        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return View(model);

        //    var user = await _userManager.FindByEmailAsync(model.Email);
        //    if (user != null)
        //    {
        //        if (!await _userManager.IsEmailConfirmedAsync(user))
        //        {
        //            ModelState.AddModelError("", "Bạn cần xác minh email trước khi đăng nhập.");
        //            return View();
        //        }
        //    }

        //    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

        //    if (result.Succeeded)
        //        return RedirectToAction("Index", "Home");

        //    ModelState.AddModelError(string.Empty, "Đăng nhập không thành công.");
        //    return View(model);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    return RedirectToAction("EmailNotConfirmed");
                }
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            TempData["Error"] = "Incorrect email or password.";
            return View(model);
        }


        [HttpGet]
        public IActionResult EmailNotConfirmed()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(user); // Truyền model là User
        }



        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditInfo()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = new EditInfoViewModel
            {
                FullName = user.FullName,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditInfo(EditInfoViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.GetUserAsync(User);
            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                ModelState.AddModelError(string.Empty, "Incorrect password.");
                return View(model);
            }

            user.FullName = model.FullName;
            user.Address = model.Address;
            user.PhoneNumber = model.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Information updated successfully.";
                return RedirectToAction("Profile");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }


        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}
