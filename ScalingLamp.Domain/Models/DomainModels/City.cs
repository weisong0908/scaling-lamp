using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScalingLamp.Domain.Models.DomainModels
{
    public class City
    {
        public int Id { get; set; }

        public string CityName { get; set; } = null!;

        public virtual ICollection<Variable> Variables { get; set; } = new List<Variable>();
    }
}