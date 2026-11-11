using System;
using System.Data;
using System.Windows.Forms;
using HRMManagement.BUS;
using HRMManagement.DTO;

namespace HRMManagement.GUI
{
    public partial class FormHRM : Form
    {
        private NhanVienBUS nhanVienBUS = new NhanVienBUS();
        private PhongBanBUS phongBanBUS = new PhongBanBUS();
        private BangChamCongBUS chamCongBUS = new BangChamCongBUS();
        private BangLuongBUS luongBUS = new BangLuongBUS();

        private DataTable dtChamCong;
        private int selectedMaNV = 0;

        public FormHRM()
        {
            InitializeComponent();
            LoadPhongBanComboBox();
            LoadNhanVienData();
            dtpThangNam.CustomFormat = "MM/yyyy";
            dtpThangNam.Format = DateTimePickerFormat.Custom;
        }

        private void LoadPhongBanComboBox()
        {
            var listPB = phongBanBUS.GetAll();
            
            cboPhongBanForm.DataSource = listPB;
            cboPhongBanForm.DisplayMember = "TenPB";
            cboPhongBanForm.ValueMember = "MaPB";

            var listPBSearch = phongBanBUS.GetAll();
            listPBSearch.Insert(0, new PhongBanDTO { MaPB = 0, TenPB = "-- Tất cả phòng ban --" });
            cboPhongBanSearch.DataSource = listPBSearch;
            cboPhongBanSearch.DisplayMember = "TenPB";
            cboPhongBanSearch.ValueMember = "MaPB";
        }

        private void LoadNhanVienData()
        {
            int? maPB = (int)cboPhongBanSearch.SelectedValue == 0 ? (int?)null : (int)cboPhongBanSearch.SelectedValue;
            dgvNhanVien.DataSource = nhanVienBUS.Search(txtTimKiem.Text.Trim(), maPB);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadNhanVienData();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                selectedMaNV = Convert.ToInt32(row.Cells["MaNV"].Value);
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                txtCCCD.Text = row.Cells["CCCD"].Value.ToString();
                cboPhongBanForm.SelectedValue = Convert.ToInt32(row.Cells["MaPB"].Value);
                txtLuongCoBan.Text = Convert.ToDecimal(row.Cells["LuongCoBan"].Value).ToString("G0");
                txtHeSoLuong.Text = row.Cells["HeSoLuong"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVienDTO nv = new NhanVienDTO
                {
                    HoTen = txtHoTen.Text.Trim(),
                    NgaySinh = dtpNgaySinh.Value,
                    CCCD = txtCCCD.Text.Trim(),
                    MaPB = Convert.ToInt32(cboPhongBanForm.SelectedValue),
                    LuongCoBan = Convert.ToDecimal(txtLuongCoBan.Text.Trim()),
                    HeSoLuong = Convert.ToDouble(txtHeSoLuong.Text.Trim())
                };

                if (nhanVienBUS.Insert(nv))
                {
                    MessageBox.Show("Thêm nhân viên mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNhanVienData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVienDTO nv = new NhanVienDTO
                {
                    MaNV = selectedMaNV,
                    HoTen = txtHoTen.Text.Trim(),
                    NgaySinh = dtpNgaySinh.Value,
                    CCCD = txtCCCD.Text.Trim(),
                    MaPB = Convert.ToInt32(cboPhongBanForm.SelectedValue),
                    LuongCoBan = Convert.ToDecimal(txtLuongCoBan.Text.Trim()),
                    HeSoLuong = Convert.ToDouble(txtHeSoLuong.Text.Trim())
                };

                if (nhanVienBUS.Update(nv))
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNhanVienData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (nhanVienBUS.Delete(selectedMaNV))
                    {
                        MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNhanVienData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- XỬ LÝ CHẤM CÔNG NGẮT KẾT NỐI (DISCONNECTED MODEL) ---
        private void btnTaiChamCong_Click(object sender, EventArgs e)
        {
            try
            {
                string thangNam = dtpThangNam.Value.ToString("MM/yyyy");
                dtChamCong = chamCongBUS.GetBangChamCongByThang(thangNam);
                dgvChamCong.DataSource = dtChamCong;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bảng chấm công: " + ex.Message, "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuChamCong_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtChamCong != null && chamCongBUS.SaveChanges(dtChamCong))
                {
                    MessageBox.Show("Đồng bộ dữ liệu chấm công về SQL Server thành công (Adapter.Update)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đồng bộ chấm công: " + ex.Message, "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- XỬ LÝ TÍNH & CHỐT LƯƠNG (SQLTRANSACTION) ---
        private void btnChotLuong_Click(object sender, EventArgs e)
        {
            try
            {
                string thangNam = dtpThangNam.Value.ToString("MM/yyyy");

                if (luongBUS.ChotLuongThang(thangNam))
                {
                    MessageBox.Show($"Chốt bảng lương tháng [{thangNam}] thành công bằng SqlTransaction!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvBangLuong.DataSource = luongBUS.GetBangLuongByThang(thangNam);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chốt lương: " + ex.Message, "Lỗi Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}