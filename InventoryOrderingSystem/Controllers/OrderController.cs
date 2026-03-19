using InventoryOrderingSystem.Models.Database;
using InventoryOrderingSystem.Models.Services.Orders;
using Microsoft.AspNetCore.Mvc;

namespace InventoryOrderingSystem.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

      
        public async Task<IActionResult> Index()
        {
            var orders = await _service.GetAllOrdersAsync();
            return View(orders);
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateOrderAsync(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

     
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _service.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateOrderAsync(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var order = await _service.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteOrderAsync(id);
            return RedirectToAction("Index");
        }
    }
}