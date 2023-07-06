using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class StaffInformation
{
    public string IdentityNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Gender { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
