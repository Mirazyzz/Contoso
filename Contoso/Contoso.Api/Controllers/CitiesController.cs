using Contoso.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contoso.Api.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly ILogger<CitiesController> _logger;

        public CitiesController(IStudentService service, ILogger<CitiesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/<CitiesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CitiesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CitiesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CitiesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CitiesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
