using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assessment1.Exercise5
{
    public sealed class GeoResponse
    {
        [JsonPropertyName("results")]
        public List<GeoCoords>? Results { get; set; }
    }
}
