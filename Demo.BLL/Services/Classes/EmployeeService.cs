using Demo.BLL.DTOS.EmployeeDTOS;
using Demo.BLL.Services.Interfaces;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.BLL.Services.Classes
{
    public class EmployeeService(IEmployeeRepository _employeeRepository) : IEmployeeService
    {
        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeDto> GetAllEmployee(bool withTracking = false)
        {
            var employees = _employeeRepository.GetAll(withTracking);
            var employeeDto = employees.Select(e => new EmployeeDto() 
            { 
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                Age = e.Age,
                Salary = e.Salary,
                IsActive = e.isActive,
                Gender = e.Gender.ToString(),
                EmployeeType = e.EmployeeType.ToString(),
            });
            return employeeDto;
        }

        public EmployeeDetailsDto GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }
    }
}
