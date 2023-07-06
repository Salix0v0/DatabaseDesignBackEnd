using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class VehicleParameter
{
    public string VehicleModel { get; set; } = null!;

    public string GearType { get; set; } = null!;

    public DateTime WarrantyPeriod { get; set; }

    public string Manufacturer { get; set; } = null!;

    public decimal? MaxSpeed { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
