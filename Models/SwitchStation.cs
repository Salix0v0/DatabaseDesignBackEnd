using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class SwitchStation
{
    public string SwitchStationId { get; set; } = null!;

    public string? StationName { get; set; }

    public decimal Longitude { get; set; }

    public decimal Latitude { get; set; }

    public string? AvailableStatus { get; set; }

    public string? FaultStatus { get; set; }

    public decimal BatteryCapacity { get; set; }

    public decimal? AvailableBatteryCount { get; set; }

    public virtual ICollection<BatteryPosition> BatteryPositions { get; set; } = new List<BatteryPosition>();

    public virtual ICollection<StaffInSwitchStation> StaffInSwitchStations { get; set; } = new List<StaffInSwitchStation>();
}
