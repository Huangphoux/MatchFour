using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMachTu.Helper
{
    public static class ColoringButton
    {
        public static void NormalColor(Button button)
        {
            button.BackColor = Color.FromArgb(57, 54, 70);
        }
        public static void EnabledColor(Button button)
        {
            button.BackColor = Color.FromArgb(79, 69, 87);
            button.ForeColor = Color.White;
        }
        public static void DisabledColor(Button button)
        {
            NormalColor(button);
            button.ForeColor = Color.FromArgb(193, 193, 193);
        }
    }
}
