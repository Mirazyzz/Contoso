using Contoso.Domain.Entities;

namespace Contoso.Domain.Interfaces.Repostiory
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> FindAllCitiesAsync(string? name, string? searchString);
        Task<City?> FindCityByIdAsync(int id);
        City CreateCity(City newCity);
        void DeleteCity(City cityToDelete);
        void UpdateCity(City cityToUpdate);
    }
}
