namespace FinalProjectOOP2
{
    partial class LoadingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingForm));
            bottom = new Panel();
            progressBar = new SiticoneNetCoreUI.SiticoneHProgressBar();
            top = new Panel();
            panel2 = new Panel();
            loadinglbl = new Label();
            center = new Panel();
            contentCenter = new Panel();
            panel1 = new Panel();
            efaf = new SiticoneNetCoreUI.SiticoneShimmerLabel();
            bottom.SuspendLayout();
            panel2.SuspendLayout();
            center.SuspendLayout();
            contentCenter.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // bottom
            // 
            bottom.Controls.Add(progressBar);
            bottom.Dock = DockStyle.Bottom;
            bottom.Location = new Point(10, 359);
            bottom.Name = "bottom";
            bottom.Padding = new Padding(5);
            bottom.Size = new Size(763, 63);
            bottom.TabIndex = 3;
            // 
            // progressBar
            // 
            progressBar.AccessibleDescription = "This control shows the value of the horizontal progress bar.";
            progressBar.AccessibleName = "Advanced and modern horizontal progress bar control";
            progressBar.AccessibleRole = AccessibleRole.ProgressBar;
            progressBar.AnimationDurationMs = 300D;
            progressBar.AnimationTimerInterval = 15;
            progressBar.AutoLabelColor = false;
            progressBar.BackColor = Color.FromArgb(216, 225, 233);
            progressBar.BackgroundBarColor = Color.FromArgb(254, 252, 251);
            progressBar.BorderColor = Color.FromArgb(34, 30, 65);
            progressBar.CanBeep = true;
            progressBar.CanShake = true;
            progressBar.CornerRadiusBottomLeft = 26;
            progressBar.CornerRadiusBottomRight = 26;
            progressBar.CornerRadiusTopLeft = 26;
            progressBar.CornerRadiusTopRight = 26;
            progressBar.CustomLabel = "";
            progressBar.Dock = DockStyle.Fill;
            progressBar.EnableValueDragging = false;
            progressBar.ErrorColor = Color.Red;
            progressBar.Font = new Font("Segoe UI", 9F);
            progressBar.GradientEndColor = Color.FromArgb(41, 128, 185);
            progressBar.GradientStartColor = Color.FromArgb(0, 31, 84);
            progressBar.Indeterminate = false;
            progressBar.IndeterminateBarColor = Color.FromArgb(34, 30, 65);
            progressBar.IsReadonly = false;
            progressBar.LabelColor = Color.White;
            progressBar.LabelFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            progressBar.Location = new Point(5, 5);
            progressBar.MakeRadial = true;
            progressBar.Maximum = 100;
            progressBar.Minimum = 0;
            progressBar.MinimumSize = new Size(50, 20);
            progressBar.Name = "progressBar";
            progressBar.ReadonlyBorderColor = Color.Black;
            progressBar.ReadonlyFillColor1 = Color.Gray;
            progressBar.ReadonlyFillColor2 = Color.White;
            progressBar.ReadonlyForeColor = Color.White;
            progressBar.ShowFocusCue = false;
            progressBar.Size = new Size(753, 53);
            progressBar.SuccessColor = Color.Green;
            progressBar.TabIndex = 8;
            progressBar.Value = 72;
            progressBar.ValueOrientation = SiticoneNetCoreUI.Helpers.ProgressBar.ProgressBarOrientation.Horizontal;
            progressBar.WarningColor = Color.Orange;
            // 
            // top
            // 
            top.BackColor = Color.Transparent;
            top.Dock = DockStyle.Top;
            top.Location = new Point(10, 10);
            top.Name = "top";
            top.Size = new Size(763, 65);
            top.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Controls.Add(loadinglbl);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(10, 320);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5);
            panel2.Size = new Size(763, 39);
            panel2.TabIndex = 10;
            // 
            // loadinglbl
            // 
            loadinglbl.AutoSize = true;
            loadinglbl.Dock = DockStyle.Left;
            loadinglbl.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loadinglbl.Location = new Point(5, 5);
            loadinglbl.Name = "loadinglbl";
            loadinglbl.Size = new Size(140, 27);
            loadinglbl.TabIndex = 2;
            loadinglbl.Text = "Preparing...";
            // 
            // center
            // 
            center.Controls.Add(contentCenter);
            center.Dock = DockStyle.Fill;
            center.Location = new Point(10, 75);
            center.Name = "center";
            center.Padding = new Padding(15);
            center.Size = new Size(763, 245);
            center.TabIndex = 11;
            // 
            // contentCenter
            // 
            contentCenter.Controls.Add(panel1);
            contentCenter.Dock = DockStyle.Fill;
            contentCenter.Location = new Point(15, 15);
            contentCenter.Name = "contentCenter";
            contentCenter.Size = new Size(733, 215);
            contentCenter.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.Controls.Add(efaf);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15);
            panel1.Size = new Size(733, 94);
            panel1.TabIndex = 0;
            // 
            // efaf
            // 
            efaf.AutoReverse = false;
            efaf.BaseColor = Color.Black;
            efaf.Direction = SiticoneNetCoreUI.ShimmerDirection.LeftToRight;
            efaf.Dock = DockStyle.Fill;
            efaf.Font = new Font("Century Gothic", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            efaf.IsAnimating = true;
            efaf.IsPaused = false;
            efaf.Location = new Point(15, 15);
            efaf.Name = "efaf";
            efaf.PauseDuration = 0;
            efaf.ShimmerColor = Color.Cyan;
            efaf.ShimmerOpacity = 1F;
            efaf.ShimmerSpeed = 50;
            efaf.ShimmerWidth = 0.2F;
            efaf.Size = new Size(703, 64);
            efaf.TabIndex = 0;
            efaf.TabStop = false;
            efaf.Text = "Loading, Please Wait!";
            efaf.ToolTipText = "";
            // 
            // LoadingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(216, 225, 233);
            ClientSize = new Size(783, 432);
            Controls.Add(center);
            Controls.Add(panel2);
            Controls.Add(top);
            Controls.Add(bottom);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoadingForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProResume+";
            bottom.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            center.ResumeLayout(false);
            contentCenter.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel bottom;
        private SiticoneNetCoreUI.SiticoneHProgressBar progressBar;
        private Panel top;
        private Panel panel2;
        private Panel center;
        private Panel contentCenter;
        private Panel panel1;
        private SiticoneNetCoreUI.SiticoneShimmerLabel efaf;
        private Label loadinglbl;
    }
}