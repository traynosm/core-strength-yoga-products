using Microsoft.AspNetCore.Identity;

namespace core_strength_yoga_products.Models;

public class Users
{
    public virtual IdentityUser? IdentityUser { get; set; }
    public virtual ICollection<IdentityRole>? Roles { get; set; }
}
