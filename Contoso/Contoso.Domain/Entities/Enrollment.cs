using Contoso.Domain.Enums;

namespace Contoso.Domain.Entities
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public Grade Grade { get; set; }

        public virtual Student Student { get; set; }
        public int StudentId { get; set; }
        public virtual Subject Subject { get; set; }
        public int SubjectId { get; set; }

        public Enrollment(Student student, Subject subject)
        {
            Student = student;
            Subject = subject;
        }

        public Enrollment(Student student, Subject subject, Grade grade)
            : this(student, subject)
        {
            Grade = grade;
        }
    }
}
