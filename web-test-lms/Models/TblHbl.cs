using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class TblHbl
{
    public string Hbl { get; set; } = null!;

    public string RequestId { get; set; } = null!;

    public string StaffId { get; set; } = null!;

    public string? IssuePlaceH { get; set; }

    public DateTime? IssueDateH { get; set; }

    public DateTime? OnBoardDateH { get; set; }

    public byte[]? HblFile { get; set; }

    public string CustomerId { get; set; } = null!;

    public string Shipper { get; set; } = null!;

    public string Cnee { get; set; } = null!;

    public string? NotifyParty { get; set; }

    public string? BlType { get; set; }

    public string NomFree { get; set; } = null!;

    public string? ContSealNo { get; set; }

    public string? Volume { get; set; }

    public string? Quantity { get; set; }

    public string? GoodsDesciption { get; set; }

    public double? GrossWeight { get; set; }

    public double? Tonnage { get; set; }

    public string? CustomsDeclarationNo { get; set; }

    public string? InvoiceNo { get; set; }

    public string? NumberofOrigins { get; set; }

    public string? FreightPayable { get; set; }

    public string? MarkNos { get; set; }

    public bool? FreightCharge { get; set; }

    public bool? Prepaid { get; set; }

    public bool? Collect { get; set; }

    public string? SiNo { get; set; }

    public string? Pic { get; set; }

    public DateTime? DoDate { get; set; }

    public string? PicPhone { get; set; }

    public byte[]? DoFile { get; set; }

    public byte[]? GgtFile { get; set; }

    public virtual TblCnee CneeNavigation { get; set; } = null!;

    public virtual TblCustomer Customer { get; set; } = null!;

    public virtual TblJob Request { get; set; } = null!;

    public virtual TblShipper ShipperNavigation { get; set; } = null!;

    public virtual TblStaff Staff { get; set; } = null!;

    public virtual ICollection<TblConth> TblConths { get; set; } = new List<TblConth>();

    public virtual ICollection<TblInvoice> TblInvoices { get; set; } = new List<TblInvoice>();

    public virtual ICollection<TblTuttJob> TblTuttJobs { get; set; } = new List<TblTuttJob>();
}
