using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class VehicleParameter
{
    public string VehicleModel { get; set; } = null!;

    public string GearType { get; set; } = null!;

    public DateTime WarrantyPeriod { get; set; }

    public string Manufacturer { get; set; } = null!;

    public decimal? MaxSpeed { get; set; }
}
