using Contoso.Domain.DTOs.Students;
using Contoso.Domain.Entities;

namespace Contoso.Domain.Interfaces.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
        Task<Student?> GetStudentById(int id);
        Task<Student?> CreateStudent(StudentForCreateDto newStudentDto);
        Task UpdateStudent(int studentId, StudentForUpdateDto studentToUpdateDto);
        Task DeleteStudent(int studentId);
        Task<bool> StudentExists(int id);
    }
}
