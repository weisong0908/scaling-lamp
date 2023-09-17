using ScalingLamp.Models.DAOs;

namespace ScalingLamp.Persistence
{
    public interface IVariableRepository
    {
        Task<List<VariableDao>> GetVariablesAsync(string? variableName, DateTimeOffset? startTimestamp, DateTimeOffset? endTimestamp, string? cityName);
    }
}