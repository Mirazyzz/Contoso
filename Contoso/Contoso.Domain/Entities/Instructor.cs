using Contoso.Domain.Enums;

namespace Contoso.Domain.Entities
{
    public class Instructor : BaseEntity
    {
        public int InstructorId { get; private set; }
        public string FullName { get; set; }
        public DateTime? HireDate { get; set; }
        public Gender? Gender { get; set; }

        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }

        public virtual ICollection<CourseAssignment> CourseAssignments { get; set; }

        public Instructor(string fullName, DateTime? hireDate, Gender? gender, int departmentId)
        {
            CourseAssignments = new List<CourseAssignment>();
            HireDate = hireDate ?? DateTime.Now;
            FullName = fullName;
            Gender = gender ?? Enums.Gender.Undisclosed;
            DepartmentId = departmentId;
        }
    }
}
