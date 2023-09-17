using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScalingLamp.Models.DomainModels;

namespace ScalingLamp.Models.DAOs
{
    public class HottestCityDao
    {
        public string CityName { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}