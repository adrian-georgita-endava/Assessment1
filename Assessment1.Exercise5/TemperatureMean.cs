using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assessment1.Exercise5
{
    public class TemperatureMean
    {
        [JsonPropertyName("temperature_2m_mean")]
        public List<double> Temperature { get; set; } = new();
    }
}
