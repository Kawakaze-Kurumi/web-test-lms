CREATE DATABASE COM_PND;
use COM_PND;
create table tbl_COM(
	Com_ID nvarchar(20) not null primary key,
	Com_nameE nvarchar(255),
	Com_nameV nvarchar(255),

	Com_shortname nvarchar(255),
	
	Com_addE nvarchar(1000),
	com_addV nvarchar(1000),
	
	Com_tel nvarchar(20),
	Com_email nvarchar(50),
	Com_email_nv nvarchar(50),
	Com_web nvarchar(255),
	Com_logo image, 
	WCA nvarchar(20),

	Cus_email nvarchar(50),
	Cus_tel nvarchar(20),
	Cus_name nvarchar(255),
	Cus_nickname nvarchar(255),

	Count_name nvarchar(255),
	Ceo_name nvarchar(255),

	BankAcountVND0 nvarchar(255),    --thanh toan cuoc bien va local charge
	BankNameNVD0 nvarchar(255),
	BankAcountNoVND0 nvarchar(50),

	BankAcountVND1 nvarchar(255),     -- thanh toan cho cuoc con va chi ho
	BankNameNVD1 nvarchar(255),
	BankAcountNoVND1 nvarchar(50),

	BankAcountUSD0 nvarchar(255),
	ComAddressUSD0 nvarchar(255),
	BankAcountNoUSD0 nvarchar(50),
	BankNameUSD0 nvarchar(255),
	BankAddressUSD0 nvarchar(255),
	SWIFT0 nvarchar(20),

	BankAcountUSD1 nvarchar(255),
	ComAddressUSD1 nvarchar(255),
	BankAcountNoUSD1 nvarchar(50),
	BankNameUSD1 nvarchar(255),
	BankAddressUSD1 nvarchar(255),
	SWIFT1 nvarchar(20),

);


insert into tbl_COM(Com_ID, Com_nameE, Com_nameV, Com_shortname, Com_addE, Com_addV, Com_tel, Com_email, Com_web) values
('0201975599', 'PND LOGISTICS TRANSPORT CO., LTD','PND', 'PND LOGISTICS TRANSPORT CO., LTD','PND',  'No 24A, Area 15, Dang Hai Ward, Hai An District, Hai Phong City, Vietnam', 'No 24A, Area 15, Dang Hai Ward, Hai An District, Hai Phong City, Vietnam', '+84 225 7303388', 'ceo@pnd-logistics.com', 'http://pnd-logistics.com');

create table tbl_TAI_KHOAN(
	Username nvarchar(50) not null primary key,
	Passwords nvarchar(20),
	FullName nvarchar(100),
	Statuss nvarchar(50),
	createDate datetime,
	Com_ID nvarchar(20) FOREIGN KEY REFERENCES tbl_COM(Com_ID),
);-- ĐÃ KIỂM TRA

insert into tbl_TAI_KHOAN(Username, Passwords, FullName) values ('user', '123', 'caoh')
insert into tbl_TAI_KHOAN(Username, Passwords, FullName) values ('admin', '123', 'caom')

CREATE TABLE ChatMessages (
    MessageID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) FOREIGN KEY REFERENCES tbl_TAI_KHOAN(Username),
    MessageText NVARCHAR(MAX),
    Timestamp DATETIME DEFAULT GETDATE(),
)

create table tbl_MESSAGES(
	MessageID UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	MessageContent nvarchar(255),
    MessageDate DATETIME DEFAULT GETDATE(),
);
create table tbl_TAI_KHOAN_MESSAGES(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    MessageID UNIQUEIDENTIFIER NOT NULL,
    Username NVARCHAR(50) NOT NULL,
	IsRead bit DEFAULT 0,
    FOREIGN KEY (MessageID) REFERENCES tbl_MESSAGES(MessageID),
    FOREIGN KEY (Username) REFERENCES tbl_TAI_KHOAN(Username)
);



create table tbl_DEPARTMENT(
	Department_ID nvarchar(20) not null primary key,
	Dep_name nvarchar(255),
	Other nvarchar(255),
	Note nvarchar(20),
	Com_ID nvarchar(20) foreign key references tbl_COM(Com_ID),
);
create table tbl_STAFF(
	Staff_ID nvarchar(20) not null primary key,
	Department_ID nvarchar(20) foreign key references tbl_DEPARTMENT(Department_ID),

	Staff_name nvarchar(255),
	Nick_name nvarchar(225),
	DOB datetime,
	
	CitizenID nvarchar(50),
	CitizenID_date datetime,
	CitizenID_place nvarchar(255),

	StartingWokdDate datetime,

	Goal_target real,
	Position nvarchar(255),
	Bank_Account_No nvarchar(100),
	Bank_name nvarchar(255),
	Insurance_No nvarchar(100),
	Phone_No nvarchar(100),
	Passwords nvarchar(20),
	Com_ID nvarchar(20) foreign key references tbl_COM(Com_ID),
);
insert into tbl_STAFF(Staff_ID, Staff_name, DOB, Passwords, Com_ID)
values
('M01@PND', N'PHẠM THỊ NGỌC NGÂN', '1986-10-11','1234', '0201975599'),
('M02@PND', N'PHẠM THỊ HẢI YẾN', '1986-10-08', '2345', '0201975599'),

('ADMIN@PND', N'PHÒNG ADMIN', '', 'PND@AD', '0201975599'),
('CEO@PND', N'PHÒNG ĐIỀU HÀNH', '', 'PND@CE', '0201975599'),
('KTOAN@PND', N'PHÒNG KẾ TOÁN', '', 'PND@KT', '0201975599'),
('NVU@PND', N'PHÒNG NGHIỆP VỤ', '', 'PND@NV', '0201975599'),
('NVQ@PND', N'PHÒNG NGHIỆP VỤ', '', 'PND@NVQ', '0201975599'),
('LGT@PND', N'PHÒNG NGHIỆP VỤ', '', 'PND@LGT', '0201975599');


create table tbl_CUSTOMER(
	Customer_ID nvarchar(20) not null primary key,  -- mã số thuế công ty
	Staff_ID nvarchar(20) foreign key references tbl_STAFF(Staff_ID),
	Company_Name nvarchar(255),
	Company_Namekd nvarchar(255),
	Com_Address nvarchar(1000),
	Com_Addresskd nvarchar(1000),
	Website nvarchar(255),
	Duty_Person nvarchar(255),
	Contact nvarchar(255),
	Email nvarchar(255),
	Com_DOB datetime,
	Bank_accountF nvarchar(255),
	bank_accountC nvarchar(255),
	Other nvarchar(255),
	Com_ID nvarchar(20) foreign key references tbl_COM(Com_ID),
);
create table tbl_SCUSTOMER(
	SCustumer_ID nvarchar(20) not null primary key,
	Staff_ID nvarchar(20) foreign key references tbl_STAFF(Staff_ID),
	Company_Name nvarchar(255),
	Com_address nvarchar(1000),
	Website nvarchar(255),
	Duty_Person nvarchar(255),
	Contact nvarchar(255),
	Email nvarchar(255),
	Com_DOB datetime,
	HCM_volume nvarchar(255),
	HP_volume nvarchar(255),
	DN_volume nvarchar(255),
	Other_volume nvarchar(255),
	Delivery_conditions nvarchar(255),
	Goods_type nvarchar(255),
	Good_name nvarchar(255),
	HS_code nvarchar(100),
	Foreign_port nvarchar(255),
	Import_country nvarchar(255),
	Export_country nvarchar(255),
	Term nvarchar(100),
	Payment_method nvarchar(255),
	Currency_code nvarchar(50),
	CK_export_name nvarchar(255),
	CK_export_code nvarchar(255),
);

create table tbl_SCUSTOMER_RELATIONSHIP(
	ID int not null primary key identity(1,1),
	SCustumer_ID nvarchar(20) foreign key references tbl_SCUSTOMER(SCustumer_ID),
	Cus_date datetime,
	Cus_satus nvarchar(1000),
	Scheme nvarchar(500),
	Other nvarchar(255),
);

create table tbl_SUPPLIER(
	Supplier_ID nvarchar(50) not null primary key,
	Name_sup nvarchar(255),
	Typer nvarchar(20),
	Address_sup nvarchar(255),
	Bank_accountF nvarchar(255),
	Bank_accountC nvarchar(255),
	LCC_Fee nvarchar(255),
	Note nvarchar(255),
	Com_ID nvarchar(20) foreign key references tbl_COM(Com_ID),
);

create table tbl_SUPPLIER_ACTION(
	ID int not null primary key identity(1,1),
	Supplier_ID nvarchar(50) foreign key references tbl_SUPPLIER(Supplier_ID),
	Person_in_charge nvarchar(255),
	Phone_number nvarchar(30),
	Email nvarchar(100),
	Note nvarchar(max)
);

create table AGENT(
	CODE nvarchar(20) not null primary key,
	Agent_name nvarchar(1000),
	Agent_namekd nvarchar(1000),
	Agent_add nvarchar(255),
	Bank_accountF nvarchar(255),
	bank_accountC nvarchar(255),
	Note nvarchar(255),
	Com_ID nvarchar(20) foreign key references tbl_COM(Com_ID),
);

create table AGENT_ACTION(
	ID int not null primary key identity(1,1),
	CODE nvarchar(20) foreign key references AGENT(CODE),
	Person_in_charge nvarchar(255),
	Phone_number nvarchar(30),
	Email nvarchar(100),
	Note nvarchar(max)
);

create table CARRIER(
	CODE nvarchar(20) not null primary key,
	Carrier_name nvarchar(255),
	Carrier_namekd nvarchar(255),
	Carier_add nvarchar(255),
	Bank_accountF nvarchar(255),
	bank_accountC nvarchar(255),
	Note nvarchar(255),
	Com_ID nvarchar(20) foreign key references tbl_COM(Com_ID),
);

create table CARRIER_ACTION(
	ID int not null primary key identity(1,1),
	CODE nvarchar(20) foreign key references CARRIER(CODE),
	Person_in_charge nvarchar(255),
	Phone_number nvarchar(30),
	Email nvarchar(100),
	LCC_Fee nvarchar(255),
	Note nvarchar(max),
);

create table tbl_SHIPPER(
	Shipper nvarchar(255) not null primary key,
	SAddress nvarchar(1000),
	SCity nvarchar(100),
	SPerson_in_charge nvarchar(255),
	TaxID	nvarchar(20),
	Com_ID nvarchar(20) foreign key references tbl_COM(Com_ID),
);

create table tbl_CNEE(
	CNEE nvarchar(255) not null primary key,
	VCNEE nvarchar(255),				-- new one
	CAddress nvarchar(1000),
	VAddress nvarchar(1000),			-- new one
	CCity nvarchar(100),
	CPerson_in_charge nvarchar(255),
	TaxID	nvarchar(20),
	HAddress nvarchar(1000),
	Com_ID nvarchar(20) foreign key references tbl_COM(Com_ID),
);

create table tbl_CNEE_ADD(
	ID int not null primary key identity(1,1),
	Adds nvarchar(500),
	Place nvarchar(255),
	PersonInCharge nvarchar(255),
	CNEE nvarchar(255) foreign key references tbl_CNEE(CNEE),
);

create table tbl_TUTT(
	SoTUTT nvarchar(50) not null primary key,
	Ngay datetime,
	NhanvienTUTT nvarchar(100),

	Noi_dung nvarchar(255),

	Thuong bit default 0,
	da bit default 0,
	
	ketoan bit default 0,
	ceo bit default 0,
	Ghi_chu nvarchar(255),

	Com_ID nvarchar(20) foreign key references tbl_COM(Com_ID),
);

create table tbl_TUTT_PHI(			-- thanh toan khong cho du an
	ID int not null primary key identity(1,1),
	SoHoaDon nvarchar(20),
	TenPhi nvarchar(255),
	TU bit DEFAULT 0,
	TT bit DEFAULT 0,
	SoTien float default 0,
	NghiChu nvarchar(255),

	SoTUTT nvarchar(50) foreign key references tbl_TUTT(SoTUTT),
);



create table tbl_JOB(
	Request_ID nvarchar(50) not null primary key,
	Job_ID nvarchar(50) not null,
	Goods_type nvarchar(20), 
	Job_date datetime default GETDATE() not null,
	MBL nvarchar(100),
	Issue_dateM datetime,
	OnBoard_dateM datetime,

	MBL_file varbinary(MAX),
	ShipperM nvarchar(1000),
	CNEEM nvarchar(1000),
	Notify_PartyM nvarchar(1000),
	Vessel_name nvarchar(100),
	Voyage_name nvarchar(100),

	POL nvarchar(255), -- port of loading
	POD nvarchar(255), -- port of destination
	PODel nvarchar(255), -- port of deliver
	PODis nvarchar(255),  -- port of discharge
	PlaceofReceipt nvarchar(255),
	PlaceofDelivery nvarchar(255),
	
	Pre_Cariage_by nvarchar(100),
	
	ETD datetime not null,
	ETA datetime not null,

	Mode nvarchar(100),

	Agent nvarchar(20) foreign key references AGENT(CODE),
	Carrier nvarchar(20) foreign key references CARRIER(CODE),
	
	Ycompany nvarchar(1000),
	Link nvarchar(500),
	YunLock int DEFAULT 0,
	Use_time int DEFAULT 2025,
	Com_ID nvarchar(20) foreign key references tbl_COM(Com_ID),

	--SoTUTT nvarchar(50) foreign key references tbl_TUTT(SoTUTT),
);

create table tbl_HBL(
	HBL nvarchar(50) not null primary key,
	Request_ID nvarchar(50) not null foreign key references tbl_JOB(Request_ID),
	Staff_ID nvarchar(20) not null foreign key references tbl_STAFF(Staff_ID),
	
	Issue_placeH nvarchar(255),
	Issue_dateH datetime,
	OnBoard_dateH datetime,
	HBL_file varbinary(MAX),
	Customer_ID nvarchar(20) not null foreign key references tbl_CUSTOMER(Customer_ID),

	Shipper nvarchar(255) not null foreign key references tbl_SHIPPER(Shipper),
	CNEE nvarchar(255)not null foreign key references tbl_CNEE(CNEE),
	Notify_party nvarchar(255),
	
	BL_type nvarchar(100),
	Nom_Free nvarchar(100) not null,

	Cont_Seal_No nvarchar(1000),
	Volume nvarchar(255),
	Quantity nvarchar(255),
	Goods_desciption nvarchar(255) default 'AS PER BILL',
	Gross_weight float default 0,
	Tonnage float default 0,

	Customs_declaration_No nvarchar(100),
	Invoice_No nvarchar(50),

	NumberofOrigins nvarchar(100),
	Freight_Payable nvarchar(100),
	
	Mark_Nos nvarchar(1000),

	Freight_charge bit DEFAULT 0,
	Prepaid bit DEFAULT 0,
	Collect bit DEFAULT 0,

	SI_No nvarchar(20),
	
	
	PIC nvarchar(255),
	DO_date datetime,
	PIC_phone nvarchar(20),


	DO_file varbinary(MAX),
	GGT_file varbinary(MAX),
);

create table tbl_TUTT_JOB(
	STT nvarchar(50) not null primary key,

	SoTUTT nvarchar(50) foreign key references tbl_TUTT(SoTUTT),
	HBL nvarchar(50) foreign key references tbl_HBL(HBL),
);


CREATE TABLE tbl_DELIVERYPFROOF(
	Del_ID nvarchar(50) not null primary key,
	Del_date datetime,
	HBL nvarchar(50),
	CNEE nvarchar(255),
	ADDs nvarchar(255),
	Place nvarchar(255),
	PersonInCharge nvarchar(255),
	TAX_ID nvarchar(50),
	TAX_CNEE nvarchar(255),
	TAX_ADDS nvarchar(255),
);

create table tbl_CONTH(
	ID int primary key not null identity(1,1),
	Cont_No nvarchar(255),
	HBL nvarchar(50) foreign key references tbl_HBL(HBL),
	Cont_quantity int default 0,
	Cont_type nvarchar(50),
	Seal_No nvarchar(255),
	Gross_weight float,
	CMB float,

	Goods_quantity nvarchar(255),

	Goods_depcription nvarchar(500),
);

CREATE TABLE tbl_DELIVERY_CONTH(
	DC_ID nvarchar(50) not null primary key,
	ID int foreign key references tbl_CONTH(ID),
	Del_ID nvarchar(50)references tbl_DELIVERYPFROOF(Del_ID),
);

create table KINDOFPACKAGES(
	CODE nvarchar(20) not null primary key,
	Package_name nvarchar(255),
	Packages_description nvarchar(255)
);

insert into KINDOFPACKAGES(CODE, Package_name) values
('BA', 'Barrels'),
('BE', 'Bundles'),
('BG', 'Bags'),
('BK', 'Baskets'),
('BL', 'Bales,compressed'),
('BN', 'Bales,non-compressed'),
('BR', 'Bars'),
('BX', 'Boxes'),
('CA', 'Cans, rectangular'),
('CG', 'Cages'),
('CK', 'Casks'),
('CL', 'Coils'),
('CN', 'Containers'),
('CO', 'Carboy, non-protected'),
('CP', 'Carboy, protected'),
('CR', 'Crates'),
('CS', 'Cases'),
('CT', 'Cartons'),
('CX', 'Cans, cylindrical'),
('CY', 'Cylinders'),
('DR', 'Drums'),
('KG', 'Kegs'),
('LG', 'Logs'),
('LZ', 'Logs, in bundle/bunch/truss'),
('MST', 'MST'),
('MT', 'Mats'),
('NE', 'Unpacked  or unpackaged'),
('NT', 'Nets'),
('PA', 'Packets'),
('PC', 'Parcels'),
('PE', 'Pens'),
('PG', 'Plates'),
('PI', 'Pipes'),
('PK', 'Packages'),
('PL', 'Pails'),
('PP', 'Pallets & Packages'),
('PS', 'Pieces'),
('PU', 'Trays'),
('RL', 'Rolls'),
('TY', 'Tanks'),
('ZZ', 'Others');


create table tbl_INVOICE(
	Debit_ID nvarchar(50) not null primary key,
	Invoice_type nvarchar(10) not null,
	Debit_date datetime default GETDATE(),
	Payment_date datetime,
	Invoice_No nvarchar(20),
	Invoice_date datetime,
	Supplier_ID nvarchar(50) foreign key references tbl_SUPPLIER(Supplier_ID),
	HBL nvarchar(50) foreign key references tbl_HBL(HBL),
);

create table tbl_CHARGES(
	ID int primary key not null identity(1,1),
	Debit_ID nvarchar(50) foreign key references tbl_INVOICE(Debit_ID),
	
	Exchange_rate real,
	Currency nvarchar(20), -- ngoại tệ
	
	Ser_Name nvarchar(255),
	Ser_Price real DEFAULT 0,
	Ser_Quantity real DEFAULT 0,
	Ser_Unit nvarchar(100),
	Ser_VAT real DEFAULT 0,
	M_VAT real DEFAULT 0,
	
	Buy bit DEFAULT 0,			    -- tiền mua
	Sell bit DEFAULT 0,				-- tiền bán
	Paybehalf bit DEFAULT 0,		-- tiền chi hộ
	
	Advance_payment bit DEFAULT 0,  -- tiền tạm ứng
	Refunds bit DEFAULT 0,			-- tiền hoàn ứng
	Cont bit DEFAULT 0,				-- tiền cược cont
	Checked bit DEFAULT 0,			-- kiểm tra hóa đơn của kế toán
);

create table INVOICE_TYPE(
	Code nvarchar(10) not null primary key,
	Name_type nvarchar (255),
);

insert into INVOICE_TYPE(code, Name_type) values
('A', 'Agent'),
('C', 'CNEE'),
('S', 'Shipper'),
('O', 'Others'),
('V', 'Vendor');

create table FEE(
	CODE nvarchar(255) not null primary key,
	FEE nvarchar(255),
	UNIT nvarchar(255),
	NOTE nvarchar(255),
);
insert into FEE(CODE, FEE, UNIT)
values
('ACI',					N'Phí khai hải quan tự động', 'SET'),
('AFR FEE',				N'Phí khai hải quan', 'SET'),
('AFS FEE',				N'Phí khai sơ lược hàng hóa', 'SET'),
('AMENDMENT FEE',		N'Phí sửa vận đơn', 'SET'),
('AMS FEE',				N'Phí khai hải quan tự động', 'SET'),
('AWB',					N'Phí chứng từ hàng xuất', 'SET'),
('BAF',					N'Phụ phí nhiên liệu', 'CBM'),
('BAF FEE',				N'Phụ phí nhiên liệu', 'SHIPMENT'),
('BL FEE',				N'Phí chứng từ hàng xuất', 'SET'),
('BL FEE+SUR FEE',		N'Phí vận đơn và điện giao hàng', 'SET'),
('C/O FEE',				N'Phí CO', 'SET'),
('CAXE',				N'Phí lưu ca xe', 'SHIPMENT'),
('CFS',					N'Phí khai thác hàng lẻ', 'CBM'),
('CFS-2',				N'Phí khai thác hàng lẻ', 'SHIPMENT'),
('CIC',					N'Phí CIC', 'CBM'),
('CIC-20`DC',			N'Phí mất cân bằng container', '20`DC'),
('CIC-20`OT',			N'Phí mất cân bằng container', '20`OT'),
('CIC-20`FR',			N'Phí mất cân bằng container', '20`FR'),
('CIC-40`FR',			N'Phí mất cân bằng container', '40`FR'),
('CIC-40`HC',			N'Phí mất cân bằng container', '40`HC'),
('CIC-FCL',				N'Phí mất cân bằng container', 'CONT'),
('CIC-SHPT',			N'Phí mất cân bằng container', 'SHIPMENT'),
('CLEANING FEE',		N'Phí vệ sinh cont', 'CONT'),
('CLEANING FEE-20',		N'Phí vệ sinh cont', '20'),
('CLEANING FEE-40',		N'Phí vệ sinh cont', '40'),
('CLEANING FEE-SHPT',	N'Phí vệ sinh cont', 'SHIPMENT'),
('CUSTOM FEE',			'', ''),
('D/O',					N'Phí lệnh giao hàng', 'SHIPMENT'),
('DDP',					N'Phí DDP',	'SET'),
('DEM FEE',				N'Phí lưu container', 'SHIPMENT'),
('DTHC-20`DC',			N'Phí xếp dỡ cảng nhập', '20`DC'),
('DTHC-20`FR',			N'Phí xếp dỡ cảng nhập', '20`FR'),
('DTHC-20`OT',			N'Phí xếp dỡ cảng nhập', '20`OT'),
('DTHC-40',				N'Phí xếp dỡ cảng nhập',	'40`HC'),
('DTHC-40`FR',			N'Phí xếp dỡ cảng nhập', '40`FR'),
('DTHC-FCL',			N'Phí xếp dỡ cảng nhập', 'CONT'),
('DTHC-LCL',			N'Phí xếp dỡ cảng nhập', 'CBM'),
('DTHC-SHPT',			N'Phí xếp dỡ cảng nhập', 'SHIPMENT'),
('DTHC-40`OT',			N'Phí xếp dỡ cảng nhập',	'40`OT'),
(N'DV KIỂM DỊCH',		N'Phí dịch vụ kiểm dịch',	'SHIPMENT'),
(N'DV LÀM HÀNG',		N'Phí dịch vụ làm hàng',	'SHIPMENT'),
('DVHQ',				N'Phí dịch vụ Hải Quan',	'CONT/SET'),
('DVHQ + VCND',			N'Phí dịch vụ hải quan và vận chuyển nội địa', 'SHIPMENT'),
('DVHQ2',				N'Phí dịch vụ hải quan', 'SET'),
('DVKD',				N'Phí dịch vụ kiểm dịch', 'CONT'),
('DVKH',				N'Phí dịch vụ kiểm hóa', 'CONT'),
('DVKH1',				N'Phí dịch vụ kiểm hóa', 'SHIPMENT'),
('EBS',					N'Phụ phí xăng dầu', 'CBM'),
('EMF',					N'Phí quản lý thiết bị', 'CONT'),
('ENS',					N'Phí ENS',	'BỘ'),
('EXPRESS FEE',			N'Phí dịch vụ giao nhận hàng hóa', 'SHIPMENT'),
('EXW',					N'PHÍ EXW',	'SHIPMENT'),
('FACILITY',			N'Phí xử lý hàng hóa',	'SHIPMENT'),
('FUMI',				N'Phí hun trùng',	'SHIPMENT'),
('GRI',					N'Phụ phí cước vận chuyển',	'CBM'),
('HANDLING',			N'Phí handling fee',	'SHIPMENT'),
('HANDLING-CONT',		N'Phí handling fee',	'CONT'),
('HT',					N'Phí Hun Trùng',	'SHIPMENT'),
('IMPORT',				N'Phí Import Tax',	'SET'),
('ISPS',				N'Phí khai báo an ninh',	'SET'),
('KG',					N'Phí đóng kiện gỗ',	'CBM'),
('LABOUR FEE',			N'Phí giao nhận, bốc xếp tại kho',	'CBM'),
('LABOUR FEE-2',		N'Phí giao nhận, bốc xếp tại kho',	'SHIPMENT'),
('LATE',				N'Phí trả chậm',	'SET'),
('LIFT ON-OFF',			N'Phí nâng hạ',	'40`HC'),
('LOCAL CHARGES',		N'Phụ phí địa phương',	'SHIPMENT'),
('LS',					N'Phí chuyển đổi nhiên liệu',	'SHIPMENT'),
('LSS',					N'Phí chuyển đổi nhiên liệu',	'CBM'),
('LSS-20`DC',			N'Phí chuyển đổi nhiên liệu',	'20`DC'),
('LSS-40',				N'Phí chuyển đổi nhiên liệu',	'40'),
('LSS-40`RF',			N'Phí chuyển đổi nhiên liệu',	'40`RF'),
('LSS FEE',				N'Phụ phí giảm thải lưu huỳnh',	'40`HC'),
('LSS FEE 20',			N'Phụ phí giảm thải lưu huỳnh',	'20`DC'),
('LSS-CFS',				N'Phí chuyển đổi nhiên liệu',	'SHIPMENT'),
('OCEAN FREIGHT',		'', ''),
('OTHC-20`DC',			N'Phí xếp dỡ hàng xuất',	'20`DC'),
('OTHC-40',				N'Phí xếp dỡ hàng xuất',	'40'),
('OTHC-FCL',			N'Phí xếp dỡ cảng xuất',	'CONT'),
('OTHC-LCL',			N'Phí xếp dỡ cảng xuất',	'CBM'),
('OVERTIME',			N'Phí dịch vụ ngoài giờ',	'SHIPMENT'),
('PACKING FEE',			N'Phí đóng kiện',	'CBM'),
('PALLET',				N'Phí đóng kiện',	'SHIPMENT'),
(N'PHÍ RÚT RUỘT CONTAINER',	N'Phí rút ruột container',	'CONT'),
('RR',					N'Phụ phí phục hồi giá',	'CBM'),
('SEAL',				N'Phí chì',	'CONT'),
('SEAL FEE',			N'Phí chì',	N'CHIẾC'),
('SURRENDER FEE',		N'Phí điện giao hàng',	'SET'),
('TELEX',				N'Phí điện giao hàng',	'SET'),
('THC FEE',				'', ''),
('TK,TQ',				N'Phí mở tờ khai, thông quan',	'SHIPMENT'),
('TRUCKING FEE',		N'Phí vận tải',	'SHIPMENT'),
('VC',					N'Phí vận chuyển nội địa',	'SET'),
('VCND',				N'Phí vận chuyển nội địa',	'SHIPMENT'),
('VCND HP-BV',			N'Cước vận chuyển nội địa Hải Phòng - Ba Vì',	'CONT'),
('VCND HP-TT',			N'Cước vận chuyển nội địa Hải Phòng - Thạch Thất',	'CONT'),
('VCNOIDIA',			N'Cước vận chuyển nội địa',	'CONT'),
('VCNOIDIA-LCL',		N'Cước vận chuyển nội địa',	'SHIPMENT'),
('VCNOIDIA2',			N'Cước vận chuyển nội địa',	'20`DC'),
('VCNOIDIA3',			N'Cước vận chuyển nội địa',	'40'),
('VCQT',				N'Cước vận chuyển quốc tế',	'CONT'),
('VCQT2',				N'Cước vận chuyển quốc tế',	'CBM/TON'),
('VCQT3',				N'Cước vận chuyển quốc tế',	'20`DC'),
('VCQT4',				N'Cước vận chuyển quốc tế',	'40`DC'),
('VCQT5',				N'Cước vận chuyển quốc tế',	'SHIPMENT'),
('VCQT6',				N'Cước vận chuyển quốc tế',	'40`HC'),
('X RAY',				N'Phí X RAY',	'KGS'),
('XL',					N'Phí xử lý hàng hóa thông thường',	'SHIPMENT');

create table MODE(
	CODE nvarchar(20) not null primary key,
	Note nvarchar(255)
);
insert into MODE(CODE)
values ('AIR/AIR'), ('CFS'), ('CFS/CFS'), ('CW'), ('CY/CY');

create table GOODS_TYPE(
	CODE nvarchar(20) not null primary key,
	GT_name nvarchar(255),
	Note nvarchar(255)
);
insert into GOODS_TYPE(CODE, GT_name, Note) 
values
('AI', 'Air Import', N'hàng không nhập'), 
('AE', 'Air Export', N'hàng không xuất'), 
('FCLI', 'Full Container Load Import', N'hàng nhập nguyên công'), 
('FCLE', 'Full Container Load Export', N'hàng xuất nguyên công'), 
('LCLI', 'Less-than Container Load Import', N'hàng lẻ nhập'), 
('LCLE', 'Less-than Container Load Export', N'hàng lẻ xuất'), 
('LGT', 'Logistics', N'hàng làm thủ tục hải quan');


create table BL_TYPE(
	CODE nvarchar(20) not null primary key,
	BL_name nvarchar(255),
	Note nvarchar(255)
);
insert into BL_TYPE(CODE)
values ('COPY'), ('DRAFT'), ('ORIGINAL'), ('SEWAY BILL'), ('SURRENDERED'), ('TELEX');

create table CURRENCY(
	CODE nvarchar(20) not null primary key,
	Curr_name nvarchar(255),
	Note nvarchar(255)
);
insert into CURRENCY(CODE, Curr_name) 
values 
('CNY', N'Tiền nhân dân tệ'), 
('EUR', N'Tiền chung châu âu'),
('GBP', N'Bảng Anh'),
('JPY', N'Tiền Yên'),
('KRW', N'Tiền hàn quốc'),
('SGD', N'Tiền singafore'),
('USD', N'Tiền đô Mỹ'),
('VND', N'Tiền việt nam');

create table SOURSE(
	CODE nvarchar(20) not null primary key,
	Sour_name nvarchar(255),
	Note nvarchar(255)
);
insert into SOURSE(CODE) 
values ('FREEHAND'), ('NOMI');

create table UNIT(
	CODE nvarchar(20) not null primary key,
	Unit_name nvarchar(255),
	Note nvarchar(255)
);

insert into UNIT(CODE) 
values ('20`DC'), ('20`GP'), ('20`OT'), ('20`RF'), ('40`GP'), ('40`HC'), ('40`OT'), ('40`FR'), ('CBM'), ('OT'), ('SHIPMENT');

create table SUP_TYPE(
	ID nvarchar(20) not null primary key,
	Note nvarchar(255),
);

insert into SUP_TYPE(ID) values
('AGENT'), ('CARRIER'), ('COLOADER'), ('VENDOR');

create table CPORT(
	CODE nvarchar(20) not null primary key,
	PORT_NAME nvarchar(255),
);

insert into CPORT(CODE, PORT_NAME) values
('VNATH', 'CANG AN THOI'),
('VNBAI', 'CUA KHAU BAC DAI'),
('VNBAN', 'CANG BA NGOI (K.HOA)'),
('VNBDA', 'DONG TAU BACH DANG'),
('VNBDC', 'CANG BINH DUC (LA)'),
('VNBDM', 'CANG BEN DAM (VT)'),
('VNBDU', 'CANG TONG HOP BDUONG'),
('VNBLG', 'CANG BINH LONG'),
('VNBMA', 'CANG BAO MAI (DT)'),
('VNBNG', 'CANG BEN NGHE (HCM)'),
('VNBTI', 'CANG BINH TRI (KG)'),
('VNCAL', 'CANG CAT LO (BRVT)'),
('VNCAM', 'CUA CAM'),
('VNCKI', 'CANG CTGK DKHI (VT)'),
('VNCLI', 'CANG CAT LAI (HCM)'),
('VNCLN', 'CANG CAI LAN (QNINH)'),
('VNCLO', 'CANG CUA LO (NG.AN)'),
('VNCLT', 'CANG XD CU LAO TAO'),
('VNCMT', 'CANG QT CAI MEP'),
('VNCMY', 'CANG CHAN MAY (HUE)'),
('VNCOP', 'CANG CONT. QT CAIMEP'),
('VNCPA', 'CANG CAM PHA (V.TAU)'),
('VNCPD', 'CP DINH VU'),
('VNCPH', 'CANG CAM PHA (QN)'),
('VNCRB', 'CANG CAM RANH(K.HOA)'),
('VNCUV', 'CANG CUA VIET(Q.TRI)'),
('VNCVE', 'CANG CHUA VE (HP)'),
('VNDAH', 'DAI HAI'),
('VNDAN', 'CANG DA NANG'),
('VNDAP', 'DAP'),
('VNDDG', 'CANG D.DONG-PQUOC'),
('VNDDN', 'CANG DIEM DIEN'),
('VNDDQ', 'CANG DOOSAN D.QUAT'),
('VNDHA', 'DONG HAI'),
('VNDKI', 'CANG DK NG.KHOI (VT)'),
('VNDNA', 'CANG DONG NAI'),
('VNDVN', 'CANG NAM DINH VU'),
('VNDNH', 'DINH VU NAM HAI'),
('VNDOC', 'CUA KHAU DONG DUC'),
('VNDQG', 'CANG QT GERMADEPT'),
('VNDQT', 'CANG D.QUAT - B.SO 1'),
('VNDTH', 'CANG DONG THAP'),
('VNDTS', 'CANG TIEN SA(D.NANG)'),
('VNDVU', 'CANG DINH VU - HP'),
('VNDXA', 'CANG DOAN XA - HP'),
('VNDXN', 'CANG KXD DONG XUYEN'),
('VNELF', 'CANG ELF GAZ DA NANG'),
('VNGAI', 'CANG GAS DAI HAI'),
('VNGAS', 'TOTAL GAS'),
('VNGDA', 'KHU TC GO DA (VT)'),
('VNGDU', 'CANG GO DAU (P.THAI)'),
('VNGEE', 'GREEN PORT (HP)'),
('VNHAL', 'CANG CA HA LONG'),
('VNHCH', 'CANG HON CHONG (KG)'),
('VNHDA', 'HAI DANG  (CELL GAS)'),
('VNHDI', 'HOANG DIEU (HP)'),
('VNHIA', 'CANG HAI AN'),
('VNHLA', 'CANG HON LA (Q.BINH)'),
('VNHLC', 'CANG HA LOC (V.TAU)'),
('VNHLH', 'C.CANG DK HAI LINH'),
('VNHLM', 'CANG HOLCIM (V.TAU)'),
('VNHON', 'CANG HON GAI (Q.N)'),
('VNHPH', 'CANG HAI PHONG'),
('VNHPN', 'TAN CANG HAI PHONG'),
('VNHPT', 'CANG TRANSVINA (HP)'),
('VNHPV', 'CANG VIETFRACHT (HP)'),
('VNHTC', 'VN HI-TECH TRANS. CO'),
('VNHTE', 'KHU CT PD HA TIEN'),
('VNHTH', 'CANG HAI THINH (ND)'),
('VNHTM', 'CANG HON THOM (KG)'),
('VNIFR', 'CANG INTERFLOUR (VT)'),
('VNKBH', 'CK KHANH BINH (AG)'),
('VNKHI', 'CANG KHANH HOI (HCM)'),
('VNKNN', 'K 99'),
('VNKYH', 'CANG KY HA (Q.NAM)'),
('VNLIL', 'LILAMA'),
('VNLIO', 'CANG LISEMCO'),
('VNLOT', 'CANG LOTUS (HCM)'),
('VNMCL', 'CATLAI OPENPORT(HCM)'),
('VNMTH', 'CANG MY THOI (AG)'),
('VNMUT', 'CANG MY THO (L.AN)'),
('VNNAU', 'NM D.TAU NAM TRIEU'),
('VNNBE', 'CANG NHA BE (HCM)'),
('VNNCN', 'CANG NAM CAN'),
('VNNGH', 'CANG NGHI SON(T.HOA)'),
('VNNHA', 'CANG NHA TRANG(KH)'),
('VNNHC', 'NAM HAI'),
('VNNNI', 'NAM NINH'),
('VNNPC', 'CANG NINH PHUC(NB)'),
('VNNRG', 'CANG NHA RONG (HCM)'),
('VNONN', 'CANG 19-9'),
('VNOSP', 'CANG SAI GON KV III'),
('VNPDQ', 'CANG DQUAT-BEN PHAO'),
('VNPHH', 'CANG PHU HUU'),
('VNPHU', 'CANG PHU MY (V.TAU)'),
('VNPLF', 'CANG ICD PHUOCLONG 1'),
('VNPLS', 'CANG ICD PHUOCLONG 2'),
('VNPLT', 'CANG ICD PHUOCLONG 3'),
('VNPMS', 'CANG PVC-MS (V.TAU)'),
('VNPMY', 'C PHU MY 2.1; 2.2-VT'),
('VNPOS', 'CANG POSCO (VT)'),
('VNPQY', 'CANG PHU QUY (D.NAI)'),
('VNPRU', 'DONG TAU PHA RUNG'),
('VNPTE', 'PETEC'),
('VNPTS', 'PTSC DINH VU'),
('VNPVS', 'CANG PV SHIPYARDS'),
('VNQDO', 'XD QUAN DOI (MIPEC)'),
('VNRRV', 'CANG QLRR VUNG TAU'),
('VNSAD', 'CANG SA DEC (DT)'),
('VNSDA', 'SONG DA 12.4'),
('VNSDG', 'CANG SON DUONG'),
('VNSGH', 'CANG SONG GIANH'),
('VNSGR', 'CANG RAU QUA (HCM)'),
('VNSGZ', 'CANG Z (HO CHI MINH)'),
('VNSIT', 'CANG SITV (VUNG TAU)'),
('VNSKY', 'CANG SA KY (B.DINH)'),
('VNSOC', 'CUA KHAU SONG DOC'),
('VNSPA', 'CANG SP-PSA (V.TAU)'),
('VNSPC', 'CANG HIEP PHUOC(HCM)'),
('VNSPT', 'CANG QT SP-SSA(SSIT)'),
('VNSRA', 'CANG SOAI RAP (DT)'),
('VNSSA', 'CANG CONT QUOC TE SG'),
('VNSTX', 'CANG STX OFFSHORE-VT'),
('VNTAP', 'CANG TAM HIEP'),
('VNTCC', 'C CAI MEP TCCT (VT)'),
('VNTCE', 'TAN CANG 128'),
('VNTCG', 'CANG TAN CANG (HCM)'),
('VNTCI', 'C CAI MEP TCIT (VT)'),
('VNTCM', 'CANG T.CANG -CAI MEP'),
('VNTCN', 'TAN CANG (189)'),
('VNTHC', 'C.KHAU THUONG PHUOC'),
('VNTHO', 'CANG THANH HOA'),
('VNTHS', 'CANG THANG LONG GAS'),
('VNTHU', 'CANG THUAN AN (HUE)'),
('VNTLY', 'XANG DAU THUONG LY'),
('VNTMN', 'CANG THEP MIEN NAM'),
('VNTRG', 'CANG TRUONG THANH '),
('VNTSN', 'CANG THUY SAN II'),
('VNTTD', 'CANG T.THUAN DONG'),
('VNTTS', 'CANG TAN THUAN (HCM)'),
('VNTVA', 'BEN CANG TH THI VAI'),
('VNUIH', 'CANG QUI NHON(BDINH)'),
('VNVAC', 'CANG VAT CACH (HP)'),
('VNVAG', 'CANG VUNG ANG(HTINH)'),
('VNVAN', 'CANG VAN AN (V.TAU)'),
('VNVCT', 'CANG CAN THO'),
('VNVDN', 'CANG VEDAN(DONG NAI)'),
('VNVGA', 'CANG VAN GIA (QN)'),
('VNVHD', 'CK VINH HOI DONG'),
('VNVIC', 'CANG VICT'),
('VNVNO', 'CANG VINA OFFSHORE'),
('VNVPH', 'CANG VAN PHONG'),
('VNVRO', 'CANG VUNG RO (P.YEN)'),
('VNVSP', 'CANG VIETSOV PETRO'),
('VNVTG', 'CANG PV.GAS (V.TAU)'),
('VNVTH', 'CANG HA LUU PTSC(VT)'),
('VNVTI', 'CANG VINH THAI(CTHO)'),
('VNVTP', 'CANG PTSC (VUNG TAU)'),
('VNVTT', 'CANG T.LUU PTSC (VT)'),
('VNVUT', 'CANG BA RIA VUNG TAU'),
('VNVXG', 'CK QT VINH XUONG(AG)'),
('VNXDG', 'CANG X.D.GA HOA LONG'),
('VNXDT', 'CANG XD DONG THAP'),
('VNXDV', 'XANG DAU DINH VU'),
('VNXHI', 'CANG XUAN HAI (HT)'),
('VNCBD', 'CANG BIEN DONG'),
('VNCBT', 'CANG BEN THUY NA'),
('VNCHS', 'CANG HAI SON'),
('VNCMC', 'CANG MUI CHUA'),
('VNCPX', 'CANG XIMANG CAM PHA'),
('VNCTN', 'CANG THI NAI'),
('VNCXP', 'CANG VIP GREEN PORT'),
('VNDAK', 'CANG DKHI BINH THUAN'),
('VNDCL', 'CANG XANGDAU CAI LAN'),
('VNDHP', 'CANG LPG DDONG HPHU'),
('VNDTV', 'DUYEN HAI TRA VINH'),
('VNDXC', 'CANG DONG XUYEN'),
('VNGQN', 'CANG ELF GAZ QNAM'),
('VNHUN', 'CK HUNG DIEN (LA)'),
('VNKHG', 'CANG KHACH HON GAI'),
('VNKHX', 'CANG XANG DAU K2'),
('VNLCU', 'PHAO LIEN CHIEU'),
('VNMKE', 'PHAO MY KHE'),
('VNMTC', 'CANG TAN CANG MTRUNG'),
('VNNHG', 'NEO CHUYEN HON GAI'),
('VNNTH', 'CANG NHON TRACH'),
('VNPEN', 'CANG PUMA ENERGY VN (HP)'),
('VNPPT', 'PHAO PETEC'),
('VNPSV', 'CANG POSCO SS VINA'),
('VNPTC', 'CANG PETEC CAIMEP'),
('VNPVO', 'PHAO PV OIL'),
('VNSCT', 'CANG SCT GAS'),
('VNSDD', 'KHU CT SONG DA DIEN'),
('VNSGF', 'CANG NM DONG TAU SG'),
('VNSMC', 'C. STRAGERIC MARINE'),
('VNTCH', 'TAN CANG HIEP PHUOC'),
('VNTCL', 'CANG TONGHOP CAILAN'),
('VNTCP', 'CANG THAN CAM PHA'),
('VNTHL', 'CANG DONG TAU H LONG'),
('VNVLC', 'CANG VINH LONG'),
('VNVSC', 'CANG VIET SEC'),
('VNVTC', 'CANG CAM PHA (VT)'),
('VNVTN', 'KHU NEO VUNG TAU'),
('VNXDB', 'CANG XANG DAU B12'),
('VNXSL', 'SANRIMJOHAP VINA'),
('VNXSM', 'CTY LD PHU DONG'),
('VNXSN', 'CTY LD LAFARGE'),
('VNXSO', 'CTY VOPAK VN'),
('VNXSP', 'CTY DAU KHI DONGTHAP'),
('VNXSQ', 'DN TM DV SV HONG MOC'),
('VNXSR', 'NM XI MANG THANGLONG'),
('VNXSS', 'NM XI MANG HA LONG'),
('VNXST', 'TONG CTY VOCARIMEX'),
('VNXSU', 'CTY TNHH MTV CANG SG'),
('VNXSV', 'CTY CN TAU THUY SG'),
('VNXSW', 'SAIGON SHIPMARIN'),
('VNXSX', 'CTY TNHH TOTALGAZ VN'),
('VNXSY', 'TONG CTY DAU VIETNAM'),
('VNXSZ', 'HOA DAU LAMTAICHANH'),
('VNYAA', 'CTY MTV DAUKHI HCM'),
('VNYAB', 'TONG KHO XANG NHA BE'),
('VNYAC', 'KHO VK102 QUAN KHU 7'),
('CNAQG', 'ANQING'),
('CNBAS', 'BASUO'),
('CNBAV', 'BAOTOU'),
('CNBAY', 'BAYUQUAN'),
('CNBHY', 'BEIHAI'),
('CNBJS', 'BEIJING'),
('CNCAN', 'GUANGZHOU'),
('CNCGD', 'CHANGDE'),
('CNCGO', 'ZHENGZHOU'),
('CNCGQ', 'CHANGCHUN'),
('CNCGU', 'CHANGSHU'),
('CNCIH', 'CHANGZHI'),
('CNCJG', 'CHANGJIAGANG'),
('CNCKG', 'CHONGQING'),
('CNCLJ', 'CHENGLINJI'),
('CNCNA', 'CHANGSHA'),
('CNCSX', 'CHANGSHA'),
('CNCTU', 'CHENGDU'),
('CNCWN', 'CHIWAN'),
('CNDAA', 'DAGANG'),
('CNDAT', 'DATONG'),
('CNDDG', 'DANDONG'),
('CNDLC', 'DALIAN'),
('CNDSN', 'DONGSHAN'),
('CNFAN', 'FANGCHENG'),
('CNFOC', 'FUZHOU'),
('CNFOS', 'FOSHAN'),
('CNGBP', 'GONGBEI'),
('CNHAK', 'HAIKOU'),
('CNHET', 'HOHHOT'),
('CNHFE', 'HEFEI'),
('CNHGH', 'HANGZHOU'),
('CNHLD', 'HAILAR'),
('CNHME', 'HAIMEN'),
('CNHNY', 'HENGYANG'),
('CNHRB', 'HARBIN'),
('CNHUA', 'HUANGPU'),
('CNHUI', 'HUIZHOU'),
('CNINC', 'YINCHUAN'),
('CNJDZ', 'JINGDEZHEN'),
('CNJIA', 'JIANGYIN'),
('CNJIU', 'JIUJIANG'),
('CNJJN', 'JINJIANG'),
('CNJMN', 'JIANGMEN'),
('CNJMU', 'JIAMUSI'),
('CNJNZ', 'JINZHOU'),
('CNKHG', 'KASHI'),
('CNKHN', 'NANCHANG'),
('CNKMG', 'KUNMING'),
('CNKNC', 'JIAN'),
('CNKWE', 'GUIYANG'),
('CNKWL', 'GUILIN'),
('CNLHW', 'LANZHOU'),
('CNLKU', 'LONGKOU'),
('CNLSN', 'LANSHAN'),
('CNLXA', 'LHASA'),
('CNLYG', 'LIANYUNGANG'),
('CNLYI', 'LINYI'),
('CNLZH', 'LIUZHOU'),
('CNMAA', 'MAANSHAN'),
('CNMAW', 'MAWEI'),
('CNMLX', 'MANZHOULI'),
('CNMWN', 'MAWAN'),
('CNNAH', 'NANHAI'),
('CNNAO', 'NANCHONG'),
('CNNGB', 'NINGBO'),
('CNNKG', 'NANJING'),
('CNNNG', 'NANNING'),
('CNNNY', 'NANYANG'),
('CNNSA', 'NANSHA'),
('CNNTG', 'NANTONG'),
('CNPEK', 'CAPITAL INTERNATIONA'),
('CNPIN', 'PINGXIANG'),
('CNPVG', 'PUDONG'),
('CNQLN', 'QINGLAN'),
('CNQZH', 'QINZHOU'),
('CNQZJ', 'QUANZHOU'),
('CNRLC', 'ERENHOT'),
('CNROQ', 'RONGQI'),
('CNRZH', 'RIZHAO'),
('CNSDG', 'SHUIDONG'),
('CNSFE', 'SUIFENHE'),
('CNSHA', 'SHANGHAI'),
('CNSHD', 'SHIDAO'),
('CNSHE', 'SHENYANG'),
('CNSHG', 'SANSHAN'),
('CNSHK', 'SHEKOU'),
('CNSHP', 'QINHUANGDAO'),
('CNSHS', 'SHASHI'),
('CNSIA', 'XI AN'),
('CNSJQ', 'SANSHUI'),
('CNSJW', 'SHIJIAZHUANG'),
('CNSNW', 'SHENWAN'),
('CNSUD', 'SHUNDE'),
('CNSUI', 'SUIGANG HUANGPU'),
('CNSWA', 'SHANTOU'),
('CNSWE', 'SHANWEI'),
('CNSYM', 'SIMAO'),
('CNSYX', 'SANYA'),
('CNSZH', 'SUZHOU'),
('CNSZX', 'SHENZHEN'),
('CNTAG', 'TAICANG'),
('CNTAO', 'QINGDAO'),
('CNTAP', 'TAIPING'),
('CNTAS', 'TANGSHAN'),
('CNTEN', 'TONGREN'),
('CNTGU', 'TANGGU'),
('CNTME', 'TUMEN'),
('CNTNA', 'JINAN'),
('CNTOL', 'TONGLING'),
('CNTSN', 'TIANJIN'),
('CNTXG', 'TIANJINXINGANG'),
('CNTXN', 'TUNXI'),
('CNTYN', 'TAIYUAN'),
('CNURC', 'URUMQI'),
('CNUYN', 'YULIN'),
('CNWEH', 'WEIHAI APT'),
('CNWEI', 'WEIHAI'),
('CNWHI', 'WUHU'),
('CNWNZ', 'WENZHOU'),
('CNWUH', 'WUHAN'),
('CNWUX', 'WUXI'),
('CNWUZ', 'WUZHOU'),
('CNXAV', 'XIAN'),
('CNXIN', 'XINHUI'),
('CNXMN', 'XIAMEN'),
('CNXNN', 'XINING'),
('CNXUZ', 'XUZHOU'),
('CNYAN', 'YANGSHAN'),
('CNYIC', 'YICHANG'),
('CNYIK', 'YINGKOU'),
('CNYIN', 'YINING'),
('CNYJI', 'YANGJIANG'),
('CNYNT', 'YANTAI'),
('CNYQS', 'BEIJIAO'),
('CNYTN', 'YANTIAN'),
('CNYZH', 'YANGZHOU'),
('CNZAP', 'ZHAPU'),
('CNZHA', 'ZHANJIANG'),
('CNZHE', 'ZHENJIANG'),
('CNZJA', 'ZHANJIAKOU'),
('CNZJG', 'ZHANGJIAGANG'),
('CNZOS', 'ZHOUSHAN'),
('CNZQG', 'ZHAOQING'),
('CNZSN', 'ZHONGSHAN'),
('CNZUH', 'ZHUHAI'),
('CNZZU', 'ZHANGZHOU'),
('CNZZZ', 'OTHER'),
('INAGR', 'AGRA'),
('INALF', 'ALLEPPEY'),
('INAMD', 'AHMEDABAD'),
('INATQ', 'AMRITSAR'),
('INBBI', 'BHUBANESWAR'),
('INBDQ', 'VADODARA (BARODA)'),
('INBED', 'BEDI'),
('INBET', 'BETUL'),
('INBEY', 'BEYPORE'),
('INBHJ', 'BHUJ'),
('INBHO', 'BHOPAL'),
('INBHU', 'BHAVNAGAR'),
('INBLK', 'BELEKERI'),
('INBLR', 'BANGALORE'),
('INBND', 'BANDDAR'),
('INBOM', 'MUMBAI(EX BOMBAY)'),
('INCAM', 'CAMBAY'),
('INCAR', 'CARIJAM'),
('INCBL', 'CHANDBALI'),
('INCCJ', 'KOZHIKODE'),
('INCCU', 'KOLKATA'),
('INCDL', 'CUDDALORE'),
('INCJB', 'COIMBATORE'),
('INCLC', 'CALICUT (KOZHIKODE)'),
('INCOH', 'COOCH BEHAR'),
('INCOK', 'COCHIN'),
('INCOL', 'COLOCHEL'),
('INCOO', 'COONDAPUR'),
('INCUM', 'CUTCH MANDVI'),
('INDAH', 'DAHEJ'),
('INDAI', 'DARJEELING'),
('INDAM', 'DAMAN'),
('INDED', 'DEHRA DUN'),
('INDEL', 'DELHI'),
('INDIB', 'DIBRUGARH'),
('INDIU', 'DIU'),
('INDMU', 'DIMAPUR'),
('INDUR', 'DURGAPUR'),
('INDWA', 'DWARKA'),
('INENR', 'ENNORE'),
('INFAR', 'FARRAKKA'),
('INGAU', 'GAUHATI'),
('INGAY', 'GAYA'),
('INGOI', 'GOA'),
('INGOP', 'GORAKHPUR'),
('INGPR', 'GOPALPUR'),
('INGUD', 'GUDUR'),
('INGWL', 'GWALIOR'),
('INHAL', 'HALDIA'),
('INHJR', 'KHAJURAHO'),
('INHON', 'HONAVAR'),
('INHYD', 'HYDERABAD'),
('INHZR', 'HAZIRA'),
('INIDR', 'INDORE'),
('INIMF', 'IMPHAL'),
('INISK', 'NASIK'),
('INIXA', 'AGARTALA'),
('INIXB', 'BAGDOGRA'),
('INIXC', 'CHANDIGARH'),
('INIXD', 'ALLAHABAD'),
('INIXE', 'MANGALORE (NEW MANGA)'),
('INIXG', 'BELGAUM'),
('INIXH', 'KAILASHAHAR'),
('INIXI', 'LILABARI'),
('INIXJ', 'JAMMU'),
('INIXK', 'KESHOD'),
('INIXL', 'LEH'),
('INIXM', 'MADURAI'),
('INIXN', 'KHOWAI'),
('INIXP', 'PATHANKOT'),
('INIXQ', 'KAMALPUR'),
('INIXR', 'RANCHI'),
('INIXS', 'SILCHAR'),
('INIXT', 'PASIGHAT'),
('INIXU', 'AURANGABAD'),
('INIXW', 'JAMSHEDPUR'),
('INIXY', 'KANDLA'),
('INIXZ', 'PORT BLAIR - ANDAMAN'),
('INJAI', 'JAIPUR'),
('INJAK', 'JAKHAU'),
('INJDH', 'JODHPUR'),
('INJGA', 'JAMNAGAR'),
('INJLR', 'JABALPUR'),
('INJRH', 'JORHAT'),
('INKAK', 'KAKINADA'),
('INKAT', 'KATHIAWAR'),
('INKBT', 'KHAMBHAT'),
('INKNU', 'KANPUR'),
('INKOD', 'KODINAR'),
('INKOI', 'KOILTHOLTAM'),
('INKOK', 'KOKA'),
('INKRI', 'KRISHNAPATAM'),
('INKRK', 'KARIKAL'),
('INKRW', 'KARWAR'),
('INKUU', 'KULU'),
('INLKO', 'LUCKNOW'),
('INMAA', 'CHENNAI (EX MADRAS)'),
('INMAH', 'MAHE'),
('INMAL', 'MALPE'),
('INMAP', 'MASULIPATNAM'),
('INMDA', 'MAGDALLA'),
('INMDP', 'MANDAPAM'),
('INMGR', 'MANGROL'),
('INMLI', 'MAROLI'),
('INMOH', 'MOHANBARI'),
('INMRM', 'MORMUGAO'),
('INMUN', 'MUNDRA'),
('INMUR', 'MURAD'),
('INMZA', 'MUZAFFARNAGAR'),
('INMZU', 'MUZAFFARPUR'),
('INNAG', 'NAGPUR'),
('INNAN', 'NANCOWRIE'),
('INNAV', 'NAVALAKHI'),
('INNEE', 'NEENDHAKARA'),
('INNEL', 'NELLORE'),
('INNML', 'NEW MANGALORE (MANGA'),
('INNPT', 'NAGAPPATTINAM'),
('INNSA', 'NHAVA SHEVA'),
('INOKH', 'OKHA'),
('INPAN', 'PANAJI - GOA'),
('INPAT', 'PATNA'),
('INPAV', 'PIPAVAV (VICTOR) POR'),
('INPBD', 'PORBANDAR'),
('INPGH', 'PANTNAGAR'),
('INPID', 'PORT INDAI'),
('INPIN', 'PINDHARA'),
('INPNQ', 'POONA'),
('INPNY', 'PONDICHERRY'),
('INPRT', 'PARADIP'),
('INPUL', 'PULICAT'),
('INPUR', 'PURI'),
('INQUI', 'QUILON'),
('INRAJ', 'RAJKOT'),
('INRAM', 'RAMESHWARAM'),
('INRED', 'REDI'),
('INRPR', 'RAIPUR'),
('INRRI', 'RAIRI'),
('INRRK', 'ROURKELA'),
('INRTC', 'RATNAGIRI'),
('INRUP', 'RUPSI'),
('INSAL', 'SALAYA'),
('INSHI', 'SHIRODA'),
('INSHL', 'SHILLONG'),
('INSIK', 'SIKA'),
('INSTV', 'SURAT'),
('INSXR', 'SRINAGAR'),
('INTAD', 'TADRIP'),
('INTEI', 'TEZU'),
('INTEL', 'TELLICHERRY'),
('INTEZ', 'TEZPUR'),
('INTIR', 'TIRUPATI'),
('INTIV', 'TIVIRI'),
('INTRA', 'TRANQUEBAR'),
('INTRV', 'TRIVANDRUM'),
('INTRZ', 'TIRUCHIRAPALLI'),
('INTUT', 'TUTICORIN (NEW TUTIC'),
('INUDR', 'UDAIPUR'),
('INUMB', 'UMBERGAON (GUJARAT)'),
('INVAD', 'VADINAR'),
('INVEP', 'VEPPALODAI'),
('INVGA', 'VIJAYAWADA'),
('INVNS', 'VARANASI (BENARES)'),
('INVTZ', 'VISAKHAPATNAM'),
('INVVA', 'VERAVAL'),
('INZZZ', 'OTHER');

create table tbl_LOG(
	ID nvarchar(50) not null primary key,
	Username nvarchar(50),
	WAN_IP nvarchar(20),
	Login_time datetime,
	Logout_time datetime,
);

create table tbl_HSCODE(
	ID int primary key not null identity(1,1),
	HS_CODE nvarchar(10),
	
	Mo_ta_hang_hoaV nvarchar(500),

	Mo_ta_hang_hoaE nvarchar(500),
	
	Don_vi_tinh nvarchar(50),

	Xuat_xu nvarchar(100),
	Ma_bieu_mau_thue_NK nvarchar(255),

	Thue_NK_TT float default 0,
	Thue_NK_UD float default 0,
	
	Thue_VAT nvarchar(100),
	ACFTA float default 0,
	ATIGA float default 0,
	AJCEP float default 0,
	VJEPA float default 0,
	AKFTA float default 0,
	AANZFTA float default 0,
	AIFTA float default 0,
	VKFTA float default 0,
	VCFTA float default 0,
	VN_EAEU float default 0,
	CPTPP float default 0,
	AHKFTA float default 0,
	VNCU float default 0,
	EVFTA float default 0,
	UKVFTA float default 0,
	VN_LAO float default 0,
	RCEPT_A float default 0,
	RCEPT_B float default 0,
	RCEPT_C float default 0,
	RCEPT_D float default 0,
	RCEPT_E float default 0,
	RCEPT_F float default 0,
	TTDB float default 0,
	XK float default 0,
	XKCPTPP float default 0,
	XKEV float default 0,
	XKUKV float default 0,
	Thue_BVMT nvarchar(100),
	Chinh_sach_hang_hoa nvarchar(1000),

	Chinh_sach_hang_hoakd nvarchar(1000),
	Mo_ta_hang_hoaVkd nvarchar(500),
	Loai_form nvarchar(255),
);

CREATE TABLE Quotations (
    QuotationID nvarchar(50) not null primary key,
	Qsatus nvarchar(255),

	Staff_ID nvarchar(20),
	contact nvarchar(100),
	Qdate datetime,
	

	CusTo nvarchar(255),
	CusContact nvarchar(255),
	Valid datetime,

    Term NVARCHAR(255),
    Vol NVARCHAR(255),
	Commodity NVARCHAR(255),

    POL NVARCHAR(255),
    ADDs NVARCHAR(255),
    POD NVARCHAR(255),
    
	
	Com_ID nvarchar(20) foreign key references tbl_COM(Com_ID),
);

CREATE TABLE Quotations_Charges (
    ChargeID int primary key not null identity(1,1),
    QuotationID nvarchar(50) FOREIGN KEY REFERENCES Quotations(QuotationID),
    
    ChargeName NVARCHAR(255),

	Quantity float default 1,
	Unit nvarchar(255),

	rate float default 0,
    
    Currency NVARCHAR(10),
    Notes NVARCHAR(255),
);





