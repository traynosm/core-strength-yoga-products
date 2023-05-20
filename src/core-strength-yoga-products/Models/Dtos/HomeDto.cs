
namespace core_strength_yoga_products.Models.Dtos;

public class HomeDto
{

    public IEnumerable<ProductCategoryDto> productCategories { get; set; }
    public IEnumerable<ProductTypeDto> productTypes { get; set; }


    public HomeDto(){}
    

    
}