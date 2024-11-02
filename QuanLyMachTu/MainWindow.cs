using FontAwesome.Sharp;
using QuanLyMachTu.Child_Forms;

namespace QuanLyMachTu
{
    public partial class MainWindow : Form
    {
        private IconButton currentButton;
        private readonly Panel leftBorderButton;
        private Form currentChildForm;

        public MainWindow()
        {
            InitializeComponent();

            leftBorderButton = new Panel
            {
                Size = new Size(10, 80)
            };

            panel_Menu.Controls.Add(leftBorderButton);

            //Form
            // Text = string.Empty;
            // this.ControlBox = false;

            DoubleBuffered = true;

            // MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;

        }

        private struct RGBColors
        {
            public static Color color_TomTat = Color.FromArgb(172, 126, 241);
            public static Color color_LichHen = Color.FromArgb(249, 118, 176);
            public static Color color_BenhNhan = Color.FromArgb(253, 138, 114);
            public static Color color_PhongKham = Color.FromArgb(95, 77, 221);
            public static Color color_TaiChinh = Color.FromArgb(249, 88, 155);
            public static Color color_ThongTin = Color.FromArgb(24, 161, 251);
            public static Color color_CaiDat = Color.FromArgb(24, 161, 251);
        }

        //Methods
        private void ActivateButton(object senderButton, Color color)
        {
            if (senderButton != null)
            {
                DisableButton();

                //Button
                currentButton = (IconButton)senderButton;

                currentButton.ForeColor = color;
                currentButton.BackColor = Color.White;
                currentButton.TextAlign = ContentAlignment.MiddleRight;
                currentButton.IconColor = color;
                //currentButton.TextImageRelation = TextImageRelation.TextBeforeImage;
                //currentButton.ImageAlign = ContentAlignment.MiddleRight;

                //Left border button
                leftBorderButton.BackColor = color;
                leftBorderButton.Location = new Point(0, currentButton.Location.Y);
                leftBorderButton.Visible = true;
                leftBorderButton.BringToFront();

                //Current Child Form Icon
                //icon_CurrentChildForm.IconChar = currentButton.IconChar;
                //icon_CurrentChildForm.IconColor = color;

                label_TitleChildForm.Text = currentButton.Text;
                // label_TitleChildForm.ForeColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentButton != null)
            {
                currentButton.ForeColor = Color.Black;
                currentButton.BackColor = Color.White;
                currentButton.TextAlign = ContentAlignment.MiddleCenter;
                currentButton.IconColor = Color.Black;
                //currentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                //currentButton.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            //End

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panel_ChildForm.Controls.Add(childForm);
            panel_ChildForm.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }


        private void icon_Home_Click(object sender, EventArgs e)
        {
            DisableButton();
            leftBorderButton.Visible = false;

            currentChildForm.Close();

            //icon_CurrentChildForm.IconChar = IconChar.Home;
            //icon_CurrentChildForm.IconColor = Color.MediumPurple;

            label_TitleChildForm.Text = "Trang chủ";
            label_TitleChildForm.ForeColor = Color.Black;
        }

        #region Button Click

        private void iconButton_TomTat_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color_TomTat);
        }

        private void iconButton_LichHen_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color_LichHen);
        }

        private void iconButton_BenhNhan_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color_BenhNhan);
        }
        private void iconButton_PhongKham_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color_TaiChinh);
        }
        private void iconButton_HoaDon_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color_TaiChinh);
        }

        private void iconButton_TaiChinh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color_TaiChinh);
        }

        private void iconButton_CaiDat_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color_CaiDat);
            OpenChildForm(new Form_CaiDat());
        }
        private void iconButton_ThongTin_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color_ThongTin);
        }

        #endregion

        private void timer_Clock_Tick(object sender, EventArgs e)
        {
            label_Clock.Text = $"Bây giờ là {DateTime.Now.ToString("HH:mm:ss")}";
        }

    }
}
