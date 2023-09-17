using Microsoft.EntityFrameworkCore;
using ScalingLamp.Models.DAOs;
using ScalingLamp.Models.DomainModels;

namespace ScalingLamp.Persistence
{
    public class CityRepository : ICityRepository
    {
        private readonly ScalingLampContext _dbContext;
        public CityRepository(ScalingLampContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<City>> GetCitiesAsync()
        {
            return await _dbContext.Cities.ToListAsync();
        }

        public async Task<HottestCityDao?> GetHottestCityAsync()
        {
            var startTimesamp = DateTimeOffset.Parse("2023-01-01");
            var endTimesamp = DateTimeOffset.Parse("2023-01-31");

            return await _dbContext.Variables
                .Include(v => v.City)
                .Where(v => v.City != null)
                .Where(v => v.Timestamp.Date >= startTimesamp.Date && v.Timestamp.Date <= endTimesamp.Date)
                .Where(v => v.Name == "Temperature" && v.Unit == "°C")
                .Where(v => Convert.ToDouble(v.Value) > 30)
                .GroupBy(v => v.City)
                .Select(g => new HottestCityDao
                {
                    CityName = g.Key!.CityName,
                    Count = g.Count()
                })
                .OrderByDescending(g => g.Count)
                .FirstOrDefaultAsync();
        }

        public async Task<MoistestCityDao?> GetMoistestCityAsync()
        {
            var startTimesamp = DateTimeOffset.Parse("2023-01-01");
            var endTimesamp = DateTimeOffset.Parse("2023-01-31");

            return await _dbContext.Variables
                .Include(v => v.City)
                .Where(v => v.City != null)
                .Where(v => v.Timestamp.Date >= startTimesamp.Date && v.Timestamp.Date <= endTimesamp.Date)
                .Where(v => v.Name == "Humidity" && v.Unit == "%")
                .GroupBy(v => v.City, v =>  Convert.ToDouble(v.Value))
                .Select(g => new MoistestCityDao
                {
                    CityName = g.Key!.CityName,
                    Average =  g.Average()
                })
                .OrderByDescending(g => g.Average)
                .FirstOrDefaultAsync();
        }
    }
}