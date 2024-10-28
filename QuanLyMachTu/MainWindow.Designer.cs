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
            tabControl_MainWindow = new TabControl();
            TrangChu = new TabPage();
            LichHen = new TabPage();
            QuanLy = new TabPage();
            CaiDat = new TabPage();
            TroGiup = new TabPage();
            tabControl_MainWindow.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl_MainWindow
            // 
            resources.ApplyResources(tabControl_MainWindow, "tabControl_MainWindow");
            tabControl_MainWindow.Controls.Add(TrangChu);
            tabControl_MainWindow.Controls.Add(LichHen);
            tabControl_MainWindow.Controls.Add(QuanLy);
            tabControl_MainWindow.Controls.Add(CaiDat);
            tabControl_MainWindow.Controls.Add(TroGiup);
            tabControl_MainWindow.Multiline = true;
            tabControl_MainWindow.Name = "tabControl_MainWindow";
            tabControl_MainWindow.SelectedIndex = 0;
            tabControl_MainWindow.SizeMode = TabSizeMode.Fixed;
            tabControl_MainWindow.DrawItem += TabControl_MainWindow_DrawItem;
            // 
            // TrangChu
            // 
            resources.ApplyResources(TrangChu, "TrangChu");
            TrangChu.Name = "TrangChu";
            TrangChu.UseVisualStyleBackColor = true;
            // 
            // LichHen
            // 
            resources.ApplyResources(LichHen, "LichHen");
            LichHen.Name = "LichHen";
            LichHen.UseVisualStyleBackColor = true;
            // 
            // QuanLy
            // 
            resources.ApplyResources(QuanLy, "QuanLy");
            QuanLy.Name = "QuanLy";
            QuanLy.UseVisualStyleBackColor = true;
            // 
            // CaiDat
            // 
            resources.ApplyResources(CaiDat, "CaiDat");
            CaiDat.Name = "CaiDat";
            CaiDat.UseVisualStyleBackColor = true;
            // 
            // TroGiup
            // 
            resources.ApplyResources(TroGiup, "TroGiup");
            TroGiup.Name = "TroGiup";
            TroGiup.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl_MainWindow);
            Name = "MainWindow";
            tabControl_MainWindow.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl_MainWindow;
        private TabPage TrangChu;
        private TabPage LichHen;
        private TabPage QuanLy;
        private TabPage CaiDat;
        private TabPage TroGiup;
    }
}
