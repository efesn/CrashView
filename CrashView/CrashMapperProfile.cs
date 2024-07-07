using CrashView.Entities;
using AutoMapper;
using CrashView.Dto.Request;
using CrashView.Dto.Response;

namespace CrashView
{
    public class CrashMapperProfile : Profile 
    {
        public CrashMapperProfile()
        {
            CreateMap<Crash, CrashResponseDto>();
            CreateMap<CrashRequestDto, Crash>();
            CreateMap<CrashResponseDto, Crash>();
        }
    }
}
