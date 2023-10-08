using AutoMapper;
using BaseNetCoreAPI.Data;
using BaseNetCoreAPI.Models.Country;

namespace BaseNetCoreAPI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, GetCountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();
        }
    }
}
