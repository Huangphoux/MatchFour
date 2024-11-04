namespace QuanLyMachTu.Child_Forms
{
    partial class Form_ThongTin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_Logo = new Label();
            icon_Home = new FontAwesome.Sharp.IconPictureBox();
            label_Credits = new Label();
            ((System.ComponentModel.ISupportInitialize)icon_Home).BeginInit();
            SuspendLayout();
            // 
            // label_Logo
            // 
            label_Logo.Anchor = AnchorStyles.None;
            label_Logo.AutoSize = true;
            label_Logo.Font = new Font("UD Digi Kyokasho NK-B", 48F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label_Logo.ImeMode = ImeMode.NoControl;
            label_Logo.Location = new Point(440, 80);
            label_Logo.Name = "label_Logo";
            label_Logo.Size = new Size(515, 92);
            label_Logo.TabIndex = 3;
            label_Logo.Text = "Match Four";
            // 
            // icon_Home
            // 
            icon_Home.Anchor = AnchorStyles.None;
            icon_Home.BackColor = Color.Transparent;
            icon_Home.ForeColor = SystemColors.ControlText;
            icon_Home.IconChar = FontAwesome.Sharp.IconChar.HeartPulse;
            icon_Home.IconColor = SystemColors.ControlText;
            icon_Home.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icon_Home.IconSize = 200;
            icon_Home.ImeMode = ImeMode.NoControl;
            icon_Home.Location = new Point(240, 40);
            icon_Home.Name = "icon_Home";
            icon_Home.Size = new Size(200, 200);
            icon_Home.TabIndex = 2;
            icon_Home.TabStop = false;
            // 
            // label_Credits
            // 
            label_Credits.Anchor = AnchorStyles.None;
            label_Credits.Location = new Point(240, 240);
            label_Credits.Name = "label_Credits";
            label_Credits.Size = new Size(720, 80);
            label_Credits.TabIndex = 4;
            label_Credits.Text = "Dành hết tâm huyết bởi Dương Quốc Hưng và Trương Hoàng Phúc ♥";
            label_Credits.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form_ThongTin
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 653);
            Controls.Add(label_Credits);
            Controls.Add(label_Logo);
            Controls.Add(icon_Home);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Form_ThongTin";
            Text = "Thông tin";
            ((System.ComponentModel.ISupportInitialize)icon_Home).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Logo;
        private FontAwesome.Sharp.IconPictureBox icon_Home;
        private Label label_Credits;
    }
}