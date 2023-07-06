using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class SwitchRecord
{
    public string SwitchServiceId { get; set; } = null!;

    public string VehicleId { get; set; } = null!;

    public DateTime SwitchTime { get; set; }

    public string EmployeeId { get; set; } = null!;

    public string SwappedBatteryId { get; set; } = null!;

    public string SwappedOutBatteryId { get; set; } = null!;

    public string? Evaluations { get; set; }

    public virtual Staff Employee { get; set; } = null!;

    public virtual Battery SwappedBattery { get; set; } = null!;

    public virtual Battery SwappedOutBattery { get; set; } = null!;

    public virtual Vehicle Vehicle { get; set; } = null!;
}
