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

            //CreateMap<Race, RaceResponseDto>()
            //    .ForMember(dest => dest.Season_Name, opt => opt.MapFrom(src => src.Season.Season_Name))
            //    .ForMember(dest => dest.Track_Name, opt => opt.MapFrom(src => src.Track.Track_Name));

            //CreateMap<RaceRequestDto, Race>();
        }
    }
}
