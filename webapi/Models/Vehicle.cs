using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Vehicle
{
    public string VehicleId { get; set; } = null!;

    public string VehicleModel { get; set; } = null!;

    public string OwnerId { get; set; } = null!;

    public DateTime PurchaseDate { get; set; }

    public string? BatteryId { get; set; }

    public virtual Battery? Battery { get; set; }

    public virtual ICollection<MaintenanceItem> MaintenanceItems { get; set; } = new List<MaintenanceItem>();

    public virtual Owner Owner { get; set; } = null!;

    public virtual ICollection<SwitchRecord> SwitchRecords { get; set; } = new List<SwitchRecord>();

    public virtual ICollection<SwitchRequest> SwitchRequests { get; set; } = new List<SwitchRequest>();

    public virtual VehicleParameter VehicleModelNavigation { get; set; } = null!;
}
