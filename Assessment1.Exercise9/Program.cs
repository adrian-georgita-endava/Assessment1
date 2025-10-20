using Assessment1.Exercise9;

Console.WriteLine("Welcome to the Currency Exchange");

Console.WriteLine("Please enter the currency amount in RON");
double amount;
Console.Write("Amount: ");
while(!double.TryParse(Console.ReadLine(), out amount) || amount < 0)
{
    Console.WriteLine("Please enter a valid value!");
    Console.Write("Amount: ");
}

HttpClient httpClient = new HttpClient();

DateOnly startDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-30);
DateOnly endDate = DateOnly.FromDateTime(DateTime.Now);

ICurrencyExchangerClient exchangeClient = new FrankfurterCurrencyExchangeClient(httpClient);
Dictionary<string, Dictionary<string, double>>? exchangeRates = await exchangeClient.GetConversionRates("RON", startDate, endDate);

if(exchangeRates != null)
{
    exchangeClient.Display(amount, exchangeRates);
}
else
{
    Console.WriteLine("Failed to get exchange rates!");
}