namespace Contoso.Domain.DTOs.Departments
{
    public class DepartmentForCreateDto
    {
        public string DepartmentName { get; set; }
        public int CityId { get; set; }

        public DepartmentForCreateDto(string departmentName, int cityId)
        {
            DepartmentName = departmentName;
            CityId = cityId;
        }
    }
}
