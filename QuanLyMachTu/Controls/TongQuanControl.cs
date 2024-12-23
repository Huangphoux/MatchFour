using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using QuanLyMachTu.Custom;
using QuanLyMachTu.Helper;
using System.Windows.Forms.DataVisualization.Charting;
using Scriban.Parsing;

namespace QuanLyMachTu.Controls
{
    public partial class TongQuanControl : UserControl
    {
        public TongQuanControl()
        {
            InitializeComponent();
        }

        private void TongQuanControl_Load(object sender, EventArgs e)
        {
            InitializeState();
        }

        private void InitializeState()
        {
            chart_BN_TanSuat_LoadChart();
            chart_DoanhThu_LoadChart();
            //chart_DV_DoanhThu_LoadChart();
            //chart_DP_DoanhThu_LoadChart();
            chart_DV_TiTrongDoanhThu_LoadChart();
            chart_DV_TiTrongTanSuat_LoadChart();
            chart_DP_TiTrongDoanhThu_LoadChart();
            chart_DP_TiTrongTanSuat_LoadChart();
            chart_NV_TichCuc_LoadChart();
            chart_NV_XepHang_LoadChart();
        }
        private void chart_DoanhThu_LoadChart()
        {
            string query = "SELECT MONTH(NgayThanhToan) AS Thang, SUM(TongTien) AS DoanhThu " +
                           "FROM HOADON " +
                           "GROUP BY MONTH(NgayThanhToan) ";

            chart_DoanhThu.DataSource = DatabaseConnection.LoadDataIntoDataTable(query);
        }
        private void chart_DV_TiTrongDoanhThu_LoadChart()
        {
            string query = "SELECT TenDV, SUM(GiaTien) AS DoanhThu " +
                           "FROM CTHD_DichVu CTDV " +
                           "INNER JOIN (SELECT * " +
                                       "FROM HOADON " +
                                       "WHERE MONTH(NgayThanhToan) = MONTH('10/23/2024')) " +
                           "HD ON HD.MaHD = CTDV.MaHD " +
                           "RIGHT JOIN DICHVU DV ON DV.MaDV = CTDV.MaDV " +
                           "GROUP BY DV.MaDV, TenDV ";

            chart_DV_TiTrongDoanhThu.DataSource = DatabaseConnection.LoadDataIntoDataTable(query);
        }
        private void chart_DV_TiTrongTanSuat_LoadChart()
        {
            string query = "SELECT TenDV, COUNT(HD.MaHD) AS TanSuat " +
                           "FROM CTHD_DichVu CTDV " +
                           "INNER JOIN (SELECT * " +
                                       "FROM HOADON " +
                                       "WHERE MONTH(NgayThanhToan) = MONTH('10/23/2024')) " +
                           "HD ON HD.MaHD = CTDV.MaHD " +
                           "RIGHT JOIN DICHVU DV ON DV.MaDV = CTDV.MaDV " +
                           "GROUP BY DV.MaDV, TenDV " +
                           "ORDER BY COUNT(HD.MaHD) DESC ";

            chart_DV_TiTrongTanSuat.DataSource = DatabaseConnection.LoadDataIntoDataTable(query);
        }
        private void chart_DP_TiTrongDoanhThu_LoadChart()
        {
            string query = "SELECT TenDP, SUM(GiaTien) AS DoanhThu\r\nFROM CTHD_DuocPham CTDP\r\nINNER JOIN (SELECT *\r\n\t\t\tFROM HOADON\r\n\t\t\tWHERE MONTH(NgayThanhToan) = MONTH('10/23/2024'))\r\nHD ON HD.MaHD = CTDP.MaHD\r\nINNER JOIN DUOCPHAM DP ON DP.MaDP = CTDP.MaDP\r\nGROUP BY DP.MaDP, TenDP";

            chart_DP_TiTrongDoanhThu.DataSource = DatabaseConnection.LoadDataIntoDataTable(query);
        }
        private void chart_DP_TiTrongTanSuat_LoadChart()
        {
            string query = "SELECT TenDP, COUNT(HD.MaHD) AS TanSuat\r\nFROM CTHD_DuocPham CTDP\r\nINNER JOIN (SELECT *\r\n\t\t\tFROM HOADON\r\n\t\t\tWHERE MONTH(NgayThanhToan) = MONTH('10/23/2024'))\r\nHD ON HD.MaHD = CTDP.MaHD\r\nINNER JOIN DUOCPHAM DP ON DP.MaDP = CTDP.MaDP\r\nGROUP BY DP.MaDP, TenDP\r\nORDER BY COUNT(HD.MaHD) DESC ";

            chart_DP_TiTrongTanSuat.DataSource = DatabaseConnection.LoadDataIntoDataTable(query);
        }
        //private void chart_DV_DoanhThu_LoadChart()
        //{
        //    string query = "SELECT MONTH(NgayThanhToan) AS Thang, SUM(GiaTien) AS DoanhThu\r\nFROM CTHD_DichVu CTDV\r\nINNER JOIN HOADON HD ON HD.MaHD = CTDV.MaHD\r\nWHERE YEAR(NgayThanhToan) = YEAR(GETDATE())\r\nGROUP BY MONTH(NgayThanhToan)";

        //    chart_DV_DoanhThu.DataSource = DatabaseConnection.LoadDataIntoDataTable(query);
        //}
        //private void chart_DP_DoanhThu_LoadChart()
        //{
        //    string query = "SELECT MONTH(NgayThanhToan) AS Thang, SUM(GiaTien) AS DoanhThu\r\nFROM CTHD_DuocPham CTDP\r\nINNER JOIN HOADON HD ON HD.MaHD = CTDP.MaHD\r\nWHERE YEAR(NgayThanhToan) = YEAR(GETDATE())\r\nGROUP BY MONTH(NgayThanhToan)";

        //    chart_DP_DoanhThu.DataSource = DatabaseConnection.LoadDataIntoDataTable(query);
        //}
        private void chart_BN_TanSuat_LoadChart()
        {
            string query = "SELECT MONTH(NgayLap) AS Thang, COUNT(MaHSBA) AS TanSuat\r\nFROM HOSOBENHAN\r\nWHERE YEAR(NgayLap) = YEAR(GETDATE())\r\nGROUP BY MONTH(NgayLap)";

            chart_BN_TanSuat.DataSource = DatabaseConnection.LoadDataIntoDataTable(query);
        }
        private void chart_NV_TichCuc_LoadChart()
        {
            string query = "SELECT HoTenNV, COUNT(MaHSBA) AS TanSuat\r\nFROM NHANVIEN NV\r\nINNER JOIN HOSOBENHAN HSBA ON HSBA.MaNV = NV.MaNV\r\nWHERE MONTH(NgayLap) = MONTH('10/23/2024')\r\nGROUP BY NV.MaNV, HoTenNV\r\nORDER BY COUNT(MaHSBA) DESC";

            chart_NV_TichCuc.DataSource = DatabaseConnection.LoadDataIntoDataTable(query);
        }
        private void chart_NV_XepHang_LoadChart()
        {
            string query = "SELECT TOP 5 HoTenNV, DanhGia\r\nFROM NHANVIEN\r\nWHERE IsDeleted = 0\r\nORDER BY DanhGia DESC, HoTenNV ASC";

            chart_NV_XepHang.DataSource = DatabaseConnection.LoadDataIntoDataTable(query);
        }

        private void label_Paint(object sender, PaintEventArgs e)
        {
            Label label = sender as Label;
            RectangleF clientRect = label.ClientRectangle;
            Graphics g = e.Graphics;
            SizeF textSize = g.MeasureString(label.Text, label.Font);

            float x = (clientRect.Width - textSize.Width) / 2;
            float y = (clientRect.Height - textSize.Height) / 2;

            //Color SpecialColor = Color.FromArgb(38, 187, 255);
            Color SpecialColor = Color.FromArgb(125, 125, 125);
            Pen unchangePen = new Pen(SpecialColor, 2);
            int startX = 20, offset = 5;
            g.DrawLine(unchangePen, new Point((int)clientRect.X, (int)clientRect.Height / 2 + offset),
                                    new Point((int)x, (int)clientRect.Height / 2 + offset));
            g.DrawLine(unchangePen, new Point((int)(x + textSize.Width), (int)clientRect.Height / 2 + offset),
                                    new Point((int)clientRect.Width, (int)clientRect.Height / 2 + offset));
        }
    }
}
