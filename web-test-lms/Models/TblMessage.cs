using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class TblMessage
{
    public Guid MessageId { get; set; }

    public string? MessageContent { get; set; }

    public DateTime? MessageDate { get; set; }

    public virtual ICollection<TblTaiKhoanMessage> TblTaiKhoanMessages { get; set; } = new List<TblTaiKhoanMessage>();
}
