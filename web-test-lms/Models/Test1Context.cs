using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace web_test_lms.Models;

public partial class Test1Context : DbContext
{
    public Test1Context()
    {
    }

    public Test1Context(DbContextOptions<Test1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<AgentAction> AgentActions { get; set; }

    public virtual DbSet<BlType> BlTypes { get; set; }

    public virtual DbSet<Carrier> Carriers { get; set; }

    public virtual DbSet<CarrierAction> CarrierActions { get; set; }

    public virtual DbSet<ChatMessage> ChatMessages { get; set; }

    public virtual DbSet<Cport> Cports { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Fee> Fees { get; set; }

    public virtual DbSet<GoodsType> GoodsTypes { get; set; }

    public virtual DbSet<InvoiceType> InvoiceTypes { get; set; }

    public virtual DbSet<Kindofpackage> Kindofpackages { get; set; }

    public virtual DbSet<Mode> Modes { get; set; }

    public virtual DbSet<Quotation> Quotations { get; set; }

    public virtual DbSet<QuotationsCharge> QuotationsCharges { get; set; }

    public virtual DbSet<Sourse> Sourses { get; set; }

    public virtual DbSet<SupType> SupTypes { get; set; }

    public virtual DbSet<TblCharge> TblCharges { get; set; }

    public virtual DbSet<TblCnee> TblCnees { get; set; }

    public virtual DbSet<TblCneeAdd> TblCneeAdds { get; set; }

    public virtual DbSet<TblCom> TblComs { get; set; }

    public virtual DbSet<TblConth> TblConths { get; set; }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    public virtual DbSet<TblDeliveryConth> TblDeliveryConths { get; set; }

    public virtual DbSet<TblDeliverypfroof> TblDeliverypfroofs { get; set; }

    public virtual DbSet<TblDepartment> TblDepartments { get; set; }

    public virtual DbSet<TblHbl> TblHbls { get; set; }

    public virtual DbSet<TblHscode> TblHscodes { get; set; }

    public virtual DbSet<TblInvoice> TblInvoices { get; set; }

    public virtual DbSet<TblJob> TblJobs { get; set; }

    public virtual DbSet<TblLog> TblLogs { get; set; }

    public virtual DbSet<TblMessage> TblMessages { get; set; }

    public virtual DbSet<TblScustomer> TblScustomers { get; set; }

    public virtual DbSet<TblScustomerRelationship> TblScustomerRelationships { get; set; }

    public virtual DbSet<TblShipper> TblShippers { get; set; }

    public virtual DbSet<TblStaff> TblStaffs { get; set; }

    public virtual DbSet<TblSupplier> TblSuppliers { get; set; }

    public virtual DbSet<TblSupplierAction> TblSupplierActions { get; set; }

    public virtual DbSet<TblTaiKhoan> TblTaiKhoans { get; set; }

    public virtual DbSet<TblTaiKhoanMessage> TblTaiKhoanMessages { get; set; }

    public virtual DbSet<TblTutt> TblTutts { get; set; }

    public virtual DbSet<TblTuttJob> TblTuttJobs { get; set; }

    public virtual DbSet<TblTuttPhi> TblTuttPhis { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-S24TC32\\SQLEXPRESS;Initial Catalog=test1;\nIntegrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__AGENT__AA1D4378B304F22F");

            entity.ToTable("AGENT");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("CODE");
            entity.Property(e => e.AgentAdd)
                .HasMaxLength(255)
                .HasColumnName("Agent_add");
            entity.Property(e => e.AgentName)
                .HasMaxLength(1000)
                .HasColumnName("Agent_name");
            entity.Property(e => e.AgentNamekd)
                .HasMaxLength(1000)
                .HasColumnName("Agent_namekd");
            entity.Property(e => e.BankAccountC)
                .HasMaxLength(255)
                .HasColumnName("bank_accountC");
            entity.Property(e => e.BankAccountF)
                .HasMaxLength(255)
                .HasColumnName("Bank_accountF");
            entity.Property(e => e.ComId)
                .HasMaxLength(20)
                .HasColumnName("Com_ID");
            entity.Property(e => e.Note).HasMaxLength(255);

            entity.HasOne(d => d.Com).WithMany(p => p.Agents)
                .HasForeignKey(d => d.ComId)
                .HasConstraintName("FK__AGENT__Com_ID__71D1E811");
        });

        modelBuilder.Entity<AgentAction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AGENT_AC__3214EC277AC29BA9");

            entity.ToTable("AGENT_ACTION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("CODE");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PersonInCharge)
                .HasMaxLength(255)
                .HasColumnName("Person_in_charge");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(30)
                .HasColumnName("Phone_number");

            entity.HasOne(d => d.CodeNavigation).WithMany(p => p.AgentActions)
                .HasForeignKey(d => d.Code)
                .HasConstraintName("FK__AGENT_ACTI__CODE__74AE54BC");
        });

        modelBuilder.Entity<BlType>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__BL_TYPE__AA1D437855FA62AF");

            entity.ToTable("BL_TYPE");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("CODE");
            entity.Property(e => e.BlName)
                .HasMaxLength(255)
                .HasColumnName("BL_name");
            entity.Property(e => e.Note).HasMaxLength(255);
        });

        modelBuilder.Entity<Carrier>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__CARRIER__AA1D4378092C54D6");

            entity.ToTable("CARRIER");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("CODE");
            entity.Property(e => e.BankAccountC)
                .HasMaxLength(255)
                .HasColumnName("bank_accountC");
            entity.Property(e => e.BankAccountF)
                .HasMaxLength(255)
                .HasColumnName("Bank_accountF");
            entity.Property(e => e.CarierAdd)
                .HasMaxLength(255)
                .HasColumnName("Carier_add");
            entity.Property(e => e.CarrierName)
                .HasMaxLength(255)
                .HasColumnName("Carrier_name");
            entity.Property(e => e.CarrierNamekd)
                .HasMaxLength(255)
                .HasColumnName("Carrier_namekd");
            entity.Property(e => e.ComId)
                .HasMaxLength(20)
                .HasColumnName("Com_ID");
            entity.Property(e => e.Note).HasMaxLength(255);

            entity.HasOne(d => d.Com).WithMany(p => p.Carriers)
                .HasForeignKey(d => d.ComId)
                .HasConstraintName("FK__CARRIER__Com_ID__778AC167");
        });

        modelBuilder.Entity<CarrierAction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CARRIER___3214EC27A63119C8");

            entity.ToTable("CARRIER_ACTION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("CODE");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.LccFee)
                .HasMaxLength(255)
                .HasColumnName("LCC_Fee");
            entity.Property(e => e.PersonInCharge)
                .HasMaxLength(255)
                .HasColumnName("Person_in_charge");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(30)
                .HasColumnName("Phone_number");

            entity.HasOne(d => d.CodeNavigation).WithMany(p => p.CarrierActions)
                .HasForeignKey(d => d.Code)
                .HasConstraintName("FK__CARRIER_AC__CODE__7A672E12");
        });

        modelBuilder.Entity<ChatMessage>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__ChatMess__C87C037C75CF9CE1");

            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.ChatMessages)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK__ChatMessa__Usern__4F7CD00D");
        });

        modelBuilder.Entity<Cport>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__CPORT__AA1D437814C986FB");

            entity.ToTable("CPORT");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("CODE");
            entity.Property(e => e.PortName)
                .HasMaxLength(255)
                .HasColumnName("PORT_NAME");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__CURRENCY__AA1D43788DF652AA");

            entity.ToTable("CURRENCY");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("CODE");
            entity.Property(e => e.CurrName)
                .HasMaxLength(255)
                .HasColumnName("Curr_name");
            entity.Property(e => e.Note).HasMaxLength(255);
        });

        modelBuilder.Entity<Fee>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__FEE__AA1D4378AC656F3A");

            entity.ToTable("FEE");

            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("CODE");
            entity.Property(e => e.Fee1)
                .HasMaxLength(255)
                .HasColumnName("FEE");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("NOTE");
            entity.Property(e => e.Unit)
                .HasMaxLength(255)
                .HasColumnName("UNIT");
        });

        modelBuilder.Entity<GoodsType>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__GOODS_TY__AA1D437847DEB7A2");

            entity.ToTable("GOODS_TYPE");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("CODE");
            entity.Property(e => e.GtName)
                .HasMaxLength(255)
                .HasColumnName("GT_name");
            entity.Property(e => e.Note).HasMaxLength(255);
        });

        modelBuilder.Entity<InvoiceType>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__INVOICE___A25C5AA6A2F8722F");

            entity.ToTable("INVOICE_TYPE");

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.NameType)
                .HasMaxLength(255)
                .HasColumnName("Name_type");
        });

        modelBuilder.Entity<Kindofpackage>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__KINDOFPA__AA1D437898F81A22");

            entity.ToTable("KINDOFPACKAGES");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("CODE");
            entity.Property(e => e.PackageName)
                .HasMaxLength(255)
                .HasColumnName("Package_name");
            entity.Property(e => e.PackagesDescription)
                .HasMaxLength(255)
                .HasColumnName("Packages_description");
        });

        modelBuilder.Entity<Mode>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__MODE__AA1D437861C057F6");

            entity.ToTable("MODE");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("CODE");
            entity.Property(e => e.Note).HasMaxLength(255);
        });

        modelBuilder.Entity<Quotation>(entity =>
        {
            entity.HasKey(e => e.QuotationId).HasName("PK__Quotatio__E19752B37DA72B2A");

            entity.Property(e => e.QuotationId)
                .HasMaxLength(50)
                .HasColumnName("QuotationID");
            entity.Property(e => e.Adds)
                .HasMaxLength(255)
                .HasColumnName("ADDs");
            entity.Property(e => e.ComId)
                .HasMaxLength(20)
                .HasColumnName("Com_ID");
            entity.Property(e => e.Commodity).HasMaxLength(255);
            entity.Property(e => e.Contact)
                .HasMaxLength(100)
                .HasColumnName("contact");
            entity.Property(e => e.CusContact).HasMaxLength(255);
            entity.Property(e => e.CusTo).HasMaxLength(255);
            entity.Property(e => e.Pod)
                .HasMaxLength(255)
                .HasColumnName("POD");
            entity.Property(e => e.Pol)
                .HasMaxLength(255)
                .HasColumnName("POL");
            entity.Property(e => e.Qdate).HasColumnType("datetime");
            entity.Property(e => e.Qsatus).HasMaxLength(255);
            entity.Property(e => e.StaffId)
                .HasMaxLength(20)
                .HasColumnName("Staff_ID");
            entity.Property(e => e.Term).HasMaxLength(255);
            entity.Property(e => e.Valid).HasColumnType("datetime");
            entity.Property(e => e.Vol).HasMaxLength(255);

            entity.HasOne(d => d.Com).WithMany(p => p.Quotations)
                .HasForeignKey(d => d.ComId)
                .HasConstraintName("FK__Quotation__Com_I__7A3223E8");
        });

        modelBuilder.Entity<QuotationsCharge>(entity =>
        {
            entity.HasKey(e => e.ChargeId).HasName("PK__Quotatio__17FC363B355C8607");

            entity.ToTable("Quotations_Charges");

            entity.Property(e => e.ChargeId).HasColumnName("ChargeID");
            entity.Property(e => e.ChargeName).HasMaxLength(255);
            entity.Property(e => e.Currency).HasMaxLength(10);
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.Quantity).HasDefaultValue(1.0);
            entity.Property(e => e.QuotationId)
                .HasMaxLength(50)
                .HasColumnName("QuotationID");
            entity.Property(e => e.Rate)
                .HasDefaultValue(0.0)
                .HasColumnName("rate");
            entity.Property(e => e.Unit).HasMaxLength(255);

            entity.HasOne(d => d.Quotation).WithMany(p => p.QuotationsCharges)
                .HasForeignKey(d => d.QuotationId)
                .HasConstraintName("FK__Quotation__Quota__7D0E9093");
        });

        modelBuilder.Entity<Sourse>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__SOURSE__AA1D4378A05A568E");

            entity.ToTable("SOURSE");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("CODE");
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.SourName)
                .HasMaxLength(255)
                .HasColumnName("Sour_name");
        });

        modelBuilder.Entity<SupType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SUP_TYPE__3214EC27BBDC2CF0");

            entity.ToTable("SUP_TYPE");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .HasColumnName("ID");
            entity.Property(e => e.Note).HasMaxLength(255);
        });

        modelBuilder.Entity<TblCharge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_CHAR__3214EC2715C7ABFC");

            entity.ToTable("tbl_CHARGES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdvancePayment)
                .HasDefaultValue(false)
                .HasColumnName("Advance_payment");
            entity.Property(e => e.Buy).HasDefaultValue(false);
            entity.Property(e => e.Checked).HasDefaultValue(false);
            entity.Property(e => e.Cont).HasDefaultValue(false);
            entity.Property(e => e.Currency).HasMaxLength(20);
            entity.Property(e => e.DebitId)
                .HasMaxLength(50)
                .HasColumnName("Debit_ID");
            entity.Property(e => e.ExchangeRate).HasColumnName("Exchange_rate");
            entity.Property(e => e.MVat)
                .HasDefaultValue(0f)
                .HasColumnName("M_VAT");
            entity.Property(e => e.Paybehalf).HasDefaultValue(false);
            entity.Property(e => e.Refunds).HasDefaultValue(false);
            entity.Property(e => e.Sell).HasDefaultValue(false);
            entity.Property(e => e.SerName)
                .HasMaxLength(255)
                .HasColumnName("Ser_Name");
            entity.Property(e => e.SerPrice)
                .HasDefaultValue(0f)
                .HasColumnName("Ser_Price");
            entity.Property(e => e.SerQuantity)
                .HasDefaultValue(0f)
                .HasColumnName("Ser_Quantity");
            entity.Property(e => e.SerUnit)
                .HasMaxLength(100)
                .HasColumnName("Ser_Unit");
            entity.Property(e => e.SerVat)
                .HasDefaultValue(0f)
                .HasColumnName("Ser_VAT");

            entity.HasOne(d => d.Debit).WithMany(p => p.TblCharges)
                .HasForeignKey(d => d.DebitId)
                .HasConstraintName("FK__tbl_CHARG__Debit__3A4CA8FD");
        });

        modelBuilder.Entity<TblCnee>(entity =>
        {
            entity.HasKey(e => e.Cnee).HasName("PK__tbl_CNEE__AA572F5060E3D69F");

            entity.ToTable("tbl_CNEE");

            entity.Property(e => e.Cnee)
                .HasMaxLength(255)
                .HasColumnName("CNEE");
            entity.Property(e => e.Caddress)
                .HasMaxLength(1000)
                .HasColumnName("CAddress");
            entity.Property(e => e.Ccity)
                .HasMaxLength(100)
                .HasColumnName("CCity");
            entity.Property(e => e.ComId)
                .HasMaxLength(20)
                .HasColumnName("Com_ID");
            entity.Property(e => e.CpersonInCharge)
                .HasMaxLength(255)
                .HasColumnName("CPerson_in_charge");
            entity.Property(e => e.Haddress)
                .HasMaxLength(1000)
                .HasColumnName("HAddress");
            entity.Property(e => e.TaxId)
                .HasMaxLength(20)
                .HasColumnName("TaxID");
            entity.Property(e => e.Vaddress)
                .HasMaxLength(1000)
                .HasColumnName("VAddress");
            entity.Property(e => e.Vcnee)
                .HasMaxLength(255)
                .HasColumnName("VCNEE");

            entity.HasOne(d => d.Com).WithMany(p => p.TblCnees)
                .HasForeignKey(d => d.ComId)
                .HasConstraintName("FK__tbl_CNEE__Com_ID__00200768");
        });

        modelBuilder.Entity<TblCneeAdd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_CNEE__3214EC2721C59687");

            entity.ToTable("tbl_CNEE_ADD");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adds).HasMaxLength(500);
            entity.Property(e => e.Cnee)
                .HasMaxLength(255)
                .HasColumnName("CNEE");
            entity.Property(e => e.PersonInCharge).HasMaxLength(255);
            entity.Property(e => e.Place).HasMaxLength(255);

            entity.HasOne(d => d.CneeNavigation).WithMany(p => p.TblCneeAdds)
                .HasForeignKey(d => d.Cnee)
                .HasConstraintName("FK__tbl_CNEE_A__CNEE__02FC7413");
        });

        modelBuilder.Entity<TblCom>(entity =>
        {
            entity.HasKey(e => e.ComId).HasName("PK__tbl_COM__D85628AC87AE11BE");

            entity.ToTable("tbl_COM");

            entity.Property(e => e.ComId)
                .HasMaxLength(20)
                .HasColumnName("Com_ID");
            entity.Property(e => e.BankAcountNoUsd0)
                .HasMaxLength(50)
                .HasColumnName("BankAcountNoUSD0");
            entity.Property(e => e.BankAcountNoUsd1)
                .HasMaxLength(50)
                .HasColumnName("BankAcountNoUSD1");
            entity.Property(e => e.BankAcountNoVnd0)
                .HasMaxLength(50)
                .HasColumnName("BankAcountNoVND0");
            entity.Property(e => e.BankAcountNoVnd1)
                .HasMaxLength(50)
                .HasColumnName("BankAcountNoVND1");
            entity.Property(e => e.BankAcountUsd0)
                .HasMaxLength(255)
                .HasColumnName("BankAcountUSD0");
            entity.Property(e => e.BankAcountUsd1)
                .HasMaxLength(255)
                .HasColumnName("BankAcountUSD1");
            entity.Property(e => e.BankAcountVnd0)
                .HasMaxLength(255)
                .HasColumnName("BankAcountVND0");
            entity.Property(e => e.BankAcountVnd1)
                .HasMaxLength(255)
                .HasColumnName("BankAcountVND1");
            entity.Property(e => e.BankAddressUsd0)
                .HasMaxLength(255)
                .HasColumnName("BankAddressUSD0");
            entity.Property(e => e.BankAddressUsd1)
                .HasMaxLength(255)
                .HasColumnName("BankAddressUSD1");
            entity.Property(e => e.BankNameNvd0)
                .HasMaxLength(255)
                .HasColumnName("BankNameNVD0");
            entity.Property(e => e.BankNameNvd1)
                .HasMaxLength(255)
                .HasColumnName("BankNameNVD1");
            entity.Property(e => e.BankNameUsd0)
                .HasMaxLength(255)
                .HasColumnName("BankNameUSD0");
            entity.Property(e => e.BankNameUsd1)
                .HasMaxLength(255)
                .HasColumnName("BankNameUSD1");
            entity.Property(e => e.CeoName)
                .HasMaxLength(255)
                .HasColumnName("Ceo_name");
            entity.Property(e => e.ComAddE)
                .HasMaxLength(1000)
                .HasColumnName("Com_addE");
            entity.Property(e => e.ComAddV)
                .HasMaxLength(1000)
                .HasColumnName("com_addV");
            entity.Property(e => e.ComAddressUsd0)
                .HasMaxLength(255)
                .HasColumnName("ComAddressUSD0");
            entity.Property(e => e.ComAddressUsd1)
                .HasMaxLength(255)
                .HasColumnName("ComAddressUSD1");
            entity.Property(e => e.ComEmail)
                .HasMaxLength(50)
                .HasColumnName("Com_email");
            entity.Property(e => e.ComEmailNv)
                .HasMaxLength(50)
                .HasColumnName("Com_email_nv");
            entity.Property(e => e.ComLogo)
                .HasColumnType("image")
                .HasColumnName("Com_logo");
            entity.Property(e => e.ComNameE)
                .HasMaxLength(255)
                .HasColumnName("Com_nameE");
            entity.Property(e => e.ComNameV)
                .HasMaxLength(255)
                .HasColumnName("Com_nameV");
            entity.Property(e => e.ComShortname)
                .HasMaxLength(255)
                .HasColumnName("Com_shortname");
            entity.Property(e => e.ComTel)
                .HasMaxLength(20)
                .HasColumnName("Com_tel");
            entity.Property(e => e.ComWeb)
                .HasMaxLength(255)
                .HasColumnName("Com_web");
            entity.Property(e => e.CountName)
                .HasMaxLength(255)
                .HasColumnName("Count_name");
            entity.Property(e => e.CusEmail)
                .HasMaxLength(50)
                .HasColumnName("Cus_email");
            entity.Property(e => e.CusName)
                .HasMaxLength(255)
                .HasColumnName("Cus_name");
            entity.Property(e => e.CusNickname)
                .HasMaxLength(255)
                .HasColumnName("Cus_nickname");
            entity.Property(e => e.CusTel)
                .HasMaxLength(20)
                .HasColumnName("Cus_tel");
            entity.Property(e => e.Swift0)
                .HasMaxLength(20)
                .HasColumnName("SWIFT0");
            entity.Property(e => e.Swift1)
                .HasMaxLength(20)
                .HasColumnName("SWIFT1");
            entity.Property(e => e.Wca)
                .HasMaxLength(20)
                .HasColumnName("WCA");
        });

        modelBuilder.Entity<TblConth>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_CONT__3214EC2760D4649A");

            entity.ToTable("tbl_CONTH");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cmb).HasColumnName("CMB");
            entity.Property(e => e.ContNo)
                .HasMaxLength(255)
                .HasColumnName("Cont_No");
            entity.Property(e => e.ContQuantity)
                .HasDefaultValue(0)
                .HasColumnName("Cont_quantity");
            entity.Property(e => e.ContType)
                .HasMaxLength(50)
                .HasColumnName("Cont_type");
            entity.Property(e => e.GoodsDepcription)
                .HasMaxLength(500)
                .HasColumnName("Goods_depcription");
            entity.Property(e => e.GoodsQuantity)
                .HasMaxLength(255)
                .HasColumnName("Goods_quantity");
            entity.Property(e => e.GrossWeight).HasColumnName("Gross_weight");
            entity.Property(e => e.Hbl)
                .HasMaxLength(50)
                .HasColumnName("HBL");
            entity.Property(e => e.SealNo)
                .HasMaxLength(255)
                .HasColumnName("Seal_No");

            entity.HasOne(d => d.HblNavigation).WithMany(p => p.TblConths)
                .HasForeignKey(d => d.Hbl)
                .HasConstraintName("FK__tbl_CONTH__HBL__2BFE89A6");
        });

        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__tbl_CUST__8CB286B9C3E618EE");

            entity.ToTable("tbl_CUSTOMER");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(20)
                .HasColumnName("Customer_ID");
            entity.Property(e => e.BankAccountC)
                .HasMaxLength(255)
                .HasColumnName("bank_accountC");
            entity.Property(e => e.BankAccountF)
                .HasMaxLength(255)
                .HasColumnName("Bank_accountF");
            entity.Property(e => e.ComAddress)
                .HasMaxLength(1000)
                .HasColumnName("Com_Address");
            entity.Property(e => e.ComAddresskd)
                .HasMaxLength(1000)
                .HasColumnName("Com_Addresskd");
            entity.Property(e => e.ComDob)
                .HasColumnType("datetime")
                .HasColumnName("Com_DOB");
            entity.Property(e => e.ComId)
                .HasMaxLength(20)
                .HasColumnName("Com_ID");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .HasColumnName("Company_Name");
            entity.Property(e => e.CompanyNamekd)
                .HasMaxLength(255)
                .HasColumnName("Company_Namekd");
            entity.Property(e => e.Contact).HasMaxLength(255);
            entity.Property(e => e.DutyPerson)
                .HasMaxLength(255)
                .HasColumnName("Duty_Person");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Other).HasMaxLength(255);
            entity.Property(e => e.StaffId)
                .HasMaxLength(20)
                .HasColumnName("Staff_ID");
            entity.Property(e => e.Website).HasMaxLength(255);

            entity.HasOne(d => d.Com).WithMany(p => p.TblCustomers)
                .HasForeignKey(d => d.ComId)
                .HasConstraintName("FK__tbl_CUSTO__Com_I__6383C8BA");

            entity.HasOne(d => d.Staff).WithMany(p => p.TblCustomers)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__tbl_CUSTO__Staff__628FA481");
        });

        modelBuilder.Entity<TblDeliveryConth>(entity =>
        {
            entity.HasKey(e => e.DcId).HasName("PK__tbl_DELI__46564CF9DD6DA4B8");

            entity.ToTable("tbl_DELIVERY_CONTH");

            entity.Property(e => e.DcId)
                .HasMaxLength(50)
                .HasColumnName("DC_ID");
            entity.Property(e => e.DelId)
                .HasMaxLength(50)
                .HasColumnName("Del_ID");
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.Del).WithMany(p => p.TblDeliveryConths)
                .HasForeignKey(d => d.DelId)
                .HasConstraintName("FK__tbl_DELIV__Del_I__30C33EC3");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.TblDeliveryConths)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__tbl_DELIVERY__ID__2FCF1A8A");
        });

        modelBuilder.Entity<TblDeliverypfroof>(entity =>
        {
            entity.HasKey(e => e.DelId).HasName("PK__tbl_DELI__ED31FCFDE0505EA3");

            entity.ToTable("tbl_DELIVERYPFROOF");

            entity.Property(e => e.DelId)
                .HasMaxLength(50)
                .HasColumnName("Del_ID");
            entity.Property(e => e.Adds)
                .HasMaxLength(255)
                .HasColumnName("ADDs");
            entity.Property(e => e.Cnee)
                .HasMaxLength(255)
                .HasColumnName("CNEE");
            entity.Property(e => e.DelDate)
                .HasColumnType("datetime")
                .HasColumnName("Del_date");
            entity.Property(e => e.Hbl)
                .HasMaxLength(50)
                .HasColumnName("HBL");
            entity.Property(e => e.PersonInCharge).HasMaxLength(255);
            entity.Property(e => e.Place).HasMaxLength(255);
            entity.Property(e => e.TaxAdds)
                .HasMaxLength(255)
                .HasColumnName("TAX_ADDS");
            entity.Property(e => e.TaxCnee)
                .HasMaxLength(255)
                .HasColumnName("TAX_CNEE");
            entity.Property(e => e.TaxId)
                .HasMaxLength(50)
                .HasColumnName("TAX_ID");
        });

        modelBuilder.Entity<TblDepartment>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__tbl_DEPA__151675D1E5774A90");

            entity.ToTable("tbl_DEPARTMENT");

            entity.Property(e => e.DepartmentId)
                .HasMaxLength(20)
                .HasColumnName("Department_ID");
            entity.Property(e => e.ComId)
                .HasMaxLength(20)
                .HasColumnName("Com_ID");
            entity.Property(e => e.DepName)
                .HasMaxLength(255)
                .HasColumnName("Dep_name");
            entity.Property(e => e.Note).HasMaxLength(20);
            entity.Property(e => e.Other).HasMaxLength(255);

            entity.HasOne(d => d.Com).WithMany(p => p.TblDepartments)
                .HasForeignKey(d => d.ComId)
                .HasConstraintName("FK__tbl_DEPAR__Com_I__5BE2A6F2");
        });

        modelBuilder.Entity<TblHbl>(entity =>
        {
            entity.HasKey(e => e.Hbl).HasName("PK__tbl_HBL__C7565848808A9541");

            entity.ToTable("tbl_HBL");

            entity.Property(e => e.Hbl)
                .HasMaxLength(50)
                .HasColumnName("HBL");
            entity.Property(e => e.BlType)
                .HasMaxLength(100)
                .HasColumnName("BL_type");
            entity.Property(e => e.Cnee)
                .HasMaxLength(255)
                .HasColumnName("CNEE");
            entity.Property(e => e.Collect).HasDefaultValue(false);
            entity.Property(e => e.ContSealNo)
                .HasMaxLength(1000)
                .HasColumnName("Cont_Seal_No");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(20)
                .HasColumnName("Customer_ID");
            entity.Property(e => e.CustomsDeclarationNo)
                .HasMaxLength(100)
                .HasColumnName("Customs_declaration_No");
            entity.Property(e => e.DoDate)
                .HasColumnType("datetime")
                .HasColumnName("DO_date");
            entity.Property(e => e.DoFile).HasColumnName("DO_file");
            entity.Property(e => e.FreightCharge)
                .HasDefaultValue(false)
                .HasColumnName("Freight_charge");
            entity.Property(e => e.FreightPayable)
                .HasMaxLength(100)
                .HasColumnName("Freight_Payable");
            entity.Property(e => e.GgtFile).HasColumnName("GGT_file");
            entity.Property(e => e.GoodsDesciption)
                .HasMaxLength(255)
                .HasDefaultValue("AS PER BILL")
                .HasColumnName("Goods_desciption");
            entity.Property(e => e.GrossWeight)
                .HasDefaultValue(0.0)
                .HasColumnName("Gross_weight");
            entity.Property(e => e.HblFile).HasColumnName("HBL_file");
            entity.Property(e => e.InvoiceNo)
                .HasMaxLength(50)
                .HasColumnName("Invoice_No");
            entity.Property(e => e.IssueDateH)
                .HasColumnType("datetime")
                .HasColumnName("Issue_dateH");
            entity.Property(e => e.IssuePlaceH)
                .HasMaxLength(255)
                .HasColumnName("Issue_placeH");
            entity.Property(e => e.MarkNos)
                .HasMaxLength(1000)
                .HasColumnName("Mark_Nos");
            entity.Property(e => e.NomFree)
                .HasMaxLength(100)
                .HasColumnName("Nom_Free");
            entity.Property(e => e.NotifyParty)
                .HasMaxLength(255)
                .HasColumnName("Notify_party");
            entity.Property(e => e.NumberofOrigins).HasMaxLength(100);
            entity.Property(e => e.OnBoardDateH)
                .HasColumnType("datetime")
                .HasColumnName("OnBoard_dateH");
            entity.Property(e => e.Pic)
                .HasMaxLength(255)
                .HasColumnName("PIC");
            entity.Property(e => e.PicPhone)
                .HasMaxLength(20)
                .HasColumnName("PIC_phone");
            entity.Property(e => e.Prepaid).HasDefaultValue(false);
            entity.Property(e => e.Quantity).HasMaxLength(255);
            entity.Property(e => e.RequestId)
                .HasMaxLength(50)
                .HasColumnName("Request_ID");
            entity.Property(e => e.Shipper).HasMaxLength(255);
            entity.Property(e => e.SiNo)
                .HasMaxLength(20)
                .HasColumnName("SI_No");
            entity.Property(e => e.StaffId)
                .HasMaxLength(20)
                .HasColumnName("Staff_ID");
            entity.Property(e => e.Tonnage).HasDefaultValue(0.0);
            entity.Property(e => e.Volume).HasMaxLength(255);

            entity.HasOne(d => d.CneeNavigation).WithMany(p => p.TblHbls)
                .HasForeignKey(d => d.Cnee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_HBL__CNEE__1DB06A4F");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblHbls)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_HBL__Custome__1BC821DD");

            entity.HasOne(d => d.Request).WithMany(p => p.TblHbls)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_HBL__Request__19DFD96B");

            entity.HasOne(d => d.ShipperNavigation).WithMany(p => p.TblHbls)
                .HasForeignKey(d => d.Shipper)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_HBL__Shipper__1CBC4616");

            entity.HasOne(d => d.Staff).WithMany(p => p.TblHbls)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_HBL__Staff_I__1AD3FDA4");
        });

        modelBuilder.Entity<TblHscode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_HSCO__3214EC27BD5E1EC4");

            entity.ToTable("tbl_HSCODE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Aanzfta)
                .HasDefaultValue(0.0)
                .HasColumnName("AANZFTA");
            entity.Property(e => e.Acfta)
                .HasDefaultValue(0.0)
                .HasColumnName("ACFTA");
            entity.Property(e => e.Ahkfta)
                .HasDefaultValue(0.0)
                .HasColumnName("AHKFTA");
            entity.Property(e => e.Aifta)
                .HasDefaultValue(0.0)
                .HasColumnName("AIFTA");
            entity.Property(e => e.Ajcep)
                .HasDefaultValue(0.0)
                .HasColumnName("AJCEP");
            entity.Property(e => e.Akfta)
                .HasDefaultValue(0.0)
                .HasColumnName("AKFTA");
            entity.Property(e => e.Atiga)
                .HasDefaultValue(0.0)
                .HasColumnName("ATIGA");
            entity.Property(e => e.ChinhSachHangHoa)
                .HasMaxLength(1000)
                .HasColumnName("Chinh_sach_hang_hoa");
            entity.Property(e => e.ChinhSachHangHoakd)
                .HasMaxLength(1000)
                .HasColumnName("Chinh_sach_hang_hoakd");
            entity.Property(e => e.Cptpp)
                .HasDefaultValue(0.0)
                .HasColumnName("CPTPP");
            entity.Property(e => e.DonViTinh)
                .HasMaxLength(50)
                .HasColumnName("Don_vi_tinh");
            entity.Property(e => e.Evfta)
                .HasDefaultValue(0.0)
                .HasColumnName("EVFTA");
            entity.Property(e => e.HsCode)
                .HasMaxLength(10)
                .HasColumnName("HS_CODE");
            entity.Property(e => e.LoaiForm)
                .HasMaxLength(255)
                .HasColumnName("Loai_form");
            entity.Property(e => e.MaBieuMauThueNk)
                .HasMaxLength(255)
                .HasColumnName("Ma_bieu_mau_thue_NK");
            entity.Property(e => e.MoTaHangHoaE)
                .HasMaxLength(500)
                .HasColumnName("Mo_ta_hang_hoaE");
            entity.Property(e => e.MoTaHangHoaV)
                .HasMaxLength(500)
                .HasColumnName("Mo_ta_hang_hoaV");
            entity.Property(e => e.MoTaHangHoaVkd)
                .HasMaxLength(500)
                .HasColumnName("Mo_ta_hang_hoaVkd");
            entity.Property(e => e.RceptA)
                .HasDefaultValue(0.0)
                .HasColumnName("RCEPT_A");
            entity.Property(e => e.RceptB)
                .HasDefaultValue(0.0)
                .HasColumnName("RCEPT_B");
            entity.Property(e => e.RceptC)
                .HasDefaultValue(0.0)
                .HasColumnName("RCEPT_C");
            entity.Property(e => e.RceptD)
                .HasDefaultValue(0.0)
                .HasColumnName("RCEPT_D");
            entity.Property(e => e.RceptE)
                .HasDefaultValue(0.0)
                .HasColumnName("RCEPT_E");
            entity.Property(e => e.RceptF)
                .HasDefaultValue(0.0)
                .HasColumnName("RCEPT_F");
            entity.Property(e => e.ThueBvmt)
                .HasMaxLength(100)
                .HasColumnName("Thue_BVMT");
            entity.Property(e => e.ThueNkTt)
                .HasDefaultValue(0.0)
                .HasColumnName("Thue_NK_TT");
            entity.Property(e => e.ThueNkUd)
                .HasDefaultValue(0.0)
                .HasColumnName("Thue_NK_UD");
            entity.Property(e => e.ThueVat)
                .HasMaxLength(100)
                .HasColumnName("Thue_VAT");
            entity.Property(e => e.Ttdb)
                .HasDefaultValue(0.0)
                .HasColumnName("TTDB");
            entity.Property(e => e.Ukvfta)
                .HasDefaultValue(0.0)
                .HasColumnName("UKVFTA");
            entity.Property(e => e.Vcfta)
                .HasDefaultValue(0.0)
                .HasColumnName("VCFTA");
            entity.Property(e => e.Vjepa)
                .HasDefaultValue(0.0)
                .HasColumnName("VJEPA");
            entity.Property(e => e.Vkfta)
                .HasDefaultValue(0.0)
                .HasColumnName("VKFTA");
            entity.Property(e => e.VnEaeu)
                .HasDefaultValue(0.0)
                .HasColumnName("VN_EAEU");
            entity.Property(e => e.VnLao)
                .HasDefaultValue(0.0)
                .HasColumnName("VN_LAO");
            entity.Property(e => e.Vncu)
                .HasDefaultValue(0.0)
                .HasColumnName("VNCU");
            entity.Property(e => e.Xk)
                .HasDefaultValue(0.0)
                .HasColumnName("XK");
            entity.Property(e => e.Xkcptpp)
                .HasDefaultValue(0.0)
                .HasColumnName("XKCPTPP");
            entity.Property(e => e.Xkev)
                .HasDefaultValue(0.0)
                .HasColumnName("XKEV");
            entity.Property(e => e.Xkukv)
                .HasDefaultValue(0.0)
                .HasColumnName("XKUKV");
            entity.Property(e => e.XuatXu)
                .HasMaxLength(100)
                .HasColumnName("Xuat_xu");
        });

        modelBuilder.Entity<TblInvoice>(entity =>
        {
            entity.HasKey(e => e.DebitId).HasName("PK__tbl_INVO__607C9BB9B26F1A17");

            entity.ToTable("tbl_INVOICE");

            entity.Property(e => e.DebitId)
                .HasMaxLength(50)
                .HasColumnName("Debit_ID");
            entity.Property(e => e.DebitDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Debit_date");
            entity.Property(e => e.Hbl)
                .HasMaxLength(50)
                .HasColumnName("HBL");
            entity.Property(e => e.InvoiceDate)
                .HasColumnType("datetime")
                .HasColumnName("Invoice_date");
            entity.Property(e => e.InvoiceNo)
                .HasMaxLength(20)
                .HasColumnName("Invoice_No");
            entity.Property(e => e.InvoiceType)
                .HasMaxLength(10)
                .HasColumnName("Invoice_type");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("Payment_date");
            entity.Property(e => e.SupplierId)
                .HasMaxLength(50)
                .HasColumnName("Supplier_ID");

            entity.HasOne(d => d.HblNavigation).WithMany(p => p.TblInvoices)
                .HasForeignKey(d => d.Hbl)
                .HasConstraintName("FK__tbl_INVOICE__HBL__37703C52");

            entity.HasOne(d => d.Supplier).WithMany(p => p.TblInvoices)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK__tbl_INVOI__Suppl__367C1819");
        });

        modelBuilder.Entity<TblJob>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__tbl_JOB__E9C5B293841EA6D0");

            entity.ToTable("tbl_JOB");

            entity.Property(e => e.RequestId)
                .HasMaxLength(50)
                .HasColumnName("Request_ID");
            entity.Property(e => e.Agent).HasMaxLength(20);
            entity.Property(e => e.Carrier).HasMaxLength(20);
            entity.Property(e => e.Cneem)
                .HasMaxLength(1000)
                .HasColumnName("CNEEM");
            entity.Property(e => e.ComId)
                .HasMaxLength(20)
                .HasColumnName("Com_ID");
            entity.Property(e => e.Eta)
                .HasColumnType("datetime")
                .HasColumnName("ETA");
            entity.Property(e => e.Etd)
                .HasColumnType("datetime")
                .HasColumnName("ETD");
            entity.Property(e => e.GoodsType)
                .HasMaxLength(20)
                .HasColumnName("Goods_type");
            entity.Property(e => e.IssueDateM)
                .HasColumnType("datetime")
                .HasColumnName("Issue_dateM");
            entity.Property(e => e.JobDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Job_date");
            entity.Property(e => e.JobId)
                .HasMaxLength(50)
                .HasColumnName("Job_ID");
            entity.Property(e => e.Link).HasMaxLength(500);
            entity.Property(e => e.Mbl)
                .HasMaxLength(100)
                .HasColumnName("MBL");
            entity.Property(e => e.MblFile).HasColumnName("MBL_file");
            entity.Property(e => e.Mode).HasMaxLength(100);
            entity.Property(e => e.NotifyPartyM)
                .HasMaxLength(1000)
                .HasColumnName("Notify_PartyM");
            entity.Property(e => e.OnBoardDateM)
                .HasColumnType("datetime")
                .HasColumnName("OnBoard_dateM");
            entity.Property(e => e.PlaceofDelivery).HasMaxLength(255);
            entity.Property(e => e.PlaceofReceipt).HasMaxLength(255);
            entity.Property(e => e.Pod)
                .HasMaxLength(255)
                .HasColumnName("POD");
            entity.Property(e => e.Podel)
                .HasMaxLength(255)
                .HasColumnName("PODel");
            entity.Property(e => e.Podis)
                .HasMaxLength(255)
                .HasColumnName("PODis");
            entity.Property(e => e.Pol)
                .HasMaxLength(255)
                .HasColumnName("POL");
            entity.Property(e => e.PreCariageBy)
                .HasMaxLength(100)
                .HasColumnName("Pre_Cariage_by");
            entity.Property(e => e.ShipperM).HasMaxLength(1000);
            entity.Property(e => e.UseTime)
                .HasDefaultValue(2025)
                .HasColumnName("Use_time");
            entity.Property(e => e.VesselName)
                .HasMaxLength(100)
                .HasColumnName("Vessel_name");
            entity.Property(e => e.VoyageName)
                .HasMaxLength(100)
                .HasColumnName("Voyage_name");
            entity.Property(e => e.Ycompany).HasMaxLength(1000);
            entity.Property(e => e.YunLock).HasDefaultValue(0);

            entity.HasOne(d => d.AgentNavigation).WithMany(p => p.TblJobs)
                .HasForeignKey(d => d.Agent)
                .HasConstraintName("FK__tbl_JOB__Agent__1332DBDC");

            entity.HasOne(d => d.CarrierNavigation).WithMany(p => p.TblJobs)
                .HasForeignKey(d => d.Carrier)
                .HasConstraintName("FK__tbl_JOB__Carrier__14270015");

            entity.HasOne(d => d.Com).WithMany(p => p.TblJobs)
                .HasForeignKey(d => d.ComId)
                .HasConstraintName("FK__tbl_JOB__Com_ID__17036CC0");
        });

        modelBuilder.Entity<TblLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_LOG__3214EC27803365E5");

            entity.ToTable("tbl_LOG");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("ID");
            entity.Property(e => e.LoginTime)
                .HasColumnType("datetime")
                .HasColumnName("Login_time");
            entity.Property(e => e.LogoutTime)
                .HasColumnType("datetime")
                .HasColumnName("Logout_time");
            entity.Property(e => e.Username).HasMaxLength(50);
            entity.Property(e => e.WanIp)
                .HasMaxLength(20)
                .HasColumnName("WAN_IP");
        });

        modelBuilder.Entity<TblMessage>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__tbl_MESS__C87C037C35C1552F");

            entity.ToTable("tbl_MESSAGES");

            entity.Property(e => e.MessageId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("MessageID");
            entity.Property(e => e.MessageContent).HasMaxLength(255);
            entity.Property(e => e.MessageDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<TblScustomer>(entity =>
        {
            entity.HasKey(e => e.ScustumerId).HasName("PK__tbl_SCUS__BCB8F29212CD0B66");

            entity.ToTable("tbl_SCUSTOMER");

            entity.Property(e => e.ScustumerId)
                .HasMaxLength(20)
                .HasColumnName("SCustumer_ID");
            entity.Property(e => e.CkExportCode)
                .HasMaxLength(255)
                .HasColumnName("CK_export_code");
            entity.Property(e => e.CkExportName)
                .HasMaxLength(255)
                .HasColumnName("CK_export_name");
            entity.Property(e => e.ComAddress)
                .HasMaxLength(1000)
                .HasColumnName("Com_address");
            entity.Property(e => e.ComDob)
                .HasColumnType("datetime")
                .HasColumnName("Com_DOB");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .HasColumnName("Company_Name");
            entity.Property(e => e.Contact).HasMaxLength(255);
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(50)
                .HasColumnName("Currency_code");
            entity.Property(e => e.DeliveryConditions)
                .HasMaxLength(255)
                .HasColumnName("Delivery_conditions");
            entity.Property(e => e.DnVolume)
                .HasMaxLength(255)
                .HasColumnName("DN_volume");
            entity.Property(e => e.DutyPerson)
                .HasMaxLength(255)
                .HasColumnName("Duty_Person");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.ExportCountry)
                .HasMaxLength(255)
                .HasColumnName("Export_country");
            entity.Property(e => e.ForeignPort)
                .HasMaxLength(255)
                .HasColumnName("Foreign_port");
            entity.Property(e => e.GoodName)
                .HasMaxLength(255)
                .HasColumnName("Good_name");
            entity.Property(e => e.GoodsType)
                .HasMaxLength(255)
                .HasColumnName("Goods_type");
            entity.Property(e => e.HcmVolume)
                .HasMaxLength(255)
                .HasColumnName("HCM_volume");
            entity.Property(e => e.HpVolume)
                .HasMaxLength(255)
                .HasColumnName("HP_volume");
            entity.Property(e => e.HsCode)
                .HasMaxLength(100)
                .HasColumnName("HS_code");
            entity.Property(e => e.ImportCountry)
                .HasMaxLength(255)
                .HasColumnName("Import_country");
            entity.Property(e => e.OtherVolume)
                .HasMaxLength(255)
                .HasColumnName("Other_volume");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(255)
                .HasColumnName("Payment_method");
            entity.Property(e => e.StaffId)
                .HasMaxLength(20)
                .HasColumnName("Staff_ID");
            entity.Property(e => e.Term).HasMaxLength(100);
            entity.Property(e => e.Website).HasMaxLength(255);

            entity.HasOne(d => d.Staff).WithMany(p => p.TblScustomers)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__tbl_SCUST__Staff__66603565");
        });

        modelBuilder.Entity<TblScustomerRelationship>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_SCUS__3214EC27DFA8BE9E");

            entity.ToTable("tbl_SCUSTOMER_RELATIONSHIP");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CusDate)
                .HasColumnType("datetime")
                .HasColumnName("Cus_date");
            entity.Property(e => e.CusSatus)
                .HasMaxLength(1000)
                .HasColumnName("Cus_satus");
            entity.Property(e => e.Other).HasMaxLength(255);
            entity.Property(e => e.Scheme).HasMaxLength(500);
            entity.Property(e => e.ScustumerId)
                .HasMaxLength(20)
                .HasColumnName("SCustumer_ID");

            entity.HasOne(d => d.Scustumer).WithMany(p => p.TblScustomerRelationships)
                .HasForeignKey(d => d.ScustumerId)
                .HasConstraintName("FK__tbl_SCUST__SCust__693CA210");
        });

        modelBuilder.Entity<TblShipper>(entity =>
        {
            entity.HasKey(e => e.Shipper).HasName("PK__tbl_SHIP__AD512F84ED153AE6");

            entity.ToTable("tbl_SHIPPER");

            entity.Property(e => e.Shipper).HasMaxLength(255);
            entity.Property(e => e.ComId)
                .HasMaxLength(20)
                .HasColumnName("Com_ID");
            entity.Property(e => e.Saddress)
                .HasMaxLength(1000)
                .HasColumnName("SAddress");
            entity.Property(e => e.Scity)
                .HasMaxLength(100)
                .HasColumnName("SCity");
            entity.Property(e => e.SpersonInCharge)
                .HasMaxLength(255)
                .HasColumnName("SPerson_in_charge");
            entity.Property(e => e.TaxId)
                .HasMaxLength(20)
                .HasColumnName("TaxID");

            entity.HasOne(d => d.Com).WithMany(p => p.TblShippers)
                .HasForeignKey(d => d.ComId)
                .HasConstraintName("FK__tbl_SHIPP__Com_I__7D439ABD");
        });

        modelBuilder.Entity<TblStaff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__tbl_STAF__32D1F3C3D8837D4C");

            entity.ToTable("tbl_STAFF");

            entity.Property(e => e.StaffId)
                .HasMaxLength(20)
                .HasColumnName("Staff_ID");
            entity.Property(e => e.BankAccountNo)
                .HasMaxLength(100)
                .HasColumnName("Bank_Account_No");
            entity.Property(e => e.BankName)
                .HasMaxLength(255)
                .HasColumnName("Bank_name");
            entity.Property(e => e.CitizenId)
                .HasMaxLength(50)
                .HasColumnName("CitizenID");
            entity.Property(e => e.CitizenIdDate)
                .HasColumnType("datetime")
                .HasColumnName("CitizenID_date");
            entity.Property(e => e.CitizenIdPlace)
                .HasMaxLength(255)
                .HasColumnName("CitizenID_place");
            entity.Property(e => e.ComId)
                .HasMaxLength(20)
                .HasColumnName("Com_ID");
            entity.Property(e => e.DepartmentId)
                .HasMaxLength(20)
                .HasColumnName("Department_ID");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.GoalTarget).HasColumnName("Goal_target");
            entity.Property(e => e.InsuranceNo)
                .HasMaxLength(100)
                .HasColumnName("Insurance_No");
            entity.Property(e => e.NickName)
                .HasMaxLength(225)
                .HasColumnName("Nick_name");
            entity.Property(e => e.Passwords).HasMaxLength(20);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(100)
                .HasColumnName("Phone_No");
            entity.Property(e => e.Position).HasMaxLength(255);
            entity.Property(e => e.StaffName)
                .HasMaxLength(255)
                .HasColumnName("Staff_name");
            entity.Property(e => e.StartingWokdDate).HasColumnType("datetime");

            entity.HasOne(d => d.Com).WithMany(p => p.TblStaffs)
                .HasForeignKey(d => d.ComId)
                .HasConstraintName("FK__tbl_STAFF__Com_I__5FB337D6");

            entity.HasOne(d => d.Department).WithMany(p => p.TblStaffs)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__tbl_STAFF__Depar__5EBF139D");
        });

        modelBuilder.Entity<TblSupplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__tbl_SUPP__83918D9826E9B79D");

            entity.ToTable("tbl_SUPPLIER");

            entity.Property(e => e.SupplierId)
                .HasMaxLength(50)
                .HasColumnName("Supplier_ID");
            entity.Property(e => e.AddressSup)
                .HasMaxLength(255)
                .HasColumnName("Address_sup");
            entity.Property(e => e.BankAccountC)
                .HasMaxLength(255)
                .HasColumnName("Bank_accountC");
            entity.Property(e => e.BankAccountF)
                .HasMaxLength(255)
                .HasColumnName("Bank_accountF");
            entity.Property(e => e.ComId)
                .HasMaxLength(20)
                .HasColumnName("Com_ID");
            entity.Property(e => e.LccFee)
                .HasMaxLength(255)
                .HasColumnName("LCC_Fee");
            entity.Property(e => e.NameSup)
                .HasMaxLength(255)
                .HasColumnName("Name_sup");
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.Typer).HasMaxLength(20);

            entity.HasOne(d => d.Com).WithMany(p => p.TblSuppliers)
                .HasForeignKey(d => d.ComId)
                .HasConstraintName("FK__tbl_SUPPL__Com_I__6C190EBB");
        });

        modelBuilder.Entity<TblSupplierAction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_SUPP__3214EC27D7231BA4");

            entity.ToTable("tbl_SUPPLIER_ACTION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PersonInCharge)
                .HasMaxLength(255)
                .HasColumnName("Person_in_charge");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(30)
                .HasColumnName("Phone_number");
            entity.Property(e => e.SupplierId)
                .HasMaxLength(50)
                .HasColumnName("Supplier_ID");

            entity.HasOne(d => d.Supplier).WithMany(p => p.TblSupplierActions)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK__tbl_SUPPL__Suppl__6EF57B66");
        });

        modelBuilder.Entity<TblTaiKhoan>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__tbl_TAI___536C85E5F3DD1F34");

            entity.ToTable("tbl_TAI_KHOAN");

            entity.Property(e => e.Username).HasMaxLength(50);
            entity.Property(e => e.ComId)
                .HasMaxLength(20)
                .HasColumnName("Com_ID");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Passwords).HasMaxLength(20);
            entity.Property(e => e.Statuss).HasMaxLength(50);

            entity.HasOne(d => d.Com).WithMany(p => p.TblTaiKhoans)
                .HasForeignKey(d => d.ComId)
                .HasConstraintName("FK__tbl_TAI_K__Com_I__4CA06362");
        });

        modelBuilder.Entity<TblTaiKhoanMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_TAI___3214EC270281489A");

            entity.ToTable("tbl_TAI_KHOAN_MESSAGES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsRead).HasDefaultValue(false);
            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Message).WithMany(p => p.TblTaiKhoanMessages)
                .HasForeignKey(d => d.MessageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_TAI_K__Messa__5812160E");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TblTaiKhoanMessages)
                .HasForeignKey(d => d.Username)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_TAI_K__Usern__59063A47");
        });

        modelBuilder.Entity<TblTutt>(entity =>
        {
            entity.HasKey(e => e.SoTutt).HasName("PK__tbl_TUTT__2F552821F2D90DBE");

            entity.ToTable("tbl_TUTT");

            entity.Property(e => e.SoTutt)
                .HasMaxLength(50)
                .HasColumnName("SoTUTT");
            entity.Property(e => e.Ceo)
                .HasDefaultValue(false)
                .HasColumnName("ceo");
            entity.Property(e => e.ComId)
                .HasMaxLength(20)
                .HasColumnName("Com_ID");
            entity.Property(e => e.Da)
                .HasDefaultValue(false)
                .HasColumnName("da");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(255)
                .HasColumnName("Ghi_chu");
            entity.Property(e => e.Ketoan)
                .HasDefaultValue(false)
                .HasColumnName("ketoan");
            entity.Property(e => e.Ngay).HasColumnType("datetime");
            entity.Property(e => e.NhanvienTutt)
                .HasMaxLength(100)
                .HasColumnName("NhanvienTUTT");
            entity.Property(e => e.NoiDung)
                .HasMaxLength(255)
                .HasColumnName("Noi_dung");
            entity.Property(e => e.Thuong).HasDefaultValue(false);

            entity.HasOne(d => d.Com).WithMany(p => p.TblTutts)
                .HasForeignKey(d => d.ComId)
                .HasConstraintName("FK__tbl_TUTT__Com_ID__09A971A2");
        });

        modelBuilder.Entity<TblTuttJob>(entity =>
        {
            entity.HasKey(e => e.Stt).HasName("PK__tbl_TUTT__CA1EB690C98EE33B");

            entity.ToTable("tbl_TUTT_JOB");

            entity.Property(e => e.Stt)
                .HasMaxLength(50)
                .HasColumnName("STT");
            entity.Property(e => e.Hbl)
                .HasMaxLength(50)
                .HasColumnName("HBL");
            entity.Property(e => e.SoTutt)
                .HasMaxLength(50)
                .HasColumnName("SoTUTT");

            entity.HasOne(d => d.HblNavigation).WithMany(p => p.TblTuttJobs)
                .HasForeignKey(d => d.Hbl)
                .HasConstraintName("FK__tbl_TUTT_JO__HBL__2739D489");

            entity.HasOne(d => d.SoTuttNavigation).WithMany(p => p.TblTuttJobs)
                .HasForeignKey(d => d.SoTutt)
                .HasConstraintName("FK__tbl_TUTT___SoTUT__2645B050");
        });

        modelBuilder.Entity<TblTuttPhi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_TUTT__3214EC271475313B");

            entity.ToTable("tbl_TUTT_PHI");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NghiChu).HasMaxLength(255);
            entity.Property(e => e.SoHoaDon).HasMaxLength(20);
            entity.Property(e => e.SoTien).HasDefaultValue(0.0);
            entity.Property(e => e.SoTutt)
                .HasMaxLength(50)
                .HasColumnName("SoTUTT");
            entity.Property(e => e.TenPhi).HasMaxLength(255);
            entity.Property(e => e.Tt)
                .HasDefaultValue(false)
                .HasColumnName("TT");
            entity.Property(e => e.Tu)
                .HasDefaultValue(false)
                .HasColumnName("TU");

            entity.HasOne(d => d.SoTuttNavigation).WithMany(p => p.TblTuttPhis)
                .HasForeignKey(d => d.SoTutt)
                .HasConstraintName("FK__tbl_TUTT___SoTUT__0F624AF8");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__UNIT__AA1D4378C53D74A9");

            entity.ToTable("UNIT");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("CODE");
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.UnitName)
                .HasMaxLength(255)
                .HasColumnName("Unit_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
