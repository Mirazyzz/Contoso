using AutoMapper;
using Contoso.Domain.DTOs.Students;
using Contoso.Domain.Entities;
using Contoso.Domain.Enums;
using Contoso.Domain.Exceptions;
using Contoso.Domain.Interfaces.Repostiory;
using Contoso.Domain.Interfaces.Services;

namespace Contoso.Services
{
    public class StudentService : IStudentService
    {
        private readonly ICommonRepository _repository;
        private readonly IMapper _mapper;

        public StudentService(ICommonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync(string? name, string? searchQuery, 
                                                                       int? age, int? cityId, int? departmentId, 
                                                                       Gender? gender, string? orderBy)
        {
            var students = await _repository.Student.FindAllStudentsAsync(name, searchQuery, age, cityId, departmentId, gender, orderBy);

            if (students == null)
            {
                throw new Exception("No students found.");
            }

            var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);

            return studentDtos;
        }

        public async Task<Student?> GetStudentById(int studentId)
        {
            var student = await _repository.Student.FindStudentByIdAsync(studentId);

            if(student is null)
            {
                throw new NotFoundDbException();
            }

            return student;
        }

        public async Task<Student?> CreateStudent(StudentForCreateDto newStudentDto)
        {
            var errors = new List<string>();

            var student = _mapper.Map<Student>(newStudentDto);

            if(student == null)
            {
                throw new ContosoException("There was an errr mapping dto to entity type");
            }

            try
            {
                // Create a new student
                _repository.Student.Create(student);
                // save changes to db
                await _repository.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new CreateDbException("There was an error adding a new student", ex.Message);
            }

            return student;
        }

        public async Task DeleteStudent(int studentId)
        {
            var student = await _repository.Student.FindStudentByIdAsync(studentId);

            if (student is null)
            {
                throw new NotFoundDbException();
            }

            try
            {
                _repository.Student.Delete(student);

                await _repository.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"There was an error while deleting student with id: {studentId} from db. {ex.Message}");
            }
        }

        public async Task UpdateStudent(int studentId, StudentForUpdateDto studentToUpdateDto)
        {
            if(studentToUpdateDto is null)
            {
                throw new Exception("Student to update cannot be null");
            }

            var studentEntity = await _repository.Student.FindById(studentId);

            if (studentEntity is null)
            {
                throw new NotFoundDbException();
            }

            var errorsList = new List<string>();

            try
            {
                studentEntity = _mapper.Map(studentToUpdateDto, studentEntity);

                if (studentEntity is null)
                {
                    throw new Exception("Could not map StudentForUpdateDto to Student entity");
                }

                _repository.Student.Update(studentEntity);

                await _repository.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"There was an error updating student. {ex.Message}");
            }
        }

        public async Task<bool> StudentExists(int id)
        {
            return await _repository.Student.FindById(id) != null;
        }
    }
}
