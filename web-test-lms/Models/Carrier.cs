using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class Carrier
{
    public string Code { get; set; } = null!;

    public string? CarrierName { get; set; }

    public string? CarrierNamekd { get; set; }

    public string? CarierAdd { get; set; }

    public string? BankAccountF { get; set; }

    public string? BankAccountC { get; set; }

    public string? Note { get; set; }

    public string? ComId { get; set; }

    public virtual ICollection<CarrierAction> CarrierActions { get; set; } = new List<CarrierAction>();

    public virtual TblCom? Com { get; set; }

    public virtual ICollection<TblJob> TblJobs { get; set; } = new List<TblJob>();
}
