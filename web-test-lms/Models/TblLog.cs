using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class TblLog
{
    public string Id { get; set; } = null!;

    public string? Username { get; set; }

    public string? WanIp { get; set; }

    public DateTime? LoginTime { get; set; }

    public DateTime? LogoutTime { get; set; }
}
