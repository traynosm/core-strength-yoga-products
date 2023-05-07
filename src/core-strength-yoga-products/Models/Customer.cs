using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace core_strength_yoga_products.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public virtual IdentityUser? IdentityUser { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsGdpr { get; set; }

        public Customer(int id, DateTime createdAt, bool isActive, bool isGdpr)
        {
            Id = id;
            CreatedAt = createdAt;
            IsActive = isActive;
            IsGdpr = isGdpr;
        }
    }
}
