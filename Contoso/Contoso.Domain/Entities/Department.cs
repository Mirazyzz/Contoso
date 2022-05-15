using System.ComponentModel.DataAnnotations;

namespace Contoso.Domain.Entities
{
    public class Department : BaseEntity
    {
        [Key]
        public int DepartmentId { get; private set; }
        public string DepartmentName { get; set; }

        public virtual City City { get; set; }
        public int CityId { get; set; }

        public Department(string departmentName, City city)
        {
            DepartmentName = departmentName;
            City = city;
        }
    }
}
