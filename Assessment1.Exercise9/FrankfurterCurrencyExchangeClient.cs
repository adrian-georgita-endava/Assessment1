using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise9
{
    public class FrankfurterCurrencyExchangeClient : ICurrencyExchangerClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://api.frankfurter.app/";

        public FrankfurterCurrencyExchangeClient(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<Dictionary<string, Dictionary<string, double>>?> GetConversionRates(string baseCurrency, DateOnly startDate, DateOnly endDate)
        {
            string url = $"{_baseUrl}{startDate.ToString("yyyy-MM-dd")}..{endDate.ToString("yyyy-MM-dd")}?from={baseCurrency}&to=EUR,USD,GBP";
            Dictionary<string, Dictionary<string, double>>? exchangeResponse = null;
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<CurrencyExchangeResponse>();
                if (content?.Rates?.Count > 0)
                {
                    exchangeResponse = content.Rates;
                }
            }

            return exchangeResponse;
        }

        public void Display(double baseValue, Dictionary<string, Dictionary<string, double>> conversionRates)
        {
            Console.WriteLine("   Date    |  RON |  EUR | USD  | GBP");
            foreach (var key in conversionRates.Keys)
            {
                Console.WriteLine($"{key} | {baseValue:F2} | {baseValue * conversionRates[key]["EUR"]:F2} | {baseValue * conversionRates[key]["USD"]:F2} | {baseValue * conversionRates[key]["GBP"]:F2}");
            }
        }
    }
}
