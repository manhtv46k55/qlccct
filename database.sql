CREATE DATABASE CCCT2019;

/* Bảng Loại việc đơn vị thực hiện - công chứng - chứng thực - công chứng + chứng thực*/

CREATE TABLE LoaiVBDVTH(
  ID INT NOT NULL PRIMARY KEY IDENTITY,
  Name NVARCHAR(500) NOT NULL,
  IsActive INT NOT NULL
);

/*Bảng Đơn vị - sở -tt, huyện - xã - văn phòng công chứng*/
CREATE TABLE Donvi(
	ID INT NOT NULL PRIMARY KEY IDENTITY,
	ParentID INT NULL,
	[Type] INT NULL,
	Madonvi NVARCHAR(500) NOT NULL,
	Tendonvi NVARCHAR(500) NOT NULL,
	Diachi NVARCHAR(500) NOT NULL,
	LoaivbdvthID INT FOREIGN KEY REFERENCES [LoaiVBDVTH] (ID),
	CreateDate DATETIME NOT NULL,
	IsActive INT NOT NULL
);

/*Bảng Công chứng viên*/
CREATE TABLE Congchungvien(
	ID INT PRIMARY KEY IDENTITY NOT NULL,
	Hoten NVARCHAR(500) NOT NULL,
	Chucvu NVARCHAR(500) NULL,
	Sodienthoai NVARCHAR(500) NULL,
	Email NVARCHAR(500) NULL,
	Donvi INT FOREIGN KEY REFERENCES [Donvi] (ID),
	CreateDate DATETIME NOT NULL,
	IsActive INT NOT NULL
);

/*Bảng Người chứng thực*/
CREATE TABLE Nguoichungthuc(
	ID INT PRIMARY KEY IDENTITY NOT NULL,
	Hoten NVARCHAR(500) NOT NULL,
	Chucvu NVARCHAR(500) NULL,
	Sodienthoai NVARCHAR(500) NULL,
	Email NVARCHAR(500) NULL,
	Donvi INT FOREIGN KEY REFERENCES [Donvi] (ID),
	CreateDate DATETIME NOT NULL,
	IsActive INT NOT NULL
);

/*Bảng Người dùng - trong hệ thống*/
CREATE TABLE [User](
	ID INT PRIMARY KEY IDENTITY NOT NULL,
	UserName VARCHAR(500) NOT NULL,
	PassWord NVARCHAR(500) NOT NULL,
	Hoten NVARCHAR(500) NULL,
	Chucvu NVARCHAR(500) NULL,
	Ngaysinh DATE NULL,
	Sodienthoai NVARCHAR(500) NULL,
	Email NVARCHAR(500) NULL,
	Diachi NVARCHAR(500) NULL,
	Avatar NVARCHAR(500) NULL,
	Donvi INT FOREIGN KEY REFERENCES [Donvi] (ID),
	CreateDate DATETIME NOT NULL,
	IsAdmin INT NOT NULL,
	IsActive INT NOT NULL);

/*Bảng Quyền - trong hệ thống*/
CREATE TABLE [Permissions](
	ID INT NOT NULL PRIMARY KEY IDENTITY,
	Name VARCHAR(500) NOT NULL,
	[Description] NVARCHAR(500) NULL,
	UserID INT FOREIGN KEY REFERENCES [User] (ID)
);

/*Bảng Ngăn chặn - giải tỏa*/
CREATE TABLE NganchanGiaitoa(
	ID INT PRIMARY KEY IDENTITY NOT NULL,
	LoaiVB INT NOT NULL, /*1 là ngăn chặn - 2 là giải tỏa*/
	SoGCN NVARCHAR(500) NOT NULL,
	Ngaycap DATE NULL,
	Noicap NVARCHAR (500) NULL,
	Chusohuu NVARCHAR(500) NOT NULL,
	Diachichusohuu NVARCHAR(500) NULL,
	Thuadatso NVARCHAR(500) NULL,
	Bandoso NVARCHAR(500) NULL,
	Diachithuadat NVARCHAR(500) NULL,
	Dientich NVARCHAR(500) NULL,
	Sudungchung NVARCHAR(500) NULL,
	Sudungrieng NVARCHAR(500) NULL,
	Mucdichsudung NVARCHAR(500) NULL,
	Ngaygiaitoa DATE NULL,
	Thoihansudung NVARCHAR(500) NULL,
	Nguongoc NVARCHAR(500) NULL,
	Sokyhieu NVARCHAR(500) NULL,
	NgayVB DATE NULL,
	Trichyeu NVARCHAR(500) NULL,
	Noigui NVARCHAR(100) NULL,
	Filedinhkem NVARCHAR(3000) NULL,
	Lydo NVARCHAR(500) NULL,
	Demncgt INT NULL,
	UserID INT FOREIGN KEY REFERENCES [User] (ID),
	CreateDate DATETIME NOT NULL,
	IsActive INT NOT NULL,
);

/*bảng Hợp đồng công chứng - chứng thực*/

CREATE TABLE HopdongCCCT(
	ID INT PRIMARY KEY IDENTITY NOT NULL,
	Tenhopdong NVARCHAR(500) NOT NULL,
	IsActive INT NOT NULL
);

/*Bảng Mẫu hợp đồng*/

CREATE TABLE Mauhopdong(
	ID INT PRIMARY KEY IDENTITY NOT NULL,
	Tenmauhopdong NVARCHAR(500) NOT NULL,
	HopdongccctID INT FOREIGN KEY REFERENCES [HopdongCCCT] (ID),
	IsActive INT NOT NULL
);
/*Bảng chi tiết hợp đồng*/

/*MỤC hợp đồng cá nhân - Doanh nghiệp*/
		/*Bảng Loại quan hệ - cá nhân - doanh nghiệp*/

		CREATE TABLE LoaiQH(
			ID INT PRIMARY KEY IDENTITY NOT NULL,
			TenQH NVARCHAR(500) NOT NULL
			);

		/*Bảng cá nhân*/
		CREATE TABLE Canhan(
			ID INT PRIMARY KEY IDENTITY NOT NULL,
			ParentID INT NULL,
			Hoten NVARCHAR(500) NOT NULL,
			Ngaysinh DATE NOT NULL,
			SoCMND DECIMAL NOT NULL,
			NgaycapCMND DATE NOT NULL,
			NoicapCMND	NVARCHAR(500) NOT NULL,
			Hokhau NVARCHAR(500) NULL,
			Diachilienhe NVARCHAR(500) NULL,
			Sodienthoai DECIMAL NULL,
			SoTKNH DECIMAL NULL,
			Nganhang NVARCHAR(500) NULL,
			Masothue NVARCHAR(500) NULL,
			CreateDate DATETIME NOT NULL,
			LoaiqhID INT FOREIGN KEY REFERENCES [LoaiQH] (ID),
			IsActive INT NOT NULL
		);

		/*Bảng doanh nghiệp*/

		CREATE TABLE Doanhnghiep(
			ID INT PRIMARY KEY IDENTITY NOT NULL,
			ParentID INT NULL,
			Tendoanhnghiep NVARCHAR(500) NOT NULL,
			Diachilienhe NVARCHAR(500) NULL,
			GiayphepKD NVARCHAR(500) NOT NULL,
			Masodoanhnghiep NVARCHAR(500) NULL,
			Nguoidaidien NVARCHAR(500) NULL,
			Chucvu NVARCHAR(500) NULL,
			Masothue NVARCHAR(500) NULL,
			SoTKNH DECIMAL NULL,
			Nganhang NVARCHAR(500) NULL,
			CreateDate DATETIME NOT NULL,
			LoaiqhID INT FOREIGN KEY REFERENCES [LoaiQH] (ID),
			IsActive INT NOT NULL
		);

		/*Bảng Bên A*/

		CREATE TABLE BenA(
			ID INT PRIMARY KEY IDENTITY NOT NULL,
			Name NVARCHAR(500) NULL,
			LoaiqhID INT FOREIGN KEY REFERENCES [LoaiQH] (ID),
			);
		/*Bảng Bên B*/

		CREATE TABLE BenB(
			ID INT PRIMARY KEY IDENTITY NOT NULL,
			Name NVARCHAR(500) NULL,
			LoaiqhID INT FOREIGN KEY REFERENCES [LoaiQH] (ID),
			);


		/*Bảng chi tiết hợp đồng*/
		CREATE TABLE Chitiethopdong(
			ID INT PRIMARY KEY IDENTITY NOT NULL,
			Tenchitiethopdong NVARCHAR(500) NULL,
			MauhopdongID INT FOREIGN KEY REFERENCES [Mauhopdong] (ID),
			BenAID INT FOREIGN KEY REFERENCES [BenA] (ID),
			BenBID INT FOREIGN KEY REFERENCES [BenB] (ID),
			IsActive INT NOT NULL
		);

		/*Bảng HỢP ĐỒNG KHÁC*/
		CREATe TABLE Hopdongkhac(
			ID INT PRIMARY	KEY IDENTITY NOT NULL,
			Name NVARCHAR(500) NOT NULL,
			MauhopdongID INT FOREIGN KEY REFERENCES [Mauhopdong] (ID),
			BenAID INT FOREIGN KEY REFERENCES [BenA] (ID),
			BenBID INT FOREIGN KEY REFERENCES [BenB] (ID)
			);


						