using AutoMapper;
using CrashView.Dto.Request;
using CrashView.Dto.Response;
using CrashView.Entities;

namespace CrashView
{
    public class RaceMapperProfile : Profile
    {
        public RaceMapperProfile()
        {
            CreateMap<Race, RaceResponseDto>();
            CreateMap<RaceRequestDto, Race>();
            CreateMap<RaceResponseDto, Race>();
        }
    }
}
