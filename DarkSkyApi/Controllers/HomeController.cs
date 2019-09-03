using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DarkSkyApi.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace DarkSkyApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _weatherUrl = "https://api.darksky.net/forecast/0295265343a337fbc9539435e6be4c57/37.8267,-122.4233";
        private readonly IConfiguration _config;

        //constructor
        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IActionResult> Index()
        {
            //Access secret thing
            //var key = _config["ApiKeys:DarkSky"];
            var weather = await GetWeatherAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //this too
        private async Task<Weather> GetWeatherAsync()
        {
            var key = _config["ApiKeys:DarkSky"];
            var url = $"{_weatherUrl}{key}/36,-86";
            var client = new HttpClient();
            var response = await client.GetAsync(url);

            //computed property
            if (response.IsSuccessStatusCode)
            {
                var weather = await response.Content.ReadAsAsync<Weather>();
                return weather;
            }
            else
            {
                return null;
            }
        }

    }
}
