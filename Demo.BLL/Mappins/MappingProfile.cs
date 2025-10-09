using AutoMapper;
using Demo.BLL.DTOS.EmployeeDTOS;
using Demo.DataAccess.Models.EmployeeModule;
using Microsoft.Extensions.Options;

namespace Demo.BLL.Mappins
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Gender,options => options.MapFrom(scr =>scr.Gender))
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(scr => scr.EmployeeType));

            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dest => dest.Gender, options => options.MapFrom(scr => scr.Gender))
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(scr => scr.EmployeeType))
                .ForMember(dest => dest.HiringDate , options => options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)));

            CreateMap<CreatedEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

            CreateMap<UpdatedEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));
        }
    }
}
