namespace FinalProjectOOP2
{
    partial class EarlierPositionsForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            comboBox1 = new ComboBox();
            descLbl = new Label();
            titleBlock = new Label();
            panel8 = new Panel();
            panel2 = new Panel();
            panel6 = new Panel();
            tableLayoutPanel13 = new TableLayoutPanel();
            label25 = new Label();
            label26 = new Label();
            label27 = new Label();
            positionTbx = new TextBox();
            label35 = new Label();
            companyTbx = new TextBox();
            locationTbx = new TextBox();
            durationTbx = new TextBox();
            panel9 = new Panel();
            warnning2EERespo = new Label();
            warning1EEProfExp = new Label();
            earlierPositionsDgv = new DataGridView();
            JobTitle = new DataGridViewTextBoxColumn();
            Company = new DataGridViewTextBoxColumn();
            Location = new DataGridViewTextBoxColumn();
            Duration = new DataGridViewTextBoxColumn();
            panel7 = new Panel();
            warningLbl = new Label();
            label2 = new Label();
            panel5 = new Panel();
            tableLayoutPanel14 = new TableLayoutPanel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            addExpBtn = new FontAwesome.Sharp.IconButton();
            removeExpBtn = new FontAwesome.Sharp.IconButton();
            panel4 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            tableLayoutPanel13.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)earlierPositionsDgv).BeginInit();
            panel7.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel14.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 31, 84);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(descLbl);
            panel1.Controls.Add(titleBlock);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10, 10, 0, 0);
            panel1.Size = new Size(862, 87);
            panel1.TabIndex = 27;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(687, 29);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(0, 28);
            comboBox1.TabIndex = 6;
            // 
            // descLbl
            // 
            descLbl.AutoSize = true;
            descLbl.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            descLbl.ForeColor = Color.White;
            descLbl.Location = new Point(30, 66);
            descLbl.Name = "descLbl";
            descLbl.Size = new Size(12, 27);
            descLbl.TabIndex = 4;
            descLbl.Text = "\r\n";
            descLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // titleBlock
            // 
            titleBlock.AutoSize = true;
            titleBlock.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleBlock.ForeColor = Color.White;
            titleBlock.Location = new Point(30, 19);
            titleBlock.Name = "titleBlock";
            titleBlock.Size = new Size(487, 47);
            titleBlock.TabIndex = 3;
            titleBlock.Text = "Enter your past positions";
            titleBlock.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(0, 31, 84);
            panel8.Dock = DockStyle.Bottom;
            panel8.Location = new Point(0, 826);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(5);
            panel8.Size = new Size(862, 50);
            panel8.TabIndex = 36;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 87);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5);
            panel2.Size = new Size(862, 739);
            panel2.TabIndex = 37;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(41, 128, 185);
            panel6.Controls.Add(tableLayoutPanel13);
            panel6.Controls.Add(panel9);
            panel6.Controls.Add(earlierPositionsDgv);
            panel6.Controls.Add(panel7);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(45, 5);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(5);
            panel6.Size = new Size(772, 638);
            panel6.TabIndex = 4;
            // 
            // tableLayoutPanel13
            // 
            tableLayoutPanel13.ColumnCount = 2;
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 476F));
            tableLayoutPanel13.Controls.Add(label25, 0, 3);
            tableLayoutPanel13.Controls.Add(label26, 0, 2);
            tableLayoutPanel13.Controls.Add(label27, 0, 1);
            tableLayoutPanel13.Controls.Add(positionTbx, 1, 0);
            tableLayoutPanel13.Controls.Add(label35, 0, 0);
            tableLayoutPanel13.Controls.Add(companyTbx, 1, 1);
            tableLayoutPanel13.Controls.Add(locationTbx, 1, 2);
            tableLayoutPanel13.Controls.Add(durationTbx, 1, 3);
            tableLayoutPanel13.Dock = DockStyle.Top;
            tableLayoutPanel13.Location = new Point(5, 344);
            tableLayoutPanel13.Name = "tableLayoutPanel13";
            tableLayoutPanel13.RowCount = 4;
            tableLayoutPanel13.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel13.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel13.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel13.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel13.Size = new Size(762, 249);
            tableLayoutPanel13.TabIndex = 81;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Century Gothic", 13.8F);
            label25.ForeColor = Color.White;
            label25.Location = new Point(3, 186);
            label25.Name = "label25";
            label25.Size = new Size(109, 27);
            label25.TabIndex = 43;
            label25.Text = "Duration";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Century Gothic", 13.8F);
            label26.ForeColor = Color.White;
            label26.Location = new Point(3, 124);
            label26.Name = "label26";
            label26.Size = new Size(112, 27);
            label26.TabIndex = 42;
            label26.Text = "Location";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Century Gothic", 13.8F);
            label27.ForeColor = Color.White;
            label27.Location = new Point(3, 62);
            label27.Name = "label27";
            label27.Size = new Size(127, 27);
            label27.TabIndex = 41;
            label27.Text = "Company";
            // 
            // positionTbx
            // 
            positionTbx.Dock = DockStyle.Fill;
            positionTbx.Font = new Font("Century Gothic", 13.8F);
            positionTbx.Location = new Point(289, 3);
            positionTbx.Name = "positionTbx";
            positionTbx.Size = new Size(470, 36);
            positionTbx.TabIndex = 40;
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Font = new Font("Century Gothic", 13.8F);
            label35.ForeColor = Color.White;
            label35.Location = new Point(3, 0);
            label35.Name = "label35";
            label35.Size = new Size(99, 27);
            label35.TabIndex = 34;
            label35.Text = "Position";
            // 
            // companyTbx
            // 
            companyTbx.Dock = DockStyle.Fill;
            companyTbx.Font = new Font("Century Gothic", 13.8F);
            companyTbx.Location = new Point(289, 65);
            companyTbx.Name = "companyTbx";
            companyTbx.Size = new Size(470, 36);
            companyTbx.TabIndex = 36;
            // 
            // locationTbx
            // 
            locationTbx.Dock = DockStyle.Fill;
            locationTbx.Font = new Font("Century Gothic", 13.8F);
            locationTbx.Location = new Point(289, 127);
            locationTbx.Name = "locationTbx";
            locationTbx.Size = new Size(470, 36);
            locationTbx.TabIndex = 37;
            // 
            // durationTbx
            // 
            durationTbx.Dock = DockStyle.Fill;
            durationTbx.Font = new Font("Century Gothic", 13.8F);
            durationTbx.Location = new Point(289, 189);
            durationTbx.Name = "durationTbx";
            durationTbx.Size = new Size(470, 36);
            durationTbx.TabIndex = 38;
            // 
            // panel9
            // 
            panel9.Controls.Add(warnning2EERespo);
            panel9.Controls.Add(warning1EEProfExp);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(5, 314);
            panel9.Name = "panel9";
            panel9.Size = new Size(762, 30);
            panel9.TabIndex = 80;
            // 
            // warnning2EERespo
            // 
            warnning2EERespo.AutoSize = true;
            warnning2EERespo.Dock = DockStyle.Right;
            warnning2EERespo.Font = new Font("Century Gothic", 13.8F);
            warnning2EERespo.ForeColor = Color.White;
            warnning2EERespo.Location = new Point(762, 0);
            warnning2EERespo.Name = "warnning2EERespo";
            warnning2EERespo.Size = new Size(0, 27);
            warnning2EERespo.TabIndex = 36;
            // 
            // warning1EEProfExp
            // 
            warning1EEProfExp.AutoSize = true;
            warning1EEProfExp.Dock = DockStyle.Left;
            warning1EEProfExp.Font = new Font("Century Gothic", 13.8F);
            warning1EEProfExp.ForeColor = Color.White;
            warning1EEProfExp.Location = new Point(0, 0);
            warning1EEProfExp.Name = "warning1EEProfExp";
            warning1EEProfExp.Size = new Size(0, 27);
            warning1EEProfExp.TabIndex = 35;
            // 
            // earlierPositionsDgv
            // 
            earlierPositionsDgv.AllowUserToAddRows = false;
            earlierPositionsDgv.AllowUserToDeleteRows = false;
            earlierPositionsDgv.AllowUserToResizeColumns = false;
            earlierPositionsDgv.AllowUserToResizeRows = false;
            earlierPositionsDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            earlierPositionsDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            earlierPositionsDgv.BackgroundColor = Color.FromArgb(216, 225, 233);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            earlierPositionsDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            earlierPositionsDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            earlierPositionsDgv.Columns.AddRange(new DataGridViewColumn[] { JobTitle, Company, Location, Duration });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            earlierPositionsDgv.DefaultCellStyle = dataGridViewCellStyle2;
            earlierPositionsDgv.Dock = DockStyle.Top;
            earlierPositionsDgv.Location = new Point(5, 73);
            earlierPositionsDgv.Name = "earlierPositionsDgv";
            earlierPositionsDgv.ReadOnly = true;
            earlierPositionsDgv.RowHeadersWidth = 51;
            earlierPositionsDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            earlierPositionsDgv.Size = new Size(762, 241);
            earlierPositionsDgv.TabIndex = 79;
            // 
            // JobTitle
            // 
            JobTitle.HeaderText = "Position";
            JobTitle.MinimumWidth = 6;
            JobTitle.Name = "JobTitle";
            JobTitle.ReadOnly = true;
            // 
            // Company
            // 
            Company.HeaderText = "Company";
            Company.MinimumWidth = 6;
            Company.Name = "Company";
            Company.ReadOnly = true;
            // 
            // Location
            // 
            Location.HeaderText = "Location";
            Location.MinimumWidth = 6;
            Location.Name = "Location";
            Location.ReadOnly = true;
            // 
            // Duration
            // 
            Duration.HeaderText = "Duration";
            Duration.MinimumWidth = 6;
            Duration.Name = "Duration";
            Duration.ReadOnly = true;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(0, 31, 84);
            panel7.Controls.Add(warningLbl);
            panel7.Controls.Add(label2);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(5, 5);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(10);
            panel7.Size = new Size(762, 68);
            panel7.TabIndex = 74;
            // 
            // warningLbl
            // 
            warningLbl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            warningLbl.AutoSize = true;
            warningLbl.Font = new Font("Century Gothic", 13.8F);
            warningLbl.ForeColor = Color.White;
            warningLbl.Location = new Point(650, 10);
            warningLbl.Name = "warningLbl";
            warningLbl.Size = new Size(0, 27);
            warningLbl.TabIndex = 35;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(10, 10);
            label2.Name = "label2";
            label2.Size = new Size(298, 47);
            label2.TabIndex = 8;
            label2.Text = "Earlier Position";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel5
            // 
            panel5.Controls.Add(tableLayoutPanel14);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(45, 643);
            panel5.Name = "panel5";
            panel5.Size = new Size(772, 91);
            panel5.TabIndex = 3;
            // 
            // tableLayoutPanel14
            // 
            tableLayoutPanel14.ColumnCount = 3;
            tableLayoutPanel14.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel14.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel14.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel14.Controls.Add(iconButton1, 2, 0);
            tableLayoutPanel14.Controls.Add(addExpBtn, 0, 0);
            tableLayoutPanel14.Controls.Add(removeExpBtn, 1, 0);
            tableLayoutPanel14.Dock = DockStyle.Top;
            tableLayoutPanel14.Location = new Point(0, 0);
            tableLayoutPanel14.Name = "tableLayoutPanel14";
            tableLayoutPanel14.Padding = new Padding(10);
            tableLayoutPanel14.RowCount = 1;
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel14.Size = new Size(772, 88);
            tableLayoutPanel14.TabIndex = 69;
            // 
            // iconButton1
            // 
            iconButton1.BackColor = Color.FromArgb(10, 17, 40);
            iconButton1.Dock = DockStyle.Fill;
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            iconButton1.ForeColor = Color.White;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.Check;
            iconButton1.IconColor = Color.White;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 38;
            iconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton1.Location = new Point(513, 13);
            iconButton1.Name = "iconButton1";
            iconButton1.Padding = new Padding(65, 0, 0, 0);
            iconButton1.Size = new Size(246, 62);
            iconButton1.TabIndex = 36;
            iconButton1.Text = "Done";
            iconButton1.TextAlign = ContentAlignment.MiddleLeft;
            iconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton1.UseVisualStyleBackColor = false;
            iconButton1.Click += btnSave_Click;
            // 
            // addExpBtn
            // 
            addExpBtn.BackColor = Color.FromArgb(10, 17, 40);
            addExpBtn.Dock = DockStyle.Fill;
            addExpBtn.FlatAppearance.BorderSize = 0;
            addExpBtn.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addExpBtn.ForeColor = Color.White;
            addExpBtn.IconChar = FontAwesome.Sharp.IconChar.Add;
            addExpBtn.IconColor = Color.White;
            addExpBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            addExpBtn.IconSize = 38;
            addExpBtn.ImageAlign = ContentAlignment.MiddleLeft;
            addExpBtn.Location = new Point(13, 13);
            addExpBtn.Name = "addExpBtn";
            addExpBtn.Padding = new Padding(65, 0, 0, 0);
            addExpBtn.Size = new Size(244, 62);
            addExpBtn.TabIndex = 1;
            addExpBtn.Text = "Add";
            addExpBtn.TextAlign = ContentAlignment.MiddleLeft;
            addExpBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            addExpBtn.UseVisualStyleBackColor = false;
            addExpBtn.Click += btnAdd_Click;
            // 
            // removeExpBtn
            // 
            removeExpBtn.BackColor = Color.IndianRed;
            removeExpBtn.Dock = DockStyle.Fill;
            removeExpBtn.FlatAppearance.BorderSize = 0;
            removeExpBtn.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            removeExpBtn.ForeColor = Color.White;
            removeExpBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            removeExpBtn.IconColor = Color.Black;
            removeExpBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            removeExpBtn.Location = new Point(263, 13);
            removeExpBtn.Name = "removeExpBtn";
            removeExpBtn.Size = new Size(244, 62);
            removeExpBtn.TabIndex = 35;
            removeExpBtn.Text = "Remove Selected";
            removeExpBtn.UseVisualStyleBackColor = false;
            removeExpBtn.Click += btnRemove_Click;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(817, 5);
            panel4.Name = "panel4";
            panel4.Size = new Size(40, 729);
            panel4.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(5, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(40, 729);
            panel3.TabIndex = 1;
            // 
            // EarlierPositionsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(862, 876);
            Controls.Add(panel2);
            Controls.Add(panel8);
            Controls.Add(panel1);
            Name = "EarlierPositionsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            tableLayoutPanel13.ResumeLayout(false);
            tableLayoutPanel13.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)earlierPositionsDgv).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel5.ResumeLayout(false);
            tableLayoutPanel14.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ComboBox comboBox1;
        private Label descLbl;
        private Label titleBlock;
        private Panel panel8;
        private Panel panel2;
        private Panel panel6;
        private Panel panel7;
        private Label label2;
        private Panel panel5;
        private TableLayoutPanel tableLayoutPanel14;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton addExpBtn;
        private FontAwesome.Sharp.IconButton removeExpBtn;
        private Panel panel4;
        private Panel panel3;
        private DataGridView earlierPositionsDgv;
        private DataGridViewTextBoxColumn JobTitle;
        private DataGridViewTextBoxColumn Company;
        private DataGridViewTextBoxColumn Location;
        private DataGridViewTextBoxColumn Duration;
        private Panel panel9;
        private Label warnning2EERespo;
        private Label warning1EEProfExp;
        private TableLayoutPanel tableLayoutPanel13;
        private Label label25;
        private Label label26;
        private Label label27;
        private TextBox positionTbx;
        private Label label35;
        private TextBox companyTbx;
        private TextBox locationTbx;
        private TextBox durationTbx;
        private Label warningLbl;
    }
}