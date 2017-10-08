using Microsoft.VisualBasic.CompilerServices;
using Shadowsocks.Controller;
using Shadowsocks.Model;
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

namespace Shadowsocks.View
{
    public partial class TrafficStatsSuspensionForm : Form
    {
        private Point ptMouseCurrentPos, ptMouseNewPos, ptFormPos, ptFormNewPos;
        private bool blnMouseDown = false;
        private TrafficStatsForm pParent;
        //Add ContextMenuStrip
        private ContextMenuStrip docMenu;
        private ShadowsocksController controller;
        private TrafficStats trafficStats;

        private CancellationTokenSource cts;
        private long lastUsed;

        public new TrafficStatsForm ParentForm
        {
            get { return pParent; }
            set { pParent = value; }
        }

        public TrafficStatsSuspensionForm(ShadowsocksController controller, TrafficStats stats)
        {
            this.controller = controller;
            this.trafficStats = stats;
            InitializeComponent();

            this.trafficStats.OnDataChanged += TrafficStats_OnDataChanged;
        }

        private void TrafficStatsSuspensionForm_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Top = 100;
            this.Left = Screen.PrimaryScreen.Bounds.Width - 200;
            this.Width = 80;
            this.Height = 80;

            docMenu = new ContextMenuStrip();

            ToolStripMenuItem OpenMainFormaItem = new ToolStripMenuItem();
            OpenMainFormaItem.Text = I18N.GetString("&Open");
            OpenMainFormaItem.Click += new EventHandler(OpenLable_Click);
            ToolStripMenuItem CalibrateItem = new ToolStripMenuItem();
            CalibrateItem.Text = I18N.GetString("&Calibrate");
            CalibrateItem.Click += new EventHandler(Calibrate_Click);
            ToolStripMenuItem ExitSuspentionItem = new ToolStripMenuItem();
            ExitSuspentionItem.Text = I18N.GetString("&Exit");
            ExitSuspentionItem.Click += new EventHandler(ExitLable_Click);

            docMenu.Items.AddRange(new ToolStripMenuItem[] { OpenMainFormaItem, CalibrateItem, ExitSuspentionItem });
            this.ContextMenuStrip = docMenu;

            //计速
            cts = new CancellationTokenSource();
            this.lastUsed = this.trafficStats.MonthUsed;
            Task.Factory.StartNew(this.CalculateSpeed, cts.Token,
                TaskCreationOptions.LongRunning, TaskScheduler.Current);
            this.UpdateStatsText();
        }

        private void TrafficStats_OnDataChanged(object sender, TrafficStatsChangedEventArgs e)
        {
            this.UpdateStatsText();
        }

        private void UpdateStatsText()
        {
            try
            {
                this.BeginInvoke(new Action(() =>
                {
                    this.label_percent.Text = $"{I18N.GetString("TotalLeft")}" +
                       $"{Math.Round((this.trafficStats.MonthTotal - this.trafficStats.MonthUsed) * 100.0 / this.trafficStats.MonthTotal, 1)}%";
                }));
            }
            catch { return; };
        }

        private void CalculateSpeed()
        {
            while (true)
            {
                long currentUsed = (long)(this.trafficStats.MonthUsed - this.lastUsed);
                try
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        this.trafficStats.CurrentSpeed = Util.Utils.FormatBytes(currentUsed);
                        this.label_speed.Text = this.trafficStats.CurrentSpeed + "/s";
                    }));
                }
                catch { return; }
                this.lastUsed = this.trafficStats.MonthUsed;
                Thread.Sleep(1000);
            }
        }

        private void TrafficStatsSuspensionForm_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (blnMouseDown)
            {
                //Get the current postion of the mouse in the screen.
                ptMouseNewPos = Control.MousePosition;

                //Set window postion.
                ptFormNewPos.X = ptMouseNewPos.X - ptMouseCurrentPos.X + ptFormPos.X;
                ptFormNewPos.Y = ptMouseNewPos.Y - ptMouseCurrentPos.Y + ptFormPos.Y;

                //Save window postion.
                Location = ptFormNewPos;
                ptFormPos = ptFormNewPos;

                //Save mouse pontion.
                ptMouseCurrentPos = ptMouseNewPos;
            }
        }

        private void TrafficStatsSuspensionForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                blnMouseDown = true;

                //Save window postion and mouse postion.
                ptMouseCurrentPos = Control.MousePosition;
                ptFormPos = Location;
            }
        }

        private void TrafficStatsSuspensionForm_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                blnMouseDown = false;
            }
        }

        //Restore parent from.
        private void TrafficStatsSuspensionForm_DoubleClick(object sender, System.EventArgs e)
        {
            SwitchToMain();
        }

        private void SwitchToMain()
        {
            if (ParentForm == null)
            {
                ParentForm = new TrafficStatsForm(this, trafficStats);
            }

            if (ParentForm != null)
            {
                ParentForm.Show();
                ParentForm.RestoreWindow();
                //this.Hide();
            }
        }

        #region  //Context events.
        private void OpenLable_Click(object sender, System.EventArgs e)
        {
            SwitchToMain();
        }
        private void Calibrate_Click(object sender, System.EventArgs e)
        {
            this.trafficStats.CalibrateTrafficDataStats();
        }
        private void ExitLable_Click(object sender, System.EventArgs e)
        {
            this.Close();
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
                this.ParentForm = null;
            }

            controller.ToggleShowStatsSuspention(false);
        }
        #endregion

        private void TrafficStatsSuspensionForm_MouseEnter(object sender, System.EventArgs e)
        {
            this.toolTip1.Active = true;
            this.toolTip1.AutoPopDelay = 500000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
        }
        private void TrafficStatsSuspensionForm_MouseLeave(object sender, System.EventArgs e)
        {
            this.toolTip1.Active = false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.trafficStats.Save();
            this.trafficStats.OnDataChanged -= TrafficStats_OnDataChanged;
            if (this.ParentForm != null)
            {
                this.ParentForm = null;
            }
            base.OnClosing(e);
        }

    }
}
