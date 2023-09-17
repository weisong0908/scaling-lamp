using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
    }
}