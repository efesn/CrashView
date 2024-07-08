using AutoMapper;
using CrashView.Entities;
using CrashView.Dto.Request;

namespace CrashView
{
    public class RaceResultMapperProfile : Profile
    {
        public RaceResultMapperProfile()
        {
            CreateMap<RaceResult, RaceResultDto>();
            CreateMap<RaceResultDto, RaceResult>();
        }
    }
}
