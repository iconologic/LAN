using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// Summary description for WeatherService
/// </summary>
public class WeatherService
{
    private const string QueryFormat = "http://api.openweathermap.org/data/2.5/weather?q={0}&units=imperial";

    private static readonly IDictionary<string, CachedItem<Weather>> WeatherCache = new Dictionary<string, CachedItem<Weather>>();
  
    public static Weather GetWeather(string location)
    {
        if (WeatherCache.ContainsKey(location) && WeatherCache[location].IsExpired == false)
            return WeatherCache[location].Item;

        var client = new HttpClient();
        var task = client.GetStringAsync(string.Format(QueryFormat, HttpUtility.UrlEncode(location)));
        task.Wait();

        var weather = JsonConvert.DeserializeObject<Weather>(task.Result);
        var cachedItem = new CachedItem<Weather>(weather, DateTime.Now.AddMinutes(10));
        WeatherCache[location] = cachedItem;
        return weather;
    }
}

public class Weather
{
    public decimal Temperature
    {
        get { return Main.Temp; }
    }

    [JsonProperty("main")]
    private MainProp Main { get; set; }

    private class MainProp
    {
        [JsonProperty("temp")]
        public decimal Temp { get; set; }
    }
}