using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScalingLamp.Domain.Models.DAOs;
using ScalingLamp.Domain.Persistence;

namespace ScalingLamp.Domain.Services
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

        public async Task<List<VariableDao>> GetVariablesAsync(
            string? variableName,
            DateTimeOffset? startTimestamp,
            DateTimeOffset? endTimestamp,
            string? cityName)
        {
            var variablesDao = await _variableRepository.GetVariablesAsync(variableName, startTimestamp, endTimestamp, cityName);

            return variablesDao
                .ToList();
        }

        public async Task<HottestCityDao?> GetHottestCityAsync()
        {
            var hottestCityDao = await _cityRepository.GetHottestCityAsync();

            return hottestCityDao;
        }

        public async Task<MoistestCityDao?> GetMoistestCityAsync()
        {
            var moistestCityDao = await _cityRepository.GetMoistestCityAsync();

            return moistestCityDao;
        }
    }
}