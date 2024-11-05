namespace QuanLyMachTu.Child_Forms
{
    public partial class Form_CaiDat : Form
    {
        private readonly MainWindow _mainForm;

        public Form_CaiDat(MainWindow mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;

            comboBox_WindowSize.SelectedIndex = 4;
        }

        private void comboBox_WindowSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_WindowSize.SelectedIndex)
            {
                case 0:
                    _mainForm.ResizeAndCenter(800, 600);
                    break;
                case 1:
                    _mainForm.ResizeAndCenter(1024, 768);
                    break;
                case 2:
                    _mainForm.ResizeAndCenter(1280, 600);
                    break;
                case 3:
                    _mainForm.ResizeAndCenter(1360, 768);
                    break;
                case 4:
                    _mainForm.ResizeAndCenter(1600, 900);
                    break;
                case 5:
                    _mainForm.ResizeAndCenter(1920, 1080);
                    break;
                default:
                    break;
            }
        }

        private void checkBox_Fullscreen_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Fullscreen.Checked == true)
            {
                _mainForm.WindowState = FormWindowState.Normal;
                _mainForm.FormBorderStyle = FormBorderStyle.None;
                _mainForm.WindowState = FormWindowState.Maximized;
            }
            else
            {
                _mainForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                _mainForm.WindowState = FormWindowState.Normal;
            }
        }
    }
}
