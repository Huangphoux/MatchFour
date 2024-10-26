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
            flatTabControl1 = new DarkModeForms.FlatTabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            flatTabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // flatTabControl1
            // 
            resources.ApplyResources(flatTabControl1, "flatTabControl1");
            flatTabControl1.BorderColor = SystemColors.ControlDark;
            flatTabControl1.Controls.Add(tabPage1);
            flatTabControl1.Controls.Add(tabPage2);
            flatTabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            flatTabControl1.LineColor = SystemColors.Highlight;
            flatTabControl1.Multiline = true;
            flatTabControl1.Name = "flatTabControl1";
            flatTabControl1.SelectedForeColor = SystemColors.HighlightText;
            flatTabControl1.SelectedIndex = 0;
            flatTabControl1.SelectTabColor = SystemColors.ControlLight;
            flatTabControl1.ShowTabCloseButton = false;
            flatTabControl1.SizeMode = TabSizeMode.Fixed;
            flatTabControl1.TabCloseColor = SystemColors.ControlText;
            flatTabControl1.TabColor = SystemColors.ControlLight;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.ControlLight;
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.Name = "tabPage1";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.ControlLight;
            resources.ApplyResources(tabPage2, "tabPage2");
            tabPage2.Name = "tabPage2";
            // 
            // MatchFour
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flatTabControl1);
            Name = "MatchFour";
            flatTabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DarkModeForms.FlatTabControl flatTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}
