using Demo.BLL.DTOS.DepartmentDTOS;
using Demo.BLL.Factories;
using Demo.BLL.Services.Interfaces;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.BLL.Services.Classes
{
    public class DepartmentService(IUnitOfWork _unitOfWork) : IDepartmentService
    {
        //Get All
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            return departments.Select(d => d.ToDepartmentDto());
        }

        //Get by id
        public DepartmentDetailsDto GetDepartmentById(int Id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(Id);
            return department is null ? null : department.ToDepartmentDetailsDto();

        }

        //ADD
        public int AddDepartment(CreateDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
            _unitOfWork.DepartmentRepository.Add(department);
            return _unitOfWork.SaveChanges();
        }

        //UPDATE
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            var department = departmentDto.updateDepartmentEntity();
            _unitOfWork.DepartmentRepository.Update(department);
            return _unitOfWork.SaveChanges();
        }

        //DELETE
        public bool DeleteDepartment(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department is null)
            {
                return false;
            }
            _unitOfWork.DepartmentRepository.Delete(department);
            //NumOfRows > 0 ? true : false;
            return _unitOfWork.SaveChanges() > 0 ? true : false;
        } 

    }
}
