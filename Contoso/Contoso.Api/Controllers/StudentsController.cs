using Contoso.Domain.DTOs.Students;
using Contoso.Domain.Exceptions;
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
            var students = await _service.GetAllStudentsAsync();

            if(students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }

        [HttpGet("{studentId}")]
        public async Task<ActionResult<StudentDto>> GetStudentById(int studentId)
        {
            try
            {
                var student = await _service.GetStudentById(studentId);

                if(student is null)
                {
                    return NotFound($"Could not find student with id: {studentId}");
                }

                return Ok(student);
            }
            catch(NotFoundDbException ex)
            {
                return NotFound($"Could not find student with id: {studentId}");
            }
            catch(Exception ex)
            {
                return NotFound($"There was an error while retreiving student with id: {studentId}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateStudent(StudentForCreateDto studentDto)
        {
            try
            {
                var studentEntity = await _service.CreateStudent(studentDto);

                if (studentEntity is null)
                {
                    return BadRequest("There was an error creating a new student, please try again later");
                }

                return Ok(studentEntity);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{studentId}")]
        public async Task<ActionResult> UpdateStudent(int studentId, StudentForUpdateDto studentToUpdateDto)
        {
            try
            {
                await _service.UpdateStudent(studentId, studentToUpdateDto);

                return NoContent();
            }
            catch(NotFoundDbException ex)
            {
                return NotFound($"The student with id: {studentId} you are trying to update does not exist. Please consider creating.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{studentId}")]
        public async Task<ActionResult> DeleteStudent(int studentId)
        {
            try
            {
                await _service.DeleteStudent(studentId);

                return NoContent();
            }
            catch(NotFoundDbException ex)
            {
                return NotFound($"Student with id: {studentId} does not exist.");
            }
            catch(Exception ex)
            {
                return BadRequest($"There was an error while deleting student with id: {studentId}");
            }
        }
    }
}
