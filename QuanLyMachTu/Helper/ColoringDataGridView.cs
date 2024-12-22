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
            dgv.DefaultCellStyle.BackColor = ColorUsed.originalGrid;
            dgv.BackgroundColor = ColorUsed.originalGrid;
        }
        public static void DeactivateDGV(DataGridView dgv)
        {
            dgv.DefaultCellStyle.BackColor = ColorUsed.deactivated;
            dgv.BackgroundColor = ColorUsed.deactivated;
        }
    }
}
