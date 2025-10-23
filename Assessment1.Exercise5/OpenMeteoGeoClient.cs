using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise5
{
    public class OpenMeteoGeoClient : IGeoClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://geocoding-api.open-meteo.com/";
        public OpenMeteoGeoClient(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<GeoCoords?> GetGeoCoordinatesAsync(string location)
        {
            string url = $"{_baseUrl}v1/search?name={location}&count=1";
            GeoCoords? geoCoords = null;
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<GeoResponse>();
                if (content?.Results?.Count > 0)
                {
                    geoCoords = content.Results[0];
                }
            }

            return geoCoords;
        }

    }
}
