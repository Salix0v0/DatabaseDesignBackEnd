using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class SwitchRequest
{
    public string SwitchRequestId { get; set; } = null!;

    public string VehicleId { get; set; } = null!;

    public string EmployeeId { get; set; } = null!;

    public DateTime RequestTime { get; set; }

    public string? Remarks { get; set; }

    public virtual AcceptanceOfSwitchRequest? AcceptanceOfSwitchRequest { get; set; }
}
