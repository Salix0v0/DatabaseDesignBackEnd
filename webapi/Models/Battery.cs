using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Battery
{
    public string BatteryId { get; set; } = null!;

    public string? AvailableStatus { get; set; }

    public string CurrentCapacity { get; set; } = null!;

    public DateTime ManufacturingDate { get; set; }

    public string BatteryModelId { get; set; } = null!;

    public virtual BatteryModel BatteryModel { get; set; } = null!;

    public virtual BatterySwitchStation? BatterySwitchStation { get; set; }

    public virtual ICollection<SwitchRecord> SwitchRecordSwappedBatteries { get; set; } = new List<SwitchRecord>();

    public virtual ICollection<SwitchRecord> SwitchRecordSwappedOutBatteries { get; set; } = new List<SwitchRecord>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
