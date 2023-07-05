using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class CompletionOfMaintenance
{
    public string MaintenanceId { get; set; } = null!;

    public string EmployeeId { get; set; } = null!;

    public virtual Staff Employee { get; set; } = null!;
}
