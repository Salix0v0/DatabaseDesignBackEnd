using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Owner
{
    public string OwnerId { get; set; } = null!;

    public string OwnerNickname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte[]? Avatar { get; set; }

    public DateTime CreationTime { get; set; }

    public string? PhoneNumber { get; set; }

    public string Email { get; set; } = null!;

    public string? Gender { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
