namespace Shadowsocks.View
{
    partial class TrafficStatsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.FileMenuItem = new System.Windows.Forms.MenuItem();
            this.OpenLocationMenuItem = new System.Windows.Forms.MenuItem();
            this.ExitMenuItem = new System.Windows.Forms.MenuItem();
            this.OperationMenuItem = new System.Windows.Forms.MenuItem();
            this.CalibrateMenuItem = new System.Windows.Forms.MenuItem();
            this.SaveStatsMenuItem = new System.Windows.Forms.MenuItem();
            this.CleanStatsMenuItem = new System.Windows.Forms.MenuItem();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.stats_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_MonthTotal = new System.Windows.Forms.GroupBox();
            this.textbox_total = new System.Windows.Forms.TextBox();
            this.label_total = new System.Windows.Forms.Label();
            this.groupBox_MonthUsed = new System.Windows.Forms.GroupBox();
            this.textbox_used = new System.Windows.Forms.TextBox();
            this.label_used = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.stats_chart)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox_MonthTotal.SuspendLayout();
            this.groupBox_MonthUsed.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.FileMenuItem,
            this.OperationMenuItem});
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.Index = 0;
            this.FileMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.OpenLocationMenuItem,
            this.ExitMenuItem});
            this.FileMenuItem.Text = "&File";
            // 
            // OpenLocationMenuItem
            // 
            this.OpenLocationMenuItem.Index = 0;
            this.OpenLocationMenuItem.Text = "&Open Location";
            this.OpenLocationMenuItem.Click += new System.EventHandler(this.OpenLocationMenuItem_Click);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Index = 1;
            this.ExitMenuItem.Text = "&Exit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // OperationMenuItem
            // 
            this.OperationMenuItem.Index = 1;
            this.OperationMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                this.CalibrateMenuItem,
                this.SaveStatsMenuItem,
                this.CleanStatsMenuItem});
                this.OperationMenuItem.Text = "&Operation";
            // 
            // CalibrateMenuItem
            // 
            this.CalibrateMenuItem.Index = 0;
            this.CalibrateMenuItem.Text = "&Calibrate Stats";
            this.CalibrateMenuItem.Click += new System.EventHandler(this.CalibrateMenuItem_Click);
            // 
            // SaveStatsMenuItem
            // 
            this.SaveStatsMenuItem.Index = 0;
            this.SaveStatsMenuItem.Text = "&Save Stats";
            this.SaveStatsMenuItem.Click += new System.EventHandler(this.SaveStatsMenuItem_Click);
            // 
            // CleanStatsMenuItem
            // 
            this.CleanStatsMenuItem.Index = 1;
            this.CleanStatsMenuItem.Text = "&Clean Stats";
            this.CleanStatsMenuItem.Click += new System.EventHandler(this.CleanStatsMenuItem_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(540, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(0, 384);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // stats_chart
            // 
            chartArea1.Name = "ChartArea";
            this.stats_chart.ChartAreas.Add(chartArea1);
            this.stats_chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stats_chart.Location = new System.Drawing.Point(3, 70);
            this.stats_chart.Name = "stats_chart";
            series1.ChartArea = "ChartArea";
            series1.IsValueShownAsLabel = true;
            series1.Name = "Series1";
            this.stats_chart.Series.Add(series1);
            this.stats_chart.Size = new System.Drawing.Size(534, 311);
            this.stats_chart.TabIndex = 0;
            this.stats_chart.Text = "chart1";
            this.stats_chart.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 61);
            this.panel1.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.50187F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.49813F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox_MonthTotal, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox_MonthUsed, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.41322F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.58678F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(534, 61);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // groupBox_MonthTotal
            // 
            this.groupBox_MonthTotal.Controls.Add(this.textbox_total);
            this.groupBox_MonthTotal.Controls.Add(this.label_total);
            this.groupBox_MonthTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_MonthTotal.Location = new System.Drawing.Point(3, 3);
            this.groupBox_MonthTotal.Name = "groupBox_MonthTotal";
            this.groupBox_MonthTotal.Size = new System.Drawing.Size(252, 55);
            this.groupBox_MonthTotal.TabIndex = 11;
            this.groupBox_MonthTotal.TabStop = false;
            this.groupBox_MonthTotal.Text = "总流量";
            // 
            // textbox_total
            // 
            this.textbox_total.Dock = System.Windows.Forms.DockStyle.Left;
            this.textbox_total.Location = new System.Drawing.Point(3, 21);
            this.textbox_total.Name = "textbox_total";
            this.textbox_total.Size = new System.Drawing.Size(110, 25);
            this.textbox_total.TabIndex = 2;
            // 
            // label_total
            // 
            this.label_total.AutoSize = true;
            this.label_total.Location = new System.Drawing.Point(122, 27);
            this.label_total.Name = "label_total";
            this.label_total.Size = new System.Drawing.Size(15, 15);
            this.label_total.TabIndex = 4;
            this.label_total.Text = "M";
            // 
            // groupBox_MonthUsed
            // 
            this.groupBox_MonthUsed.Controls.Add(this.textbox_used);
            this.groupBox_MonthUsed.Controls.Add(this.label_used);
            this.groupBox_MonthUsed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_MonthUsed.Location = new System.Drawing.Point(261, 3);
            this.groupBox_MonthUsed.Name = "groupBox_MonthUsed";
            this.groupBox_MonthUsed.Size = new System.Drawing.Size(270, 55);
            this.groupBox_MonthUsed.TabIndex = 12;
            this.groupBox_MonthUsed.TabStop = false;
            this.groupBox_MonthUsed.Text = "已用流量";
            // 
            // textbox_used
            // 
            this.textbox_used.Dock = System.Windows.Forms.DockStyle.Left;
            this.textbox_used.Location = new System.Drawing.Point(3, 21);
            this.textbox_used.Name = "textbox_used";
            this.textbox_used.Size = new System.Drawing.Size(113, 25);
            this.textbox_used.TabIndex = 2;
            // 
            // label_used
            // 
            this.label_used.AutoSize = true;
            this.label_used.Location = new System.Drawing.Point(122, 27);
            this.label_used.Name = "label_used";
            this.label_used.Size = new System.Drawing.Size(15, 15);
            this.label_used.TabIndex = 4;
            this.label_used.Text = "M";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 96F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.stats_chart, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.70833F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.29166F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(540, 384);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // TrafficStatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 384);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Menu = this.MainMenu;
            this.Name = "TrafficStatsForm";
            this.Text = "流量数据统计";
            this.Load += new System.EventHandler(this.TrafficStatsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stats_chart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox_MonthTotal.ResumeLayout(false);
            this.groupBox_MonthTotal.PerformLayout();
            this.groupBox_MonthUsed.ResumeLayout(false);
            this.groupBox_MonthUsed.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MainMenu MainMenu;
        private System.Windows.Forms.MenuItem FileMenuItem;
        private System.Windows.Forms.MenuItem OpenLocationMenuItem;
        private System.Windows.Forms.MenuItem ExitMenuItem;
        private System.Windows.Forms.MenuItem OperationMenuItem;
        private System.Windows.Forms.MenuItem CalibrateMenuItem;
        private System.Windows.Forms.MenuItem SaveStatsMenuItem;
        private System.Windows.Forms.MenuItem CleanStatsMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart stats_chart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_total;
        private System.Windows.Forms.TextBox textbox_total;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox_MonthTotal;
        private System.Windows.Forms.GroupBox groupBox_MonthUsed;
        private System.Windows.Forms.TextBox textbox_used;
        private System.Windows.Forms.Label label_used;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}