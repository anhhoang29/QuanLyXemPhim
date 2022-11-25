﻿--======================================================TẠO DATABASE==========================================================
CREATE DATABASE QuanLyXemPhim
GO

USE QuanLyXemPhim
GO 

--DROP DATABASE QuanLyXemPhim


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
	UserName NVARCHAR(100) UNIQUE NOT NULL,
	Pass VARCHAR(1000) NOT NULL,
	LoaiTK INT NOT NULL DEFAULT 2, -- 1:admin || 2:staff
	idNV VARCHAR(50) UNIQUE NOT NULL,
	FOREIGN KEY (idNV) REFERENCES dbo.NhanVien(idNV)
)
GO

--ALTER TABLE TaiKhoan ADD CONSTRAINT  rangbuocUNIQUE UNIQUE(idNV);


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


--===================================================TẠO STORE============================================================================
----Store xử lý đăng nhập
CREATE PROC USP_dangNhap @userName NVARCHAR(1000), @pass VARCHAR(1000)
AS
BEGIN
	SELECT * FROM dbo.TaiKhoan WHERE UserName = @userName AND Pass = @pass
END
GO

-----------STORE NHÂN VIÊN
----Store lấy tất cả các nhân viên 
CREATE FUNCTION FUNC_layTatCaNhanVien()
RETURNS TABLE AS
	RETURN SELECT * FROM NhanVien
GO


----Store Thêm nhân viên
CREATE PROCEDURE USP_themNhanVien @idNV varchar(50), @HoTen nvarchar(100), @NgaySinh date, @DiaChi varchar(100), @SDT varchar(100), @CMND int
AS
	INSERT INTO NhanVien(idNV , HoTen , NgaySinh , DiaChi , SDT , CMND) 
	VALUES(@idNV, @HoTen , @NgaySinh , @DiaChi , @SDT , @CMND )
GO



----Store Cập nhật nhân viên
CREATE PROCEDURE USP_capNhatNhanVien @id varchar(50), @name nvarchar(100), @birth date, @address nvarchar(100), @phone varchar(100), @identity int
AS 
	UPDATE NhanVien SET idNV = @id, HoTen = @name, NgaySinh = @birth, DiaChi = @address, SDT = @phone, CMND = @identity
	WHERE idNV = @id
GO





----Store xóa nhân viên
CREATE PROCEDURE USP_xoaNhanVien @StaffID varchar(50)
AS
	DELETE FROM NhanVien WHERE idNV = @StaffID
GO



------STORE TaiKhoan
--Thủ tục thêm mới tài khoản user
CREATE PROC USP_themDanhSachTaiKhoan @UserName NVARCHAR(100), @Pass NVARCHAR(1000), @LoaiTK INT, @idNV VARCHAR(50)
AS
BEGIN
	INSERT TaiKhoan (UserName, Pass,LoaiTK, idNV) VALUES (@UserName, @Pass , @LoaiTK, @idNV)
END
GO

--Thủ tục cập nhật thông tin tài khoản user
CREATE PROC USP_suaDanhSachTaiKhoan @UserName NVARCHAR(100), @Pass NVARCHAR(1000), @LoaiTK INT, @idNV VARCHAR(50)
AS
BEGIN
	UPDATE TaiKhoan SET Pass = @Pass WHERE idNV = @idNV
END
GO

--Thủ tục xóa tài khoản user
CREATE PROC USP_xoaDanhSachTaiKhoan @idNV VARCHAR(50)
AS
BEGIN
	DELETE TaiKhoan WHERE idNV = @idNV
END
GO


--Thủ tục lấy danh sách các user
CREATE PROC USP_hienDanhSachTaiKhoan
AS
BEGIN
	SELECT * FROM TaiKhoan
END
GO



-----------STORE PHÒNG CHIẾU
--Store lấy danh sách phòng chiếu
CREATE PROC USP_layDanhSachPhongChieu 
AS
BEGIN
	SELECT * FROM PhongChieu
END
GO


--Store thêm phòng chiếu
CREATE PROC USP_themPhongChieu @MaPhong VARCHAR(50), @TenPhong NVARCHAR(100) , @SoChoNgoi INT, @TinhTrang INT, @SoHangGhe int ,@SoGheMotHang int
AS
BEGIN
	INSERT INTO PhongChieu(MaPhong, TenPhong, SoChoNgoi, TinhTrang, SoHangGhe, SoGheMotHang) VALUES (@MaPhong, @TenPhong, @SoChoNgoi, @TinhTrang, @SoHangGhe, @SoGheMotHang)
END
GO



--Store cập nhật phòng chiếu
CREATE PROC USP_capNhatPhongChieu @MaPhong VARCHAR(50), @TenPhong NVARCHAR(100) , @SoChoNgoi INT, @TinhTrang INT, @SoHangGhe int ,@SoGheMotHang int
AS
BEGIN
	UPDATE PhongChieu SET TenPhong = @TenPhong, SoChoNgoi = @SoChoNgoi, TinhTrang = @TinhTrang, SoHangGhe = @SoHangGhe , SoGheMotHang = @SoGheMotHang WHERE MaPhong = @MaPhong
END
GO


--Store xóa Phòng chiếu
CREATE PROC USP_xoaPhongChieu @MaPhong VARCHAR(50)
AS
BEGIN
	DELETE FROM PhongChieu WHERE MaPhong = @MaPhong
END
GO



--------------Phim
--Store Them danh sach phim
CREATE PROC USP_themDanhSachPhim @MaPhim VARCHAR(50), @TenPhim NVARCHAR(100), @MoTa NVARCHAR(1000), @ThoiLuong FLOAT, @NgayKhoiChieu DATE,
@NgayKetThuc DATE, @QuocGia NVARCHAR(50), @DaoDien NVARCHAR(100), @NamSX INT, @GioiHanTuoi INT
AS
BEGIN
	INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien, NamSX, GioiHanTuoi) 
VALUES (@MaPhim, @TenPhim, @MoTa, @ThoiLuong, @NgayKhoiChieu , @NgayKetThuc, @QuocGia, @DaoDien, @NamSX, @GioiHanTuoi)
END
GO


--Store sua danh sach phim
CREATE PROC USP_suaDanhSachPhim @MaPhim VARCHAR(50), @TenPhim NVARCHAR(100), @MoTa NVARCHAR(1000), @ThoiLuong FLOAT, @NgayKhoiChieu DATE,
@NgayKetThuc DATE, @QuocGia NVARCHAR(50), @DaoDien NVARCHAR(100), @NamSX int, @GioiHanTuoi INT
AS
BEGIN
	UPDATE Phim SET TenPhim = @TenPhim, MoTa = @MoTa, ThoiLuong = @ThoiLuong, NgayKhoiChieu = @NgayKhoiChieu, NgayKetThuc = @NgayKetThuc, @NamSX = NamSX, QuocGia = @QuocGia, DaoDien = @DaoDien WHERE MaPhim = @MaPhim
END
GO
--Store xoa danh sach phim
CREATE PROC USP_xoaDanhSachPhimTuCaChieu @MaPhim varchar(50)
AS
BEGIN 
	DELETE FROM PhanLoaiPhim WHERE idPhim = @MaPhim
	DELETE FROM CaChieu WHERE MaPhim = @MaPhim
	DELETE FROM Phim WHERE MaPhim = @MaPhim

END
GO

--Store hien thi danh sach phim 
CREATE PROC USP_hienDanhSachPhim
AS
BEGIN
	SELECT * FROM Phim
END
GO




-----------STORE THỂ LOẠI
----Store lấy danh sách thể loại phim
CREATE PROC USP_hienThiTheLoaiPhim
AS
BEGIN
	SELECT * FROM TheLoai
END
GO



---Store thêm thể loại phim
CREATE PROC USP_themTheLoaiPhim @MaLoaiPhim  VARCHAR(50), @TenTheLoai NVARCHAR(100)
AS
BEGIN
	INSERT INTO TheLoai (MaLoaiPhim, TenTheLoai) VALUES (@MaLoaiPhim, @TenTheLoai)
END
GO



----Store sửa thể loại phim
CREATE PROC USP_suaTheLoaiPhim @MaLoaiPhim  VARCHAR(50), @TenTheLoai NVARCHAR(100)
AS
BEGIN
	UPDATE TheLoai SET TenTheLoai = @TenTheLoai WHERE MaLoaiPhim = @MaLoaiPhim
END
GO



----Store xóa thể loại phim
CREATE PROC USP_xoaTheLoaiPhim @MaLoaiPhim  VARCHAR(50)
AS
BEGIN
	DELETE FROM TheLoai WHERE MaLoaiPhim = @MaLoaiPhim
END
GO

--- store lấy thế loại bởi mã phim
CREATE PROC USP_layTheLoaiBoiPhim @MaPhim VARCHAR(50)
AS
BEGIN
	SELECT TL.MaLoaiPhim, TenTheLoai
	FROM dbo.PhanLoaiPhim PL, dbo.TheLoai TL
	WHERE PL.idPhim = @MaPhim AND PL.idTheLoai = TL.MaLoaiPhim
END
GO

-----------STORE PHÂN LOẠI PHIM
-----------STORE CA CHIẾU
----Store hiện thị ca chiếu
CREATE PROC USP_hienThiCaChieu
AS
BEGIN
	SELECT * FROM CaChieu
END
GO



----Store lấy danh sách ca chiếu
CREATE PROC USP_layDanhSachCaChieu
AS
BEGIN
	--SELECT   DISTINCT  CC.MaCaChieu, CC.MaPhong, P.TenPhim , CC.ThoiGianChieu, CC.ThoiGianKetThuc, CC.GiaVe
	--FROM dbo.CaChieu AS CC, dbo.Phim AS p, dbo.PhanLoaiPhim AS PL
	--WHERE CC.MaPhim = PL.idPhim AND p.MaPhim = PL.idPhim 
	SELECT   CC.MaCaChieu, CC.MaPhong, P.TenPhim , CC.ThoiGianChieu, CC.ThoiGianKetThuc, CC.GiaVe
	FROM dbo.CaChieu AS CC, dbo.Phim AS p
	WHERE CC.MaPhim = p.MaPhim

END
GO

----Store thêm ca chiếu
CREATE PROC USP_themCaChieu @MaCaChieu VARCHAR(50), @ThoiGianChieu DATETIME, @ThoiGianKetThuc DATETIME, 
@MaPhong VARCHAR(50), @MaPhim VARCHAR(50), @GiaVe Money
AS
BEGIN
	INSERT INTO CaChieu(MaCaChieu, ThoiGianChieu, ThoiGianKetThuc, MaPhong, MaPhim, GiaVe)
	VALUES (@MaCaChieu, @ThoiGianChieu, @ThoiGianKetThuc, @MaPhong, @MaPhim, @GiaVe)
END
GO



----Store sửa ca chiếu
CREATE PROC USP_capNhatCaChieu @MaCaChieu VARCHAR(50), @ThoiGianChieu DATETIME, @ThoiGianKetThuc DATETIME, 
@MaPhong VARCHAR(50), @MaPhim VARCHAR(50), @GiaVe Money
AS
BEGIN
	UPDATE CaChieu SET ThoiGianChieu = @ThoiGianChieu, ThoiGianKetThuc = @ThoiGianKetThuc, MaPhong = @MaPhong, MaPhim = @MaPhim, GiaVe = @GiaVe
	WHERE MaCaChieu = @MaCaChieu
END
GO


--STORE xóa ca chiếu
CREATE PROC USP_xoaCaChieu @MaCaChieu VARCHAR(50)
AS
BEGIN
	DELETE FROM CaChieu WHERE MaCaChieu = @MaCaChieu
END
Go



----Store sửa tình trạng ca chiếu
CREATE PROC USP_capNhatTinhTrangCaChieu
@MaCaChieu NVARCHAR(50), @TinhTrang int
AS
BEGIN
	UPDATE dbo.CaChieu
	SET TrangThai = @TinhTrang
	WHERE MaCaChieu = @MaCaChieu
END
GO



--- Store lấy ca chếu theo vé
CREATE PROC USP_layCaChieuTheoVe
AS
BEGIN
	select CaChieu.MaCaChieu, CaChieu.MaPhong, Phim.TenPhim, CaChieu.TrangThai, CaChieu.ThoiGianChieu
	from Phim , CaChieu 
	where Phim.MaPhim = CaChieu.MaPhim
	order by ThoiGianChieu
END
GO

-----------STORE KHÁCH HÀNG
----Store lấy ra danh sách tất cả khách hàng
CREATE PROCEDURE USP_layTatCaKhachHang
AS
	SELECT MaKH, TenKhachHang, Diachi, NamSinh, SoDienThoai, DiemTichLuy FROM KhachHang;
GO

----Store thêm khách hàng
CREATE PROCEDURE USP_themKhachHang @TenKhachHang nvarchar(50), @DiaChi nvarchar(100), @NamSinh int, @SoDienThoai varchar(50), @Diem int
AS
	INSERT INTO KhachHang(TenKhachHang, DiaChi, NamSinh, SoDienThoai, DiemTichLuy) 
	VALUES(@TenKhachHang, @DiaChi, @NamSinh, @SoDienThoai, @Diem)
GO


----Store cập nhật thông tin khách hàng
CREATE PROCEDURE USP_capNhatKhachHang @CusId INT, @name nvarchar(50), @address nvarchar(100), @birth int, @phone varchar(50), @point int
AS 
	UPDATE KhachHang SET TenKhachHang = @name, Diachi = @address, NamSinh = @birth, SoDienThoai = @phone, DiemTichLuy = @point
	WHERE MaKH = @CusId
GO  



----Store xóa khách hàng bởi id
CREATE PROCEDURE USP_xoaKhachHang @CusID INT
AS
	DELETE FROM KhachHang WHERE MaKH = @CusID
GO


----Store lấy thông tin của khách hàng dựa vào số điện thoại đăng ký thành viên
CREATE PROC USP_layThongTinKhachHang @Sdt varchar(100)
AS
	SELECT DISTINCT * FROM KhachHang Where SoDienThoai = @Sdt
GO


----Store xập nhật điểm tích lũy
CREATE PROC USP_capNhatDiem @Diem int, @Sdt varchar(100)
AS 
	UPDATE KhachHang SET DiemTichLuy = @Diem WHERE SoDienThoai = @Sdt;
GO




-----------STORE VÉ
----Store thêm vé bằng mã ca chiếu
CREATE PROC USP_themVeCaChieu
@MaCaChieu VARCHAR(50), @MaGheNgoi VARCHAR(50)
AS
BEGIN
	INSERT INTO dbo.Ve (MaCaChieu, MaGheNgoi, MaKhachHang)
	VALUES(@MaCaChieu, @MaGheNgoi, null)
END
GO


----Store xóa vé bằng mã ca chiếu
CREATE PROC USP_xoaVeBoiMaCaChieu
@MaCaChieu VARCHAR(50)
AS
BEGIN
	DELETE FROM dbo.Ve
	WHERE MaCaChieu = @MaCaChieu
END
GO

--- Store cập nhật trạng thái vé
CREATE PROC USP_capNhatTrangThaiVe @maVe Int, @TienBanVe money, @LoaiVe int
AS
	UPDATE VE Set TrangThai = 1, TienBanVe = @TienBanVe, LoaiVe = @LoaiVe Where id = @maVe;
GO

----- DOANH THU ---
CREATE PROC USP_layDoanhThuBoiPhimVaNgay
@idMovie VARCHAR(50), @fromDate date, @toDate date
AS
BEGIN
	SELECT P.TenPhim AS [Tên phim], CONVERT(DATE, CC.ThoiGianChieu) AS [Ngày chiếu], CONVERT(TIME(0),CC.ThoiGianChieu) AS [Giờ chiếu], COUNT(V.id) AS [Số vé đã bán], SUM(TienBanVe) AS [Tiền vé]
	FROM dbo.Ve AS V, dbo.CaChieu AS CC, Phim AS P
	WHERE V.MaCaChieu= CC.MaCaChieu AND CC.MaPhim = P.MaPhim AND V.TrangThai = 1 AND P.MaPhim = @idMovie AND CC.ThoiGianChieu >= @fromDate AND CC.ThoiGianChieu <= @toDate
	GROUP BY V.MaCaChieu, P.TenPhim, CC.ThoiGianChieu
END
GO


--===================================================TẠO TRIGGER==========================================================================
----Trigger kiểm tra lịch chiếu trùng
CREATE TRIGGER [dbo].[UTG_kiemTraCaChieu]
ON [dbo].[CaChieu]
FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @count INT = 0, @count2 INT = 0, @ThoiGianChieu DATETIME, @idPhong VARCHAR(50)

	SELECT @idPhong = MaPhong, @ThoiGianChieu = ThoiGianChieu from INSERTED

	SELECT @count = COUNT(*)
	FROM dbo.CaChieu CC, dbo.Phim P
	WHERE CC.MaPhong = @idPhong AND CC.MaPhim = P.MaPhim AND (@ThoiGianChieu >= Cc.ThoiGianChieu AND @ThoiGianChieu <= DATEADD(MINUTE, P.ThoiLuong, Cc.ThoiGianChieu))

	SELECT @count2 = COUNT(*)
	FROM dbo.CaChieu CC, dbo.Phim P
	WHERE @idPhong = CC.MaPhong AND CC.MaPhim = P.MaPhim AND (CC.ThoiGianChieu >= @ThoiGianChieu AND CC.ThoiGianChieu <= DATEADD(MINUTE, P.ThoiLuong, @ThoiGianChieu))

	IF (@count > 1 OR @count2 > 1)
	BEGIN
		ROLLBACK TRAN
		Raiserror('Thời Gian Chiếu đã trùng với một lịch chiếu khác cùng Phòng Chiếu',16,1)
		Return
	END
END
GO



----Trigger kiểm tra ca chiếu với ngày khởi chiếu và ngày kết thúc của phim
CREATE TRIGGER [dbo].[UTG_INSERT_kiemTraNgayCaChieu]
ON [dbo].[CaChieu]
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


----Trigger tạo danh sách vé ứng với ca chiếu vừa được thêm mới 
CREATE TRIGGER [dbo].[UTG_themVeCaChieu]
ON [dbo].[CaChieu]
FOR INSERT
AS
BEGIN 
	DECLARE @result INT = 0, @i INT = 0, @SoHangGhe INT, @SoGheMotHang INT, @j INT = 0, @MaCaChieu VARCHAR(50)
	SELECT @SoHangGhe = dbo.PhongChieu.SoHangGhe FROM dbo.PhongChieu, inserted 
	SELECT @SoGheMotHang = dbo.PhongChieu.SoGheMotHang FROM dbo.PhongChieu, inserted 
	SELECT @MaCaChieu = MaCaChieu  FROM inserted
	WHILE @i < @SoHangGhe
	BEGIN
		DECLARE @tempt INT = 0;
		SET @tempt= @i + 65;
		DECLARE @charName VARCHAR(50);
		SELECT @charName = char(@tempt);
		WHILE @j <@SoGheMotHang
		BEGIN
			DECLARE @seatName VARCHAR(50);
			SET @seatName = @charName + '-' + CONVERT(CHAR,@j);
			BEGIN
				INSERT INTO Ve (LoaiVe, MaCaChieu, MaGheNgoi, TrangThai, TienBanVe)
				VALUES ('0', @MaCaChieu, @seatName,0, '0')
			END;
			SET @j = @j + 1;
		END;
		SET @j = 0;
		SET @i = @i +1;
	END
END
GO



----Trigger Xóa đi các vé thừa sau khi ca chiếu đã kết thúc.
CREATE TRIGGER USP_xoaVeThuaKhiCaChieuKetThuc ON CaChieu FOR UPDATE
AS
BEGIN
	DECLARE @MaCaChieu VARCHAR(50);
	SELECT @MaCaChieu = MaCaChieu FROM deleted;
	DELETE FROM Ve WHERE MaCaChieu = @MaCaChieu AND TrangThai = 0;
END
GO



----Trigger tạo tài khoản phân quyền ở DB khi các tài khoản ở Role Manager thêm mới tài khoản vào bảng tài khoản
CREATE TRIGGER UTG_taoTaiKhoanPhanQuyen ON TaiKhoan FOR INSERT
AS
BEGIN
	DECLARE @username VARCHAR(100);
	DECLARE @pass VARCHAR(255);
	DECLARE @loaiTK INT;
	DECLARE @createLogin VARCHAR(200);
	DECLARE @createUser VARCHAR(200);
	DECLARE @addUserToRole VARCHAR(200);
	DECLARE @addSystemToRole VARCHAR(200);
 
	SELECT @username = UserName, @pass = Pass, @loaiTK = LoaiTK FROM inserted
	SET @createLogin = 'CREATE LOGIN '+ @username +' WITH PASSWORD = ''' + @pass + '''';
	EXEC (@createLogin)
	SET @createUser = 'CREATE USER ' + @username + ' FOR LOGIN ' + @username;
	EXEC (@createUser)

	IF @loaiTK = 1
	BEGIN
		SET @addUserToRole = 'sp_addrolemember Manager,' + @username;
		EXEC (@addUserToRole)
		SET @addSystemToRole = 'SP_ADDSRVROLEMEMBER ' + @username +', SYSADMIN'
		EXEC (@addSystemToRole)
	END

	IF @loaiTK = 2
	BEGIN
		SET @addUserToRole = 'sp_addrolemember Staff,' + @username;
		EXEC (@addUserToRole)
	END
END
GO

---Trigger xóa tài khoản phân quyền ở DB khi các tài khoản ở Role Manager xóa đi một dòng trong bảng tài khoản 
CREATE TRIGGER UTG_xoaTaiKhoanPhanQuyen ON TaiKhoan FOR DELETE
AS
BEGIN
	DECLARE @username VARCHAR(100);
	DECLARE @xoaTaiKhoan VARCHAR(200);
	DECLARE @xoaNguoiDung VARCHAR(200);
	SELECT @username = UserName FROM deleted
	
	SET @xoaNguoiDung = 'DROP USER ' + @username
	PRINT @xoaNguoiDung
	EXEC(@xoaNguoiDung)
	SET @xoaTaiKhoan = 'DROP LOGIN ' + @username;
	EXEC(@xoaTaiKhoan)
END
GO


----Trigger sửa thông tin tài khoản phân quyền ở DB khi các tài khoản ở Role Manager chỉnh sửa thông tin trong bảng tài khoản
CREATE TRIGGER UTG_capNhatTaiKhoanPhanQuyen ON TaiKhoan FOR UPDATE
AS
BEGIN
	DECLARE @oldUsername VARCHAR(100);
	DECLARE @oldPassword VARCHAR(100);
	DECLARE @newUsername VARCHAR(100);
	DECLARE @newPassword VARCHAR(100);
	DECLARE @updateLogin VARCHAR(200);

	SELECT @newUsername = UserName, @newPassword = Pass FROM inserted
	SELECT @oldUsername = UserName, @oldPassword = Pass FROM deleted

	SET @updateLogin = 'ALTER LOGIN ' + @oldUsername + ' WITH PASSWORD = ''' + @newPassword +  '''';
	EXEC(@updateLogin)
END
GO




--===================================================TẠO FUNCTION==========================================================================
----FUNCTION lấy danh sách phim theo ngày chiếu
CREATE FUNCTION FUNC_layPhimTheoNgayChieu(@NgayChieu DATE)
RETURNS TABLE
AS
	RETURN
	(
		SELECT p.MaPhim, p.TenPhim, p.MoTa, p.ThoiLuong, p.NgayKhoiChieu, p.NgayKetThuc, p.QuocGia, p.DaoDien, p.NamSX, p.GioiHanTuoi FROM Phim as p, CaChieu as cc 
		WHERE NgayKhoiChieu <= @NgayChieu AND NgayKetThuc >= @NgayChieu AND p.MaPhim = cc.MaPhim AND cc.TrangThai = 0
	);
GO
---- Lấy giá vé
CREATE FUNCTION FUNC_layGiaVe (@Id varchar(50))
RETURNS money as
	BEGIN
		DECLARE @Price money
		SELECT @Price=GiaVe FROM CaChieu WHERE CaChieu.MaCaChieu = @Id
		RETURN @Price
	END 
GO

----Function lấy danh sách ca chiếu theo Tên phim và tình trạng ca chiếu (Chỉ lấy những ca chiếu của bộ phim được chọn mà chưa công chiếu)
CREATE FUNCTION FUNC_layCaChieuTheoTenPhim(@TenPhim NVARCHAR(100))
RETURNS TABLE
AS
	RETURN
	(
		SELECT cc.MaCaChieu, p.TenPhim, cc.ThoiGianChieu, cc.TrangThai, cc.MaPhong
		FROM CaChieu as cc, Phim as p WHERE cc.TrangThai = 0 AND p.TenPhim = @TenPhim AND p.MaPhim = cc.MaPhim
	);

GO

----Function kiểm tra có tồn tại khách hàng thành viên thông qua số điện thoại
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




--===================================================TẠO TRANSACTION==========================================================================
----Store + Transaction cập nhật điểm tích lũy cho khách hàng
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


----Store + Transaction sử dụng điểm tích lũy 
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



--=============================================PHÂN QUYỀN THEO ROLE==================================================================
----Câu lệnh tạo Role 
CREATE ROLE Manager
GO
CREATE ROLE Staff
GO

----Cấp quyền trên bảng cho Role Manager vừa tạo
GRANT ALL ON CaChieu TO [Manager] WITH GRANT OPTION
GO
GRANT ALL ON ChoNgoi TO [Manager] WITH GRANT OPTION
GO
GRANT ALL ON KhachHang TO [Manager] WITH GRANT OPTION
GO
GRANT ALL ON NhanVien TO [Manager] WITH GRANT OPTION
GO
GRANT ALL ON PhanLoaiPhim TO [Manager] WITH GRANT OPTION
GO
GRANT ALL ON Phim TO [Manager] WITH GRANT OPTION
GO
GRANT ALL ON PhongChieu TO [Manager] WITH GRANT OPTION
GO
GRANT ALL ON TaiKhoan TO [Manager] WITH GRANT OPTION 
GO
GRANT ALL ON TheLoai TO [Manager] WITH GRANT OPTION
GO
GRANT ALL ON Ve TO [Manager] WITH GRANT OPTION
GO
----Cấp quyền thực thi toàn bộ thủ tục và hàm cho Role Manager
GRANT EXECUTE, SELECT ON SCHEMA::dbo TO [Manager] WITH GRANT OPTION
GO







----Cấp quyền trên bảng cho Role Staff vừa tạo
GRANT SELECT ON Phim TO [Staff]
GO
GRANT SELECT, UPDATE ON CaChieu TO [Staff]
GO
GRANT SELECT, DELETE, UPDATE ON Ve TO [Staff]
GO
GRANT SELECT, INSERT, UPDATE ON KhachHang TO [Staff]
GO
----Cấp quyền thực thi thủ tục và hàm cho Role Manager
GRANT SELECT ON OBJECT:: FUNC_layPhimTheoNgayChieu TO [Staff]
GO
GRANT SELECT ON OBJECT:: FUNC_layCaChieuTheoTenPhim TO [Staff]
GO
GRANT EXEC ON OBJECT:: FUNC_layGiaVe  TO [Staff]
GO
GRANT EXEC ON OBJECT:: FUNC_laThanhVien  TO [Staff]
GO
GRANT EXECUTE ON USP_dangNhap TO [Staff]
GO
GRANT EXECUTE ON USP_layThongTinKhachHang TO [Staff]
GO
GRANT EXECUTE ON USP_layTatCaKhachHang TO [Staff]
GO
GRANT EXECUTE ON USP_themKhachHang TO [Staff]
GO
GRANT EXECUTE ON USP_capNhatTrangThaiVe TO [Staff]
GO
GRANT EXECUTE ON USP_congDiemTichLuy TO [Staff]
GO
GRANT EXECUTE ON USP_suDungDiemTichLuy TO [Staff]
GO
GRANT EXECUTE ON USP_capNhatDiem TO [Staff]
GO


------Tạo mới User Login admin
--CREATE LOGIN [admin] WITH PASSWORD = 'admin' 
--GO
------Tạo mới User liên kết với User Login
--USE QuanLyXemPhim CREATE USER [admin] FOR LOGIN [admin]
--GO
----Cấp quyền cho nhóm SysAdmin cho phép User Login admin có thể thêm mới User Login
--SP_ADDSRVROLEMEMBER [admin],'SYSADMIN'
--GO
------Gán User admin vừa tạo vào Role Manage
--EXEC sp_addrolemember 'Manager', [admin];
--GO


------Tạo mới User Login NV02
--CREATE LOGIN [NV02] WITH PASSWORD = '123456'
--GO
------Tạo mới User liên kết với User Login
--USE QuanLyXemPhim CREATE USER [NV02] FOR LOGIN [NV02]
--GO
------Gán User NV02 vừa tạo vào Role Staff
--EXEC sp_addrolemember 'Staff', [NV02];
--GO

--================================================CHÈN DỮ LIỆU VÀO CÁC BẢNG==================================================
-- insert nhân viên---
INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV01','Admin', CAST(N'2002-10-29' AS Date),N'Admin',032903968,123456789)
GO
INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV02',N'Bùi Thanh Duy', CAST(N'2002-1-1' AS Date),N'Phú Yên',0344968539,075234567)
GO
INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV03',N'Phạm Nguyễn Nhựt Trường', CAST(N'2002-2-2' AS Date),N'Tiền Giang',0349685558,075234568)
GO
INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV04',N'Phan Quốc Lưu', CAST(N'2002-3-3' AS Date),N'Thủ Đức',0379814088,075234569)
GO
INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV05',N'Vũ Hoàng Anh', CAST(N'2002-5-5' AS Date),N'Đồng Nai',0385511101,075234560)
GO
INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV06',N'Vân Anh', CAST(N'2000-2-25' AS Date),N'Đồng Tháp',0934567891,0213467321)
GO
INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV07',N'Vân Mỹ Lan', CAST(N'1998-2-25' AS Date),N'Cần Thơ',0397091786,215620175)
GO
INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV08',N'Vân Mỹ Lên', CAST(N'2003-2-25' AS Date),N'An Giang',0890984544,0904567345)
GO
INSERT NhanVien (idNV, HoTen, NgaySinh, DiaChi, SDT, CMND) VALUES (N'NV09',N'Ngọc Lan Anh', CAST(N'2000-2-25' AS Date),N'Khánh Hòa',08909847676,345767895)
GO

SELECT * FROM TaiKhoan
--- insert tài khoản---
---1: quyền admin(Có đầy đủ tất cả các quyền trên bảng, store, function)
INSERT TaiKhoan (UserName, Pass,LoaiTK, idNV) VALUES (N'admin',N'admin',1,N'NV01')
GO
---2: quyền nhân viên(Chỉ có quyền thao tác trên 1 số bảng, store, function)
INSERT TaiKhoan (UserName, Pass,LoaiTK, idNV) VALUES (N'NV02',N'123456',2,N'NV02')
GO
INSERT TaiKhoan (UserName, Pass,LoaiTK, idNV) VALUES (N'NV03',N'123456',2,N'NV03')
GO
INSERT TaiKhoan (UserName, Pass,LoaiTK, idNV) VALUES (N'NV04',N'123456',2,N'NV04')
GO
INSERT TaiKhoan (UserName, Pass,LoaiTK, idNV) VALUES (N'NV05',N'123456',2,N'NV05')
GO
INSERT TaiKhoan (UserName, Pass,LoaiTK, idNV) VALUES (N'NV06',N'123456',2,N'NV06')
GO
INSERT TaiKhoan (UserName, Pass,LoaiTK, idNV) VALUES (N'NV07',N'123456',2,N'NV07')
GO
INSERT TaiKhoan (UserName, Pass,LoaiTK, idNV) VALUES (N'NV08',N'123456',2,N'NV08')
GO


--- insert thể loại phim
INSERT TheLoai(MaLoaiPhim,TenTheLoai) VALUES (N'T01', N'Hành Động')
GO
INSERT TheLoai(MaLoaiPhim,TenTheLoai) VALUES (N'T02', N'Hoạt Hình')
GO
INSERT TheLoai(MaLoaiPhim,TenTheLoai) VALUES (N'T03', N'Hài')
GO
INSERT TheLoai(MaLoaiPhim,TenTheLoai) VALUES (N'T04', N'Viễn Tưởng')
GO
INSERT TheLoai(MaLoaiPhim,TenTheLoai) VALUES (N'T05', N'Phiêu lưu')
GO
INSERT TheLoai(MaLoaiPhim,TenTheLoai) VALUES (N'T06', N'Gia đình')
GO
INSERT TheLoai(MaLoaiPhim,TenTheLoai) VALUES (N'T07', N'Tình Cảm')
GO
INSERT TheLoai(MaLoaiPhim,TenTheLoai) VALUES (N'T08', N'Tâm Lý')
GO
INSERT TheLoai(MaLoaiPhim,TenTheLoai) VALUES (N'T09', N'Kinh Dị')
GO

--- insert phim---
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P0001',N'Chú Khủng Long Của Nobita',NULL,2.5,CAST(N'2022-10-1' AS DATE),CAST(N'2023-12-1' AS DATE),N'Nhật Bản','Kaminashi Mitsuo',2019,7)
GO
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P0002',N'Harry Potter và Hòn Đá Phù Thủy',NULL,2, CAST(N'2022-10-1' AS DATE),CAST(N'2023-12-1' AS DATE),N'Anh','Chris Columbus',2018,13)
GO
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P0003',N'Chúa tể của những chiếc nhẫn',NULL,2.5,CAST(N'2022-10-1' AS DATE),CAST(N'2023-12-1' AS DATE),N'Mỹ','Ralph Bakshi',2016,13)
GO
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P0004',N'Bố Già',NULL,2,CAST(N'2022-10-1' AS DATE),CAST(N'2023-12-1' AS DATE),N'Việt Nam',N'Trấn Thành',2018,9)
GO
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P0005',N'Nhà tù Shawshank',NULL,2,CAST(N'2022-10-1' AS DATE),CAST(N'2023-12-1' AS DATE),N'Mỹ',N'Frank Darabont',1994,10)
GO
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P0006',N'Kỵ sĩ bóng đêm',NULL,3,CAST(N'2022-10-1' AS DATE),CAST(N'2023-12-1' AS DATE),N'Mỹ',N'Christopher Nolan',2008,18)
GO
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P0007',N'Kẻ đánh cắp giấc mơ',NULL,2.5,CAST(N'2022-10-1' AS DATE),CAST(N'2023-12-1' AS DATE),N'Mỹ',N'Christopher Nolan',2010,9)
GO
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P0008',N'Sàn đấu sinh tử ',NULL,3.1,CAST(N'2022-10-1' AS DATE),CAST(N'2023-12-1' AS DATE),N'Mỹ',N'David Fincher',1999,5)
GO
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P0009',N'Vua sư tử ',NULL,2,CAST(N'2022-10-1' AS DATE),CAST(N'2023-12-1' AS DATE),N'Mỹ',N'Roger Allers và Rob Minkoff',1994,2)
GO
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P00010',N'Ngôi nhà ma',NULL,4,CAST(N'2022-10-1' AS DATE),CAST(N'2023-12-1' AS DATE),N'Anh',N'The shining ',1940,5)
GO
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P00011',N'Star Wars IV ',NULL,2,CAST(N'2022-10-1' AS DATE),CAST(N'2023-12-1' AS DATE),N'Anh',N'A New Hope ',1977,2)
GO
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P00012',N'Cái Tên Khắc Sâu Trong Tim Người',NULL,1,CAST(N'2022-10-1' AS DATE),CAST(N'2023-12-1' AS DATE),N'Đài Loan',N'Liễu Quảng Huy ',2020,8)
GO
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P00013',N'Tân Tuyệt Đại Song Kiêu',NULL,1,CAST(N'2022-10-1' AS DATE),CAST(N'2023-12-1' AS DATE),N'Trung Quốc',N'Trâu Tập Thành',2020,8)
GO
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P00014',N'Tảo Hắc Phong Bạo',NULL,4,CAST(N'2022-10-1' AS DATE),CAST(N'2023-12-1' AS DATE),N'Hàn Quốc',N'Thanh Khôi',2013,8)
GO
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P00015',N'Tiếu Ngạo Gian Hồ',NULL,1,CAST(N'2022-10-1' AS DATE),CAST(N'2023-12-1' AS DATE),N'Trung Quốc',N'Minh Châu',1990,9)
GO
INSERT Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKhoiChieu, NgayKetThuc,QuocGia, DaoDien,NamSX,GioiHanTuoi) 
VALUES ('P00016',N'Thủy Hử',NULL,1,CAST(N'2022-10-1' AS DATE),CAST(N'2023-12-1' AS DATE),N'Trung Quốc',N'Tràng An ',1890,8)
GO



-- Phân Loại Phim
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0001','T02')
GO
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0001','T05')
GO
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0002','T01')
GO
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0002','T05')
GO
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0002','T04')
GO
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0003','T02')
GO
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0003','T05')
GO
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0003','T07')
GO
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0003','T09')
GO
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0004','T06')
GO
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0004','T08')
GO
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0004','T07')
GO
INSERT PhanLoaiPhim ( idPhim, idTheLoai) VALUES ('P0004','T03')
GO


-- insert phong chiếu---
INSERT PhongChieu(MaPhong,TenPhong,SoChoNgoi,TinhTrang,SoHangGhe,SoGheMotHang) VALUES ( 'R01','USA',100,1,10,10)
GO
INSERT PhongChieu(MaPhong,TenPhong,SoChoNgoi,TinhTrang,SoHangGhe,SoGheMotHang) VALUES ( 'R02','AUSTRALIA',100,1,10,10)
GO
INSERT PhongChieu(MaPhong,TenPhong,SoChoNgoi,TinhTrang,SoHangGhe,SoGheMotHang) VALUES ( 'R03','KOREAN',100,1,10,10)
GO
INSERT PhongChieu(MaPhong,TenPhong,SoChoNgoi,TinhTrang,SoHangGhe,SoGheMotHang) VALUES ( 'R04','VIETNAM',100,1,10,10)
GO

--- insert ca chiếu----
INSERT CaChieu ( MaCaChieu, ThoiGianChieu, ThoiGianKetThuc,MaPhong,MaPhim,GiaVe,TrangThai)
VALUES ('MCC0001',CAST(N'2022-10-24T08:50:00.000' AS DateTime),CAST(N'2022-10-25T08:50:00.000' AS DateTime),'R01','P0001', 90.000,1)
GO
INSERT CaChieu ( MaCaChieu, ThoiGianChieu, ThoiGianKetThuc,MaPhong,MaPhim,GiaVe,TrangThai)
VALUES ('MCC0002',CAST(N'2022-10-23T08:50:00.000' AS DateTime),CAST(N'2022-10-06T08:50:00.000' AS DateTime),'R01','P0002', 90.000,0)
GO
INSERT CaChieu ( MaCaChieu, ThoiGianChieu, ThoiGianKetThuc,MaPhong,MaPhim,GiaVe,TrangThai)
VALUES ('MCC0003',CAST(N'2022-10-22T08:50:00.000' AS DateTime),CAST(N'2022-10-27T08:50:00.000' AS DateTime),'R01','P0003', 90.000,0)
GO
INSERT CaChieu ( MaCaChieu, ThoiGianChieu, ThoiGianKetThuc,MaPhong,MaPhim,GiaVe,TrangThai)
VALUES ('MCC0004',CAST(N'2022-10-21T08:50:00.000' AS DateTime),CAST(N'2012-10-28T08:50:00.000' AS DateTime),'R01','P0004', 90.000,1)
GO
INSERT CaChieu ( MaCaChieu, ThoiGianChieu, ThoiGianKetThuc,MaPhong,MaPhim,GiaVe,TrangThai)
VALUES ('MCC0005',CAST(N'2022-11-22T08:50:00.000' AS DateTime),CAST(N'2022-11-27T08:50:00.000' AS DateTime),'R01','P0003', 90.000,0)
GO


--- insert khách hàng
INSERT KhachHang (TenKhachHang, Diachi, NamSinh, SoDienThoai, DiemTichLuy)
VALUES (N'Đỗ Dương Thái Tuấn',N'Thủ Đức',2002,'0912999988',0)
GO
INSERT KhachHang (TenKhachHang, Diachi, NamSinh, SoDienThoai, DiemTichLuy)
VALUES (N'Trần Chí Mỹ',N'Thủ Đức',2002,'0912922988',0)
GO
INSERT KhachHang (TenKhachHang, Diachi, NamSinh, SoDienThoai, DiemTichLuy)
VALUES (N'Nguyễn Minh Quốc',N'Quận 1',1995,'0987635456',5)
GO
INSERT KhachHang (TenKhachHang, Diachi, NamSinh, SoDienThoai, DiemTichLuy)
VALUES (N'Trần Minh Quân',N'Quận Bình Thạnh',2000,'0983456789',12)
GO
INSERT KhachHang (TenKhachHang, Diachi, NamSinh, SoDienThoai,DiemTichLuy)
VALUES (N'Trần Văn Trường',N'Quận Tân Bình',1999,'0934567823',10)
GO
INSERT KhachHang (TenKhachHang, Diachi, NamSinh, SoDienThoai, DiemTichLuy)
VALUES (N'Trần Vân Anh',N'Huyện Cần Giờ',1995,'09345672346',5)
GO
INSERT KhachHang (TenKhachHang, Diachi, NamSinh, SoDienThoai, DiemTichLuy)
VALUES (N'Trần Thị Lan',N'Huyện Bình Chánh',2009,'09944567846',5)
GO
INSERT KhachHang (TenKhachHang, Diachi, NamSinh, SoDienThoai, DiemTichLuy)
VALUES (N'Trần Minh Long',N'Quảng Ngãi',2003,'04567892345',20)
GO
INSERT KhachHang (TenKhachHang, Diachi, NamSinh, SoDienThoai,DiemTichLuy)
VALUES (N'Trần Minh Hướng',N'Quảng Nam',1999,'09454324535',5)
GO
INSERT KhachHang (TenKhachHang, Diachi, NamSinh, SoDienThoai, DiemTichLuy)
VALUES (N'Trần Thị Minh Phương',N'Thái Nguyên',1999,'34567898054',10)
GO

SELECT * FROM TaiKhoan