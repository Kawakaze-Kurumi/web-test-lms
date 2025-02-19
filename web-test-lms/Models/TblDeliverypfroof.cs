using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class TblDeliverypfroof
{
    public string DelId { get; set; } = null!;

    public DateTime? DelDate { get; set; }

    public string? Hbl { get; set; }

    public string? Cnee { get; set; }

    public string? Adds { get; set; }

    public string? Place { get; set; }

    public string? PersonInCharge { get; set; }

    public string? TaxId { get; set; }

    public string? TaxCnee { get; set; }

    public string? TaxAdds { get; set; }

    public virtual ICollection<TblDeliveryConth> TblDeliveryConths { get; set; } = new List<TblDeliveryConth>();
}
