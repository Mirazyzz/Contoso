using AutoMapper;
using Contoso.Domain.DTOs.Cities;
using Contoso.Domain.Entities;
using Contoso.Domain.Interfaces.Repostiory;
using Contoso.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Services
{
    public class CityService : ICityService
    {
        private readonly ICommonRepository _repository;
        private readonly IMapper _mapper;

        public CityService(ICommonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDto>> GetAllCitiesAsyc(string? name, string? searchString)
        {
            try
            {
                var cities = await _repository.City.FindAllCitiesAsync(name, searchString);

                var cityDtos = _mapper.Map<IEnumerable<CityDto>>(cities);

                return cityDtos;
            }
            catch(Exception ex)
            {
                throw new Exception($"There was an error while retrieving cities. {ex.Message}");
            }
        }

        public async Task<CityDto?> GetCityByIdAsync(int id)
        {
            try
            {
                var city = await _repository.City.FindCityByIdAsync(id);

                var cityDto = _mapper.Map<CityDto>(city);

                return cityDto;
            }
            catch(Exception ex)
            {
                throw new Exception($"There was an error while retreiving city with id: {id}. {ex.Message}");
            }
        }

        public async Task<CityDto?> CreateCityAsync(CityForCreateDto newCityDto)
        {
            try
            {
                var cityEntity = _mapper.Map<City>(newCityDto);

                var createdCity = _repository.City.CreateCity(cityEntity);

                await _repository.SaveChangesAsync();

                var cityDto = _mapper.Map<CityDto>(createdCity);

                return cityDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error adding new city: {newCityDto}. {ex.Message}");
            }
        }

        public async Task DeleteCityAsync(int cityId)
        {
            try
            {
                var cityEntity = await _repository.City.FindCityByIdAsync(cityId);

                if(cityEntity != null)
                {
                    _repository.City.DeleteCity(cityEntity);
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"There was an error deleting city with id: {cityId}. {ex.Message}");
            }
        }

        public async Task UpdateCityAsync(CityForUpdateDto cityForUpdateDto)
        {
            try
            {
                var cityEntity = _mapper.Map<City>(cityForUpdateDto);
                
                _repository.City.UpdateCity(cityEntity);
                await _repository.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"There was an error updating city: {cityForUpdateDto}. {ex.Message}");
            }
        }

        public async Task<bool> CityExists(int id)
        {
            return await _repository.City.FindCityByIdAsync(id) != null;
        }
    }
}
