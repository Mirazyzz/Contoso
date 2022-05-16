using Contoso.Domain.Entities;
using Contoso.Domain.Interfaces.Repostiory;
using Contoso.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(ContosoDbContext context)
            : base(context)
        {
        }

        public void CreateStudent(Student newStudent)
        {
            Create(newStudent);
        }

        public void DeleteStudent(Student studentToRemove)
        {
            Delete(studentToRemove);
        }

        public Task<List<Student>> GetAllStudents()
        {
            return FindAll().ToListAsync();
        }

        public Task<Student> GetStudentByIdAsync(int id)
        {
            return FindById(id);
        }

        public void UpdateStudent(Student studentToUpdate)
        {
            Update(studentToUpdate);
        }
    }
}
