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
            panel1 = new Panel();
            checkBox_ShowPassword = new CheckBox();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)icon_Username).BeginInit();
            ((System.ComponentModel.ISupportInitialize)icon_Password).BeginInit();
            ((System.ComponentModel.ISupportInitialize)icon_Logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)icon_Exit).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
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
            icon_Logo.BackColor = Color.Transparent;
            icon_Logo.ForeColor = Color.FromArgb(244, 238, 224);
            icon_Logo.IconChar = FontAwesome.Sharp.IconChar.HeartPulse;
            icon_Logo.IconColor = Color.FromArgb(244, 238, 224);
            icon_Logo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icon_Logo.IconSize = 200;
            resources.ApplyResources(icon_Logo, "icon_Logo");
            icon_Logo.Name = "icon_Logo";
            icon_Logo.TabStop = false;
            // 
            // label_Logo
            // 
            resources.ApplyResources(label_Logo, "label_Logo");
            label_Logo.ForeColor = Color.FromArgb(244, 238, 224);
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
            label_Password.ForeColor = Color.Black;
            label_Password.Name = "label_Password";
            // 
            // label_Username
            // 
            resources.ApplyResources(label_Username, "label_Username");
            label_Username.ForeColor = Color.Black;
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
            icon_Exit.BackColor = Color.Transparent;
            icon_Exit.ForeColor = Color.Black;
            icon_Exit.IconChar = FontAwesome.Sharp.IconChar.SquareXmark;
            icon_Exit.IconColor = Color.Black;
            icon_Exit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            icon_Exit.IconSize = 60;
            resources.ApplyResources(icon_Exit, "icon_Exit");
            icon_Exit.Name = "icon_Exit";
            icon_Exit.TabStop = false;
            icon_Exit.Click += icon_Exit_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(checkBox_ShowPassword);
            panel1.Controls.Add(icon_Exit);
            panel1.Controls.Add(icon_Username);
            panel1.Controls.Add(icon_SignUp);
            panel1.Controls.Add(icon_Password);
            panel1.Controls.Add(label_Username);
            panel1.Controls.Add(textBox_Password);
            panel1.Controls.Add(label_Password);
            panel1.Controls.Add(textBox_Username);
            panel1.Controls.Add(icon_SignIn);
            panel1.Controls.Add(panel_Password);
            panel1.Controls.Add(panel_Username);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // checkBox_ShowPassword
            // 
            resources.ApplyResources(checkBox_ShowPassword, "checkBox_ShowPassword");
            checkBox_ShowPassword.Name = "checkBox_ShowPassword";
            checkBox_ShowPassword.UseVisualStyleBackColor = true;
            checkBox_ShowPassword.CheckedChanged += checkBox_ShowPassword_CheckedChanged;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(57, 54, 70);
            panel2.Controls.Add(label_Logo);
            panel2.Controls.Add(icon_Logo);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // LoginWindow
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginWindow";
            Load += LoginWindow_Load;
            ((System.ComponentModel.ISupportInitialize)icon_Username).EndInit();
            ((System.ComponentModel.ISupportInitialize)icon_Password).EndInit();
            ((System.ComponentModel.ISupportInitialize)icon_Logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)icon_Exit).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
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
        private Panel panel1;
        private Panel panel2;
        private CheckBox checkBox_ShowPassword;
    }
}