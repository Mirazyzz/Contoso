using Contoso.Domain.DTOs.Departments;

namespace Contoso.Domain.DTOs.Cities
{
    public class CityDto
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<DepartmentDto> Departments { get; set; }

        public CityDto(string cityName)
        {
            CityName = cityName;
            Departments = new List<DepartmentDto>();
        }
    }
}
