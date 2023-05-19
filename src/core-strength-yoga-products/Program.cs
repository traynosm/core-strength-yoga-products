using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using core_strength_yoga_products.Data;
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
            builder.Services.AddHttpClient<ProductCategoryService>();
            builder.Services.AddHttpClient<ProductTypeService>();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            app.Run();
        }
    }
}