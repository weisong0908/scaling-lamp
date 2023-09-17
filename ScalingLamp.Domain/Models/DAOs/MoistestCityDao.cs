using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScalingLamp.Domain.Models.DAOs
{
    public class MoistestCityDao
    {
        public string CityName { get; set; } = string.Empty;
        public double Average { get; set; }
    }
}