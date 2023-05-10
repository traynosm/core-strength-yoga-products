using core_strength_yoga_products.Models;
using core_strength_yoga_products.Models.Enums;
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

        SeedProductTypes(builder);
        SeedProductCategories(builder);
        SeedProducts(builder);
        SeedProductAttributes(builder);
        SeedImages(builder);


    }

    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    public static void SeedProductTypes(ModelBuilder builder)
    {
        builder.Entity<Models.ProductType>().HasData(
            new Models.ProductType(
                id: 1,
                productTypeName: "Equipment",
                description: "Our Selection of Equipment",
                imageId: 1));

        builder.Entity<Models.ProductType>().HasData(
           new Models.ProductType(
                id: 2,
                productTypeName: "Clothing",
                description: "Our Selection of Clothing",
                imageId: 1));
    }

    public static void SeedProductCategories(ModelBuilder builder)
    {
        builder.Entity<Models.ProductCategory>().HasData(
            new Models.ProductCategory(
                id: 1, 
                productCategoryName: "Mats",
                description: "Our Selection of Mats",
                imageId: 1));
    }

    public static void SeedProductAttributes(ModelBuilder builder)
    {
        builder.Entity<ProductAttributes>().HasData(new ProductAttributes(
                id: 1,
                stockLevel: 10,
                priceAdjustment: 0,
                colour: Colour.Red,
                size: Size.M,
                gender: Gender.Unisex,
                productId: 1
            ));
    }

    public static void SeedImages(ModelBuilder builder)
    {
        builder.Entity<Image>().HasData(new Image(
                id: 1,
                imageName: "yoga-mat-1",
                alt: "some alt",
                path: "~/images/banner-1.jpg",
                productId: 1
            ));
    }

    public static void SeedProducts(ModelBuilder builder)
    {
        var product = new Product(
            id: 1,
            name: "Bog Standard Yoga Mat",
            description: "The worst yoga mat you have ever seen",
            fullPrice: 30m
        );

        product.ProductTypeId = 1;
        product.ProductCategoryId = 1;

        builder.Entity<Product>().HasData(product);
    }
}
