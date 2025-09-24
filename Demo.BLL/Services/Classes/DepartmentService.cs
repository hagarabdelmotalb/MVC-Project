using Demo.BLL.DTOS;
using Demo.BLL.Factories;
using Demo.BLL.Services.Interfaces;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.BLL.Services.Classes
{
    public class DepartmentService(IDepartmentRepository _departmentRepository) : IDepartmentService
    {
        //Get All
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();
            return departments.Select(d => d.ToDepartmentDto());
        }

        //Get by id
        public DepartmentDetailsDto GetDepartmentById(int Id)
        {
            var department = _departmentRepository.GetById(Id);
            return department is null ? null : department.ToDepartmentDetailsDto();

            //Add

            //Update

            //Delete
        }

        //ADD
        public int AddDepartment(CreateDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
            return _departmentRepository.Add(department);
        }

        //UPDATE
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            var department = departmentDto.updateDepartmentEntity();
            return _departmentRepository.Update(department);
        }

        //DELETE
        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department is null)
            {
                return false;
            }
            int NumOfRows = _departmentRepository.Delete(department);
            return NumOfRows > 0 ? true : false;
        }
    }
}
