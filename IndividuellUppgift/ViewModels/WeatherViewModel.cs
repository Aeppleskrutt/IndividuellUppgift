using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IndividuellUppgift.ViewModels
{
    internal class WeatherViewModel
    {
        
        public static async Task<Models.Weather> GetWeatherAsync(string city)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "rBk1C+u8kcBQo5XewNYkZA==pYfOZIsiB0cbWOet");
            Models.Weather weather = null;
            HttpResponseMessage response = await client.GetAsync($"v1/weather?city={city}");
           
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                
                weather = JsonSerializer.Deserialize<Models.Weather>(responseString);
            }
            return weather;
        }
    }
}
