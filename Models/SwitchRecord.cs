using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class SwitchRecord
{
    public string SwitchServiceId { get; set; } = null!;

    public string VehicleId { get; set; } = null!;

    public DateTime SwitchTime { get; set; }

    public string EmployeeId { get; set; } = null!;

    public string SwappedBatteryId { get; set; } = null!;

    public string BatterySource { get; set; } = null!;

    public string SwappedOutBatteryId { get; set; } = null!;

    public string SwappedOutBatteryDestination { get; set; } = null!;

    public string? Evaluation { get; set; }
}
