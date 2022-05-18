using AutoMapper;
using Contoso.Domain.DTOs.Cities;
using Contoso.Domain.Entities;

namespace Contoso.Api.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>();
            CreateMap<CityForCreateDto, City>();
            CreateMap<CityForUpdateDto, City>();
        }
    }
}
