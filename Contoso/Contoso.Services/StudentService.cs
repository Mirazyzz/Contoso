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
            try
            {
                var students = await _repository.Student.FindAllStudentsAsync(name, searchQuery, age, cityId, departmentId, gender, orderBy);

                if (students == null)
                {
                    throw new Exception("No students found.");
                }

                var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);

                if(studentDtos is null)
                {
                    throw new Exception("Could not map Student entites list to Student DTOs");
                }

                return studentDtos;
            }
            catch(Exception ex)
            {
                throw new Exception($"There was an error while retrieving students. {ex.Message}");
            }
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsWithTopGradesAsync(int limit)
        {
            try
            {
                var students = await _repository.Student.FindStudentsWithTopGrades(limit);

                if (students == null)
                {
                    throw new Exception("No students found.");
                }

                var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);

                if(studentDtos is null)
                {
                    throw new Exception("Could not map Student entities list to Student DTOs list.");
                }

                return studentDtos;
            }
            catch(Exception ex)
            {
                throw new Exception("There was an error retrieving students with top grades.", ex);
            }
        }

        public async Task<StudentDto?> GetStudentByIdAsync(int studentId)
        {
            try
            {
                var student = await _repository.Student.FindStudentByIdAsync(studentId);

                if (student is null)
                {
                    throw new EntityDoesNotExistException($"Student with id: {studentId} does not exist.");
                }

                var studentDto = _mapper.Map<StudentDto>(student);

                if (studentDto is null)
                {
                    throw new Exception("Cannot map Student entity to Student DTO.");
                }

                return studentDto;
            }
            catch(Exception ex)
            {
                throw new Exception($"There was an error while retrieving student with id: {studentId}", ex);
            }
        }

        public async Task<StudentDto?> CreateStudentAsync(StudentForCreateDto newStudentDto)
        {
            try
            {
                // Map to student entity
                var student = _mapper.Map<Student>(newStudentDto);

                if (student == null)
                {
                    throw new ContosoException("Could not map StudentForCreateDTO to student entity.");
                }

                var createdStudent = _repository.Student.Create(student);
                await _repository.SaveChangesAsync();

                // Map newly created student back to DTO
                var studentDto = _mapper.Map<StudentDto>(createdStudent);

                return studentDto;
            }
            catch(Exception ex)
            {
                throw new Exception("There was an error adding a new student.", ex);
            }
        }

        public async Task UpdateStudentAsync(int studentId, StudentForUpdateDto studentToUpdateDto)
        {
            var studentEntity = await _repository.Student.FindById(studentId);

            if(studentEntity is null)
            {
                throw new EntityDoesNotExistException($"Student with id: {studentId} does not exist.");
            }

            try
            {
                studentEntity = _mapper.Map(studentToUpdateDto, studentEntity);

                if (studentEntity is null)
                {
                    throw new Exception("Could not map StudentForUpdateDTO to Student entity.");
                }

                _repository.Student.Update(studentEntity);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error updating student.", ex);
            }
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            var student = await _repository.Student.FindStudentByIdAsync(studentId);

            if (student is null)
            {
                throw new EntityDoesNotExistException($"Student with id: {studentId} does not exist.");
            }

            try
            {
                _repository.Student.DeleteStudent(student);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error while deleting student with id: {studentId}.", ex);
            }
        }

        public async Task<bool> StudentExistsAsync(int id)
        {
            return await _repository.Student.FindById(id) != null;
        }
    }
}
