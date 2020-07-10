using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpTraining.Service.Model
{
    public class CurrentWeatherModel
    {
        [JsonProperty("temp_c")]
        public double TempC { get; set; }
    }
}
