using AutoMapper;
using CrashView.Entities;
using CrashView.Dto.Response;
using CrashView.Dto.Request;

namespace CrashView
{
    public class PersonTeamHistoryMapperProfile : Profile
    {
        public PersonTeamHistoryMapperProfile()
        {
            CreateMap<PersonTeamHistory, PersonTeamHistoryDto>();
        }
    }
}
