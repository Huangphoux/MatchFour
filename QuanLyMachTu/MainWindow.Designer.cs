using QuanLyMachTu.Custom;

namespace QuanLyMachTu
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            panel_Menu = new Panel();
            pageButton_LichKham = new PageButton();
            pageButton_HoaDon = new PageButton();
            label_Clock = new Label();
            pageButton_DichVu = new PageButton();
            pictureBox_logo = new PictureBox();
            pageButton_DuocPham = new PageButton();
            pageButton_PhongKham = new PageButton();
            pageButton_NhanVien = new PageButton();
            pageButton_BenhNhan = new PageButton();
            pageButton_TongQuan = new PageButton();
            panel_TitleBar = new Panel();
            pageButton2 = new PageButton();
            pageButton1 = new PageButton();
            timer_Clock = new System.Windows.Forms.Timer(components);
            benhNhanControl = new BenhNhanControl();
            phongKhamControl = new PhongKhamControl();
            hoaDonControl = new HoaDonControl();
            panel_CustomControl = new Panel();
            lichKhamControl1 = new LichKhamControl();
            panel_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).BeginInit();
            panel_TitleBar.SuspendLayout();
            panel_CustomControl.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Menu
            // 
            resources.ApplyResources(panel_Menu, "panel_Menu");
            panel_Menu.BackColor = Color.FromArgb(57, 54, 70);
            panel_Menu.Controls.Add(pageButton_LichKham);
            panel_Menu.Controls.Add(pageButton_HoaDon);
            panel_Menu.Controls.Add(label_Clock);
            panel_Menu.Controls.Add(pageButton_DichVu);
            panel_Menu.Controls.Add(pictureBox_logo);
            panel_Menu.Controls.Add(pageButton_DuocPham);
            panel_Menu.Controls.Add(pageButton_PhongKham);
            panel_Menu.Controls.Add(pageButton_NhanVien);
            panel_Menu.Controls.Add(pageButton_BenhNhan);
            panel_Menu.Controls.Add(pageButton_TongQuan);
            panel_Menu.Name = "panel_Menu";
            // 
            // pageButton_LichKham
            // 
            pageButton_LichKham.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_LichKham.BorderColor = Color.FromArgb(238, 238, 238);
            pageButton_LichKham.BorderRadius = 30;
            pageButton_LichKham.BorderSize = 0;
            pageButton_LichKham.CustomText = "Lịch khám";
            pageButton_LichKham.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(pageButton_LichKham, "pageButton_LichKham");
            pageButton_LichKham.ForeColor = Color.White;
            pageButton_LichKham.Icon = (Image)resources.GetObject("pageButton_LichKham.Icon");
            pageButton_LichKham.IconLocation = new Point(40, 31);
            pageButton_LichKham.IconSize = new Size(30, 30);
            pageButton_LichKham.Name = "pageButton_LichKham";
            pageButton_LichKham.TextLocation = new Point(98, 28);
            pageButton_LichKham.UseVisualStyleBackColor = false;
            pageButton_LichKham.Click += pageButton_LichKham_Click;
            // 
            // pageButton_HoaDon
            // 
            pageButton_HoaDon.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_HoaDon.BorderColor = Color.FromArgb(238, 238, 238);
            pageButton_HoaDon.BorderRadius = 30;
            pageButton_HoaDon.BorderSize = 0;
            pageButton_HoaDon.CustomText = "Hoá đơn";
            pageButton_HoaDon.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(pageButton_HoaDon, "pageButton_HoaDon");
            pageButton_HoaDon.ForeColor = Color.White;
            pageButton_HoaDon.Icon = (Image)resources.GetObject("pageButton_HoaDon.Icon");
            pageButton_HoaDon.IconLocation = new Point(40, 31);
            pageButton_HoaDon.IconSize = new Size(28, 28);
            pageButton_HoaDon.Name = "pageButton_HoaDon";
            pageButton_HoaDon.TextLocation = new Point(98, 28);
            pageButton_HoaDon.UseVisualStyleBackColor = false;
            pageButton_HoaDon.Click += pageButton_HoaDon_Click;
            // 
            // label_Clock
            // 
            resources.ApplyResources(label_Clock, "label_Clock");
            label_Clock.ForeColor = Color.White;
            label_Clock.Name = "label_Clock";
            label_Clock.Click += icon_Home_Click;
            // 
            // pageButton_DichVu
            // 
            pageButton_DichVu.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_DichVu.BorderColor = Color.FromArgb(238, 238, 238);
            pageButton_DichVu.BorderRadius = 30;
            pageButton_DichVu.BorderSize = 0;
            pageButton_DichVu.CustomText = "Dịch vụ";
            pageButton_DichVu.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(pageButton_DichVu, "pageButton_DichVu");
            pageButton_DichVu.ForeColor = Color.White;
            pageButton_DichVu.Icon = (Image)resources.GetObject("pageButton_DichVu.Icon");
            pageButton_DichVu.IconLocation = new Point(40, 31);
            pageButton_DichVu.IconSize = new Size(28, 28);
            pageButton_DichVu.Name = "pageButton_DichVu";
            pageButton_DichVu.TextLocation = new Point(98, 28);
            pageButton_DichVu.UseVisualStyleBackColor = false;
            // 
            // pictureBox_logo
            // 
            resources.ApplyResources(pictureBox_logo, "pictureBox_logo");
            pictureBox_logo.Name = "pictureBox_logo";
            pictureBox_logo.TabStop = false;
            // 
            // pageButton_DuocPham
            // 
            pageButton_DuocPham.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_DuocPham.BorderColor = Color.FromArgb(238, 238, 238);
            pageButton_DuocPham.BorderRadius = 30;
            pageButton_DuocPham.BorderSize = 0;
            pageButton_DuocPham.CustomText = "Dược phẩm";
            pageButton_DuocPham.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(pageButton_DuocPham, "pageButton_DuocPham");
            pageButton_DuocPham.ForeColor = Color.White;
            pageButton_DuocPham.Icon = (Image)resources.GetObject("pageButton_DuocPham.Icon");
            pageButton_DuocPham.IconLocation = new Point(40, 31);
            pageButton_DuocPham.IconSize = new Size(28, 28);
            pageButton_DuocPham.Name = "pageButton_DuocPham";
            pageButton_DuocPham.TextLocation = new Point(98, 28);
            pageButton_DuocPham.UseVisualStyleBackColor = false;
            // 
            // pageButton_PhongKham
            // 
            pageButton_PhongKham.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_PhongKham.BorderColor = Color.FromArgb(238, 238, 238);
            pageButton_PhongKham.BorderRadius = 30;
            pageButton_PhongKham.BorderSize = 0;
            pageButton_PhongKham.CustomText = "Phòng khám";
            pageButton_PhongKham.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(pageButton_PhongKham, "pageButton_PhongKham");
            pageButton_PhongKham.ForeColor = Color.White;
            pageButton_PhongKham.Icon = (Image)resources.GetObject("pageButton_PhongKham.Icon");
            pageButton_PhongKham.IconLocation = new Point(40, 31);
            pageButton_PhongKham.IconSize = new Size(28, 28);
            pageButton_PhongKham.Name = "pageButton_PhongKham";
            pageButton_PhongKham.TextLocation = new Point(98, 28);
            pageButton_PhongKham.UseVisualStyleBackColor = false;
            pageButton_PhongKham.Click += pageButton_PhongKham_Click;
            // 
            // pageButton_NhanVien
            // 
            pageButton_NhanVien.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_NhanVien.BorderColor = Color.FromArgb(238, 238, 238);
            pageButton_NhanVien.BorderRadius = 30;
            pageButton_NhanVien.BorderSize = 0;
            pageButton_NhanVien.CustomText = "Nhân viên";
            pageButton_NhanVien.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(pageButton_NhanVien, "pageButton_NhanVien");
            pageButton_NhanVien.ForeColor = Color.White;
            pageButton_NhanVien.Icon = (Image)resources.GetObject("pageButton_NhanVien.Icon");
            pageButton_NhanVien.IconLocation = new Point(40, 31);
            pageButton_NhanVien.IconSize = new Size(28, 28);
            pageButton_NhanVien.Name = "pageButton_NhanVien";
            pageButton_NhanVien.TextLocation = new Point(98, 28);
            pageButton_NhanVien.UseVisualStyleBackColor = false;
            // 
            // pageButton_BenhNhan
            // 
            pageButton_BenhNhan.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_BenhNhan.BorderColor = Color.FromArgb(238, 238, 238);
            pageButton_BenhNhan.BorderRadius = 30;
            pageButton_BenhNhan.BorderSize = 0;
            pageButton_BenhNhan.CustomText = "Bệnh nhân";
            pageButton_BenhNhan.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(pageButton_BenhNhan, "pageButton_BenhNhan");
            pageButton_BenhNhan.ForeColor = Color.White;
            pageButton_BenhNhan.Icon = (Image)resources.GetObject("pageButton_BenhNhan.Icon");
            pageButton_BenhNhan.IconLocation = new Point(40, 31);
            pageButton_BenhNhan.IconSize = new Size(28, 28);
            pageButton_BenhNhan.Name = "pageButton_BenhNhan";
            pageButton_BenhNhan.TextLocation = new Point(98, 28);
            pageButton_BenhNhan.UseVisualStyleBackColor = false;
            pageButton_BenhNhan.Click += pageButton_BenhNhan_Click;
            // 
            // pageButton_TongQuan
            // 
            pageButton_TongQuan.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_TongQuan.BorderColor = Color.FromArgb(238, 238, 238);
            pageButton_TongQuan.BorderRadius = 30;
            pageButton_TongQuan.BorderSize = 0;
            pageButton_TongQuan.CustomText = "Tổng quan";
            pageButton_TongQuan.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(pageButton_TongQuan, "pageButton_TongQuan");
            pageButton_TongQuan.ForeColor = Color.White;
            pageButton_TongQuan.Icon = (Image)resources.GetObject("pageButton_TongQuan.Icon");
            pageButton_TongQuan.IconLocation = new Point(40, 31);
            pageButton_TongQuan.IconSize = new Size(28, 28);
            pageButton_TongQuan.Name = "pageButton_TongQuan";
            pageButton_TongQuan.TextLocation = new Point(98, 28);
            pageButton_TongQuan.UseVisualStyleBackColor = false;
            pageButton_TongQuan.Click += pageButton_TongQuat_Click;
            // 
            // panel_TitleBar
            // 
            panel_TitleBar.BackColor = Color.FromArgb(57, 54, 70);
            panel_TitleBar.Controls.Add(pageButton2);
            panel_TitleBar.Controls.Add(pageButton1);
            resources.ApplyResources(panel_TitleBar, "panel_TitleBar");
            panel_TitleBar.Name = "panel_TitleBar";
            // 
            // pageButton2
            // 
            resources.ApplyResources(pageButton2, "pageButton2");
            pageButton2.BackColor = Color.FromArgb(57, 54, 70);
            pageButton2.BorderColor = Color.PaleVioletRed;
            pageButton2.BorderRadius = 40;
            pageButton2.BorderSize = 0;
            pageButton2.CustomText = null;
            pageButton2.FlatAppearance.BorderSize = 0;
            pageButton2.ForeColor = Color.FromArgb(57, 54, 70);
            pageButton2.Icon = (Image)resources.GetObject("pageButton2.Icon");
            pageButton2.IconLocation = new Point(12, 12);
            pageButton2.IconSize = new Size(35, 35);
            pageButton2.Name = "pageButton2";
            pageButton2.TextLocation = new Point(0, 0);
            pageButton2.UseVisualStyleBackColor = false;
            pageButton2.Click += iconButton_CaiDat_Click;
            // 
            // pageButton1
            // 
            resources.ApplyResources(pageButton1, "pageButton1");
            pageButton1.BackColor = Color.FromArgb(57, 54, 70);
            pageButton1.BorderColor = Color.PaleVioletRed;
            pageButton1.BorderRadius = 40;
            pageButton1.BorderSize = 0;
            pageButton1.CustomText = null;
            pageButton1.FlatAppearance.BorderSize = 0;
            pageButton1.ForeColor = Color.FromArgb(57, 54, 70);
            pageButton1.Icon = (Image)resources.GetObject("pageButton1.Icon");
            pageButton1.IconLocation = new Point(12, 12);
            pageButton1.IconSize = new Size(35, 35);
            pageButton1.Name = "pageButton1";
            pageButton1.TextLocation = new Point(0, 0);
            pageButton1.UseVisualStyleBackColor = false;
            // 
            // timer_Clock
            // 
            timer_Clock.Enabled = true;
            timer_Clock.Interval = 1000;
            timer_Clock.Tick += timer_Clock_Tick;
            // 
            // benhNhanControl
            // 
            resources.ApplyResources(benhNhanControl, "benhNhanControl");
            benhNhanControl.BackColor = Color.FromArgb(57, 54, 70);
            benhNhanControl.Name = "benhNhanControl";
            // 
            // phongKhamControl
            // 
            resources.ApplyResources(phongKhamControl, "phongKhamControl");
            phongKhamControl.BackColor = Color.FromArgb(57, 54, 70);
            phongKhamControl.Name = "phongKhamControl";
            // 
            // hoaDonControl
            // 
            hoaDonControl.BackColor = Color.FromArgb(57, 54, 70);
            resources.ApplyResources(hoaDonControl, "hoaDonControl");
            hoaDonControl.Name = "hoaDonControl";
            // 
            // panel_CustomControl
            // 
            panel_CustomControl.BackColor = Color.FromArgb(57, 54, 70);
            panel_CustomControl.Controls.Add(lichKhamControl1);
            panel_CustomControl.Controls.Add(phongKhamControl);
            panel_CustomControl.Controls.Add(benhNhanControl);
            panel_CustomControl.Controls.Add(hoaDonControl);
            resources.ApplyResources(panel_CustomControl, "panel_CustomControl");
            panel_CustomControl.Name = "panel_CustomControl";
            // 
            // lichKhamControl1
            // 
            lichKhamControl1.BackColor = Color.FromArgb(57, 54, 70);
            resources.ApplyResources(lichKhamControl1, "lichKhamControl1");
            lichKhamControl1.Name = "lichKhamControl1";
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(panel_CustomControl);
            Controls.Add(panel_TitleBar);
            Controls.Add(panel_Menu);
            Name = "MainWindow";
            FormClosing += MainWindow_FormClosing;
            Load += MainWindow_Load;
            panel_Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).EndInit();
            panel_TitleBar.ResumeLayout(false);
            panel_CustomControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Menu;
        private Panel panel_TitleBar;
        private Label label_Clock;
        private System.Windows.Forms.Timer timer_Clock;
        private PageButton pageButton_TongQuan;
        private PageButton pageButton_BenhNhan;
        private PageButton pageButton_DuocPham;
        private PageButton pageButton_DichVu;
        private PageButton pageButton_NhanVien;
        private PageButton pageButton_PhongKham;
        private PictureBox pictureBox_logo;
        private PageButton pageButton1;
        private PageButton pageButton2;
        private BenhNhanControl benhNhanControl;
        private PhongKhamControl phongKhamControl;
        private HoaDonControl hoaDonControl;
        private PageButton pageButton_HoaDon;
        private Panel panel_CustomControl;
        private PageButton pageButton_LichKham;
        private LichKhamControl lichKhamControl1;
    }
}
