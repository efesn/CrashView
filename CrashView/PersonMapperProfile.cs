using AutoMapper;

namespace CrashView
{
    public class PersonMapperProfile : Profile
    {
            public PersonMapperProfile()
            {
                CreateMap<Entities.Person, Dto.Response.PersonsResponseDto>();
                CreateMap<Dto.Request.PersonsRequestDto, Entities.Person>();
            }
        }
    }
