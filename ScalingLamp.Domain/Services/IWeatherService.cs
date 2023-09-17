using ScalingLamp.Domain.Models.DAOs;

namespace ScalingLamp.Domain.Services
{
    public interface IWeatherService
    {
        Task<List<CityDao>> GetCitiesAsync();
        Task<HottestCityDao?> GetHottestCityAsync();
        Task<MoistestCityDao?> GetMoistestCityAsync();
        Task<List<VariableDao>> GetVariablesAsync(string? variableName, DateTimeOffset? startTimestamp, DateTimeOffset? endTimestamp, string? cityName);
    }
}