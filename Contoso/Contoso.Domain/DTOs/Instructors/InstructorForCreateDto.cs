using Contoso.Domain.Enums;

namespace Contoso.Domain.DTOs.Instructors
{
    public class InstructorForCreateDto
    {
        public string FullName { get; set; }
        public DateTime HireDate { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }

        public InstructorForCreateDto(string fullName, int departmentId, DateTime? hireDate, Gender? gender)
        {
            FullName = fullName;
            HireDate = hireDate ?? DateTime.MinValue;
            Gender = gender ?? Gender.Undisclosed;
            DepartmentId = departmentId;
        }
    }
}
