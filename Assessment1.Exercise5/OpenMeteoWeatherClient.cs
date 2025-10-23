using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise5
{
    public class OpenMeteoWeatherClient : IWeatherClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://api.open-meteo.com/";

        public OpenMeteoWeatherClient(HttpClient httpClient) => _httpClient = httpClient;

        // https://api.open-meteo.com/v1/forecast?latitude=51.5&longitude=-0.12&daily=temperature_2m_mean&timezone=auto&start_date=2025-10-20&end_date=2025-10-20
        public async Task<double> GetAverageTempAsync(double lat, double lon, DateOnly date)
        {
            string queryDate = date.ToString("yyyy-MM-dd");
            string url = $"{_baseUrl}v1/forecast?latitude={lat}&longitude={lon}&daily=temperature_2m_mean&timezone=auto&start_date={queryDate}&end_date={queryDate}";
            double meanTemp = 0;
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<WeatherResponse>();
                if (content?.Daily.Temperature?.Count > 0)
                {
                    meanTemp = content.Daily.Temperature[0];
                }
            }

            return meanTemp;
        }
    }
}
