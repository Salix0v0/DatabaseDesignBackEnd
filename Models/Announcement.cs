using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Announcement
{
    public string AnnouncementId { get; set; } = null!;

    public DateTime PublishTime { get; set; }

    public string Title { get; set; } = null!;

    public string? Content { get; set; }
}
