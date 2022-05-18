namespace Contoso.Domain.DTOs.Cities
{
    public class CityForUpdateDto
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public CityForUpdateDto(string cityName)
        {
            CityName = cityName;
        }
    }
}
