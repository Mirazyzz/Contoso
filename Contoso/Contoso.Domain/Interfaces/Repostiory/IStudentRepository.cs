using Contoso.Domain.Entities;

namespace Contoso.Domain.Interfaces.Repostiory
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        Task<List<Student>> FindAllStudentsAsync();
        Task<Student?> FindStudentByIdAsync(int id);
        void CreateStudent(Student newStudentDto);
        void DeleteStudent(Student studentToDeleteDto);
        void UpdateStudent(Student studentToUpdateDto);
    }
}
