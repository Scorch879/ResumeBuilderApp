namespace FinalProjectOOP2
{
    partial class Profile
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
            panel1 = new Panel();
            label1 = new Label();
            lbl = new Label();
            logoutBtn = new FontAwesome.Sharp.IconButton();
            tableLayoutPanel3 = new TableLayoutPanel();
            panel9 = new Panel();
            deleteAccBtn = new Button();
            panel8 = new Panel();
            panel7 = new Panel();
            updateProfileBtn = new Button();
            panel4 = new Panel();
            panel12 = new Panel();
            label6 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel10 = new Panel();
            usernameLbl = new Label();
            panel15 = new Panel();
            panel11 = new Panel();
            changeProfilePicBtn = new Button();
            panel14 = new Panel();
            descriptionTbx = new SiticoneNetCoreUI.SiticoneLabel();
            label3 = new Label();
            panel6 = new Panel();
            profilePic = new PictureBox();
            panel2 = new Panel();
            panel5 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel20 = new Panel();
            emaillbl = new Label();
            panel19 = new Panel();
            label = new Label();
            panel18 = new Panel();
            fullnameLbl = new Label();
            panel17 = new Panel();
            label2 = new Label();
            panel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel4.SuspendLayout();
            panel12.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel10.SuspendLayout();
            panel15.SuspendLayout();
            panel11.SuspendLayout();
            panel14.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)profilePic).BeginInit();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel20.SuspendLayout();
            panel19.SuspendLayout();
            panel18.SuspendLayout();
            panel17.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 128, 185);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lbl);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1510, 108);
            panel1.TabIndex = 26;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(10, 65);
            label1.Name = "label1";
            label1.Size = new Size(323, 27);
            label1.TabIndex = 4;
            label1.Text = "\"Your very own information\"";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl.ForeColor = Color.White;
            lbl.Location = new Point(10, 14);
            lbl.Name = "lbl";
            lbl.Size = new Size(138, 47);
            lbl.TabIndex = 3;
            lbl.Text = "Profile";
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // logoutBtn
            // 
            logoutBtn.BackColor = Color.FromArgb(41, 128, 185);
            logoutBtn.Dock = DockStyle.Fill;
            logoutBtn.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold);
            logoutBtn.ForeColor = Color.White;
            logoutBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            logoutBtn.IconColor = Color.Black;
            logoutBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            logoutBtn.Location = new Point(2, 2);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Padding = new Padding(3);
            logoutBtn.Size = new Size(492, 78);
            logoutBtn.TabIndex = 0;
            logoutBtn.Text = "Logout";
            logoutBtn.UseVisualStyleBackColor = false;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel3.Controls.Add(panel9, 2, 0);
            tableLayoutPanel3.Controls.Add(panel8, 1, 0);
            tableLayoutPanel3.Controls.Add(panel7, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(5, 5);
            tableLayoutPanel3.Margin = new Padding(5);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.Padding = new Padding(5);
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(1500, 92);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.BackColor = Color.White;
            panel9.Controls.Add(deleteAccBtn);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(997, 5);
            panel9.Margin = new Padding(0);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(3);
            panel9.Size = new Size(498, 82);
            panel9.TabIndex = 2;
            // 
            // deleteAccBtn
            // 
            deleteAccBtn.BackColor = Color.IndianRed;
            deleteAccBtn.Dock = DockStyle.Fill;
            deleteAccBtn.FlatAppearance.BorderSize = 0;
            deleteAccBtn.FlatStyle = FlatStyle.Flat;
            deleteAccBtn.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold);
            deleteAccBtn.ForeColor = Color.White;
            deleteAccBtn.Location = new Point(3, 3);
            deleteAccBtn.Name = "deleteAccBtn";
            deleteAccBtn.Size = new Size(492, 76);
            deleteAccBtn.TabIndex = 6;
            deleteAccBtn.Text = "Delete Account";
            deleteAccBtn.UseVisualStyleBackColor = false;
            deleteAccBtn.Click += deleteAccBtn_Click;
            // 
            // panel8
            // 
            panel8.BackColor = Color.White;
            panel8.Controls.Add(logoutBtn);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(501, 5);
            panel8.Margin = new Padding(0);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(2);
            panel8.Size = new Size(496, 82);
            panel8.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.Controls.Add(updateProfileBtn);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(5, 5);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(3);
            panel7.Size = new Size(496, 82);
            panel7.TabIndex = 0;
            // 
            // updateProfileBtn
            // 
            updateProfileBtn.BackColor = Color.FromArgb(0, 31, 84);
            updateProfileBtn.Dock = DockStyle.Fill;
            updateProfileBtn.FlatAppearance.BorderSize = 0;
            updateProfileBtn.FlatStyle = FlatStyle.Flat;
            updateProfileBtn.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold);
            updateProfileBtn.ForeColor = Color.White;
            updateProfileBtn.Location = new Point(3, 3);
            updateProfileBtn.Name = "updateProfileBtn";
            updateProfileBtn.Size = new Size(490, 76);
            updateProfileBtn.TabIndex = 7;
            updateProfileBtn.Text = "Update Profile";
            updateProfileBtn.UseVisualStyleBackColor = false;
            updateProfileBtn.Click += updateProfileBtn_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(tableLayoutPanel3);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 748);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(5);
            panel4.Size = new Size(1510, 102);
            panel4.TabIndex = 29;
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(0, 31, 84);
            panel12.Controls.Add(label6);
            panel12.Dock = DockStyle.Top;
            panel12.Location = new Point(390, 108);
            panel12.Name = "panel12";
            panel12.Size = new Size(1120, 75);
            panel12.TabIndex = 33;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(5, 17);
            label6.Name = "label6";
            label6.Size = new Size(313, 37);
            label6.TabIndex = 1;
            label6.Text = "Account Information";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel10, 0, 1);
            tableLayoutPanel1.Controls.Add(panel15, 0, 3);
            tableLayoutPanel1.Controls.Add(panel14, 0, 2);
            tableLayoutPanel1.Controls.Add(panel6, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.379406F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.279221F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 46.42857F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.1753244F));
            tableLayoutPanel1.Size = new Size(390, 640);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // panel10
            // 
            panel10.BackColor = Color.Transparent;
            panel10.Controls.Add(usernameLbl);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(3, 216);
            panel10.Name = "panel10";
            panel10.Size = new Size(384, 46);
            panel10.TabIndex = 0;
            // 
            // usernameLbl
            // 
            usernameLbl.BackColor = Color.FromArgb(254, 252, 251);
            usernameLbl.Dock = DockStyle.Fill;
            usernameLbl.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameLbl.ForeColor = Color.Black;
            usernameLbl.Location = new Point(0, 0);
            usernameLbl.Name = "usernameLbl";
            usernameLbl.Size = new Size(384, 46);
            usernameLbl.TabIndex = 17;
            usernameLbl.Text = "Username";
            usernameLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel15
            // 
            panel15.BackColor = Color.FromArgb(41, 128, 185);
            panel15.Controls.Add(panel11);
            panel15.Dock = DockStyle.Fill;
            panel15.Location = new Point(3, 564);
            panel15.Name = "panel15";
            panel15.Size = new Size(384, 73);
            panel15.TabIndex = 13;
            // 
            // panel11
            // 
            panel11.BackColor = Color.White;
            panel11.Controls.Add(changeProfilePicBtn);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(0, 0);
            panel11.Margin = new Padding(0);
            panel11.Name = "panel11";
            panel11.Padding = new Padding(3);
            panel11.Size = new Size(384, 73);
            panel11.TabIndex = 2;
            // 
            // changeProfilePicBtn
            // 
            changeProfilePicBtn.BackColor = Color.FromArgb(0, 31, 84);
            changeProfilePicBtn.Dock = DockStyle.Fill;
            changeProfilePicBtn.FlatAppearance.BorderSize = 0;
            changeProfilePicBtn.FlatStyle = FlatStyle.Flat;
            changeProfilePicBtn.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            changeProfilePicBtn.ForeColor = Color.White;
            changeProfilePicBtn.Location = new Point(3, 3);
            changeProfilePicBtn.Name = "changeProfilePicBtn";
            changeProfilePicBtn.Size = new Size(378, 67);
            changeProfilePicBtn.TabIndex = 18;
            changeProfilePicBtn.Text = "Change Profile Picture";
            changeProfilePicBtn.UseVisualStyleBackColor = false;
            changeProfilePicBtn.Click += changeProfilePicBtn_Click;
            // 
            // panel14
            // 
            panel14.BackColor = Color.FromArgb(254, 252, 251);
            panel14.Controls.Add(descriptionTbx);
            panel14.Controls.Add(label3);
            panel14.Dock = DockStyle.Fill;
            panel14.Location = new Point(3, 268);
            panel14.Name = "panel14";
            panel14.Size = new Size(384, 290);
            panel14.TabIndex = 12;
            // 
            // descriptionTbx
            // 
            descriptionTbx.BackColor = Color.Transparent;
            descriptionTbx.Dock = DockStyle.Fill;
            descriptionTbx.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            descriptionTbx.ForeColor = Color.Black;
            descriptionTbx.Location = new Point(0, 34);
            descriptionTbx.Name = "descriptionTbx";
            descriptionTbx.Padding = new Padding(10);
            descriptionTbx.Size = new Size(384, 256);
            descriptionTbx.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(167, 34);
            label3.TabIndex = 2;
            label3.Text = "About me :";
            // 
            // panel6
            // 
            panel6.BackColor = Color.Transparent;
            panel6.Controls.Add(profilePic);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(384, 207);
            panel6.TabIndex = 10;
            // 
            // profilePic
            // 
            profilePic.BackColor = Color.FromArgb(254, 252, 251);
            profilePic.Dock = DockStyle.Fill;
            profilePic.Image = Properties.Resources.default_profile1;
            profilePic.Location = new Point(0, 0);
            profilePic.Name = "profilePic";
            profilePic.Size = new Size(384, 207);
            profilePic.SizeMode = PictureBoxSizeMode.Zoom;
            profilePic.TabIndex = 2;
            profilePic.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 108);
            panel2.Name = "panel2";
            panel2.Size = new Size(390, 640);
            panel2.TabIndex = 30;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Transparent;
            panel5.BorderStyle = BorderStyle.Fixed3D;
            panel5.Controls.Add(tableLayoutPanel2);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(390, 183);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(5);
            panel5.Size = new Size(1120, 565);
            panel5.TabIndex = 34;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.Transparent;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.818182F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 79.1818161F));
            tableLayoutPanel2.Controls.Add(panel20, 1, 1);
            tableLayoutPanel2.Controls.Add(panel19, 0, 1);
            tableLayoutPanel2.Controls.Add(panel18, 1, 0);
            tableLayoutPanel2.Controls.Add(panel17, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(5, 5);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 12.1568632F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 12.1568632F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 75.68627F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(1106, 551);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // panel20
            // 
            panel20.BackColor = Color.Transparent;
            panel20.Controls.Add(emaillbl);
            panel20.Dock = DockStyle.Fill;
            panel20.Location = new Point(233, 65);
            panel20.Name = "panel20";
            panel20.Size = new Size(870, 56);
            panel20.TabIndex = 16;
            // 
            // emaillbl
            // 
            emaillbl.AutoSize = true;
            emaillbl.BackColor = Color.Transparent;
            emaillbl.Dock = DockStyle.Left;
            emaillbl.Font = new Font("Century Gothic", 18F);
            emaillbl.ForeColor = Color.Black;
            emaillbl.Location = new Point(0, 0);
            emaillbl.Name = "emaillbl";
            emaillbl.Size = new Size(290, 37);
            emaillbl.TabIndex = 3;
            emaillbl.Text = "user@domain.com";
            // 
            // panel19
            // 
            panel19.BackColor = Color.Transparent;
            panel19.Controls.Add(label);
            panel19.Dock = DockStyle.Fill;
            panel19.Location = new Point(3, 65);
            panel19.Name = "panel19";
            panel19.Size = new Size(224, 56);
            panel19.TabIndex = 15;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Dock = DockStyle.Left;
            label.Font = new Font("Century Gothic", 18F);
            label.ForeColor = Color.Black;
            label.Location = new Point(0, 0);
            label.Name = "label";
            label.Size = new Size(110, 37);
            label.TabIndex = 1;
            label.Text = "Email :";
            // 
            // panel18
            // 
            panel18.BackColor = Color.Transparent;
            panel18.Controls.Add(fullnameLbl);
            panel18.Dock = DockStyle.Fill;
            panel18.Location = new Point(233, 3);
            panel18.Name = "panel18";
            panel18.Size = new Size(870, 56);
            panel18.TabIndex = 14;
            // 
            // fullnameLbl
            // 
            fullnameLbl.AutoSize = true;
            fullnameLbl.Dock = DockStyle.Left;
            fullnameLbl.Font = new Font("Century Gothic", 18F);
            fullnameLbl.ForeColor = Color.Black;
            fullnameLbl.Location = new Point(0, 0);
            fullnameLbl.Name = "fullnameLbl";
            fullnameLbl.Size = new Size(77, 37);
            fullnameLbl.TabIndex = 2;
            fullnameLbl.Text = "User";
            // 
            // panel17
            // 
            panel17.BackColor = Color.Transparent;
            panel17.Controls.Add(label2);
            panel17.Dock = DockStyle.Fill;
            panel17.Location = new Point(3, 3);
            panel17.Name = "panel17";
            panel17.Size = new Size(224, 56);
            panel17.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Century Gothic", 18F);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(163, 37);
            label2.TabIndex = 0;
            label2.Text = "Fullname :";
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(216, 225, 233);
            Controls.Add(panel5);
            Controls.Add(panel12);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel4);
            Name = "Profile";
            Size = new Size(1510, 850);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel15.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)profilePic).EndInit();
            panel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel20.ResumeLayout(false);
            panel20.PerformLayout();
            panel19.ResumeLayout(false);
            panel19.PerformLayout();
            panel18.ResumeLayout(false);
            panel18.PerformLayout();
            panel17.ResumeLayout(false);
            panel17.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label1;
        private Label lbl;
        private FontAwesome.Sharp.IconButton logoutBtn;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel9;
        private Panel panel8;
        private Panel panel7;
        private Panel panel4;
        private Button deleteAccBtn;
        private Button updateProfileBtn;
        private Panel panel12;
        private Label label6;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel10;
        private Panel panel15;
        private Panel panel11;
        private Button changeProfilePicBtn;
        private Panel panel14;
        private SiticoneNetCoreUI.SiticoneLabel descriptionTbx;
        private Label label3;
        private Panel panel6;
        private Panel panel2;
        private Panel panel5;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel20;
        private Label emaillbl;
        private Panel panel19;
        private Label label;
        private Panel panel18;
        private Label fullnameLbl;
        private Panel panel17;
        private Label label2;
        private PictureBox profilePic;
        private Label usernameLbl;
    }
}
