﻿using System;
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
            textBox.BackColor = ColorUsed.highlightTop;
        }
        public static void NormalColor(TextBox textBox)
        {
            textBox.BackColor = ColorUsed.backgroud;
        }
    }
}
