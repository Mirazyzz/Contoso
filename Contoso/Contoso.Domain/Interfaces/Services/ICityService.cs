using Contoso.Domain.DTOs.Cities;

namespace Contoso.Domain.Interfaces.Services
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetAllCitiesAsync(string? name, string? searchString);
        Task<CityDto?> GetCityByIdAsync(int id);
        Task<CityDto?> CreateCityAsync(CityForCreateDto newCityDto);
        Task UpdateCityAsync( CityForUpdateDto cityForUpdateDto);
        Task DeleteCityAsync(int cityId);
        Task<bool> CityExists(int id);
    }
}
