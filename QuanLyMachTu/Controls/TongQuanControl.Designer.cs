namespace QuanLyMachTu.Controls
{
    partial class TongQuanControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            panel1 = new Panel();
            chart_DuocPham = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)chart_DuocPham).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1272, 80);
            panel1.TabIndex = 0;
            // 
            // chart_DuocPham
            // 
            chartArea1.Name = "ChartArea1";
            chart_DuocPham.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart_DuocPham.Legends.Add(legend1);
            chart_DuocPham.Location = new Point(160, 160);
            chart_DuocPham.Name = "chart_DuocPham";
            chart_DuocPham.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart_DuocPham.Series.Add(series1);
            chart_DuocPham.Size = new Size(440, 360);
            chart_DuocPham.TabIndex = 1;
            chart_DuocPham.Text = "chart1";
            // 
            // TongQuanControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(57, 54, 70);
            Controls.Add(chart_DuocPham);
            Controls.Add(panel1);
            Name = "TongQuanControl";
            Size = new Size(1272, 691);
            Load += TongQuanControl_Load;
            ((System.ComponentModel.ISupportInitialize)chart_DuocPham).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_DuocPham;
    }
}
