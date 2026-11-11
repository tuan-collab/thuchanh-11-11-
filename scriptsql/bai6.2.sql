CREATE DATABASE HRMDB;
USE HRMDB;

-- 1. Bảng Phòng Ban
CREATE TABLE PhongBan (
    MaPB INT IDENTITY(1,1) PRIMARY KEY,
    TenPB NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255)
);

-- 2. Bảng Hồ Sơ Nhân Viên
CREATE TABLE NhanVien (
    MaNV INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATETIME,
    CCCD VARCHAR(20) UNIQUE,
    MaPB INT NOT NULL,
    LuongCoBan DECIMAL(18,2) CHECK (LuongCoBan > 0),
    HeSoLuong FLOAT DEFAULT 1.0,
    CONSTRAINT FK_NhanVien_PhongBan FOREIGN KEY (MaPB) REFERENCES PhongBan(MaPB)
);

-- 3. Bảng Chấm Công Tháng
CREATE TABLE BangChamCong (
    MaCong INT IDENTITY(1,1) PRIMARY KEY,
    MaNV INT NOT NULL,
    ThangNam VARCHAR(7) NOT NULL, -- Ví dụ: "11/2026"
    SoNgayCong FLOAT CHECK (SoNgayCong <= 31),
    SoGioOT FLOAT DEFAULT 0,
    CONSTRAINT FK_ChamCong_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT UQ_ChamCong_NhanVien_Thang UNIQUE (MaNV, ThangNam)
);

-- 4. Bảng Lương Chi Tiết
CREATE TABLE BangLuong (
    MaLuong INT IDENTITY(1,1) PRIMARY KEY,
    MaNV INT NOT NULL,
    ThangNam VARCHAR(7) NOT NULL,
    ThucLinh DECIMAL(18,2),
    CONSTRAINT FK_BangLuong_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT UQ_BangLuong_NhanVien_Thang UNIQUE (MaNV, ThangNam)
);

-- DỮ LIỆU MẪU BAN ĐẦU
INSERT INTO PhongBan (TenPB, MoTa) VALUES 
(N'Phòng Nhân sự', N'Quản lý hồ sơ và tuyển dụng'),
(N'Phòng Kế toán', N'Tài chính và trả lương'),
(N'Phòng Kỹ thuật', N'Phát triển phần mềm');

INSERT INTO NhanVien (HoTen, NgaySinh, CCCD, MaPB, LuongCoBan, HeSoLuong) VALUES 
(N'Nguyễn Văn An', '1995-05-15', '001095012345', 1, 10000000, 1.2),
(N'Trần Thị Bình', '1998-08-20', '001098054321', 2, 12000000, 1.5),
(N'Lê Hoàng Cường', '1992-11-10', '001092098765', 3, 15000000, 2.0);

-- Dữ liệu chấm công mẫu tháng 11/2026
INSERT INTO BangChamCong (MaNV, ThangNam, SoNgayCong, SoGioOT) VALUES 
(1, '11/2026', 22, 5),
(2, '11/2026', 20, 2),
(3, '11/2026', 21.5, 10);