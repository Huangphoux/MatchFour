using QuanLyMachTu.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.AxHost;

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

        //Database fields
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataSet dataset;
        private DataTable datatableHD;
        private DataTable datatableDT;
        private DataTable datatableHDDV;
        //Database connection
        private string connectionStr = @"Server=LAPTOP-6GL1AF15\STUDENT;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";

        //Control variables
        //tab index
        const int HD_TAB = 0;
        const int DT_TAB = 10;
        const int HDDV_TAB = 20;
        //function index
        const int INS_FUNC = 1;
        const int FIL_FUNC = 2;
        //controllers
        int controlPage;
        int HD_controlFunc;
        int DT_controlFunc;
        int HDDV_controlFunc;
        DataTable controlDataTable;
        public HoaDonControl()
        {
            InitializeComponent();
        }
        private void HoaDonControl_Load(object sender, EventArgs e)
        {
            LoadData();
            InitializeState();
        }
        //General methods
        //Initialize methods
        private void InitializeState()
        {
            DisablePage(HD_TAB);
            DisablePage(DT_TAB);
            DisablePage(HDDV_TAB);

            controlPage = HD_TAB;

            HD_controlFunc = FIL_FUNC;
            DT_controlFunc = FIL_FUNC;
            HDDV_controlFunc = FIL_FUNC;

            controlDataTable = datatableHD;            

            EnablePage(controlPage);
            openFunctionPanel(HD_controlFunc);
            customDataGridView.Focus();
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
        private void openFunctionPanel(int controlFunc)
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
                    controlDataTable = datatableHD;
                    ColoringButton.EnabledColor(pageButton_HDTab);
                    EnableUploadComponents_HD();
                    break;
                case DT_TAB:
                    controlDataTable = datatableDT;
                    ColoringButton.EnabledColor(pageButton_DTTab);
                    EnableUploadComponents_DT();
                    break;
                case HDDV_TAB:
                    controlDataTable = datatableHDDV;
                    ColoringButton.EnabledColor(pageButton_HDDVTab);
                    EnableUploadComponents_HDDV();
                    break;
            }

            UpdateDataGridView(customDataGridView, controlDataTable);
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
        //Load methods
        private void LoadData()
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();

            dataset = new DataSet();
            LoadTabHoaDon();
            LoadTabDonThuoc();
            LoadTabHoaDonDichVu();

            connection.Close();
        }
        private void LoadDataToDataSet(string commandStr, string tableName)
        {
            adapter = new SqlDataAdapter(commandStr, connection);
            adapter.Fill(dataset, tableName);
        }
        //Reload data
        private void UpdateDataGridView(DataGridView dgv, DataTable datatable)
        {
            //Load data to data grid view
            dgv.DataSource = datatable;
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
            DataColumn[] primaryKeyColumn = controlDataTable.PrimaryKey;
            string[] primaryKeyName = new string[primaryKeyColumn.Length];
            string[] primaryKey = new string[primaryKeyColumn.Length];
            HashSet<DataGridViewRow> selectedRows = new HashSet<DataGridViewRow>();

            //get primary key name
            for (int col = 0; col < primaryKeyName.Length; col++)
                primaryKeyName[col] = primaryKeyColumn[col].ColumnName;

            //get all rows of selected cells
            foreach (DataGridViewCell cell in customDataGridView.SelectedCells)
                selectedRows.Add(cell.OwningRow);

            //remove row with primary key
            foreach (DataGridViewRow row in selectedRows)
            {
                //get primary key value
                for (int col = 0; col < primaryKeyName.Length; col++)
                    primaryKey[col] = row.Cells[primaryKeyName[col]].Value.ToString();
                //remove row
                DataRow? deleteRow = controlDataTable.Rows.Find(primaryKey);
                controlDataTable.Rows.Remove(deleteRow);
            }

            UpdateDataGridView(customDataGridView, controlDataTable);
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
        private bool CheckRowCondition(DataRow row1, DataRow row2, string[] condition_columns)
        {
            for (int condition = 0; condition < condition_columns.Length; condition++)
            {
                string columnName = condition_columns[condition];
                if (row1[columnName].ToString() != row2[columnName].ToString())
                    return false;
            }

            return true;
        }
        private List<DataRow> Intersect(DataRow[] rows1, DataRow[] rows2, string[] condition_columns)
        {
            List<DataRow> result = new List<DataRow>();

            for (int row1 = 0; row1 < rows1.Length; row1++)
            {
                for (int row2 = 0; row2 < rows2.Length; row2++)
                {
                    if (CheckRowCondition(rows1[row1], rows2[row2], condition_columns))
                    {
                        result.Add(rows1[row1]);
                        break;
                    }
                }
            }

            return result;
        }
        private string GetOperation(ComboBox operations)
        {
            string selected = operations.SelectedItem as string;
            switch (selected)
            {
                case "≥":
                    return ">=";
                case "≤":
                    return "<=";
                default:
                    return selected;
            }
        }
        private string GetNgayThangNam(TextBox textBox_Ngay, ComboBox comboBox_Thang, TextBox textBox_Nam)
        {
            int day, year;
            int month = comboBox_Thang.SelectedIndex + 1;

            bool isDayRead = int.TryParse(textBox_Ngay.Text, out day);
            bool isYearRead = int.TryParse(textBox_Nam.Text, out year);

            if (!isDayRead)
                return null;
            else if (!isYearRead)
                return null;

            int maxDays = GetDaysOfMonth(month, year);

            if (day < 1 || day > maxDays)
                return null;

            return $"{comboBox_Thang.SelectedIndex + 1}/{textBox_Ngay.Text}/{textBox_Nam.Text}";
        }
        private int isLeapYear(int year)
        {
            return Convert.ToInt32(year % 4 == 0 && year % 100 != 0 || year % 400 == 0);
        }
        private int GetDaysOfMonth(int month, int year)
        {
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    return 28 + isLeapYear(year);
                default:
                    return 30;
            }
        }
        private void Button_KeyPress_PositiveNumber(object sender, KeyPressEventArgs e)
        {
            ColoringTextBox.NormalColor((TextBox)sender);

            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
        private void button_KeyPress_Normal(object sender, KeyPressEventArgs e)
        {
            ColoringTextBox.NormalColor((TextBox)sender);
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
            controlDataTable = datatableHD;
            EnablePage(controlPage);
            openFunctionPanel(HD_controlFunc);

            customDataGridView.Focus();
        }
        //Load data
        private void LoadTabHoaDon()
        {
            LoadDataToDataSet("SELECT * FROM HOADON", "HOADON");
            datatableHD = dataset.Tables["HOADON"];
            datatableHD.PrimaryKey = new DataColumn[] { datatableHD.Columns["MaHD"] };

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
            if (string.IsNullOrEmpty(GetNgayThangNam(textBox_Upload_Ngay, comboBox_Upload_Thang, textBox_Upload_Nam)))
                error |= DATE_ERR;

            return error;
        }
        private void WarningUploadTextBoxError_HD(int error)
        {
            if ((error & MABN_ERR) == MABN_ERR)
                ColoringTextBox.WarningColor(textBox_Upload_MaBN);
            if ((error & MANV_ERR) == MANV_ERR)
                ColoringTextBox.WarningColor(textBox_Upload_MaNV);
            if ((error & DATE_ERR) == DATE_ERR)
                ColoringTextBox.WarningColor(textBox_Upload_Ngay);
        }
        private void AutoFillUploadTextBox()
        {
            FillMaHD(textBox_Upload_MaHD);
            FillDate(textBox_Upload_Ngay, comboBox_Upload_Thang, textBox_Upload_Nam);
        }
        //Auto fill
        private void FillMaHD(TextBox textBox)
        {
            string MaHD = datatableHD.Rows[datatableHD.Rows.Count - 1]["MaHD"].ToString();
            MaHD = StringMath.Increment(MaHD);
            textBox.Text = MaHD;
        }
        private void FillDate(TextBox ngay, ComboBox thang, TextBox nam)
        {
            DateTime currentDate = DateTime.Now;
            ngay.Text = currentDate.Day.ToString("D2");
            thang.SelectedIndex = currentDate.Month - 1;
            nam.Text = currentDate.Year.ToString("D2");
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
            DataRow targetRow = datatableHD.Rows.Find(primaryKey);

            if (targetRow == null) // Insert
            {
                targetRow = datatableHD.NewRow();
                targetRow["MaHD"] = primaryKey;
                targetRow["MaBN"] = textBox_Upload_MaBN.Text;
                targetRow["MaNV"] = textBox_Upload_MaNV.Text;
                targetRow["NgayThanhToan"] = GetNgayThangNam(textBox_Upload_Ngay, comboBox_Upload_Thang, textBox_Upload_Nam);
                datatableHD.Rows.Add(targetRow);
            }
            else //Update
            {
                targetRow["MaBN"] = textBox_Upload_MaBN.Text;
                targetRow["MaNV"] = textBox_Upload_MaNV.Text;
                targetRow["NgayThanhToan"] = GetNgayThangNam(textBox_Upload_Ngay, comboBox_Upload_Thang, textBox_Upload_Nam);
            }

            UpdateDataGridView(customDataGridView, datatableHD);
        }
        //Filter method
        private void button_HDFilter_OK_Click(object sender, EventArgs e)
        {
            string selectCommand_HD = "1 = 1 ";
            string selectCommand_DT = "1 = 1 ";
            string selectCommand_HDDV = "1 = 1 ";

            //search with primary informations
            if (string.IsNullOrEmpty(textBox_HDFilters_MaHD.Text) == false)
                selectCommand_HD += $"AND MaHD = '{textBox_HDFilters_MaHD.Text}' ";
            if (string.IsNullOrEmpty(textBox_HDFilters_MaNV.Text) == false)
                selectCommand_HD += $"AND MaNV = '{textBox_HDFilters_MaNV.Text}' ";
            if (string.IsNullOrEmpty(textBox_HDFilters_MaBN.Text) == false)
                selectCommand_HD += $"AND MaBN = '{textBox_HDFilters_MaBN.Text}' ";
            string comparerTongTriGia = GetOperation(comboBox_HDFilters_TongTriGiaComparer);
            if (string.IsNullOrEmpty(textBox_HDFilters_TongTriGia.Text) == false)
                selectCommand_HD += $"AND TongTien {comparerTongTriGia} {textBox_HDFilters_TongTriGia.Text} ";

            string date = GetNgayThangNam(textBox_HDFilters_Ngay, comboBox_HDFilters_Thang, textBox_HDFilters_Nam);
            string comparerDate = GetOperation(comboBox_HDFilters_DateComparer);
            if (string.IsNullOrEmpty(date) == false)
                selectCommand_HD += $"AND NgayThanhToan {comparerDate} '{date}' ";

            //Another informations
            //informations in datatableDT
            string comparerSoLuong = GetOperation(comboBox_HDFilters_SLComparer);
            if (string.IsNullOrEmpty(textBox_HDFilters_MaDP.Text) == false)
                selectCommand_DT += $"AND MaDP = '{textBox_HDFilters_MaDP.Text}' ";
            if (string.IsNullOrEmpty(textBox_HDFilters_SoLuong.Text) == false)
                selectCommand_DT += $"AND SoLuong {comparerSoLuong} {textBox_HDFilters_SoLuong.Text} ";

            //informations in datatableHDDV
            if (string.IsNullOrEmpty(textBox_HDFilters_MaDV.Text) == false)
                selectCommand_HDDV += $"AND MaDV = '{textBox_HDFilters_MaDV.Text}' ";

            DataRow[] resultRow_HD = datatableHD.Select(selectCommand_HD);
            DataRow[] resultRow_DT;
            DataRow[] resultRow_HDDV;
            DataTable resultDatatable = datatableHD.Clone();

            if (selectCommand_DT != "1 = 1 ")
            {
                resultRow_DT = datatableDT.Select(selectCommand_DT);
                resultRow_HD = Intersect(resultRow_HD, resultRow_DT, ["MaHD"]).ToArray();
            }
            if (selectCommand_HDDV != "1 = 1 ")
            {
                resultRow_HDDV = datatableHDDV.Select(selectCommand_HDDV);
                resultRow_HD = Intersect(resultRow_HD, resultRow_HDDV, ["MaHD"]).ToArray();
            }

            foreach (DataRow row in resultRow_HD)
            {
                resultDatatable.ImportRow(row);
            }

            UpdateDataGridView(customDataGridView, resultDatatable);
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
            controlDataTable = datatableDT;
            EnablePage(controlPage);
            openFunctionPanel(DT_controlFunc);

            customDataGridView.Focus();
        }
        //Load data
        private void LoadTabDonThuoc()
        {
            LoadDataToDataSet("SELECT * FROM CTHD_DuocPham", "CTHD_DuocPham");
            datatableDT = dataset.Tables["CTHD_DuocPham"];
            datatableDT.PrimaryKey = new DataColumn[] { datatableDT.Columns["MaHD"], datatableDT.Columns["MaDP"] };

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
            DataRow targetRow = datatableDT.Rows.Find(primaryKey);

            if (targetRow == null) // Insert
            {
                targetRow = datatableDT.NewRow();
                targetRow["MaHD"] = primaryKey[0];
                targetRow["MaDP"] = primaryKey[1];
                targetRow["SoLuong"] = textBox_Upload_SoLuong.Text;
                datatableDT.Rows.Add(targetRow);
            }
            else //Update
            {
                targetRow["MaHD"] = primaryKey[0];
                targetRow["MaDP"] = primaryKey[1];
                targetRow["SoLuong"] = textBox_Upload_SoLuong.Text;
            }

            UpdateDataGridView(customDataGridView, datatableDT);
        }
        //Filter method
        private void button_DTFilter_OK_Click(object sender, EventArgs e)
        {
            string selectCommand_DT = "1 = 1 ";

            //search with primary information
            if (string.IsNullOrEmpty(textBox_DTFilters_MaHD.Text) == false)
                selectCommand_DT += $"AND MaHD = '{textBox_DTFilters_MaHD.Text}' ";
            if (string.IsNullOrEmpty(textBox_DTFilters_MaDP.Text) == false)
                selectCommand_DT += $"AND MaDP = '{textBox_DTFilters_MaDP.Text}' ";

            string comparerSoLuong = GetOperation(comboBox_DTFilters_ComparerSoLuong);
            if (string.IsNullOrEmpty(textBox_DTFilters_SoLuong.Text) == false)
                selectCommand_DT += $"AND SoLuong {comparerSoLuong} '{textBox_DTFilters_SoLuong.Text}' ";
            string comparerGiaTien = GetOperation(comboBox_DTFilters_ComparerGiaTien);
            if (string.IsNullOrEmpty(textBox_DTFilters_GiaTien.Text) == false)
                selectCommand_DT += $"AND GiaTien {comparerGiaTien} '{textBox_DTFilters_GiaTien.Text}' ";

            DataRow[] resultRow_DT = datatableDT.Select(selectCommand_DT);
            DataTable resultDatatable = datatableDT.Clone();

            foreach (DataRow row in resultRow_DT)
            {
                resultDatatable.ImportRow(row);
            }

            UpdateDataGridView(customDataGridView, resultDatatable);
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
            controlDataTable = datatableHDDV;
            EnablePage(controlPage);
            openFunctionPanel(HDDV_controlFunc);

            customDataGridView.Focus();
        }
        //Load data
        private void LoadTabHoaDonDichVu()
        {
            LoadDataToDataSet("SELECT * FROM CTHD_DichVu", "CTHD_DichVu");
            datatableHDDV = dataset.Tables["CTHD_DichVu"];
            datatableHDDV.PrimaryKey = new DataColumn[] { datatableHDDV.Columns["MaHD"], datatableHDDV.Columns["MaDV"] };

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
            DataRow targetRow = datatableHDDV.Rows.Find(primaryKey);

            if (targetRow == null) // Insert
            {
                targetRow = datatableHDDV.NewRow();
                targetRow["MaHD"] = primaryKey[0];
                targetRow["MaDV"] = primaryKey[1];
                datatableHDDV.Rows.Add(targetRow);
            }
            else //Update
            {
                targetRow["MaDV"] = primaryKey[1];
            }

            UpdateDataGridView(customDataGridView, datatableHDDV);
        }
        //Filter method
        private void button_HDDVFilter_OK_Click(object sender, EventArgs e)
        {
            string selectCommand_HDDV = "1 = 1 ";

            //search with primary informations
            if (string.IsNullOrEmpty(textBox_HDDVFilters_MaHD.Text) == false)
                selectCommand_HDDV += $"AND MaHD = '{textBox_HDDVFilters_MaHD.Text}' ";
            if (string.IsNullOrEmpty(textBox_HDDVFilters_MaDV.Text) == false)
                selectCommand_HDDV += $"AND MaDV = '{textBox_HDDVFilters_MaDV.Text}' ";
            string comparer = GetOperation(comboBox_HDDVFilters_Comparer);
            if (string.IsNullOrEmpty(textBox_HDDVFilters_ChiPhi.Text) == false)
                selectCommand_HDDV += $"AND GiaTien {comparer} '{textBox_HDDVFilters_ChiPhi.Text}' ";

            DataRow[] resultRow_HDDV = datatableHDDV.Select(selectCommand_HDDV);
            DataTable resultDatatable = datatableHDDV.Clone();

            foreach (DataRow row in resultRow_HDDV)
            {
                resultDatatable.ImportRow(row);
            }

            UpdateDataGridView(customDataGridView, resultDatatable);
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
            DateTime date;

            switch (HD_controlFunc)
            {
                case INS_FUNC:
                    textBox_Upload_MaHD.Text = row["MaHD"].ToString();
                    textBox_Upload_MaBN.Text = row["MaBN"].ToString();
                    textBox_Upload_MaNV.Text = row["MaNV"].ToString();

                    date = row.Field<DateTime>("NgayThanhToan");

                    textBox_Upload_Ngay.Text = date.Day.ToString();
                    comboBox_Upload_Thang.SelectedIndex = date.Month - 1;
                    textBox_Upload_Nam.Text = date.Year.ToString();
                    break;
                case FIL_FUNC:
                    textBox_HDFilters_MaHD.Text = row["MaHD"].ToString();
                    textBox_HDFilters_MaBN.Text = row["MaBN"].ToString();
                    textBox_HDFilters_MaNV.Text = row["MaNV"].ToString();

                    date = row.Field<DateTime>("NgayThanhToan");

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
                    break;
                case FIL_FUNC:
                    textBox_DTFilters_MaHD.Text = row["MaHD"].ToString();
                    textBox_DTFilters_MaDP.Text = row["MaDP"].ToString();
                    textBox_DTFilters_SoLuong.Text = row["SoLuong"].ToString();
                    textBox_DTFilters_GiaTien.Text = row["GiaTien"].ToString();
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
                    break;
                case FIL_FUNC:
                    textBox_HDDVFilters_MaHD.Text = row["MaHD"].ToString();
                    textBox_HDDVFilters_MaDV.Text = row["MaDV"].ToString();
                    textBox_HDDVFilters_ChiPhi.Text = row["GiaTien"].ToString();
                    break;
            }
        }

        private void button_Filter_Reset_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            Panel containingPanel = clickedButton.Parent as Panel;

            foreach (Control control in containingPanel.Controls)
            {
                if (control is TextBox textBox)
                    textBox.Text = "";
                if (control is ComboBox comboBox)
                    comboBox.SelectedIndex = 2;
            }

            if (containingPanel == panel_HDFilters)
                comboBox_HDFilters_Thang.SelectedIndex = 0;
        }

        private void textBox_Upload_Reset_Click(object sender, EventArgs e)
        {
            FillMaHD(textBox_Upload_MaHD);

            switch (controlPage)
            {
                case HD_TAB:
                    textBox_Upload_MaBN.Text = "";
                    textBox_Upload_MaNV.Text = "";
                    FillDate(textBox_Upload_Ngay, comboBox_Upload_Thang, textBox_Upload_Nam);
                    break;
                case DT_TAB:
                    textBox_Upload_MaDP.Text = "";
                    textBox_Upload_SoLuong.Text = "";
                    break;
                case HDDV_TAB:
                    textBox_Upload_MaDV.Text = "";
                    break;
            }
        }
    }
}
