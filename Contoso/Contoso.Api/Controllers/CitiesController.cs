using Contoso.Domain.DTOs.Cities;
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

        // GET: api/<CitiesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCities(string? cityName, string? searchString)
        {
            try
            {
                var cities = await _service.GetAllCitiesAsync(cityName, searchString);

                if(cities == null)
                {
                    return NotFound(cities);
                }

                return Ok(cities);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);

                return StatusCode(500, "There was an error while retreiving cities. Please, try again later.");
            }
        }

        // GET api/<CitiesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetCity(int id)
        {
            try
            {
                var city = await _service.GetCityByIdAsync(id);

                if(city is null)
                {
                    return NotFound();
                }

                return Ok(city);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error while retreiving city with id: {id}. {ex.Message}");

                return StatusCode(500, $"There was an error while retreiving city with id: {id}. Please, try again later");
            }
        }

        // POST api/<CitiesController>
        [HttpPost]
        public async Task<ActionResult<CityDto>> CreateCity(CityForCreateDto cityToCreate)
        {
            try
            {
                var city = await _service.CreateCityAsync(cityToCreate);

                if(city is null)
                {
                    return StatusCode(500, "Something went wrong while creating a new city. Please, try again later.");
                }

                return Ok(city);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error while creating new city: {cityToCreate}. {ex.Message}");

                return StatusCode(500, "There was an error while creating a new city. Please, try again later.");
            }
        }

        // PUT api/<CitiesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCity(int id, CityForUpdateDto cityToUpdate)
        {
            try
            {
                await _service.UpdateCityAsync(cityToUpdate);

                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error whiel updating city with id: {id}. {ex.Message}");

                return StatusCode(500, $"There was an error while updating city with id: {id}. Please, try again later");
            }
        }

        // DELETE api/<CitiesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCity(int id)
        {
            try
            {
                await _service.DeleteCityAsync(id);

                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error while deleting city with id: {id}. {ex.Message}");

                return StatusCode(500, $"There was an error while deleting city with id: {id}. Please, try again later");
            }
        }
    }
}
