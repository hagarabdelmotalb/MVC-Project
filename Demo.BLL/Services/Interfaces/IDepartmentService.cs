using Demo.BLL.DTOS;

namespace Demo.BLL.Services.Interfaces
{
    public interface IDepartmentService
    {
        int AddDepartment(CreateDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDetailsDto GetDepartmentById(int Id);
        int UpdateDepartment(UpdatedDepartmentDto departmentDto);
    }
}