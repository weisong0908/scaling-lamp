using Microsoft.AspNetCore.Mvc;
using ScalingLamp.Services;

namespace ScalingLamp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("variables")]
        public async Task<IActionResult> GetVariables(
            string? variableName,
            DateTimeOffset? startTimestamp,
            DateTimeOffset? endTimestamp,
            string? cityName)
        {
            var variables = await _weatherService.GetVariablesAsync(variableName, startTimestamp, endTimestamp, cityName);

            return Ok(variables);
        }

        [HttpGet("hottestCity")]
        public async Task<IActionResult> GetHottestCity()
        {
            var hottestCity = await _weatherService.GetHottestCityAsync();
            
            return Ok(hottestCity);
        }

        [HttpGet("moistestCity")]
        public async Task<IActionResult> GetMoistestCity()
        {
            var moistestCity = await _weatherService.GetMoistestCityAsync();
            
            return Ok(moistestCity);
        }
    }
}