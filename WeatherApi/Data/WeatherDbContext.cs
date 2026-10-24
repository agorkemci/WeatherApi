using Microsoft.EntityFrameworkCore;
using WeatherApi.Models;

namespace WeatherApi.Data
{
    public class WeatherDbContext:DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        { }
        public DbSet<City> Cities => Set<City>();
        public DbSet<DailyForecast> DailyForecasts => Set<DailyForecast>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(c => c.Name).HasMaxLength(30);
                entity.Property(c => c.Country).HasMaxLength(30);
            });
            modelBuilder.Entity<DailyForecast>(entity =>
            {
                entity.Property(f=>f.Summary).HasMaxLength(200);
            });
        }

    }
}
