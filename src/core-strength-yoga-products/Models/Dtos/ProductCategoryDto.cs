using core_strength_yoga_products.Models;

namespace core_strength_yoga_products.Models.Dtos
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }
        public string ProductCategoryName { get; set; }
        public string Description { get; set; }
        public ImageDto Image { get; set; }

       
    }
}
