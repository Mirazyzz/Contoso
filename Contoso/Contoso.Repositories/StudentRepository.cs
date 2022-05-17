using Contoso.Domain.Entities;
using Contoso.Domain.Enums;
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

        public async Task<List<Student>> FindAllStudentsAsync(string? name, string? searchQuery,
                                                                                int? age, int? cityId,
                                                                                int? departmentId, Gender? gender)
        {
            IQueryable<Student> students = _context.Students.Include(s => s.Department.City).AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name))
            {
                students = students.Where(s => s.FirstName.Equals(name) || s.LastName.Equals(name));
            }

            if (!string.IsNullOrEmpty(searchQuery) && !string.IsNullOrWhiteSpace(searchQuery))
            {
                students = students.Where(s => s.FirstName.Contains(searchQuery) || s.LastName.Contains(searchQuery));
            }

            if (age.HasValue)
            {
                students = students.Where(s => s.BirthDate.HasValue && 
                                            ((DateTime.Now.Year - s.BirthDate.Value.Year).Equals(age)));
            }

            if (departmentId.HasValue)
            {
                students = students.Where(s => s.DepartmentId.Equals(departmentId));
            }

            if (cityId.HasValue)
            {
                students = students.Where(s => s.Department.CityId.Equals(cityId));
            }

            if (gender.HasValue)
            {
                students = students.Where(s => s.Gender.Equals(gender));
            }

            return await students.ToListAsync();
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
