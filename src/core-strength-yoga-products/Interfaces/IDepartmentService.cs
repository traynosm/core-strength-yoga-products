using core_strength_yoga_products.Models;

namespace core_strength_yoga_products.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<ProductType>> GetDepartments();
    }
}
