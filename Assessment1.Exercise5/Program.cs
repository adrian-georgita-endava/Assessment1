using Assessment1.Exercise5;

Console.WriteLine("Welcome to the Temperature Comparator");

double temp;
Console.WriteLine("Please enter the temperature in Celsius");
Console.Write("Temperature: ");
while (!double.TryParse(Console.ReadLine(), out temp))
{
    Console.WriteLine("Please enter a valid temperature!");
    Console.Write("Temperature: ");
}

Console.Write("Enter the location: ");
string? location = Console.ReadLine();

while(String.IsNullOrEmpty(location)) {
    Console.WriteLine("Please enter a valid location!");
    Console.Write("Location: ");
    location = Console.ReadLine();
}

HttpClient httpClient = new HttpClient();

IGeoClient geoClient = new OpenMeteoGeoClient(httpClient);
GeoCoords? geoCoords = await geoClient.GetGeoCoordinatesAsync(location);

if(geoCoords == null)
{
    Console.WriteLine("Invalid Location");
    return;
}

IWeatherClient weatherClient = new OpenMeteoWeatherClient(httpClient);
double meanTempToday = await weatherClient.GetAverageTempAsync(geoCoords.Latitude, geoCoords.Longitude, DateOnly.FromDateTime(DateTime.Now));

double tempDiff = temp - meanTempToday;
if(tempDiff > 10)
{
    Console.WriteLine("Hot");
}
else if(tempDiff >= 0)
{
    Console.WriteLine("Warm");
}
else if(tempDiff < 0)
{
    Console.WriteLine("Cold");
}