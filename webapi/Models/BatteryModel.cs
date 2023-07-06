using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class BatteryModel
{
    public string BatteryModelId { get; set; } = null!;

    public decimal BatteryLife { get; set; }

    public string TotalCapacity { get; set; } = null!;

    public virtual ICollection<Battery> Batteries { get; set; } = new List<Battery>();
}
