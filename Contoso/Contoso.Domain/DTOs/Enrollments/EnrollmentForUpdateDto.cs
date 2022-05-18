using Contoso.Domain.Enums;

namespace Contoso.Domain.DTOs.Enrollments
{
    public class EnrollmentForUpdateDto
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public Grade? Grade { get; set; }
    }
}
