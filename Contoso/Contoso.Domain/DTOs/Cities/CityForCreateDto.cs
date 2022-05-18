namespace Contoso.Domain.DTOs.Cities
{
    public class CityForCreateDto
    {
        public string CityName { get; set; }

        public CityForCreateDto(string cityName)
        {
            CityName = cityName;
        }
    }
}
