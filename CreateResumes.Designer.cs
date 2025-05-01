namespace FinalProjectOOP2
{
    partial class CreateResumes
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
            panel6 = new Panel();
            saveResume = new FontAwesome.Sharp.IconButton();
            tableLayoutPanel3 = new TableLayoutPanel();
            panel2 = new Panel();
            loadResumeBtn = new FontAwesome.Sharp.IconButton();
            panel7 = new Panel();
            previewResume = new FontAwesome.Sharp.IconButton();
            panel8 = new Panel();
            userLbl = new Label();
            label1 = new Label();
            comboBox1 = new ComboBox();
            panel1 = new Panel();
            templatePanelCorner = new Panel();
            seeSampleBtn = new FontAwesome.Sharp.IconButton();
            label14 = new Label();
            templateSelector = new ComboBox();
            contentPanel = new Panel();
            templatePanel = new Panel();
            panel13 = new Panel();
            centerTemplateSelectorCbx = new ComboBox();
            panel12 = new Panel();
            panel5 = new Panel();
            titleLbl = new Label();
            panel6.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel2.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel1.SuspendLayout();
            templatePanelCorner.SuspendLayout();
            contentPanel.SuspendLayout();
            templatePanel.SuspendLayout();
            panel13.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(216, 225, 233);
            panel6.Controls.Add(saveResume);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(2, 2);
            panel6.Margin = new Padding(2);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(2);
            panel6.Size = new Size(499, 82);
            panel6.TabIndex = 8;
            // 
            // saveResume
            // 
            saveResume.BackColor = Color.FromArgb(41, 128, 185);
            saveResume.Cursor = Cursors.Hand;
            saveResume.Dock = DockStyle.Fill;
            saveResume.FlatAppearance.BorderSize = 0;
            saveResume.FlatStyle = FlatStyle.Flat;
            saveResume.Font = new Font("Century Gothic", 13.8F);
            saveResume.ForeColor = Color.White;
            saveResume.IconChar = FontAwesome.Sharp.IconChar.Save;
            saveResume.IconColor = Color.FromArgb(216, 225, 233);
            saveResume.IconFont = FontAwesome.Sharp.IconFont.Auto;
            saveResume.IconSize = 50;
            saveResume.ImageAlign = ContentAlignment.MiddleLeft;
            saveResume.Location = new Point(2, 2);
            saveResume.Margin = new Padding(2);
            saveResume.Name = "saveResume";
            saveResume.Padding = new Padding(100, 0, 0, 0);
            saveResume.Size = new Size(495, 78);
            saveResume.TabIndex = 23;
            saveResume.Text = " Save Information";
            saveResume.TextAlign = ContentAlignment.MiddleLeft;
            saveResume.TextImageRelation = TextImageRelation.ImageBeforeText;
            saveResume.UseVisualStyleBackColor = false;
            saveResume.Click += saveResume_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Controls.Add(panel2, 2, 0);
            tableLayoutPanel3.Controls.Add(panel7, 1, 0);
            tableLayoutPanel3.Controls.Add(panel6, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(1510, 86);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(216, 225, 233);
            panel2.Controls.Add(loadResumeBtn);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(1008, 2);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(2);
            panel2.Size = new Size(500, 82);
            panel2.TabIndex = 10;
            // 
            // loadResumeBtn
            // 
            loadResumeBtn.BackColor = Color.FromArgb(41, 128, 185);
            loadResumeBtn.Cursor = Cursors.Hand;
            loadResumeBtn.Dock = DockStyle.Fill;
            loadResumeBtn.FlatAppearance.BorderSize = 0;
            loadResumeBtn.FlatStyle = FlatStyle.Flat;
            loadResumeBtn.Font = new Font("Century Gothic", 13.8F);
            loadResumeBtn.ForeColor = Color.White;
            loadResumeBtn.IconChar = FontAwesome.Sharp.IconChar.Server;
            loadResumeBtn.IconColor = Color.FromArgb(216, 225, 233);
            loadResumeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            loadResumeBtn.IconSize = 50;
            loadResumeBtn.ImageAlign = ContentAlignment.MiddleLeft;
            loadResumeBtn.Location = new Point(2, 2);
            loadResumeBtn.Margin = new Padding(2);
            loadResumeBtn.Name = "loadResumeBtn";
            loadResumeBtn.Padding = new Padding(130, 0, 0, 0);
            loadResumeBtn.Size = new Size(496, 78);
            loadResumeBtn.TabIndex = 24;
            loadResumeBtn.Text = " Load Resume";
            loadResumeBtn.TextAlign = ContentAlignment.MiddleLeft;
            loadResumeBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            loadResumeBtn.UseVisualStyleBackColor = false;
            loadResumeBtn.Click += loadResumeBtn_Click;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(216, 225, 233);
            panel7.Controls.Add(previewResume);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(505, 2);
            panel7.Margin = new Padding(2);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(2);
            panel7.Size = new Size(499, 82);
            panel7.TabIndex = 9;
            // 
            // previewResume
            // 
            previewResume.BackColor = Color.FromArgb(41, 128, 185);
            previewResume.Cursor = Cursors.Hand;
            previewResume.Dock = DockStyle.Fill;
            previewResume.FlatAppearance.BorderSize = 0;
            previewResume.FlatStyle = FlatStyle.Flat;
            previewResume.Font = new Font("Century Gothic", 13.8F);
            previewResume.ForeColor = Color.White;
            previewResume.IconChar = FontAwesome.Sharp.IconChar.Eye;
            previewResume.IconColor = Color.FromArgb(216, 225, 233);
            previewResume.IconFont = FontAwesome.Sharp.IconFont.Auto;
            previewResume.IconSize = 50;
            previewResume.ImageAlign = ContentAlignment.MiddleLeft;
            previewResume.Location = new Point(2, 2);
            previewResume.Margin = new Padding(2);
            previewResume.Name = "previewResume";
            previewResume.Padding = new Padding(110, 0, 0, 0);
            previewResume.Size = new Size(495, 78);
            previewResume.TabIndex = 23;
            previewResume.Text = " Preview Resume";
            previewResume.TextAlign = ContentAlignment.MiddleLeft;
            previewResume.TextImageRelation = TextImageRelation.ImageBeforeText;
            previewResume.UseVisualStyleBackColor = false;
            previewResume.Click += previewResume_Click;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(0, 31, 84);
            panel8.Controls.Add(tableLayoutPanel3);
            panel8.Dock = DockStyle.Bottom;
            panel8.Location = new Point(0, 764);
            panel8.Name = "panel8";
            panel8.Size = new Size(1510, 86);
            panel8.TabIndex = 34;
            // 
            // userLbl
            // 
            userLbl.AutoSize = true;
            userLbl.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userLbl.ForeColor = Color.White;
            userLbl.Location = new Point(10, 10);
            userLbl.Name = "userLbl";
            userLbl.Size = new Size(357, 47);
            userLbl.TabIndex = 3;
            userLbl.Text = "Create a Resume";
            userLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(10, 57);
            label1.Name = "label1";
            label1.Size = new Size(366, 27);
            label1.TabIndex = 4;
            label1.Text = "\"Create a resume for your work\"";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(687, 29);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(0, 28);
            comboBox1.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 128, 185);
            panel1.Controls.Add(templatePanelCorner);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(userLbl);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10, 10, 0, 0);
            panel1.Size = new Size(1510, 106);
            panel1.TabIndex = 25;
            // 
            // templatePanelCorner
            // 
            templatePanelCorner.BackColor = Color.FromArgb(10, 17, 40);
            templatePanelCorner.Controls.Add(seeSampleBtn);
            templatePanelCorner.Controls.Add(label14);
            templatePanelCorner.Controls.Add(templateSelector);
            templatePanelCorner.Location = new Point(1108, 0);
            templatePanelCorner.Name = "templatePanelCorner";
            templatePanelCorner.Size = new Size(402, 106);
            templatePanelCorner.TabIndex = 7;
            // 
            // seeSampleBtn
            // 
            seeSampleBtn.BackColor = Color.FromArgb(10, 17, 40);
            seeSampleBtn.FlatAppearance.BorderSize = 0;
            seeSampleBtn.FlatStyle = FlatStyle.Flat;
            seeSampleBtn.ForeColor = Color.White;
            seeSampleBtn.IconChar = FontAwesome.Sharp.IconChar.Eye;
            seeSampleBtn.IconColor = Color.White;
            seeSampleBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            seeSampleBtn.Location = new Point(13, 43);
            seeSampleBtn.Name = "seeSampleBtn";
            seeSampleBtn.Size = new Size(43, 44);
            seeSampleBtn.TabIndex = 5;
            seeSampleBtn.UseVisualStyleBackColor = false;
            seeSampleBtn.Click += seeSampleBtn_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Dock = DockStyle.Top;
            label14.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.FromArgb(216, 225, 233);
            label14.Location = new Point(0, 0);
            label14.Name = "label14";
            label14.Size = new Size(129, 27);
            label14.TabIndex = 4;
            label14.Text = "Template :";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // templateSelector
            // 
            templateSelector.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            templateSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            templateSelector.Font = new Font("Century Gothic", 13.8F);
            templateSelector.FormattingEnabled = true;
            templateSelector.Items.AddRange(new object[] { "Attorney Resume", "Call Center Resume", "Doctor Resume", "Electrical Engineer Resume" });
            templateSelector.Location = new Point(66, 45);
            templateSelector.Name = "templateSelector";
            templateSelector.Size = new Size(327, 35);
            templateSelector.Sorted = true;
            templateSelector.TabIndex = 0;
            templateSelector.SelectedIndexChanged += templateSelector_SelectedIndexChanged;
            // 
            // contentPanel
            // 
            contentPanel.Controls.Add(templatePanel);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 106);
            contentPanel.Margin = new Padding(0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1510, 658);
            contentPanel.TabIndex = 35;
            // 
            // templatePanel
            // 
            templatePanel.Controls.Add(panel13);
            templatePanel.Controls.Add(panel12);
            templatePanel.Controls.Add(panel5);
            templatePanel.Location = new Point(403, 140);
            templatePanel.Name = "templatePanel";
            templatePanel.Size = new Size(603, 317);
            templatePanel.TabIndex = 0;
            // 
            // panel13
            // 
            panel13.BackColor = Color.FromArgb(254, 252, 251);
            panel13.Controls.Add(centerTemplateSelectorCbx);
            panel13.Dock = DockStyle.Fill;
            panel13.Location = new Point(0, 69);
            panel13.Name = "panel13";
            panel13.Size = new Size(603, 232);
            panel13.TabIndex = 29;
            // 
            // centerTemplateSelectorCbx
            // 
            centerTemplateSelectorCbx.DropDownStyle = ComboBoxStyle.DropDownList;
            centerTemplateSelectorCbx.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            centerTemplateSelectorCbx.FormattingEnabled = true;
            centerTemplateSelectorCbx.Items.AddRange(new object[] { "Attorney Resume", "Call Center Resume", "Doctor Resume", "Electrical Engineer Resume" });
            centerTemplateSelectorCbx.Location = new Point(87, 78);
            centerTemplateSelectorCbx.Name = "centerTemplateSelectorCbx";
            centerTemplateSelectorCbx.Size = new Size(424, 48);
            centerTemplateSelectorCbx.Sorted = true;
            centerTemplateSelectorCbx.TabIndex = 3;
            centerTemplateSelectorCbx.SelectionChangeCommitted += centerTemplateSelectorCbx_SelectedIndexChanged;
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(0, 31, 84);
            panel12.Dock = DockStyle.Bottom;
            panel12.Location = new Point(0, 301);
            panel12.Name = "panel12";
            panel12.Padding = new Padding(10, 10, 0, 0);
            panel12.Size = new Size(603, 16);
            panel12.TabIndex = 28;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(41, 128, 185);
            panel5.Controls.Add(titleLbl);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(10);
            panel5.Size = new Size(603, 69);
            panel5.TabIndex = 26;
            // 
            // titleLbl
            // 
            titleLbl.BackColor = Color.Transparent;
            titleLbl.Dock = DockStyle.Fill;
            titleLbl.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLbl.ForeColor = Color.White;
            titleLbl.Location = new Point(10, 10);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(583, 49);
            titleLbl.TabIndex = 22;
            titleLbl.Text = "Select a template :";
            // 
            // CreateResumes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(216, 225, 233);
            Controls.Add(contentPanel);
            Controls.Add(panel8);
            Controls.Add(panel1);
            Margin = new Padding(0);
            Name = "CreateResumes";
            Size = new Size(1510, 850);
            panel6.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            templatePanelCorner.ResumeLayout(false);
            templatePanelCorner.PerformLayout();
            contentPanel.ResumeLayout(false);
            templatePanel.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel6;
        private FontAwesome.Sharp.IconButton saveResume;
        private Panel panel8;
        private Label userLbl;
        private Label label1;
        private ComboBox comboBox1;
        private Panel panel1;
        private Panel templatePanelCorner;
        private Label label14;
        private ComboBox templateSelector;
        public Panel contentPanel;
        private Panel templatePanel;
        private Panel panel5;
        private Label titleLbl;
        private Panel panel12;
        private Panel panel13;
        private ComboBox centerTemplateSelectorCbx;
        private Panel panel2;
        private Panel panel7;
        private FontAwesome.Sharp.IconButton previewResume;
        private FontAwesome.Sharp.IconButton loadResumeBtn;
        private FontAwesome.Sharp.IconButton seeSampleBtn;
    }
}
