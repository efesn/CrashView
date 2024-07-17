using AutoMapper;
using CrashView.Entities;
using CrashView.Dto.Request;
using CrashView.Dto.Response;

namespace CrashView
{
    public class RaceResultMapperProfile : Profile
    {
        public RaceResultMapperProfile()
        {
            CreateMap<RaceResult, RaceResultResponseDto>();

            CreateMap<RaceResultRequestDto, RaceResult>()
                .ForMember(dest => dest.PointsEarned, opt => opt.MapFrom<PointsResolver>()) 
                .ForMember(dest => dest.Person_ID, opt => opt.MapFrom(src => src.Person_ID));

            CreateMap<RaceResultResponseDto, RaceResult>();
        }
    }
}
