using System.ComponentModel.DataAnnotations;

namespace core_strength_yoga_products.Models
{
    public class Size
    {
        [Key]
        public int Id { get; set; }
        public string SizeName { get; set; }

        public Size(int id, string sizeName) 
        {
            Id = id;
            SizeName = sizeName;
        }
    }
}
