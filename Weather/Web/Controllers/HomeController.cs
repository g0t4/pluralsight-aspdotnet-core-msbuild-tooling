using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Client;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Weather(string city = "New York, NY")
        {
            var client = new OpenWeatherMapClient();

            var weather = await client.GetCurrentWeatherByCityAsync(city);
            if (weather == null)
            {
                return Content($"No weather for {city}");
            }

            var message = $"<h2>{city}</h2>"
                + $"<img src=\"{weather.FirstCondition?.IconUrl}\" /><br>"
                + $"Condition: {weather.FirstCondition?.Description}<br>"
                + $"Temp: {weather.Main?.Temperature}<br>"
                + $"Low: {weather.Main?.MinTemperature}<br>"
                + $"High: {weather.Main?.MaxTemperature}<br>"
                + $"Humidity: {weather.Main?.Humidity}%<br>";

            return Content(message, "text/html");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "World";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
