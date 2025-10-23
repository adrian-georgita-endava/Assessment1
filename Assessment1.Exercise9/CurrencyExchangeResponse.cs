using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assessment1.Exercise9
{
    public class CurrencyExchangeResponse
    {
        [JsonPropertyName("rates")]
        public Dictionary<string, Dictionary<string, double>> Rates { get; set; } = new();
    }
}
