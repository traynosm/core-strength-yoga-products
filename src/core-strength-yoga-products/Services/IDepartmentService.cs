

using core_strength_yoga_products.Models.Dtos;

namespace core_strength_yoga_products.Services;

public interface IDepartmentService
{
    public Task<IEnumerable<DepartmentDto>?> GetDepartments();


}