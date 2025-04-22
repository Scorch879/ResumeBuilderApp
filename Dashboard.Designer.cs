namespace FinalProjectOOP2
{
    partial class Dashboard
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            panel1 = new Panel();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            pictureBox1 = new PictureBox();
            sidePanel = new Panel();
            sideLayoutTable = new TableLayoutPanel();
            messagesBtn = new FontAwesome.Sharp.IconButton();
            profileBtn = new FontAwesome.Sharp.IconButton();
            createResumeBtn = new FontAwesome.Sharp.IconButton();
            myResumeBtn = new FontAwesome.Sharp.IconButton();
            homeBtn = new FontAwesome.Sharp.IconButton();
            resumeIcon = new PictureBox();
            logoutBtn = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            label8 = new Label();
            label4 = new Label();
            highlightTimer = new System.Windows.Forms.Timer(components);
            headerPanel = new Panel();
            minimizeBtn = new FontAwesome.Sharp.IconPictureBox();
            maximizeBtn = new FontAwesome.Sharp.IconPictureBox();
            closeBtn = new FontAwesome.Sharp.IconPictureBox();
            mainPanel = new FlowLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            sidePanel.SuspendLayout();
            sideLayoutTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)resumeIcon).BeginInit();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)minimizeBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maximizeBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeBtn).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(41, 128, 185);
            panel1.Controls.Add(iconButton2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(0, 955);
            panel1.TabIndex = 12;
            // 
            // iconButton2
            // 
            iconButton2.BackColor = Color.FromArgb(41, 128, 185);
            iconButton2.Dock = DockStyle.Top;
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.Font = new Font("Century Gothic", 15F);
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            iconButton2.IconColor = Color.Black;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.Location = new Point(0, 251);
            iconButton2.Name = "iconButton2";
            iconButton2.Padding = new Padding(50, 0, 0, 0);
            iconButton2.Size = new Size(0, 99);
            iconButton2.TabIndex = 7;
            iconButton2.Text = " Home";
            iconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton2.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = Properties.Resources.online_job_application_chalk_icon_job_search_website_online_resume_builder_cv_maker_recruitment_website_isolated_chalkboard_illustration_vector;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(0, 251);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // sidePanel
            // 
            sidePanel.BackColor = Color.FromArgb(41, 128, 185);
            sidePanel.Controls.Add(sideLayoutTable);
            sidePanel.Controls.Add(label1);
            sidePanel.Controls.Add(label8);
            sidePanel.Controls.Add(label4);
            sidePanel.Dock = DockStyle.Left;
            sidePanel.Location = new Point(0, 0);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(309, 955);
            sidePanel.TabIndex = 16;
            // 
            // sideLayoutTable
            // 
            sideLayoutTable.ColumnCount = 1;
            sideLayoutTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            sideLayoutTable.Controls.Add(messagesBtn, 0, 5);
            sideLayoutTable.Controls.Add(profileBtn, 0, 4);
            sideLayoutTable.Controls.Add(createResumeBtn, 0, 3);
            sideLayoutTable.Controls.Add(myResumeBtn, 0, 2);
            sideLayoutTable.Controls.Add(homeBtn, 0, 1);
            sideLayoutTable.Controls.Add(resumeIcon, 0, 0);
            sideLayoutTable.Controls.Add(logoutBtn, 0, 10);
            sideLayoutTable.Dock = DockStyle.Left;
            sideLayoutTable.Location = new Point(0, 0);
            sideLayoutTable.Name = "sideLayoutTable";
            sideLayoutTable.RowCount = 12;
            sideLayoutTable.RowStyles.Add(new RowStyle());
            sideLayoutTable.RowStyles.Add(new RowStyle());
            sideLayoutTable.RowStyles.Add(new RowStyle());
            sideLayoutTable.RowStyles.Add(new RowStyle());
            sideLayoutTable.RowStyles.Add(new RowStyle());
            sideLayoutTable.RowStyles.Add(new RowStyle());
            sideLayoutTable.RowStyles.Add(new RowStyle());
            sideLayoutTable.RowStyles.Add(new RowStyle());
            sideLayoutTable.RowStyles.Add(new RowStyle());
            sideLayoutTable.RowStyles.Add(new RowStyle());
            sideLayoutTable.RowStyles.Add(new RowStyle());
            sideLayoutTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            sideLayoutTable.Size = new Size(309, 955);
            sideLayoutTable.TabIndex = 17;
            // 
            // messagesBtn
            // 
            messagesBtn.BackColor = Color.FromArgb(41, 128, 185);
            messagesBtn.Dock = DockStyle.Top;
            messagesBtn.FlatAppearance.BorderSize = 0;
            messagesBtn.FlatStyle = FlatStyle.Flat;
            messagesBtn.Font = new Font("Century Gothic", 13.8F);
            messagesBtn.ForeColor = Color.White;
            messagesBtn.IconChar = FontAwesome.Sharp.IconChar.Envelope;
            messagesBtn.IconColor = Color.FromArgb(216, 225, 233);
            messagesBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            messagesBtn.IconSize = 50;
            messagesBtn.ImageAlign = ContentAlignment.MiddleLeft;
            messagesBtn.Location = new Point(3, 561);
            messagesBtn.Name = "messagesBtn";
            messagesBtn.Padding = new Padding(30, 0, 0, 0);
            messagesBtn.Size = new Size(303, 67);
            messagesBtn.TabIndex = 38;
            messagesBtn.Text = " Messages";
            messagesBtn.TextAlign = ContentAlignment.MiddleLeft;
            messagesBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            messagesBtn.UseVisualStyleBackColor = false;
            messagesBtn.Click += messagesBtn_Click;
            // 
            // profileBtn
            // 
            profileBtn.BackColor = Color.FromArgb(41, 128, 185);
            profileBtn.Dock = DockStyle.Top;
            profileBtn.FlatAppearance.BorderSize = 0;
            profileBtn.FlatStyle = FlatStyle.Flat;
            profileBtn.Font = new Font("Century Gothic", 13.8F);
            profileBtn.ForeColor = Color.White;
            profileBtn.IconChar = FontAwesome.Sharp.IconChar.User;
            profileBtn.IconColor = Color.FromArgb(216, 225, 233);
            profileBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            profileBtn.IconSize = 50;
            profileBtn.ImageAlign = ContentAlignment.MiddleLeft;
            profileBtn.Location = new Point(3, 488);
            profileBtn.Name = "profileBtn";
            profileBtn.Padding = new Padding(30, 0, 0, 0);
            profileBtn.Size = new Size(303, 67);
            profileBtn.TabIndex = 24;
            profileBtn.Text = " Profile";
            profileBtn.TextAlign = ContentAlignment.MiddleLeft;
            profileBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            profileBtn.UseVisualStyleBackColor = false;
            profileBtn.Click += profileBtn_Click;
            // 
            // createResumeBtn
            // 
            createResumeBtn.BackColor = Color.FromArgb(41, 128, 185);
            createResumeBtn.Dock = DockStyle.Top;
            createResumeBtn.FlatAppearance.BorderSize = 0;
            createResumeBtn.FlatStyle = FlatStyle.Flat;
            createResumeBtn.Font = new Font("Century Gothic", 13.8F);
            createResumeBtn.ForeColor = Color.White;
            createResumeBtn.IconChar = FontAwesome.Sharp.IconChar.Add;
            createResumeBtn.IconColor = Color.FromArgb(216, 225, 233);
            createResumeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            createResumeBtn.IconSize = 50;
            createResumeBtn.ImageAlign = ContentAlignment.MiddleLeft;
            createResumeBtn.Location = new Point(3, 415);
            createResumeBtn.Name = "createResumeBtn";
            createResumeBtn.Padding = new Padding(30, 0, 0, 0);
            createResumeBtn.Size = new Size(303, 67);
            createResumeBtn.TabIndex = 23;
            createResumeBtn.Text = " Create Resume";
            createResumeBtn.TextAlign = ContentAlignment.MiddleLeft;
            createResumeBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            createResumeBtn.UseVisualStyleBackColor = false;
            createResumeBtn.Click += createResumeBtn_Click;
            // 
            // myResumeBtn
            // 
            myResumeBtn.BackColor = Color.FromArgb(41, 128, 185);
            myResumeBtn.Dock = DockStyle.Top;
            myResumeBtn.FlatAppearance.BorderSize = 0;
            myResumeBtn.FlatStyle = FlatStyle.Flat;
            myResumeBtn.Font = new Font("Century Gothic", 13.8F);
            myResumeBtn.ForeColor = Color.White;
            myResumeBtn.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            myResumeBtn.IconColor = Color.FromArgb(216, 225, 233);
            myResumeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            myResumeBtn.IconSize = 50;
            myResumeBtn.ImageAlign = ContentAlignment.MiddleLeft;
            myResumeBtn.Location = new Point(3, 342);
            myResumeBtn.Name = "myResumeBtn";
            myResumeBtn.Padding = new Padding(30, 0, 0, 0);
            myResumeBtn.Size = new Size(303, 67);
            myResumeBtn.TabIndex = 22;
            myResumeBtn.Text = " My Resumes";
            myResumeBtn.TextAlign = ContentAlignment.MiddleLeft;
            myResumeBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            myResumeBtn.UseVisualStyleBackColor = false;
            myResumeBtn.Click += myResumeBtn_Click;
            // 
            // homeBtn
            // 
            homeBtn.BackColor = Color.FromArgb(41, 128, 185);
            homeBtn.Dock = DockStyle.Top;
            homeBtn.FlatAppearance.BorderSize = 0;
            homeBtn.FlatStyle = FlatStyle.Flat;
            homeBtn.Font = new Font("Century Gothic", 13.8F);
            homeBtn.ForeColor = Color.White;
            homeBtn.IconChar = FontAwesome.Sharp.IconChar.HomeUser;
            homeBtn.IconColor = Color.FromArgb(216, 225, 233);
            homeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            homeBtn.IconSize = 50;
            homeBtn.ImageAlign = ContentAlignment.MiddleLeft;
            homeBtn.Location = new Point(3, 269);
            homeBtn.Name = "homeBtn";
            homeBtn.Padding = new Padding(30, 0, 0, 0);
            homeBtn.Size = new Size(303, 67);
            homeBtn.TabIndex = 21;
            homeBtn.Text = " Home";
            homeBtn.TextAlign = ContentAlignment.MiddleLeft;
            homeBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            homeBtn.UseVisualStyleBackColor = false;
            homeBtn.Click += homeBtn_Click;
            // 
            // resumeIcon
            // 
            resumeIcon.Dock = DockStyle.Top;
            resumeIcon.Image = (Image)resources.GetObject("resumeIcon.Image");
            resumeIcon.Location = new Point(3, 3);
            resumeIcon.Name = "resumeIcon";
            resumeIcon.Size = new Size(303, 260);
            resumeIcon.SizeMode = PictureBoxSizeMode.Zoom;
            resumeIcon.TabIndex = 20;
            resumeIcon.TabStop = false;
            // 
            // logoutBtn
            // 
            logoutBtn.BackColor = Color.FromArgb(41, 128, 185);
            logoutBtn.Dock = DockStyle.Top;
            logoutBtn.FlatAppearance.BorderSize = 0;
            logoutBtn.FlatStyle = FlatStyle.Flat;
            logoutBtn.Font = new Font("Century Gothic", 13.8F);
            logoutBtn.ForeColor = Color.White;
            logoutBtn.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            logoutBtn.IconColor = Color.FromArgb(216, 225, 233);
            logoutBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            logoutBtn.IconSize = 50;
            logoutBtn.ImageAlign = ContentAlignment.MiddleLeft;
            logoutBtn.Location = new Point(3, 634);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Padding = new Padding(30, 0, 0, 0);
            logoutBtn.Size = new Size(303, 67);
            logoutBtn.TabIndex = 36;
            logoutBtn.Text = " Logout";
            logoutBtn.TextAlign = ContentAlignment.MiddleLeft;
            logoutBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            logoutBtn.UseVisualStyleBackColor = false;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(645, 552);
            label1.Name = "label1";
            label1.Size = new Size(113, 17);
            label1.TabIndex = 14;
            label1.Text = "Jobert Gamboa";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(682, 535);
            label8.Name = "label8";
            label8.Size = new Size(80, 17);
            label8.TabIndex = 13;
            label8.Text = "Project by: ";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(680, 301);
            label4.Name = "label4";
            label4.Size = new Size(78, 37);
            label4.TabIndex = 11;
            label4.Text = "App";
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(0, 31, 84);
            headerPanel.Controls.Add(minimizeBtn);
            headerPanel.Controls.Add(maximizeBtn);
            headerPanel.Controls.Add(closeBtn);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.ForeColor = Color.FromArgb(41, 128, 185);
            headerPanel.Location = new Point(309, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1557, 48);
            headerPanel.TabIndex = 22;
            // 
            // minimizeBtn
            // 
            minimizeBtn.BackColor = Color.Transparent;
            minimizeBtn.Cursor = Cursors.Hand;
            minimizeBtn.Dock = DockStyle.Right;
            minimizeBtn.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            minimizeBtn.IconColor = Color.White;
            minimizeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            minimizeBtn.IconSize = 28;
            minimizeBtn.Location = new Point(1465, 0);
            minimizeBtn.Margin = new Padding(3, 4, 3, 4);
            minimizeBtn.Name = "minimizeBtn";
            minimizeBtn.Size = new Size(28, 48);
            minimizeBtn.SizeMode = PictureBoxSizeMode.CenterImage;
            minimizeBtn.TabIndex = 30;
            minimizeBtn.TabStop = false;
            minimizeBtn.Click += minimizeBtn_Click;
            minimizeBtn.MouseEnter += MinimizeBtn_MouseEnter;
            minimizeBtn.MouseLeave += MinimizeBtn_MouseLeave;
            // 
            // maximizeBtn
            // 
            maximizeBtn.BackColor = Color.Transparent;
            maximizeBtn.Cursor = Cursors.Hand;
            maximizeBtn.Dock = DockStyle.Right;
            maximizeBtn.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            maximizeBtn.IconColor = Color.White;
            maximizeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            maximizeBtn.IconSize = 35;
            maximizeBtn.Location = new Point(1493, 0);
            maximizeBtn.Margin = new Padding(0);
            maximizeBtn.Name = "maximizeBtn";
            maximizeBtn.Size = new Size(35, 48);
            maximizeBtn.SizeMode = PictureBoxSizeMode.Zoom;
            maximizeBtn.TabIndex = 29;
            maximizeBtn.TabStop = false;
            maximizeBtn.Click += maximizeBtn_Click;
            maximizeBtn.MouseEnter += MaximizeBtn_MouseEnter;
            maximizeBtn.MouseLeave += MaximizeBtn_MouseLeave;
            // 
            // closeBtn
            // 
            closeBtn.BackColor = Color.Transparent;
            closeBtn.Cursor = Cursors.Hand;
            closeBtn.Dock = DockStyle.Right;
            closeBtn.IconChar = FontAwesome.Sharp.IconChar.X;
            closeBtn.IconColor = Color.White;
            closeBtn.IconFont = FontAwesome.Sharp.IconFont.Regular;
            closeBtn.IconSize = 29;
            closeBtn.Location = new Point(1528, 0);
            closeBtn.Margin = new Padding(0);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(29, 48);
            closeBtn.SizeMode = PictureBoxSizeMode.Zoom;
            closeBtn.TabIndex = 28;
            closeBtn.TabStop = false;
            closeBtn.Click += closeBtn_Click;
            closeBtn.MouseEnter += CloseBtn_MouseEnter;
            closeBtn.MouseLeave += CloseBtn_MouseLeave;
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.BackColor = Color.FromArgb(216, 225, 233);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(309, 48);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1557, 907);
            mainPanel.TabIndex = 23;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1866, 955);
            Controls.Add(mainPanel);
            Controls.Add(headerPanel);
            Controls.Add(sidePanel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Load += Dashboard_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            sidePanel.ResumeLayout(false);
            sidePanel.PerformLayout();
            sideLayoutTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)resumeIcon).EndInit();
            headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)minimizeBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)maximizeBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeBtn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private PictureBox pictureBox1;
        private Panel sidePanel;
        private Label label1;
        private Label label8;
        private Label label4;
        private TableLayoutPanel sideLayoutTable;
        private FontAwesome.Sharp.IconButton profileBtn;
        private FontAwesome.Sharp.IconButton createResumeBtn;
        private FontAwesome.Sharp.IconButton myResumeBtn;
        private FontAwesome.Sharp.IconButton homeBtn;
        private PictureBox resumeIcon;
        private System.Windows.Forms.Timer highlightTimer;
        private Panel headerPanel;
        private FlowLayoutPanel mainPanel;
        private FontAwesome.Sharp.IconPictureBox minimizeBtn;
        private FontAwesome.Sharp.IconPictureBox maximizeBtn;
        private FontAwesome.Sharp.IconPictureBox closeBtn;
        private FontAwesome.Sharp.IconButton logoutBtn;
        private FontAwesome.Sharp.IconButton messagesBtn;
    }
}