using Demo.BLL.DTOS.EmployeeDTOS;

namespace Demo.BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        //Get All
        IEnumerable<EmployeeDto> GetAllEmployee(bool withTracking = false);

        //Get by Id
        EmployeeDetailsDto GetEmployeeById(int id);

        //Create employee
        int CreateEmployee (CreatedEmployeeDto employeeDto);

        //update employee
        int UpdateEmployee (UpdatedEmployeeDto employeeDto);

        //delete employee
        bool DeleteEmployee (int id);
    }
}
