namespace FinalProjectOOP2
{
    partial class SavingForm
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
            panel1 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel2 = new Panel();
            panel5 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel7 = new Panel();
            saveBtn = new SiticoneNetCoreUI.SiticoneTileButton();
            label1 = new Label();
            textBox1 = new TextBox();
            panel6 = new Panel();
            savingYourData = new SiticoneNetCoreUI.SiticoneShimmerLabel();
            panel5.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 128, 185);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(801, 37);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(41, 128, 185);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 375);
            panel3.Name = "panel3";
            panel3.Size = new Size(801, 44);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(715, 37);
            panel4.Name = "panel4";
            panel4.Size = new Size(86, 338);
            panel4.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 37);
            panel2.Name = "panel2";
            panel2.Size = new Size(86, 338);
            panel2.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.Controls.Add(tableLayoutPanel1);
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(savingYourData);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(86, 37);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(10);
            panel5.Size = new Size(629, 338);
            panel5.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel7, 0, 2);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(textBox1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(10, 145);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(5);
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 39.74359F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60.25641F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 94F));
            tableLayoutPanel1.Size = new Size(609, 183);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // panel7
            // 
            panel7.Controls.Add(saveBtn);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(8, 86);
            panel7.Name = "panel7";
            panel7.Size = new Size(593, 89);
            panel7.TabIndex = 0;
            // 
            // saveBtn
            // 
            saveBtn.AccessibleDescription = "A customizable tile button";
            saveBtn.AccessibleName = "TileButton";
            saveBtn.BackColor = Color.Transparent;
            saveBtn.BadgeColor = Color.Red;
            saveBtn.BadgeFont = "Segoe UI";
            saveBtn.BadgePosition = new Point(218, 5);
            saveBtn.BadgeText = "";
            saveBtn.BaseColor = Color.FromArgb(50, 150, 215);
            saveBtn.BorderWidth = 1F;
            saveBtn.BottomLeftRadius = 12F;
            saveBtn.BottomRightRadius = 12F;
            saveBtn.ColorTransitionSpeed = 0.15F;
            saveBtn.EnableRipple = true;
            saveBtn.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            saveBtn.ForeColor = Color.White;
            saveBtn.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            saveBtn.HoverColor = Color.FromArgb(70, 170, 235);
            saveBtn.Icon = null;
            saveBtn.IconAlignment = ContentAlignment.MiddleLeft;
            saveBtn.IconMargin = new Padding(5);
            saveBtn.IconPadding = 5;
            saveBtn.IconSize = new Size(24, 24);
            saveBtn.IsLoading = false;
            saveBtn.IsToggled = false;
            saveBtn.LoadingColor = Color.White;
            saveBtn.Location = new Point(179, 15);
            saveBtn.Margin = new Padding(3, 2, 3, 2);
            saveBtn.MaxRipples = 100;
            saveBtn.Name = "saveBtn";
            saveBtn.PersistState = false;
            saveBtn.RippleColor = Color.FromArgb(255, 255, 255);
            saveBtn.RippleFadeStart = 0F;
            saveBtn.RippleOpacity = 0.1F;
            saveBtn.RippleSpeed = 20F;
            saveBtn.ShadowColor = Color.Black;
            saveBtn.ShadowDepth = 1;
            saveBtn.ShadowOffset = new Point(1, 1);
            saveBtn.ShadowOpacity = 0.3F;
            saveBtn.ShowBadge = false;
            saveBtn.ShowBorder = false;
            saveBtn.ShowTextShadow = true;
            saveBtn.Size = new Size(229, 57);
            saveBtn.TabIndex = 20;
            saveBtn.Text = "SAVE";
            saveBtn.TooltipAlwaysShow = true;
            saveBtn.TooltipAutoPopDelay = 5000;
            saveBtn.TooltipBackColor = Color.Black;
            saveBtn.TooltipFont = new Font("Segoe UI", 9F);
            saveBtn.TooltipForeColor = Color.White;
            saveBtn.TooltipInitialDelay = 500;
            saveBtn.TooltipReshowDelay = 100;
            saveBtn.TooltipText = "";
            saveBtn.TopLeftRadius = 12F;
            saveBtn.TopRightRadius = 12F;
            saveBtn.UseGradient = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 13.8F);
            label1.Location = new Point(8, 5);
            label1.Name = "label1";
            label1.Size = new Size(485, 27);
            label1.TabIndex = 4;
            label1.Text = "Please enter your Resume Title (FileName)";
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(8, 39);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(593, 36);
            textBox1.TabIndex = 2;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(10, 74);
            panel6.Name = "panel6";
            panel6.Size = new Size(609, 71);
            panel6.TabIndex = 6;
            // 
            // savingYourData
            // 
            savingYourData.AutoReverse = false;
            savingYourData.BaseColor = Color.Black;
            savingYourData.Direction = SiticoneNetCoreUI.ShimmerDirection.LeftToRight;
            savingYourData.Dock = DockStyle.Top;
            savingYourData.Font = new Font("Century Gothic", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            savingYourData.IsAnimating = true;
            savingYourData.IsPaused = false;
            savingYourData.Location = new Point(10, 10);
            savingYourData.Name = "savingYourData";
            savingYourData.PauseDuration = 0;
            savingYourData.ShimmerColor = Color.Cyan;
            savingYourData.ShimmerOpacity = 1F;
            savingYourData.ShimmerSpeed = 50;
            savingYourData.ShimmerWidth = 0.2F;
            savingYourData.Size = new Size(609, 64);
            savingYourData.TabIndex = 1;
            savingYourData.TabStop = false;
            savingYourData.Text = "Saving your data...";
            savingYourData.ToolTipText = "";
            // 
            // SavingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(216, 225, 233);
            ClientSize = new Size(801, 419);
            Controls.Add(panel5);
            Controls.Add(panel2);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SavingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Save your Resume";
            panel5.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel7.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel4;
        private Panel panel2;
        private Panel panel5;
        private SiticoneNetCoreUI.SiticoneShimmerLabel savingYourData;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TextBox textBox1;
        private Panel panel6;
        private Panel panel7;
        private SiticoneNetCoreUI.SiticoneTileButton saveBtn;
    }
}