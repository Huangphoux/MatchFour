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
            iconButton_LichHen = new FontAwesome.Sharp.IconButton();
            iconButton_TrangChu = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            panel_Menu.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Menu
            // 
            panel_Menu.BackColor = Color.WhiteSmoke;
            panel_Menu.BorderStyle = BorderStyle.FixedSingle;
            panel_Menu.Controls.Add(iconButton_CaiDat);
            panel_Menu.Controls.Add(iconButton_TaiChinh);
            panel_Menu.Controls.Add(iconButton_LichHen);
            panel_Menu.Controls.Add(iconButton_TrangChu);
            panel_Menu.Controls.Add(panel1);
            resources.ApplyResources(panel_Menu, "panel_Menu");
            panel_Menu.Name = "panel_Menu";
            // 
            // iconButton_CaiDat
            // 
            resources.ApplyResources(iconButton_CaiDat, "iconButton_CaiDat");
            iconButton_CaiDat.FlatAppearance.BorderColor = Color.Gainsboro;
            iconButton_CaiDat.ForeColor = Color.Black;
            iconButton_CaiDat.IconChar = FontAwesome.Sharp.IconChar.Cog;
            iconButton_CaiDat.IconColor = Color.Black;
            iconButton_CaiDat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton_CaiDat.IconSize = 60;
            iconButton_CaiDat.Name = "iconButton_CaiDat";
            iconButton_CaiDat.UseVisualStyleBackColor = true;
            // 
            // iconButton_TaiChinh
            // 
            resources.ApplyResources(iconButton_TaiChinh, "iconButton_TaiChinh");
            iconButton_TaiChinh.FlatAppearance.BorderColor = Color.Gainsboro;
            iconButton_TaiChinh.ForeColor = Color.Black;
            iconButton_TaiChinh.IconChar = FontAwesome.Sharp.IconChar.SackDollar;
            iconButton_TaiChinh.IconColor = Color.Black;
            iconButton_TaiChinh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton_TaiChinh.IconSize = 60;
            iconButton_TaiChinh.Name = "iconButton_TaiChinh";
            iconButton_TaiChinh.UseVisualStyleBackColor = true;
            // 
            // iconButton_LichHen
            // 
            resources.ApplyResources(iconButton_LichHen, "iconButton_LichHen");
            iconButton_LichHen.FlatAppearance.BorderColor = Color.Gainsboro;
            iconButton_LichHen.ForeColor = Color.Black;
            iconButton_LichHen.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            iconButton_LichHen.IconColor = Color.Black;
            iconButton_LichHen.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton_LichHen.IconSize = 60;
            iconButton_LichHen.Name = "iconButton_LichHen";
            iconButton_LichHen.UseVisualStyleBackColor = true;
            // 
            // iconButton_TrangChu
            // 
            resources.ApplyResources(iconButton_TrangChu, "iconButton_TrangChu");
            iconButton_TrangChu.FlatAppearance.BorderColor = Color.Gainsboro;
            iconButton_TrangChu.ForeColor = Color.Black;
            iconButton_TrangChu.IconChar = FontAwesome.Sharp.IconChar.House;
            iconButton_TrangChu.IconColor = Color.Black;
            iconButton_TrangChu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton_TrangChu.IconSize = 60;
            iconButton_TrangChu.Name = "iconButton_TrangChu";
            iconButton_TrangChu.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGray;
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(panel_Menu);
            Name = "MainWindow";
            panel_Menu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Menu;
        private FontAwesome.Sharp.IconButton iconButton_TrangChu;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton_CaiDat;
        private FontAwesome.Sharp.IconButton iconButton_TaiChinh;
        private FontAwesome.Sharp.IconButton iconButton_LichHen;
    }
}
