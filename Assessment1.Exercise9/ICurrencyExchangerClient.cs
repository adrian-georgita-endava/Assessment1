using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise9
{
    public interface ICurrencyExchangerClient
    {
        public Task<Dictionary<string, Dictionary<string, double>>?> GetConversionRates(string baseCurrency, DateOnly startDate, DateOnly endDate);

        public void Display(double baseValue, Dictionary<string, Dictionary<string, double>> conversionRates);
    }
}
