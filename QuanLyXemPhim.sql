--======================================================TẠO DATABASE==========================================================
CREATE DATABASE QuanLyXemPhim
GO

USE QuanLyXemPhim
GO 

--========================================================TẠO BẢNG ==============================================================
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
	MaKH INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	TenKhachHang NVARCHAR(50) NOT NULL,
	Diachi NVARCHAR(100),
	NamSinh INT,
	SoDienThoai VARCHAR (50) UNIQUE,
	DiemTichLuy INT DEFAULT 0
)
GO



CREATE TABLE Ve
(
	id int identity(1,1) PRIMARY KEY,
	LoaiVe INT  DEFAULT '0', --0: Vé người lớn || 1: Vé học sinh - sinh viên || 2: vé trẻ em
	MaCaChieu VARCHAR(50),
	MaGheNgoi VARCHAR(50),
	MaKhachHang INT ,
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


select * from NhanVien

--================================================CHÈN DỮ LIỆU VÀO CÁC BẢNG==================================================
-- insert nhân viên---
INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV01','Admin', CAST(N'2002-10-29' AS Date),N'Admin',NULL,123456789)
INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV02',N'Bùi Thanh Duy', CAST(N'2002-1-1' AS Date),N'Phú Yên',NULL,075234567)
INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV03',N'Phạm Nguyễn Nhựt Trường', CAST(N'2002-2-2' AS Date),N'Tiền Giang',NULL,075234568)
INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV04',N'Phan Quốc Lưu', CAST(N'2002-3-3' AS Date),N'Thủ Đức',NULL,075234569)
INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV05',N'Vũ Hoàng Anh', CAST(N'2002-5-5' AS Date),N'Đồng Nai',NULL,075234560)

--- insert tài khoản---
INSERT TaiKhoan (UserName, Pass,LoaiTK, idNV) VALUES (N'admin',N'admin',1,N'NV01')
INSERT TaiKhoan (UserName, Pass,LoaiTK, idNV) VALUES (N'NV02',N'123456',2,N'NV02')

select * from TaiKhoan

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
VALUES ('MCC0001',CAST(N'2022-10-24T08:50:00.000' AS DateTime),CAST(N'2022-10-25T08:50:00.000' AS DateTime),'R01','P0001', 90.000,1)
INSERT CaChieu ( MaCaChieu, ThoiGianChieu, ThoiGianKetThuc,MaPhong,MaPhim,GiaVe,TrangThai)
VALUES ('MCC0002',CAST(N'2022-10-23T08:50:00.000' AS DateTime),CAST(N'2022-10-06T08:50:00.000' AS DateTime),'R01','P0002', 90.000,0)
INSERT CaChieu ( MaCaChieu, ThoiGianChieu, ThoiGianKetThuc,MaPhong,MaPhim,GiaVe,TrangThai)
VALUES ('MCC0003',CAST(N'2022-10-22T08:50:00.000' AS DateTime),CAST(N'2022-10-27T08:50:00.000' AS DateTime),'R01','P0003', 90.000,0)
INSERT CaChieu ( MaCaChieu, ThoiGianChieu, ThoiGianKetThuc,MaPhong,MaPhim,GiaVe,TrangThai)
VALUES ('MCC0004',CAST(N'2022-10-21T08:50:00.000' AS DateTime),CAST(N'2012-10-28T08:50:00.000' AS DateTime),'R01','P0004', 90.000,1)
INSERT CaChieu ( MaCaChieu, ThoiGianChieu, ThoiGianKetThuc,MaPhong,MaPhim,GiaVe,TrangThai)
VALUES ('MCC0005',CAST(N'2022-11-22T08:50:00.000' AS DateTime),CAST(N'2022-11-27T08:50:00.000' AS DateTime),'R01','P0003', 90.000,0)

--- insert khách hàng
INSERT KhachHang (TenKhachHang, Diachi, NamSinh, SoDienThoai,DiemTichLuy)
VALUES (N'Đỗ Dương Thái Tuấn',N'Thủ Đức',2002,'0912999988',0)
INSERT KhachHang (TenKhachHang, Diachi, NamSinh, SoDienThoai,DiemTichLuy)
VALUES (N'Trần Chí Mỹ',N'Thủ Đức',2002,'0912922988',0)

-- insert cho ngoi
INSERT ChoNgoi (Hang,So,MaPhong,MaKhachHang) VALUES ('A',1,'R01',2)

--insert vé --
INSERT Ve (LoaiVe,MaCaChieu,MaGheNgoi,MaKhachHang,TrangThai,TienBanVe) VALUES (0,'MCC0001',2,2,1,90.000)
GO



--===================================================TẠO STORE==============================================================================
-- STORE Login
CREATE PROC USP_Login @userName NVARCHAR(1000), @pass VARCHAR(1000)
AS
BEGIN
	SELECT * FROM dbo.TaiKhoan WHERE UserName = @userName AND Pass = @pass
END
GO

--STORE Resest password
CREATE PROC USP_ResetPasswordtAccount
@username NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.TaiKhoan 
	SET Pass = '123456' 
	WHERE UserName = @username
END
GO

-----------STAFF
-- STORE add staff
CREATE PROC USP_Add_Staff @idNV VARCHAR(50), @HoTen NVARCHAR(100), @NgaySinh VARCHAR(100), @DiaChi NVARCHAR(100), @SDT VARCHAR(100), @CMND INT
AS
BEGIN
	INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (@idNV, @HoTen, CAST(@NgaySinh AS Date), @DiaChi, @SDT, @CMND)
END
GO

-- STORE update staff
CREATE PROC USP_Update_Staff @idNV VARCHAR(50), @HoTen NVARCHAR(100), @NgaySinh VARCHAR(100), @DiaChi NVARCHAR(100), @SDT VARCHAR(100), @CMND INT
AS
BEGIN
	UPDATE NhanVien SET HoTen = @HoTen, NgaySinh = CAST(@NgaySinh AS Date), DiaChi = @DiaChi, SDT = @SDT, CMND = @CMND WHERE idNV = @idNV
END
GO

--STROE delete staff
CREATE PROC USP_Delete_Staff @idNV VARCHAR(50)
AS
BEGIN
	DELETE NhanVien WHERE idNV = @idNV
END
GO


select * from CaChieu
select * from Phim
--STORE show staff

CREATE PROC USP_Show_Staff 
AS
BEGIN
	SELECT * FROM NhanVien
END
GO

select * from VE
select * from ChoNgoi

------STORE Account
--STORE add account
CREATE PROC USP_Add_Account @UserName NVARCHAR(100), @Pass NVARCHAR(1000), @LoaiTK INT, @idNV VARCHAR(50)
AS
BEGIN
	INSERT TaiKhoan (UserName, Pass,LoaiTK, idNV) VALUES (@UserName, @Pass , @LoaiTK, @idNV)
END
GO

--STORE update account
CREATE PROC USP_Update_Account @UserName NVARCHAR(100), @Pass NVARCHAR(1000), @LoaiTK INT, @idNV VARCHAR(50)
AS
BEGIN
	UPDATE TaiKhoan SET UserName = @UserName, Pass = @Pass , LoaiTK = @LoaiTK WHERE idNV = @idNV
END
GO

--STORE delete account
CREATE PROC USP_Delete_Account @idNV VARCHAR(50)
AS
BEGIN
	DELETE TaiKhoan WHERE idNV = @idNV
END
GO

--STORE show all account
CREATE PROC USP_Show_Account
AS
BEGIN
	SELECT * FROM TaiKhoan
END
GO

--------------PhongChieu
--STORE add Phong chieu
CREATE PROC USP_Add_Phong_Chieu @MaPhong VARCHAR(50), @TenPhong NVARCHAR(100) , @SoChoNgoi INT, @TinhTrang INT, @SoHangGhe int ,@SoGheMotHang int
AS
BEGIN
	INSERT INTO PhongChieu(MaPhong, TenPhong, SoChoNgoi, TinhTrang, SoHangGhe, SoGheMotHang) VALUES (@MaPhong, @TenPhong, @SoChoNgoi, @TinhTrang, @SoHangGhe, @SoGheMotHang)
END
GO


--STORE update Phong chieu
CREATE PROC USP_Update_Phong_Chieu @MaPhong VARCHAR(50), @TenPhong NVARCHAR(100) , @SoChoNgoi INT, @TinhTrang INT, @SoHangGhe int ,@SoGheMotHang int
AS
BEGIN
	UPDATE PhongChieu SET TenPhong = @TenPhong, SoChoNgoi = @SoChoNgoi, TinhTrang = @TinhTrang, SoHangGhe = @SoHangGhe , SoGheMotHang = @SoGheMotHang WHERE MaPhong = @MaPhong
END
GO


--STORE show Phong chieu
CREATE PROC USP_Show_Phong_Chieu 
AS
BEGIN
	SELECT * FROM PhongChieu
END
GO

--STORE xóa Phong Chieu
CREATE PROC USP_Xoa_Phong_Chieu @MaPhong VARCHAR(50)
AS
BEGIN
	DELETE FROM PhongChieu WHERE MaPhong = @MaPhong
END
GO

-- Lấy phòng chiếu và tên
CREATE PROC USP_GetPhongChieuByName
AS
BEGIN 
	SELECT MaPhong, TenPhong
	FROM PhongChieu
END
Go


--------------Phim
--Store add phim
CREATE PROC USP_Add_Phim @MaPhim VARCHAR(50), @TenPhim NVARCHAR(100), @MoTa NVARCHAR(1000), @ThoiLuong FLOAT, @NgayKhoiChieu DATE,
@NgayKetThuc DATE, @QuocGia NVARCHAR(50), @DaoDien NVARCHAR(100), @NamSX INT, @GioiHanTuoi INT
AS
BEGIN
	INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES (@MaPhim, @TenPhim, @MoTa, @ThoiLuong, CAST(@NgayKhoiChieu AS Date), CAST(@NgayKetThuc AS Date), @QuocGia, @DaoDien, @NamSX, @GioiHanTuoi)
END
GO


--Store update phim
CREATE PROC USP_Update_Phim @MaPhim VARCHAR(50), @TenPhim NVARCHAR(100), @MoTa NVARCHAR(1000), @ThoiLuong FLOAT, @NgayKhoiChieu DATE,
@NgayKetThuc DATE, @QuocGia NVARCHAR(50), @DaoDien NVARCHAR(100), @NamSX INT, @GioiHanTuoi INT
AS
BEGIN
	UPDATE Phim SET TenPhim = @TenPhim, MoTa = @MoTa, ThoiLuong = @ThoiLuong, NgayKhoiChieu = CAST(@NgayKhoiChieu AS Date) WHERE MaPhim = @MaPhim
END
GO

--Store delete phim
CREATE PROC USP_Delete_Phim @MaPhim VARCHAR(50)
AS
BEGIN
	DELETE FROM Phim WHERE MaPhim = @MaPhim
END
GO


--Store show phim
CREATE PROC USP_Show_Phim
AS
BEGIN
	SELECT * FROM Phim
END
GO


---------------Thể loại phim
---Store add thể loại phim
CREATE PROC USP_Add_The_Loai_Phim @MaLoaiPhim  VARCHAR(50), @TenTheLoai NVARCHAR(100)
AS
BEGIN
	INSERT INTO TheLoai (MaLoaiPhim, TenTheLoai) VALUES (@MaLoaiPhim, @TenTheLoai)
END
GO

----Store update thể loại phim
CREATE PROC USP_Update_The_Loai_Phim @MaLoaiPhim  VARCHAR(50), @TenTheLoai NVARCHAR(100)
AS
BEGIN
	UPDATE TheLoai SET TenTheLoai = @TenTheLoai WHERE MaLoaiPhim = @MaLoaiPhim
END
GO

----Store delete thể loại phim
CREATE PROC USP_Delete_The_Loai_Phim @MaLoaiPhim  VARCHAR(50)
AS
BEGIN
	DELETE FROM TheLoai WHERE MaLoaiPhim = @MaLoaiPhim
END
GO


----Store show thể loại phim
CREATE PROC USP_Show_The_Loai_Phim
AS
BEGIN
	SELECT * FROM TheLoai
END
GO




----------Phân loại phim
----Store add Phân Loại Phim
CREATE PROC USP_Add_Phan_Loai_Phim @idPhim VARCHAR(50), @idTheLoaiPhim VARCHAR(50)
AS
BEGIN
	INSERT INTO PhanLoaiPhim(idPhim, idTheLoai) VALUES(@idPhim, @idTheLoaiPhim)
END
GO

----Store show Phân Loại Phim
CREATE PROC USP_Show_Phan_Loai_Phim @idPhim VARCHAR(50), @idTheLoaiPhim VARCHAR(50)
AS
BEGIN
	SELECT * FROM PhanLoaiPhim
END
GO


----------Ca Chiếu
--STORE lấy ca chiếu
CREATE PROC USP_LayCaChieu
AS
BEGIN
	SELECT Cc.MaCaChieu AS [Mã lịch chiếu], Cc.MaPhong AS [Mã phòng], p.TenPhim AS [Tên phim], Cc.ThoiGianChieu AS [Thời gian chiếu],Cc.ThoiGianKetThuc AS [Thời gian Kết Thúc], Cc.GiaVe AS [Giá vé]
	FROM dbo.CaChieu AS Cc, dbo.Phim AS p
	WHERE Cc.MaPhim = p.MaPhim 
END
GO

--STORE lấy danh sách ca chiếu
CREATE PROC USP_GetListCaChieusByPhim
@ID varchar(50), @Date Datetime
AS
BEGIN
	select l.MaCaChieu, pc.TenPhong, p.TenPhim, l.ThoiGianChieu, l.ThoiGianKetThuc, l.GiaVe, l.TrangThai
	from Phim p , CaChieu l, PhongChieu pc
	where p.MaPhim = l.MaCaChieu and l.MaPhong = pc.MaPhong
	and CONVERT(DATE, @Date) = CONVERT(DATE, l.ThoiGianChieu) and CONVERT(DATE, @Date) = CONVERT(DATE, l.ThoiGianChieu)
	order by l.ThoiGianChieu, l.ThoiGianKetThuc
END
GO

--STORE add ca chiếu
Create PROC USP_Add_Ca_Chieu @MaCaChieu VARCHAR(50), @ThoiGianChieu DATETIME, @ThoiGianKetThuc DATETIME, 
@MaPhong VARCHAR(50), @MaPhim VARCHAR(50), @GiaVe Money
AS
BEGIN
	INSERT INTO CaChieu(MaCaChieu, ThoiGianChieu, ThoiGianKetThuc, MaPhong, MaPhim, GiaVe)
	VALUES (@MaCaChieu, @ThoiGianChieu, @ThoiGianKetThuc, @MaPhong, @MaPhim, @GiaVe)
END
GO

--STORE update ca chieu
Create PROC USP_Update_Ca_Chieu @MaCaChieu VARCHAR(50), @ThoiGianChieu DATETIME, @ThoiGianKetThuc DATETIME, 
@MaPhong VARCHAR(50), @MaPhim VARCHAR(50), @GiaVe Money
AS
BEGIN
	UPDATE CaChieu SET ThoiGianChieu = @ThoiGianChieu, ThoiGianKetThuc = @ThoiGianKetThuc, MaPhong = @MaPhong, MaPhim = @MaPhim, GiaVe = @GiaVe
	WHERE MaCaChieu = @MaCaChieu
END

GO

--STORE delete ca chieu 
CREATE PROC USP_Delete_Ca_Chieu @MaCaChieu VARCHAR(50)
AS
BEGIN
	DELETE FROM CaChieu WHERE MaCaChieu = @MaCaChieu
END
Go


--STORE show ca chieu 
Create PROC USP_Show_Ca_Chieu 
AS
BEGIN
	SELECT * FROM CaChieu
END
GO

-- STORE Get ca chiếu
Create PROC USP_GetCaChieu
AS
BEGIN
	SELECT  DISTINCT   CC.MaCaChieu, CC.MaPhong, P.TenPhim , CC.ThoiGianChieu, CC.ThoiGianKetThuc, CC.GiaVe
	FROM dbo.CaChieu AS CC, dbo.Phim AS p, dbo.PhanLoaiPhim AS PL
	WHERE CC.MaPhim = PL.idPhim AND p.MaPhim = PL.idPhim 

END
GO

--- Get ca chieu by ticket
CREATE PROC USP_GetCaChieuByTicket
AS
BEGIN
	select CaChieu.MaCaChieu, CaChieu.MaPhong, Phim.TenPhim, CaChieu.TrangThai, CaChieu.ThoiGianChieu
	from Phim , CaChieu 
	where Phim.MaPhim = CaChieu.MaPhim
	order by ThoiGianChieu
END
GO

-- update tinh trang ca chieu

CREATE PROC USP_updateTinhTrangCaChieu
@MaCaChieu NVARCHAR(50), @TinhTrang int
AS
BEGIN
	UPDATE dbo.CaChieu
	SET TrangThai = @TinhTrang
	WHERE MaCaChieu = @MaCaChieu
END
GO

---STORE lấy tên phim theo ca chiếu
Create PROC USP_LayTenPhimByCaChieu
AS
BEGIN
	SELECT CC.MaCaChieu, p.TenPhim
	from CaChieu CC, Phim p
	where CC.MaPhim = p.MaPhim
END
GO






-------STORE Vé
--STORE add Ve
CREATE PROC USP_Add_Ve @LoaiVe INT, @MaCaChieu VARCHAR(50), @MaGheNgoi VARCHAR(50), @MaKhachHang INT,
@TrangThai INT, @TienBanVe MONEY
AS
BEGIN
	INSERT INTO Ve (LoaiVe, MaCaChieu, MaGheNgoi, MaKhachHang, TrangThai, TienBanVe)
	VALUES (@LoaiVe, @MaCaChieu, @MaGheNgoi, @MaKhachHang, @TrangThai, @TienBanVe)
END
GO

-- Xoa ve
CREATE PROC USP_Xoa_Ve_By_Ca_Chieu
@MaCaChieu VARCHAR(50)
AS
BEGIN
	DELETE FROM dbo.Ve
	WHERE MaCaChieu = @MaCaChieu
END
GO

--STORE show danh sách vé
CREATE PROC USP_Show_Ve 
AS
BEGIN
	SELECT * FROm Ve
END
GO

CREATE PROC USP_themVebyCaChieu
@MaCaChieu VARCHAR(50), @MaGheNgoi VARCHAR(50)
AS
BEGIN
	INSERT INTO dbo.Ve (MaCaChieu, MaGheNgoi, MaKhachHang)
	VALUES(@MaCaChieu, @MaGheNgoi, null)
END
GO




-------STORE Chỗ ngồi
--STORE Add Chỗ ngồi
CREATE PROC USP_Add_Cho_Ngoi @Hang CHAR(1), @So INT, @MaPhong VARCHAR(50), @MaKhachHang INT
AS
BEGIN
	INSERT INTO ChoNgoi(Hang, So, MaPhong, MaKhachHang) VALUES (@Hang, @So, @MaPhong, @MaKhachHang)
END
GO


--STORE Update Chỗ ngồi
CREATE PROC USP_Update_Cho_Ngoi @Id INT,@Hang CHAR(1), @So INT, @MaPhong VARCHAR(50), @MaKhachHang INT
AS
BEGIN
	UPDATE ChoNgoi SET Hang = @Hang, So = @So, MaPhong = @MaPhong, MaKhachHang = @MaKhachHang WHERE Id = @Id
END
GO

--STORE Show Chỗ ngồi
CREATE PROC USP_Show_Cho_Ngoi
AS
BEGIN
	SELECT * FROM ChoNgoi
END
GO

CREATE PROC USP_Delete_Phim_Phim_PhanLoaiPhim_CaChieu @MaPhim varchar(50)
as
Begin 
	DELETE FROM PhanLoaiPhim WHERE idPhim = @MaPhim
	DELETE FROM CaChieu WHERE MaPhim = @MaPhim
	DELETE FROM Phim WHERE MaPhim = @MaPhim

end
Go




-- KHÁCH HÀNG

--STORE lấy ra danh sách tất cả khách hàng
CREATE PROCEDURE SP_layTatCaKhachHang
AS
	SELECT MaKH, TenKhachHang, Diachi, NamSinh, SoDienThoai, DiemTichLuy FROM KhachHang;
GO


-- Thêm khách hàng
CREATE PROCEDURE USP_themKhachHang @TenKhachHang nvarchar(50), @DiaChi nvarchar(100), @NamSinh int, @SoDienThoai varchar(50), @Diem int
AS
	INSERT INTO KhachHang(TenKhachHang, DiaChi, NamSinh, SoDienThoai, DiemTichLuy) 
	VALUES(@TenKhachHang, @DiaChi, @NamSinh, @SoDienThoai, @Diem)
GO




-- xóa khách hàng bởi id
CREATE PROCEDURE USP_xoaKhachHang @CusID INT
AS
	DELETE FROM KhachHang WHERE MaKH = @CusID
GO

-- cập nhật thông tin khách hàng
CREATE PROCEDURE USP_capNhatKhachHang @CusId INT, @name nvarchar(50), @address nvarchar(100), @birth int, @phone varchar(50), @point int
AS 
	UPDATE KhachHang SET TenKhachHang = @name, Diachi = @address, NamSinh = @birth, SoDienThoai = @phone, DiemTichLuy = @point
	WHERE MaKH = @CusId
GO  




-- NHÂN VIÊN
-- lấy tất cả các nhân viên 
CREATE FUNCTION FUNC_layTatCaNhanVien()
RETURNS TABLE AS
	RETURN SELECT * FROM NhanVien
GO

-- xóa nhân viên
CREATE PROCEDURE USP_xoaNhanVien @StaffID varchar(50)
AS
	DELETE FROM NhanVien WHERE idNV = @StaffID
GO

-- Thêm nhân viên
CREATE PROCEDURE USP_themNhanVien @idNV varchar(50), @HoTen nvarchar(100), @NgaySinh date, @DiaChi varchar(100), @SDT varchar(100), @CMND int
AS
	INSERT INTO NhanVien(idNV , HoTen , NgaySinh , DiaChi , SDT , CMND) 
	VALUES(@idNV, @HoTen , @NgaySinh , @DiaChi , @SDT , @CMND )
GO



-- Cập nhật nhân viên
CREATE PROCEDURE USP_capNhatNhanVien @id varchar(50), @name nvarchar(100), @birth date, @address nvarchar(100), @phone varchar(100), @identity int
AS 
	UPDATE NhanVien SET idNV = @id, HoTen = @name, NgaySinh = @birth, DiaChi = @address, SDT = @phone, CMND = @identity
	WHERE idNV = @id
GO  



--======================================================TRIGGER====================================================
CREATE TRIGGER UTG_INSERT_CheckDateLichChieu
ON dbo.CaChieu
FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idDinhDang VARCHAR(50), @ThoiGianChieu DATE, @NgayKhoiChieu DATE, @NgayKetThuc DATE

	SELECT @ThoiGianChieu = CONVERT(DATE, ThoiGianChieu) from INSERTED

	SELECT @NgayKhoiChieu = P.NgayKhoiChieu, @NgayKetThuc = P.NgayKetThuc
	FROM dbo.Phim P

	IF ( @ThoiGianChieu > @NgayKetThuc or @ThoiGianChieu < @NgayKhoiChieu)
	BEGIN
		ROLLBACK TRAN
		Raiserror('Lịch Chiếu lớn hơn hoặc bằng Ngày Khởi Chiếu và nhỏ hơn hoặc bằng Ngày Kết Thúc',16,1)
		Return
    END
END
GO




---=================================================FUNCTION===============================================
--FUNCTION get ca chiếu 
CREATE FUNCTION FUNC_GetCaChieu()
RETURNS TABLE
AS
RETURN
	(SELECT  DISTINCT   CC.MaCaChieu, CC.MaPhong, P.TenPhim , CC.ThoiGianChieu AS [Thời gian chiếu], CC.ThoiGianKetThuc AS [Thời gian kết thúc], CC.GiaVe AS [Giá vé]
	FROM dbo.CaChieu AS CC, dbo.Phim AS p, dbo.PhanLoaiPhim AS PL
	WHERE CC.MaPhim = PL.idPhim AND p.MaPhim = PL.idPhim )
GO





--Function lấy danh sách phim theo ngày chiếu(Chỉ lấy record thỏa điều kiện NgayCongChieu <= NgayDuocChon <= NgayKetThuc)
CREATE FUNCTION FUNC_layPhimTheoNgayChieu(@NgayChieu DATE)
RETURNS TABLE
AS
	RETURN
	(
		SELECT p.MaPhim, p.TenPhim, p.MoTa, p.ThoiLuong, p.NgayKhoiChieu, p.NgayKetThuc, p.QuocGia, p.DaoDien, p.NamSX, p.GioiHanTuoi FROM Phim as p, CaChieu as cc 
		WHERE NgayKhoiChieu <= @NgayChieu AND NgayKetThuc >= @NgayChieu AND p.MaPhim = cc.MaPhim AND cc.TrangThai = 0
	);
GO

-- Function lấy danh sách ca chiếu theo Tên phim và tình trạng ca chiếu (Chỉ lấy những ca chiếu của bộ phim được chọn mà chưa công chiếu)
CREATE FUNCTION FUNC_layCaChieuTheoTenPhim(@TenPhim NVARCHAR(100))
RETURNS TABLE
AS
	RETURN
	(
		SELECT cc.MaCaChieu, p.TenPhim, cc.ThoiGianChieu, cc.TrangThai, cc.MaPhong
		FROM CaChieu as cc, Phim as p WHERE cc.TrangThai = 0 AND p.TenPhim = @TenPhim AND p.MaPhim = cc.MaPhim
	);

GO

--FUNCTION Lấy danh sách cá chiếu - Tên phòng chiếu phù hợp với thời gian người dùng chọn.
CREATE FUNCTION FUNC_Get_DanhSachThongTinCaChieuTheoThoiGian (@TenPhim NVARCHAR(100))
RETURNS TABLE
AS
	RETURN
	(
		SELECT cc.MaCaChieu, p.TenPhim, cc.ThoiGianChieu, cc.MaPhong, cc.TrangThai
		FROM CaChieu as cc, Phim as p WHERE p.TenPhim = @TenPhim  AND cc.MaPhim = p.MaPhim AND cc.TrangThai = 0
	);



--- transaction update trạng thái vé
CREATE PROC USP_capNhatTrangThaiVe @MaVe int
AS
BEGIN TRANSACTION
	UPDATE VE SET TrangThai = 1 WHERE VE.id = @MaVe;
	IF(@@ERROR > 0)  
	BEGIN  
		ROLLBACK TRANSACTION  
	END  
	ELSE  
	BEGIN  
		COMMIT TRANSACTION  
	END 
GO 

-- lấy giá vé của một vé dựa vào id function
CREATE FUNCTION FUNC_layGiaVe (@Id int)
RETURNS money as
	BEGIN
		DECLARE @Price money
		SELECT @Price=TienBanVe FROM Ve WHERE Ve.id = @Id
		RETURN @Price
	END 
GO



-- hàm kiểm tra có tồn tại khách hàng thành viên thông qua số điện thoại
CREATE FUNCTION FUNC_laThanhVien(@phone varchar(50))
RETURNS BIT
	BEGIN
		DECLARE @isMember BIT
		SET @isMember = 0;
		IF EXISTS(SELECT * FROM KhachHang WHERE SoDienThoai = @phone)
			BEGIN
				SET @isMember = 1;
			END
		RETURN @isMember
	END
GO
-- Hàm lấy thông tin của khách hàng dựa vào số điện thoại đăng ký thành viên
CREATE PROC USP_layThongTinKhachHang @Sdt varchar(100)
AS
	SELECT DISTINCT * FROM KhachHang Where SoDienThoai = @Sdt


-- transaction cập nhật điểm tích lũy cho khách hàng
CREATE PROC USP_congDiemTichLuy @Sdt varchar(100), @bonus int
AS
	BEGIN TRANSACTION
		DECLARE @point int
		select @point = DiemTichLuy from KhachHang where SoDienThoai = @Sdt;
		set @point = @point + @bonus;
		update KhachHang set DiemTichLuy = @point where SoDienThoai = @Sdt;
		IF(@@ERROR > 0)  
		BEGIN  
			ROLLBACK TRANSACTION  
		END  
		ELSE  
		BEGIN  
			COMMIT TRANSACTION  
		END 
GO


-- sử dụng điểm tích lũy 
CREATE PROC USP_suDungDiemTichLuy @Sdt varchar(100)
AS
	BEGIN TRANSACTION
		DECLARE @point int
		select @point = DiemTichLuy from KhachHang where SoDienThoai = @Sdt;
		update KhachHang set DiemTichLuy = 0 where SoDienThoai = @Sdt;
		IF(@@ERROR > 0)  
		BEGIN  
			ROLLBACK TRANSACTION
		END  
		ELSE  
		BEGIN  
			COMMIT TRANSACTION  
		END 
GO

CREATE PROC USP_capNhatDiem @Diem int, @Sdt varchar(100)
AS 
	UPDATE KhachHang SET DiemTichLuy = @Diem WHERE SoDienThoai = @Sdt;
GO