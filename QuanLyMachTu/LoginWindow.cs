using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace QuanLyMachTu
{
    public partial class LoginWindow : Form
    {
        string filePath = "FILENAME.txt";

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
             //File.WriteAllText(filePath, String.Empty);
        }

        public string ToSHA256(string value)
        {
            SHA256 sha256 = SHA256.Create();

            byte[] hashData = sha256.ComputeHash(Encoding.Default.GetBytes(value));
            StringBuilder returnValue = new StringBuilder();

            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            return returnValue.ToString();
        }

        private void icon_Login_Click(object sender, EventArgs e)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Không tìm thấy thông tin đăng nhập.\n" +
                    "Vui lòng đăng ký trước khi truy cập.");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin đăng nhập.\n" +
                    "Vui lòng đăng ký trước khi truy cập.");
                return;
            }

            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');

                string username = parts[0];
                string password = parts[parts.Length - 1];

                if (username != textBox_Username.Text)
                {
                    textBox_Username.Clear();
                    textBox_Password.Clear();

                    textBox_Username.BackColor = Color.Red;
                    textBox_Password.BackColor = Color.Red;

                    return;
                }

                if (password != ToSHA256(textBox_Password.Text))
                {
                    textBox_Password.Clear();
                    textBox_Password.BackColor = Color.Red;
                    return;
                }

                DialogResult = DialogResult.OK;
            }

            Hide();
        }


        private void icon_SignUp_Click(object sender, EventArgs e)
        {
            string filePath = "FILENAME.txt";

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(textBox_Username.Text + " " + ToSHA256(textBox_Password.Text));
            }

            textBox_Username.Clear();
            textBox_Password.Clear();

            MessageBox.Show("Vui lòng đăng nhập bằng thông tin vừa đăng ký.");
            
        }

        private void checkBox_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ShowPassword.Checked)
            {
                textBox_Password.PasswordChar = '\0';
            }
            else
            {
                textBox_Password.PasswordChar = '●';
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel_TopBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void icon_Logo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label_Logo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

    }
}
