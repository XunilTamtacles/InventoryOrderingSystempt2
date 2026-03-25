using InventoryOrderingSystem.Models.Database;
using InventoryOrderingSystem.Models.Services.Customers;
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
        private readonly ICustomerService _customerService;
        private readonly AdminsService _adminService;

        public AccountController(ICustomerService customerService, AdminsService adminService)
        {
            _customerService = customerService;
            _adminService = adminService;
        }

        // Show login page
        public IActionResult Login()
        {
            return View();
        }

        // Handle login post
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Try admin login
            var admin = await _adminService.LoginAdminAsync(model.Username, model.Password);

            if (admin != null)
            {
                await SignInUser(admin.Username, admin.Id, "Admin");
                return RedirectToAction("Index", "Admin");
            }

            // Try customer login
            var customer = await _customerService.LoginCustomerAsync(model.Username, model.Password);
            if (customer != null)
            {
                await SignInUser(customer.Username, customer.Id, "Customer");
                return RedirectToAction("Index", "CustomerDashboard");
            }

            ViewBag.ErrorMessage = "Username or password is incorrect";
            return View(model);
        }

        private async Task SignInUser(string username, int userId, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        // Logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}