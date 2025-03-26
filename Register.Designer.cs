namespace FinalProjectOOP2
{
    partial class Register
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
            label4 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label8 = new Label();
            panel4 = new Panel();
            passwordTbx = new TextBox();
            pictureBox3 = new PictureBox();
            panel2 = new Panel();
            usernameTbx = new TextBox();
            pictureBox2 = new PictureBox();
            label9 = new Label();
            closeBtn = new Button();
            registerBtn = new Button();
            linkLabel1 = new LinkLabel();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            rolePanel = new Panel();
            userRadioBtn = new RadioButton();
            adminRadioBtn = new RadioButton();
            pictureBox4 = new PictureBox();
            panel3 = new Panel();
            emailTbx = new TextBox();
            pictureBox5 = new PictureBox();
            RegisterTooltip = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            warningLbl = new SiticoneNetCoreUI.SiticoneLabel();
            label5 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            rolePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(260, 302);
            label4.Name = "label4";
            label4.Size = new Size(78, 37);
            label4.TabIndex = 11;
            label4.Text = "App";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(93, 196);
            label2.Name = "label2";
            label2.Size = new Size(257, 37);
            label2.TabIndex = 10;
            label2.Text = "Welcome to the ";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 128, 185);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(356, 726);
            panel1.TabIndex = 13;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.avatar1;
            pictureBox1.Location = new Point(119, 59);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(225, 677);
            label1.Name = "label1";
            label1.Size = new Size(113, 17);
            label1.TabIndex = 14;
            label1.Text = "Jobert Gamboa";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(262, 660);
            label8.Name = "label8";
            label8.Size = new Size(80, 17);
            label8.TabIndex = 13;
            label8.Text = "Project by: ";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Control;
            panel4.Controls.Add(passwordTbx);
            panel4.Controls.Add(pictureBox3);
            panel4.Location = new Point(356, 260);
            panel4.Name = "panel4";
            panel4.Size = new Size(504, 55);
            panel4.TabIndex = 16;
            // 
            // passwordTbx
            // 
            passwordTbx.BackColor = SystemColors.Control;
            passwordTbx.BorderStyle = BorderStyle.None;
            passwordTbx.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordTbx.ForeColor = Color.FromArgb(41, 128, 185);
            passwordTbx.Location = new Point(55, 16);
            passwordTbx.Name = "passwordTbx";
            passwordTbx.Size = new Size(422, 25);
            passwordTbx.TabIndex = 17;
            RegisterTooltip.SetToolTip(passwordTbx, "Hold Left-click to see password");
            passwordTbx.UseSystemPasswordChar = true;
            passwordTbx.Click += passwordTbx_Click;
            passwordTbx.CursorChanged += passwordTbx_Click;
            passwordTbx.TextChanged += passwordTbx_TextChanged;
            passwordTbx.Enter += passwordTbx_Click;
            passwordTbx.KeyDown += Register_KeyDown;
            // 
            // pictureBox3
            // 
            pictureBox3.Cursor = Cursors.Hand;
            pictureBox3.Image = Properties.Resources._5582931;
            pictureBox3.Location = new Point(15, 11);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(34, 34);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            pictureBox3.MouseDown += pictureBox3_MouseDown;
            pictureBox3.MouseUp += pictureBox3_MouseUp;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(usernameTbx);
            panel2.Controls.Add(pictureBox2);
            panel2.Location = new Point(356, 196);
            panel2.Name = "panel2";
            panel2.Size = new Size(504, 55);
            panel2.TabIndex = 15;
            // 
            // usernameTbx
            // 
            usernameTbx.BackColor = SystemColors.Control;
            usernameTbx.BorderStyle = BorderStyle.None;
            usernameTbx.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernameTbx.ForeColor = Color.FromArgb(41, 128, 185);
            usernameTbx.Location = new Point(55, 16);
            usernameTbx.Name = "usernameTbx";
            usernameTbx.Size = new Size(422, 25);
            usernameTbx.TabIndex = 16;
            RegisterTooltip.SetToolTip(usernameTbx, "Enter your desired username");
            usernameTbx.Click += usernameTbx_Click;
            usernameTbx.CursorChanged += usernameTbx_Click;
            usernameTbx.Enter += usernameTbx_Click;
            usernameTbx.KeyDown += Register_KeyDown;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.blue_user_icon_vector_427974561;
            pictureBox2.Location = new Point(15, 11);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(34, 34);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(41, 128, 185);
            label9.Location = new Point(398, 135);
            label9.Name = "label9";
            label9.Size = new Size(335, 37);
            label9.TabIndex = 18;
            label9.Text = "Register your account\r\n";
            // 
            // closeBtn
            // 
            closeBtn.Cursor = Cursors.Hand;
            closeBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.Font = new Font("Verdana", 16F, FontStyle.Bold);
            closeBtn.ForeColor = Color.FromArgb(41, 128, 185);
            closeBtn.Location = new Point(820, 0);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(40, 40);
            closeBtn.TabIndex = 17;
            closeBtn.Text = "X";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click;
            // 
            // registerBtn
            // 
            registerBtn.BackColor = Color.FromArgb(41, 128, 185);
            registerBtn.Cursor = Cursors.Hand;
            registerBtn.FlatStyle = FlatStyle.Flat;
            registerBtn.Font = new Font("Century Gothic", 10F);
            registerBtn.ForeColor = Color.White;
            registerBtn.Location = new Point(371, 523);
            registerBtn.Name = "registerBtn";
            registerBtn.Size = new Size(172, 45);
            registerBtn.TabIndex = 19;
            registerBtn.Text = "SIGN UP";
            registerBtn.UseVisualStyleBackColor = false;
            registerBtn.Click += registerBtn_Click;
            registerBtn.KeyDown += Register_KeyDown;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.Bottom;
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.FromArgb(41, 128, 185);
            linkLabel1.Location = new Point(590, 692);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(216, 20);
            linkLabel1.TabIndex = 24;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "jobertdamian.gamboa@cit.edu";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Bottom;
            label10.AutoSize = true;
            label10.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Silver;
            label10.Location = new Point(398, 694);
            label10.Name = "label10";
            label10.Size = new Size(195, 17);
            label10.TabIndex = 23;
            label10.Text = "submit an email message to:";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Bottom;
            label11.AutoSize = true;
            label11.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Silver;
            label11.Location = new Point(398, 677);
            label11.Name = "label11";
            label11.Size = new Size(354, 17);
            label11.TabIndex = 22;
            label11.Text = "To obtain access to this App or any questions about it";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Bottom;
            label12.AutoSize = true;
            label12.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Silver;
            label12.Location = new Point(398, 660);
            label12.Name = "label12";
            label12.Size = new Size(66, 17);
            label12.TabIndex = 21;
            label12.Text = "Support :";
            // 
            // rolePanel
            // 
            rolePanel.BackColor = SystemColors.Control;
            rolePanel.Controls.Add(userRadioBtn);
            rolePanel.Controls.Add(adminRadioBtn);
            rolePanel.Controls.Add(pictureBox4);
            rolePanel.Location = new Point(356, 453);
            rolePanel.Name = "rolePanel";
            rolePanel.Size = new Size(504, 55);
            rolePanel.TabIndex = 29;
            RegisterTooltip.SetToolTip(rolePanel, "Pick your role");
            // 
            // userRadioBtn
            // 
            userRadioBtn.AutoSize = true;
            userRadioBtn.Cursor = Cursors.Hand;
            userRadioBtn.Font = new Font("Century Gothic", 10.2F);
            userRadioBtn.ForeColor = Color.FromArgb(41, 128, 185);
            userRadioBtn.Location = new Point(183, 16);
            userRadioBtn.Name = "userRadioBtn";
            userRadioBtn.Size = new Size(66, 25);
            userRadioBtn.TabIndex = 30;
            userRadioBtn.TabStop = true;
            userRadioBtn.Text = "User";
            userRadioBtn.UseVisualStyleBackColor = true;
            // 
            // adminRadioBtn
            // 
            adminRadioBtn.AutoSize = true;
            adminRadioBtn.Cursor = Cursors.Hand;
            adminRadioBtn.Font = new Font("Century Gothic", 10.2F);
            adminRadioBtn.ForeColor = Color.FromArgb(41, 128, 185);
            adminRadioBtn.Location = new Point(62, 16);
            adminRadioBtn.Name = "adminRadioBtn";
            adminRadioBtn.Size = new Size(84, 25);
            adminRadioBtn.TabIndex = 29;
            adminRadioBtn.TabStop = true;
            adminRadioBtn.Text = "Admin";
            adminRadioBtn.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.roleNoBg;
            pictureBox4.Location = new Point(15, 11);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(34, 34);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 4;
            pictureBox4.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(emailTbx);
            panel3.Controls.Add(pictureBox5);
            panel3.Location = new Point(356, 389);
            panel3.Name = "panel3";
            panel3.Size = new Size(504, 55);
            panel3.TabIndex = 30;
            // 
            // emailTbx
            // 
            emailTbx.BackColor = SystemColors.Control;
            emailTbx.BorderStyle = BorderStyle.None;
            emailTbx.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailTbx.ForeColor = Color.FromArgb(41, 128, 185);
            emailTbx.Location = new Point(55, 16);
            emailTbx.Name = "emailTbx";
            emailTbx.Size = new Size(422, 25);
            emailTbx.TabIndex = 17;
            RegisterTooltip.SetToolTip(emailTbx, "Enter your email");
            emailTbx.Click += emailTbx_Click;
            emailTbx.CursorChanged += emailTbx_Click;
            emailTbx.Enter += emailTbx_Click;
            emailTbx.KeyDown += Register_KeyDown;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.emailIcon;
            pictureBox5.Location = new Point(15, 11);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(34, 34);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 4;
            pictureBox5.TabStop = false;
            // 
            // RegisterTooltip
            // 
            RegisterTooltip.AllowLinksHandling = true;
            RegisterTooltip.Font = new Font("Century Gothic", 9.5F);
            RegisterTooltip.ForeColor = Color.FromArgb(41, 128, 185);
            RegisterTooltip.MaximumSize = new Size(0, 0);
            RegisterTooltip.TitleFont = new Font("Century Gothic", 9.5F);
            // 
            // warningLbl
            // 
            warningLbl.BackColor = Color.Transparent;
            warningLbl.FlatStyle = FlatStyle.Flat;
            warningLbl.Font = new Font("Century Gothic", 9F);
            warningLbl.ForeColor = Color.FromArgb(41, 128, 185);
            warningLbl.Location = new Point(371, 323);
            warningLbl.Name = "warningLbl";
            warningLbl.Size = new Size(301, 63);
            warningLbl.TabIndex = 31;
            warningLbl.Text = "Password must be at least 8 characters.\r\nNo whitespaces allowed.\r\nMake a strong password!\r\n";
            warningLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(142, 249);
            label5.Name = "label5";
            label5.Size = new Size(196, 37);
            label5.TabIndex = 16;
            label5.Text = "ProResume+";
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(861, 726);
            Controls.Add(warningLbl);
            Controls.Add(panel3);
            Controls.Add(rolePanel);
            Controls.Add(linkLabel1);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(registerBtn);
            Controls.Add(label9);
            Controls.Add(closeBtn);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Register_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            rolePanel.ResumeLayout(false);
            rolePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label4;
        private Label label2;
        private Panel panel1;
        private Label label1;
        private Label label8;
        private Panel panel4;
        private TextBox passwordTbx;
        private PictureBox pictureBox3;
        private Panel panel2;
        private TextBox usernameTbx;
        private PictureBox pictureBox2;
        private Label label9;
        private Button closeBtn;
        private Button registerBtn;
        private LinkLabel linkLabel1;
        private Label label10;
        private Label label11;
        private Label label12;
        private PictureBox pictureBox1;
        private Panel rolePanel;
        private RadioButton userRadioBtn;
        private RadioButton adminRadioBtn;
        private PictureBox pictureBox4;
        private Panel panel3;
        private TextBox emailTbx;
        private PictureBox pictureBox5;
        private Guna.UI2.WinForms.Guna2HtmlToolTip RegisterTooltip;
        private SiticoneNetCoreUI.SiticoneLabel warningLbl;
        private Label label5;
    }
}