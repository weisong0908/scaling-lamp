using ScalingLamp.Models.DTOs;

namespace ScalingLamp.Services
{
    public interface IWeatherService
    {
        Task<HottestCityDto> GetHottestCityAsync();
        Task<MoistestCityDto> GetMoistestCityAsync();
        Task<List<VariableDto>> GetVariablesAsync(string? variableName, DateTimeOffset? startTimesamp, DateTimeOffset? endTimestamp, string? cityName);
    }
}