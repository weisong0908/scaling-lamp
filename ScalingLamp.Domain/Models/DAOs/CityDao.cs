using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScalingLamp.Domain.Models.DomainModels;

namespace ScalingLamp.Domain.Models.DAOs
{
    public class CityDao
    {
        public string CityName { get; set; } = string.Empty;

        public CityDao(City city)
        {
            CityName = city.CityName;
        }
    }
}