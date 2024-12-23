using QuanLyMachTu.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.AxHost;
using Scriban;
using Microsoft.Playwright;
using System.Windows.Documents;
using System.Threading.Tasks;
using System.Net.Http;

namespace QuanLyMachTu
{
    public partial class HoaDonControl : UserControl
    {
        //Bit errors
        //Upload textBox
        const int MAHD_ERR = 1;
        const int MABN_ERR = 2;
        const int MANV_ERR = 4;
        const int MADP_ERR = 8;
        const int MADV_ERR = 16;
        const int DATE_ERR = 32;
        const int SL_ERR = 64;

        //Sql Command
        private string HD_SelectCommand = "SELECT MaHD, NgayThanhToan, TongTien, MaBN, MaNV " +
                                          "FROM HOADON " +
                                          "WHERE IsDeleted = 0 ";
        private string CTDV_SelectCommand = "SELECT * FROM CTHD_DichVu ";
        private string CTDP_SelectCommand = "SELECT * FROM CTHD_DuocPham ";
        string selectLastID = "SELECT TOP 1 MaHD FROM HOADON ORDER BY MaHD DESC";
        //Printer
        string waitingString = "Waiting";
        //Control variables
        //tab index
        const int HD_TAB = 0;
        const int DT_TAB = 10;
        const int HDDV_TAB = 20;
        //function index
        const int INS_FUNC = 1;
        const int FIL_FUNC = 2;
        //controllers
        string controlCommand;
        string restoreText;
        int controlPage;
        int HD_controlFunc;
        int DT_controlFunc;
        int HDDV_controlFunc;
        string next_HD_PrimaryKey;
        public HoaDonControl()
        {
            InitializeComponent();
        }
        private void HoaDonControl_Load(object sender, EventArgs e)
        {
            InitializeState();
        }
        //General methods
        //Initialize methods
        private void InitializeState()
        {
            InitializeState_HD();
            InitializeState_DT();
            InitializeState_HDDV();

            controlPage = HD_TAB;
            EnablePage(controlPage);
            LoadPage(controlPage);            
        }
        //Activate / Deactivate tab
        private void OpenFiltersPanel(int controlPage)
        {
            switch (controlPage)
            {
                case HD_TAB:
                    HD_controlFunc = FIL_FUNC;
                    panel_HDFilters.BringToFront();
                    break;
                case DT_TAB:
                    DT_controlFunc = FIL_FUNC;
                    panel_DTFilters.BringToFront();
                    break;
                case HDDV_TAB:
                    HDDV_controlFunc = FIL_FUNC;
                    panel_HDDVFilters.BringToFront();
                    break;
            }
        }
        private void OpenUploadPanel(int controlPage)
        {
            RepaintPanel(panel_Upload);
            panel_Upload.BringToFront();

            switch (controlPage)
            {
                case HD_TAB:
                    HD_controlFunc = INS_FUNC;
                    break;
                case DT_TAB:
                    DT_controlFunc = INS_FUNC;
                    break;
                case HDDV_TAB:
                    HDDV_controlFunc = INS_FUNC;
                    break;
            }
        }
        private void OpenFunctionPanel(int controlFunc)
        {
            switch (controlFunc)
            {
                case INS_FUNC:
                    OpenUploadPanel(controlPage);
                    break;
                case FIL_FUNC:
                    OpenFiltersPanel(controlPage);
                    break;
            }
        }
        private void EnablePage(int controlPage)
        {
            switch (controlPage)
            {
                case HD_TAB:
                    ColoringButton.EnabledColor(pageButton_HDTab);
                    EnableUploadComponents_HD();
                    OpenFunctionPanel(HD_controlFunc);
                    break;
                case DT_TAB:
                    ColoringButton.EnabledColor(pageButton_DTTab);
                    EnableUploadComponents_DT();
                    OpenFunctionPanel(DT_controlFunc);
                    break;
                case HDDV_TAB:
                    ColoringButton.EnabledColor(pageButton_HDDVTab);
                    EnableUploadComponents_HDDV();
                    OpenFunctionPanel(HDDV_controlFunc);
                    break;
            }
        }
        private void LoadPage(int controlPage)
        {
            switch (controlPage)
            {
                case HD_TAB:
                    controlCommand = HD_SelectCommand;
                    break;
                case DT_TAB:
                    controlCommand = CTDP_SelectCommand;
                    break;
                case HDDV_TAB:
                    controlCommand = CTDV_SelectCommand;
                    break;
            }
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        private void DisablePage(int controlPage)
        {
            switch (controlPage)
            {
                case HD_TAB:
                    ColoringButton.DisabledColor(pageButton_HDTab);
                    DisableUploadComponents_HD();
                    break;
                case DT_TAB:
                    ColoringButton.DisabledColor(pageButton_DTTab);
                    DisableUploadComponents_DT();
                    break;
                case HDDV_TAB:
                    ColoringButton.DisabledColor(pageButton_HDDVTab);
                    DisableUploadComponents_HDDV();
                    break;
            }
        }
        //Reload data
        private void UpdateDataGridView(DataGridView dgv, DataTable datatable)
        {
            //Load data to data grid view
            dgv.DataSource = datatable;

            if(controlPage == HD_TAB)
            {
                int soluongHD = dgv.Rows.Count;
                long sumDoanhThu = GeneralMethods.Sum(dgv, "TongTien");
                float avgDoanhThu = 1f * sumDoanhThu / soluongHD;
                label_SoHoaDon_Number.Text = soluongHD.ToString();
                label_TongDoanhThu_Number.Text = sumDoanhThu.ToString("N0");
                label_TrungBinh_Number.Text = avgDoanhThu.ToString("N0");
            }
        }
        //Upload button
        private void pageButton_Upload_Click(object sender, EventArgs e)
        {
            OpenUploadPanel(controlPage);
        }
        private void button_Upload_OK_Click(object sender, EventArgs e)
        {
            switch (controlPage)
            {
                case HD_TAB:
                    button_HDUpload_OK_Click(sender, e);
                    break;
                case DT_TAB:
                    button_DTUpload_OK_Click(sender, e);
                    break;
                case HDDV_TAB:
                    button_HDDVUpload_OK_Click(sender, e);
                    break;
            }
        }
        //Filter button
        private void pageButton_Filters_Click(object sender, EventArgs e)
        {
            OpenFiltersPanel(controlPage);
        }
        //Remove button
        private void pageButton_Remove_Click(object sender, EventArgs e)
        {
            switch (controlPage)
            {
                case HD_TAB:
                    HD_Remove();
                    break;
                case DT_TAB:
                    DT_remove();
                    break;
                case HDDV_TAB:
                    HDDV_remove();
                    break;
            }
        }
        //Paint
        private void panel_Upload_Paint(object sender, PaintEventArgs e)
        {
            Color activatedColor = Color.FromArgb(193, 193, 193);
            Color deactivatedColor = Color.FromArgb(109, 93, 110);

            Color upload_HD_color = deactivatedColor;
            Color upload_DT_color = deactivatedColor;
            Color upload_HDDV_color = deactivatedColor;

            //Unchanged
            Color SpecialColor = Color.FromArgb(38, 187, 255);

            Graphics graphic = e.Graphics;
            Pen unchangePen = new Pen(SpecialColor, 2);
            int startX = 20, offset = 5;
            graphic.DrawLine(unchangePen, new Point(startX, textBox_Upload_MaHD.Location.Y + textBox_Upload_MaHD.Height + offset),
                                          new Point(textBox_Upload_MaHD.Location.X + textBox_Upload_MaHD.Width + offset, textBox_Upload_MaHD.Location.Y + textBox_Upload_MaHD.Height + offset)); //MaHD line

            switch (controlPage)
            {
                case HD_TAB:
                    upload_HD_color = activatedColor;
                    break;
                case DT_TAB:
                    upload_DT_color = activatedColor;
                    break;
                case HDDV_TAB:
                    upload_HDDV_color = activatedColor;
                    break;
            }

            panel_HDUpload_Paint(sender, e, upload_HD_color);
            panel_DTUpload_Paint(sender, e, upload_DT_color);
            panel_HDDVUpload_Paint(sender, e, upload_HDDV_color);
        }
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            int offset = 5;

            foreach (Control control in panel.Controls)
            {
                if (control is TextBox)
                    graphic.DrawLine(linePen, new Point(control.Location.X - offset, control.Location.Y + control.Height + offset),
                                              new Point(control.Location.X + control.Width + offset, control.Location.Y + control.Height + offset));
            }
        }
        private void RepaintPanel(Panel panel)
        {
            panel.Invalidate();
        }
        //Additions
        private void Button_KeyPress_PositiveNumber(object sender, KeyPressEventArgs e)
        {
            GeneralMethods.textBox_KeyPress_PositiveNumber(sender, e);
        }
        private void button_KeyPress_Normal(object sender, KeyPressEventArgs e)
        {
            GeneralMethods.textBox_KeyPress_Normal(sender, e);
        }
        private void customDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                pageButton_Remove_Click(sender, e);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.F)
            {
                pageButton_Filters_Click(sender, e);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.T)
            {
                pageButton_Upload_Click(sender, e);
                e.Handled = true;
            }
        }

        //---------------------------------------------------------------Hoa Don tab---------------------------------------------------------------        
        //Activate tab
        private void pageButton_HDTab_Click(object sender, EventArgs e)
        {

            if (controlPage == HD_TAB)
                return;

            DisablePage(controlPage);
            controlPage = HD_TAB;
            EnablePage(controlPage);
            LoadPage(controlPage);            
        }
        //Load data
        private void InitializeState_HD()
        {
            //prefetch
            next_HD_PrimaryKey = (string)DatabaseConnection.ExecuteScalar(selectLastID, null);
            next_HD_PrimaryKey = StringMath.Increment(next_HD_PrimaryKey);
            //State
            DisablePage(HD_TAB);
            HD_controlFunc = FIL_FUNC;
            OpenFiltersPanel(HD_TAB);
            //Components
            //Filters
            comboBox_HDFilters_Thang.SelectedIndex = 0;
            comboBox_HDFilters_DateComparer.SelectedIndex = 2;
            comboBox_HDFilters_SLComparer.SelectedIndex = 1;
            comboBox_HDFilters_TongTriGiaComparer.SelectedIndex = 1;
            //Upload
            comboBox_Upload_Thang.SelectedIndex = 2;
            AutoFillUploadTextBox();
        }
        //Check and prevent errors        
        private int CheckUploadTextBox_HD()
        {
            int error = 0;
            if (string.IsNullOrEmpty(textBox_Upload_MaBN.Text))
                error |= MABN_ERR;
            if (string.IsNullOrEmpty(textBox_Upload_MaNV.Text))
                error |= MANV_ERR;

            return error;
        }
        private void WarningUploadTextBoxError_HD(int error)
        {
            if ((error & MABN_ERR) == MABN_ERR)
                ColoringTextBox.WarningColor(textBox_Upload_MaBN);
            if ((error & MANV_ERR) == MANV_ERR)
                ColoringTextBox.WarningColor(textBox_Upload_MaNV);
        }
        private void AutoFillUploadTextBox()
        {
            FillMaHD(textBox_Upload_MaHD);
            GeneralMethods.FillDate(textBox_Upload_Ngay, comboBox_Upload_Thang, textBox_Upload_Nam);
        }
        //Auto fill
        private void FillMaHD(TextBox textBox)
        {
            textBox.Text = next_HD_PrimaryKey;
        }
        //Upload method
        //Enable / Disable components
        private void EnableUploadComponents_HD()
        {
            textBox_Upload_MaBN.Enabled = true;
            textBox_Upload_MaNV.Enabled = true;
            textBox_Upload_Ngay.Enabled = true;
            textBox_Upload_Nam.Enabled = true;
            comboBox_Upload_Thang.Enabled = true;
        }
        private void DisableUploadComponents_HD()
        {
            textBox_Upload_MaBN.Enabled = false;
            textBox_Upload_MaNV.Enabled = false;
            textBox_Upload_Ngay.Enabled = false;
            textBox_Upload_Nam.Enabled = false;
            comboBox_Upload_Thang.Enabled = false;
        }
        private void button_HDUpload_OK_Click(object sender, EventArgs e)
        {
            //check errors
            int error = CheckUploadTextBox_HD();

            if (error != 0)
            {
                WarningUploadTextBoxError_HD(error);
                return;
            }

            string primaryKey = textBox_Upload_MaHD.Text;

            string checkQuery = "IF EXISTS (SELECT 1 FROM HOADON WHERE MaHD = @MaHD) SELECT 1 ELSE SELECT 0";
            Dictionary<string, object> checkParameters = new Dictionary<string, object> { { "@MaHD", primaryKey } };

            int recordExists = (int)DatabaseConnection.ExecuteScalar(checkQuery, checkParameters);

            if (recordExists == 0)
            {
                string insertQuery = "INSERT INTO HOADON " +
                                        "(MaHD, NgayThanhToan, MaBN, MaNV) " +
                                        "VALUES(@MaHD, @NgayThanhToan, @MaBN, @MaNV)";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaHD", primaryKey},
                    {"@NgayThanhToan", GeneralMethods.GetNgayThangNam(textBox_Upload_Ngay, comboBox_Upload_Thang, textBox_Upload_Nam) },
                    {"@MaBN", textBox_Upload_MaBN.Text },
                    {"@MaNV", textBox_Upload_MaNV.Text }
                };

                DatabaseConnection.ExecuteNonQuery(insertQuery, parameters);

                //fetch next available primary key
                next_HD_PrimaryKey = StringMath.Increment(next_HD_PrimaryKey);
            }
            else
            {
                string updateQuery = "UPDATE HOADON " +
                                        "SET NgayThanhToan = @NgayThanhToan, " +
                                            "MaBN = @MaBN, " +
                                            "MaNV = @MaNV " +
                                        "WHERE MaHD = @MaHD";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaHD", primaryKey},
                    {"@NgayThanhToan", GeneralMethods.GetNgayThangNam(textBox_Upload_Ngay, comboBox_Upload_Thang, textBox_Upload_Nam) },
                    {"@MaBN", textBox_Upload_MaBN.Text },
                    {"@MaNV", textBox_Upload_MaNV.Text }
                };

                DatabaseConnection.ExecuteNonQuery(updateQuery, parameters);
            }

            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Filter method
        private void button_HDFilter_OK_Click(object sender, EventArgs e)
        {
            string selectCommand = "SELECT DISTINCT HD.MaHD, NgayThanhToan, TongTien, MaBN, MaNV " +
                                   "FROM HOADON HD " +
                                   "LEFT JOIN CTHD_DuocPham CTDP ON HD.MaHD = CTDP.MaHD " +
                                   "LEFT JOIN CTHD_DichVu CTDV ON HD.MaHD = CTDV.MaHD " +
                                   "WHERE HD.IsDeleted = 0 ";

            //search with primary informations
            if (string.IsNullOrEmpty(textBox_HDFilters_MaHD.Text) == false)
                selectCommand += $"AND HD.MaHD = '{textBox_HDFilters_MaHD.Text}' ";
            if (string.IsNullOrEmpty(textBox_HDFilters_MaNV.Text) == false)
                selectCommand += $"AND MaNV = '{textBox_HDFilters_MaNV.Text}' ";
            if (string.IsNullOrEmpty(textBox_HDFilters_MaBN.Text) == false)
                selectCommand += $"AND MaBN = '{textBox_HDFilters_MaBN.Text}' ";
            string comparerTongTriGia = GeneralMethods.GetOperation(comboBox_HDFilters_TongTriGiaComparer);
            if (string.IsNullOrEmpty(textBox_HDFilters_TongTriGia.Text) == false)
                selectCommand += $"AND TongTien {comparerTongTriGia} {textBox_HDFilters_TongTriGia.Text} ";

            string date = GeneralMethods.GetNgayThangNam(textBox_HDFilters_Ngay, comboBox_HDFilters_Thang, textBox_HDFilters_Nam);
            string comparerDate = GeneralMethods.GetOperation(comboBox_HDFilters_DateComparer);
            if (string.IsNullOrEmpty(date) == false)
                selectCommand += $"AND NgayThanhToan {comparerDate} '{date}' ";

            //Another informations
            //informations in datatableDT
            string comparerSoLuong = GeneralMethods.GetOperation(comboBox_HDFilters_SLComparer);
            if (string.IsNullOrEmpty(textBox_HDFilters_MaDP.Text) == false)
                selectCommand += $"AND MaDP = '{textBox_HDFilters_MaDP.Text}' ";
            if (string.IsNullOrEmpty(textBox_HDFilters_SoLuong.Text) == false)
                selectCommand += $"AND SoLuong {comparerSoLuong} {textBox_HDFilters_SoLuong.Text} ";

            //informations in datatableHDDV
            if (string.IsNullOrEmpty(textBox_HDFilters_MaDV.Text) == false)
                selectCommand += $"AND MaDV = '{textBox_HDFilters_MaDV.Text}' ";

            controlCommand = selectCommand;
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Remove
        private void HD_Remove()
        {
            //get all rows of selected cells
            HashSet<DataGridViewRow> selectedRows = new HashSet<DataGridViewRow>();
            foreach (DataGridViewCell cell in customDataGridView.SelectedCells)
                selectedRows.Add(cell.OwningRow);

            //get deleted parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string parameter;
            int parameterIndex = 0;

            string inDeletedList = "(NULL";
            foreach (DataGridViewRow row in selectedRows)
            {
                parameter = $"@MaHD{parameterIndex}";
                parameters.Add(parameter, row.Cells["MaHD"].Value.ToString());
                inDeletedList += $", {parameter}";
                parameterIndex++;
            }
            inDeletedList += ")";

            //remove
            string deleteCommand = "UPDATE HOADON " +
                                   "SET IsDeleted = 1 " +
                                   "WHERE MaHD IN " + inDeletedList;
            DatabaseConnection.ExecuteNonQuery(deleteCommand, parameters);

            //renew
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Decorate panel
        private void panel_HDUpload_Paint(object sender, PaintEventArgs e, Color lineColor)
        {
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            Pen sectionPen = new Pen(lineColor, 2);
            int startX = 20, endX = 395, offset = 5;
            graphic.DrawLine(sectionPen, new Point(startX - 3 * offset, label_Upload_HoaDon.Location.Y + label_Upload_HoaDon.Height / 2 + offset),
                                         new Point(label_Upload_HoaDon.Location.X, label_Upload_HoaDon.Location.Y + label_Upload_HoaDon.Height / 2 + offset)); //label_Upload_HoaDon line
            graphic.DrawLine(sectionPen, new Point(label_Upload_HoaDon.Location.X + label_Upload_HoaDon.Width, label_Upload_HoaDon.Location.Y + label_Upload_HoaDon.Height / 2 + offset),
                                         new Point(endX + offset, label_Upload_HoaDon.Location.Y + label_Upload_HoaDon.Height / 2 + offset)); //label_Upload_HoaDon line

            graphic.DrawLine(linePen, new Point(textBox_Upload_MaBN.Location.X - offset, textBox_Upload_MaBN.Location.Y + textBox_Upload_MaBN.Height + offset),
                                      new Point(textBox_Upload_MaBN.Location.X + textBox_Upload_MaBN.Width + offset, textBox_Upload_MaBN.Location.Y + textBox_Upload_MaBN.Height + offset)); //MaBN line
            graphic.DrawLine(linePen, new Point(textBox_Upload_MaNV.Location.X - offset, textBox_Upload_MaNV.Location.Y + textBox_Upload_MaNV.Height + offset),
                                      new Point(textBox_Upload_MaNV.Location.X + textBox_Upload_MaNV.Width + offset, textBox_Upload_MaNV.Location.Y + textBox_Upload_MaNV.Height + offset)); //MaNV line
            graphic.DrawLine(linePen, new Point(startX, textBox_Upload_Ngay.Location.Y + textBox_Upload_Ngay.Height + offset),
                                      new Point(textBox_Upload_Ngay.Location.X + textBox_Upload_Ngay.Width + offset, textBox_Upload_Ngay.Location.Y + textBox_Upload_Ngay.Height + offset)); //Ngay line
            graphic.DrawLine(linePen, new Point(textBox_Upload_Nam.Location.X - offset, textBox_Upload_Nam.Location.Y + textBox_Upload_Nam.Height + offset),
                                      new Point(textBox_Upload_Nam.Location.X + textBox_Upload_Nam.Width + offset, textBox_Upload_Nam.Location.Y + textBox_Upload_Nam.Height + offset)); //Nam line

            int x = label_Upload_NgayLap.Location.X - 9;
            int startY = label_Upload_NgayLap.Location.Y, endY = startY + label_Upload_NgayLap.Height;
            graphic.DrawLine(linePen, new Point(x, startY), new Point(x, endY));
        }
        private void panel_HDFilter_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            Pen sectionPen = new Pen(lineColor, 2);
            int startX = 20, endX = 395, offset = 5;

            foreach (Control control in panel.Controls)
            {
                if (control is TextBox)
                    graphic.DrawLine(linePen, new Point(control.Location.X - offset, control.Location.Y + control.Height + offset),
                                              new Point(control.Location.X + control.Width + offset, control.Location.Y + control.Height + offset));
            }

            graphic.DrawLine(sectionPen, new Point(startX - 3 * offset, label_Filters_ThongTinBoSung.Location.Y + label_Filters_ThongTinBoSung.Height / 2 + offset),
                                         new Point(label_Filters_ThongTinBoSung.Location.X, label_Filters_ThongTinBoSung.Location.Y + label_Filters_ThongTinBoSung.Height / 2 + offset)); //label_Filters_ThongTinBoSung line
            graphic.DrawLine(sectionPen, new Point(label_Filters_ThongTinBoSung.Location.X + label_Filters_ThongTinBoSung.Width, label_Filters_ThongTinBoSung.Location.Y + label_Filters_ThongTinBoSung.Height / 2 + offset),
                                         new Point(endX, label_Filters_ThongTinBoSung.Location.Y + label_Filters_ThongTinBoSung.Height / 2 + offset)); //label_Filters_ThongTinBoSung line            

            int x = label_HDFilters_NgayLap.Location.X - 9;
            int startY = label_HDFilters_NgayLap.Location.Y, endY = startY + label_HDFilters_NgayLap.Height;
            graphic.DrawLine(linePen, new Point(x, startY), new Point(x, endY));
        }

        //---------------------------------------------------------------Don Thuoc tab---------------------------------------------------------------        
        //Activate tab
        private void pageButton_DTTab_Click(object sender, EventArgs e)
        {
            if (controlPage == DT_TAB)
                return;

            DisablePage(controlPage);
            controlPage = DT_TAB;
            EnablePage(controlPage);
            LoadPage(controlPage);
        }
        //Load data
        private void InitializeState_DT()
        {
            //State
            DisablePage(DT_TAB);
            DT_controlFunc = FIL_FUNC;
            //Components
            //Filters
            comboBox_DTFilters_ComparerSoLuong.SelectedIndex = 2;
            comboBox_DTFilters_ComparerGiaTien.SelectedIndex = 2;
        }
        //Check and prevent errors        
        private int CheckUploadTextBox_DT()
        {
            int error = 0;
            if (string.IsNullOrEmpty(textBox_Upload_MaHD.Text))
                error |= MAHD_ERR;
            if (string.IsNullOrEmpty(textBox_Upload_MaDP.Text))
                error |= MADP_ERR;
            if (string.IsNullOrEmpty(textBox_Upload_SoLuong.Text))
                error |= SL_ERR;

            return error;
        }
        private void WarningUploadTextBoxError_DT(int error)
        {
            if ((error & MABN_ERR) == MABN_ERR)
                ColoringTextBox.WarningColor(textBox_Upload_MaBN);
            if ((error & MADP_ERR) == MADP_ERR)
                ColoringTextBox.WarningColor(textBox_Upload_MaDP);
            if ((error & SL_ERR) == SL_ERR)
                ColoringTextBox.WarningColor(textBox_Upload_SoLuong);
        }
        //Upload method
        //Enable / Disable components
        private void EnableUploadComponents_DT()
        {
            textBox_Upload_MaDP.Enabled = true;
            textBox_Upload_SoLuong.Enabled = true;
        }
        private void DisableUploadComponents_DT()
        {
            textBox_Upload_MaDP.Enabled = false;
            textBox_Upload_SoLuong.Enabled = false;
        }
        private void button_DTUpload_OK_Click(object sender, EventArgs e)
        {
            //check errors
            int error = CheckUploadTextBox_DT();

            if (error != 0)
            {
                WarningUploadTextBoxError_DT(error);
                return;
            }

            string[] primaryKey = [textBox_Upload_MaHD.Text, textBox_Upload_MaDP.Text];

            string checkQuery = "IF EXISTS (SELECT 1 FROM CTHD_DuocPham WHERE MaHD = @MaHD AND MaDP = @MaDP) SELECT 1 ELSE SELECT 0";
            Dictionary<string, object> checkParameters = new Dictionary<string, object> { { "@MaHD", primaryKey[0] }, { "@MaDP", primaryKey[1] } };

            int recordExists = (int)DatabaseConnection.ExecuteScalar(checkQuery, checkParameters);

            if (recordExists == 0)
            {
                string insertQuery = "INSERT INTO CTHD_DuocPham " +
                                     "(MaHD, MaDP, SoLuong) " +
                                     "VALUES(@MaHD, @MaDP, @SoLuong)";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaHD", primaryKey[0]},
                    {"@MaDP", primaryKey[1]},
                    {"@SoLuong", textBox_Upload_SoLuong.Text }
                };

                DatabaseConnection.ExecuteNonQuery(insertQuery, parameters);
            }
            else
            {
                string updateQuery = "UPDATE CTHD_DuocPham " +
                                        "SET SoLuong = @SoLuong " +
                                        "WHERE MaHD = @MaHD AND MaDP = @MaDP";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaHD", primaryKey[0]},
                    {"@MaDP", primaryKey[1]},
                    {"@SoLuong", textBox_Upload_SoLuong.Text }
                };

                DatabaseConnection.ExecuteNonQuery(updateQuery, parameters);
            }

            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Filter method
        private void button_DTFilter_OK_Click(object sender, EventArgs e)
        {
            string selectCommand = "SELECT * " +
                                   "FROM CTHD_DuocPham " +
                                   "WHERE 1 = 1 ";

            //search with primary information
            if (string.IsNullOrEmpty(textBox_DTFilters_MaHD.Text) == false)
                selectCommand += $"AND MaHD = '{textBox_DTFilters_MaHD.Text}' ";
            if (string.IsNullOrEmpty(textBox_DTFilters_MaDP.Text) == false)
                selectCommand += $"AND MaDP = '{textBox_DTFilters_MaDP.Text}' ";

            string comparerSoLuong = GeneralMethods.GetOperation(comboBox_DTFilters_ComparerSoLuong);
            if (string.IsNullOrEmpty(textBox_DTFilters_SoLuong.Text) == false)
                selectCommand += $"AND SoLuong {comparerSoLuong} '{textBox_DTFilters_SoLuong.Text}' ";
            string comparerGiaTien = GeneralMethods.GetOperation(comboBox_DTFilters_ComparerGiaTien);
            if (string.IsNullOrEmpty(textBox_DTFilters_GiaTien.Text) == false)
                selectCommand += $"AND GiaTien {comparerGiaTien} '{textBox_DTFilters_GiaTien.Text}' ";

            controlCommand = selectCommand;
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Remove
        private void DT_remove()
        {
            //get all rows of selected cells
            HashSet<DataGridViewRow> selectedRows = new HashSet<DataGridViewRow>();
            foreach (DataGridViewCell cell in customDataGridView.SelectedCells)
                selectedRows.Add(cell.OwningRow);

            //get deleted parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string parameter1, parameter2;
            int parameterIndex = 0;

            string maHD, maDP;

            string inDeletedList = "1 != 1 ";
            foreach (DataGridViewRow row in selectedRows)
            {
                parameter1 = $"@MaHD{parameterIndex}";
                parameter2 = $"@MaDP{parameterIndex}";
                maHD = row.Cells["MaHD"].Value.ToString();
                maDP = row.Cells["MaDP"].Value.ToString();
                parameters.Add(parameter1, maHD);
                parameters.Add(parameter2, maDP);
                inDeletedList += $"OR (MaHD = {parameter1} AND MaDP = {parameter2}) ";
                parameterIndex++;
            }

            //remove
            string deleteCommand = "DELETE FROM CTHD_DuocPham " +
                                   "WHERE " + inDeletedList;
            DatabaseConnection.ExecuteNonQuery(deleteCommand, parameters);

            //renew
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Decorate panel
        private void panel_DTUpload_Paint(object sender, PaintEventArgs e, Color lineColor)
        {
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            Pen sectionPen = new Pen(lineColor, 2);
            int startX = 20, endX = 395, offset = 5;
            graphic.DrawLine(sectionPen, new Point(startX - 3 * offset, label_Upload_DonThuoc.Location.Y + label_Upload_DonThuoc.Height / 2 + offset),
                                         new Point(label_Upload_DonThuoc.Location.X, label_Upload_DonThuoc.Location.Y + label_Upload_DonThuoc.Height / 2 + offset)); //label_Upload_DonThuoc line
            graphic.DrawLine(sectionPen, new Point(label_Upload_DonThuoc.Location.X + label_Upload_DonThuoc.Width, label_Upload_DonThuoc.Location.Y + label_Upload_DonThuoc.Height / 2 + offset),
                                         new Point(endX + offset, label_Upload_DonThuoc.Location.Y + label_Upload_DonThuoc.Height / 2 + offset)); //label_Upload_DonThuoc line

            graphic.DrawLine(linePen, new Point(startX, textBox_Upload_MaDP.Location.Y + textBox_Upload_MaDP.Height + offset),
                                      new Point(textBox_Upload_MaDP.Location.X + textBox_Upload_MaDP.Width + offset, textBox_Upload_MaDP.Location.Y + textBox_Upload_MaDP.Height + offset)); //MaDP line
            graphic.DrawLine(linePen, new Point(textBox_Upload_SoLuong.Location.X - offset, textBox_Upload_SoLuong.Location.Y + textBox_Upload_SoLuong.Height + offset),
                                      new Point(textBox_Upload_SoLuong.Location.X + textBox_Upload_SoLuong.Width + offset, textBox_Upload_SoLuong.Location.Y + textBox_Upload_SoLuong.Height + offset)); //SoLuong line
        }

        //---------------------------------------------------------------Hoa Don Dich Vu tab---------------------------------------------------------------        
        //Activate tab
        private void pageButton_HDDVTab_Click(object sender, EventArgs e)
        {
            if (controlPage == HDDV_TAB)
                return;

            DisablePage(controlPage);
            controlPage = HDDV_TAB;
            EnablePage(controlPage);
            LoadPage(controlPage);
        }
        //Load data
        private void InitializeState_HDDV()
        {
            //State
            DisablePage(HDDV_TAB);
            HDDV_controlFunc = FIL_FUNC;
            //Components
            comboBox_HDDVFilters_Comparer.SelectedIndex = 2;
        }
        //Check and prevent errors        
        private int CheckUploadTextBox_HDDV()
        {
            int error = 0;
            if (string.IsNullOrEmpty(textBox_Upload_MaDV.Text))
                error |= MADV_ERR;

            return error;
        }
        private void WarningUploadTextBoxError_HDDV(int error)
        {
            if ((error & MADV_ERR) == MADV_ERR)
                ColoringTextBox.WarningColor(textBox_Upload_MaDV);
        }
        //Upload method
        //Enable / Disable components
        private void EnableUploadComponents_HDDV()
        {
            textBox_Upload_MaDV.Enabled = true;
        }
        private void DisableUploadComponents_HDDV()
        {
            textBox_Upload_MaDV.Enabled = false;
        }
        private void button_HDDVUpload_OK_Click(object sender, EventArgs e)
        {
            //check errors
            int error = CheckUploadTextBox_HDDV();

            if (error != 0)
            {
                WarningUploadTextBoxError_HDDV(error);
                return;
            }

            string[] primaryKey = { textBox_Upload_MaHD.Text, textBox_Upload_MaDV.Text };

            string insertQuery = "INSERT INTO CTHD_DichVu " +
                                    "(MaHD, MaDV) " +
                                    "VALUES(@MaHD, @MaDV)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@MaHD", primaryKey[0]},
                {"@MaDV", primaryKey[1]}
            };

            DatabaseConnection.ExecuteNonQuery(insertQuery, parameters);

            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Filter method
        private void button_HDDVFilter_OK_Click(object sender, EventArgs e)
        {
            string selectCommand = "SELECT * " +
                                   "FROM CTHD_DichVu " +
                                   "WHERE 1 = 1 ";

            //search with primary informations
            if (string.IsNullOrEmpty(textBox_HDDVFilters_MaHD.Text) == false)
                selectCommand += $"AND MaHD = '{textBox_HDDVFilters_MaHD.Text}' ";
            if (string.IsNullOrEmpty(textBox_HDDVFilters_MaDV.Text) == false)
                selectCommand += $"AND MaDV = '{textBox_HDDVFilters_MaDV.Text}' ";
            string comparer = GeneralMethods.GetOperation(comboBox_HDDVFilters_Comparer);
            if (string.IsNullOrEmpty(textBox_HDDVFilters_ChiPhi.Text) == false)
                selectCommand += $"AND GiaTien {comparer} '{textBox_HDDVFilters_ChiPhi.Text}' ";

            controlCommand = selectCommand;
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        private void HDDV_remove()
        {
            //get all rows of selected cells
            HashSet<DataGridViewRow> selectedRows = new HashSet<DataGridViewRow>();
            foreach (DataGridViewCell cell in customDataGridView.SelectedCells)
                selectedRows.Add(cell.OwningRow);

            //get deleted parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string parameter1, parameter2;
            int parameterIndex = 0;

            string maHD, maDV;

            string inDeletedList = "1 != 1 ";
            foreach (DataGridViewRow row in selectedRows)
            {
                parameter1 = $"@MaHD{parameterIndex}";
                parameter2 = $"@MaDV{parameterIndex}";
                maHD = row.Cells["MaHD"].Value.ToString();
                maDV = row.Cells["MaDV"].Value.ToString();
                parameters.Add(parameter1, maHD);
                parameters.Add(parameter2, maDV);
                inDeletedList += $"OR (MaHD = {parameter1} AND MaDV = {parameter2}) ";
                parameterIndex++;
            }

            //remove
            string deleteCommand = "DELETE FROM CTHD_DichVu " +
                                   "WHERE " + inDeletedList;
            DatabaseConnection.ExecuteNonQuery(deleteCommand, parameters);

            //renew
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Decorate panel
        private void panel_HDDVUpload_Paint(object sender, PaintEventArgs e, Color lineColor)
        {
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            Pen sectionPen = new Pen(lineColor, 2);
            int startX = 20, endX = 395, offset = 5;
            graphic.DrawLine(sectionPen, new Point(startX - 3 * offset, label_Upload_DichVu.Location.Y + label_Upload_DichVu.Height / 2 + offset),
                                         new Point(label_Upload_DichVu.Location.X, label_Upload_DichVu.Location.Y + label_Upload_DichVu.Height / 2 + offset)); //label_Upload_DichVu line
            graphic.DrawLine(sectionPen, new Point(label_Upload_DichVu.Location.X + label_Upload_DichVu.Width, label_Upload_DichVu.Location.Y + label_Upload_DichVu.Height / 2 + offset),
                                         new Point(endX + offset, label_Upload_DichVu.Location.Y + label_Upload_DichVu.Height / 2 + offset)); //label_Upload_DichVu line

            graphic.DrawLine(linePen, new Point(startX, textBox_Upload_MaDV.Location.Y + textBox_Upload_MaDV.Height + offset),
                                      new Point(textBox_Upload_MaDV.Location.X + textBox_Upload_MaDV.Width + offset, textBox_Upload_MaDV.Location.Y + textBox_Upload_MaDV.Height + offset)); //MaDV line            
        }

        private void textBox_MaHD_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrEmpty(textBox.Text))
                FillMaHD(textBox);
        }

        private void customDataGridView_CellMouseDoubleClicked(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.Button != MouseButtons.Left)
                return;

            DataGridView dgv = sender as DataGridView;
            DataRowView drv = dgv.Rows[e.RowIndex].DataBoundItem as DataRowView;
            DataRow row = drv.Row;

            switch (controlPage)
            {
                case HD_TAB:
                    fillPanel_HD(row);
                    break;
                case DT_TAB:
                    fillPanel_DT(row);
                    break;
                case HDDV_TAB:
                    fillPanel_HDDV(row);
                    break;
            }
        }

        private void fillPanel_HD(DataRow row)
        {
            DateTime date = row.Field<DateTime>("NgayThanhToan");            
            switch (HD_controlFunc)
            {
                case INS_FUNC:
                    textBox_Upload_MaHD.Text = row["MaHD"].ToString();
                    textBox_Upload_MaBN.Text = row["MaBN"].ToString();
                    textBox_Upload_MaNV.Text = row["MaNV"].ToString();
                    textBox_Upload_Ngay.Text = date.Day.ToString();
                    comboBox_Upload_Thang.SelectedIndex = date.Month - 1;
                    textBox_Upload_Nam.Text = date.Year.ToString();
                    GeneralMethods.CleanColorPanel(panel_Upload);
                    break;
                case FIL_FUNC:
                    GeneralMethods.SetUpPanel(panel_HDFilters, 2);
                    textBox_HDFilters_MaHD.Text = row["MaHD"].ToString();
                    textBox_HDFilters_MaBN.Text = row["MaBN"].ToString();
                    textBox_HDFilters_MaNV.Text = row["MaNV"].ToString();
                    textBox_HDFilters_Ngay.Text = date.Day.ToString();
                    comboBox_HDFilters_Thang.SelectedIndex = date.Month - 1;
                    textBox_HDFilters_Nam.Text = date.Year.ToString();
                    textBox_HDFilters_TongTriGia.Text = row["TongTien"].ToString();                    
                    break;
            }
        }

        private void fillPanel_DT(DataRow row)
        {
            switch (DT_controlFunc)
            {
                case INS_FUNC:
                    textBox_Upload_MaHD.Text = row["MaHD"].ToString();
                    textBox_Upload_MaDP.Text = row["MaDP"].ToString();
                    textBox_Upload_SoLuong.Text = row["SoLuong"].ToString();
                    GeneralMethods.CleanColorPanel(panel_Upload);
                    break;
                case FIL_FUNC:
                    textBox_DTFilters_MaHD.Text = row["MaHD"].ToString();
                    textBox_DTFilters_MaDP.Text = row["MaDP"].ToString();
                    textBox_DTFilters_SoLuong.Text = row["SoLuong"].ToString();
                    textBox_DTFilters_GiaTien.Text = row["GiaTien"].ToString();
                    GeneralMethods.SetUpPanel(panel_DTFilters, 2);
                    break;
            }
        }

        private void fillPanel_HDDV(DataRow row)
        {
            switch (HDDV_controlFunc)
            {
                case INS_FUNC:
                    textBox_Upload_MaHD.Text = row["MaHD"].ToString();
                    textBox_Upload_MaDV.Text = row["MaDV"].ToString();
                    GeneralMethods.CleanColorPanel(panel_Upload);
                    break;
                case FIL_FUNC:
                    textBox_HDDVFilters_MaHD.Text = row["MaHD"].ToString();
                    textBox_HDDVFilters_MaDV.Text = row["MaDV"].ToString();
                    textBox_HDDVFilters_ChiPhi.Text = row["GiaTien"].ToString();
                    GeneralMethods.SetUpPanel(panel_HDDVFilters, 2);
                    break;
            }
        }

        private void button_Filter_Reset_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Panel panel = button.Parent as Panel;

            GeneralMethods.ClearPanel(panel);
            GeneralMethods.CleanColorPanel(panel);
            GeneralMethods.SetUpPanel(panel, 2);

            if (panel == panel_HDFilters)
                comboBox_HDFilters_Thang.SelectedIndex = 0;

            LoadPage(controlPage);
        }

        private void textBox_Upload_Reset_Click(object sender, EventArgs e)
        {
            FillMaHD(textBox_Upload_MaHD);

            switch (controlPage)
            {
                case HD_TAB:
                    textBox_Upload_MaBN.Text = null;
                    textBox_Upload_MaNV.Text = null;
                    GeneralMethods.FillDate(textBox_Upload_Ngay, comboBox_Upload_Thang, textBox_Upload_Nam);
                    break;
                case DT_TAB:
                    textBox_Upload_MaDP.Text = null;
                    textBox_Upload_SoLuong.Text = null;
                    break;
                case HDDV_TAB:
                    textBox_Upload_MaDV.Text = null;
                    break;
            }

            LoadPage(controlPage);
        }        
        private List<string> GetPrimaryKeysFromRows(string primaryKeyName)
        {
            if (customDataGridView.SelectedCells.Count > 0)
            {
                HashSet<DataGridViewRow> selectedRows = new HashSet<DataGridViewRow>();
                foreach (DataGridViewCell cell in customDataGridView.SelectedCells)
                    selectedRows.Add(cell.OwningRow);

                List<string> primaryKeys = new List<string>();
                foreach (DataGridViewRow row in selectedRows)
                    primaryKeys.Add(row.Cells[primaryKeyName].Value.ToString());

                return primaryKeys;
            }
            else
                return null;
        }

        private object GetDataFromPrimaryKey(string primaryKey)
        {
            //RETRIEVE FROM DATABASE
            string patientRetrieveCommand = "SELECT MaHD, NgayThanhToan, HoTenBN, Email, SDT, TongTien " +
                                            "FROM HOADON HD " +
                                            "INNER JOIN BENHNHAN BN ON BN.MaBN = HD.MaBN ";
            string serviceRetrieveCommand = "SELECT TenDV, GiaTien " +
                                            "FROM CTHD_DichVu CTDV " +
                                            "INNER JOIN DICHVU DV ON DV.MaDV = CTDV.MaDV ";
            string medicineRetrieveCommand = "SELECT TenDP, CTDP.SoLuong, GiaTien, GiaTien/CTDP.SoLuong AS GiaLe " +
                                             "FROM CTHD_DuocPham CTDP " +
                                             "INNER JOIN DUOCPHAM DP ON DP.MaDP = CTDP.MaDP ";

            string condition = $"WHERE MaHD = '{primaryKey}' ";

            DataTable selectedRow = DatabaseConnection.LoadDataIntoDataTable(patientRetrieveCommand + condition);
            DataTable serviceRows = DatabaseConnection.LoadDataIntoDataTable(serviceRetrieveCommand + condition);
            DataTable medicineRows = DatabaseConnection.LoadDataIntoDataTable(medicineRetrieveCommand + condition);

            if (selectedRow.Rows.Count == 0)
                throw new Exception("Invoice not found");
            //GET
            var service = new List<object>();
            //get service
            foreach (DataRow row in serviceRows.Rows)
            {
                service.Add(new
                {
                    name = row["TenDV"].ToString(),
                    description = "Service",
                    quantity = 1,
                    price = row["GiaTien"].ToString(),
                    total_price = row["GiaTien"].ToString()
                });
            }

            //get medicine
            foreach (DataRow row in medicineRows.Rows)
            {
                int quantity = Convert.ToInt32(row["SoLuong"]);
                int price = Convert.ToInt32(row["GiaLe"]);
                int totalPrice = Convert.ToInt32(row["GiaTien"]);
                service.Add(new
                {
                    name = row["TenDP"].ToString(),
                    description = "Medicine",
                    quantity = quantity,
                    price = price,
                    total_price = totalPrice
                });
            }

            int subtotal = Convert.ToInt32(selectedRow.Rows[0]["TongTien"]);
            float taxFee = 0.1f * subtotal;
            float grandtotal = subtotal + taxFee;

            var invoice = new
            {
                date = selectedRow.Rows[0]["NgayThanhToan"].ToString(),
                id = selectedRow.Rows[0]["MaHD"].ToString()
            };

            var patient = new
            {
                name = selectedRow.Rows[0]["HoTenBN"].ToString(),
                email = selectedRow.Rows[0]["Email"].ToString(),
                phonenumber = selectedRow.Rows[0]["SDT"].ToString()
            };

            var data = new
            {
                data = new
                {
                    companyName = "Clinic",
                    invoice = invoice,
                    patient = patient,
                    sub_total = subtotal,
                    tax = taxFee,
                    grand_total = grandtotal,
                    service = service
                }
            };

            return data;
        }
        private async void pageButton_Printing_HD_Click(object sender, EventArgs e)
        {
            //display
            ColoringButton.EnabledColor(pageButton_Printing_HD);
            restoreText = pageButton_Printing_HD.CustomText;
            pageButton_Printing_HD.CustomText = waitingString;

            //get primary keys
            List<string> primaryKeys = GetPrimaryKeysFromRows("MaHD");
            // List to hold all tasks for printing invoices
            List<Task> printTasks = new List<Task>();

            foreach (string primaryKey in primaryKeys)
            {
                var data = GetDataFromPrimaryKey(primaryKey);
                printTasks.Add(PrintInvoice(data));
            }

            //wait(NULL)
            await Task.WhenAll(printTasks);
            //Graphical show
            pageButton_Printing_HD.CustomText = restoreText;
            ColoringButton.DisabledColor(pageButton_Printing_HD);
        }
        private async Task PrintInvoice(object data)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.DefaultExt = "pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string templatePath = @"Template\template.html";
                string htmlTemplate = File.ReadAllText(templatePath);

                var template = Template.Parse(htmlTemplate);
                string filledHtml = template.Render(data);

                await PrintHtmlWithPlaywright(filledHtml, saveFileDialog.FileName);
            }
        }

        private async Task PrintHtmlWithPlaywright(string htmlContent, string saveFileURL)
        {
            // Write content to export.html
            File.WriteAllText("export.html", htmlContent);
            //Process.Start(new ProcessStartInfo("export.html") { UseShellExecute = true });

            var dataUrl = "data:text/html;base64," + Convert.ToBase64String(Encoding.UTF8.GetBytes(htmlContent));

            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true,
            });

            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync(dataUrl, new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });

            // Generate the PDF
            var output = await page.PdfAsync(new PagePdfOptions
            {
                Width = "600px",
                Height = "Auto",
                Format = "letter", // or "letter"
                Landscape = true,
                Margin = new Microsoft.Playwright.Margin() { Top = "0", Right = "0", Bottom = "0", Left = "0" },
                Scale = 0.8f,
                PrintBackground = true
            });

            // Generate the PDF
            try
            {
                File.WriteAllBytes(saveFileURL, output);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Open the PDF
            Process.Start(new ProcessStartInfo(saveFileURL) { UseShellExecute = true });

            await browser.CloseAsync();            
        }
    }
}
