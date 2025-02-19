using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class Quotation
{
    public string QuotationId { get; set; } = null!;

    public string? Qsatus { get; set; }

    public string? StaffId { get; set; }

    public string? Contact { get; set; }

    public DateTime? Qdate { get; set; }

    public string? CusTo { get; set; }

    public string? CusContact { get; set; }

    public DateTime? Valid { get; set; }

    public string? Term { get; set; }

    public string? Vol { get; set; }

    public string? Commodity { get; set; }

    public string? Pol { get; set; }

    public string? Adds { get; set; }

    public string? Pod { get; set; }

    public string? ComId { get; set; }

    public virtual TblCom? Com { get; set; }

    public virtual ICollection<QuotationsCharge> QuotationsCharges { get; set; } = new List<QuotationsCharge>();
}
