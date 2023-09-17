using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScalingLamp.Models.DAOs;
using ScalingLamp.Models.DomainModels;

namespace ScalingLamp.Persistence
{
    public class VariableRepository : IVariableRepository
    {
        private readonly ScalingLampContext _dbContext;

        public VariableRepository(ScalingLampContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<VariableDao>> GetVariablesAsync(
            string? variableName,
            DateTimeOffset? startTimestamp,
            DateTimeOffset? endTimestamp,
            string? cityName)
        {
            var variables = _dbContext.Variables
                .Include(v => v.City)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(variableName))
            {
                variables = variables.Where(v => v.Name == variableName);
            }

            if (startTimestamp is not null)
            {
                variables = variables.Where(v => v.Timestamp >= startTimestamp);
            }

            if (endTimestamp is not null)
            {
                variables = variables.Where(v => v.Timestamp <= endTimestamp);
            }

            if (!string.IsNullOrWhiteSpace(cityName))
            {
                variables = variables.Where(v => v.City != null && v.City.CityName == cityName);
            }

            return await variables
                .Select(v => new VariableDao(v))
                .ToListAsync();
        }
    }
}