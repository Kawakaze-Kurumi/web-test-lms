using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class QuotationsCharge
{
    public int ChargeId { get; set; }

    public string? QuotationId { get; set; }

    public string? ChargeName { get; set; }

    public double? Quantity { get; set; }

    public string? Unit { get; set; }

    public double? Rate { get; set; }

    public string? Currency { get; set; }

    public string? Notes { get; set; }

    public virtual Quotation? Quotation { get; set; }
}
