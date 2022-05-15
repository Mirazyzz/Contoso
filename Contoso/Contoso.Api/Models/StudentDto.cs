using Contoso.Domain.Enums;

namespace Contoso.Api.Models
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public int NumberOfCourses
        {
            get => Enrollments.Count;
        }

        public int AverageGrade
        {
            get => Convert.ToInt32(Enrollments.Average(e => (int)e.Grade));
        }

        public ICollection<EnrollmentDto> Enrollments { get; set; }

        public StudentDto(string firstName, string lastName, DateTime? birthDate, Gender? gender)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate ?? DateTime.Now;
            Gender = gender ?? Gender.Undisclosed;
            Enrollments = new List<EnrollmentDto>();
        }
    }
}
