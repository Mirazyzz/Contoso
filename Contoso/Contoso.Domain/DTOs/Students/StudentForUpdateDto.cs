using Contoso.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Domain.DTOs.Students
{
    public class StudentForUpdateDto
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Please provide first name for the student.")]
        [MaxLength(50, ErrorMessage = "First name can contain max of 50 characters.")]
        [MinLength(2, ErrorMessage = "First name should contain at least of 2 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide last name for the student.")]
        [MaxLength(75, ErrorMessage = "Last name can contain max of 75 characters.")]
        [MinLength(2, ErrorMessage = "Last name should contain at least of 2 characters")]
        public string LastName { get; set; }

        public Gender? Gender { get; set; }
        public DateTime? Birthdate { get; set; }

        public StudentForUpdateDto(string firstName, string lastName, Gender? gender, DateTime? birthdate)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender ?? Enums.Gender.Undisclosed;
            Birthdate = birthdate ?? DateTime.MinValue;
        }
    }
}
