namespace Example;

public class WeatherAppGood
{
    private readonly IWeatherReadonlyDb _readonlyDb;
    private readonly IWeatherDbUpdater _dbUpdater;

    public WeatherAppGood(IWeatherReadonlyDb readonlyDb, IWeatherDbUpdater dbUpdater)
    {
        _readonlyDb = readonlyDb;
        _dbUpdater = dbUpdater;
    }

    public void PrintWeatherInfos()
    {
        foreach (var weatherInfo in _readonlyDb.GetWeatherInfos())
        {
            Console.WriteLine(weatherInfo);
        }
    }

    public void UpdateWeatherInfo(string city, double temperature)
    {
        _dbUpdater.UpdateWeatherInfo(city, temperature);
    }

    public interface IWeatherReadonlyDb
    {
        IEnumerable<WeatherInfo> GetWeatherInfos();
    }

    public interface IWeatherDbUpdater
    {
        void UpdateWeatherInfo(string city, double temperature);
    }

    public class WeatherDb : IWeatherReadonlyDb, IWeatherDbUpdater
    {
        private readonly IList<WeatherInfo> _weatherInfos;

        public WeatherDb()
        {
            _weatherInfos = new[]
            {
                new WeatherInfo(new CountryWeatherLocation("Tel Aviv", "Israel"), 30),
                new WeatherInfo(new WeatherLocation("New York"), 12),
                new WeatherInfo(new WeatherLocation("London"), 15),
                new WeatherInfo(new WeatherLocation("Moscow"), 2),
            };
        }

        public IEnumerable<WeatherInfo> GetWeatherInfos()
        {
            return _weatherInfos;
        }

        public void UpdateWeatherInfo(string city, double temperature)
        {
            _weatherInfos.Single(x => x.Location.City == city).Temperature = temperature;
        }
    }

    public class WeatherInfo
    {
        public WeatherInfo(WeatherLocation location, double temperature)
        {
            Location = location;
            Temperature = temperature;
        }

        public WeatherLocation Location { get; set; }
        public double Temperature { get; set; }

        public override string ToString()
        {
            return $"Temperature in {Location} is {Temperature}C";
        }
    }

    public record WeatherLocation(string City)
    {
        public override string ToString()
        {
            return City;
        }
    }

    public record CountryWeatherLocation(string City, string Country) : WeatherLocation(City)
    {
        public override string ToString()
        {
            return $"{City} in country {Country}";
        }
    }
}