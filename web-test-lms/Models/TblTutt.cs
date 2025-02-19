using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class TblTutt
{
    public string SoTutt { get; set; } = null!;

    public DateTime? Ngay { get; set; }

    public string? NhanvienTutt { get; set; }

    public string? NoiDung { get; set; }

    public bool? Thuong { get; set; }

    public bool? Da { get; set; }

    public bool? Ketoan { get; set; }

    public bool? Ceo { get; set; }

    public string? GhiChu { get; set; }

    public string? ComId { get; set; }

    public virtual TblCom? Com { get; set; }

    public virtual ICollection<TblTuttJob> TblTuttJobs { get; set; } = new List<TblTuttJob>();

    public virtual ICollection<TblTuttPhi> TblTuttPhis { get; set; } = new List<TblTuttPhi>();
}
