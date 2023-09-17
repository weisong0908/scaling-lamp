using ScalingLamp.Domain.Models.DomainModels;

namespace ScalingLamp.Domain.Models.DAOs
{
    public class VariableDao
    {
        public string Name { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public DateTimeOffset Timestamp { get; set; }
        public string CityName { get; set; } = string.Empty;

        public VariableDao(Variable variable)
        {
            Name = variable.Name;
            Unit = variable.Unit;
            Value = variable.Value;
            Timestamp = variable.Timestamp;
            CityName = variable.City == null ? "" : variable.City.CityName;
        }
    }
}