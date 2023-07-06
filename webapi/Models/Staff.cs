using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Staff
{
    public string EmployeeId { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string PasswordP { get; set; } = null!;

    public byte[]? Avatar { get; set; }

    public DateTime CreatiTime { get; set; }

    public string? PhoneNumber { get; set; }

    public string IdentityNumber { get; set; } = null!;

    public string NameP { get; set; } = null!;

    public string? Gender { get; set; }

    public string? Positions { get; set; }

    public decimal Salary { get; set; }

    public virtual ICollection<AcceptanceOfSwitchRequest> AcceptanceOfSwitchRequests { get; set; } = new List<AcceptanceOfSwitchRequest>();

    public virtual ICollection<CompletionOfMaintenance> CompletionOfMaintenances { get; set; } = new List<CompletionOfMaintenance>();

    public virtual ICollection<Performance> Performances { get; set; } = new List<Performance>();

    public virtual StaffInSwitchStation? StaffInSwitchStation { get; set; }

    public virtual ICollection<SwitchRecord> SwitchRecords { get; set; } = new List<SwitchRecord>();
}
