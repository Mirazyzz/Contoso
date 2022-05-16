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

        public Task<List<Student>> FindAllStudentsAsync()
        {
            return FindAll().ToListAsync();
        }

        public async Task<Student?> FindStudentByIdAsync(int id)
        {
            return await FindById(id);
        }

        public void CreateStudent(Student newStudent)
        {
            Create(newStudent);
        }

        public void DeleteStudent(Student studentToRemove)
        {
            Delete(studentToRemove);
        }

        public void UpdateStudent(Student studentToUpdate)
        {
            Update(studentToUpdate);
        }
    }
}
