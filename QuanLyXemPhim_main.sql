

--- Tạo Database
CREATE DATABASE QuanLyXemPhim
GO

USE QuanLyXemPhim
GO 


CREATE TABLE NhanVien
(
	idNV VARCHAR(50) PRIMARY KEY,
	HoTen NVARCHAR(100) NOT NULL,
	NgaySinh DATE NOT NULL,
	DiaChi NVARCHAR(100),
	SDT VARCHAR(100),
	CMND INT NOT NULL Unique	
)
GO

CREATE TABLE TaiKhoan
(
	UserName NVARCHAR(100) NOT NULL,
	Pass VARCHAR(1000) NOT NULL,
	LoaiTK INT NOT NULL DEFAULT 2, -- 1:admin || 2:staff
	idNV VARCHAR(50) NOT NULL,

	FOREIGN KEY (idNV) REFERENCES dbo.NhanVien(idNV)
)
GO

CREATE TABLE PhongChieu
(
	MaPhong VARCHAR(50) PRIMARY KEY,
	TenPhong NVARCHAR(100) UNIQUE NOT NULL,
	SoChoNgoi INT NOT NULL,
	TinhTrang INT NOT NULL DEFAULT 1, -- 0:không hoạt động || 1:đang hoạt động
	SoHangGhe int not null,
	SoGheMotHang int not null,
	--- Điều kiện SoHangGhe x SoGheMotHang == SochoNgoi
	CONSTRAINT CK_seat CHECK (SoHangGhe * SoGheMotHang = SoChoNgoi)
	--FOREIGN KEY (idManHinh) REFERENCES dbo.LoaiManHinh(id)
)
GO

CREATE TABLE Phim
(
	MaPhim varchar(50) PRIMARY KEY,
	TenPhim nvarchar(100) NOT NULL,
	MoTa nvarchar(1000) NULL,
	ThoiLuong float NOT NULL,
	NgayKhoiChieu date NOT NULL,
	NgayKetThuc date NOT NULL,
	QuocGia nvarchar(50) NOT NULL,
	DaoDien nvarchar(100) NULL,
	NamSX int NOT NULL,
	GioiHanTuoi int NOT NULL
)
GO


CREATE TABLE TheLoai
(
	MaLoaiPhim VARCHAR(50) PRIMARY KEY,
	TenTheLoai NVARCHAR(100) NOT NULL,
)
GO


CREATE TABLE PhanLoaiPhim --Quan hệ giữa Phim và LoaiPhim là quan hệ n-n, một phim có thể có nhiều thể loại
(
	idPhim VARCHAR(50) NOT NULL,
	idTheLoai VARCHAR(50) NOT NULL,

	FOREIGN KEY (idPhim) REFERENCES dbo.Phim(MaPhim),
	FOREIGN KEY (idTheLoai) REFERENCES dbo.TheLoai(MaLoaiPhim),

	CONSTRAINT PK_PhanLoaiPhim PRIMARY KEY(idPhim,idTheLoai)
)
GO

CREATE TABLE CaChieu
(
	MaCaChieu VARCHAR(50) PRIMARY KEY,
	ThoiGianChieu DATETIME NOT NULL,
	ThoiGianKetThuc DATETIME NOT NULL,
	MaPhong VARCHAR(50) NOT NULL,
	MaPhim VARCHAR(50) NOT NULL,
	-- Qui định giá vé cho 1 ca chiếu --
	GiaVe Money NOT NULL,
	TrangThai INT NOT NULL DEFAULT '0', --0: Chưa tạo vé cho Ca chiếu || 1: Đã tạo vé

	CONSTRAINT UC_CaChieu UNIQUE(MaPhim, MaPhong, ThoiGianChieu),

	FOREIGN KEY (MaPhong) REFERENCES dbo.PhongChieu(MaPhong),
	FOREIGN KEY (MaPhim) REFERENCES dbo.Phim(MaPhim),

	--CONSTRAINT PK_CaChieu PRIMARY KEY(ThoiGianChieu,ThoiGianKetThuc,MaPhong) --Vì cùng 1 thời điểm có thể có nhiều phòng cùng hoạt động nên khóa chính phải là cả 3 cái
)
GO

-- Tạo bảng khách hàng ---
CREATE TABLE KhachHang(
	MaKH INT PRIMARY KEY IDENTITY(1,1),
	TenKhachHang NVARCHAR(50) NOT NULL,
	Diachi NVARCHAR(100),
	NamSinh INT NOT NULL,
	SoDienThoai VARCHAR (50),
	DiemTichLuy INT DEFAULT 0
)
GO


CREATE TABLE Ve
(
	id int identity(1,1) PRIMARY KEY,
	LoaiVe INT  DEFAULT '0', --0: Vé người lớn || 1: Vé học sinh - sinh viên || 2: vé trẻ em
	MaCaChieu VARCHAR(50),
	MaGheNgoi VARCHAR(50),
	MaKhachHang INT,
	TrangThai INT NOT NULL DEFAULT '0', --0: 'Chưa Bán' || 1: 'Đã Bán'
	TienBanVe MONEY DEFAULT '0' --- Tổng vé sau khi áp mã giảm giá

	FOREIGN KEY (MaCaChieu) REFERENCES dbo.CaChieu(MaCaChieu),
	FOREIGN KEY (MaKhachHang) REFERENCES dbo.KhachHang(MaKH)
)
GO

CREATE TABLE ChoNgoi(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Hang CHAR(1) NOT NULL, -- Hàng A, B, C
	So INT NOT NULL,-- Số 1, 2, 3 
	MaPhong VARCHAR(50) NOT NULL,
	MaKhachHang INT DEFAULT -1
	CONSTRAINT UC_ChoNgoi UNIQUE(Hang, So, MaPhong),
	CONSTRAINT FK_ChoNgoi_Phong FOREIGN KEY(MaPhong) REFERENCES PhongChieu(MaPhong),
	CONSTRAINT FK_ChoNgoi_KhachHang FOREIGN KEY(MaKhachHang) REFERENCES KhachHang(MaKH)
);
GO


---- Trigger


-- Stored Proc

-- Tk--
CREATE PROC USP_Login @userName NVARCHAR(1000), @pass VARCHAR(1000)
AS
BEGIN
	SELECT * FROM dbo.TaiKhoan WHERE UserName = @userName AND Pass = @pass
END
GO

CREATE PROC USP_ResetPasswordtAccount
@username NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.TaiKhoan 
	SET Pass = '123456' 
	WHERE UserName = @username
END
GO

--- INSERT DỮ LIỆU----


-- insert nhân viên---
 INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV01','Admin', CAST(N'2002-10-29' AS Date),N'Admin',NULL,123456789)
INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV02',N'Bùi Thanh Duy', CAST(N'2002-1-1' AS Date),N'Phú Yên',NULL,075234567)
INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV03',N'Phạm Nguyễn Nhựt Trường', CAST(N'2002-2-2' AS Date),N'Tiền Giang',NULL,075234568)
INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV04',N'Phan Quốc Lưu', CAST(N'2002-3-3' AS Date),N'Thủ Đức',NULL,075234569)
INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV05',N'Vũ Hoàng Anh', CAST(N'2002-5-5' AS Date),N'Đồng Nai',NULL,075234560)


--- insert tài khoản---
INSERT TaiKhoan (UserName, Pass,LoaiTK, idNV) VALUES (N'admin',N'admin',1,N'NV01')
INSERT TaiKhoan (UserName, Pass,LoaiTK, idNV) VALUES (N'NV02',N'123456',2,N'NV02')

--- insert thể loại phim
INSERT TheLoai(MaLoaiPhim,TenTheLoai) VALUES (N'T01', N'Hành Động')
INSERT TheLoai(MaLoaiPhim,TenTheLoai) VALUES (N'T02', N'Hoạt Hình')
INSERT TheLoai(MaLoaiPhim,TenTheLoai) VALUES (N'T03', N'Hài')
INSERT TheLoai(MaLoaiPhim,TenTheLoai) VALUES (N'T04', N'Viễn Tưởng')
INSERT TheLoai(MaLoaiPhim,TenTheLoai) VALUES (N'T05', N'Phiêu lưu')
INSERT TheLoai(MaLoaiPhim,TenTheLoai) VALUES (N'T06', N'Gia đình')
INSERT TheLoai(MaLoaiPhim,TenTheLoai) VALUES (N'T07', N'Tình Cảm')
INSERT TheLoai(MaLoaiPhim,TenTheLoai) VALUES (N'T08', N'Tâm Lý')
INSERT TheLoai(MaLoaiPhim,TenTheLoai) VALUES (N'T09', N'Kinh Dị')

---

--- insert phim---
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P0001',N'Chú Khủng Long Của Nobita',NULL,2.5, CAST(N'2022-10-1' AS Date),CAST(N'2022-12-1' AS Date),N'Nhật Bản','Kaminashi Mitsuo',2019,7)
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P0002',N'Harry Potter và Hòn Đá Phù Thủy',NULL,2, CAST(N'2022-10-8' AS Date),CAST(N'2022-12-30' AS Date),N'Anh','Chris Columbus',2018,13)
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P0003',N'Chúa tể của những chiếc nhẫn',NULL,2.5, CAST(N'2022-9-8' AS Date),CAST(N'2022-12-30' AS Date),N'Mỹ','Ralph Bakshi',2016,13)
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P0004',N'Bố Già',NULL,2, CAST(N'2022-10-8' AS Date),CAST(N'2022-12-30' AS Date),N'Việt Nam',N'Trấn Thành',2018,9)

-- Phân Loại Phim
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0001','T02')
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0001','T05')
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0002','T01')
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0002','T05')
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0002','T04')
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0003','T02')
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0003','T05')
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0003','T07')
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0003','T09')
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0004','T06')
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0004','T08')
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0004','T07')
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0004','T03')


-- insert phong chiếu---

INSERT PhongChieu(MaPhong,TenPhong,SoChoNgoi,TinhTrang,SoHangGhe,SoGheMotHang) VALUES ( 'R01','USA',100,1,10,10)
INSERT PhongChieu(MaPhong,TenPhong,SoChoNgoi,TinhTrang,SoHangGhe,SoGheMotHang) VALUES ( 'R02','AUSTRALIA',100,1,10,10)
INSERT PhongChieu(MaPhong,TenPhong,SoChoNgoi,TinhTrang,SoHangGhe,SoGheMotHang) VALUES ( 'R03','KOREAN',100,1,10,10)
INSERT PhongChieu(MaPhong,TenPhong,SoChoNgoi,TinhTrang,SoHangGhe,SoGheMotHang) VALUES ( 'R04','VIETNAM',100,1,10,10)

--- insert ca chiếu----
INSERT CaChieu ( MaCaChieu, ThoiGianChieu, ThoiGianKetThuc,MaPhong,MaPhim,GiaVe,TrangThai)
VALUES ('MCC0001',CAST(N'2022-05-02T08:50:00.000' AS DateTime),CAST(N'2022-05-02T08:50:00.000' AS DateTime),'R01','P0001', 90.000,1)
INSERT CaChieu ( MaCaChieu, ThoiGianChieu, ThoiGianKetThuc,MaPhong,MaPhim,GiaVe,TrangThai)
VALUES ('MCC0002',CAST(N'2022-05-02T08:50:00.000' AS DateTime),CAST(N'2022-05-02T08:50:00.000' AS DateTime),'R01','P0002', 90.000,0)
INSERT CaChieu ( MaCaChieu, ThoiGianChieu, ThoiGianKetThuc,MaPhong,MaPhim,GiaVe,TrangThai)
VALUES ('MCC0003',CAST(N'2022-05-02T08:50:00.000' AS DateTime),CAST(N'2022-05-02T08:50:00.000' AS DateTime),'R01','P0003', 90.000,0)
INSERT CaChieu ( MaCaChieu, ThoiGianChieu, ThoiGianKetThuc,MaPhong,MaPhim,GiaVe,TrangThai)
VALUES ('MCC0004',CAST(N'2022-10-02T08:50:00.000' AS DateTime),CAST(N'2012-10-02T08:50:00.000' AS DateTime),'R01','P0004', 90.000,1)

--- insert khách hàng
INSERT KhachHang (TenKhachHang, Diachi, NamSinh, SoDienThoai,DiemTichLuy)
VALUES (N'Đỗ Dương Thái Tuấn',N'Thủ Đức',2002,'0912999988',0)
INSERT KhachHang (TenKhachHang, Diachi, NamSinh, SoDienThoai,DiemTichLuy)
VALUES (N'Trần Chí Mỹ',N'Thủ Đức',2002,'0912922988',0)
INSERT KhachHang (TenKhachHang, Diachi, NamSinh, SoDienThoai,DiemTichLuy)
VALUES (N'Phan Quốc Lưu',N'Thủ Đức',2002,'091292297',0)
INSERT KhachHang (TenKhachHang, Diachi, NamSinh, SoDienThoai,DiemTichLuy)
VALUES (N'Bùi Thanh Duy',N'Thủ Đức',2002,'093792297',0)



-- insert cho ngoi
INSERT ChoNgoi (Hang,So,MaPhong,MaKhachHang) VALUES ('A',1,'R01',2)

--insert vé --
INSERT Ve (LoaiVe,MaCaChieu,MaGheNgoi,MaKhachHang,TrangThai,TienBanVe) VALUES (0,'MCC0001',2,2,1,90.000)



-- select specified information of customer
CREATE PROCEDURE SP_GetALLCustomer
AS
	SELECT MaKH, TenKhachHang, Diachi, NamSinh, SoDienThoai, DiemTichLuy FROM KhachHang;
GO


-- add new Customer and reload
CREATE PROCEDURE USP_AddCustomer @TenKhachHang nvarchar(50), @DiaChi nvarchar(100), @NamSinh int, @SoDienThoai varchar(50), @Diem int
AS
	INSERT INTO KhachHang(TenKhachHang, DiaChi, NamSinh, SoDienThoai, DiemTichLuy) 
	VALUES(@TenKhachHang, @DiaChi, @NamSinh, @SoDienThoai, @Diem)
GO	


-- delete a customer by id
CREATE PROCEDURE USP_DeleteCustomer @CusID INT
AS
	DELETE FROM KhachHang WHERE MaKH = @CusID
GO

-- update customer infor
CREATE PROCEDURE USP_UpdateCustomer @CusId INT, @name nvarchar(50), @address nvarchar(100), @birth int, @phone varchar(50), @point int
AS 
	UPDATE KhachHang SET TenKhachHang = @name, Diachi = @address, NamSinh = @birth, SoDienThoai = @phone, DiemTichLuy = @point
	WHERE MaKH = @CusId
GO  


-- CREARTE FUNCTION get All staff 
CREATE FUNCTION UF_readAllStaff()
RETURNS TABLE AS
	RETURN SELECT * FROM NhanVien
GO



-- store delete staff
CREATE PROCEDURE USP_DeleteStaff @StaffID varchar(50)
AS
	DELETE FROM NhanVien WHERE idNV = @StaffID
GO

-- store add staff
CREATE PROCEDURE USP_AddStaff @idNV varchar(50), @HoTen nvarchar(100), @NgaySinh date, @DiaChi varchar(100), @SDT varchar(100), @CMND int
AS
	INSERT INTO NhanVien(idNV , HoTen , NgaySinh , DiaChi , SDT , CMND) 
	VALUES(@idNV, @HoTen , @NgaySinh , @DiaChi , @SDT , @CMND )
GO


-- update customer infor
CREATE PROCEDURE USP_UpdateStaff @id varchar(50), @name nvarchar(100), @birth date, @address nvarchar(100), @phone varchar(100), @identity int
AS 
	UPDATE NhanVien SET idNV = @id, HoTen = @name, NgaySinh = @birth, DiaChi = @address, SDT = @phone, CMND = @identity
	WHERE idNV = @id
GO  














 



