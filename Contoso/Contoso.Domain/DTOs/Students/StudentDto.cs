using Contoso.Domain.DTOs.Enrollments;
using Contoso.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Domain.DTOs.Students
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public int NumberOfCourses
        {
            get => Enrollments.Count;
        }

        public int AverageGrade
        {
            get
            {
                if(Enrollments.Count > 0)
                {
                   return Convert.ToInt32(Enrollments.Average(e => (int)e.Grade));
                }

                return 0;
            }
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
