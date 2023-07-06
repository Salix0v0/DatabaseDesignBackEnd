using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Vehicle
{
    public string VehicleId { get; set; } = null!;

    public string VehicleModel { get; set; } = null!;

    public string OwnerId { get; set; } = null!;

    public DateTime PurchaseDate { get; set; }

    public virtual ICollection<BatteryPosition> BatteryPositions { get; set; } = new List<BatteryPosition>();

    public virtual ICollection<MaintenanceItem> MaintenanceItems { get; set; } = new List<MaintenanceItem>();

    public virtual Owner Owner { get; set; } = null!;
}
