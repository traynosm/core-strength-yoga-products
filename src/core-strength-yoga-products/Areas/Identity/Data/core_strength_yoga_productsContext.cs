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
    }
}
