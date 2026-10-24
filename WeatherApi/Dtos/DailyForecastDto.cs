namespace WeatherApi.Dtos
{
    public class DailyForecastDto
    {
        public DateOnly Date { get; set; }
        public int TemperatureMinC { get; set; }
        public int TemperatureMaxC { get; set; }
        public string Summary { get; set; } = string.Empty;

    }
}
