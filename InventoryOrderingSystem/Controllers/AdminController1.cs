using InventoryOrderingSystem.Models;
using InventoryOrderingSystem.Service.Admins;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventoryOrderingSystem.Controllers
{
    public class AdminRegistrationController : Controller
    {
        private readonly AdminsService _adminService;

        public AdminRegistrationController(AdminsService adminService)
        {
            _adminService = adminService;
        }

      
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegistrationModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            
            if (await _adminService.AdminExists(model.Username))
            {
                ModelState.AddModelError("Username", "Username already taken");
                return View(model);
            }

          
            await _adminService.RegisterAdminAsync(model);

            ViewBag.SuccessMessage = "Admin registered successfully!";
            return View();
        }
    }
}