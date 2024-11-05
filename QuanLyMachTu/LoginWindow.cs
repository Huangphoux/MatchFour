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
        private void LoginWindow_Load(object sender, EventArgs e)
        {
            textBox_Username.Focus();
        }

        private void icon_Login_Click(object sender, EventArgs e)
        {
            if (textBox_Username.Text != "user")
            {
                MessageBox.Show("Sai tên đăng nhập.\nVui lòng nhập lại.",
                                "Sai tên đăng nhập");
                textBox_Username.Clear();
            }

            else if (textBox_Password.Text != "123456")
            {

                MessageBox.Show("Sai mật khẩu.\nVui lòng nhập lại.",
                                "Sai tên đăng nhập");
                textBox_Password.Clear();
            }

            else
            {
                textBox_Username.Clear();
                textBox_Password.Clear();

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
