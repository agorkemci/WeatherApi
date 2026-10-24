using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherApi.Data;
using WeatherApi.Dtos;

namespace WeatherApi.Controllers
{
    [ApiController]//bu sınıfı bir API Controller yapar
    //Controller base ile view support giderr
    [Route("api/[controller]")]//api/"controllerdan kalan ad ne ise o
    //örnek CitiesController ==> api/cities
    public class CitiesController : ControllerBase
    {
        //salt okunur referans aldığı değer bir daha değiştirilemez
        private readonly WeatherDbContext _weatherDbContext;
        public CitiesController(WeatherDbContext weatherDbContext)
        {
            _weatherDbContext = weatherDbContext;
        }
        [HttpGet("{id}/forecast")]
        public async Task<ActionResult<CityForecastDto>> GetForecast(int id)
        {
            var city = await _weatherDbContext
                .Cities.AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new CityForecastDto
                {
                    CityId = c.Id,
                    CityName = c.Name,
                    Country = c.Country,
                    Forecasts = c.Forecasts.OrderBy(f => f.Date).Select(f => new DailyForecastDto
                    {
                        Date = f.Date,
                        TemperatureMaxC = f.TemperatureMaxC,
                        TemperatureMinC = f.TemperatureMinC,
                        Summary = f.Summary
                    })
                    .ToList()
                }).FirstOrDefaultAsync();
            if (city == null)
                return NotFound();
            return Ok(city);
        }
    }
}
