namespace Shadowsocks.View
{
    partial class TrafficStatsSuspensionForm
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label_speed = new System.Windows.Forms.Label();
            this.label_percent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_speed
            // 
            this.label_speed.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label_speed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_speed.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_speed.Font = new System.Drawing.Font("新宋体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_speed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_speed.Location = new System.Drawing.Point(2, 18);
            this.label_speed.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.label_speed.Name = "label_speed";
            this.label_speed.Size = new System.Drawing.Size(87, 16);
            this.label_speed.TabIndex = 2;
            this.label_speed.Text = "198.99KiB/s";
            this.label_speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_speed.MouseEnter += TrafficStatsSuspensionForm_MouseEnter;
            this.label_speed.MouseLeave += TrafficStatsSuspensionForm_MouseLeave;
            this.label_speed.MouseDown += TrafficStatsSuspensionForm_MouseDown;
            this.label_speed.MouseUp += TrafficStatsSuspensionForm_MouseUp;
            this.label_speed.MouseMove += TrafficStatsSuspensionForm_MouseMove;
            this.label_speed.MouseDoubleClick += TrafficStatsSuspensionForm_DoubleClick;
            // 
            // label_percent
            // 
            this.label_percent.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label_percent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_percent.Font = new System.Drawing.Font("新宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_percent.Location = new System.Drawing.Point(2, 45);
            this.label_percent.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.label_percent.Name = "label_percent";
            this.label_percent.Size = new System.Drawing.Size(87, 16);
            this.label_percent.TabIndex = 3;
            this.label_percent.Text = "剩余0%";
            this.label_percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_percent.MouseEnter += TrafficStatsSuspensionForm_MouseEnter;
            this.label_percent.MouseLeave += TrafficStatsSuspensionForm_MouseLeave;
            this.label_percent.MouseDown += TrafficStatsSuspensionForm_MouseDown;
            this.label_percent.MouseUp += TrafficStatsSuspensionForm_MouseUp;
            this.label_percent.MouseMove += TrafficStatsSuspensionForm_MouseMove;
            this.label_percent.MouseDoubleClick += TrafficStatsSuspensionForm_DoubleClick;
            // 
            // TrafficStatsSuspensionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(90, 80);
            this.Controls.Add(this.label_speed);
            this.Controls.Add(this.label_percent);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TrafficStatsSuspensionForm";
            this.Opacity = 0.6D;
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.Text = "TrafficStatsSuspensionForm";
            this.toolTip1.SetToolTip(this, "dddd");
            this.TopMost = true;
            this.Load += new System.EventHandler(this.TrafficStatsSuspensionForm_Load);
            this.MouseEnter += TrafficStatsSuspensionForm_MouseEnter;
            this.MouseLeave += TrafficStatsSuspensionForm_MouseLeave;
            this.MouseDown += TrafficStatsSuspensionForm_MouseDown;
            this.MouseUp += TrafficStatsSuspensionForm_MouseUp;
            this.MouseMove += TrafficStatsSuspensionForm_MouseMove;
            this.MouseDoubleClick += TrafficStatsSuspensionForm_DoubleClick;
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label_speed;
        private System.Windows.Forms.Label label_percent;
    }
}