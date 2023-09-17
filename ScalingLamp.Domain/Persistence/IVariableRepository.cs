using ScalingLamp.Domain.Models.DAOs;

namespace ScalingLamp.Domain.Persistence
{
    public interface IVariableRepository
    {
        Task<List<VariableDao>> GetVariablesAsync(string? variableName, DateTimeOffset? startTimestamp, DateTimeOffset? endTimestamp, string? cityName);
    }
}