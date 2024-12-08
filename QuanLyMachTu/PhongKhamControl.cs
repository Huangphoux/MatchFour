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
using System.Web;

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
        private string connectionStr = @"Server=LAPTOP-6GL1AF15\STUDENT;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";

        //Control variables
        //tab index
        const int PK_TAB = 0;
        const int PC_TAB = 10;
        //function index
        const int INS_FUNC = 1;
        const int FIL_FUNC = 2;
        //controllers
        int controlPage;
        int controlFunc;
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
            InitializeState_PK();
            InitializeState_PC();

            controlDataGridView = customDataGridView_PK;
            controlPage = PK_TAB;
            controlFunc = FIL_FUNC;
            SwitchMode(controlPage);
            EnablePage(controlPage);
            panel_Filters.BringToFront();
        }
        //Activate / Deactivate tab
        private void EnablePage(int controlPage)
        {
            switch (controlPage)
            {
                case PK_TAB:
                    ColoringButton.EnabledColor(pageButton_PKTab);
                    ColoringDataGridView.ActivateDGV(controlDataGridView);
                    EnableUploadComponents_PK();
                    break;
                case PC_TAB:
                    ColoringButton.EnabledColor(pageButton_PCTab);
                    ColoringDataGridView.ActivateDGV(controlDataGridView);
                    EnableUploadComponents_PC();
                    break;
            }
        }
        private void DisablePage(int controlPage)
        {
            switch (controlPage)
            {
                case PK_TAB:
                    ColoringButton.DisabledColor(pageButton_PKTab);
                    ColoringDataGridView.DeactivateDGV(controlDataGridView);
                    DisableUploadComponents_PK();
                    break;
                case PC_TAB:
                    ColoringButton.DisabledColor(pageButton_PCTab);
                    ColoringDataGridView.DeactivateDGV(controlDataGridView);
                    DisableUploadComponents_PC();
                    break;
            }
        }
        private void SwitchMode(int controlPage)
        {
            switch (controlPage)
            {
                case PK_TAB:
                    controlDataTable = datatablePK;
                    controlDataGridView = customDataGridView_PK;
                    break;
                case PC_TAB:
                    controlDataTable = datatablePC;
                    controlDataGridView = customDataGridView_PC;
                    break;
            }

            RepaintPanel(panel_Upload);
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
            controlFunc = INS_FUNC;
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
            controlFunc = FIL_FUNC;
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

            //Unchanged
            Color SpecialColor = Color.FromArgb(38, 187, 255);

            Graphics graphic = e.Graphics;
            Pen unchangePen = new Pen(SpecialColor, 2);
            int startX = 20, offset = 5;
            graphic.DrawLine(unchangePen, new Point(startX, textBox_Upload_MaPK.Location.Y + textBox_Upload_MaPK.Height + offset),
                                          new Point(textBox_Upload_MaPK.Location.X + textBox_Upload_MaPK.Width + offset, textBox_Upload_MaPK.Location.Y + textBox_Upload_MaPK.Height + offset)); //MaPK line

            switch (controlPage)
            {
                case PK_TAB:
                    panel_PK_color = activatedColor;                    
                    break;
                case PC_TAB:
                    panel_PC_color = activatedColor;
                    break;
            }

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
            int startX = 20, endX = 395, offset = 5;
            graphic.DrawLine(linePen, new Point(startX, textBox_Filters_MaPK.Location.Y + textBox_Filters_MaPK.Height + offset),
                                      new Point(textBox_Filters_MaPK.Location.X + textBox_Filters_MaPK.Width + offset, textBox_Filters_MaPK.Location.Y + textBox_Filters_MaPK.Height + offset)); //MaPK line
            graphic.DrawLine(linePen, new Point(textBox_Filters_SoGhe.Location.X - offset, textBox_Filters_SoGhe.Location.Y + textBox_Filters_SoGhe.Height + offset),
                                      new Point(textBox_Filters_SoGhe.Location.X + textBox_Filters_SoGhe.Width + offset, textBox_Filters_SoGhe.Location.Y + textBox_Filters_SoGhe.Height + offset)); //SoGhe line            

            graphic.DrawLine(linePen, new Point(startX, textBox_Filters_MaNV.Location.Y + textBox_Filters_MaNV.Height + offset),
                                      new Point(textBox_Filters_MaNV.Location.X + textBox_Filters_MaNV.Width + offset, textBox_Filters_MaNV.Location.Y + textBox_Filters_MaNV.Height + offset)); //MaNV line

            graphic.DrawLine(linePen, new Point(startX, textBox_Filters_TGBDGio.Location.Y + textBox_Filters_TGBDGio.Height + offset),
                                      new Point(textBox_Filters_TGBDGio.Location.X + textBox_Filters_TGBDGio.Width + offset, textBox_Filters_TGBDGio.Location.Y + textBox_Filters_TGBDGio.Height + offset)); //TGBD Gio line       
            graphic.DrawLine(linePen, new Point(textBox_Filters_TGBDPhut.Location.X - offset, textBox_Filters_TGBDPhut.Location.Y + textBox_Filters_TGBDPhut.Height + offset),
                                      new Point(textBox_Filters_TGBDPhut.Location.X + textBox_Filters_TGBDPhut.Width + offset, textBox_Filters_TGBDPhut.Location.Y + textBox_Filters_TGBDPhut.Height + offset)); //TGBD Phut line
            graphic.DrawLine(linePen, new Point(textBox_Filters_TGBDGiay.Location.X - offset, textBox_Filters_TGBDGiay.Location.Y + textBox_Filters_TGBDGiay.Height + offset),
                                      new Point(textBox_Filters_TGBDGiay.Location.X + textBox_Filters_TGBDGiay.Width + offset, textBox_Filters_TGBDGiay.Location.Y + textBox_Filters_TGBDGiay.Height + offset)); //TGBD Giay line

            graphic.DrawLine(linePen, new Point(textBox_Filters_TGKTGio.Location.X - offset, textBox_Filters_TGKTGio.Location.Y + textBox_Filters_TGKTGio.Height + offset),
                                      new Point(textBox_Filters_TGKTGio.Location.X + textBox_Filters_TGKTGio.Width + offset, textBox_Filters_TGKTGio.Location.Y + textBox_Filters_TGKTGio.Height + offset)); //TGKT Gio line       
            graphic.DrawLine(linePen, new Point(textBox_Filters_TGKTPhut.Location.X - offset, textBox_Filters_TGKTPhut.Location.Y + textBox_Filters_TGKTPhut.Height + offset),
                                      new Point(textBox_Filters_TGKTPhut.Location.X + textBox_Filters_TGKTPhut.Width + offset, textBox_Filters_TGKTPhut.Location.Y + textBox_Filters_TGKTPhut.Height + offset)); //TGKT Phut line
            graphic.DrawLine(linePen, new Point(textBox_Filters_TGKTGiay.Location.X - offset, textBox_Filters_TGKTGiay.Location.Y + textBox_Filters_TGKTGiay.Height + offset),
                                      new Point(textBox_Filters_TGKTGiay.Location.X + textBox_Filters_TGKTGiay.Width + offset, textBox_Filters_TGKTGiay.Location.Y + textBox_Filters_TGKTGiay.Height + offset)); //TGKT Giay line
        }
        //Additions        
        private void WarningComboBox(ComboBox cb)
        {
            cb.BackColor = Color.FromArgb(255, 140, 158);
        }
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

        //---------------------------------------------------------------Phong Kham tab---------------------------------------------------------------        
        //Activate tab
        private void PK_Tab_Activated(object sender, EventArgs e)
        {
            if (controlPage == PK_TAB)
                return;

            DisablePage(controlPage);
            controlPage = PK_TAB;
            SwitchMode(controlPage);
            EnablePage(controlPage);
        }
        //Initial State
        private void InitializeState_PK()
        {
            //Components
            comboBox_Upload_TrangThai.SelectedItem = comboBox_Upload_TrangThai.Items[0];

            //Page status
            controlDataGridView = customDataGridView_PK;
            DisablePage(PK_TAB);
        }
        //Load data
        private void LoadTabPhongKham()
        {
            LoadDataToDataSet("SELECT * FROM PHONGKHAM", "PHONGKHAM");
            datatablePK = dataset.Tables["PHONGKHAM"];
            datatablePK.PrimaryKey = new DataColumn[] { datatablePK.Columns["MaPK"] };

            UpdateDataGridView(customDataGridView_PK, datatablePK);
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
            string trangThai = GetTrangThai(comboBox_Filters_TrangThai);
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
            Pen sectionPen = new Pen(lineColor, 2);
            int startX = 20, endX = 395, offset = 5;
            graphic.DrawLine(sectionPen, new Point(startX - 3 * offset, label_Upload_PhongKham.Location.Y + label_Upload_PhongKham.Height / 2 + offset),
                                         new Point(label_Upload_PhongKham.Location.X, label_Upload_PhongKham.Location.Y + label_Upload_PhongKham.Height / 2 + offset)); //label_Upload_PhongKham line
            graphic.DrawLine(sectionPen, new Point(label_Upload_PhongKham.Location.X + label_Upload_PhongKham.Width, label_Upload_PhongKham.Location.Y + label_Upload_PhongKham.Height / 2 + offset),
                                         new Point(endX + offset, label_Upload_PhongKham.Location.Y + label_Upload_PhongKham.Height / 2 + offset)); //label_Upload_PhongKham line

            graphic.DrawLine(linePen, new Point(textBox_Upload_SoGhe.Location.X - offset, textBox_Upload_SoGhe.Location.Y + textBox_Upload_SoGhe.Height + offset),
                                      new Point(textBox_Upload_SoGhe.Location.X + textBox_Upload_SoGhe.Width + offset, textBox_Upload_SoGhe.Location.Y + textBox_Upload_SoGhe.Height + offset)); //SoGhe line
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
            EnablePage(controlPage);
        }
        //Initial state
        private void InitializeState_PC()
        {
            //Components
            //Upload
            textBox_Upload_TGBDGio.Text = "00";
            textBox_Upload_TGBDPhut.Text = "00";
            textBox_Upload_TGBDGiay.Text = "00";
            textBox_Upload_TGKTGio.Text = "23";
            textBox_Upload_TGKTPhut.Text = "59";
            textBox_Upload_TGKTGiay.Text = "59";
            //Filters
            textBox_Filters_TGBDGio.Text = "00";
            textBox_Filters_TGBDPhut.Text = "00";
            textBox_Filters_TGBDGiay.Text = "00";
            textBox_Filters_TGKTGio.Text = "23";
            textBox_Filters_TGKTPhut.Text = "59";
            textBox_Filters_TGKTGiay.Text = "59";

            //Page status
            controlDataGridView = customDataGridView_PC;
            DisablePage(PC_TAB);
        }
        //Load data
        private void LoadTabPhanCong()
        {
            LoadDataToDataSet("SELECT * FROM LAMVIEC", "LAMVIEC");
            datatablePC = dataset.Tables["LAMVIEC"];
            datatablePC.PrimaryKey = new DataColumn[] { datatablePC.Columns["MaNV"], datatablePC.Columns["MaPK"] };

            UpdateDataGridView(customDataGridView_PC, datatablePC);
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
            string trangThai = GetTrangThai(comboBox_Filters_TrangThai);
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
            Pen sectionPen = new Pen(lineColor, 2);
            int startX = 20, endX = 395, offset = 5;
            graphic.DrawLine(sectionPen, new Point(startX - 3 * offset, label_Upload_PhanCong.Location.Y + label_Upload_PhanCong.Height / 2 + offset),
                                         new Point(label_Upload_PhanCong.Location.X, label_Upload_PhanCong.Location.Y + label_Upload_PhanCong.Height / 2 + offset)); //label_Upload_PhanCong line
            graphic.DrawLine(sectionPen, new Point(label_Upload_PhanCong.Location.X + label_Upload_PhanCong.Width, label_Upload_PhanCong.Location.Y + label_Upload_PhanCong.Height / 2 + offset),
                                         new Point(endX + offset, label_Upload_PhanCong.Location.Y + label_Upload_PhanCong.Height / 2 + offset)); //label_Upload_PhanCong line

            graphic.DrawLine(linePen, new Point(startX, textBox_Upload_MaNV.Location.Y + textBox_Upload_MaNV.Height + offset),
                                      new Point(textBox_Upload_MaNV.Location.X + textBox_Upload_MaNV.Width + offset, textBox_Upload_MaNV.Location.Y + textBox_Upload_MaNV.Height + offset)); //MaNV line

            graphic.DrawLine(linePen, new Point(startX, textBox_Upload_TGBDGio.Location.Y + textBox_Upload_TGBDGio.Height + offset),
                                      new Point(textBox_Upload_TGBDGio.Location.X + textBox_Upload_TGBDGio.Width + offset, textBox_Upload_TGBDGio.Location.Y + textBox_Upload_TGBDGio.Height + offset)); //TGBD Gio line       
            graphic.DrawLine(linePen, new Point(textBox_Upload_TGBDPhut.Location.X - offset, textBox_Upload_TGBDPhut.Location.Y + textBox_Upload_TGBDPhut.Height + offset), 
                                      new Point(textBox_Upload_TGBDPhut.Location.X + textBox_Upload_TGBDPhut.Width + offset, textBox_Upload_TGBDPhut.Location.Y + textBox_Upload_TGBDPhut.Height + offset)); //TGBD Phut line
            graphic.DrawLine(linePen, new Point(textBox_Upload_TGBDGiay.Location.X - offset, textBox_Upload_TGBDGiay.Location.Y + textBox_Upload_TGBDGiay.Height + offset),
                                      new Point(textBox_Upload_TGBDGiay.Location.X + textBox_Upload_TGBDGiay.Width + offset, textBox_Upload_TGBDGiay.Location.Y + textBox_Upload_TGBDGiay.Height + offset)); //TGBD Giay line

            graphic.DrawLine(linePen, new Point(textBox_Upload_TGKTGio.Location.X - offset, textBox_Upload_TGKTGio.Location.Y + textBox_Upload_TGKTGio.Height + offset),
                                      new Point(textBox_Upload_TGKTGio.Location.X + textBox_Upload_TGKTGio.Width + offset, textBox_Upload_TGKTGio.Location.Y + textBox_Upload_TGKTGio.Height + offset)); //TGKT Gio line       
            graphic.DrawLine(linePen, new Point(textBox_Upload_TGKTPhut.Location.X - offset, textBox_Upload_TGKTPhut.Location.Y + textBox_Upload_TGKTPhut.Height + offset),
                                      new Point(textBox_Upload_TGKTPhut.Location.X + textBox_Upload_TGKTPhut.Width + offset, textBox_Upload_TGKTPhut.Location.Y + textBox_Upload_TGKTPhut.Height + offset)); //TGKT Phut line
            graphic.DrawLine(linePen, new Point(textBox_Upload_TGKTGiay.Location.X - offset, textBox_Upload_TGKTGiay.Location.Y + textBox_Upload_TGKTGiay.Height + offset),
                                      new Point(textBox_Upload_TGKTGiay.Location.X + textBox_Upload_TGKTGiay.Width + offset, textBox_Upload_TGKTGiay.Location.Y + textBox_Upload_TGKTGiay.Height + offset)); //TGKT Giay line
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
                case PK_TAB:
                    fillPanel_PK(row);
                    break;
                case PC_TAB:
                    fillPanel_PC(row);
                    break;
            }
        }

        private void fillPanel_PC(DataRow row)
        {
            TimeSpan startTime, finishTime;

            string primaryKey = row["MaPK"].ToString();
            DataRow row_PK = datatablePK.Rows.Find(primaryKey);

            switch (controlFunc)
            {
                case INS_FUNC:                    
                    textBox_Upload_MaPK.Text = row["MaPK"].ToString();
                    comboBox_Upload_TrangThai.Text = row_PK["TrangThai"].ToString();
                    textBox_Upload_SoGhe.Text = row_PK["SoGhe"].ToString();

                    textBox_Upload_MaNV.Text = row["MaNV"].ToString();

                    startTime = row.Field<TimeSpan>("ThoiGianBD");
                    finishTime = row.Field<TimeSpan>("ThoiGianKT");

                    textBox_Upload_TGBDGio.Text = startTime.Hours.ToString("D2");
                    textBox_Upload_TGBDPhut.Text = startTime.Minutes.ToString("D2");
                    textBox_Upload_TGBDGiay.Text = startTime.Seconds.ToString("D2");

                    textBox_Upload_TGKTGio.Text = finishTime.Hours.ToString("D2");
                    textBox_Upload_TGKTPhut.Text = finishTime.Minutes.ToString("D2");
                    textBox_Upload_TGKTGiay.Text = finishTime.Seconds.ToString("D2");

                    break;                    
                case FIL_FUNC:
                    textBox_Filters_MaPK.Text = row["MaPK"].ToString();
                    comboBox_Filters_TrangThai.Text = row_PK["TrangThai"].ToString();
                    textBox_Filters_SoGhe.Text = row_PK["SoGhe"].ToString();

                    textBox_Filters_MaNV.Text = row["MaNV"].ToString();

                    startTime = row.Field<TimeSpan>("ThoiGianBD");
                    finishTime = row.Field<TimeSpan>("ThoiGianKT");

                    textBox_Filters_TGBDGio.Text = startTime.Hours.ToString("D2");
                    textBox_Filters_TGBDPhut.Text = startTime.Minutes.ToString("D2");
                    textBox_Filters_TGBDGiay.Text = startTime.Seconds.ToString("D2");

                    textBox_Filters_TGKTGio.Text = finishTime.Hours.ToString("D2");
                    textBox_Filters_TGKTPhut.Text = finishTime.Minutes.ToString("D2");
                    textBox_Filters_TGKTGiay.Text = finishTime.Seconds.ToString("D2");
                    break;
            }
        }

        private void fillPanel_PK(DataRow row)
        {
            switch (controlFunc)
            {
                case INS_FUNC:
                    textBox_Upload_MaPK.Text = row["MaPK"].ToString();
                    comboBox_Upload_TrangThai.Text = row["TrangThai"].ToString();
                    textBox_Upload_SoGhe.Text = row["SoGhe"].ToString();
                    break;
                case FIL_FUNC:
                    textBox_Filters_MaPK.Text = row["MaPK"].ToString();
                    comboBox_Filters_TrangThai.Text = row["TrangThai"].ToString();
                    textBox_Filters_SoGhe.Text = row["SoGhe"].ToString();
                    break;
            }
        }
    }
}
