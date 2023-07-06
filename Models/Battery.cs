using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Battery
{
    public string BatteryId { get; set; } = null!;

    public string? AvailableStatus { get; set; }

    public decimal? TotalCapacity { get; set; }

    public decimal CurrentCapacity { get; set; }

    public decimal BatteryLife { get; set; }

    public DateTime ManufacturingDate { get; set; }

    public string BatteryModel { get; set; } = null!;

    public virtual BatteryPosition? BatteryPosition { get; set; }
}
