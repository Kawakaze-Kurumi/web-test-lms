using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class TblDeliveryConth
{
    public string DcId { get; set; } = null!;

    public int? Id { get; set; }

    public string? DelId { get; set; }

    public virtual TblDeliverypfroof? Del { get; set; }

    public virtual TblConth? IdNavigation { get; set; }
}
