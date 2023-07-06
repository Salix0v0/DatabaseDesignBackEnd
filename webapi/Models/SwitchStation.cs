using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class SwitchStation
{
    public string SwitchStationId { get; set; } = null!;

    public string? StationName { get; set; }

    public decimal Longitude { get; set; }

    public decimal Latitude { get; set; }

    public string? FaliureStatus { get; set; }

    public decimal BatteryCapacity { get; set; }

    public decimal? AvailableBatteryCount { get; set; }

    public virtual ICollection<BatterySwitchStation> BatterySwitchStations { get; set; } = new List<BatterySwitchStation>();

    public virtual ICollection<StaffInSwitchStation> StaffInSwitchStations { get; set; } = new List<StaffInSwitchStation>();
}
