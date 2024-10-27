namespace QuanLyMachTu
{
    partial class MatchFour
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchFour));
            LichHen = new TabPage();
            TomTat = new TabPage();
            flatTabControl = new DarkModeForms.FlatTabControl();
            flatTabControl.SuspendLayout();
            SuspendLayout();
            // 
            // LichHen
            // 
            LichHen.BackColor = SystemColors.ControlLight;
            resources.ApplyResources(LichHen, "LichHen");
            LichHen.Name = "LichHen";
            // 
            // TomTat
            // 
            TomTat.BackColor = SystemColors.ControlLight;
            resources.ApplyResources(TomTat, "TomTat");
            TomTat.Name = "TomTat";
            // 
            // flatTabControl
            // 
            resources.ApplyResources(flatTabControl, "flatTabControl");
            flatTabControl.BorderColor = SystemColors.ControlDark;
            flatTabControl.Controls.Add(TomTat);
            flatTabControl.Controls.Add(LichHen);
            flatTabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            flatTabControl.LineColor = SystemColors.Highlight;
            flatTabControl.Multiline = true;
            flatTabControl.Name = "flatTabControl";
            flatTabControl.SelectedForeColor = SystemColors.HighlightText;
            flatTabControl.SelectedIndex = 0;
            flatTabControl.SelectTabColor = SystemColors.ControlLight;
            flatTabControl.ShowTabCloseButton = false;
            flatTabControl.SizeMode = TabSizeMode.Fixed;
            flatTabControl.TabCloseColor = SystemColors.ControlText;
            flatTabControl.TabColor = SystemColors.ControlLight;
            // 
            // MatchFour
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flatTabControl);
            Name = "MatchFour";
            flatTabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage LichHen;
        private TabPage TomTat;
        private DarkModeForms.FlatTabControl flatTabControl;
    }
}
