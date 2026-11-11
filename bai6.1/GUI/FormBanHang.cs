using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SalesManagement.BUS;
using SalesManagement.DTO;

namespace SalesManagement.GUI
{
    public partial class FormBanHang : Form
    {
        private SanPhamBUS sanPhamBUS = new SanPhamBUS();
        private HoaDonBUS hoaDonBUS = new HoaDonBUS();
        private NhanVienBUS nhanVienBUS = new NhanVienBUS();
        private KhachHangBUS khachHangBUS = new KhachHangBUS();
        private BaoCaoBUS baoCaoBUS = new BaoCaoBUS();

        private List<ChiTietHoaDonDTO> gioHang = new List<ChiTietHoaDonDTO>();

        public FormBanHang()
        {
            InitializeComponent();
            LoadDataControls();
        }

        private void LoadDataControls()
        {
            // Nạp danh sách Nhân viên
            cboNhanVien.DataSource = nhanVienBUS.GetAll();
            cboNhanVien.DisplayMember = "TenNV";
            cboNhanVien.ValueMember = "MaNV";

            // Nạp danh sách Khách hàng
            var listKH = khachHangBUS.GetAll();
            cboKhachHang.DataSource = listKH;
            cboKhachHang.DisplayMember = "TenKH";
            cboKhachHang.ValueMember = "MaKH";

            // Load tất cả sản phẩm
            btnTimKiem_Click(null, null);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = sanPhamBUS.Search(txtTimKiem.Text.Trim());
        }

        private void btnThemGioHang_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null) return;

            var selectedSP = (SanPhamDTO)dgvSanPham.CurrentRow.DataBoundItem;
            int soLuongMua = (int)nudSoLuong.Value;

            if (soLuongMua <= 0)
            {
                MessageBox.Show("Số lượng mua phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existItem = gioHang.FirstOrDefault(x => x.MaSP == selectedSP.MaSP);
            if (existItem != null)
            {
                existItem.SoLuong += soLuongMua;
            }
            else
            {
                gioHang.Add(new ChiTietHoaDonDTO
                {
                    MaSP = selectedSP.MaSP,
                    TenSP = selectedSP.TenSP,
                    SoLuong = soLuongMua,
                    DonGia = selectedSP.GiaBan
                });
            }

            CapNhatGioHangUI();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDonDTO hd = new HoaDonDTO
                {
                    MaNV = Convert.ToInt32(cboNhanVien.SelectedValue),
                    MaKH = cboKhachHang.SelectedValue != null ? (int?)Convert.ToInt32(cboKhachHang.SelectedValue) : null,
                    TongTien = gioHang.Sum(x => x.ThanhTien)
                };

                int maHD = hoaDonBUS.ThanhToan(hd, gioHang);

                MessageBox.Show($"Thanh toán giao dịch thành công!\nMã Hóa Đơn: {maHD}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                gioHang.Clear();
                CapNhatGioHangUI();
                btnTimKiem_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Giao dịch thất bại!\nChi tiết: {ex.Message}", "Lỗi Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            // Lấy từ ngày 1 của tháng hiện tại đến ngày hôm nay
            DateTime tuNgay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime denNgay = DateTime.Now;

            decimal doanhThu = baoCaoBUS.TinhTongDoanhThu(tuNgay, denNgay);
            List<string> top5 = baoCaoBUS.GetTop5SanPhamBanChay();

            string top5Str = string.Join("\n", top5);
            MessageBox.Show($"DOANH THU THÁNG {DateTime.Now.Month}: {doanhThu:N0} VNĐ\n\nTOP 5 SẢN PHẨM BÁN CHẠY:\n{top5Str}", "Báo cáo thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CapNhatGioHangUI()
        {
            dgvGioHang.DataSource = null;
            dgvGioHang.DataSource = gioHang;
            lblTongTien.Text = gioHang.Sum(x => x.ThanhTien).ToString("N0") + " VNĐ";
        }
    }
}