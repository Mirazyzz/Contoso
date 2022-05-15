using System.ComponentModel.DataAnnotations;

namespace Contoso.Domain.Entities
{
    public class City : BaseEntity
    {
        [Key]
        public int CityId { get; private set; }
        public string CityName { get; set; }

        public virtual ICollection<Department> Departments { get; set; }

        public City(string cityName)
        {
            CityName = cityName;
            Departments = new List<Department>();
        }
    }
}
