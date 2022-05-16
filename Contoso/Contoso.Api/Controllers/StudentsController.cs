using Contoso.Domain.DTOs.Students;
using Contoso.Domain.Interfaces.Repostiory;
using Contoso.Domain.Interfaces.Services;
using Contoso.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Api.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students = await _service.GetStudentsAsync();

            if(students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }

    }
}
