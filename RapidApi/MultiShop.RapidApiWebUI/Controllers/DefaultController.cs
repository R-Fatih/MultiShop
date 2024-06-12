using Microsoft.AspNetCore.Mvc;
using MultiShop.RapidApiWebUI.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MultiShop.RapidApiWebUI.Controllers
{
	public class DefaultController : Controller
	{
		public async Task< IActionResult> WeatherDetail()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://the-weather-api.p.rapidapi.com/api/weather/ankara"),
				Headers =
	{
		{ "x-rapidapi-key", "b92489cde0msh89003454a330f43p17ffbejsn526f18837291" },
		{ "x-rapidapi-host", "the-weather-api.p.rapidapi.com" },
	},
			};
			
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var weather = JsonConvert.DeserializeObject<WeatherViewModel.Rootobject>(body);
				ViewBag.temp=weather.data.temp;
				return View(weather);
			}

			return View();
		}
	}
}
