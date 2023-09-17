using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScalingLamp.Models.DAOs;

namespace ScalingLamp.Models.DTOs
{
    public class MoistestCityDto
    {
        public string CityName { get; set; } = string.Empty;
        public double Average { get; set; }

        public MoistestCityDto(MoistestCityDao? dao)
        {
            if (dao is not null)
            {
                CityName = dao.CityName;
                Average = dao.Average;
            }
        }
    }
}