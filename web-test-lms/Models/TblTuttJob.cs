using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class TblTuttJob
{
    public string Stt { get; set; } = null!;

    public string? SoTutt { get; set; }

    public string? Hbl { get; set; }

    public virtual TblHbl? HblNavigation { get; set; }

    public virtual TblTutt? SoTuttNavigation { get; set; }
}
