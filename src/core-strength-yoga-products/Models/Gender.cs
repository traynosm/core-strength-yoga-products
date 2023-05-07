using core_strength_yoga_products.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace core_strength_yoga_products.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        public string GenderName { get; set; }

        public Gender(int id, string genderName)
        {
            Id = id;
            GenderName = genderName;
        }
    }
}
