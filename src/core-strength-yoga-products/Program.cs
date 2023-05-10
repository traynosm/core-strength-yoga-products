using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using core_strength_yoga_products.Data;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;

namespace core_strength_yoga_products
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("core_strength_yoga_productsContextConnection") ?? throw new InvalidOperationException("Connection string 'core_strength_yoga_productsContextConnection' not found.");

            builder.Services.AddDbContext<core_strength_yoga_productsContext>(options =>
                options
                    .UseLazyLoadingProxies()
                    .UseSqlite(connectionString));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<core_strength_yoga_productsContext>();

           // var sqlite_conn = CreateConnection(connectionString);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

        static SQLiteConnection CreateConnection(string connectionString)
        {
            var sqlite_conn = new SQLiteConnection(connectionString);
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }
    }
}