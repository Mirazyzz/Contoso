using Contoso.Domain.DTOs.Students;
using Contoso.Domain.Entities;
using Contoso.Domain.Interfaces.Repostiory;
using Contoso.Domain.Interfaces.Services;

namespace Contoso.Services
{
    public class StudentService : IStudentService
    {
        private readonly ICommonRepository _repository;

        public StudentService(ICommonRepository repository)
        {
            _repository = repository;
        }

        public void CreateStudent(StudentDto newStudentDto)
        {
            var errors = new List<string>();

            Student newStudentMapped = new Student(newStudentDto.FirstName, newStudentDto.LastName, newStudentDto.BirthDate, newStudentDto.Gender);
        }

        public void DeleteStudent(StudentDto studentToDeleteDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentDto>> GetStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(StudentDto studentToUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
