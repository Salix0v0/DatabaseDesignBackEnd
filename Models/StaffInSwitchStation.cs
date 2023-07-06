using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class StaffInSwitchStation
{
    public string EmployeeId { get; set; } = null!;

    public string SwitchStationId { get; set; } = null!;

    public virtual Staff Employee { get; set; } = null!;

    public virtual SwitchStation SwitchStation { get; set; } = null!;
}
