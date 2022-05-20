using Contoso.Domain.DTOs.Cities;
using Contoso.Domain.Exceptions;
using Contoso.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contoso.Api.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _service;
        private readonly ILogger<CitiesController> _logger;

        public CitiesController(ICityService service, ILogger<CitiesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCities(string? cityName, string? searchString)
        {
            try
            {
                var cities = await _service.GetAllCitiesAsync(cityName, searchString);

                if(cities is null)
                {
                    return NotFound("Not cities were found.");
                }

                return Ok(cities);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error retrieving cities", ex.Message);

                return StatusCode(500, "There was an error while retrieving cities. Please, try again later.");
            }
        }

        [HttpGet("{cityId}")]
        public async Task<ActionResult<CityDto>> GetCity(int cityId)
        {
            try
            {
                var city = await _service.GetCityByIdAsync(cityId);

                if(city is null)
                {
                    _logger.LogWarning($"Retreiving non existing city with id: {cityId}.");

                    return NotFound($"Could not find city with id: {cityId}");
                }

                return Ok(city);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error while retrieving city with id: {cityId}.", ex.Message);

                return StatusCode(500, $"There was an error while retreiving city with id: {cityId}. Please, try again later");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CityDto>> CreateCity(CityForCreateDto cityToCreate)
        {
            try
            {
                if(cityToCreate is null)
                {
                    return BadRequest("Student canno be empty.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Student object is invalid");
                }

                var city = await _service.CreateCityAsync(cityToCreate);

                if(city is null)
                {
                    return StatusCode(500, "Unknown error has occured while creating a new city. Please, try again later.");
                }

                return Ok(city);
            }
            catch(EntityAlreadyExistException ex)
            {
                _logger.LogWarning($"Trying to create existing city: {cityToCreate}.", ex.Message);

                return BadRequest("City you trying to create already exists.");
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error while creating new city: {cityToCreate}.", ex.Message);

                return StatusCode(500, "There was an error while creating a new city. Please, try again later.");
            }
        }

        [HttpPut("{cityId}")]
        public async Task<ActionResult> UpdateCity(int cityId, CityForUpdateDto cityToUpdate)
        {
            try
            {
                if(cityToUpdate is null)
                {
                    return BadRequest("City cannot be empty.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("City object is invalid for updating.");
                }

                if(cityToUpdate.CityId != cityId)
                {
                    return BadRequest($"The city id: {cityToUpdate.CityId} does not match with route id: {cityId}.");
                }

                await _service.UpdateCityAsync(cityId, cityToUpdate);

                return NoContent();
            }
            catch(EntityDoesNotExistException ex)
            {
                _logger.LogWarning($"Updating non existing city with id: {cityId}", ex.Message);

                return NotFound($"City with id: {cityId} does not exist");
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error whiel updating city with id: {cityId}.", ex.Message);

                return StatusCode(500, $"There was an error while updating city with id: {cityId}. Please, try again later");
            }
        }

        [HttpDelete("{cityId}")]
        public async Task<ActionResult> DeleteCity(int cityId)
        {
            try
            {
                await _service.DeleteCityAsync(cityId);

                return NoContent();
            }
            catch(EntityDoesNotExistException ex)
            {
                _logger.LogWarning($"Deleting non existing city with id: {cityId}", ex.Message);

                return BadRequest($"The city with id: {cityId} that you are trying to delete does not exist.");
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error while deleting city with id: {cityId}.", ex.Message);

                return StatusCode(500, $"There was an error while deleting city with id: {cityId}. Please, try again later");
            }
        }

        #endregion
    }
}
