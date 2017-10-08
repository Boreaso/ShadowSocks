using Shadowsocks.Controller;
using Shadowsocks.Model;
using Shadowsocks.Properties;
using Shadowsocks.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Shadowsocks.View
{
    public partial class TrafficStatsForm : Form
    {
        private FormWindowState fwsPrevious;
        private TrafficStatsSuspensionForm tsSuspentionForm;
        private TrafficStats trafficStats;
        private bool formLoaded;

        public TrafficStatsForm(TrafficStatsSuspensionForm pSub, TrafficStats stats)
        {
            this.tsSuspentionForm = pSub;

            InitializeComponent();

            Icon = Icon.FromHandle(Resources.ssw128.GetHicon());
            this.SizeChanged += new EventHandler(this.TrafficStatsForm_SizeChanged);

            this.trafficStats = stats;
            this.trafficStats.OnDataChanged += TrafficdStats_OnDataChanged;
            this.trafficStats.OnSpeedChanged += TrafficStats_OnSpeedChanged;

            StatsItem totalItem = Utils.ConvertToMiB(this.trafficStats.MonthTotal);
            this.textbox_total.Text = totalItem.Value.ToString();
            this.label_total.Text = totalItem.Unit;
            StatsItem statsItem = Utils.ConvertToMiB(this.trafficStats.MonthUsed);
            this.textbox_used.Text = statsItem.Value.ToString();
            this.label_used.Text = statsItem.Unit;

            this.UpdateTexts();
        }

        private void UpdateTexts()
        {
            this.FileMenuItem.Text = I18N.GetString("&File");
            this.OpenLocationMenuItem.Text = I18N.GetString("&Open Location");
            this.ExitMenuItem.Text = I18N.GetString("E&xit");
            this.OperationMenuItem.Text = I18N.GetString("&Operation");
            this.CalibrateMenuItem.Text = I18N.GetString("&Calibrate Stats");
            this.SaveStatsMenuItem.Text = I18N.GetString("&Save Stats");
            this.CleanStatsMenuItem.Text = I18N.GetString("&Clean Stats");
            this.Text = I18N.GetString("TrafficFormTitle");
            this.groupBox_MonthTotal.Text = I18N.GetString("MonthTotal");
            this.groupBox_MonthUsed.Text = I18N.GetString("MonthTotalUsed");
        }

        private void TrafficStatsForm_Load(object sender, EventArgs e)
        {
            List<double> downLoadValues = new List<double>()
            {
                Utils.ConvertToMiB(this.trafficStats.MonthDownload).Value,
                Utils.ConvertToMiB(this.trafficStats.TodayDownload).Value,
                Utils.ConvertToMiB(this.trafficStats.CurrentDownload).Value
            };
            List<double> upLoadValues = new List<double>()
            {
                Utils.ConvertToMiB(this.trafficStats.MonthUpload).Value,
                Utils.ConvertToMiB(this.trafficStats.TodayUpload).Value,
                Utils.ConvertToMiB(this.trafficStats.CurrentUpload).Value
            };
            List<string> x = new List<string>()
            {
                I18N.GetString("MonthUsed"),
                I18N.GetString("TodayUsed"),
                I18N.GetString("CurrentUsed")
            };

            if (stats_chart.IsHandleCreated)
            {
                stats_chart.Series.Clear();
                stats_chart.Series.Add(I18N.GetString("Download"));
                stats_chart.Series.Add(I18N.GetString("Upload"));

                //stats_chart.Legends.Clear();
                stats_chart.Legends.Add(I18N.GetString("Download"));
                stats_chart.Legends[I18N.GetString("Download")].Docking = Docking.Top;
                stats_chart.Legends[I18N.GetString("Download")].Alignment = StringAlignment.Far;
                stats_chart.Legends.Add(I18N.GetString("Upload"));
                stats_chart.Legends[I18N.GetString("Upload")].Docking = Docking.Top;
                stats_chart.Legends[I18N.GetString("Upload")].Alignment = StringAlignment.Far;

                stats_chart.Series[I18N.GetString("Download")].LegendText = I18N.GetString("DownloadLegendText");
                stats_chart.Series[I18N.GetString("Download")].Points.DataBindXY(x, downLoadValues);
                stats_chart.Series[I18N.GetString("Download")].IsValueShownAsLabel = true;
                stats_chart.Series[I18N.GetString("Upload")].LegendText = I18N.GetString("UploadLegendText");
                stats_chart.Series[I18N.GetString("Upload")].Points.DataBindXY(x, upLoadValues);
                stats_chart.Series[I18N.GetString("Upload")].IsValueShownAsLabel = true;
            }

            //save the windowState;
            this.fwsPrevious = this.WindowState;
            this.formLoaded = true;
        }

        private void TrafficStats_OnSpeedChanged(object sender, TrafficStatsChangedEventArgs e)
        {
            try
            {
                if (this.formLoaded)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.Text = $"{I18N.GetString("TrafficFormTitle")}       " +
                        $"{I18N.GetString("CurrentSpeed")}: {e.Value}/s";
                    }));
                }
            }
            catch { return; }
        }

        private void TrafficdStats_OnDataChanged(object sender, TrafficStatsChangedEventArgs e)
        {
            try
            {
                if (this.formLoaded && this.IsHandleCreated)
                {
                    //校准月总量
                    string monthTotalText = Utils.ConvertToMiB(this.trafficStats.MonthTotal).Value.ToString();
                    if (!monthTotalText.Equals(this.textbox_total.Text))
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.textbox_total.Text = monthTotalText;
                        }));
                    }

                    List<string> x = new List<string>()
                    {
                        I18N.GetString("MonthUsed"),
                        I18N.GetString("TodayUsed"),
                        I18N.GetString("CurrentUsed")
                    };

                    if (e.IsDownload)
                    {
                        List<double> downLoadValues = new List<double>()
                        {
                            Utils.ConvertToMiB(this.trafficStats.MonthDownload).Value,
                            Utils.ConvertToMiB(this.trafficStats.TodayDownload).Value,
                            Utils.ConvertToMiB(this.trafficStats.CurrentDownload).Value
                        };

                        this.Invoke(new Action(() =>
                        {
                            stats_chart.Series[I18N.GetString("Download")].Points.DataBindXY(x, downLoadValues);
                        }));
                    }
                    else
                    {
                        List<double> upLoadValues = new List<double>()
                        {
                            Utils.ConvertToMiB(this.trafficStats.MonthUpload).Value,
                            Utils.ConvertToMiB(this.trafficStats.TodayUpload).Value,
                            Utils.ConvertToMiB(this.trafficStats.CurrentUpload).Value
                        };

                        this.Invoke(new Action(() =>
                        {
                            stats_chart.Series[I18N.GetString("Upload")].Points.DataBindY(upLoadValues);
                        }));
                    }

                    this.Invoke(new Action(() =>
                    {
                        StatsItem statsItem = Utils.ConvertToMiB(this.trafficStats.MonthUsed);
                        this.textbox_used.Text = statsItem.Value.ToString();
                        if (!this.label_used.Text.Equals(statsItem.Unit))
                        {
                            this.label_used.Text = statsItem.Unit;
                        }
                    }));
                }
            }
            catch { return; };
        }

        private void TrafficStatsForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                //window minimized.
                //tsSuspentionForm.Show();
                this.ShowInTaskbar = false;
                this.formLoaded = false;
            }
            else if (this.WindowState != fwsPrevious)
            {
                fwsPrevious = WindowState;
            }
        }

        //Restore window.
        public void RestoreWindow()
        {
            this.WindowState = fwsPrevious;
            this.CenterToScreen();
            this.ShowInTaskbar = true;
            this.formLoaded = true;
        }

        private void OpenLocationMenuItem_Click(object sender, EventArgs e)
        {
            string argument = "/select, \"" + "traffic-stats.json" + "\"";
            System.Diagnostics.Process.Start("explorer.exe", argument);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CalibrateMenuItem_Click(object sender, EventArgs e)
        {
            this.trafficStats.CalibrateTrafficDataStats();
        }

        private void SaveStatsMenuItem_Click(object sender, EventArgs e)
        {
            this.trafficStats.MonthTotal = (long)Utils.ConvertToBytes(double.Parse(this.textbox_total.Text)).Value;
            this.trafficStats.MonthUsed = (long)Utils.ConvertToBytes(double.Parse(this.textbox_used.Text)).Value;
            this.trafficStats.Save();
        }

        private void CleanStatsMenuItem_Click(object sender, EventArgs e)
        {
            this.trafficStats.Clear();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.trafficStats.Save();
            this.trafficStats.OnDataChanged -= TrafficdStats_OnDataChanged;
            this.trafficStats.OnSpeedChanged -= TrafficStats_OnSpeedChanged;
            if (this.tsSuspentionForm != null)
            {
                this.tsSuspentionForm.ParentForm = null;
                this.tsSuspentionForm = null;
            }
            base.OnClosing(e);
        }
    }
}
