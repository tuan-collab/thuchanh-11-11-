CREATE DATABASE SalesDB;

USE SalesDB;

-- 1. Bảng Nhân Viên
CREATE TABLE NhanVien (
    MaNV INT IDENTITY(1,1) PRIMARY KEY,
    TenNV NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15) UNIQUE,
    ChucVu NVARCHAR(50)
);

-- 2. Bảng Khách Hàng
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenKH NVARCHAR(100) NOT NULL,
    DienThoai VARCHAR(15) UNIQUE,
    DiemTichLuy INT DEFAULT 0
);

-- 3. Bảng Sản Phẩm
CREATE TABLE SanPham (
    MaSP VARCHAR(20) PRIMARY KEY,
    TenSP NVARCHAR(150) NOT NULL,
    GiaBan DECIMAL(18,2) CHECK (GiaBan > 0),
    SoLuongTon INT CHECK (SoLuongTon >= 0)
);

-- 4. Bảng Hóa Đơn
CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    NgayLap DATETIME DEFAULT GETDATE(),
    MaNV INT NOT NULL,
    MaKH INT NULL,
    TongTien DECIMAL(18,2),
    CONSTRAINT FK_HoaDon_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_HoaDon_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);

-- 5. Bảng Chi Tiết Hóa Đơn
CREATE TABLE ChiTietHoaDon (
    MaHD INT NOT NULL,
    MaSP VARCHAR(20) NOT NULL,
    SoLuong INT CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2),
    PRIMARY KEY (MaHD, MaSP),
    CONSTRAINT FK_CTHD_HoaDon FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
    CONSTRAINT FK_CTHD_SanPham FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

-- 3. Chèn dữ liệu mẫu
INSERT INTO NhanVien (TenNV, SoDienThoai, ChucVu) VALUES 
(N'Nguyễn Văn An', '0901234567', N'Thu ngân'),
(N'Trần Thị Bình', '0907654321', N'Thu ngân'),
(N'Lê Hoàng Cường', '0912345678', N'Quản lý');

INSERT INTO KhachHang (TenKH, DienThoai, DiemTichLuy) VALUES 
(N'Phạm Minh Đức', '0933111222', 15),
(N'Vũ Thị Hoa', '0944222333', 50),
(N'Đỗ Anh Tuấn', '0955333444', 0),
(N'Nguyễn Phương Thảo', '0966444555', 120);

INSERT INTO SanPham (MaSP, TenSP, GiaBan, SoLuongTon) VALUES 
('SP01', N'Sữa tươi Vinamilk 1L', 35000, 50),
('SP02', N'Bánh mì Sandwich Kinh Đô', 25000, 30),
('SP03', N'Nước khoáng Lavie 500ml', 7000, 100),
('SP04', N'Mì Hảo Hảo tôm chua cay (Thùng)', 115000, 20),
('SP05', N'Cà phê hòa tan Trung Nguyên G7', 65000, 45),
('SP06', N'Dầu ăn Tường An 1L', 52000, 15),
('SP07', N'Nước ngọt Coca-Cola 330ml', 10000, 80),
('SP08', N'Kem đánh răng P/S 180g', 38000, 25);

INSERT INTO HoaDon (NgayLap, MaNV, MaKH, TongTien) VALUES 
(GETDATE() - 2, 1, 1, 135000),
(GETDATE() - 1, 2, 2, 243000),
(GETDATE(), 1, 3, 52000);

INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia) VALUES 
(1, 'SP01', 2, 35000),
(1, 'SP05', 1, 65000),
(2, 'SP04', 1, 115000),
(2, 'SP07', 10, 10000),
(2, 'SP03', 4, 7000),
(3, 'SP06', 1, 52000);
