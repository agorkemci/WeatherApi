namespace WeatherApi.Models
{
    public class DailyForecast
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int TemperatureMinC { get; set; }
        public int TemperatureMaxC { get; set; }
        public string Summary { get; set; } = string.Empty;

        public int CityId { get; set; }
        public City City { get; set; } = null!;
    }
}
