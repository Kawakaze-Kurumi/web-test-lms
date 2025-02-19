using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class TblTaiKhoan
{
    public string Username { get; set; } = null!;

    public string? Passwords { get; set; }

    public string? FullName { get; set; }

    public string? Statuss { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? ComId { get; set; }

    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

    public virtual TblCom? Com { get; set; }

    public virtual ICollection<TblTaiKhoanMessage> TblTaiKhoanMessages { get; set; } = new List<TblTaiKhoanMessage>();
}
