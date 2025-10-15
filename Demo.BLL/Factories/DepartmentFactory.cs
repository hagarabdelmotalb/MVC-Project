using Demo.BLL.DTOS.DepartmentDTOS;
using Demo.DataAccess.Models.DepartmentModule;

namespace Demo.BLL.Factories
{
    internal static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department d)
        {
            return new DepartmentDto()
            {
                DepId = d.Id,
                Code = d.Code,
                Description = d.Description,
                Name = d.Name,
                DateOfCreation = d.CreatedAt.HasValue ? DateOnly.FromDateTime(d.CreatedAt.Value) : default
            };
        }

        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department department)
        {
            return new DepartmentDetailsDto()
            {
                Id = department.Id,
                Code = department.Code,
                Description = department.Description,
                Name = department.Name,
                CreatedAt = DateOnly.FromDateTime(department.CreatedAt.HasValue ? department.CreatedAt.Value : default),
                CreatedBy = department.CreatedBy,
                IsDeleted = department.IsDeleted,
                ModifiedAt = DateOnly.FromDateTime(department.ModifiedAt.HasValue ? department.ModifiedAt.Value : default),
                ModifiedBy = department.ModifiedBy 
            };
        }

        public static Department ToEntity(this CreateDepartmentDto departmentDto)
        {
            return new Department()
            {
                Description = departmentDto.Description,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                CreatedAt = departmentDto.DateOfCreation.ToDateTime(new TimeOnly()),
            };
        }

        public static Department updateDepartmentEntity(this UpdatedDepartmentDto departmentDto)
        {
            return new Department()
            {
                Id = departmentDto.Id,
                Description = departmentDto.Description,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                CreatedAt = departmentDto.DateOfCreation.ToDateTime(new TimeOnly()),
            };
        }

    }
}
