namespace Contoso.Api.Models
{
    public class CityDto
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int NumberOfDepartments 
        { 
            get => Departments.Count; 
        }

        public ICollection<DepartmentDto> Departments { get; set; }

        public CityDto()
        {
            Departments = new List<DepartmentDto>();
        }
    }
}
