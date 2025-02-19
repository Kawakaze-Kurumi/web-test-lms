using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class TblSupplier
{
    public string SupplierId { get; set; } = null!;

    public string? NameSup { get; set; }

    public string? Typer { get; set; }

    public string? AddressSup { get; set; }

    public string? BankAccountF { get; set; }

    public string? BankAccountC { get; set; }

    public string? LccFee { get; set; }

    public string? Note { get; set; }

    public string? ComId { get; set; }

    public virtual TblCom? Com { get; set; }

    public virtual ICollection<TblInvoice> TblInvoices { get; set; } = new List<TblInvoice>();

    public virtual ICollection<TblSupplierAction> TblSupplierActions { get; set; } = new List<TblSupplierAction>();
}
