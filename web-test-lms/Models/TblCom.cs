using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class TblCom
{
    public string ComId { get; set; } = null!;

    public string? ComNameE { get; set; }

    public string? ComNameV { get; set; }

    public string? ComShortname { get; set; }

    public string? ComAddE { get; set; }

    public string? ComAddV { get; set; }

    public string? ComTel { get; set; }

    public string? ComEmail { get; set; }

    public string? ComEmailNv { get; set; }

    public string? ComWeb { get; set; }

    public byte[]? ComLogo { get; set; }

    public string? Wca { get; set; }

    public string? CusEmail { get; set; }

    public string? CusTel { get; set; }

    public string? CusName { get; set; }

    public string? CusNickname { get; set; }

    public string? CountName { get; set; }

    public string? CeoName { get; set; }

    public string? BankAcountVnd0 { get; set; }

    public string? BankNameNvd0 { get; set; }

    public string? BankAcountNoVnd0 { get; set; }

    public string? BankAcountVnd1 { get; set; }

    public string? BankNameNvd1 { get; set; }

    public string? BankAcountNoVnd1 { get; set; }

    public string? BankAcountUsd0 { get; set; }

    public string? ComAddressUsd0 { get; set; }

    public string? BankAcountNoUsd0 { get; set; }

    public string? BankNameUsd0 { get; set; }

    public string? BankAddressUsd0 { get; set; }

    public string? Swift0 { get; set; }

    public string? BankAcountUsd1 { get; set; }

    public string? ComAddressUsd1 { get; set; }

    public string? BankAcountNoUsd1 { get; set; }

    public string? BankNameUsd1 { get; set; }

    public string? BankAddressUsd1 { get; set; }

    public string? Swift1 { get; set; }

    public virtual ICollection<Agent> Agents { get; set; } = new List<Agent>();

    public virtual ICollection<Carrier> Carriers { get; set; } = new List<Carrier>();

    public virtual ICollection<Quotation> Quotations { get; set; } = new List<Quotation>();

    public virtual ICollection<TblCnee> TblCnees { get; set; } = new List<TblCnee>();

    public virtual ICollection<TblCustomer> TblCustomers { get; set; } = new List<TblCustomer>();

    public virtual ICollection<TblDepartment> TblDepartments { get; set; } = new List<TblDepartment>();

    public virtual ICollection<TblJob> TblJobs { get; set; } = new List<TblJob>();

    public virtual ICollection<TblShipper> TblShippers { get; set; } = new List<TblShipper>();

    public virtual ICollection<TblStaff> TblStaffs { get; set; } = new List<TblStaff>();

    public virtual ICollection<TblSupplier> TblSuppliers { get; set; } = new List<TblSupplier>();

    public virtual ICollection<TblTaiKhoan> TblTaiKhoans { get; set; } = new List<TblTaiKhoan>();

    public virtual ICollection<TblTutt> TblTutts { get; set; } = new List<TblTutt>();
}
