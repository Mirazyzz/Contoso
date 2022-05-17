using Contoso.Domain.Enums;

namespace Contoso.Domain.Entities
{
    public class Enrollment
    {
        public int EnrollmentId { get; private set; }
        public Grade? Grade { get; set; }

        public virtual Student Student { get; set; }
        public int StudentId { get; set; }
        public virtual Subject Subject { get; set; }
        public int SubjectId { get; set; }

        public Enrollment(int studentId, int subjectId)
        {
            StudentId = studentId;
            SubjectId = subjectId;
        }
    }
}
