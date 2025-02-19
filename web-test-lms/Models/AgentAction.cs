using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class AgentAction
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? PersonInCharge { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Note { get; set; }

    public virtual Agent? CodeNavigation { get; set; }
}
