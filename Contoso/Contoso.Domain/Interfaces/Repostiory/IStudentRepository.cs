using Contoso.Domain.Entities;
using Contoso.Domain.Enums;

namespace Contoso.Domain.Interfaces.Repostiory
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        Task<List<Student>> FindAllStudentsAsync(string? name, string? searchQuery, 
                                                 int? age, int? cityId,  int? departmentId, 
                                                 Gender? gender,  string? orderBy);
        Task<List<Student>> FindStudentsWithTopGrades(int limit);
        Task<Student?> FindStudentByIdAsync(int id);
        void CreateStudent(Student newStudentDto);
        void DeleteStudent(Student studentToDeleteDto);
        void UpdateStudent(Student studentToUpdateDto);
    }
}
