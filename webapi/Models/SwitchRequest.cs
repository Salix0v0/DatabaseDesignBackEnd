using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class SwitchRequest
{
    public string SwitchRequestId { get; set; } = null!;

    public string VehicleId { get; set; } = null!;

    public string? SwitchMode { get; set; }

    public DateTime RequestTime { get; set; }

    public string? Remarks { get; set; }

    public virtual AcceptanceOfSwitchRequest SwitchRequestNavigation { get; set; } = null!;

    public virtual Vehicle Vehicle { get; set; } = null!;
}
