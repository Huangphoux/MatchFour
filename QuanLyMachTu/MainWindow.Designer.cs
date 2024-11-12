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
            pageButton2 = new PageButton();
            pageButton1 = new PageButton();
            panel_DivideLabel = new Panel();
            panel_DivideButton = new Panel();
            panel_DivideExit = new Panel();
            timer_Clock = new System.Windows.Forms.Timer(components);
            benhNhanControl1 = new BenhNhanControl();
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
            pageButton_DichVu.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(pageButton_DichVu, "pageButton_DichVu");
            pageButton_DichVu.ForeColor = Color.FromArgb(0, 173, 181);
            pageButton_DichVu.Icon = (Image)resources.GetObject("pageButton_DichVu.Icon");
            pageButton_DichVu.IconLocation = new Point(40, 31);
            pageButton_DichVu.IconSize = new Size(28, 28);
            pageButton_DichVu.Name = "pageButton_DichVu";
            pageButton_DichVu.Text1 = "Dịch vụ";
            pageButton_DichVu.TextColor = Color.White;
            pageButton_DichVu.TextFont = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
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
            pageButton_DuocPham.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(pageButton_DuocPham, "pageButton_DuocPham");
            pageButton_DuocPham.ForeColor = Color.White;
            pageButton_DuocPham.Icon = (Image)resources.GetObject("pageButton_DuocPham.Icon");
            pageButton_DuocPham.IconLocation = new Point(40, 31);
            pageButton_DuocPham.IconSize = new Size(28, 28);
            pageButton_DuocPham.Name = "pageButton_DuocPham";
            pageButton_DuocPham.Text1 = "Dược phẩm";
            pageButton_DuocPham.TextColor = Color.White;
            pageButton_DuocPham.TextFont = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            pageButton_DuocPham.TextLocation = new Point(98, 28);
            pageButton_DuocPham.UseVisualStyleBackColor = false;
            // 
            // pageButton_PhongKham
            // 
            pageButton_PhongKham.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_PhongKham.BorderColor = Color.FromArgb(238, 238, 238);
            pageButton_PhongKham.BorderRadius = 30;
            pageButton_PhongKham.BorderSize = 0;
            pageButton_PhongKham.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(pageButton_PhongKham, "pageButton_PhongKham");
            pageButton_PhongKham.ForeColor = Color.White;
            pageButton_PhongKham.Icon = (Image)resources.GetObject("pageButton_PhongKham.Icon");
            pageButton_PhongKham.IconLocation = new Point(40, 31);
            pageButton_PhongKham.IconSize = new Size(28, 28);
            pageButton_PhongKham.Name = "pageButton_PhongKham";
            pageButton_PhongKham.Text1 = "Phòng khám";
            pageButton_PhongKham.TextColor = Color.White;
            pageButton_PhongKham.TextFont = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            pageButton_PhongKham.TextLocation = new Point(98, 28);
            pageButton_PhongKham.UseVisualStyleBackColor = false;
            // 
            // pageButton_NhanVien
            // 
            pageButton_NhanVien.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_NhanVien.BorderColor = Color.FromArgb(238, 238, 238);
            pageButton_NhanVien.BorderRadius = 30;
            pageButton_NhanVien.BorderSize = 0;
            pageButton_NhanVien.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(pageButton_NhanVien, "pageButton_NhanVien");
            pageButton_NhanVien.ForeColor = Color.White;
            pageButton_NhanVien.Icon = (Image)resources.GetObject("pageButton_NhanVien.Icon");
            pageButton_NhanVien.IconLocation = new Point(40, 31);
            pageButton_NhanVien.IconSize = new Size(28, 28);
            pageButton_NhanVien.Name = "pageButton_NhanVien";
            pageButton_NhanVien.Text1 = "Nhân viên";
            pageButton_NhanVien.TextColor = Color.White;
            pageButton_NhanVien.TextFont = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            pageButton_NhanVien.TextLocation = new Point(98, 28);
            pageButton_NhanVien.UseVisualStyleBackColor = false;
            // 
            // pageButton_BenhNhan
            // 
            pageButton_BenhNhan.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_BenhNhan.BorderColor = Color.FromArgb(238, 238, 238);
            pageButton_BenhNhan.BorderRadius = 30;
            pageButton_BenhNhan.BorderSize = 0;
            pageButton_BenhNhan.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(pageButton_BenhNhan, "pageButton_BenhNhan");
            pageButton_BenhNhan.ForeColor = Color.White;
            pageButton_BenhNhan.Icon = (Image)resources.GetObject("pageButton_BenhNhan.Icon");
            pageButton_BenhNhan.IconLocation = new Point(40, 31);
            pageButton_BenhNhan.IconSize = new Size(28, 28);
            pageButton_BenhNhan.Name = "pageButton_BenhNhan";
            pageButton_BenhNhan.Text1 = "Bệnh nhân";
            pageButton_BenhNhan.TextColor = Color.White;
            pageButton_BenhNhan.TextFont = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            pageButton_BenhNhan.TextLocation = new Point(98, 28);
            pageButton_BenhNhan.UseVisualStyleBackColor = false;
            pageButton_BenhNhan.Click += iconButton_BenhNhan_Click;
            // 
            // pageButton_TongQuan
            // 
            pageButton_TongQuan.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_TongQuan.BorderColor = Color.FromArgb(238, 238, 238);
            pageButton_TongQuan.BorderRadius = 30;
            pageButton_TongQuan.BorderSize = 0;
            pageButton_TongQuan.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(pageButton_TongQuan, "pageButton_TongQuan");
            pageButton_TongQuan.ForeColor = Color.White;
            pageButton_TongQuan.Icon = (Image)resources.GetObject("pageButton_TongQuan.Icon");
            pageButton_TongQuan.IconLocation = new Point(40, 31);
            pageButton_TongQuan.IconSize = new Size(28, 28);
            pageButton_TongQuan.Name = "pageButton_TongQuan";
            pageButton_TongQuan.Text1 = "Tổng quan";
            pageButton_TongQuan.TextColor = Color.White;
            pageButton_TongQuan.TextFont = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            pageButton_TongQuan.TextLocation = new Point(98, 28);
            pageButton_TongQuan.UseVisualStyleBackColor = false;
            pageButton_TongQuan.Click += pageButton_TongQuat_Click;
            // 
            // panel_TitleBar
            // 
            panel_TitleBar.BackColor = Color.FromArgb(57, 54, 70);
            panel_TitleBar.Controls.Add(pageButton2);
            panel_TitleBar.Controls.Add(pageButton1);
            panel_TitleBar.Controls.Add(panel_DivideLabel);
            panel_TitleBar.Controls.Add(panel_DivideButton);
            panel_TitleBar.Controls.Add(panel_DivideExit);
            resources.ApplyResources(panel_TitleBar, "panel_TitleBar");
            panel_TitleBar.Name = "panel_TitleBar";
            // 
            // pageButton2
            // 
            pageButton2.BackColor = Color.FromArgb(57, 54, 70);
            pageButton2.BorderColor = Color.PaleVioletRed;
            pageButton2.BorderRadius = 40;
            pageButton2.BorderSize = 0;
            pageButton2.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(pageButton2, "pageButton2");
            pageButton2.ForeColor = Color.White;
            pageButton2.Icon = (Image)resources.GetObject("pageButton2.Icon");
            pageButton2.IconLocation = new Point(12, 12);
            pageButton2.IconSize = new Size(35, 35);
            pageButton2.Name = "pageButton2";
            pageButton2.Text1 = "";
            pageButton2.TextColor = Color.FromArgb(57, 54, 70);
            pageButton2.TextFont = new Font("Segoe UI", 12F);
            pageButton2.TextLocation = new Point(0, 0);
            pageButton2.UseVisualStyleBackColor = false;
            // 
            // pageButton1
            // 
            pageButton1.BackColor = Color.FromArgb(57, 54, 70);
            pageButton1.BorderColor = Color.PaleVioletRed;
            pageButton1.BorderRadius = 40;
            pageButton1.BorderSize = 0;
            pageButton1.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(pageButton1, "pageButton1");
            pageButton1.ForeColor = Color.White;
            pageButton1.Icon = (Image)resources.GetObject("pageButton1.Icon");
            pageButton1.IconLocation = new Point(12, 12);
            pageButton1.IconSize = new Size(35, 35);
            pageButton1.Name = "pageButton1";
            pageButton1.Text1 = "";
            pageButton1.TextColor = Color.FromArgb(57, 54, 70);
            pageButton1.TextFont = new Font("Segoe UI", 12F);
            pageButton1.TextLocation = new Point(0, 0);
            pageButton1.UseVisualStyleBackColor = false;
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
            // benhNhanControl1
            // 
            resources.ApplyResources(benhNhanControl1, "benhNhanControl1");
            benhNhanControl1.BackColor = Color.FromArgb(57, 54, 70);
            benhNhanControl1.Name = "benhNhanControl1";
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(benhNhanControl1);
            Controls.Add(panel_TitleBar);
            Controls.Add(panel_Menu);
            Name = "MainWindow";
            FormClosing += MainWindow_FormClosing;
            panel_Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).EndInit();
            panel_TitleBar.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private PageButton pageButton1;
        private PageButton pageButton2;
        private BenhNhanControl benhNhanControl1;
    }
}
