using Contoso.Domain.Entities;

namespace Contoso.Domain.Interfaces.Repostiory
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentByIdAsync(int id);
        void CreateStudent(Student newStudent);
        void DeleteStudent(Student studentToRemove);
        void UpdateStudent(Student studentToUpdate);
    }
}
