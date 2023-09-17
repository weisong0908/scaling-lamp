using ScalingLamp.Models.DTOs;
using ScalingLamp.Persistence;

namespace ScalingLamp.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IVariableRepository _variableRepository;

        public WeatherService(ICityRepository cityRepository, IVariableRepository variableRepository)
        {
            _cityRepository = cityRepository;
            _variableRepository = variableRepository;
        }

        public async Task<List<VariableDto>> GetVariablesAsync(
            string? variableName,
            DateTimeOffset? startTimesamp,
            DateTimeOffset? endTimestamp,
            string? cityName)
        {
            var variables = await _variableRepository.GetVariablesAsync(variableName, startTimesamp, endTimestamp, cityName);

            return variables
                .Select(v => new VariableDto(v))
                .ToList();
        }

        public async Task<HottestCityDto> GetHottestCityAsync()
        {
            var hottestCityDao = await _cityRepository.GetHottestCityAsync();

            return new HottestCityDto(hottestCityDao);
        }

        public async Task<MoistestCityDto> GetMoistestCityAsync()
        {
            var moistestCityDao = await _cityRepository.GetMoistestCityAsync();

            return new MoistestCityDto(moistestCityDao);
        }
    }
}