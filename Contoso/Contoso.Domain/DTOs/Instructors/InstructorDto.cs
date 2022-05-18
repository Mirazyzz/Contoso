using Contoso.Domain.DTOs.Departments;
using Contoso.Domain.Entities;
using Contoso.Domain.Enums;

namespace Contoso.Domain.DTOs.Instructors
{
    public class InstructorDto
    {
        public int InstructorId { get; set; }
        public string FullName { get; set; }
        public DateTime HireDate { get; set; }
        public Gender Gender { get; set; }

        public virtual DepartmentDto Department { get; set; }

        public ICollection<CourseAssignment> CourseAssignments { get; set; }

        public InstructorDto()
        {
            CourseAssignments = new List<CourseAssignment>();
        }
    }
}
