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
            iconButton_HoaDon = new FontAwesome.Sharp.IconButton();
            iconButton_DichVu = new FontAwesome.Sharp.IconButton();
            iconButton_DuocPham = new FontAwesome.Sharp.IconButton();
            iconButton_NhanVien = new FontAwesome.Sharp.IconButton();
            iconButton_PhongKham = new FontAwesome.Sharp.IconButton();
            iconButton_BenhNhan = new FontAwesome.Sharp.IconButton();
            iconButton_LichHen = new FontAwesome.Sharp.IconButton();
            iconButton_TomTat = new FontAwesome.Sharp.IconButton();
            panel_Logo = new Panel();
            label_Clock = new Label();
            icon_Home = new FontAwesome.Sharp.IconPictureBox();
            panel_TitleBar = new Panel();
            label_TitleChildForm = new Label();
            panel_DivideLabel = new Panel();
            icon_CaiDat = new FontAwesome.Sharp.IconPictureBox();
            panel_DivideButton = new Panel();
            icon_ThongTin = new FontAwesome.Sharp.IconPictureBox();
            panel_DivideExit = new Panel();
            icon_Thoat = new FontAwesome.Sharp.IconPictureBox();
            panel_ChildForm = new Panel();
            customGrpBox_TaiChinh = new CustomGrpBox();
            customGrpBox_LichHen = new CustomGrpBox();
            timer_Clock = new System.Windows.Forms.Timer(components);
            panel_Menu.SuspendLayout();
            panel_Logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon_Home).BeginInit();
            panel_TitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon_CaiDat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)icon_ThongTin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)icon_Thoat).BeginInit();
            panel_ChildForm.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Menu
            // 
            resources.ApplyResources(panel_Menu, "panel_Menu");
            panel_Menu.BackColor = Color.WhiteSmoke;
            panel_Menu.BorderStyle = BorderStyle.FixedSingle;
            panel_Menu.Controls.Add(iconButton_HoaDon);
            panel_Menu.Controls.Add(iconButton_DichVu);
            panel_Menu.Controls.Add(iconButton_DuocPham);
            panel_Menu.Controls.Add(iconButton_NhanVien);
            panel_Menu.Controls.Add(iconButton_PhongKham);
            panel_Menu.Controls.Add(iconButton_BenhNhan);
            panel_Menu.Controls.Add(iconButton_LichHen);
            panel_Menu.Controls.Add(iconButton_TomTat);
            panel_Menu.Controls.Add(panel_Logo);
            panel_Menu.Name = "panel_Menu";
            // 
            // iconButton_HoaDon
            // 
            iconButton_HoaDon.BackColor = Color.White;
            resources.ApplyResources(iconButton_HoaDon, "iconButton_HoaDon");
            iconButton_HoaDon.FlatAppearance.BorderColor = Color.Silver;
            iconButton_HoaDon.FlatAppearance.BorderSize = 0;
            iconButton_HoaDon.ForeColor = Color.Black;
            iconButton_HoaDon.IconChar = FontAwesome.Sharp.IconChar.MoneyBill;
            iconButton_HoaDon.IconColor = Color.Black;
            iconButton_HoaDon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton_HoaDon.IconSize = 50;
            iconButton_HoaDon.Name = "iconButton_HoaDon";
            iconButton_HoaDon.UseVisualStyleBackColor = false;
            iconButton_HoaDon.Click += iconButton_HoaDon_Click;
            // 
            // iconButton_DichVu
            // 
            iconButton_DichVu.BackColor = Color.White;
            resources.ApplyResources(iconButton_DichVu, "iconButton_DichVu");
            iconButton_DichVu.FlatAppearance.BorderColor = Color.Silver;
            iconButton_DichVu.FlatAppearance.BorderSize = 0;
            iconButton_DichVu.ForeColor = Color.Black;
            iconButton_DichVu.IconChar = FontAwesome.Sharp.IconChar.HandHoldingMedical;
            iconButton_DichVu.IconColor = Color.Black;
            iconButton_DichVu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton_DichVu.IconSize = 50;
            iconButton_DichVu.Name = "iconButton_DichVu";
            iconButton_DichVu.UseVisualStyleBackColor = false;
            iconButton_DichVu.Click += iconButton_DichVu_Click;
            // 
            // iconButton_DuocPham
            // 
            iconButton_DuocPham.BackColor = Color.White;
            resources.ApplyResources(iconButton_DuocPham, "iconButton_DuocPham");
            iconButton_DuocPham.FlatAppearance.BorderColor = Color.Silver;
            iconButton_DuocPham.FlatAppearance.BorderSize = 0;
            iconButton_DuocPham.ForeColor = Color.Black;
            iconButton_DuocPham.IconChar = FontAwesome.Sharp.IconChar.Pills;
            iconButton_DuocPham.IconColor = Color.Black;
            iconButton_DuocPham.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton_DuocPham.IconSize = 50;
            iconButton_DuocPham.Name = "iconButton_DuocPham";
            iconButton_DuocPham.UseVisualStyleBackColor = false;
            iconButton_DuocPham.Click += iconButton_DuocPham_Click;
            // 
            // iconButton_NhanVien
            // 
            iconButton_NhanVien.BackColor = Color.White;
            resources.ApplyResources(iconButton_NhanVien, "iconButton_NhanVien");
            iconButton_NhanVien.FlatAppearance.BorderColor = Color.Silver;
            iconButton_NhanVien.FlatAppearance.BorderSize = 0;
            iconButton_NhanVien.ForeColor = Color.Black;
            iconButton_NhanVien.IconChar = FontAwesome.Sharp.IconChar.Users;
            iconButton_NhanVien.IconColor = Color.Black;
            iconButton_NhanVien.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton_NhanVien.IconSize = 50;
            iconButton_NhanVien.Name = "iconButton_NhanVien";
            iconButton_NhanVien.UseVisualStyleBackColor = false;
            iconButton_NhanVien.Click += iconButton_NhanVien_Click;
            // 
            // iconButton_PhongKham
            // 
            iconButton_PhongKham.BackColor = Color.White;
            resources.ApplyResources(iconButton_PhongKham, "iconButton_PhongKham");
            iconButton_PhongKham.FlatAppearance.BorderColor = Color.Silver;
            iconButton_PhongKham.FlatAppearance.BorderSize = 0;
            iconButton_PhongKham.ForeColor = Color.Black;
            iconButton_PhongKham.IconChar = FontAwesome.Sharp.IconChar.HouseMedical;
            iconButton_PhongKham.IconColor = Color.Black;
            iconButton_PhongKham.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton_PhongKham.IconSize = 50;
            iconButton_PhongKham.Name = "iconButton_PhongKham";
            iconButton_PhongKham.UseVisualStyleBackColor = false;
            iconButton_PhongKham.Click += iconButton_PhongKham_Click;
            // 
            // iconButton_BenhNhan
            // 
            iconButton_BenhNhan.BackColor = Color.White;
            resources.ApplyResources(iconButton_BenhNhan, "iconButton_BenhNhan");
            iconButton_BenhNhan.FlatAppearance.BorderColor = Color.Silver;
            iconButton_BenhNhan.FlatAppearance.BorderSize = 0;
            iconButton_BenhNhan.ForeColor = Color.Black;
            iconButton_BenhNhan.IconChar = FontAwesome.Sharp.IconChar.Bed;
            iconButton_BenhNhan.IconColor = Color.Black;
            iconButton_BenhNhan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton_BenhNhan.IconSize = 50;
            iconButton_BenhNhan.Name = "iconButton_BenhNhan";
            iconButton_BenhNhan.UseVisualStyleBackColor = false;
            iconButton_BenhNhan.Click += iconButton_BenhNhan_Click;
            // 
            // iconButton_LichHen
            // 
            iconButton_LichHen.BackColor = Color.White;
            resources.ApplyResources(iconButton_LichHen, "iconButton_LichHen");
            iconButton_LichHen.FlatAppearance.BorderColor = Color.Silver;
            iconButton_LichHen.FlatAppearance.BorderSize = 0;
            iconButton_LichHen.ForeColor = Color.Black;
            iconButton_LichHen.IconChar = FontAwesome.Sharp.IconChar.CalendarDay;
            iconButton_LichHen.IconColor = Color.Black;
            iconButton_LichHen.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton_LichHen.IconSize = 50;
            iconButton_LichHen.Name = "iconButton_LichHen";
            iconButton_LichHen.UseVisualStyleBackColor = false;
            iconButton_LichHen.Click += iconButton_LichHen_Click;
            // 
            // iconButton_TomTat
            // 
            iconButton_TomTat.BackColor = Color.White;
            resources.ApplyResources(iconButton_TomTat, "iconButton_TomTat");
            iconButton_TomTat.FlatAppearance.BorderColor = Color.Silver;
            iconButton_TomTat.FlatAppearance.BorderSize = 0;
            iconButton_TomTat.ForeColor = Color.Black;
            iconButton_TomTat.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            iconButton_TomTat.IconColor = Color.Black;
            iconButton_TomTat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton_TomTat.IconSize = 50;
            iconButton_TomTat.Name = "iconButton_TomTat";
            iconButton_TomTat.UseVisualStyleBackColor = false;
            iconButton_TomTat.Click += iconButton_TomTat_Click;
            // 
            // panel_Logo
            // 
            panel_Logo.BackColor = Color.WhiteSmoke;
            panel_Logo.Controls.Add(label_Clock);
            panel_Logo.Controls.Add(icon_Home);
            resources.ApplyResources(panel_Logo, "panel_Logo");
            panel_Logo.Name = "panel_Logo";
            panel_Logo.Click += icon_Home_Click;
            // 
            // label_Clock
            // 
            resources.ApplyResources(label_Clock, "label_Clock");
            label_Clock.Name = "label_Clock";
            label_Clock.Click += icon_Home_Click;
            // 
            // icon_Home
            // 
            icon_Home.BackColor = Color.Transparent;
            icon_Home.ForeColor = SystemColors.ControlText;
            icon_Home.IconChar = FontAwesome.Sharp.IconChar.HeartPulse;
            icon_Home.IconColor = SystemColors.ControlText;
            icon_Home.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icon_Home.IconSize = 120;
            resources.ApplyResources(icon_Home, "icon_Home");
            icon_Home.Name = "icon_Home";
            icon_Home.TabStop = false;
            icon_Home.Click += icon_Home_Click;
            // 
            // panel_TitleBar
            // 
            panel_TitleBar.BackColor = Color.Gainsboro;
            panel_TitleBar.Controls.Add(label_TitleChildForm);
            panel_TitleBar.Controls.Add(panel_DivideLabel);
            panel_TitleBar.Controls.Add(icon_CaiDat);
            panel_TitleBar.Controls.Add(panel_DivideButton);
            panel_TitleBar.Controls.Add(icon_ThongTin);
            panel_TitleBar.Controls.Add(panel_DivideExit);
            panel_TitleBar.Controls.Add(icon_Thoat);
            resources.ApplyResources(panel_TitleBar, "panel_TitleBar");
            panel_TitleBar.Name = "panel_TitleBar";
            // 
            // label_TitleChildForm
            // 
            resources.ApplyResources(label_TitleChildForm, "label_TitleChildForm");
            label_TitleChildForm.Name = "label_TitleChildForm";
            // 
            // panel_DivideLabel
            // 
            panel_DivideLabel.BackColor = Color.Black;
            resources.ApplyResources(panel_DivideLabel, "panel_DivideLabel");
            panel_DivideLabel.Name = "panel_DivideLabel";
            // 
            // icon_CaiDat
            // 
            icon_CaiDat.BackColor = Color.Gainsboro;
            resources.ApplyResources(icon_CaiDat, "icon_CaiDat");
            icon_CaiDat.ForeColor = SystemColors.ControlText;
            icon_CaiDat.IconChar = FontAwesome.Sharp.IconChar.Cog;
            icon_CaiDat.IconColor = SystemColors.ControlText;
            icon_CaiDat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icon_CaiDat.IconSize = 40;
            icon_CaiDat.Name = "icon_CaiDat";
            icon_CaiDat.TabStop = false;
            icon_CaiDat.Click += iconButton_CaiDat_Click;
            // 
            // panel_DivideButton
            // 
            panel_DivideButton.BackColor = Color.Black;
            resources.ApplyResources(panel_DivideButton, "panel_DivideButton");
            panel_DivideButton.Name = "panel_DivideButton";
            // 
            // icon_ThongTin
            // 
            icon_ThongTin.BackColor = Color.Gainsboro;
            resources.ApplyResources(icon_ThongTin, "icon_ThongTin");
            icon_ThongTin.ForeColor = SystemColors.ControlText;
            icon_ThongTin.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            icon_ThongTin.IconColor = SystemColors.ControlText;
            icon_ThongTin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icon_ThongTin.IconSize = 40;
            icon_ThongTin.Name = "icon_ThongTin";
            icon_ThongTin.TabStop = false;
            icon_ThongTin.Click += iconButton_ThongTin_Click;
            // 
            // panel_DivideExit
            // 
            panel_DivideExit.BackColor = Color.Black;
            resources.ApplyResources(panel_DivideExit, "panel_DivideExit");
            panel_DivideExit.Name = "panel_DivideExit";
            // 
            // icon_Thoat
            // 
            icon_Thoat.BackColor = Color.Gainsboro;
            resources.ApplyResources(icon_Thoat, "icon_Thoat");
            icon_Thoat.ForeColor = SystemColors.ControlText;
            icon_Thoat.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            icon_Thoat.IconColor = SystemColors.ControlText;
            icon_Thoat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icon_Thoat.IconSize = 40;
            icon_Thoat.Name = "icon_Thoat";
            icon_Thoat.TabStop = false;
            icon_Thoat.Click += icon_Thoat_Click;
            // 
            // panel_ChildForm
            // 
            panel_ChildForm.BackColor = Color.White;
            panel_ChildForm.Controls.Add(customGrpBox_TaiChinh);
            panel_ChildForm.Controls.Add(customGrpBox_LichHen);
            resources.ApplyResources(panel_ChildForm, "panel_ChildForm");
            panel_ChildForm.Name = "panel_ChildForm";
            // 
            // customGrpBox_TaiChinh
            // 
            resources.ApplyResources(customGrpBox_TaiChinh, "customGrpBox_TaiChinh");
            customGrpBox_TaiChinh.Name = "customGrpBox_TaiChinh";
            customGrpBox_TaiChinh.TabStop = false;
            // 
            // customGrpBox_LichHen
            // 
            resources.ApplyResources(customGrpBox_LichHen, "customGrpBox_LichHen");
            customGrpBox_LichHen.Name = "customGrpBox_LichHen";
            customGrpBox_LichHen.TabStop = false;
            // 
            // timer_Clock
            // 
            timer_Clock.Enabled = true;
            timer_Clock.Interval = 1000;
            timer_Clock.Tick += timer_Clock_Tick;
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(panel_ChildForm);
            Controls.Add(panel_TitleBar);
            Controls.Add(panel_Menu);
            Name = "MainWindow";
            FormClosing += MainWindow_FormClosing;
            panel_Menu.ResumeLayout(false);
            panel_Logo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)icon_Home).EndInit();
            panel_TitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)icon_CaiDat).EndInit();
            ((System.ComponentModel.ISupportInitialize)icon_ThongTin).EndInit();
            ((System.ComponentModel.ISupportInitialize)icon_Thoat).EndInit();
            panel_ChildForm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Menu;
        private FontAwesome.Sharp.IconButton iconButton_TomTat;
        private Panel panel_Logo;
        private FontAwesome.Sharp.IconButton iconButton_CaiDat;
        private FontAwesome.Sharp.IconButton iconButton_LichHen;
        private FontAwesome.Sharp.IconButton iconButton_BenhNhan;
        private FontAwesome.Sharp.IconPictureBox icon_Home;
        private Panel panel_TitleBar;
        private Label label_TitleChildForm;
        private Panel panel_ChildForm;
        private FontAwesome.Sharp.IconButton iconButton_PhongKham;
        private FontAwesome.Sharp.IconButton iconButton_ThongTin;
        private Label label_Clock;
        private System.Windows.Forms.Timer timer_Clock;
        private FontAwesome.Sharp.IconButton iconButton_HoaDon;
        private CustomGrpBox customGrpBox_TaiChinh;
        private CustomGrpBox customGrpBox_LichHen;
        private FontAwesome.Sharp.IconPictureBox icon_ThongTin;
        private FontAwesome.Sharp.IconPictureBox icon_CaiDat;
        private Panel panel_DivideButton;
        private FontAwesome.Sharp.IconButton iconButton_NhanVien;
        private FontAwesome.Sharp.IconButton iconButton_DuocPham;
        private FontAwesome.Sharp.IconButton iconButton_DichVu;
        private Panel panel_DivideLabel;
        private Panel panel_DivideExit;
        private FontAwesome.Sharp.IconPictureBox icon_Thoat;
    }
}
