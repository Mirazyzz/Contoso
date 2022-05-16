using Contoso.Domain.DTOs.Enrollments;
using Contoso.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Domain.DTOs.Students
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
