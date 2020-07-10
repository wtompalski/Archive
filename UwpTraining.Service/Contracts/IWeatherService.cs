using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpTraining.Service.Model;

namespace UwpTraining.Service.Contracts
{
    public interface IWeatherService
    {
        Task<WeatherInfoModel> GetWeatherAsync(string location);
    }
}
