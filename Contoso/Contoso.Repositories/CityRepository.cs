using Contoso.Domain.Entities;
using Contoso.Domain.Interfaces.Repostiory;
using Contoso.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Repositories
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(ContosoDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<City>> FindAllCitiesAsync(string? name, string? searchString)
        {
            var cities = _context.Cities
                .Include(c => c.Departments)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                cities = cities.Where(c => c.CityName.Equals(name));
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                cities = cities.Where(c => c.CityName.Contains(searchString));
            }

            return await cities.ToListAsync();
        }

        public async Task<City?> FindCityByIdAsync(int id)
        {
            return await FindById(id);
        }

        public City CreateCity(City newCity)
        {
            return Create(newCity);
        }

        public void DeleteCity(City cityToDelete)
        {
            Delete(cityToDelete);
        }

        public void UpdateCity(City cityToUpdate)
        {
            Update(cityToUpdate);
        }
    }
}
