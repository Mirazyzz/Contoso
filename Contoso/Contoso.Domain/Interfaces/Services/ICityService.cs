using Contoso.Domain.Entities;

namespace Contoso.Domain.Interfaces.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task AddCityAsync(City newCity);
        Task UpdateCityAsync(City newCity);
        Task DeleteStudentAsync(City cityToDelete);
    }
}
