using AutoMapper;
using ParamApi.Data.Model;
using ParamApi.Dto.Dtos;

namespace ParamApi.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();
        }
    }
}
