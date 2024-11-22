using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMachTu.Helper
{
    public static class ColoringDataGridView
    {
        public static void ActivateDGV(DataGridView dgv)
        {
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.BackgroundColor = Color.White;
        }
        public static void DeactivateDGV(DataGridView dgv)
        {
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(193, 193, 193);
            dgv.BackgroundColor = Color.FromArgb(193, 193, 193);
        }
    }
}
