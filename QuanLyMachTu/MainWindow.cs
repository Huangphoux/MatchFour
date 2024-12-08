using QuanLyMachTu.Child_Forms;
using QuanLyMachTu.Custom;
using QuanLyMachTu.Helper;

namespace QuanLyMachTu
{
    public partial class MainWindow : Form
    {
        private readonly Panel leftBorderButton;
        private readonly Form currentChildForm;
        private PageButton currentButton;
        private Form_CaiDat formCaiDat;
        private Form_ThongTin formThongTin;
        private LoginWindow loginWindow;
        private bool isApplicationRunning = true;

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
            _ = loginWindow.ShowDialog();

            isApplicationRunning = false;

            elapsedTime = TimeSpan.Zero;
            timer_Clock.Start();

            MainWindow_Resize(this, EventArgs.Empty);
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

        #region Button Click

        private void pageButton_TongQuat_Click(object sender, EventArgs e)
        {
            ActivateButton((PageButton)sender);
            tongQuanControl.BringToFront();
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
            _ = formCaiDat.ShowDialog();
        }
        private void pageButton_DuocPham_Click(object sender, EventArgs e)
        {
            ActivateButton((PageButton)sender);
            duocPhamControl.BringToFront();
        }

        #endregion


        private TimeSpan elapsedTime;

        private void timer_Clock_Tick(object sender, EventArgs e)
        {
            elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1));
            label_Clock.Text = elapsedTime.ToString(@"hh\:mm\:ss");
        }

        private void pageButton_SignOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pageButton_DichVu_Click(object sender, EventArgs e)
        {
            ActivateButton((PageButton)sender);
            dichVuControl.BringToFront();
        }

        private void pageButton_ThongTin_Click(object sender, EventArgs e)
        {
            _ = formThongTin.ShowDialog();
        }

        private void pageButton_NhanVien_Click(object sender, EventArgs e)
        {
            ActivateButton((PageButton)sender);
            nhanVienControl.BringToFront();
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized
                && this.FormBorderStyle == FormBorderStyle.None
            )
            {
                pageButton_SignOut.Visible = true;
            }
            else
            {
                pageButton_SignOut.Visible = false;
            }
        }
    }
}
