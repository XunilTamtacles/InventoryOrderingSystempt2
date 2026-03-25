using InventoryOrderingSystem.Models.Database;
using InventoryOrderingSystem.Service.Admins;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InventoryOrderingSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAdminsService _adminService;

        public AccountController(IAdminsService adminService)
        {
            _adminService = adminService;
        }

     
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.ErrorMessage = "Please enter username and password.";
                return View();
            }

            var loginResult = await _adminService.LoginAdminAsync(username, password);

            if (loginResult.LoginSuccessful)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.NameIdentifier, loginResult.UserId.ToString()),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Admin");
            }

            ViewBag.ErrorMessage = "Invalid username or password.";
            return View();
        }

   
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

       
        public IActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Register(Administrator admin)
        {
            if (string.IsNullOrEmpty(admin.Username) || string.IsNullOrEmpty(admin.Password))
            {
                ViewBag.ErrorMessage = "Username and password are required.";
                return View(admin);
            }

            if (await _adminService.AdminExists(admin.Username))
            {
                ViewBag.ErrorMessage = "Username already exists.";
                return View(admin);
            }

            await _adminService.RegisterAdminAsync(admin);
            ViewBag.SuccessMessage = "Admin registered successfully!";
            return View();
        }
    }
}