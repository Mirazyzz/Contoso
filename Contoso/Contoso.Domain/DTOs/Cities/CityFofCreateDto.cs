namespace Contoso.Domain.DTOs.Cities
{
    public class CityFofCreateDto
    {
        public string CityName { get; set; }

        public CityFofCreateDto(string cityName)
        {
            CityName = cityName;
        }
    }
}
