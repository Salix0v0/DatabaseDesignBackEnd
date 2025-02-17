﻿using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class AcceptanceOfSwitchRequest
{
    public string SwitchRequestId { get; set; } = null!;

    public string EmployeeId { get; set; } = null!;

    public virtual Staff Employee { get; set; } = null!;

    public virtual SwitchRequest? SwitchRequest { get; set; }
}
