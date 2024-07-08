using AutoMapper;
using CrashView.Entities;
using CrashView.Dto.Request;

namespace CrashView
{
    public class PersonMapperProfile : Profile
    {
        public PersonMapperProfile()
        {
            CreateMap<Person, PersonsResponseDto>();
            CreateMap<PersonsRequestDto, Person>();
            CreateMap<PersonsResponseDto, Person>();

        }
    }
}


//public class Employee
//{
//    public string FullName { get; set; }
//    public string WorkPosition { get; set; }
//}

//public class EmployeeDto
//{
//    public string Name { get; set; }
//    public string Role { get; set; }
//}

//// AutoMapper configuration
//cfg.CreateMap<Employee, EmployeeDto>()
//   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName))
//   .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.WorkPosition));
