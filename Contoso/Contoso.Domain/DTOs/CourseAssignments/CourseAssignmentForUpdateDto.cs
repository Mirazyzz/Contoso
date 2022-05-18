namespace Contoso.Domain.DTOs.CourseAssignments
{
    public class CourseAssignmentForUpdateDto
    {
        public int CourseAssignmetnId { get; set; }
        public int InstructorId { get; set; }
        public int SubjectId { get; set; }
        public decimal SalaryPerHour { get; set; }
    }
}
