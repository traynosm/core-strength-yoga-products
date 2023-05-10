using core_strength_yoga_products.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace core_strength_yoga_products.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string Alt { get; set; }
        public string Path { get; set; }

        public Image(int id, string imageName, string alt, string path)
        {
            Id = id;
            ImageName = imageName;
            Alt = alt;
            Path = path;
        }
    }
}
