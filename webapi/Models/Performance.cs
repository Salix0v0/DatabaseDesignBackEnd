using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Performance
{
    public string PerformanceId { get; set; } = null!;

    public string EmployeeId { get; set; } = null!;

    public decimal TotalPerformance { get; set; }

    public decimal? ServiceCount { get; set; }

    public decimal? PositiveRating { get; set; }

    public virtual Staff Employee { get; set; } = null!;
}
