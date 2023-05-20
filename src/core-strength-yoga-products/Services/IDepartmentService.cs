

using core_strength_yoga_products.Models;

namespace core_strength_yoga_products.Services;

public interface IDepartmentService
{
    public Task<IEnumerable<ProductCategory>?> GetDepartments();


}