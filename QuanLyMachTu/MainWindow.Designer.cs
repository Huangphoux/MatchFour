using QuanLyMachTu.Controls;
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
            label_Clock = new Label();
            pageButton_DichVu = new PageButton();
            pictureBox_logo = new PictureBox();
            pageButton_DuocPham = new PageButton();
            pageButton_PhongKham = new PageButton();
            pageButton_NhanVien = new PageButton();
            pageButton_BenhNhan = new PageButton();
            pageButton_TongQuan = new PageButton();
            panel_TitleBar = new Panel();
            pageButton_SignOut = new PageButton();
            pageButton_CaiDat = new PageButton();
            pageButton_ThongTin = new PageButton();
            panel_DivideLabel = new Panel();
            panel_DivideButton = new Panel();
            panel_DivideExit = new Panel();
            timer_Clock = new System.Windows.Forms.Timer(components);
            benhNhanControl = new BenhNhanControl();
            phongKhamControl = new PhongKhamControl();
            dichVuControl = new DichVuControl();
            nhanVienControl = new NhanVienControl();
            duocPhamControl = new DuocPhamControl();
            tongQuanControl = new TongQuanControl();
            panel_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).BeginInit();
            panel_TitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Menu
            // 
            resources.ApplyResources(panel_Menu, "panel_Menu");
            panel_Menu.BackColor = Color.FromArgb(57, 54, 70);
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
            pageButton_DichVu.Click += pageButton_DichVu_Click;
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
            pageButton_DuocPham.Click += pageButton_DuocPham_Click;
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
            pageButton_NhanVien.Click += pageButton_NhanVien_Click;
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
            panel_TitleBar.Controls.Add(pageButton_SignOut);
            panel_TitleBar.Controls.Add(pageButton_CaiDat);
            panel_TitleBar.Controls.Add(pageButton_ThongTin);
            panel_TitleBar.Controls.Add(panel_DivideLabel);
            panel_TitleBar.Controls.Add(panel_DivideButton);
            panel_TitleBar.Controls.Add(panel_DivideExit);
            resources.ApplyResources(panel_TitleBar, "panel_TitleBar");
            panel_TitleBar.Name = "panel_TitleBar";
            // 
            // pageButton_SignOut
            // 
            resources.ApplyResources(pageButton_SignOut, "pageButton_SignOut");
            pageButton_SignOut.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_SignOut.BorderColor = Color.PaleVioletRed;
            pageButton_SignOut.BorderRadius = 40;
            pageButton_SignOut.BorderSize = 0;
            pageButton_SignOut.CustomText = null;
            pageButton_SignOut.FlatAppearance.BorderSize = 0;
            pageButton_SignOut.ForeColor = Color.FromArgb(57, 54, 70);
            pageButton_SignOut.Icon = (Image)resources.GetObject("pageButton_SignOut.Icon");
            pageButton_SignOut.IconLocation = new Point(15, 15);
            pageButton_SignOut.IconSize = new Size(30, 30);
            pageButton_SignOut.Name = "pageButton_SignOut";
            pageButton_SignOut.TextLocation = new Point(0, 0);
            pageButton_SignOut.UseVisualStyleBackColor = false;
            pageButton_SignOut.Click += pageButton_SignOut_Click;
            // 
            // pageButton_CaiDat
            // 
            resources.ApplyResources(pageButton_CaiDat, "pageButton_CaiDat");
            pageButton_CaiDat.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_CaiDat.BorderColor = Color.PaleVioletRed;
            pageButton_CaiDat.BorderRadius = 40;
            pageButton_CaiDat.BorderSize = 0;
            pageButton_CaiDat.CustomText = null;
            pageButton_CaiDat.FlatAppearance.BorderSize = 0;
            pageButton_CaiDat.ForeColor = Color.FromArgb(57, 54, 70);
            pageButton_CaiDat.Icon = (Image)resources.GetObject("pageButton_CaiDat.Icon");
            pageButton_CaiDat.IconLocation = new Point(12, 12);
            pageButton_CaiDat.IconSize = new Size(35, 35);
            pageButton_CaiDat.Name = "pageButton_CaiDat";
            pageButton_CaiDat.TextLocation = new Point(0, 0);
            pageButton_CaiDat.UseVisualStyleBackColor = false;
            pageButton_CaiDat.Click += iconButton_CaiDat_Click;
            // 
            // pageButton_ThongTin
            // 
            resources.ApplyResources(pageButton_ThongTin, "pageButton_ThongTin");
            pageButton_ThongTin.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_ThongTin.BorderColor = Color.PaleVioletRed;
            pageButton_ThongTin.BorderRadius = 40;
            pageButton_ThongTin.BorderSize = 0;
            pageButton_ThongTin.CustomText = null;
            pageButton_ThongTin.FlatAppearance.BorderSize = 0;
            pageButton_ThongTin.ForeColor = Color.FromArgb(57, 54, 70);
            pageButton_ThongTin.Icon = (Image)resources.GetObject("pageButton_ThongTin.Icon");
            pageButton_ThongTin.IconLocation = new Point(12, 12);
            pageButton_ThongTin.IconSize = new Size(35, 35);
            pageButton_ThongTin.Name = "pageButton_ThongTin";
            pageButton_ThongTin.TextLocation = new Point(0, 0);
            pageButton_ThongTin.UseVisualStyleBackColor = false;
            pageButton_ThongTin.Click += pageButton_ThongTin_Click;
            // 
            // panel_DivideLabel
            // 
            panel_DivideLabel.BackColor = Color.Black;
            resources.ApplyResources(panel_DivideLabel, "panel_DivideLabel");
            panel_DivideLabel.Name = "panel_DivideLabel";
            // 
            // panel_DivideButton
            // 
            panel_DivideButton.BackColor = Color.Black;
            resources.ApplyResources(panel_DivideButton, "panel_DivideButton");
            panel_DivideButton.Name = "panel_DivideButton";
            // 
            // panel_DivideExit
            // 
            panel_DivideExit.BackColor = Color.Black;
            resources.ApplyResources(panel_DivideExit, "panel_DivideExit");
            panel_DivideExit.Name = "panel_DivideExit";
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
            phongKhamControl.BackColor = Color.FromArgb(57, 54, 70);
            resources.ApplyResources(phongKhamControl, "phongKhamControl");
            phongKhamControl.Name = "phongKhamControl";
            // 
            // dichVuControl
            // 
            dichVuControl.BackColor = Color.FromArgb(57, 54, 70);
            resources.ApplyResources(dichVuControl, "dichVuControl");
            dichVuControl.Name = "dichVuControl";
            // 
            // nhanVienControl
            // 
            resources.ApplyResources(nhanVienControl, "nhanVienControl");
            nhanVienControl.BackColor = Color.FromArgb(57, 54, 70);
            nhanVienControl.Name = "nhanVienControl";
            // 
            // duocPhamControl
            // 
            duocPhamControl.BackColor = Color.FromArgb(57, 54, 70);
            resources.ApplyResources(duocPhamControl, "duocPhamControl");
            duocPhamControl.Name = "duocPhamControl";
            // 
            // tongQuanControl
            // 
            tongQuanControl.BackColor = Color.FromArgb(57, 54, 70);
            resources.ApplyResources(tongQuanControl, "tongQuanControl");
            tongQuanControl.Name = "tongQuanControl";
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(tongQuanControl);
            Controls.Add(duocPhamControl);
            Controls.Add(dichVuControl);
            Controls.Add(phongKhamControl);
            Controls.Add(nhanVienControl);
            Controls.Add(benhNhanControl);
            Controls.Add(panel_TitleBar);
            Controls.Add(panel_Menu);
            Name = "MainWindow";
            Load += MainWindow_Load;
            Resize += MainWindow_Resize;
            panel_Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).EndInit();
            panel_TitleBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Menu;
        private Panel panel_TitleBar;
        private Label label_Clock;
        private System.Windows.Forms.Timer timer_Clock;
        private Panel panel_DivideButton;
        private Panel panel_DivideLabel;
        private Panel panel_DivideExit;
        private PageButton pageButton_TongQuan;
        private PageButton pageButton_BenhNhan;
        private PageButton pageButton_DuocPham;
        private PageButton pageButton_DichVu;
        private PageButton pageButton_NhanVien;
        private PageButton pageButton_PhongKham;
        private PictureBox pictureBox_logo;
        private PageButton pageButton_ThongTin;
        private PageButton pageButton_CaiDat;
        private BenhNhanControl benhNhanControl;
        private PhongKhamControl phongKhamControl;
        private DichVuControl dichVuControl;
        private PageButton pageButton_SignOut;
        private NhanVienControl nhanVienControl;
        private DuocPhamControl duocPhamControl;
        private TongQuanControl tongQuanControl;
    }
}
