using System.ComponentModel.DataAnnotations;

namespace Contoso.Domain.Entities
{
    public class Department : BaseEntity
    {
        [Key]
        public int DepartmentId { get; private set; }
        public string DepartmentName { get; set; }

        public City? City { get; set; }
        public int CityId { get; set; }

        public Department(string departmentName)
        {
            DepartmentName = departmentName;
        }
    }
}
