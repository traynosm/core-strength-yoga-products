using core_strength_yoga_products.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace core_strength_yoga_products.Data;

public class core_strength_yoga_productsContext : IdentityDbContext<IdentityUser>
{
    public core_strength_yoga_productsContext(DbContextOptions<core_strength_yoga_productsContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        SeedColours(builder);
    }

    /*public DbSet<Product> Products { get; set; } = default!;
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }*/


    private static void SeedColours(ModelBuilder builder)
    {
        /*builder.Entity<Colour>().HasData(new Colour(id: (int)Models.Enums.Colour.Unknown, colourName: Models.Enums.Colour.Unknown.ToString()));
        builder.Entity<Colour>().HasData(new Colour(id: (int)Models.Enums.Colour.Red, colourName: Models.Enums.Colour.Red.ToString()));
        builder.Entity<Colour>().HasData(new Colour(id: (int)Models.Enums.Colour.Green, colourName: Models.Enums.Colour.Green.ToString()));
        builder.Entity<Colour>().HasData(new Colour(id: (int)Models.Enums.Colour.Blue, colourName: Models.Enums.Colour.Blue.ToString()));*/
    }
}
