namespace Example;

public class WeatherAppBad
{
    private readonly IList<WeatherInfo> _weatherDb;

    public WeatherAppBad()
    {
        _weatherDb = new[]
        {
            new WeatherInfo("Tel Aviv", 30, "Israel"),
            new WeatherInfo("New York", 12),
            new WeatherInfo("London", 15),
            new WeatherInfo("Moscow", 2),
        };
    }

    public void PrintWeatherInfos()
    {
        foreach (var weatherInfo in GetWeatherInfos())
        {
            var countryText = weatherInfo.Country is not null
                ? $"in country {weatherInfo.Country}"
                : string.Empty;
            Console.WriteLine($"Temperature in {weatherInfo.City} {countryText} is {weatherInfo.Temperature}C");
        }
    }

    public void UpdateWeatherInfo(string city, double temperature)
    {
        _weatherDb.Single(x => x.City == city).Temperature = temperature;
    }

    private IEnumerable<WeatherInfo> GetWeatherInfos()
    {
        return _weatherDb;
    }

    public class WeatherInfo
    {
        public WeatherInfo(string city, double temperature, string? country = null)
        {
            City = city;
            Temperature = temperature;
            Country = country;
        }

        public string City { get; set; }
        public string? Country { get; set; }
        public double Temperature { get; set; }
    }
}