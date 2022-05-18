using Contoso.Domain.DTOs.Cities;

namespace Contoso.Domain.DTOs.Departments
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual CityDto City { get; set; }

        public DepartmentDto(string departmentName)
        {
            DepartmentName = departmentName;
        }
    }
}
