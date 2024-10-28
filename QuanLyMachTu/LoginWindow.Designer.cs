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
            textBox_Login = new TextBox();
            label_Login = new Label();
            button_Login = new Button();
            SuspendLayout();
            // 
            // textBox_Login
            // 
            resources.ApplyResources(textBox_Login, "textBox_Login");
            textBox_Login.Name = "textBox_Login";
            // 
            // label_Login
            // 
            resources.ApplyResources(label_Login, "label_Login");
            label_Login.Name = "label_Login";
            // 
            // button_Login
            // 
            resources.ApplyResources(button_Login, "button_Login");
            button_Login.Name = "button_Login";
            button_Login.UseVisualStyleBackColor = true;
            button_Login.Click += button_Login_Click;
            // 
            // LoginWindow
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button_Login);
            Controls.Add(label_Login);
            Controls.Add(textBox_Login);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "LoginWindow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_Login;
        private Label label_Login;
        private Button button_Login;
    }
}