using Contoso.Domain.Enums;

namespace Contoso.Domain.Entities
{
    public class Student : BaseEntity
    {
        public int StudentId { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }

        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Enrollments = new List<Enrollment>();
        }

        public Student(string firstName, string lastName, int departmentId, DateTime? birthDate, Gender? gender)
        {
            FirstName = firstName;
            LastName = lastName;
            DepartmentId = departmentId;
            BirthDate = birthDate;
            Gender = gender ?? Gender.Undisclosed;

            Enrollments = new List<Enrollment>();
        }   
    }
}
