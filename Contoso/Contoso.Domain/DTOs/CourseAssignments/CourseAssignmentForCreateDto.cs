namespace Contoso.Domain.DTOs.CourseAssignments
{
    public class CourseAssignmentForCreateDto
    {
        public int InstructorId { get; set; }
        public int SubjectId { get; set; }
        public decimal SalaryPerHour { get; set; }

        public CourseAssignmentForCreateDto(int instructorId, int subjectId, decimal salaryPerHour)
        {
            InstructorId = instructorId;
            SubjectId = subjectId;
            SalaryPerHour = salaryPerHour;
        }
    }
}
