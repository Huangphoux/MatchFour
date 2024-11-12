using FontAwesome.Sharp;
using QuanLyMachTu.Child_Forms;
using System.Windows.Forms;

namespace QuanLyMachTu
{    
    public partial class MainWindow : Form
    {
        private readonly Panel leftBorderButton;
        private Form currentChildForm;
        private PageButton currentButton;
        
        //Methods
        public MainWindow()
        {
            InitializeComponent();

            leftBorderButton = new Panel
            {
                Size = new Size(10, 80)
            };

            panel_Menu.Controls.Add(leftBorderButton);

            currentButton = pageButton_TongQuan;

            //Form
            // Text = string.Empty;
            // this.ControlBox = false;

            DoubleBuffered = true;

            // MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;

            // Initialize the SqlConnection
        }

        //private struct RGBColors
        //{
        //    public static Color color_TomTat = Color.FromArgb(172, 126, 241);
        //    public static Color color_LichHen = Color.FromArgb(249, 118, 176);
        //    public static Color color_BenhNhan = Color.FromArgb(253, 138, 114);
        //    public static Color color_PhongKham = Color.FromArgb(95, 77, 221);
        //    public static Color color_TaiChinh = Color.FromArgb(249, 88, 155);
        //    public static Color color_ThongTin = Color.FromArgb(24, 161, 251);
        //    public static Color color_CaiDat = Color.FromArgb(24, 161, 251);
        //}

        //Methods
        private void ActivateButton(PageButton senderButton)
        {
            DisableButton(currentButton);
            currentButton = senderButton;
            senderButton.BackColor = Color.FromArgb(57, 62, 70);
        }

        private void DisableButton(PageButton currentButton)
        {
            if (currentButton == null)
                return;

            currentButton.BackColor = Color.FromArgb(34, 40, 49);
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

        private void iconButton_BenhNhan_Click(object sender, EventArgs e)
        {
            ActivateButton((PageButton)sender);
        }
        private void iconButton_PhongKham_Click(object sender, EventArgs e)
        {
            ActivateButton((PageButton)sender);
        }
        private void iconButton_HoaDon_Click(object sender, EventArgs e)
        {
            ActivateButton((PageButton)sender);
        }

        private void iconButton_CaiDat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_CaiDat(this));
        }
        private void iconButton_ThongTin_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_ThongTin());
        }


        private void iconButton_NhanVien_Click(object sender, EventArgs e)
        {
            ActivateButton((PageButton)sender);
        }
        private void iconButton_DuocPham_Click(object sender, EventArgs e)
        {
            ActivateButton((PageButton)sender);
        }
        private void iconButton_DichVu_Click(object sender, EventArgs e)
        {
            ActivateButton((PageButton)sender);
        }

        #endregion

        private void timer_Clock_Tick(object sender, EventArgs e)
        {
            label_Clock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private bool isSignoutInitiated = false;

        private void icon_Thoat_Click(object sender, EventArgs e)
        {
            ShowExitConfirmation();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isSignoutInitiated)
            {
                e.Cancel = true;
                ShowExitConfirmation();
            }
        }

        private void ShowExitConfirmation()
        {
            DialogResult dialogResult = MessageBox.Show(
                "Bạn có thực sự muốn thoát khỏi chương trình?",
                "Trước khi thoát chương trình",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );

            if (dialogResult == DialogResult.OK)
            {
                isSignoutInitiated = true;
                Application.Exit();
            }            
        }
    }
}
