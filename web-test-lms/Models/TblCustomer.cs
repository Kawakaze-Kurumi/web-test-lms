using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class TblCustomer
{
    public string CustomerId { get; set; } = null!;

    public string? StaffId { get; set; }

    public string? CompanyName { get; set; }

    public string? CompanyNamekd { get; set; }

    public string? ComAddress { get; set; }

    public string? ComAddresskd { get; set; }

    public string? Website { get; set; }

    public string? DutyPerson { get; set; }

    public string? Contact { get; set; }

    public string? Email { get; set; }

    public DateTime? ComDob { get; set; }

    public string? BankAccountF { get; set; }

    public string? BankAccountC { get; set; }

    public string? Other { get; set; }

    public string? ComId { get; set; }

    public virtual TblCom? Com { get; set; }

    public virtual TblStaff? Staff { get; set; }

    public virtual ICollection<TblHbl> TblHbls { get; set; } = new List<TblHbl>();
}
