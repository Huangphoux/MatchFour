using QuanLyMachTu.Custom;
using QuanLyMachTu.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Controls;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.AxHost;

namespace QuanLyMachTu
{
    public partial class PhongKhamControl : UserControl
    {
        //Bit errors
        //Upload textBox
        const int MAPK_ERR = 1;
        const int MANV_ERR = 2;
        const int SOGHE_ERR = 4;
        const int TRANGTHAI_ERR = 8;

        //Database fields
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataSet dataset;
        private DataTable datatablePK;
        private DataTable datatablePC;
        //Database connection
        // private string connectionStr = @"Server=LAPTOP-6GL1AF15\STUDENT;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";
        private string connectionStr = @"Server=HOANGPHUC2023;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";

        //Control variables
        //tab index
        const int PK_TAB = 0;
        const int PC_TAB = 10;
        //function index
        const int INS_FUNC = 1;
        const int FIL_FUNC = 2;
        //controllers
        int controlPage;
        DataTable controlDataTable;
        CustomDataGridView controlDataGridView;
        public PhongKhamControl()
        {
            InitializeComponent();
        }
        private void PhongKhamControl_Load(object sender, EventArgs e)
        {
            LoadData();
            InitializeState();
        }
        //General methods
        //Initialize methods
        private void InitializeState()
        {
            controlDataGridView = customDataGridView_PC;
            controlPage = PK_TAB;
            SwitchMode(controlPage);
            panel_Filters.BringToFront();
        }
        //Activate / Deactivate tab
        private void EnablePage(int controlPage)
        {
            switch (controlPage)
            {
                case PK_TAB:
                    ColoringButton.EnabledColor(pageButton_PKTab);
                    break;
                case PC_TAB:
                    ColoringButton.EnabledColor(pageButton_PCTab);
                    break;
            }
        }
        private void DisablePage(int controlPage)
        {
            switch (controlPage)
            {
                case PK_TAB:
                    ColoringButton.DisabledColor(pageButton_PKTab);
                    break;
                case PC_TAB:
                    ColoringButton.DisabledColor(pageButton_PCTab);
                    break;
            }
        }
        //Load methods
        private void LoadData()
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();

            dataset = new DataSet();
            LoadTabPhongKham();
            LoadTabPhanCong();

            connection.Close();

            UpdateDataGridView(customDataGridView_PK, datatablePK);
            UpdateDataGridView(customDataGridView_PC, datatablePC);
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

            //Display statitic number
            //label_HienThiDTTong.Text = CalculateSumOfDoanhSo(dgv).ToString();
            label_HienThiSoBN.Text = dgv.Rows.Count.ToString();
        }
        //Upload button
        private void pageButton_Upload_Click(object sender, EventArgs e)
        {
            panel_Upload.BringToFront();
        }
        private void pageButton_Upload_OK_Click(object sender, EventArgs e)
        {
            switch (controlPage)
            {
                case PK_TAB:
                    button_PKUpload_OK_Click();
                    break;
                case PC_TAB:
                    button_PCUpload_OK_Click();
                    break;
            }
        }
        //Filter button
        private void pageButton_Filters_Click(object sender, EventArgs e)
        {
            panel_Filters.BringToFront();
        }
        private void pageButton_Filters_OK_Click(object sender, EventArgs e)
        {
            switch (controlPage)
            {
                case PK_TAB:
                    button_PKFilter_OK_Click();
                    break;
                case PC_TAB:
                    button_PCFilter_OK_Click();
                    break;
            }
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
            foreach (DataGridViewCell cell in controlDataGridView.SelectedCells)
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

            UpdateDataGridView(controlDataGridView, controlDataTable);
        }
        //Paint
        private void panel_Upload_Paint(object sender, PaintEventArgs e)
        {
            Color activatedColor = Color.FromArgb(193, 193, 193);
            Color deactivatedColor = Color.FromArgb(109, 93, 110);

            Color panel_PK_color = deactivatedColor;
            Color panel_PC_color = deactivatedColor;

            switch (controlPage)
            {
                case PK_TAB:
                    panel_PK_color = activatedColor;
                    panel_PKUpload_Highlight(sender, e);
                    break;
                case PC_TAB:
                    panel_PC_color = activatedColor;
                    panel_PCUpload_Highlight(sender, e);
                    break;
            }

            e.Graphics.DrawLine(new Pen(activatedColor), new Point(20, 165), new Point(182, 165)); //MaPK line
            panel_PKUpload_Paint(sender, e, panel_PK_color);
            panel_PCUpload_Paint(sender, e, panel_PC_color);
        }
        private void RepaintPanel(Panel panel)
        {
            panel.Invalidate();
        }
        private void panel_Filter_Paint(object sender, PaintEventArgs e)
        {
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            int startX = 20, endX = 395;
            graphic.DrawLine(linePen, new Point(startX, 165), new Point(endX, 165)); //MaPK line
            graphic.DrawLine(linePen, new Point(startX, 264), new Point(115, 264)); //SoGhe line
            graphic.DrawLine(linePen, new Point(startX, 363), new Point(endX, 363)); //MaNV line
            graphic.DrawLine(linePen, new Point(25, 462), new Point(65, 462)); //TGBD Gio line
            graphic.DrawLine(linePen, new Point(81, 462), new Point(121, 462)); //TGBD Phut line
            graphic.DrawLine(linePen, new Point(137, 462), new Point(177, 462)); //TGBD Giay line
            graphic.DrawLine(linePen, new Point(230, 462), new Point(270, 462)); //TGKT Gio line
            graphic.DrawLine(linePen, new Point(286, 462), new Point(326, 462)); //TGKT Phut line
            graphic.DrawLine(linePen, new Point(342, 462), new Point(382, 462)); //TGKT Giay line
        }
        //Additions
        private string GetTrangThai(ComboBox trangThai)
        {
            return (string)trangThai.SelectedItem;
        }
        private TimeSpan GetTime(TextBox textBox_Gio, TextBox textBox_Phut, TextBox textBox_Giay)
        {
            int hour = int.Parse(textBox_Gio.Text);
            int minute = int.Parse(textBox_Phut.Text);
            int second = int.Parse(textBox_Giay.Text);
            return new TimeSpan(hour, minute, second);
        }
        private void textBox_KeyPress_PositiveNumber(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                ColoringTextBox.NormalColor((TextBox)sender);
            }
            else
                e.Handled = true;
        }
        private void textBox_KeyPress_Normal(object sender, KeyPressEventArgs e)
        {
            ColoringTextBox.NormalColor((TextBox)sender);
        }
        private void WarningComboBox(ComboBox cb)
        {
            cb.BackColor = Color.FromArgb(255, 140, 158);
        }
        private void SwitchMode(int controlPage)
        {
            EnablePage(controlPage);

            switch (controlPage)
            {
                case PK_TAB:
                    //DataGridView
                    ColoringDataGridView.DeactivateDGV(controlDataGridView);
                    controlDataTable = datatablePK;
                    controlDataGridView = customDataGridView_PK;
                    ColoringDataGridView.ActivateDGV(controlDataGridView);
                    //Upload
                    EnableUploadComponents_PK();
                    DisableUploadComponents_PC();
                    break;
                case PC_TAB:
                    //DataGridView
                    ColoringDataGridView.DeactivateDGV(controlDataGridView);
                    controlDataTable = datatablePC;
                    controlDataGridView = customDataGridView_PC;
                    ColoringDataGridView.ActivateDGV(controlDataGridView);
                    //Upload
                    EnableUploadComponents_PC();
                    DisableUploadComponents_PK();
                    break;
            }

            RepaintPanel(panel_Upload);
        }

        //---------------------------------------------------------------Phong Kham tab---------------------------------------------------------------        
        //Activate tab
        private void PK_Tab_Activated(object sender, EventArgs e)
        {
            if (controlPage == PK_TAB)
                return;

            DisablePage(controlPage);
            controlPage = PK_TAB;
            SwitchMode(controlPage);
        }
        //Load data
        private void LoadTabPhongKham()
        {
            LoadDataToDataSet("SELECT * FROM PHONGKHAM", "PHONGKHAM");
            datatablePK = dataset.Tables["PHONGKHAM"];
            datatablePK.PrimaryKey = new DataColumn[] { datatablePK.Columns["MaPK"] };

            comboBox_Upload_TrangThai.SelectedItem = comboBox_Upload_TrangThai.Items[0];
        }
        //Check and prevent errors
        private int CheckUploadError_PK()
        {
            int error = 0;
            if (string.IsNullOrEmpty(textBox_Upload_MaPK.Text))
                error |= MAPK_ERR;
            if (string.IsNullOrEmpty(textBox_Upload_SoGhe.Text))
                error |= SOGHE_ERR;
            if (string.IsNullOrEmpty(GetTrangThai(comboBox_Upload_TrangThai)))
                error |= TRANGTHAI_ERR;

            return error;
        }
        private void WarningUploadError_PK(int error)
        {
            if ((error & MAPK_ERR) == MAPK_ERR)
                ColoringTextBox.WarningColor(textBox_Upload_MaPK);
            if ((error & SOGHE_ERR) == SOGHE_ERR)
                ColoringTextBox.WarningColor(textBox_Upload_SoGhe);
            if ((error & TRANGTHAI_ERR) == TRANGTHAI_ERR)
                WarningComboBox(comboBox_Upload_TrangThai);

        }
        //Upload method
        //Enable / Disable components
        private void EnableUploadComponents_PK()
        {
            textBox_Upload_SoGhe.Enabled = true;
            comboBox_Upload_TrangThai.Enabled = true;
        }
        private void DisableUploadComponents_PK()
        {
            textBox_Upload_SoGhe.Enabled = false;
            comboBox_Upload_TrangThai.Enabled = false;
        }
        private void button_PKUpload_OK_Click()
        {
            int error = CheckUploadError_PK();
            if (error != 0)
            {
                WarningUploadError_PK(error);
                return;
            }

            string primaryKey = textBox_Upload_MaPK.Text;
            DataRow targetRow = datatablePK.Rows.Find(primaryKey);

            if (targetRow == null) // Insert
            {
                targetRow = datatablePK.NewRow();
                targetRow["MaPK"] = primaryKey;
                targetRow["SoGhe"] = textBox_Upload_SoGhe.Text;
                targetRow["TrangThai"] = GetTrangThai(comboBox_Upload_TrangThai);
                datatablePK.Rows.Add(targetRow);
            }
            else //Update
            {
                targetRow["MaPK"] = primaryKey;
                targetRow["SoGhe"] = textBox_Upload_SoGhe.Text;
                targetRow["TrangThai"] = GetTrangThai(comboBox_Upload_TrangThai);
            }

            UpdateDataGridView(customDataGridView_PK, datatablePK);
        }
        //Filter method
        private void button_PKFilter_OK_Click()
        {
            string selectCommandPK = "1 = 1 ";
            string selectCommandPC = "1 = 1 ";

            //Search for Phong Kham with its information            
            if (string.IsNullOrEmpty(textBox_Filters_MaPK.Text) == false)
                selectCommandPK += $"AND MaPK = '{textBox_Filters_MaPK.Text}' ";
            if (string.IsNullOrEmpty(textBox_Filters_SoGhe.Text) == false)
                selectCommandPK += $"AND SoGhe = '{textBox_Filters_SoGhe.Text}' ";
            string trangThai = GetTrangThai(comboBox_Filter_TrangThai);
            if (string.IsNullOrEmpty(trangThai) == false)
                selectCommandPK += $"AND TrangThai = '{trangThai}' ";

            //Search for Phong Kham with additional information
            if (string.IsNullOrEmpty(textBox_Filters_MaNV.Text) == false)
                selectCommandPC += $"AND MaNV = '{textBox_Filters_MaNV.Text}' ";


            DataRow[] resultRowPK = datatablePK.Select(selectCommandPK);
            DataRow[] resultRowPC = datatablePC.Select(selectCommandPC);
            DataTable resultDatatable = datatablePK.Clone();

            //Search with time
            TimeSpan thoiGianBD = GetTime(textBox_Filters_TGBDGio, textBox_Filters_TGBDPhut, textBox_Filters_TGBDGiay);
            TimeSpan thoiGianKT = GetTime(textBox_Filters_TGKTGio, textBox_Filters_TGKTPhut, textBox_Filters_TGKTGiay);
            resultRowPC = resultRowPC.AsEnumerable()
            .Where(row =>
                row.Field<TimeSpan>("ThoiGianBD") >= thoiGianBD &&
                row.Field<TimeSpan>("ThoiGianKT") <= thoiGianKT)
            .ToArray();

            if (resultRowPC.Length != datatablePC.Rows.Count) //if filter does some changes in datatablePC to filter datatablePK, do join
            {
                foreach (DataRow row in resultRowPK)
                {
                    foreach (DataRow joinedRow in resultRowPC)
                    {
                        if (row["MaPK"].ToString() == joinedRow["MaPK"].ToString())
                        {
                            resultDatatable.ImportRow(row);
                            break;
                        }
                    }
                }
            }
            else //if no changes, no join
            {
                foreach (DataRow row in resultRowPK)
                {
                    resultDatatable.ImportRow(row);
                }
            }

            UpdateDataGridView(customDataGridView_PK, resultDatatable);
        }
        //Decorate panel
        private void panel_PKUpload_Paint(object sender, PaintEventArgs e, Color lineColor)
        {
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            int startX = 20, endX = 395;
            graphic.DrawLine(linePen, new Point(225, 264), new Point(345, 264)); //SoGhe line
        }
        private void panel_PKUpload_Highlight(object sender, PaintEventArgs e)
        {
            Color frameColor = Color.FromArgb(38, 187, 255);

            Graphics graphic = e.Graphics;
            Pen framePen = new Pen(frameColor, 4);

            int heihgt_distance = 46;
            int width_distance = 10;
            int startY = 78;

            Point[] frameShape = new Point[]
            {
                new Point(20 - width_distance, startY),
                new Point(397 + width_distance, startY),
                new Point(397 + width_distance, 227 + heihgt_distance),
                new Point(225 - width_distance, 227 + heihgt_distance),
                new Point(225 - width_distance, 128 + heihgt_distance),
                new Point(20 - width_distance, 128 + heihgt_distance),
                new Point(20 - width_distance, startY)
            };

            graphic.DrawPolygon(framePen, frameShape);
        }

        //---------------------------------------------------------------Phan Cong tab---------------------------------------------------------------        
        //Activate tab
        private void PC_Tab_Activated(object sender, EventArgs e)
        {
            if (controlPage == PC_TAB)
                return;

            DisablePage(controlPage);
            controlPage = PC_TAB;
            SwitchMode(controlPage);
        }
        //Load data
        private void LoadTabPhanCong()
        {
            LoadDataToDataSet("SELECT * FROM LAMVIEC", "LAMVIEC");
            datatablePC = dataset.Tables["LAMVIEC"];
            datatablePC.PrimaryKey = new DataColumn[] { datatablePC.Columns["MaNV"], datatablePC.Columns["MaPK"] };

            textBox_Upload_TGBDGio.Text = "00";
            textBox_Upload_TGBDPhut.Text = "00";
            textBox_Upload_TGBDGiay.Text = "00";
            textBox_Upload_TGKTGio.Text = "23";
            textBox_Upload_TGKTPhut.Text = "59";
            textBox_Upload_TGKTGiay.Text = "59";

            textBox_Filters_TGBDGio.Text = "00";
            textBox_Filters_TGBDPhut.Text = "00";
            textBox_Filters_TGBDGiay.Text = "00";
            textBox_Filters_TGKTGio.Text = "23";
            textBox_Filters_TGKTPhut.Text = "59";
            textBox_Filters_TGKTGiay.Text = "59";
        }
        //Check and prevent errors
        private int CheckUploadError_PC()
        {
            int error = 0;
            if (string.IsNullOrEmpty(textBox_Upload_MaPK.Text))
                error |= MAPK_ERR;
            if (string.IsNullOrEmpty(textBox_Upload_MaNV.Text))
                error |= MANV_ERR;

            return error;
        }
        private void WarningUploadError_PC(int error)
        {
            if ((error & MAPK_ERR) == MAPK_ERR)
                ColoringTextBox.WarningColor(textBox_Upload_MaPK);
            if ((error & MANV_ERR) == MANV_ERR)
                ColoringTextBox.WarningColor(textBox_Upload_MaNV);
        }
        //Upload method
        //Enable / Disable components
        private void EnableUploadComponents_PC()
        {
            textBox_Upload_MaNV.Enabled = true;

            textBox_Upload_TGBDGio.Enabled = true;
            textBox_Upload_TGBDPhut.Enabled = true;
            textBox_Upload_TGBDGiay.Enabled = true;
            textBox_Upload_TGKTGio.Enabled = true;
            textBox_Upload_TGKTPhut.Enabled = true;
            textBox_Upload_TGKTGiay.Enabled = true;
        }
        private void DisableUploadComponents_PC()
        {
            textBox_Upload_MaNV.Enabled = false;

            textBox_Upload_TGBDGio.Enabled = false;
            textBox_Upload_TGBDPhut.Enabled = false;
            textBox_Upload_TGBDGiay.Enabled = false;
            textBox_Upload_TGKTGio.Enabled = false;
            textBox_Upload_TGKTPhut.Enabled = false;
            textBox_Upload_TGKTGiay.Enabled = false;
        }
        private void button_PCUpload_OK_Click()
        {
            int error = CheckUploadError_PC();
            if (error != 0)
            {
                WarningUploadError_PC(error);
                return;
            }

            string[] primaryKey = new string[2]
            {
                textBox_Upload_MaNV.Text,
                textBox_Upload_MaPK.Text
            };

            DataRow targetRow = datatablePC.Rows.Find(primaryKey);

            if (targetRow == null) // Insert
            {
                targetRow = datatablePC.NewRow();
                targetRow["MaNV"] = primaryKey[0];
                targetRow["MaPK"] = primaryKey[1];
                targetRow["ThoiGianBD"] = GetTime(textBox_Upload_TGBDGio, textBox_Upload_TGBDPhut, textBox_Upload_TGBDGiay);
                targetRow["ThoiGianKT"] = GetTime(textBox_Upload_TGKTGio, textBox_Upload_TGKTPhut, textBox_Upload_TGKTGiay);
                datatablePC.Rows.Add(targetRow);
            }
            else //Update
            {
                targetRow["MaNV"] = primaryKey[0];
                targetRow["MaPK"] = primaryKey[1];
                targetRow["ThoiGianBD"] = GetTime(textBox_Upload_TGBDGio, textBox_Upload_TGBDPhut, textBox_Upload_TGBDGiay);
                targetRow["ThoiGianKT"] = GetTime(textBox_Upload_TGKTGio, textBox_Upload_TGKTPhut, textBox_Upload_TGKTGiay);
            }

            UpdateDataGridView(customDataGridView_PC, datatablePC);
        }
        //Filter method
        private void button_PCFilter_OK_Click()
        {
            string selectCommandPK = "1 = 1 ";
            string selectCommandPC = "1 = 1 ";

            //Search for Phan Cong with its information
            if (string.IsNullOrEmpty(textBox_Filters_MaPK.Text) == false)
                selectCommandPC += $"AND MaPK = '{textBox_Filters_MaPK.Text}' ";
            if (string.IsNullOrEmpty(textBox_Filters_MaNV.Text) == false)
                selectCommandPC += $"AND MaNV = '{textBox_Filters_MaNV.Text}' ";

            //Search for Phan Cong with addition information            
            if (string.IsNullOrEmpty(textBox_Filters_SoGhe.Text) == false)
                selectCommandPK += $"AND SoGhe = '{textBox_Filters_SoGhe.Text}' ";
            string trangThai = GetTrangThai(comboBox_Filter_TrangThai);
            if (string.IsNullOrEmpty(trangThai) == false)
                selectCommandPK += $"AND TrangThai = '{trangThai}' ";

            DataRow[] resultRowPK = datatablePK.Select(selectCommandPK);
            DataRow[] resultRowPC = datatablePC.Select(selectCommandPC);
            DataTable resultDatatable = datatablePC.Clone();

            //Search with time
            TimeSpan thoiGianBD = GetTime(textBox_Filters_TGBDGio, textBox_Filters_TGBDPhut, textBox_Filters_TGBDGiay);
            TimeSpan thoiGianKT = GetTime(textBox_Filters_TGKTGio, textBox_Filters_TGKTPhut, textBox_Filters_TGKTGiay);
            resultRowPC = resultRowPC.AsEnumerable()
            .Where(row =>
                row.Field<TimeSpan>("ThoiGianBD") >= thoiGianBD &&
                row.Field<TimeSpan>("ThoiGianKT") <= thoiGianKT)
            .ToArray();

            if (resultRowPK.Length != datatablePK.Rows.Count)
            {
                foreach (DataRow row in resultRowPC)
                {
                    foreach (DataRow joinedRow in resultRowPK)
                    {
                        if (row["MaPK"].ToString() == joinedRow["MaPK"].ToString())
                        {
                            resultDatatable.ImportRow(row);
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (DataRow row in resultRowPC)
                {
                    resultDatatable.ImportRow(row);
                }
            }

            UpdateDataGridView(customDataGridView_PC, resultDatatable);
        }
        //Decorate panel
        private void panel_PCUpload_Paint(object sender, PaintEventArgs e, Color lineColor)
        {
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            int startX = 20, endX = 395;
            graphic.DrawLine(linePen, new Point(startX, 264), new Point(182, 264)); //MaNV line            
            graphic.DrawLine(linePen, new Point(25, 363), new Point(65, 363)); //TGBD Gio line
            graphic.DrawLine(linePen, new Point(81, 363), new Point(121, 363)); //TGBD Phut line
            graphic.DrawLine(linePen, new Point(137, 363), new Point(177, 363)); //TGBD Giay line
            graphic.DrawLine(linePen, new Point(230, 363), new Point(270, 363)); //TGKT Gio line
            graphic.DrawLine(linePen, new Point(286, 363), new Point(326, 363)); //TGKT Phut line
            graphic.DrawLine(linePen, new Point(342, 363), new Point(382, 363)); //TGKT Giay line
        }
        private void panel_PCUpload_Highlight(object sender, PaintEventArgs e)
        {
            Color frameColor = Color.FromArgb(38, 187, 255);

            Graphics graphic = e.Graphics;
            Pen framePen = new Pen(frameColor, 4);

            int heihgt_distance = 46;
            int width_distance = 10;
            int startY = 78;

            Point[] frameShape = new Point[]
            {
                new Point(20 - width_distance, startY),
                new Point(182 + width_distance, startY),
                new Point(182 + width_distance, 227 + heihgt_distance),
                new Point(398 + width_distance, 227 + heihgt_distance),
                new Point(398 + width_distance, 326 + heihgt_distance),
                new Point(20 - width_distance, 326 + heihgt_distance),
                new Point(20 - width_distance, startY)
            };

            graphic.DrawPolygon(framePen, frameShape);
        }

        private void textBox_NoHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int caretPos = textBox.SelectionStart;
            int convertedNumber;

            if (Char.IsControl(e.KeyChar))
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Back:
                        textBox.Text = textBox.Text.Remove(Math.Max(0, caretPos - 1), 1);
                        break;
                    default:
                        return;
                }

                if (int.TryParse(textBox.Text, out convertedNumber) == false)
                    convertedNumber = 0;

                convertedNumber = Math.Min(convertedNumber, 59);
                textBox.Text = convertedNumber.ToString("D2");
                textBox.SelectionStart = caretPos;

                e.Handled = true;
            }
            else if (Char.IsDigit(e.KeyChar))
            {
                string number = textBox.Text + e.KeyChar;
                convertedNumber = int.Parse(number);

                convertedNumber = Math.Min(convertedNumber, 59);
                textBox.Text = convertedNumber.ToString("D2");
                textBox.SelectionStart = caretPos;

                e.Handled = true;
            }
            else
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox_Hour_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int caretPos = textBox.SelectionStart;
            int convertedNumber;

            if (Char.IsControl(e.KeyChar))
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Back:
                        textBox.Text = textBox.Text.Remove(Math.Max(0, caretPos - 1), 1);
                        break;
                    default:
                        return;
                }

                if (int.TryParse(textBox.Text, out convertedNumber) == false)
                    convertedNumber = 0;

                convertedNumber = Math.Min(convertedNumber, 23);
                textBox.Text = convertedNumber.ToString("D2");
                textBox.SelectionStart = caretPos;

                e.Handled = true;
            }
            else if (Char.IsDigit(e.KeyChar))
            {
                string number = textBox.Text + e.KeyChar;
                convertedNumber = int.Parse(number);

                convertedNumber = Math.Min(convertedNumber, 23);
                textBox.Text = convertedNumber.ToString("D2");
                textBox.SelectionStart = caretPos;

                e.Handled = true;
            }
            else
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox_EnabledChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.BackColor = Color.FromArgb(57, 54, 70);
        }
    }
}
