using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace QuanLyMachTu.Custom
{
    public class PageButton : Button
    {
        //Fields
        private int borderSize = 0;
        private int borderRadius = 40;
        private Color borderColor = Color.PaleVioletRed;
        private Image icon;
        private Point iconLocation;
        private Size iconSize;
        private string text;
        private Point textLocation;

        //Propertiest
        [Category("Page Button Addition")]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                Invalidate();
            }
        }
        [Category("Page Button Addition")]
        public int BorderRadius
        {
            get
            {
                return borderRadius;
            }
            set
            {
                if (value <= Height)
                    borderRadius = value;
                else
                    borderRadius = Height;

                Invalidate();
            }
        }
        [Category("Page Button Addition")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }
        [Category("Page Button Addition")]
        public Image Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
                iconLocation = new Point(Width / 2, Height / 2);
                iconSize = icon.Size;
                Invalidate();
            }
        }
        [Category("Page Button Addition")]
        public Point IconLocation
        {
            get
            {
                return iconLocation;
            }
            set
            {
                iconLocation = value;
                Invalidate();
            }
        }
        [Category("Page Button Addition")]
        public Size IconSize
        {
            get
            {
                return iconSize;
            }
            set
            {
                iconSize = value;
                Invalidate();
            }
        }
        [Category("Page Button Addition")]
        public string CustomText
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                Invalidate();
            }
        }

        [Category("Page Button Addition")]
        public Point TextLocation
        {
            get
            {
                return textLocation;
            }
            set
            {
                textLocation = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        public override string Text { get => base.Text; set => base.Text = value; }

        //Constructor
        public PageButton()
        {
            base.Text = "";
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Size = new Size(150, 40);
            BackColor = Color.MediumSlateBlue;
            ForeColor = Color.White;
            Resize += new EventHandler(Button_Resize);
            textLocation = new Point(0, 0);
        }

        //Methods
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

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, Width, Height);
            RectangleF rectBorder = new RectangleF(1, 1, Width - 0.8f, Height - 1);

            if (BorderRadius > 2) //Rounded button
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, BorderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, BorderRadius - 1f))
                using (Pen penSurface = new Pen(Parent.BackColor, 2))
                using (Pen penBorder = new Pen(BorderColor, BorderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    //Button surface
                    Region = new Region(pathSurface);
                    //Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    //button border
                    if (BorderSize >= 1)
                        //Draw control border
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else //Normal button
            {
                Region = new Region(rectSurface);
                if (BorderSize >= 1)
                {
                    using (Pen penBorder = new Pen(BorderColor, BorderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
                    }
                }
            }

            if (icon != null)
            {
                pevent.Graphics.DrawImage(icon, new Rectangle(iconLocation, iconSize));
            }

            TextRenderer.DrawText(pevent.Graphics, text, base.Font, textLocation, base.ForeColor);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (Parent != null)
            {
                Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
            }
        }

        private void Container_BackColorChanged(object? sender, EventArgs e)
        {
            if (DesignMode)
                Invalidate();
        }

        private void Button_Resize(object? sender, EventArgs e)
        {
            if (borderRadius > Height)
                borderRadius = Height;
        }
    }
}
