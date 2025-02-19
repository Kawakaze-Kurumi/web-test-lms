using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class TblShipper
{
    public string Shipper { get; set; } = null!;

    public string? Saddress { get; set; }

    public string? Scity { get; set; }

    public string? SpersonInCharge { get; set; }

    public string? TaxId { get; set; }

    public string? ComId { get; set; }

    public virtual TblCom? Com { get; set; }

    public virtual ICollection<TblHbl> TblHbls { get; set; } = new List<TblHbl>();
}
