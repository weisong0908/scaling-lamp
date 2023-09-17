using ScalingLamp.Models.DomainModels;

namespace ScalingLamp.Persistence
{
    public interface ICityRepository
    {
        Task<List<City>> GetCitiesAsync();
    }
}