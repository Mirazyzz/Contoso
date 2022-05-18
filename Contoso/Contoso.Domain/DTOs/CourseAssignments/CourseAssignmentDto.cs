using Contoso.Domain.Entities;

namespace Contoso.Domain.DTOs.CourseAssignments
{
    public class CourseAssignmentDto
    {
        public int CourseAssignmentId { get; set; }
        public Instructor Instructor { get; set; }
        public Subject Subject { get; set; }
        public decimal SalaryPerHour { get; set; }
    }
}
