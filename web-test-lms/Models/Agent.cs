using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class Agent
{
    public string Code { get; set; } = null!;

    public string? AgentName { get; set; }

    public string? AgentNamekd { get; set; }

    public string? AgentAdd { get; set; }

    public string? BankAccountF { get; set; }

    public string? BankAccountC { get; set; }

    public string? Note { get; set; }

    public string? ComId { get; set; }

    public virtual ICollection<AgentAction> AgentActions { get; set; } = new List<AgentAction>();

    public virtual TblCom? Com { get; set; }

    public virtual ICollection<TblJob> TblJobs { get; set; } = new List<TblJob>();
}
