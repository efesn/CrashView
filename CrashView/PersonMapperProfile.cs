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

