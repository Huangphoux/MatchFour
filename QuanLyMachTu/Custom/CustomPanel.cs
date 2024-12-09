using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace QuanLyMachTu.Custom
{
    public class CustomPanel : Panel
    {
        private int _cornerRadius = 20;

        [Category("New addition")]
        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; Invalidate(); }
        }

        public CustomPanel()
        {
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Create a new GraphicsPath for the custom rounded corners
            using (GraphicsPath path = new GraphicsPath())
            {
                // Add rounded corners to the path
                path.AddArc(new Rectangle(0, 0, _cornerRadius, _cornerRadius), 180, 90);
                path.AddArc(new Rectangle(Width - _cornerRadius, 0, _cornerRadius, _cornerRadius), 270, 90);
                path.AddArc(new Rectangle(Width - _cornerRadius, Height - _cornerRadius, _cornerRadius, _cornerRadius), 0, 90);
                path.AddArc(new Rectangle(0, Height - _cornerRadius, _cornerRadius, _cornerRadius), 90, 90);
                path.CloseAllFigures();

                // Set the region of the panel to the custom shape
                Region = new Region(path);

                // Fill the area with the panel's background color
                using (Brush brush = new SolidBrush(BackColor))
                {
                    e.Graphics.FillPath(brush, path); // Fill the path with the background color
                }
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
    }
}
