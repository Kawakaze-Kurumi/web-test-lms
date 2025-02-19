using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class TblCharge
{
    public int Id { get; set; }

    public string? DebitId { get; set; }

    public float? ExchangeRate { get; set; }

    public string? Currency { get; set; }

    public string? SerName { get; set; }

    public float? SerPrice { get; set; }

    public float? SerQuantity { get; set; }

    public string? SerUnit { get; set; }

    public float? SerVat { get; set; }

    public float? MVat { get; set; }

    public bool? Buy { get; set; }

    public bool? Sell { get; set; }

    public bool? Paybehalf { get; set; }

    public bool? AdvancePayment { get; set; }

    public bool? Refunds { get; set; }

    public bool? Cont { get; set; }

    public bool? Checked { get; set; }

    public virtual TblInvoice? Debit { get; set; }
}
