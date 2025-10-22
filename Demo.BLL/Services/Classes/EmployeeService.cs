using AutoMapper;
using Demo.BLL.DTOS.EmployeeDTOS;
using Demo.BLL.Services.AttachmentService;
using Demo.BLL.Services.Interfaces;
using Demo.DataAccess.Models.EmployeeModule;

namespace Demo.BLL.Services.Classes
{
    public class EmployeeService(IUnitOfWork _unitOfWork,IMapper _mapper, IAttachmentService _attachmentService) : IEmployeeService
    {
        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
           var employee= _mapper.Map<CreatedEmployeeDto,Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Add(employee); 
            return _unitOfWork.SaveChanges();
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if (employee is null) return false;

            else{
                employee.IsDeleted = true;
                _unitOfWork.EmployeeRepository.Update(employee);
                return _unitOfWork.SaveChanges() > 0 ? true : false;
            }
        }

        public IEnumerable<EmployeeDto> GetAllEmployee(string? EmployeeSearchName , bool withTracking = false)
        {
            IEnumerable<Employee> employees;
            if (!string.IsNullOrEmpty(EmployeeSearchName))
            {
                employees = _unitOfWork.EmployeeRepository.GetAll(e => e.Name.ToLower().Contains(EmployeeSearchName.ToLower()));
            }
            else
            {
                employees = _unitOfWork.EmployeeRepository.GetAll(withTracking);
            }

            var employeeDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return employeeDto;
        }

        public EmployeeDetailsDto GetEmployeeById(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            return employee is null ? null : _mapper.Map<Employee,EmployeeDetailsDto>(employee);
        }

        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            _unitOfWork.EmployeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(employeeDto));
            return _unitOfWork.SaveChanges();
        }
    }
}
