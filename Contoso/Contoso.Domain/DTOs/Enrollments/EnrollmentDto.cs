using Contoso.Domain.DTOs.Students;
using Contoso.Domain.Enums;

namespace Contoso.Domain.DTOs.Enrollments
{
    public class EnrollmentDto
    {
        public int Id { get; set; }
        public StudentDto Student { get; set; }
        public SubjectDto Subject { get; set; }
        public Grade Grade { get; set; }
    }
}
