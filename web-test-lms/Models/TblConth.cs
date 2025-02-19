using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class TblConth
{
    public int Id { get; set; }

    public string? ContNo { get; set; }

    public string? Hbl { get; set; }

    public int? ContQuantity { get; set; }

    public string? ContType { get; set; }

    public string? SealNo { get; set; }

    public double? GrossWeight { get; set; }

    public double? Cmb { get; set; }

    public string? GoodsQuantity { get; set; }

    public string? GoodsDepcription { get; set; }

    public virtual TblHbl? HblNavigation { get; set; }

    public virtual ICollection<TblDeliveryConth> TblDeliveryConths { get; set; } = new List<TblDeliveryConth>();
}
