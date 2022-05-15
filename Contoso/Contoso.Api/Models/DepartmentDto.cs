namespace Contoso.Api.Models
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public CityDto City { get; set; }

        public DepartmentDto(string departmentName)
        {
            DepartmentName = departmentName;
            City = new CityDto();
        }
    }
}
