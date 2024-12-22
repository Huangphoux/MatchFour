using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMachTu.Helper
{
    public static class GeneralMethods
    {
        public static string GetGioiTinh(CheckBox checkBox_Nam, CheckBox checkBox_Nu)
        {
            if (checkBox_Nam.Checked)
                return "Nam";
            else
                return "Nữ";
        }
        public static string GetNgayThangNam(TextBox textBox_Ngay, ComboBox comboBox_Thang, TextBox textBox_Nam)
        {
            if (string.IsNullOrEmpty(textBox_Ngay.Text))
                return null;
            else if (string.IsNullOrEmpty(textBox_Nam.Text))
                return null;

            return $"{comboBox_Thang.SelectedIndex + 1}/{textBox_Ngay.Text}/{textBox_Nam.Text}";
        }
        public static string GetOperation(ComboBox operations)
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
        public static void textBox_KeyPress_PositiveNumber(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                ColoringTextBox.NormalColor((TextBox)sender);
            }
            else
                e.Handled = true;
        }
        public static void textBox_KeyPress_Normal(object sender, KeyPressEventArgs e)
        {
            ColoringTextBox.NormalColor((TextBox)sender);
        }
        public static void FillDate(TextBox ngay, ComboBox thang, TextBox nam)
        {
            DateTime currentDate = DateTime.Now;
            ngay.Text = currentDate.Day.ToString("D2");
            thang.SelectedIndex = currentDate.Month - 1;
            nam.Text = currentDate.Year.ToString("D2");
        }
        public static void FillTime(TextBox gio, TextBox phut, TextBox giay)
        {
            DateTime currentDate = DateTime.Now;
            gio.Text = currentDate.Hour.ToString("D2");
            phut.Text = currentDate.Minute.ToString("D2");
            giay.Text = currentDate.Second.ToString("D2");
        }
        public static string GetTrangThai(ComboBox trangThai)
        {
            return (string)trangThai.SelectedItem;
        }
        public static int isLeapYear(int year)
        {
            return Convert.ToInt32(year % 4 == 0 && year % 100 != 0 || year % 400 == 0);
        }
        public static int GetDaysOfMonth(int month, int year)
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
        public static string GetDateTime(TextBox textBox_Ngay, ComboBox comboBox_Thang, TextBox textBox_Nam, TextBox textBox_Gio, TextBox textBox_Phut, TextBox textBox_Giay)
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

            int hour = int.Parse(textBox_Gio.Text);
            int minute = int.Parse(textBox_Phut.Text);
            int second = int.Parse(textBox_Giay.Text);

            DateTime datetime = new DateTime(year, month, day, hour, minute, second);

            return datetime.ToString("MM/dd/yyyy H:mm:ss");
        }
        public static string GetTime(TextBox textBox_Gio, TextBox textBox_Phut, TextBox textBox_Giay)
        {
            int hour, minute, second;
            bool isError = int.TryParse(textBox_Gio.Text, out hour);
            isError |= int.TryParse(textBox_Phut.Text, out minute);
            isError |= int.TryParse(textBox_Giay.Text, out second);

            if (isError)
                return null;
            return $"{hour}:{minute}:{second}";
        }
        public static void textBox_Hour_KeyPress(object sender, KeyPressEventArgs e)
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

        public static void textBox_NoHour_KeyPress(object sender, KeyPressEventArgs e)
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
        public static void ClearPanel(Panel panel)
        {
            foreach (Control control in panel.Controls)
                if (control is TextBox || control is ComboBox)
                    control.Text = null;
        }
        public static void SetUpPanel(Panel panel, int index)
        {
            foreach (Control control in panel.Controls)
                if (control is ComboBox comboBox)
                    comboBox.SelectedIndex = index;
        }      
        public static void CleanColorPanel(Panel panel)
        {
            foreach (Control control in panel.Controls)
                if (control is TextBox textBox)
                    ColoringTextBox.NormalColor(textBox);
        }
        public static void TickCheckBox(CheckBox checkbox1, CheckBox checkbox2, string match)
        {
            if (match == checkbox1.Text)
            {
                checkbox1.Checked = true;
                checkbox2.Checked = false;
            }
            else if (match == checkbox2.Text)
            {
                checkbox2.Checked = true;
                checkbox1.Checked = false;
            }
        }
        public static int Count(DataGridView dgv, string columnName, object value)
        {
            int count = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[columnName].Value.Equals(value))
                    count++;     
            }
            return count;
        }
        public static long Sum(DataGridView dgv, string columnName)
        {
            long sum = 0;
            foreach (DataGridViewRow row in dgv.Rows)
                sum += Convert.ToInt64(row.Cells[columnName].Value);
            return sum;
        }
        public static float Average(DataGridView dgv, string columnName)
        {
            float sum = 0f;
            int count = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                sum += Convert.ToSingle(row.Cells[columnName].Value);
                count++;
            }
            return sum/count;
        }
    }
}
