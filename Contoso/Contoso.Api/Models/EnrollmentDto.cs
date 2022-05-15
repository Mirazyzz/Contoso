using Contoso.Domain.Enums;

namespace Contoso.Api.Models
{
    public class EnrollmentDto
    {
        public int Id { get; set; }
        public StudentDto Student { get; set; }
        public SubjectDto Subject { get; set; }
        public Grade Grade { get; set; }
    }
}
