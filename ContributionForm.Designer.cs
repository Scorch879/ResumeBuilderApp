namespace FinalProjectOOP2
{
    partial class ContributionForm
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
            comboBox1 = new ComboBox();
            descLbl = new Label();
            titleBlock = new Label();
            panel8 = new Panel();
            panel2 = new Panel();
            panel6 = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            label3 = new Label();
            contributionTextBox = new TextBox();
            panel9 = new Panel();
            warnning2EERespo = new Label();
            warning1EEProfExp = new Label();
            contributionsListBox = new ListBox();
            panel7 = new Panel();
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
            tableLayoutPanel3.SuspendLayout();
            panel9.SuspendLayout();
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
            panel1.Size = new Size(852, 87);
            panel1.TabIndex = 26;
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
            descLbl.Location = new Point(20, 56);
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
            titleBlock.Location = new Point(20, 18);
            titleBlock.Name = "titleBlock";
            titleBlock.Size = new Size(475, 47);
            titleBlock.TabIndex = 3;
            titleBlock.Text = "Enter your contributions";
            titleBlock.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(0, 31, 84);
            panel8.Dock = DockStyle.Bottom;
            panel8.Location = new Point(0, 676);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(5);
            panel8.Size = new Size(852, 50);
            panel8.TabIndex = 35;
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
            panel2.Size = new Size(852, 589);
            panel2.TabIndex = 36;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(41, 128, 185);
            panel6.Controls.Add(tableLayoutPanel3);
            panel6.Controls.Add(panel9);
            panel6.Controls.Add(contributionsListBox);
            panel6.Controls.Add(panel7);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(45, 5);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(5);
            panel6.Size = new Size(762, 488);
            panel6.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.1308765F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68.8691254F));
            tableLayoutPanel3.Controls.Add(label3, 0, 0);
            tableLayoutPanel3.Controls.Add(contributionTextBox, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Top;
            tableLayoutPanel3.Location = new Point(5, 358);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(752, 116);
            tableLayoutPanel3.TabIndex = 78;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 13.8F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(227, 54);
            label3.TabIndex = 75;
            label3.Text = "Contributions (Add one at a time)";
            // 
            // contributionTextBox
            // 
            contributionTextBox.Dock = DockStyle.Fill;
            contributionTextBox.Font = new Font("Century Gothic", 13.8F);
            contributionTextBox.Location = new Point(237, 3);
            contributionTextBox.Multiline = true;
            contributionTextBox.Name = "contributionTextBox";
            contributionTextBox.Size = new Size(512, 110);
            contributionTextBox.TabIndex = 74;
            // 
            // panel9
            // 
            panel9.Controls.Add(warnning2EERespo);
            panel9.Controls.Add(warning1EEProfExp);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(5, 337);
            panel9.Name = "panel9";
            panel9.Size = new Size(752, 21);
            panel9.TabIndex = 77;
            // 
            // warnning2EERespo
            // 
            warnning2EERespo.AutoSize = true;
            warnning2EERespo.Dock = DockStyle.Right;
            warnning2EERespo.Font = new Font("Century Gothic", 13.8F);
            warnning2EERespo.ForeColor = Color.White;
            warnning2EERespo.Location = new Point(752, 0);
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
            // contributionsListBox
            // 
            contributionsListBox.Dock = DockStyle.Top;
            contributionsListBox.FormattingEnabled = true;
            contributionsListBox.Location = new Point(5, 73);
            contributionsListBox.Name = "contributionsListBox";
            contributionsListBox.SelectionMode = SelectionMode.MultiExtended;
            contributionsListBox.Size = new Size(752, 264);
            contributionsListBox.TabIndex = 75;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(0, 31, 84);
            panel7.Controls.Add(label2);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(5, 5);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(10);
            panel7.Size = new Size(752, 68);
            panel7.TabIndex = 74;
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
            label2.Size = new Size(393, 47);
            label2.TabIndex = 8;
            label2.Text = "List of Contributions";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel5
            // 
            panel5.Controls.Add(tableLayoutPanel14);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(45, 493);
            panel5.Name = "panel5";
            panel5.Size = new Size(762, 91);
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
            tableLayoutPanel14.Size = new Size(762, 88);
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
            iconButton1.Location = new Point(507, 13);
            iconButton1.Name = "iconButton1";
            iconButton1.Padding = new Padding(65, 0, 0, 0);
            iconButton1.Size = new Size(242, 62);
            iconButton1.TabIndex = 36;
            iconButton1.Text = "Done";
            iconButton1.TextAlign = ContentAlignment.MiddleLeft;
            iconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton1.UseVisualStyleBackColor = false;
            iconButton1.Click += okBtn_Click;
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
            addExpBtn.Size = new Size(241, 62);
            addExpBtn.TabIndex = 1;
            addExpBtn.Text = "Add";
            addExpBtn.TextAlign = ContentAlignment.MiddleLeft;
            addExpBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            addExpBtn.UseVisualStyleBackColor = false;
            addExpBtn.Click += addBtn_Click;
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
            removeExpBtn.Location = new Point(260, 13);
            removeExpBtn.Name = "removeExpBtn";
            removeExpBtn.Size = new Size(241, 62);
            removeExpBtn.TabIndex = 35;
            removeExpBtn.Text = "Remove Selected";
            removeExpBtn.UseVisualStyleBackColor = false;
            removeExpBtn.Click += removeBtn_Click;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(807, 5);
            panel4.Name = "panel4";
            panel4.Size = new Size(40, 579);
            panel4.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(5, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(40, 579);
            panel3.TabIndex = 1;
            // 
            // ContributionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(216, 225, 233);
            ClientSize = new Size(852, 726);
            Controls.Add(panel2);
            Controls.Add(panel8);
            Controls.Add(panel1);
            Name = "ContributionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Contributions";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
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
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel14;
        private FontAwesome.Sharp.IconButton addExpBtn;
        private FontAwesome.Sharp.IconButton removeExpBtn;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Panel panel6;
        private Panel panel7;
        private Label label2;
        private ListBox contributionsListBox;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label3;
        private TextBox contributionTextBox;
        private Panel panel9;
        private Label warnning2EERespo;
        private Label warning1EEProfExp;
    }
}