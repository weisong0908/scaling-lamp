using Microsoft.AspNetCore.Mvc;
using ScalingLamp.Domain.Services;
using ScalingLamp.Models.DTOs;

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

            return Ok(variables.Select(v => new VariableDto(v)));
        }

        [HttpGet("hottestCity")]
        public async Task<IActionResult> GetHottestCity()
        {
            var hottestCity = await _weatherService.GetHottestCityAsync();
            
            return Ok(new HottestCityDto(hottestCity));
        }

        [HttpGet("moistestCity")]
        public async Task<IActionResult> GetMoistestCity()
        {
            var moistestCity = await _weatherService.GetMoistestCityAsync();
            
            return Ok(new MoistestCityDto(moistestCity));
        }
    }
}