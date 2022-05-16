using Contoso.Domain.DTOs.Students;

namespace Contoso.Domain.Interfaces.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetStudentsAsync();
        void CreateStudent(StudentDto newStudentDto);
        void UpdateStudent(StudentDto studentToUpdateDto);
        void DeleteStudent(StudentDto studentToDeleteDto);
    }
}
