using WeatherApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherApi.Data
{
    public class DbSeeder
    {
        public static void Seed(WeatherDbContext weatherDbContext) 
        {
            if (weatherDbContext.Cities.Any())
            {
                return;
            }
            var summaries = new[]{
                "Sunny",
                "Partly cloudy",
                "Cloudy",
                "Rainy",
                "Windy"
            };

            var random = new Random();
            var today = DateOnly.FromDateTime(DateTime.Today);

            var cities = new List<City>
            {
                new() { Name = "Ankara", Country = "Türkiye" },
                new() { Name = "İstanbul", Country = "Türkiye" },
                new() { Name = "İzmir", Country = "Türkiye" }
            };
            foreach (var c in cities)
            {
                for (int i = 0; i < 7; i++) {
                    var min = random.Next(5, 15);
                    c.Forecasts.Add(new DailyForecast
                    {
                        Date = today.AddDays(i),
                        TemperatureMinC = min,
                        TemperatureMaxC = min + random.Next(4, 11),
                        Summary = summaries[random.Next(summaries.Length)]
                    });
                }
            }
            weatherDbContext.Cities.AddRange(cities);
            weatherDbContext.SaveChanges();
        }
    }
}
