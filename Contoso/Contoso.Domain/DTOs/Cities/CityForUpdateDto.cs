using System.ComponentModel.DataAnnotations;

namespace Contoso.Domain.DTOs.Cities
{
    public class CityForUpdateDto
    {
        public int CityId { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "The city name should not exceed 150 characters.")]
        [MinLength(2, ErrorMessage = "The city name should have at least 2 characters.")]
        public string CityName { get; set; }

        public CityForUpdateDto(string cityName)
        {
            CityName = cityName;
        }
    }
}
