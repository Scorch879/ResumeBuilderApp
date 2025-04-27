namespace FinalProjectOOP2
{
    partial class TitleInputDialog
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
            templatePanel = new Panel();
            panel13 = new Panel();
            tableLayoutPanel14 = new TableLayoutPanel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            removeExpBtn = new FontAwesome.Sharp.IconButton();
            resumeTitleTbx = new TextBox();
            panel1.SuspendLayout();
            templatePanel.SuspendLayout();
            panel13.SuspendLayout();
            tableLayoutPanel14.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 128, 185);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(descLbl);
            panel1.Controls.Add(titleBlock);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10, 10, 0, 0);
            panel1.Size = new Size(725, 87);
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
            titleBlock.Size = new Size(465, 47);
            titleBlock.TabIndex = 3;
            titleBlock.Text = "Enter your Resume Title";
            titleBlock.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // templatePanel
            // 
            templatePanel.Controls.Add(panel13);
            templatePanel.Dock = DockStyle.Fill;
            templatePanel.Location = new Point(0, 87);
            templatePanel.Name = "templatePanel";
            templatePanel.Size = new Size(725, 232);
            templatePanel.TabIndex = 39;
            // 
            // panel13
            // 
            panel13.BackColor = Color.Transparent;
            panel13.Controls.Add(tableLayoutPanel14);
            panel13.Controls.Add(resumeTitleTbx);
            panel13.Dock = DockStyle.Fill;
            panel13.Location = new Point(0, 0);
            panel13.Name = "panel13";
            panel13.Size = new Size(725, 232);
            panel13.TabIndex = 29;
            // 
            // tableLayoutPanel14
            // 
            tableLayoutPanel14.ColumnCount = 2;
            tableLayoutPanel14.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel14.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel14.Controls.Add(iconButton1, 0, 0);
            tableLayoutPanel14.Controls.Add(removeExpBtn, 1, 0);
            tableLayoutPanel14.Dock = DockStyle.Bottom;
            tableLayoutPanel14.Location = new Point(0, 144);
            tableLayoutPanel14.Name = "tableLayoutPanel14";
            tableLayoutPanel14.Padding = new Padding(5);
            tableLayoutPanel14.RowCount = 1;
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel14.Size = new Size(725, 88);
            tableLayoutPanel14.TabIndex = 70;
            // 
            // iconButton1
            // 
            iconButton1.BackColor = Color.FromArgb(10, 17, 40);
            iconButton1.Dock = DockStyle.Fill;
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            iconButton1.ForeColor = Color.White;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(8, 8);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(351, 72);
            iconButton1.TabIndex = 36;
            iconButton1.Text = "OK";
            iconButton1.UseVisualStyleBackColor = false;
            iconButton1.Click += btnOK_Click;
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
            removeExpBtn.Location = new Point(365, 8);
            removeExpBtn.Name = "removeExpBtn";
            removeExpBtn.Size = new Size(352, 72);
            removeExpBtn.TabIndex = 35;
            removeExpBtn.Text = "CANCEL";
            removeExpBtn.UseVisualStyleBackColor = false;
            removeExpBtn.Click += btnCancel_Click;
            // 
            // resumeTitleTbx
            // 
            resumeTitleTbx.BackColor = Color.White;
            resumeTitleTbx.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            resumeTitleTbx.Location = new Point(42, 49);
            resumeTitleTbx.Name = "resumeTitleTbx";
            resumeTitleTbx.Size = new Size(645, 44);
            resumeTitleTbx.TabIndex = 35;
            // 
            // TitleInputDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(725, 319);
            Controls.Add(templatePanel);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "TitleInputDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Resume Title";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            templatePanel.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            tableLayoutPanel14.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ComboBox comboBox1;
        private Label descLbl;
        private Label titleBlock;
        private Panel templatePanel;
        private Panel panel13;
        private TextBox resumeTitleTbx;
        private TableLayoutPanel tableLayoutPanel14;
        private FontAwesome.Sharp.IconButton removeExpBtn;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}