using Contoso.Domain.DTOs.Students;
using Contoso.Domain.Exceptions;
using Contoso.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Api.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(IStudentService service, ILogger<StudentsController> logger)
        {
            _service = service;
            _logger = logger;
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
            string errorMessage = string.Empty;
            string exceptionMessage = string.Empty;

            try
            {
                var student = await _service.GetStudentById(studentId);

                if(student is null)
                {
                    errorMessage = $"Could not find student with id: {studentId}";

                    return NotFound($"Could not find student with id: {studentId}");
                }

                return Ok(student);
            }
            catch(NotFoundDbException ex)
            {
                errorMessage = $"Could not find student with id: {studentId}";
                exceptionMessage = ex.Message;

                return NotFound($"Could not find student with id: {studentId}");
            }
            catch(Exception ex)
            {
                errorMessage = $"There was an error while retreiving student with id: {studentId}";
                exceptionMessage = ex.Message;

                return NotFound($"There was an error while retreiving student with id: {studentId}");
            }
            finally
            {
                _logger.LogError(errorMessage, exceptionMessage);
            }
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateStudent(StudentForCreateDto studentDto)
        {
            string errorMessage = string.Empty;
            string exceptionMessage = string.Empty;

            try
            {
                var studentEntity = await _service.CreateStudent(studentDto);

                if (studentEntity is null)
                {
                    errorMessage = "There was an error creating a new student, please try again later";

                    return BadRequest(errorMessage);
                }

                return Ok(studentEntity);
            }
            catch(CreateDbException ex)
            {
                errorMessage = "There was an error creating a new student, please try again later";
                exceptionMessage = ex.Message;

                return BadRequest(errorMessage);
            }
            catch(Exception ex)
            {
                errorMessage = "There was an error creating a new student, please try again later";
                exceptionMessage = ex.Message;

                return BadRequest(errorMessage);
            }
            finally
            {
                _logger.LogError(errorMessage, exceptionMessage);
            }
        }

        [HttpPut("{studentId}")]
        public async Task<ActionResult> UpdateStudent(int studentId, StudentForUpdateDto studentToUpdateDto)
        {
            string errorMessage = string.Empty;
            string exceptionMessage = string.Empty;

            try
            {
                await _service.UpdateStudent(studentId, studentToUpdateDto);

                return NoContent();
            }
            catch(NotFoundDbException ex)
            {
                errorMessage = $"The student with id: {studentId} you are trying to update does not exist. Please consider creating.";
                exceptionMessage = ex.Message;

                return NotFound(errorMessage);
            }
            catch(Exception ex)
            {
                errorMessage = $"There was an error while updating the student with id{studentId}.";
                exceptionMessage = ex.Message;

                return BadRequest(ex.Message);
            }
            finally
            {
                _logger.LogError(errorMessage, exceptionMessage);
            }
        }

        [HttpDelete("{studentId}")]
        public async Task<ActionResult> DeleteStudent(int studentId)
        {
            string errorMessage = string.Empty;
            string exceptionMessage = string.Empty;

            try
            {
                await _service.DeleteStudent(studentId);

                return NoContent();
            }
            catch(NotFoundDbException ex)
            {
                errorMessage = $"Student with id: {studentId} does not exist.";
                exceptionMessage = ex.Message;

                return NotFound(errorMessage);
            }
            catch(Exception ex)
            {
                errorMessage = $"There was an error while deleting student with id: {studentId}";
                exceptionMessage = ex.Message;

                return BadRequest(errorMessage);
            }
            finally
            {
                _logger.LogError(errorMessage, exceptionMessage);
            }
        }
    }
}
