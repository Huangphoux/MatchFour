namespace QuanLyMachTu
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void icon_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void icon_Login_Click(object sender, EventArgs e)
        {
            //check username password
            if (textBox_Username.Text == "user"
                && textBox_Password.Text == "123456")
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.");
            }
        }
    }
}
