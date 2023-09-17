using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScalingLamp.Models.DAOs;
using ScalingLamp.Models.DomainModels;

namespace ScalingLamp.Models.DTOs
{
    public class VariableDto
    {
        public string Name { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public double Value { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string CityName { get; set; } = string.Empty;

        public VariableDto(VariableDao dao)
        {
            Name = dao.Name;
            Unit = dao.Unit;
            Value = Convert.ToDouble(dao.Value);
            Timestamp = dao.Timestamp;
            CityName = dao.CityName;
        }
    }
}