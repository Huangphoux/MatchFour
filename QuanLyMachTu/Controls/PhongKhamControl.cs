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

        //SQL Command
        string PK_SelectCommand = "SELECT MaPK, SoGhe, TrangThai " +
                                  "FROM PHONGKHAM " +
                                  "WHERE IsDeleted = 0 ";
        string PC_SelectCommand = "SELECT * FROM LamViec ";

        //Control variables
        //highlight
        List<string> highlightList = new List<string>();
        Color oldColor;
        //tab index
        const int PK_TAB = 0;
        const int PC_TAB = 10;
        //function index
        const int INS_FUNC = 1;
        const int FIL_FUNC = 2;
        //controllers
        string controlCommand_PK;
        string controlCommand_PC;
        int controlPage;
        int controlFunc;
        CustomDataGridView controlDataGridView;
        public PhongKhamControl()
        {
            InitializeComponent();
        }
        private void PhongKhamControl_Load(object sender, EventArgs e)
        {
            InitializeState();
        }
        //General methods
        //Initialize methods
        private void InitializeState()
        {
            InitializeState_PK();
            InitializeState_PC();

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
        private void LoadPage(int controlPage)
        {
            switch (controlPage)
            {
                case PK_TAB:
                    controlCommand_PK = PK_SelectCommand;
                    UpdateDataGridView(controlDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand_PK));
                    break;
                case PC_TAB:
                    controlCommand_PC = PC_SelectCommand;
                    UpdateDataGridView(controlDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand_PC));
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
                    controlDataGridView = customDataGridView_PK;
                    break;
                case PC_TAB:
                    controlDataGridView = customDataGridView_PC;
                    break;
            }

            RepaintPanel(panel_Upload);
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
            string selectCommand;
            switch (controlPage)
            {
                case PK_TAB:
                    selectCommand = "SELECT DISTINCT PK.MaPK, SoGhe, TrangThai " +
                                    "FROM PHONGKHAM PK " +
                                    "LEFT JOIN LamViec LV ON LV.MaPK = PK.MaPK " +
                                    "WHERE IsDeleted = 0 ";
                    ApplyFilter(ref selectCommand);
                    UpdateDataGridView(customDataGridView_PK, DatabaseConnection.LoadDataIntoDataTable(selectCommand));
                    break;
                case PC_TAB:
                    selectCommand = "SELECT MaNV, PK.MaPK, ThoiGianBD, ThoiGianKT " +
                                    "FROM LamViec LV " +
                                    "INNER JOIN PHONGKHAM PK ON LV.MaPK = PK.MaPK " +
                                    "WHERE IsDeleted = 0 ";
                    ApplyFilter(ref selectCommand);
                    UpdateDataGridView(customDataGridView_PC, DatabaseConnection.LoadDataIntoDataTable(selectCommand));
                    break;
            }
        }
        //Remove button
        private void pageButton_Remove_Click(object sender, EventArgs e)
        {
            switch (controlPage)
            {
                case PK_TAB:
                    PK_Remove();
                    break;
                case PC_TAB:
                    PC_Remove();
                    break;
            }
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
        //Additions
        private void textBox_KeyPress_PositiveNumber(object sender, KeyPressEventArgs e)
        {
            GeneralMethods.textBox_KeyPress_PositiveNumber(sender, e);
        }
        private void textBox_KeyPress_Normal(object sender, KeyPressEventArgs e)
        {
            GeneralMethods.textBox_KeyPress_Normal(sender, e);
        }
        private void textBox_NoHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            GeneralMethods.textBox_NoHour_KeyPress(sender, e);
        }
        private void textBox_Hour_KeyPress(object sender, KeyPressEventArgs e)
        {
            GeneralMethods.textBox_Hour_KeyPress(sender, e);
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
            //Upload
            comboBox_Upload_TrangThai.SelectedItem = comboBox_Upload_TrangThai.Items[0];
            //Filters
            comboBox_Filters_Comparer.SelectedIndex = 2;

            //Page status
            controlCommand_PK = PK_SelectCommand;
            controlDataGridView = customDataGridView_PK;
            UpdateDataGridView(controlDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand_PK));
            DisablePage(PK_TAB);
        }
        //Check and prevent errors
        private int CheckUploadError_PK()
        {
            int error = 0;
            if (string.IsNullOrEmpty(textBox_Upload_MaPK.Text))
                error |= MAPK_ERR;
            if (string.IsNullOrEmpty(textBox_Upload_SoGhe.Text))
                error |= SOGHE_ERR;
            if (string.IsNullOrEmpty(GeneralMethods.GetTrangThai(comboBox_Upload_TrangThai)))
                error |= TRANGTHAI_ERR;

            return error;
        }
        private void WarningUploadError_PK(int error)
        {
            if ((error & MAPK_ERR) == MAPK_ERR)
                ColoringTextBox.WarningColor(textBox_Upload_MaPK);
            if ((error & SOGHE_ERR) == SOGHE_ERR)
                ColoringTextBox.WarningColor(textBox_Upload_SoGhe);

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

            string checkQuery = "IF EXISTS (SELECT 1 FROM PHONGKHAM WHERE AND MaPK = @MaPK) SELECT 1 ELSE SELECT 0";
            Dictionary<string, object> checkParameters = new Dictionary<string, object> { { "@MaPK", primaryKey } };

            int recordExists = (int)DatabaseConnection.ExecuteScalar(checkQuery, checkParameters);

            if (recordExists == 0)
            {
                string insertQuery = "INSERT INTO PHONGKHAM " +
                                     "(MaPK, SoGhe, TrangThai) " +
                                     "VALUES(@MaPK, @SoGhe, @TrangThai)";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaPK", primaryKey},
                    {"@SoGhe", textBox_Upload_SoGhe.Text },
                    {"@TrangThai", GeneralMethods.GetTrangThai(comboBox_Upload_TrangThai) },
                };

                DatabaseConnection.ExecuteNonQuery(insertQuery, parameters);
            }
            else
            {
                string updateQuery = "UPDATE PHONGKHAM " +
                                        "SET SoGhe = @SoGhe, " +
                                            "TrangThai = @TrangThai, " +
                                            "IsDeleted = 0 " +
                                        "WHERE MaPK = @MaPK";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaPK", primaryKey},
                    {"@SoGhe", textBox_Upload_SoGhe.Text },
                    {"@TrangThai", GeneralMethods.GetTrangThai(comboBox_Upload_TrangThai) },
                };

                DatabaseConnection.ExecuteNonQuery(updateQuery, parameters);
            }

            UpdateDataGridView(customDataGridView_PK, DatabaseConnection.LoadDataIntoDataTable(controlCommand_PK));
        }
        //Filter method
        private string ApplyFilter(ref string selectCommand)
        {
            if (string.IsNullOrEmpty(textBox_Filters_MaPK.Text) == false)
                selectCommand += $"AND PK.MaPK = '{textBox_Filters_MaPK.Text}' ";
            if (string.IsNullOrEmpty(textBox_Filters_SoGhe.Text) == false)
            {
                string comparer = GeneralMethods.GetOperation(comboBox_Filters_Comparer);
                selectCommand += $"AND SoGhe {comparer} {textBox_Filters_SoGhe.Text} ";
            }
            string trangThai = GeneralMethods.GetTrangThai(comboBox_Filters_TrangThai);
            if (string.IsNullOrEmpty(trangThai) == false)
                selectCommand += $"AND TrangThai = '{trangThai}' ";
            if (string.IsNullOrEmpty(textBox_Filters_MaNV.Text) == false)
                selectCommand += $"AND MaNV = '{textBox_Filters_MaNV.Text}' ";
            string time = GeneralMethods.GetTime(textBox_Upload_TGBDGio, textBox_Upload_TGBDPhut, textBox_Upload_TGBDGiay);
            if (time != null)
                selectCommand += $"AND ThoiGianBD >= '{time}' ";
            time = GeneralMethods.GetTime(textBox_Upload_TGKTGio, textBox_Upload_TGKTPhut, textBox_Upload_TGKTGiay);
            if (time != null)
                selectCommand += $"AND ThoiGianKT <= '{time}' ";

            return selectCommand;
        }
        //Remove method
        private void PK_Remove()
        {
            //get all rows of selected cells
            HashSet<DataGridViewRow> selectedRows = new HashSet<DataGridViewRow>();
            foreach (DataGridViewCell cell in customDataGridView_PK.SelectedCells)
                selectedRows.Add(cell.OwningRow);

            //get deleted parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string parameter;
            int parameterIndex = 0;

            string inDeletedList = "(NULL";
            foreach (DataGridViewRow row in selectedRows)
            {
                parameter = $"@MaPK{parameterIndex}";
                parameters.Add(parameter, row.Cells["MaPK"].Value.ToString());
                inDeletedList += $", {parameter}";
                parameterIndex++;
            }
            inDeletedList += ")";

            //remove
            string deleteCommand = "UPDATE PHONGKHAM " +
                                   "SET IsDeleted = 1 " +
                                   "WHERE MaPK IN " + inDeletedList;
            DatabaseConnection.ExecuteNonQuery(deleteCommand, parameters);

            //renew
            UpdateDataGridView(customDataGridView_PK, DatabaseConnection.LoadDataIntoDataTable(controlCommand_PK));
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

            customDataGridView_PC.Focus();
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

            //Page status
            controlCommand_PC = PC_SelectCommand;
            controlDataGridView = customDataGridView_PC;
            UpdateDataGridView(controlDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand_PC));
            DisablePage(PC_TAB);
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
            string checkQuery = "IF EXISTS (SELECT 1 FROM LamViec WHERE MaPK = @MaPK AND MaNV = @MaNV) SELECT 1 ELSE SELECT 0";
            Dictionary<string, object> checkParameters = new Dictionary<string, object> { { "@MaPK", primaryKey[1] }, { "@MaNV", primaryKey[0] } };

            int recordExists = (int)DatabaseConnection.ExecuteScalar(checkQuery, checkParameters);

            if (recordExists == 0)
            {
                string insertQuery = "INSERT INTO LamViec " +
                                     "VALUES(@MaNV, @MaPK, @ThoiGianBD, @ThoiGianKT)";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaPK", primaryKey[1] },
                    {"@MaNV", primaryKey[0] },
                    {"@ThoiGianBD", GeneralMethods.GetTime(textBox_Upload_TGBDGio, textBox_Upload_TGBDPhut, textBox_Upload_TGBDGiay) },
                    {"@ThoiGianKT", GeneralMethods.GetTime(textBox_Upload_TGKTGio, textBox_Upload_TGKTPhut, textBox_Upload_TGKTGiay) },
                };

                DatabaseConnection.ExecuteNonQuery(insertQuery, parameters);
            }
            else
            {
                string updateQuery = "UPDATE LamViec " +
                                        "SET ThoiGianBD = @ThoiGianBD, " +
                                            "ThoiGianKT = @ThoiGianKT " +
                                        "WHERE MaPK = @MaPK AND MaNV = @MaNV";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaPK", primaryKey[1] },
                    {"@MaNV", primaryKey[0] },
                    {"@ThoiGianBD", GeneralMethods.GetTime(textBox_Upload_TGBDGio, textBox_Upload_TGBDPhut, textBox_Upload_TGBDGiay) },
                    {"@ThoiGianKT", GeneralMethods.GetTime(textBox_Upload_TGKTGio, textBox_Upload_TGKTPhut, textBox_Upload_TGKTGiay) },
                };

                DatabaseConnection.ExecuteNonQuery(updateQuery, parameters);
            }

            UpdateDataGridView(customDataGridView_PC, DatabaseConnection.LoadDataIntoDataTable(controlCommand_PC));
        }
        //Remove
        private void PC_Remove()
        {
            //get all rows of selected cells
            HashSet<DataGridViewRow> selectedRows = new HashSet<DataGridViewRow>();
            foreach (DataGridViewCell cell in customDataGridView_PC.SelectedCells)
                selectedRows.Add(cell.OwningRow);

            //get deleted parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string parameter1, parameter2;
            int parameterIndex = 0;

            string maPK, maNV;

            string inDeletedList = "1 != 1 ";
            foreach (DataGridViewRow row in selectedRows)
            {
                parameter1 = $"@MaPK{parameterIndex}";
                parameter2 = $"@MaNV{parameterIndex}";
                maPK = row.Cells["MaPK"].Value.ToString();
                maNV = row.Cells["MaNV"].Value.ToString();
                parameters.Add(parameter1, maPK);
                parameters.Add(parameter2, maNV);
                inDeletedList += $"OR (MaPK = {parameter1} AND MaNV = {parameter2}) ";
                parameterIndex++;
            }

            //remove
            string deleteCommand = "DELETE FROM LamViec " +
                                   "WHERE " + inDeletedList;
            DatabaseConnection.ExecuteNonQuery(deleteCommand, parameters);

            //renew
            UpdateDataGridView(customDataGridView_PC, DatabaseConnection.LoadDataIntoDataTable(controlCommand_PC));
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
            DataGridViewRow row = dgv.Rows[e.RowIndex];

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

        private void fillPanel_PC(DataGridViewRow row)
        {
            TimeSpan startTime, finishTime;

            switch (controlFunc)
            {
                case INS_FUNC:
                    textBox_Upload_MaPK.Text = row.Cells["MaPK"].Value.ToString();
                    textBox_Upload_MaNV.Text = row.Cells["MaNV"].Value.ToString();

                    startTime = TimeSpan.Parse(row.Cells["ThoiGianBD"].Value.ToString());
                    finishTime = TimeSpan.Parse(row.Cells["ThoiGianKT"].Value.ToString());

                    textBox_Upload_TGBDGio.Text = startTime.Hours.ToString("D2");
                    textBox_Upload_TGBDPhut.Text = startTime.Minutes.ToString("D2");
                    textBox_Upload_TGBDGiay.Text = startTime.Seconds.ToString("D2");

                    textBox_Upload_TGKTGio.Text = finishTime.Hours.ToString("D2");
                    textBox_Upload_TGKTPhut.Text = finishTime.Minutes.ToString("D2");
                    textBox_Upload_TGKTGiay.Text = finishTime.Seconds.ToString("D2");

                    break;
                case FIL_FUNC:
                    textBox_Filters_MaPK.Text = row.Cells["MaPK"].Value.ToString();
                    textBox_Filters_MaNV.Text = row.Cells["MaNV"].Value.ToString();

                    startTime = TimeSpan.Parse(row.Cells["ThoiGianBD"].Value.ToString());
                    finishTime = TimeSpan.Parse(row.Cells["ThoiGianKT"].Value.ToString());

                    textBox_Filters_TGBDGio.Text = startTime.Hours.ToString("D2");
                    textBox_Filters_TGBDPhut.Text = startTime.Minutes.ToString("D2");
                    textBox_Filters_TGBDGiay.Text = startTime.Seconds.ToString("D2");

                    textBox_Filters_TGKTGio.Text = finishTime.Hours.ToString("D2");
                    textBox_Filters_TGKTPhut.Text = finishTime.Minutes.ToString("D2");
                    textBox_Filters_TGKTGiay.Text = finishTime.Seconds.ToString("D2");
                    break;
            }
        }

        private void fillPanel_PK(DataGridViewRow row)
        {
            switch (controlFunc)
            {
                case INS_FUNC:
                    textBox_Upload_MaPK.Text = row.Cells["MaPK"].Value.ToString();
                    comboBox_Upload_TrangThai.Text = row.Cells["TrangThai"].Value.ToString();
                    textBox_Upload_SoGhe.Text = row.Cells["SoGhe"].Value.ToString();
                    break;
                case FIL_FUNC:
                    textBox_Filters_MaPK.Text = row.Cells["MaPK"].Value.ToString();
                    comboBox_Filters_TrangThai.Text = row.Cells["TrangThai"].Value.ToString();
                    textBox_Filters_SoGhe.Text = row.Cells["SoGhe"].Value.ToString();
                    break;
            }
        }

        private void button_Upload_Reset_Click(object sender, EventArgs e)
        {
            textBox_Upload_MaPK.Text = "";

            if (controlPage == PK_TAB)
            {
                textBox_Upload_SoGhe.Text = "";
                comboBox_Upload_TrangThai.SelectedIndex = 0;
            }
            else if (controlPage == PC_TAB)
            {
                textBox_Upload_MaNV.Text = "";
                textBox_Upload_TGBDGio.Text = "00";
                textBox_Upload_TGBDPhut.Text = "00";
                textBox_Upload_TGBDGiay.Text = "00";
                textBox_Upload_TGKTGio.Text = "23";
                textBox_Upload_TGKTPhut.Text = "59";
                textBox_Upload_TGKTGiay.Text = "59";
            }

            LoadPage(controlPage);
        }

        private void button_Filters_Reset_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            Panel containingPanel = clickedButton.Parent as Panel;

            foreach (Control control in containingPanel.Controls)
                if (control is TextBox textBox)
                    textBox.Text = "";

            comboBox_Filters_Comparer.SelectedIndex = 2;
            comboBox_Filters_TrangThai.Text = null;

            LoadPage(controlPage);
        }
        private List<string> GetDataWhenDatabaseChanged()
        {
            string NV_chuaPhanCongCommand = "SELECT MaPK " +
                                            "FROM LICHKHAM LK " +
                                            "WHERE TinhTrang = N'Chưa kết thúc' " +
                                            "GROUP BY MaPK " +
                                            "HAVING COUNT(MaLK) >= (SELECT SoGhe " +
                                                                   "FROM PHONGKHAM PK " +
                                                                   "WHERE PK.MaPK = LK.MaPK) ";
            //SqlDataReader reader = DatabaseConnection.ExecuteReaderNotification(NV_chuaPhanCongCommand, OnTableChange);
            SqlDataReader reader = DatabaseConnection.ExecuteReader(NV_chuaPhanCongCommand);
            List<string> NV_chuaPhanCongList = new List<string>();
            while (reader.Read())
            {
                NV_chuaPhanCongList.Add(reader["MaPK"].ToString());
            }
            reader.Close();

            return NV_chuaPhanCongList;
        }
        private void checkBox_QuaTai_PK_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked)
            {
                highlightList = GetDataWhenDatabaseChanged();
            }
            else
            {
                highlightList.Clear();
            }
            customDataGridView_PK.Refresh();
        }
        private void customDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewRow row = dgv.Rows[e.RowIndex];

            if (highlightList.Contains(row.Cells["MaPK"].Value.ToString()))
            {
                MessageBox.Show($"{row.DefaultCellStyle.BackColor}");
                row.DefaultCellStyle.BackColor = ColorUsed.Overlay(row.DefaultCellStyle.BackColor, Color.Red, 0.5f);
            }
            //else
            //{
            //    //MessageBox.Show($"{row.DefaultCellStyle.BackColor}");
            //    row.DefaultCellStyle.BackColor = ColorUsed.Remove(row.DefaultCellStyle.BackColor, Color.Red);
            //}
        }

        private void customDataGridView_RowPrePaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewRow row = dgv.Rows[e.RowIndex];

            if (highlightList.Contains(row.Cells["MaPK"].Value.ToString()))
            {
                row.DefaultCellStyle.BackColor = ColorUsed.highlightTop;
            }
            else
            {
                row.DefaultCellStyle.BackColor = dgv.BackgroundColor;
            }
        }
    }
}
