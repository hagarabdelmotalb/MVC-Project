using Demo.BLL.DTOS.DepartmentDTOS;

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