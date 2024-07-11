using AutoMapper;
using CrashView.Entities;
using CrashView.Dto.Request;

namespace CrashView
{
    public class PersonTeamHistoryMapperProfile : Profile
    {
        public PersonTeamHistoryMapperProfile()
        {
            CreateMap<PersonTeamHistory, PersonTeamHistoryDto>()
                .ForMember(dest => dest.EmploymentStatus, opt =>
                {
                    opt.MapFrom(src => (src.End_Date.HasValue && src.End_Date <= DateTime.Today) ? " (Former)" : "(Active)");
                })
                .ForMember(dest => dest.Person_Name, opt =>
                {
                    opt.MapFrom(src => (src.End_Date.HasValue && src.End_Date <= DateTime.Today) ? $"{src.Person.First_Name} {src.Person.Last_Name} (Former)" : $"{src.Person.First_Name} {src.Person.Last_Name} (Active)");
                });

            CreateMap<PersonTeamHistoryDto, PersonTeamHistory>()
                .ForMember(dest => dest.EmploymentStatus, opt => opt.Ignore()); 
        }
    }
}
