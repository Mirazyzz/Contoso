using Contoso.Domain.Enums;

namespace Contoso.Domain.DTOs.Enrollments
{
    public class EnrollmentForCreateDto
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public Grade Grade { get; set; }

        public EnrollmentForCreateDto(int studentId, int subjectId, Grade? grade)
        {
            StudentId = studentId;
            SubjectId = subjectId;
            Grade = grade ?? Enums.Grade.F;
        }
    }
}
