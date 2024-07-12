using AutoMapper;
using CrashView.Dto.Response;
using CrashView.Entities;

namespace CrashView
{
    public class TeamMapperProfile : Profile
    {
        public TeamMapperProfile()
        {
            CreateMap<Team, TeamResponseDto>()
                .ForMember(dest => dest.TotalPoints, opt => opt.MapFrom<TeamPointsResolver>());
        }
    }
}
