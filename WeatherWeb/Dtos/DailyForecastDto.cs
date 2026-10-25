namespace WeatherWeb.Dtos
{
    public class DailyForecastDto
    {
        public DateOnly Date { get; set; }
        public int TemperatureMinC { get; set; }
        public int TemperatureMaxC { get; set; }
        public string Summary { get; set; } = string.Empty;
    }
    //burda tanımlanan properylerin api projesindeki gönderilen
    //dto lar ile eşleşmesini sağlamak için aynı isimde tanımlamak
    //gerekiyor ancak upperlowercase önemli değil
}
