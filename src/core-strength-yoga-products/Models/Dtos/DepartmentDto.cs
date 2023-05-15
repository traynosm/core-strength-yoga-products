using core_strength_yoga_products.Models;

namespace core_strength_yoga_products.Models.Dtos;

public class DepartmentDto
{
    public int Id { get; set; }
    public string DepartmentName { get; set; }
    public string Base64Image { get; set; }
    
    public static DepartmentDto Resolve(Department department)
    {
        return new DepartmentDto()
        {
            Id = department.Id,
            DepartmentName = department.Departmentname
        };
    }
    
    public static Department Resolve(DepartmentDto departmentDto)
    {
        return new Department()
        {
            Id = departmentDto.Id,
            Departmentname = departmentDto.DepartmentName,
            Base64Image = departmentDto.Base64Image
        };
    }
}