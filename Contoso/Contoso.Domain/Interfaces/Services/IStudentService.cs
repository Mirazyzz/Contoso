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
        Task<IEnumerable<StudentDto>> GetStudentsWithTopGradesAsync(int limit);
        Task<StudentDto?> GetStudentByIdAsync(int id);
        Task<StudentDto?> CreateStudentAsync(StudentForCreateDto newStudentDto);
        Task UpdateStudentAsync(int studentId, StudentForUpdateDto studentToUpdateDto);
        Task DeleteStudentAsync(int studentId);
        Task<bool> StudentExistsAsync(int id);
    }
}
