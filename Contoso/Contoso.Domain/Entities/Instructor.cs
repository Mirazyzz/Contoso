using Contoso.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Domain.Entities
{
    public class Instructor : BaseEntity
    {
        [Key]
        public int InstructorId { get; private set; }
        public string FullName { get; set; }
        public DateTime? HireDate { get; set; }
        public Gender? Gender { get; set; }

        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }

        public virtual ICollection<CourseAssignment> CourseAssignments { get; set; }

        public Instructor()
        {
            CourseAssignments = new List<CourseAssignment>();
            HireDate = DateTime.Now;
            Gender = Enums.Gender.Undisclosed;
        }
    }
}
