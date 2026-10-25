using System.Net;
using WeatherWeb.Dtos;

namespace WeatherWeb.Services
{
    public class WeatherApiClient
    {
        private readonly HttpClient _httpClient;

        public WeatherApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<CityDto>> GetCitiesAsync()
        {
            //getfromjson üç işi birlikte yapar. Get isteği atar, gelen json verisi okur ve <list<citydto>> ya çevirir(deserialize).
            var cities = await _httpClient.GetFromJsonAsync<List<CityDto>>("api/cities");
            return cities ?? new List<CityDto>();
        }
        public async Task<CityForecastDto?> GetForecastAsync(int cityId) {
            //burda belli bir city'i döndüreceğimizden olmamaa ihtimalini de göz önüne almak için response üzerinden gidiyoruz.
            var response = await _httpClient.GetAsync($"api/cities/{cityId}/forecast");
            if (response.StatusCode == HttpStatusCode.NotFound)     
            {
                return null;
            }//gelen cevabın status codeu 404 ise null dönüyoruz
            if (!response.IsSuccessStatusCode)//2xx dışında bir status code varsa biz bunu bir exception olarak fırlatıyoruz. Örnek api 500 verdi
            {
                throw new HttpRequestException(
                    $"API hata döndü: {(int)response.StatusCode}", null, response.StatusCode);
            }
            return await response.Content.ReadFromJsonAsync<CityForecastDto?>();
            //apiden elde edilmiş response'ın content => body kısmını alıp dtoya çevirip return ediyoruz

        }
    }
}
