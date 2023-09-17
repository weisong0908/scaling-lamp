using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScalingLamp.Models.DTOs;
using ScalingLamp.Persistence;

namespace ScalingLamp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        private readonly IVariableRepository _variableRepository;

        public WeatherController(ICityRepository cityRepository, IVariableRepository variableRepository)
        {
            _cityRepository = cityRepository;
            _variableRepository = variableRepository;
        }

        [HttpGet("variables")]
        public async Task<IActionResult> GetVariables(
            string? variableName,
            DateTimeOffset? startTimesamp,
            DateTimeOffset? endTimestamp,
            string? cityName)
        {
            var variables = await _variableRepository.GetVariablesAsync(variableName, startTimesamp, endTimestamp, cityName);

            return Ok(variables.Select(v => new VariableDto(v)));
        }

        [HttpGet("hottestCity")]
        public async Task<IActionResult> GetHottestCity()
        {
            var cityCountDao = await _cityRepository.GetHottestCityAsync();
            
            return Ok(new HottestCityDto(cityCountDao));
        }

        [HttpGet("moistestCity")]
        public async Task<IActionResult> GetMoistestCity()
        {
            var cityAverageDao = await _cityRepository.GetMoistestCityAsync();
            
            return Ok(new MoistestCityDto(cityAverageDao));
        }
    }
}