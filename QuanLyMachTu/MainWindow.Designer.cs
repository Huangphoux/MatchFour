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
            panel1 = new Panel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            panel_Menu.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Menu
            // 
            panel_Menu.BackColor = Color.Navy;
            panel_Menu.Controls.Add(iconButton1);
            panel_Menu.Controls.Add(panel1);
            resources.ApplyResources(panel_Menu, "panel_Menu");
            panel_Menu.Name = "panel_Menu";
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // iconButton1
            // 
            resources.ApplyResources(iconButton1, "iconButton1");
            iconButton1.FlatAppearance.BorderColor = Color.White;
            iconButton1.ForeColor = Color.White;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.Calendar;
            iconButton1.IconColor = Color.White;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Name = "iconButton1";
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel_Menu);
            Name = "MainWindow";
            Paint += MainWindow_Paint;
            panel_Menu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Menu;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Panel panel1;
    }
}
