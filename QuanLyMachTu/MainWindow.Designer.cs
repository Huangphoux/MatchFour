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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            panel_Menu = new Panel();
            iconButton_CaiDat = new FontAwesome.Sharp.IconButton();
            iconButton_TaiChinh = new FontAwesome.Sharp.IconButton();
            iconButton_QuanLy = new FontAwesome.Sharp.IconButton();
            iconButton_LichHen = new FontAwesome.Sharp.IconButton();
            iconButton_TomTat = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            iconPictureBox_Home = new FontAwesome.Sharp.IconPictureBox();
            panel_TitleBar = new Panel();
            label_TitleChildForm = new Label();
            panel_Menu.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_Home).BeginInit();
            panel_TitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Menu
            // 
            panel_Menu.BackColor = Color.WhiteSmoke;
            panel_Menu.BorderStyle = BorderStyle.FixedSingle;
            panel_Menu.Controls.Add(iconButton_CaiDat);
            panel_Menu.Controls.Add(iconButton_TaiChinh);
            panel_Menu.Controls.Add(iconButton_QuanLy);
            panel_Menu.Controls.Add(iconButton_LichHen);
            panel_Menu.Controls.Add(iconButton_TomTat);
            panel_Menu.Controls.Add(panel1);
            resources.ApplyResources(panel_Menu, "panel_Menu");
            panel_Menu.Name = "panel_Menu";
            // 
            // iconButton_CaiDat
            // 
            iconButton_CaiDat.BackColor = Color.White;
            resources.ApplyResources(iconButton_CaiDat, "iconButton_CaiDat");
            iconButton_CaiDat.FlatAppearance.BorderColor = Color.Silver;
            iconButton_CaiDat.FlatAppearance.BorderSize = 0;
            iconButton_CaiDat.ForeColor = Color.Black;
            iconButton_CaiDat.IconChar = FontAwesome.Sharp.IconChar.Cog;
            iconButton_CaiDat.IconColor = Color.Black;
            iconButton_CaiDat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton_CaiDat.IconSize = 50;
            iconButton_CaiDat.Name = "iconButton_CaiDat";
            iconButton_CaiDat.UseVisualStyleBackColor = false;
            iconButton_CaiDat.Click += iconButton_CaiDat_Click;
            // 
            // iconButton_TaiChinh
            // 
            iconButton_TaiChinh.BackColor = Color.White;
            resources.ApplyResources(iconButton_TaiChinh, "iconButton_TaiChinh");
            iconButton_TaiChinh.FlatAppearance.BorderColor = Color.Silver;
            iconButton_TaiChinh.FlatAppearance.BorderSize = 0;
            iconButton_TaiChinh.ForeColor = Color.Black;
            iconButton_TaiChinh.IconChar = FontAwesome.Sharp.IconChar.SackDollar;
            iconButton_TaiChinh.IconColor = Color.Black;
            iconButton_TaiChinh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton_TaiChinh.IconSize = 50;
            iconButton_TaiChinh.Name = "iconButton_TaiChinh";
            iconButton_TaiChinh.UseVisualStyleBackColor = false;
            iconButton_TaiChinh.Click += iconButton_TaiChinh_Click;
            // 
            // iconButton_QuanLy
            // 
            iconButton_QuanLy.BackColor = Color.White;
            resources.ApplyResources(iconButton_QuanLy, "iconButton_QuanLy");
            iconButton_QuanLy.FlatAppearance.BorderColor = Color.Silver;
            iconButton_QuanLy.FlatAppearance.BorderSize = 0;
            iconButton_QuanLy.ForeColor = Color.Black;
            iconButton_QuanLy.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            iconButton_QuanLy.IconColor = Color.Black;
            iconButton_QuanLy.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton_QuanLy.IconSize = 50;
            iconButton_QuanLy.Name = "iconButton_QuanLy";
            iconButton_QuanLy.UseVisualStyleBackColor = false;
            iconButton_QuanLy.Click += iconButton_QuanLy_Click;
            // 
            // iconButton_LichHen
            // 
            iconButton_LichHen.BackColor = Color.White;
            resources.ApplyResources(iconButton_LichHen, "iconButton_LichHen");
            iconButton_LichHen.FlatAppearance.BorderColor = Color.Silver;
            iconButton_LichHen.FlatAppearance.BorderSize = 0;
            iconButton_LichHen.ForeColor = Color.Black;
            iconButton_LichHen.IconChar = FontAwesome.Sharp.IconChar.CalendarWeek;
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
            // panel1
            // 
            panel1.BackColor = Color.LightGray;
            panel1.Controls.Add(iconPictureBox_Home);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // iconPictureBox_Home
            // 
            iconPictureBox_Home.BackColor = Color.LightGray;
            iconPictureBox_Home.ForeColor = SystemColors.ControlText;
            iconPictureBox_Home.IconChar = FontAwesome.Sharp.IconChar.ClinicMedical;
            iconPictureBox_Home.IconColor = SystemColors.ControlText;
            iconPictureBox_Home.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox_Home.IconSize = 120;
            resources.ApplyResources(iconPictureBox_Home, "iconPictureBox_Home");
            iconPictureBox_Home.Name = "iconPictureBox_Home";
            iconPictureBox_Home.TabStop = false;
            iconPictureBox_Home.Click += iconPictureBox1_Click;
            // 
            // panel_TitleBar
            // 
            panel_TitleBar.BackColor = Color.Gainsboro;
            panel_TitleBar.Controls.Add(label_TitleChildForm);
            resources.ApplyResources(panel_TitleBar, "panel_TitleBar");
            panel_TitleBar.Name = "panel_TitleBar";
            // 
            // label_TitleChildForm
            // 
            resources.ApplyResources(label_TitleChildForm, "label_TitleChildForm");
            label_TitleChildForm.Name = "label_TitleChildForm";
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(panel_TitleBar);
            Controls.Add(panel_Menu);
            Name = "MainWindow";
            panel_Menu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_Home).EndInit();
            panel_TitleBar.ResumeLayout(false);
            panel_TitleBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Menu;
        private FontAwesome.Sharp.IconButton iconButton_TomTat;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton_CaiDat;
        private FontAwesome.Sharp.IconButton iconButton_TaiChinh;
        private FontAwesome.Sharp.IconButton iconButton_LichHen;
        private FontAwesome.Sharp.IconButton iconButton_QuanLy;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox_Home;
        private Panel panel_TitleBar;
        private Label label_TitleChildForm;
    }
}
