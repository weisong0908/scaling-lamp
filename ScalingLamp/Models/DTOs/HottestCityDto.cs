using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScalingLamp.Models.DAOs;

namespace ScalingLamp.Models.DTOs
{
    public class HottestCityDto
    {
        public string CityName { get; set; } = string.Empty;
        public int Count { get; set; }

        public HottestCityDto(HottestCityDao? dao)
        {
            if (dao is not null)
            {
                CityName = dao.CityName;
                Count = dao.Count;
            }
        }
    }
}