using AutoMapper;
using Demo.BLL.DTOS.EmployeeDTOS;
using Demo.BLL.Services.Interfaces;
using Demo.DataAccess.Models.EmployeeModule;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.BLL.Services.Classes
{
    public class EmployeeService(IEmployeeRepository _employeeRepository,IMapper _mapper) : IEmployeeService
    {
        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
           var employee= _mapper.Map<CreatedEmployeeDto,Employee>(employeeDto);
            return _employeeRepository.Add(employee);    
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee is null) return false;

            else{
                employee.IsDeleted = true;
                return _employeeRepository.Update(employee)>0 ? true : false;
            }
        }

        public IEnumerable<EmployeeDto> GetAllEmployee(bool withTracking = false)
        {
            var employees = _employeeRepository.GetAll(withTracking);
            var employeeDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return employeeDto;
        }

        public EmployeeDetailsDto GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            return employee is null ? null : _mapper.Map<Employee,EmployeeDetailsDto>(employee);
        }

        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            return _employeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(employeeDto));
        }
    }
}
