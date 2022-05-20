using Contoso.Domain.DTOs.Students;
using Contoso.Domain.Enums;
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

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents(string? name, string? searchQuery, 
                                                                                int? age, int? cityId,  int? departmentId, 
                                                                                Gender? gender, string? orderBy)
        {
            try
            {
                var students = await _service.GetAllStudentsAsync(name, searchQuery, age, cityId, departmentId, gender, orderBy);

                if (students is null)
                {
                    return NotFound("No students were found.");
                }

                return Ok(students);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error while retreiving students.", ex.Message);

                return StatusCode(500, "There was an error while retrieving students. Please, try again later.");
            }
        }

        [HttpGet("{studentId}")]
        public async Task<ActionResult<StudentDto>> GetStudentById(int studentId)
        {
            try
            {
                var student = await _service.GetStudentByIdAsync(studentId);

                if(student is null)
                {
                    _logger.LogWarning($"Retrieving non existing student with id: {studentId}.");

                    return NotFound($"Could not find student with id: {studentId}.");
                }

                return Ok(student);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error while retrieving student with id: {studentId}", ex.Message);

                return StatusCode(500, $"There was an error while retrieving student with id: {studentId}. Please, try again later.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateStudent(StudentForCreateDto studentToCreate)
        {
            try
            {
                if(studentToCreate is null)
                {
                    return BadRequest("Student cannot be empty.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("The student object is invalid.");
                }

                var studentDto = await _service.CreateStudentAsync(studentToCreate);

                if (studentDto is null)
                {
                    return StatusCode(500, "Unknown error has occured while creating a new student. Please, try again later.");
                }

                return Ok(studentDto);
            }
            catch(EntityAlreadyExistException ex)
            {
                _logger.LogWarning($"Trying to create existing student: {studentToCreate}", ex.Message);

                return BadRequest("Student you are trying to create already exists.");
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error while creating a new student {studentToCreate}", ex.Message);

                return StatusCode(500, "There was an error while creating a new student. Please, try again later.");
            }
        }

        [HttpPut("{studentId}")]
        public async Task<ActionResult> UpdateStudent(int studentId, StudentForUpdateDto studentToUpdateDto)
        {
            try
            {
                if(studentToUpdateDto is null)
                {
                    return BadRequest("Student cannot be empty.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("The student for update is not valid.");
                }

                if(studentToUpdateDto.StudentId != studentId)
                {
                    return BadRequest($"Student id: {studentToUpdateDto.StudentId} does not match with route id: {studentId}");
                }

                await _service.UpdateStudentAsync(studentId, studentToUpdateDto);

                return NoContent();
            }
            catch(EntityDoesNotExistException ex)
            {
                _logger.LogWarning("Updating non existing student", ex.Message);

                return NotFound($"The student with id: {studentId} that you are trying to update does not exist. Please consider creating");
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error while updating a student with id: {studentId}", ex.Message);

                return StatusCode(500, $"There was an error while updating the student with id: {studentId}. Please, try again later");
            }
        }

        [HttpDelete("{studentId}")]
        public async Task<ActionResult> DeleteStudent(int studentId)
        {
            try
            {
                await _service.DeleteStudentAsync(studentId);

                return NoContent();
            }
            catch(EntityDoesNotExistException ex)
            {
                _logger.LogWarning($"Deleting non existing student with id: {studentId}", ex.Message);
                    
                return BadRequest($"The student with id: {studentId} that you are trying to delete does not exist.");
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error while deleting student with id: {studentId}", ex.Message);

                return StatusCode(500, $"There was an error while deleting student with id: {studentId}. Please, try again later");
            }
        }

        #endregion

        [HttpGet("topgrades/{limit}")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudentsWithTopGrades(int limit)
        {
            try
            {
                var students = await _service.GetStudentsWithTopGradesAsync(limit);

                if(students is null)
                {
                    _logger.LogWarning("Retreiving non existing student with top grades.");

                    return NotFound();
                }

                return Ok(students);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error while retrieving students with top grades with limit: {limit}", ex.Message);

                return StatusCode(500, "There was an error while retrieving students. Please try again later");
            }
        }
    }
}