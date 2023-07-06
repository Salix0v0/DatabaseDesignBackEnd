using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Staff
{
    public string EmployeeId { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte[]? Avatar { get; set; }

    public DateTime CreationTime { get; set; }

    public string IdCardNum { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string Name { get; set; } = null!;

    public string? Gender { get; set; }

    public string? Position { get; set; }

    public virtual ICollection<AcceptanceOfSwitchRequest> AcceptanceOfSwitchRequests { get; set; } = new List<AcceptanceOfSwitchRequest>();

    public virtual ICollection<CompletionOfMaintenance> CompletionOfMaintenances { get; set; } = new List<CompletionOfMaintenance>();

    public virtual StaffInformation IdCardNumNavigation { get; set; } = null!;

    public virtual StaffInSwitchStation? StaffInSwitchStation { get; set; }
}
