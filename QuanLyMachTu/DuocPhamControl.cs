using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QuanLyMachTu.Custom;
using QuanLyMachTu.Helper;

using System.Data;
using System.Data.SqlClient;

namespace QuanLyMachTu
{
    public partial class DuocPhamControl : UserControl
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
        //function index
        const int INS_FUNC = 1;
        const int FIL_FUNC = 2;
        //controllers
        int controlPage;
        DataTable controlDataTable;
        CustomDataGridView controlDataGridView;

        public DuocPhamControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // DuocPhamControl
            // 
            Name = "DuocPhamControl";
            Load += DuocPhamControl_Load;
            ResumeLayout(false);
        }

        private void DuocPhamControl_Load(object sender, EventArgs e)
        {
            LoadData();
            InitializeState();
        }

        private void InitializeState()
        {
            controlDataGridView = customDataGridView_PC;
            controlPage = PK_TAB;
            SwitchMode(controlPage);
            panel_Filters.BringToFront();
        }

        private void LoadData()
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();

            dataset = new DataSet();

            connection.Close();

            UpdateDataGridView(customDataGridView_PK, datatablePK);
            UpdateDataGridView(customDataGridView_PC, datatablePC);
        }
    }
}
