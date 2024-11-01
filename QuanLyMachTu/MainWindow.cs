using System.Drawing;
using System.Drawing.Drawing2D;

namespace QuanLyMachTu
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            //define gradient's properties
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(0, 0, 0), Color.FromArgb(57, 128, 227), 65f);

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
        }
    }
}
