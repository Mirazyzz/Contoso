namespace Contoso.Domain.Entities
{
    public class Department : BaseEntity
    {
        public int DepartmentId { get; private set; }
        public string DepartmentName { get; set; }

        public virtual City City { get; set; }
        public int CityId { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<Student> Students { get; set; }

        public Department(string departmentName, int cityId)
        {
            DepartmentName = departmentName;
            CityId = cityId;
            Instructors = new List<Instructor>();
            Students = new List<Student>();
        }
    }
}
