using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace QuanLyMachTu
{
    public class PageButton: Button
    {
        //Fields
        private int borderSize = 0;
        private int borderRadius = 40;
        private Color borderColor = Color.PaleVioletRed;
        private Image icon;
        private Point iconLocation;
        private Size iconSize;
        private string text;
        private Font textFont;
        private Color textColor;
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
                this.Invalidate();
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
                if (value <= this.Height)
                    borderRadius = value;
                else
                    borderRadius = this.Height;

                this.Invalidate();
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
                this.Invalidate();
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
                iconLocation = new Point(this.Width / 2, this.Height / 2);
                iconSize = icon.Size;
                this.Invalidate();
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
                this.Invalidate();
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
                this.Invalidate();
            }
        }

        public string Text1 
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                this.Invalidate();
            }
        }
        public Font TextFont 
        {
            get
            {
                return textFont;
            }
            set
            {
                textFont = value;
                this.Invalidate();
            }
        }
        public Color TextColor 
        { 
            get 
            { 
                return textColor; 
            }
            set 
            {
                textColor = value;
                this.Invalidate();
            }
        }
        public Point TextLocation 
        {
            get
            {
                return textLocation;
            }
            set
            {
                textLocation = value;
                this.Invalidate();
            }
        }

        //Constructor
        public PageButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(Button_Resize);
            this.text = "PageButton";
            this.textFont = new Font("Segoe UI", 12, FontStyle.Regular);
            this.textColor = Color.Black;
            this.textLocation = new Point(0, 0);
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

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8f, this.Height - 1);
            
            if(BorderRadius > 2) //Rounded button
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, BorderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, BorderRadius - 1f))
                using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                using (Pen penBorder = new Pen(BorderColor, BorderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    //Button surface
                    this.Region = new Region(pathSurface);
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
                this.Region = new Region(rectSurface);
                if(BorderSize >= 1)
                {
                    using (Pen penBorder = new Pen(BorderColor, BorderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }

            if (icon != null)
            {
                pevent.Graphics.DrawImage(icon, new Rectangle(iconLocation, iconSize));
            }

            TextRenderer.DrawText(pevent.Graphics, text, textFont, textLocation, textColor);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this.Parent != null)
            {
                this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
            }
        }

        private void Container_BackColorChanged(object? sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }

        private void Button_Resize(object? sender, EventArgs e)
        {
            if (borderRadius > this.Height)
                borderRadius = this.Height;
        }
    }
}
