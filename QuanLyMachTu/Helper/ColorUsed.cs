using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMachTu.Helper
{
    public static class ColorUsed
    {
        public static Color deactivated = Color.FromArgb(193, 193, 193);
        public static Color originalGrid = Color.White;
        public static Color highlightTop = Color.FromArgb(255, 176, 176);
        public static Color highlightMedium = Color.FromArgb(255, 255, 176);
        public static Color backgroud = Color.FromArgb(57, 54, 70);

        public static Color Overlay(Color origin, Color blend, float alpha)
        {
            int red = (int)(origin.R * alpha + blend.R * (1f - alpha));
            int green = (int)(origin.G * alpha + blend.G * (1f - alpha));
            int blue = (int)(origin.B * alpha + blend.B * (1f - alpha));

            return Color.FromArgb(red, green, blue);
        }
    }
}
