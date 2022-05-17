namespace Contoso.Domain.Entities
{
    public class CourseAssignment : BaseEntity
    {
        public int CourseAssignmentId { get; set; }
        public decimal? SalaryPerHour { get; set; }

        public virtual Instructor Instructor { get; set; }
        public int InstructorId { get; set; }
        public virtual Subject Subject { get; set; }
        public int SubjectId { get; set; }

        public CourseAssignment(int instructorId, int subjectId)
        {
            InstructorId = instructorId;
            SubjectId = subjectId;
        }
    }
}
