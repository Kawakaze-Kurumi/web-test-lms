using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class TblStaff
{
    public string StaffId { get; set; } = null!;

    public string? DepartmentId { get; set; }

    public string? StaffName { get; set; }

    public string? NickName { get; set; }

    public DateTime? Dob { get; set; }

    public string? CitizenId { get; set; }

    public DateTime? CitizenIdDate { get; set; }

    public string? CitizenIdPlace { get; set; }

    public DateTime? StartingWokdDate { get; set; }

    public float? GoalTarget { get; set; }

    public string? Position { get; set; }

    public string? BankAccountNo { get; set; }

    public string? BankName { get; set; }

    public string? InsuranceNo { get; set; }

    public string? PhoneNo { get; set; }

    public string? Passwords { get; set; }

    public string? ComId { get; set; }

    public virtual TblCom? Com { get; set; }

    public virtual TblDepartment? Department { get; set; }

    public virtual ICollection<TblCustomer> TblCustomers { get; set; } = new List<TblCustomer>();

    public virtual ICollection<TblHbl> TblHbls { get; set; } = new List<TblHbl>();

    public virtual ICollection<TblScustomer> TblScustomers { get; set; } = new List<TblScustomer>();
}
