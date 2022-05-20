using Contoso.Domain.DTOs.Cities;

namespace Contoso.Domain.Interfaces.Services
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetAllCitiesAsync(string? name, string? searchString);
        Task<CityDto?> GetCityByIdAsync(int id);
        Task<CityDto?> CreateCityAsync(CityForCreateDto newCityDto);
        Task UpdateCityAsync(int cityId, CityForUpdateDto cityForUpdateDto);
        Task DeleteCityAsync(int cityId);
        Task<bool> CityExistsAsync(int id);
    }
}
