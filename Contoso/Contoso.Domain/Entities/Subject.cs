namespace Contoso.Domain.Entities
{
    public class Subject
    {
        public int SubjectId { get; private set; }
        public string SubjectName { get; set; }
        public decimal Fee { get; set; }
        public int? TotalHours { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<CourseAssignment> CourseAssignments { get; set; }

        public Subject(string subjectName, decimal fee, int? totalHours)
        {
            SubjectName = subjectName;
            Fee = fee;
            TotalHours = totalHours ?? 40;
            Enrollments = new List<Enrollment>();
            CourseAssignments = new List<CourseAssignment>();
        }
    }
}
