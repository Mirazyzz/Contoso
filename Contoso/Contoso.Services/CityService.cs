using AutoMapper;
using Contoso.Domain.DTOs.Cities;
using Contoso.Domain.Entities;
using Contoso.Domain.Exceptions;
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

        public async Task<IEnumerable<CityDto>> GetAllCitiesAsync(string? name, string? searchString)
        {
            try
            {
                var cities = await _repository.City.FindAllCitiesAsync(name, searchString);

                if(cities is null)
                {
                    throw new Exception("Cities not found.");
                }

                var cityDtos = _mapper.Map<IEnumerable<CityDto>>(cities);

                if(cityDtos is null)
                {
                    throw new Exception("Could not map City entites list to City DTOs.");
                }

                return cityDtos;
            }
            catch(Exception ex)
            {
                throw new Exception($"There was an error while retrieving cities.", ex);
            }
        }

        public async Task<CityDto?> GetCityByIdAsync(int cityId)
        {
            try
            {
                var city = await _repository.City.FindCityByIdAsync(cityId);

                if(city is null)
                {
                    throw new EntityDoesNotExistException($"City with id: {cityId} does not exist.");
                }

                var cityDto = _mapper.Map<CityDto>(city);

                if(cityDto is null)
                {
                    throw new Exception("Cannot map City entity to City DTO");
                }

                return cityDto;
            }
            catch(Exception ex)
            {
                throw new Exception($"There was an error while retreiving city with id: {cityId}.", ex);
            }
        }

        public async Task<CityDto?> CreateCityAsync(CityForCreateDto newCityDto)
        {
            try
            {
                // Map to city entity
                var cityEntity = _mapper.Map<City>(newCityDto);

                if(cityEntity is null)
                {
                    throw new Exception("Could not map CityForCreateDto to City entity.");
                }

                var createdCity = _repository.City.CreateCity(cityEntity);
                await _repository.SaveChangesAsync();

                // Map newly created student back to DTO
                var cityDto = _mapper.Map<CityDto>(createdCity);

                return cityDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error while creating a new city: {newCityDto}.", ex);
            }
        }

        public async Task UpdateCityAsync(int cityId, CityForUpdateDto cityForUpdateDto)
        {
            var cityEntity = await _repository.City.FindCityByIdAsync(cityId);

            if(cityEntity is null)
            {
                throw new EntityDoesNotExistException($"City with id: {cityId} does not exist.");
            }

            try
            {
                cityEntity = _mapper.Map(cityForUpdateDto, cityEntity);

                if (cityEntity is null)
                {
                    throw new Exception("Could not map CityForUpdateDto to City entity.");
                }
                
                _repository.City.UpdateCity(cityEntity);
                await _repository.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"There was an error updating city: {cityForUpdateDto}.", ex);
            }
        }

        public async Task DeleteCityAsync(int cityId)
        {
            var cityEntity = await _repository.City.FindCityByIdAsync(cityId);

            if (cityEntity is null)
            {
                throw new EntityDoesNotExistException($"City with id: {cityId} does not exist.");
            }

            try
            {
                _repository.City.DeleteCity(cityEntity);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error deleting city with id: {cityId}.", ex);
            }
        }

        public async Task<bool> CityExistsAsync(int id)
        {
            return await _repository.City.FindCityByIdAsync(id) is not null;
        }
    }
}
