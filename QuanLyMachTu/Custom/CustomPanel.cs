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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(new Rectangle(0, 0, _cornerRadius, _cornerRadius), 180, 90);
                path.AddArc(new Rectangle(Width - _cornerRadius, 0, _cornerRadius, _cornerRadius), 270, 90);
                path.AddArc(new Rectangle(Width - _cornerRadius, Height - _cornerRadius, _cornerRadius, _cornerRadius), 0, 90);
                path.AddArc(new Rectangle(0, Height - _cornerRadius, _cornerRadius, _cornerRadius), 90, 90);
                path.CloseAllFigures();

                Region = new Region(path);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
    }
}
