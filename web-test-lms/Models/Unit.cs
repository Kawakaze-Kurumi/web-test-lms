﻿using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class Unit
{
    public string Code { get; set; } = null!;

    public string? UnitName { get; set; }

    public string? Note { get; set; }
}
