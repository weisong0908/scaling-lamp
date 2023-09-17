using ScalingLamp.Domain.Models.DAOs;
using ScalingLamp.Domain.Models.DomainModels;

namespace ScalingLamp.Domain.Persistence
{
    public interface ICityRepository
    {
        Task<List<City>> GetCitiesAsync();
        Task<HottestCityDao?> GetHottestCityAsync();
        Task<MoistestCityDao?> GetMoistestCityAsync();
    }
}