namespace QuanLyMachTu.Child_Forms
{
    partial class Form_CaiDat
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
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            label_WindowSize = new Label();
            comboBox_WindowSize = new ComboBox();
            checkBox_Fullscreen = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.White;
            iconPictureBox1.ForeColor = SystemColors.ControlText;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Display;
            iconPictureBox1.IconColor = SystemColors.ControlText;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 60;
            iconPictureBox1.Location = new Point(40, 40);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(60, 60);
            iconPictureBox1.TabIndex = 1;
            iconPictureBox1.TabStop = false;
            // 
            // label_WindowSize
            // 
            label_WindowSize.FlatStyle = FlatStyle.Flat;
            label_WindowSize.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_WindowSize.Location = new Point(100, 40);
            label_WindowSize.Name = "label_WindowSize";
            label_WindowSize.Size = new Size(180, 60);
            label_WindowSize.TabIndex = 2;
            label_WindowSize.Text = "Kích cỡ cửa sổ";
            label_WindowSize.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox_WindowSize
            // 
            comboBox_WindowSize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_WindowSize.FlatStyle = FlatStyle.Flat;
            comboBox_WindowSize.FormattingEnabled = true;
            comboBox_WindowSize.Items.AddRange(new object[] { "800 × 600", "1024 × 768", "1280 × 600", "1360 × 768", "1600 × 900", "1920 × 1080" });
            comboBox_WindowSize.Location = new Point(40, 120);
            comboBox_WindowSize.Name = "comboBox_WindowSize";
            comboBox_WindowSize.Size = new Size(240, 49);
            comboBox_WindowSize.TabIndex = 3;
            comboBox_WindowSize.SelectedIndexChanged += comboBox_WindowSize_SelectedIndexChanged;
            // 
            // checkBox_Fullscreen
            // 
            checkBox_Fullscreen.FlatStyle = FlatStyle.Flat;
            checkBox_Fullscreen.Location = new Point(40, 200);
            checkBox_Fullscreen.Name = "checkBox_Fullscreen";
            checkBox_Fullscreen.Size = new Size(240, 60);
            checkBox_Fullscreen.TabIndex = 4;
            checkBox_Fullscreen.Text = "Toàn màn hình";
            checkBox_Fullscreen.TextAlign = ContentAlignment.MiddleCenter;
            checkBox_Fullscreen.UseVisualStyleBackColor = true;
            checkBox_Fullscreen.CheckedChanged += checkBox_Fullscreen_CheckedChanged;
            // 
            // Form_CaiDat
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 700);
            Controls.Add(checkBox_Fullscreen);
            Controls.Add(comboBox_WindowSize);
            Controls.Add(label_WindowSize);
            Controls.Add(iconPictureBox1);
            Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(6);
            Name = "Form_CaiDat";
            Text = "Cài đặt";
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Label label_WindowSize;
        private ComboBox comboBox_WindowSize;
        private CheckBox checkBox_Fullscreen;
    }
}