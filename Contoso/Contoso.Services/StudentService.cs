using AutoMapper;
using Contoso.Domain.DTOs.Students;
using Contoso.Domain.Entities;
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

        public async void CreateStudent(StudentDto newStudentDto)
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
        }

        public void DeleteStudent(StudentDto studentToDeleteDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsAsync()
        {
            var students = await _repository.Student.GetAllStudents();

            if(students == null)
            {
                throw new Exception("No students found.");
            }

            var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);

            return studentDtos;
        }

        public void UpdateStudent(StudentDto studentToUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
