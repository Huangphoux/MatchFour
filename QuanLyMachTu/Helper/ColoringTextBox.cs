using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMachTu.Helper
{
    internal static class ColoringTextBox
    {
        public static void WarningColor(TextBox textBox)
        {
            textBox.BackColor = Color.FromArgb(255, 140, 158);
        }
        public static void NormalColor(TextBox textBox)
        {
            textBox.BackColor = Color.FromArgb(57, 54, 70);
        }
    }
}
