using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows;

namespace QuanLyMachTu.Custom
{
    [ToolboxItem(true)]
    public class CustomDataGridView : DataGridView
    {
        private int _cornerRadius = 20;  

        [Category("New addition")]
        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; Invalidate(); }
        }

        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            return path;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, Width, Height);
            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, _cornerRadius))
            using (Pen penSurface = new Pen(Parent.BackColor, 2))
            {
                //Button surface
                Region = new Region(pathSurface);
                //Draw surface border for HD result
                e.Graphics.DrawPath(penSurface, pathSurface);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
    }
}
