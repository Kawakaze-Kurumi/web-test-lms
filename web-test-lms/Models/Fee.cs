using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class Fee
{
    public string Code { get; set; } = null!;

    public string? Fee1 { get; set; }

    public string? Unit { get; set; }

    public string? Note { get; set; }
}
