using ScalingLamp.Models.DAOs;
using ScalingLamp.Models.DomainModels;

namespace ScalingLamp.Persistence
{
    public interface ICityRepository
    {
        Task<List<City>> GetCitiesAsync();
        Task<HottestCityDao?> GetHottestCityAsync();
        Task<MoistestCityDao?> GetMoistestCityAsync();
    }
}