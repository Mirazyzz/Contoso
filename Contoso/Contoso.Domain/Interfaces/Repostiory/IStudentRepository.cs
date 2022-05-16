using Contoso.Domain.Entities;

namespace Contoso.Domain.Interfaces.Repostiory
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentByIdAsync(int id);
        void CreateStudent(Student newStudentDto);
        void DeleteStudent(Student studentToDeleteDto);
        void UpdateStudent(Student studentToUpdateDto);
    }
}
