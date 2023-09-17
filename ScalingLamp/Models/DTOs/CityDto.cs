using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScalingLamp.Domain.Models.DAOs;

namespace ScalingLamp.Models.DTOs
{
    public class CityDto
    {
        public string CityName { get; set; } = string.Empty;

        public CityDto(CityDao dao)
        {
            CityName = dao.CityName;
        }
    }
}