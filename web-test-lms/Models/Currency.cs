using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class Currency
{
    public string Code { get; set; } = null!;

    public string? CurrName { get; set; }

    public string? Note { get; set; }
}
