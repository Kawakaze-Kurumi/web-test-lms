using System;
using System.Collections.Generic;

namespace web_test_lms.Models;

public partial class TblScustomer
{
    public string ScustumerId { get; set; } = null!;

    public string? StaffId { get; set; }

    public string? CompanyName { get; set; }

    public string? ComAddress { get; set; }

    public string? Website { get; set; }

    public string? DutyPerson { get; set; }

    public string? Contact { get; set; }

    public string? Email { get; set; }

    public DateTime? ComDob { get; set; }

    public string? HcmVolume { get; set; }

    public string? HpVolume { get; set; }

    public string? DnVolume { get; set; }

    public string? OtherVolume { get; set; }

    public string? DeliveryConditions { get; set; }

    public string? GoodsType { get; set; }

    public string? GoodName { get; set; }

    public string? HsCode { get; set; }

    public string? ForeignPort { get; set; }

    public string? ImportCountry { get; set; }

    public string? ExportCountry { get; set; }

    public string? Term { get; set; }

    public string? PaymentMethod { get; set; }

    public string? CurrencyCode { get; set; }

    public string? CkExportName { get; set; }

    public string? CkExportCode { get; set; }

    public virtual TblStaff? Staff { get; set; }

    public virtual ICollection<TblScustomerRelationship> TblScustomerRelationships { get; set; } = new List<TblScustomerRelationship>();
}
