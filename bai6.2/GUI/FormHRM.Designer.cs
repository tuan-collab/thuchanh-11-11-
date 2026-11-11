namespace HRMManagement.GUI
{
    partial class FormHRM
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabNhanVien = new System.Windows.Forms.TabPage();
            this.tabChamCong = new System.Windows.Forms.TabPage();
            this.tabBangLuong = new System.Windows.Forms.TabPage();

            // Controls Tab NhanVien
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cboPhongBanSearch = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.cboPhongBanForm = new System.Windows.Forms.ComboBox();
            this.txtLuongCoBan = new System.Windows.Forms.TextBox();
            this.txtHeSoLuong = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();

            // Controls Tab ChamCong & BangLuong
            this.dtpThangNam = new System.Windows.Forms.DateTimePicker();
            this.btnTaiChamCong = new System.Windows.Forms.Button();
            this.btnLuuChamCong = new System.Windows.Forms.Button();
            this.dgvChamCong = new System.Windows.Forms.DataGridView();

            this.btnChotLuong = new System.Windows.Forms.Button();
            this.dgvBangLuong = new System.Windows.Forms.DataGridView();

            this.lblThangNam = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.lblPhongBan = new System.Windows.Forms.Label();
            this.lblLuongCB = new System.Windows.Forms.Label();
            this.lblHeSo = new System.Windows.Forms.Label();

            this.tabControlMain.SuspendLayout();
            this.tabNhanVien.SuspendLayout();
            this.tabChamCong.SuspendLayout();
            this.tabBangLuong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangLuong)).BeginInit();
            this.SuspendLayout();

            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabNhanVien);
            this.tabControlMain.Controls.Add(this.tabChamCong);
            this.tabControlMain.Controls.Add(this.tabBangLuong);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(980, 560);
            this.tabControlMain.TabIndex = 0;

            // 
            // TAB 1: QUẢN LÝ NHÂN SỰ (CRUD)
            // 
            this.tabNhanVien.Controls.Add(this.grpInfo);
            this.tabNhanVien.Controls.Add(this.dgvNhanVien);
            this.tabNhanVien.Controls.Add(this.grpSearch);
            this.tabNhanVien.Location = new System.Drawing.Point(4, 22);
            this.tabNhanVien.Name = "tabNhanVien";
            this.tabNhanVien.Padding = new System.Windows.Forms.Padding(3);
            this.tabNhanVien.Size = new System.Drawing.Size(972, 534);
            this.tabNhanVien.Text = "Hồ sơ Nhân viên (3-Tier CRUD)";

            // grpSearch
            this.grpSearch.Controls.Add(this.txtTimKiem);
            this.grpSearch.Controls.Add(this.cboPhongBanSearch);
            this.grpSearch.Controls.Add(this.btnTimKiem);
            this.grpSearch.Location = new System.Drawing.Point(10, 10);
            this.grpSearch.Size = new System.Drawing.Size(580, 55);
            this.grpSearch.Text = "Tìm kiếm nhân viên";

            this.txtTimKiem.Location = new System.Drawing.Point(10, 20);
            this.txtTimKiem.Size = new System.Drawing.Size(200, 20);

            this.cboPhongBanSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhongBanSearch.Location = new System.Drawing.Point(220, 20);
            this.cboPhongBanSearch.Size = new System.Drawing.Size(220, 21);

            this.btnTimKiem.Location = new System.Drawing.Point(450, 18);
            this.btnTimKiem.Size = new System.Drawing.Size(115, 25);
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            // dgvNhanVien
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.Location = new System.Drawing.Point(10, 75);
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.Size = new System.Drawing.Size(580, 445);
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellClick);

            // grpInfo
            this.grpInfo.Controls.Add(this.lblHoTen);
            this.grpInfo.Controls.Add(this.txtHoTen);
            this.grpInfo.Controls.Add(this.lblNgaySinh);
            this.grpInfo.Controls.Add(this.dtpNgaySinh);
            this.grpInfo.Controls.Add(this.lblCCCD);
            this.grpInfo.Controls.Add(this.txtCCCD);
            this.grpInfo.Controls.Add(this.lblPhongBan);
            this.grpInfo.Controls.Add(this.cboPhongBanForm);
            this.grpInfo.Controls.Add(this.lblLuongCB);
            this.grpInfo.Controls.Add(this.txtLuongCoBan);
            this.grpInfo.Controls.Add(this.lblHeSo);
            this.grpInfo.Controls.Add(this.txtHeSoLuong);
            this.grpInfo.Controls.Add(this.btnThem);
            this.grpInfo.Controls.Add(this.btnSua);
            this.grpInfo.Controls.Add(this.btnXoa);
            this.grpInfo.Location = new System.Drawing.Point(600, 10);
            this.grpInfo.Size = new System.Drawing.Size(360, 510);
            this.grpInfo.Text = "Thông tin chi tiết";

            this.lblHoTen.Text = "Họ tên:"; this.lblHoTen.Location = new System.Drawing.Point(20, 30);
            this.txtHoTen.Location = new System.Drawing.Point(120, 27); this.txtHoTen.Size = new System.Drawing.Size(220, 20);

            this.lblNgaySinh.Text = "Ngày sinh:"; this.lblNgaySinh.Location = new System.Drawing.Point(20, 70);
            this.dtpNgaySinh.Location = new System.Drawing.Point(120, 67); this.dtpNgaySinh.Size = new System.Drawing.Size(220, 20);

            this.lblCCCD.Text = "CCCD:"; this.lblCCCD.Location = new System.Drawing.Point(20, 110);
            this.txtCCCD.Location = new System.Drawing.Point(120, 107); this.txtCCCD.Size = new System.Drawing.Size(220, 20);

            this.lblPhongBan.Text = "Phòng ban:"; this.lblPhongBan.Location = new System.Drawing.Point(20, 150);
            this.cboPhongBanForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhongBanForm.Location = new System.Drawing.Point(120, 147); this.cboPhongBanForm.Size = new System.Drawing.Size(220, 21);

            this.lblLuongCB.Text = "Lương cơ bản:"; this.lblLuongCB.Location = new System.Drawing.Point(20, 190);
            this.txtLuongCoBan.Location = new System.Drawing.Point(120, 187); this.txtLuongCoBan.Size = new System.Drawing.Size(220, 20);

            this.lblHeSo.Text = "Hệ số lương:"; this.lblHeSo.Location = new System.Drawing.Point(20, 230);
            this.txtHeSoLuong.Location = new System.Drawing.Point(120, 227); this.txtHeSoLuong.Size = new System.Drawing.Size(220, 20);

            this.btnThem.Text = "Thêm"; this.btnThem.Location = new System.Drawing.Point(20, 280); this.btnThem.Size = new System.Drawing.Size(90, 35); this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.Text = "Sửa"; this.btnSua.Location = new System.Drawing.Point(135, 280); this.btnSua.Size = new System.Drawing.Size(90, 35); this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnXoa.Text = "Xóa"; this.btnXoa.Location = new System.Drawing.Point(250, 280); this.btnXoa.Size = new System.Drawing.Size(90, 35); this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // 
            // TAB 2: CHẤM CÔNG NGẮT KẾT NỐI (DISCONNECTED MODEL)
            // 
            this.tabChamCong.Controls.Add(this.lblThangNam);
            this.tabChamCong.Controls.Add(this.dtpThangNam);
            this.tabChamCong.Controls.Add(this.btnTaiChamCong);
            this.tabChamCong.Controls.Add(this.btnLuuChamCong);
            this.tabChamCong.Controls.Add(this.dgvChamCong);
            this.tabChamCong.Location = new System.Drawing.Point(4, 22);
            this.tabChamCong.Name = "tabChamCong";
            this.tabChamCong.Size = new System.Drawing.Size(972, 534);
            this.tabChamCong.Text = "Chấm công hàng tháng (Disconnected Model)";

            this.lblThangNam.Text = "Chọn Tháng/Năm:"; this.lblThangNam.Location = new System.Drawing.Point(15, 20);
            this.dtpThangNam.Location = new System.Drawing.Point(130, 17); this.dtpThangNam.Size = new System.Drawing.Size(120, 20);

            this.btnTaiChamCong.Text = "Tải bảng chấm công"; this.btnTaiChamCong.Location = new System.Drawing.Point(270, 15); this.btnTaiChamCong.Size = new System.Drawing.Size(150, 25); this.btnTaiChamCong.Click += new System.EventHandler(this.btnTaiChamCong_Click);
            this.btnLuuChamCong.Text = "LƯU CHẤM CÔNG (Adapter.Update)"; this.btnLuuChamCong.Location = new System.Drawing.Point(430, 15); this.btnLuuChamCong.Size = new System.Drawing.Size(240, 25); this.btnLuuChamCong.Click += new System.EventHandler(this.btnLuuChamCong_Click);

            this.dgvChamCong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChamCong.Location = new System.Drawing.Point(15, 50);
            this.dgvChamCong.Size = new System.Drawing.Size(940, 470);

            // 
            // TAB 3: BẢNG LƯƠNG & CHỐT LƯƠNG (SQLTRANSACTION)
            // 
            this.tabBangLuong.Controls.Add(this.btnChotLuong);
            this.tabBangLuong.Controls.Add(this.dgvBangLuong);
            this.tabBangLuong.Location = new System.Drawing.Point(4, 22);
            this.tabBangLuong.Name = "tabBangLuong";
            this.tabBangLuong.Size = new System.Drawing.Size(972, 534);
            this.tabBangLuong.Text = "Tính & Chốt Lương (SqlTransaction)";

            this.btnChotLuong.BackColor = System.Drawing.Color.DarkGreen;
            this.btnChotLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnChotLuong.ForeColor = System.Drawing.Color.White;
            this.btnChotLuong.Location = new System.Drawing.Point(15, 15);
            this.btnChotLuong.Size = new System.Drawing.Size(940, 40);
            this.btnChotLuong.Text = "CHỐT LƯƠNG THÁNG THỰC THI SQLTRANSACTION";
            this.btnChotLuong.UseVisualStyleBackColor = false;
            this.btnChotLuong.Click += new System.EventHandler(this.btnChotLuong_Click);

            this.dgvBangLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBangLuong.Location = new System.Drawing.Point(15, 65);
            this.dgvBangLuong.ReadOnly = true;
            this.dgvBangLuong.Size = new System.Drawing.Size(940, 455);

            // 
            // FormHRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 560);
            this.Controls.Add(this.tabControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormHRM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Nhân sự & Tính lương (HRM & Payroll System)";

            this.tabControlMain.ResumeLayout(false);
            this.tabNhanVien.ResumeLayout(false);
            this.tabChamCong.ResumeLayout(false);
            this.tabBangLuong.ResumeLayout(false);
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangLuong)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabNhanVien;
        private System.Windows.Forms.TabPage tabChamCong;
        private System.Windows.Forms.TabPage tabBangLuong;

        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboPhongBanSearch;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvNhanVien;

        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.ComboBox cboPhongBanForm;
        private System.Windows.Forms.TextBox txtLuongCoBan;
        private System.Windows.Forms.TextBox txtHeSoLuong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;

        private System.Windows.Forms.Label lblThangNam;
        private System.Windows.Forms.DateTimePicker dtpThangNam;
        private System.Windows.Forms.Button btnTaiChamCong;
        private System.Windows.Forms.Button btnLuuChamCong;
        private System.Windows.Forms.DataGridView dgvChamCong;

        private System.Windows.Forms.Button btnChotLuong;
        private System.Windows.Forms.DataGridView dgvBangLuong;

        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.Label lblPhongBan;
        private System.Windows.Forms.Label lblLuongCB;
        private System.Windows.Forms.Label lblHeSo;
    }
}