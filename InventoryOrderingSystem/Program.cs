using InventoryOrderingSystem.Models.Database;
using InventoryOrderingSystem.Models.Repositories.Customers;
using InventoryOrderingSystem.Models.Repositories.Products;
using InventoryOrderingSystem.Models.Repositories.Orders;
using InventoryOrderingSystem.Models.Repositories.OrderProductItems;
using InventoryOrderingSystem.Models.Services.Customers;
using InventoryOrderingSystem.Models.Services.Products;
using InventoryOrderingSystem.Models.Services.Orders;
using InventoryOrderingSystem.Models.Services.OrderProductItems;
using Microsoft.EntityFrameworkCore;
using InventoryOrderingSystem.Service.Orders;

namespace InventoryOrderingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

          
            builder.Services.AddControllersWithViews();

          
            builder.Services.AddDbContext<InventoryOrderingSystemContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderProductItemRepository, OrderProductItemRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderProductItemService, OrderProductItemService>();
            builder.Services.AddScoped<IAdminsService, AdminsService>();

            var app = builder.Build();

           
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}