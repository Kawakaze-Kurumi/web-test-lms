using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class TblCnee
{
    public string Cnee { get; set; } = null!;

    public string? Vcnee { get; set; }

    public string? Caddress { get; set; }

    public string? Vaddress { get; set; }

    public string? Ccity { get; set; }

    public string? CpersonInCharge { get; set; }

    public string? TaxId { get; set; }

    public string? Haddress { get; set; }

    public string? ComId { get; set; }

    public virtual TblCom? Com { get; set; }

    public virtual ICollection<TblCneeAdd> TblCneeAdds { get; set; } = new List<TblCneeAdd>();

    public virtual ICollection<TblHbl> TblHbls { get; set; } = new List<TblHbl>();
}
