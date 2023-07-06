using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class BatteryPosition
{
    public string BatteryId { get; set; } = null!;

    public decimal? PositionStatus { get; set; }

    public string VehicleId { get; set; } = null!;

    public string SwitchStationId { get; set; } = null!;

    public virtual Battery Battery { get; set; } = null!;

    public virtual SwitchStation SwitchStation { get; set; } = null!;

    public virtual Vehicle Vehicle { get; set; } = null!;
}
