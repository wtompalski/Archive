using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UwpTraining.Service.Contracts;
using UwpTraining.Service.Model;

namespace UwpTraining.Service
{
    public class WeatherService : IWeatherService
    {
        private string weatherServiceUrl = "http://api.weatherapi.com/v1/current.json?key=e5bde0bca9784e54a0755717201305&q=";
        
        public async Task<WeatherInfoModel> GetWeatherAsync(string location)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(new Uri(weatherServiceUrl + location));

                return JsonConvert.DeserializeObject<WeatherInfoModel>(response);
            }
        }
    }
}
