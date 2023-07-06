using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class BatterySwitchStation
{
    public string BatteryId { get; set; } = null!;

    public string SwitchStationId { get; set; } = null!;

    public virtual Battery Battery { get; set; } = null!;

    public virtual SwitchStation SwitchStation { get; set; } = null!;
}
