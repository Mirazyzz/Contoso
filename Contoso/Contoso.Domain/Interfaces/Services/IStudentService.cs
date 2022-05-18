using Contoso.Domain.DTOs.Students;
using Contoso.Domain.Entities;
using Contoso.Domain.Enums;

namespace Contoso.Domain.Interfaces.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync(string? name, string? searchQuery, 
                                                          int? age, int? cityId, int? departmentId, 
                                                          Gender? gender, string? orderBy);
        Task<Student?> GetStudentById(int id);
        Task<Student?> CreateStudent(StudentForCreateDto newStudentDto);
        Task UpdateStudent(int studentId, StudentForUpdateDto studentToUpdateDto);
        Task DeleteStudent(int studentId);
        Task<bool> StudentExists(int id);
    }
}
