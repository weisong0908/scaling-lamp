using System;
using System.Collections.Generic;

namespace ScalingLamp.Models.DomainModels;

public partial class Variable
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public string Value { get; set; } = null!;

    public DateTimeOffset Timestamp { get; set; }

    public int? CityId { get; set; }

    public virtual City? City { get; set; }
}
