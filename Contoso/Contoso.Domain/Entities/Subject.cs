namespace Contoso.Domain.Entities
{
    public class Subject
    {
        public int SubjectId { get; private set; }
        public string SubjectName { get; set; }
        public decimal Fee { get; set; }
        public int? TotalHours { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public Subject(string subjectName)
        {
            SubjectName = subjectName;
            Enrollments = new List<Enrollment>();
        }
    }
}
