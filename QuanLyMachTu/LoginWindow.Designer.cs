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
            label_Login = new Label();
            SuspendLayout();
            // 
            // label_Login
            // 
            resources.ApplyResources(label_Login, "label_Login");
            label_Login.Name = "label_Login";
            // 
            // LoginWindow
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label_Login);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "LoginWindow";
            ResumeLayout(false);
        }

        #endregion
        private Label label_Login;
    }
}