namespace WeatherWeb.Dtos
{
    public class CityForecastDto
    {
        public int CityId { get; set; }
        public string CityName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public List<DailyForecastDto> Forecasts { get; set; } = new List<DailyForecastDto>();
    }
}
