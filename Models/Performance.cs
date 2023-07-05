using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Performance
{
    public string PerformanceId { get; set; } = null!;

    public string EmployeeId { get; set; } = null!;

    public decimal TotalPerformance { get; set; }

    public decimal? ServiceCount { get; set; }

    public decimal? PositiveRating { get; set; }
}
