using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScalingLamp.Domain.Models.DAOs
{
    public class HottestCityDao
    {
        public string CityName { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}