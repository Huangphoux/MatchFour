using FontAwesome.Sharp;
using QuanLyMachTu.Child_Forms;
using QuanLyMachTu.Custom;
using QuanLyMachTu.Helper;
using System.Windows.Forms;

namespace QuanLyMachTu
{
    public partial class MainWindow : Form
    {
        private readonly Panel leftBorderButton;
        private Form currentChildForm;
        private PageButton currentButton;
        Form_CaiDat formCaiDat;
        Form_ThongTin formThongTin;

        LoginWindow loginWindow;

        bool isApplicationRunning = true;

        //Methods
        public MainWindow()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            currentButton = pageButton_TongQuan;
            ActivateButton(currentButton);

            formCaiDat = new Form_CaiDat(this);
            formThongTin = new();

            loginWindow = new();
            loginWindow.ShowDialog();

            isApplicationRunning = false;
        }

        //Methods
        private void ActivateButton(PageButton senderButton)
        {
            DisableButton(currentButton);
            currentButton = senderButton;
            ColoringButton.EnabledColor(currentButton);
        }

        private void DisableButton(PageButton currentButton)
        {
            if (currentButton == null)
                return;

            ColoringButton.DisabledColor(currentButton);
        }

        private void OpenChildForm(Form childForm)
        {
            //open only form
            currentChildForm?.Close();

            currentChildForm = childForm;
            //End

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            //panel_ChildForm.Controls.Add(childForm);
            //panel_ChildForm.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }


        private void icon_Home_Click(object sender, EventArgs e)
        {
            DisableButton((PageButton)sender);
            leftBorderButton.Visible = false;

            currentChildForm?.Close();

            //icon_CurrentChildForm.IconChar = IconChar.Home;
            //icon_CurrentChildForm.IconColor = Color.MediumPurple;
        }
        public void ResizeAndCenter(int width, int height)
        {
            Width = width;
            Height = height;
            StartPosition = FormStartPosition.Manual;
            Left = (Screen.PrimaryScreen.WorkingArea.Width - Width) / 2;
            Top = (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2;
        }

        private readonly Color ActivateColor = Color.Teal;

        #region Button Click

        private void pageButton_TongQuat_Click(object sender, EventArgs e)
        {
            ActivateButton((PageButton)sender);
        }

        private void pageButton_BenhNhan_Click(object sender, EventArgs e)
        {
            ActivateButton((PageButton)sender);
            benhNhanControl.BringToFront();
        }
        private void pageButton_PhongKham_Click(object sender, EventArgs e)
        {
            ActivateButton((PageButton)sender);
            phongKhamControl.BringToFront();
        }

        private void iconButton_CaiDat_Click(object sender, EventArgs e)
        {
            formCaiDat.ShowDialog();
        }
        private void pageButton_DuocPham_Click(object sender, EventArgs e)
        {
            ActivateButton((PageButton)sender);
            duocPhamControl.BringToFront();
        }

        #endregion

        private void timer_Clock_Tick(object sender, EventArgs e)
        {
            label_Clock.Text = DateTime.Now.ToString("HH:mm:ss");
        }


        private void pageButton_SignOut_Click(object sender, EventArgs e)
        {
            this.Close();

            loginWindow = new();
            loginWindow.Show();
        }

        //private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (!isApplicationRunning)
        //    {
        //        e.Cancel = true;
        //        ShowExitConfirmation();
        //    }
        //}



        private void ShowExitConfirmation()
        {
            DialogResult dialogResult = MessageBox.Show(
                "Bạn có thực sự muốn thoát chương trình?",
                "Xác nhận thoát chương trình",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );

            if (dialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void pageButton_DichVu_Click(object sender, EventArgs e)
        {
            ActivateButton((PageButton)sender);
            dichVuControl.BringToFront();
        }

        private void pageButton_ThongTin_Click(object sender, EventArgs e)
        {
            formThongTin.ShowDialog();
        }

        private void pageButton_NhanVien_Click(object sender, EventArgs e)
        {
            ActivateButton((PageButton)sender);
            nhanVienControl.BringToFront();
        }
    }
}
