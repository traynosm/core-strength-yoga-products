using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using core_strength_yoga_products.Data;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using core_strength_yoga_products.Services;
using core_strength_yoga_products.Services;
using core_strength_yoga_products.Settings;

namespace core_strength_yoga_products
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = builder.Configuration.GetConnectionString("core_strength_yoga_productsContextConnection") ?? throw new InvalidOperationException(
                "Connection string 'core_strength_yoga_productsContextConnection' not found.");

            builder.Services.AddDbContext<core_strength_yoga_productsContext>(options =>
                options
                    .UseSqlite(connectionString));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<core_strength_yoga_productsContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient<IProductCategoryService, ProductCategoryService>();
            builder.Services.AddHttpClient<IProductTypeService, ProductTypeService>();
            builder.Services.AddHttpClient<IProductService, ProductService>();
            builder.Services.AddHttpClient<IBasketService, BasketService>();


            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(1);
            });

            builder.Services.Configure<ApiSettings>(o =>
                configuration.GetSection("ApiSettings").Bind(o));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            app.Run();
        }
    }
}