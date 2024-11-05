namespace QuanLyMachTu
{
    partial class LoginWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginWindow));
            icon_Username = new FontAwesome.Sharp.IconPictureBox();
            icon_Password = new FontAwesome.Sharp.IconPictureBox();
            textBox_Password = new TextBox();
            textBox_Username = new TextBox();
            panel_Password = new Panel();
            panel_Username = new Panel();
            icon_Logo = new FontAwesome.Sharp.IconPictureBox();
            label_Logo = new Label();
            icon_SignIn = new FontAwesome.Sharp.IconButton();
            label_Password = new Label();
            label_Username = new Label();
            icon_SignUp = new FontAwesome.Sharp.IconButton();
            icon_Exit = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)icon_Username).BeginInit();
            ((System.ComponentModel.ISupportInitialize)icon_Password).BeginInit();
            ((System.ComponentModel.ISupportInitialize)icon_Logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)icon_Exit).BeginInit();
            SuspendLayout();
            // 
            // icon_Username
            // 
            icon_Username.BackColor = Color.White;
            icon_Username.ForeColor = SystemColors.ControlText;
            icon_Username.IconChar = FontAwesome.Sharp.IconChar.UserDoctor;
            icon_Username.IconColor = SystemColors.ControlText;
            icon_Username.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icon_Username.IconSize = 40;
            resources.ApplyResources(icon_Username, "icon_Username");
            icon_Username.Name = "icon_Username";
            icon_Username.TabStop = false;
            // 
            // icon_Password
            // 
            icon_Password.BackColor = Color.White;
            icon_Password.ForeColor = SystemColors.ControlText;
            icon_Password.IconChar = FontAwesome.Sharp.IconChar.Key;
            icon_Password.IconColor = SystemColors.ControlText;
            icon_Password.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icon_Password.IconSize = 40;
            resources.ApplyResources(icon_Password, "icon_Password");
            icon_Password.Name = "icon_Password";
            icon_Password.TabStop = false;
            // 
            // textBox_Password
            // 
            textBox_Password.BorderStyle = BorderStyle.None;
            resources.ApplyResources(textBox_Password, "textBox_Password");
            textBox_Password.Name = "textBox_Password";
            // 
            // textBox_Username
            // 
            textBox_Username.BorderStyle = BorderStyle.None;
            resources.ApplyResources(textBox_Username, "textBox_Username");
            textBox_Username.Name = "textBox_Username";
            // 
            // panel_Password
            // 
            panel_Password.BackColor = Color.Black;
            resources.ApplyResources(panel_Password, "panel_Password");
            panel_Password.Name = "panel_Password";
            // 
            // panel_Username
            // 
            panel_Username.BackColor = Color.Black;
            resources.ApplyResources(panel_Username, "panel_Username");
            panel_Username.Name = "panel_Username";
            // 
            // icon_Logo
            // 
            icon_Logo.BackColor = Color.White;
            icon_Logo.ForeColor = SystemColors.ControlText;
            icon_Logo.IconChar = FontAwesome.Sharp.IconChar.HeartPulse;
            icon_Logo.IconColor = SystemColors.ControlText;
            icon_Logo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icon_Logo.IconSize = 120;
            resources.ApplyResources(icon_Logo, "icon_Logo");
            icon_Logo.Name = "icon_Logo";
            icon_Logo.TabStop = false;
            // 
            // label_Logo
            // 
            resources.ApplyResources(label_Logo, "label_Logo");
            label_Logo.Name = "label_Logo";
            // 
            // icon_SignIn
            // 
            icon_SignIn.BackColor = Color.WhiteSmoke;
            icon_SignIn.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(icon_SignIn, "icon_SignIn");
            icon_SignIn.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            icon_SignIn.IconColor = Color.Black;
            icon_SignIn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icon_SignIn.IconSize = 30;
            icon_SignIn.Name = "icon_SignIn";
            icon_SignIn.UseVisualStyleBackColor = false;
            icon_SignIn.Click += icon_Login_Click;
            // 
            // label_Password
            // 
            resources.ApplyResources(label_Password, "label_Password");
            label_Password.Name = "label_Password";
            // 
            // label_Username
            // 
            resources.ApplyResources(label_Username, "label_Username");
            label_Username.Name = "label_Username";
            // 
            // icon_SignUp
            // 
            icon_SignUp.BackColor = Color.WhiteSmoke;
            icon_SignUp.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(icon_SignUp, "icon_SignUp");
            icon_SignUp.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            icon_SignUp.IconColor = Color.Black;
            icon_SignUp.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icon_SignUp.IconSize = 30;
            icon_SignUp.Name = "icon_SignUp";
            icon_SignUp.UseVisualStyleBackColor = false;
            // 
            // icon_Exit
            // 
            icon_Exit.BackColor = Color.White;
            icon_Exit.ForeColor = SystemColors.ControlText;
            icon_Exit.IconChar = FontAwesome.Sharp.IconChar.SquareXmark;
            icon_Exit.IconColor = SystemColors.ControlText;
            icon_Exit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icon_Exit.IconSize = 60;
            resources.ApplyResources(icon_Exit, "icon_Exit");
            icon_Exit.Name = "icon_Exit";
            icon_Exit.TabStop = false;
            icon_Exit.Click += icon_Exit_Click;
            // 
            // LoginWindow
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(icon_Exit);
            Controls.Add(icon_SignUp);
            Controls.Add(label_Username);
            Controls.Add(label_Password);
            Controls.Add(icon_SignIn);
            Controls.Add(label_Logo);
            Controls.Add(icon_Logo);
            Controls.Add(panel_Username);
            Controls.Add(panel_Password);
            Controls.Add(textBox_Username);
            Controls.Add(textBox_Password);
            Controls.Add(icon_Password);
            Controls.Add(icon_Username);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginWindow";
            Load += LoginWindow_Load;
            ((System.ComponentModel.ISupportInitialize)icon_Username).EndInit();
            ((System.ComponentModel.ISupportInitialize)icon_Password).EndInit();
            ((System.ComponentModel.ISupportInitialize)icon_Logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)icon_Exit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox icon_Username;
        private FontAwesome.Sharp.IconPictureBox icon_Password;
        private TextBox textBox_Password;
        private TextBox textBox_Username;
        private Panel panel_Password;
        private Panel panel_Username;
        private FontAwesome.Sharp.IconPictureBox icon_Logo;
        private Label label_Logo;
        private FontAwesome.Sharp.IconButton icon_SignIn;
        private Label label_Password;
        private Label label_Username;
        private FontAwesome.Sharp.IconButton icon_SignUp;
        private FontAwesome.Sharp.IconPictureBox icon_Exit;
    }
}