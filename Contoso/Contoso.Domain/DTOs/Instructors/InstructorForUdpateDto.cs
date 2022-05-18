using Contoso.Domain.Enums;

namespace Contoso.Domain.DTOs.Instructors
{
    public class InstructorForUpdateDto
    {
        public int InstructorId { get; set; }
        public string FullName { get; set; }
        public DateTime HireDate { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
    }
}
