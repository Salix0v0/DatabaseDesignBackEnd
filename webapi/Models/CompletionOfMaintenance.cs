using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class CompletionOfMaintenance
{
    public string MaintenanceItemId { get; set; } = null!;

    public string EmployeeId { get; set; } = null!;

    public virtual Staff Employee { get; set; } = null!;

    public virtual MaintenanceItem MaintenanceItem { get; set; } = null!;
}
