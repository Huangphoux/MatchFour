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

namespace QuanLyMachTu
{
    public partial class BenhNhanControl : UserControl
    {
        //Bit errors
        //Upload textBox
        const int MABN_ERR = 1;
        const int TENBN_ERR = 2;
        const int NGAY_ERR = 4;
        const int NAM_ERR = 8;
        const int SDT_ERR = 16;
        const int EMAIL_ERR = 32;

        //Database fields
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataSet dataset;
        private DataTable datatableBN;
        private DataTable datatableHSBA;
        private DataTable datatableTK;

        public BenhNhanControl()
        {
            InitializeComponent();
            comboBox_BNUpload_Thang.SelectedItem = comboBox_BNUpload_Thang.Items[0];

            panel_Filter.BringToFront();

            LoadData();
        }

        //Database methods
        private void LoadData()
        {
            string connectionStr = @"Server=LAPTOP-6GL1AF15\STUDENT;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";
            connection = new SqlConnection(connectionStr);
            connection.Open();

            dataset = new DataSet();

            LoadDataToDataSet("SELECT * FROM BENHNHAN", "BENHNHAN");
            LoadDataToDataSet("SELECT * FROM HOSOBENHAN", "HOSOBENHAN");
            LoadDataToDataSet("SELECT * FROM TAIKHOAN", "TAIKHOAN");

            datatableBN = dataset.Tables["BENHNHAN"];
            datatableBN.PrimaryKey = new DataColumn[] { datatableBN.Columns["MaBN"] };

            datatableHSBA = dataset.Tables["HOSOBENHAN"];
            datatableHSBA.PrimaryKey = new DataColumn[] { datatableHSBA.Columns["MaHSBA"], datatableHSBA.Columns["NgayLap"] };

            datatableTK = dataset.Tables["TAIKHOAN"];
            datatableTK.PrimaryKey = new DataColumn[] { datatableTK.Columns["MaTK"] };

            UpdateDataGridView(customDataGridView_BenhNhan, datatableBN);

            connection.Close();
        }

        //Database methods
        private void LoadDataToDataSet(string commandStr, string tableName)
        {
            adapter = new SqlDataAdapter(commandStr, connection);
            adapter.Fill(dataset, tableName);
        }

        //Upload method set
        private void pageButton_Upload_Click(object sender, EventArgs e)
        {
            panel_Upload.BringToFront();
        }

        private int CheckUploadTextBox()
        {
            int error = 0;
            if (string.IsNullOrEmpty(textBox_BNUpload_MaBN.Text))
                error |= 1;
            if (string.IsNullOrEmpty(textBox_BNUpload_TenBN.Text))
                error |= 2;
            if (string.IsNullOrEmpty(textBox_BNUpload_Ngay.Text))
                error |= 4;
            if (string.IsNullOrEmpty(textBox_BNUpload_Nam.Text))
                error |= 8;
            if (string.IsNullOrEmpty(textBox_BNUpload_SDT.Text))
                error |= 16;
            if (string.IsNullOrEmpty(textBox_BNUpload_Email.Text))
                error |= 32;

            return error;
        }

        private void WarningUploadTextBoxError(int error)
        {
            if ((error & MABN_ERR) == MABN_ERR)
                ColoringTextBox.WarningColor(textBox_BNUpload_MaBN);
            if ((error & TENBN_ERR) == TENBN_ERR)
                ColoringTextBox.WarningColor(textBox_BNUpload_TenBN);
            if ((error & NGAY_ERR) == NGAY_ERR)
                ColoringTextBox.WarningColor(textBox_BNUpload_Ngay);
            if ((error & NAM_ERR) == NAM_ERR)
                ColoringTextBox.WarningColor(textBox_BNUpload_Nam);
            if ((error & SDT_ERR) == SDT_ERR)
                ColoringTextBox.WarningColor(textBox_BNUpload_SDT);
            if ((error & EMAIL_ERR) == EMAIL_ERR)
                ColoringTextBox.WarningColor(textBox_BNUpload_Email);
        }

        private void button_BNUpload_OK_Click(object sender, EventArgs e)
        {
            int error = CheckUploadTextBox();
            if (error != 0)
            {
                WarningUploadTextBoxError(error);
                return;
            }

            string primaryKey = textBox_BNUpload_MaBN.Text;
            DataRow targetRow = datatableBN.Rows.Find(primaryKey);

            if (targetRow == null) // Insert
            {
                targetRow = datatableBN.NewRow();
                targetRow["MaBN"] = primaryKey;
                targetRow["HoTenBN"] = textBox_BNUpload_TenBN.Text;
                targetRow["GioiTinh"] = GetGioiTinh(checkBox_BNUpload_Nam, checkBox_BNUpload_Nu);
                targetRow["NgaySinh"] = GetNgayThangNam(textBox_BNUpload_Ngay, comboBox_BNUpload_Thang, textBox_BNUpload_Nam);
                targetRow["Email"] = textBox_BNUpload_Email.Text;
                targetRow["SDT"] = textBox_BNUpload_SDT.Text;
                datatableBN.Rows.Add(targetRow);
            }
            else //Update
            {
                targetRow["MaBN"] = primaryKey;
                targetRow["HoTenBN"] = textBox_BNUpload_TenBN.Text;
                targetRow["GioiTinh"] = GetGioiTinh(checkBox_BNUpload_Nam, checkBox_BNUpload_Nu);
                targetRow["NgaySinh"] = GetNgayThangNam(textBox_BNUpload_Ngay, comboBox_BNUpload_Thang, textBox_BNUpload_Nam);
                targetRow["Email"] = textBox_BNUpload_Email.Text;
                targetRow["SDT"] = textBox_BNUpload_SDT.Text;
            }

            UpdateDataGridView(customDataGridView_BenhNhan, datatableBN);
        }

        private void checkBox_BNUpload_Nam_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_BNUpload_Nam.Checked)
                checkBox_BNUpload_Nu.Checked = false;
        }

        private void checkBox_BNUpload_Nu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_BNUpload_Nu.Checked)
                checkBox_BNUpload_Nam.Checked = false;
        }

        //general methods
        private string GetGioiTinh(CheckBox checkBox_Nam, CheckBox checkBox_Nu)
        {
            if (checkBox_Nam.Checked)
                return "Nam";
            else
                return "Nữ";
        }

        private string GetNgayThangNam(TextBox textBox_Ngay, ComboBox comboBox_Thang, TextBox textBox_Nam)
        {
            return $"{comboBox_Thang.SelectedIndex + 1}/{textBox_Ngay.Text}/{textBox_Nam.Text}";
        }

        private void Button_KeyPress_PositiveNumber(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                ColoringTextBox.NormalColor((TextBox)sender);
            }
            else
                e.Handled = true;
        }

        private void UpdateDataGridView(DataGridView dgv, DataTable datatable)
        {
            //Load data to data grid view
            dgv.DataSource = datatable;

            //Display statitic number
            label_HienThiDTTong.Text = CalculateSumOfDoanhSo(dgv).ToString();
            label_HienThiSoBN.Text = dgv.Rows.Count.ToString();
        }

        private void button_KeyPress_Normal(object sender, KeyPressEventArgs e)
        {
            ColoringTextBox.NormalColor((TextBox)sender);
        }

        //Filters method set
        private void button_Filters_OK_Click(object sender, EventArgs e)
        {
            string selectCommand = "1 = 1 ";

            //Find exact row
            if (string.IsNullOrEmpty(textBox_Filters_MaBN.Text) == false)
                selectCommand += $"AND MaBN = '{textBox_Filters_MaBN.Text}' ";
            else if (string.IsNullOrEmpty(textBox_Filters_MaHSBA.Text) == false)
            {
                DataRow[] foundRows = datatableHSBA.Select($"MaHSBA = '{textBox_Filters_MaHSBA.Text}'");

                if (foundRows.Length == 0)
                    selectCommand += $"AND MaBN = NULL ";
                else
                    selectCommand += $"AND MaBN = '{foundRows[0]["MaBN"]}' ";
            }
            else if (string.IsNullOrEmpty(textBox_Filters_MaTK.Text) == false)
            {
                DataRow? foundRow = datatableTK.Rows.Find(textBox_Filters_MaTK.Text);

                selectCommand += $"AND MaBN = '{foundRow["MaBN"]}' ";
            }

            //Another informations
            if (string.IsNullOrEmpty(textBox_Filters_TenBN.Text) == false)
                selectCommand += $"AND HoTenBN = '{textBox_Filters_TenBN.Text}' ";
            if (string.IsNullOrEmpty(textBox_Filters_Email.Text) == false)
                selectCommand += $"AND Email = '{textBox_Filters_Email.Text}' ";
            if (string.IsNullOrEmpty(textBox_Filters_SDT.Text) == false)
                selectCommand += $"AND SDT = '{textBox_Filters_SDT.Text}' ";
            if (string.IsNullOrEmpty(textBox_Filters_DoanhSo.Text) == false)
                selectCommand += $"AND DoanhSo >= {textBox_Filters_DoanhSo.Text} ";

            DataRow[] resultRow = datatableBN.Select(selectCommand);
            DataTable resultDatatable = datatableBN.Clone();

            foreach (DataRow row in resultRow)
            {
                if (resultDatatable.Rows.Contains(row["MaBN"]))
                    continue;

                resultDatatable.ImportRow(row);
            }

            UpdateDataGridView(customDataGridView_BenhNhan, resultDatatable);
        }

        private void pageButton_Filters_Click(object sender, EventArgs e)
        {
            panel_Filter.BringToFront();
        }

        //Remove methods
        private void pageButton_Remove_Click(object sender, EventArgs e)
        {
            HashSet<DataGridViewRow> selectedRows = new HashSet<DataGridViewRow>();

            foreach (DataGridViewCell cell in customDataGridView_BenhNhan.SelectedCells)
                selectedRows.Add(cell.OwningRow);

            foreach (DataGridViewRow row in selectedRows)
            {
                string MaBN = row.Cells["MaBN"].Value.ToString();

                DataRow? deleteRow = datatableBN.Rows.Find(MaBN);
                datatableBN.Rows.Remove(deleteRow);
            }

            UpdateDataGridView(customDataGridView_BenhNhan, datatableBN);
        }

        //Bottom view
        private long CalculateSumOfDoanhSo(DataGridView dgv)
        {
            long sum = 0L;
            long doanhSo;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (long.TryParse(row.Cells["DoanhSo"].Value.ToString(), out doanhSo))
                    sum += doanhSo;
            }

            return sum;
        }

        //Decorate panel
        private void panel_BNUpload_Paint(object sender, PaintEventArgs e)
        {
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            int startX = 15, endX = 395;
            graphic.DrawLine(linePen, new Point(startX, 165), new Point(endX, 165)); //MaBN line
            graphic.DrawLine(linePen, new Point(startX, 264), new Point(endX, 264)); //TenBN line
            graphic.DrawLine(linePen, new Point(startX, 363), new Point(94, 363)); //Ngay line
            graphic.DrawLine(linePen, new Point(239, 363), new Point(endX, 363)); //Nam line
            graphic.DrawLine(linePen, new Point(startX, 462), new Point(199, 462)); //SDL line
            graphic.DrawLine(linePen, new Point(startX, 561), new Point(endX, 561)); //Email line
        }

        private void panel_BNFilter_Paint(object sender, PaintEventArgs e)
        {
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            int startX = 15, endX = 395;
            graphic.DrawLine(linePen, new Point(startX, 165), new Point(135, 165)); //MaBN line
            graphic.DrawLine(linePen, new Point(145, 165), new Point(265, 165)); //MaHSBA line
            graphic.DrawLine(linePen, new Point(275, 165), new Point(endX, 165)); //MaTK line
            graphic.DrawLine(linePen, new Point(startX, 264), new Point(endX, 264)); //TenBN line
            graphic.DrawLine(linePen, new Point(startX, 363), new Point(endX, 363)); //Email line
            graphic.DrawLine(linePen, new Point(startX, 462), new Point(endX, 462)); //SDL line
            graphic.DrawLine(linePen, new Point(startX, 561), new Point(352, 561)); //DoanhSo line
        }

        private void pageButton5_Click(object sender, EventArgs e)
        {

        }
    }
}
