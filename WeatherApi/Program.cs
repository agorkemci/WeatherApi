using Microsoft.EntityFrameworkCore;
using WeatherApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<WeatherDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));




var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    //Web uygulamasında scope = bir HTTP isteği. 
    //İstek gelince bir scope açılır, cevap dönünce kapanır.
    var WeatherDbContext = scope.ServiceProvider.GetRequiredService<WeatherDbContext>();
    //Dependecy injection scope undan context’i ister eğer ki servis kayıtlı değilse null yerine
    //hata fırlatır.
    DbSeeder.Seed(WeatherDbContext);
    //request sonrası işlem bitti ve scoped vasıtasıyla elde edilmiş olan context de siliniyor
}

//her scope için bir http request i oluşturulur scope içi işlem tamamlandığında da
//context bağlantısı açık kalma



 // Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
