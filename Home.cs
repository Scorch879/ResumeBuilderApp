using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectOOP2
{
    public partial class Home : UserControl, ICurrentUsername
    {
        private string? currentUsername;

        public string? CurrentUsername
        {
            get 
            { 
                return currentUsername; 
            }
            set
            {
                currentUsername = value;
                userLbl.Text = $"Welcome, {currentUsername}!";
            }
        }

        public Home()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            tableLayoutPanel3 = new TableLayoutPanel();
            panel12 = new Panel();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            panel11 = new Panel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            panel9 = new Panel();
            homeBtn = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            label1 = new Label();
            userLbl = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel10 = new Panel();
            label12 = new Label();
            resumesSentlbl = new Label();
            pictureBox8 = new PictureBox();
            panel4 = new Panel();
            label5 = new Label();
            resumesExportlbl = new Label();
            pictureBox3 = new PictureBox();
            panel2 = new Panel();
            label11 = new Label();
            resumesCreatedlbl = new Label();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            label2 = new Label();
            pendingResumeslbl = new Label();
            pictureBox2 = new PictureBox();
            panel5 = new Panel();
            label20 = new Label();
            label8 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel13 = new Panel();
            siticoneTileButton10 = new SiticoneNetCoreUI.SiticoneTileButton();
            label21 = new Label();
            label22 = new Label();
            siticoneTileButton9 = new SiticoneNetCoreUI.SiticoneTileButton();
            label23 = new Label();
            panel7 = new Panel();
            label10 = new Label();
            label19 = new Label();
            siticoneTileButton5 = new SiticoneNetCoreUI.SiticoneTileButton();
            siticoneTileButton6 = new SiticoneNetCoreUI.SiticoneTileButton();
            label16 = new Label();
            panel6 = new Panel();
            label7 = new Label();
            label18 = new Label();
            siticoneTileButton3 = new SiticoneNetCoreUI.SiticoneTileButton();
            siticoneTileButton4 = new SiticoneNetCoreUI.SiticoneTileButton();
            label9 = new Label();
            panel8 = new Panel();
            label15 = new Label();
            label17 = new Label();
            siticoneTileButton1 = new SiticoneNetCoreUI.SiticoneTileButton();
            siticoneTileButton2 = new SiticoneNetCoreUI.SiticoneTileButton();
            label13 = new Label();
            tableLayoutPanel3.SuspendLayout();
            panel12.SuspendLayout();
            panel11.SuspendLayout();
            panel9.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel10.SuspendLayout();
            ((ISupportInitialize)pictureBox8).BeginInit();
            panel4.SuspendLayout();
            ((ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            ((ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            ((ISupportInitialize)pictureBox2).BeginInit();
            panel5.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel13.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.FromArgb(216, 225, 233);
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.Controls.Add(panel12, 2, 0);
            tableLayoutPanel3.Controls.Add(panel11, 1, 0);
            tableLayoutPanel3.Controls.Add(panel9, 0, 0);
            tableLayoutPanel3.Location = new Point(10, 529);
            tableLayoutPanel3.Margin = new Padding(26, 22, 26, 22);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.Padding = new Padding(3, 2, 3, 2);
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(1061, 92);
            tableLayoutPanel3.TabIndex = 19;
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(41, 128, 185);
            panel12.BorderStyle = BorderStyle.FixedSingle;
            panel12.Controls.Add(iconButton2);
            panel12.Location = new Point(718, 6);
            panel12.Margin = new Padding(4);
            panel12.Name = "panel12";
            panel12.Padding = new Padding(1);
            panel12.Size = new Size(334, 78);
            panel12.TabIndex = 19;
            // 
            // iconButton2
            // 
            iconButton2.BackColor = Color.FromArgb(41, 128, 185);
            iconButton2.Cursor = Cursors.Hand;
            iconButton2.Dock = DockStyle.Fill;
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.Font = new Font("Century Gothic", 13.8F);
            iconButton2.ForeColor = Color.White;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.PaperPlane;
            iconButton2.IconColor = Color.FromArgb(216, 225, 233);
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 50;
            iconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton2.Location = new Point(1, 1);
            iconButton2.Margin = new Padding(3, 2, 3, 2);
            iconButton2.Name = "iconButton2";
            iconButton2.Padding = new Padding(60, 0, 0, 0);
            iconButton2.Size = new Size(330, 74);
            iconButton2.TabIndex = 23;
            iconButton2.Text = "Send Resume";
            iconButton2.TextAlign = ContentAlignment.MiddleLeft;
            iconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton2.UseVisualStyleBackColor = false;
            // 
            // panel11
            // 
            panel11.BackColor = Color.FromArgb(41, 128, 185);
            panel11.BorderStyle = BorderStyle.FixedSingle;
            panel11.Controls.Add(iconButton1);
            panel11.Location = new Point(382, 6);
            panel11.Margin = new Padding(4);
            panel11.Name = "panel11";
            panel11.Padding = new Padding(1);
            panel11.Size = new Size(328, 78);
            panel11.TabIndex = 18;
            // 
            // iconButton1
            // 
            iconButton1.BackColor = Color.FromArgb(41, 128, 185);
            iconButton1.Cursor = Cursors.Hand;
            iconButton1.Dock = DockStyle.Fill;
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.Font = new Font("Century Gothic", 13.8F);
            iconButton1.ForeColor = Color.White;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.Download;
            iconButton1.IconColor = Color.FromArgb(216, 225, 233);
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 50;
            iconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton1.Location = new Point(1, 1);
            iconButton1.Margin = new Padding(3, 2, 3, 2);
            iconButton1.Name = "iconButton1";
            iconButton1.Padding = new Padding(75, 0, 0, 0);
            iconButton1.Size = new Size(324, 74);
            iconButton1.TabIndex = 22;
            iconButton1.Text = "Export All";
            iconButton1.TextAlign = ContentAlignment.MiddleLeft;
            iconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton1.UseVisualStyleBackColor = false;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(41, 128, 185);
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(homeBtn);
            panel9.Location = new Point(7, 6);
            panel9.Margin = new Padding(4);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(1);
            panel9.Size = new Size(367, 78);
            panel9.TabIndex = 17;
            // 
            // homeBtn
            // 
            homeBtn.BackColor = Color.FromArgb(41, 128, 185);
            homeBtn.Cursor = Cursors.Hand;
            homeBtn.Dock = DockStyle.Fill;
            homeBtn.FlatAppearance.BorderSize = 0;
            homeBtn.FlatStyle = FlatStyle.Flat;
            homeBtn.Font = new Font("Century Gothic", 13.8F);
            homeBtn.ForeColor = Color.White;
            homeBtn.IconChar = FontAwesome.Sharp.IconChar.Add;
            homeBtn.IconColor = Color.FromArgb(216, 225, 233);
            homeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            homeBtn.IconSize = 50;
            homeBtn.ImageAlign = ContentAlignment.MiddleLeft;
            homeBtn.Location = new Point(1, 1);
            homeBtn.Margin = new Padding(3, 2, 3, 2);
            homeBtn.Name = "homeBtn";
            homeBtn.Padding = new Padding(25, 0, 0, 0);
            homeBtn.Size = new Size(363, 74);
            homeBtn.TabIndex = 22;
            homeBtn.Text = " Create New Resume";
            homeBtn.TextAlign = ContentAlignment.MiddleLeft;
            homeBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            homeBtn.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(userLbl);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1557, 112);
            panel1.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(41, 128, 185);
            label1.Location = new Point(10, 72);
            label1.Name = "label1";
            label1.Size = new Size(474, 27);
            label1.TabIndex = 5;
            label1.Text = "\"Here's a quick overview of your activity\"";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // userLbl
            // 
            userLbl.AutoSize = true;
            userLbl.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userLbl.ForeColor = Color.FromArgb(41, 128, 185);
            userLbl.Location = new Point(10, 15);
            userLbl.Name = "userLbl";
            userLbl.Size = new Size(324, 47);
            userLbl.TabIndex = 3;
            userLbl.Text = "Welcome, User!";
            userLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(216, 225, 233);
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 151F));
            tableLayoutPanel1.Controls.Add(panel10, 3, 0);
            tableLayoutPanel1.Controls.Add(panel4, 2, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel3, 1, 0);
            tableLayoutPanel1.Location = new Point(10, 118);
            tableLayoutPanel1.Margin = new Padding(9, 8, 9, 8);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 132F));
            tableLayoutPanel1.Size = new Size(692, 155);
            tableLayoutPanel1.TabIndex = 16;
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(41, 128, 185);
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Controls.Add(label12);
            panel10.Controls.Add(resumesSentlbl);
            panel10.Controls.Add(pictureBox8);
            panel10.Location = new Point(520, 6);
            panel10.Margin = new Padding(4);
            panel10.Name = "panel10";
            panel10.Padding = new Padding(9);
            panel10.Size = new Size(163, 140);
            panel10.TabIndex = 18;
            // 
            // label12
            // 
            label12.Dock = DockStyle.Bottom;
            label12.Font = new Font("Century Gothic", 13.8F);
            label12.ForeColor = Color.White;
            label12.Location = new Point(9, 44);
            label12.Name = "label12";
            label12.Size = new Size(143, 57);
            label12.TabIndex = 17;
            label12.Text = "RESUMES\r\nSENT :\r\n";
            // 
            // resumesSentlbl
            // 
            resumesSentlbl.Dock = DockStyle.Bottom;
            resumesSentlbl.Font = new Font("Century Gothic", 13.8F);
            resumesSentlbl.ForeColor = Color.White;
            resumesSentlbl.Location = new Point(9, 101);
            resumesSentlbl.Name = "resumesSentlbl";
            resumesSentlbl.Size = new Size(143, 28);
            resumesSentlbl.TabIndex = 16;
            resumesSentlbl.Text = "3";
            // 
            // pictureBox8
            // 
            pictureBox8.Dock = DockStyle.Top;
            pictureBox8.Image = Properties.Resources.images1;
            pictureBox8.Location = new Point(9, 9);
            pictureBox8.Margin = new Padding(3, 2, 3, 2);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(143, 36);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 15;
            pictureBox8.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(41, 128, 185);
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label5);
            panel4.Controls.Add(resumesExportlbl);
            panel4.Controls.Add(pictureBox3);
            panel4.Location = new Point(349, 6);
            panel4.Margin = new Padding(4);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(9, 8, 9, 8);
            panel4.Size = new Size(163, 140);
            panel4.TabIndex = 17;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Bottom;
            label5.Font = new Font("Century Gothic", 13.8F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(9, 43);
            label5.Name = "label5";
            label5.Size = new Size(143, 58);
            label5.TabIndex = 17;
            label5.Text = "RESUMES\r\nEXPORTED :";
            // 
            // resumesExportlbl
            // 
            resumesExportlbl.Dock = DockStyle.Bottom;
            resumesExportlbl.Font = new Font("Century Gothic", 13.8F);
            resumesExportlbl.ForeColor = Color.White;
            resumesExportlbl.Location = new Point(9, 101);
            resumesExportlbl.Name = "resumesExportlbl";
            resumesExportlbl.Size = new Size(143, 29);
            resumesExportlbl.TabIndex = 16;
            resumesExportlbl.Text = "3";
            // 
            // pictureBox3
            // 
            pictureBox3.Dock = DockStyle.Top;
            pictureBox3.Image = Properties.Resources.images1;
            pictureBox3.Location = new Point(9, 8);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(143, 37);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 15;
            pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(41, 128, 185);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label11);
            panel2.Controls.Add(resumesCreatedlbl);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(7, 6);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(9, 8, 9, 8);
            panel2.Size = new Size(163, 140);
            panel2.TabIndex = 15;
            // 
            // label11
            // 
            label11.Dock = DockStyle.Bottom;
            label11.Font = new Font("Century Gothic", 13.8F);
            label11.ForeColor = Color.White;
            label11.Location = new Point(9, 43);
            label11.Name = "label11";
            label11.Size = new Size(143, 58);
            label11.TabIndex = 17;
            label11.Text = "RESUMES\r\nCREATED :";
            // 
            // resumesCreatedlbl
            // 
            resumesCreatedlbl.Dock = DockStyle.Bottom;
            resumesCreatedlbl.Font = new Font("Century Gothic", 13.8F);
            resumesCreatedlbl.ForeColor = Color.White;
            resumesCreatedlbl.Location = new Point(9, 101);
            resumesCreatedlbl.Name = "resumesCreatedlbl";
            resumesCreatedlbl.Size = new Size(143, 29);
            resumesCreatedlbl.TabIndex = 16;
            resumesCreatedlbl.Text = "3";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = Properties.Resources.resumeIcon;
            pictureBox1.Location = new Point(9, 8);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(143, 36);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(41, 128, 185);
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(pendingResumeslbl);
            panel3.Controls.Add(pictureBox2);
            panel3.Location = new Point(178, 6);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(9, 8, 9, 8);
            panel3.Size = new Size(163, 140);
            panel3.TabIndex = 16;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Bottom;
            label2.Font = new Font("Century Gothic", 13.8F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(9, 43);
            label2.Name = "label2";
            label2.Size = new Size(143, 58);
            label2.TabIndex = 17;
            label2.Text = "PENDING\r\nRESUMES :\r\n";
            // 
            // pendingResumeslbl
            // 
            pendingResumeslbl.Dock = DockStyle.Bottom;
            pendingResumeslbl.Font = new Font("Century Gothic", 13.8F);
            pendingResumeslbl.ForeColor = Color.White;
            pendingResumeslbl.Location = new Point(9, 101);
            pendingResumeslbl.Name = "pendingResumeslbl";
            pendingResumeslbl.Size = new Size(143, 29);
            pendingResumeslbl.TabIndex = 16;
            pendingResumeslbl.Text = "3";
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Top;
            pictureBox2.Image = Properties.Resources.pending;
            pictureBox2.Location = new Point(9, 8);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(143, 36);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            // 
            // panel5
            // 
            panel5.Controls.Add(label20);
            panel5.Controls.Add(label8);
            panel5.Location = new Point(10, 278);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(1334, 94);
            panel5.TabIndex = 17;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label20.ForeColor = Color.FromArgb(41, 128, 185);
            label20.Location = new Point(3, 57);
            label20.Name = "label20";
            label20.Size = new Size(253, 27);
            label20.TabIndex = 5;
            label20.Text = "\"Your recent resumes\"";
            label20.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(41, 128, 185);
            label8.Location = new Point(3, 15);
            label8.Name = "label8";
            label8.Size = new Size(341, 47);
            label8.TabIndex = 3;
            label8.Text = "Recent Resumes";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.FromArgb(216, 225, 233);
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
            tableLayoutPanel2.Controls.Add(panel13, 3, 0);
            tableLayoutPanel2.Controls.Add(panel7, 2, 0);
            tableLayoutPanel2.Controls.Add(panel6, 1, 0);
            tableLayoutPanel2.Controls.Add(panel8, 0, 0);
            tableLayoutPanel2.Location = new Point(10, 375);
            tableLayoutPanel2.Margin = new Padding(26, 22, 26, 22);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel2.Size = new Size(1334, 146);
            tableLayoutPanel2.TabIndex = 18;
            // 
            // panel13
            // 
            panel13.BackColor = Color.FromArgb(41, 128, 185);
            panel13.BorderStyle = BorderStyle.FixedSingle;
            panel13.Controls.Add(siticoneTileButton10);
            panel13.Controls.Add(label21);
            panel13.Controls.Add(label22);
            panel13.Controls.Add(siticoneTileButton9);
            panel13.Controls.Add(label23);
            panel13.Location = new Point(1003, 6);
            panel13.Margin = new Padding(4);
            panel13.Name = "panel13";
            panel13.Padding = new Padding(9, 8, 9, 8);
            panel13.Size = new Size(322, 133);
            panel13.TabIndex = 18;
            // 
            // siticoneTileButton10
            // 
            siticoneTileButton10.AccessibleDescription = "A customizable tile button";
            siticoneTileButton10.AccessibleName = "TileButton";
            siticoneTileButton10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            siticoneTileButton10.BackColor = Color.Transparent;
            siticoneTileButton10.BadgeColor = Color.Red;
            siticoneTileButton10.BadgeFont = "Segoe UI";
            siticoneTileButton10.BadgePosition = new Point(134, 5);
            siticoneTileButton10.BadgeText = "";
            siticoneTileButton10.BaseColor = Color.FromArgb(50, 150, 215);
            siticoneTileButton10.BorderWidth = 1F;
            siticoneTileButton10.BottomLeftRadius = 12F;
            siticoneTileButton10.BottomRightRadius = 12F;
            siticoneTileButton10.ColorTransitionSpeed = 0.15F;
            siticoneTileButton10.EnableRipple = true;
            siticoneTileButton10.Font = new Font("Segoe UI", 10F);
            siticoneTileButton10.ForeColor = Color.White;
            siticoneTileButton10.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneTileButton10.HoverColor = Color.FromArgb(70, 170, 235);
            siticoneTileButton10.Icon = null;
            siticoneTileButton10.IconAlignment = ContentAlignment.MiddleLeft;
            siticoneTileButton10.IconMargin = new Padding(5);
            siticoneTileButton10.IconPadding = 5;
            siticoneTileButton10.IconSize = new Size(24, 24);
            siticoneTileButton10.IsLoading = false;
            siticoneTileButton10.IsToggled = false;
            siticoneTileButton10.LoadingColor = Color.White;
            siticoneTileButton10.Location = new Point(9, 94);
            siticoneTileButton10.Margin = new Padding(3, 2, 3, 2);
            siticoneTileButton10.MaxRipples = 100;
            siticoneTileButton10.Name = "siticoneTileButton10";
            siticoneTileButton10.PersistState = false;
            siticoneTileButton10.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneTileButton10.RippleFadeStart = 0F;
            siticoneTileButton10.RippleOpacity = 0.1F;
            siticoneTileButton10.RippleSpeed = 20F;
            siticoneTileButton10.ShadowColor = Color.Black;
            siticoneTileButton10.ShadowDepth = 1;
            siticoneTileButton10.ShadowOffset = new Point(1, 1);
            siticoneTileButton10.ShadowOpacity = 0.3F;
            siticoneTileButton10.ShowBadge = false;
            siticoneTileButton10.ShowBorder = false;
            siticoneTileButton10.ShowTextShadow = true;
            siticoneTileButton10.Size = new Size(145, 29);
            siticoneTileButton10.TabIndex = 24;
            siticoneTileButton10.Text = "Open";
            siticoneTileButton10.TooltipAlwaysShow = true;
            siticoneTileButton10.TooltipAutoPopDelay = 5000;
            siticoneTileButton10.TooltipBackColor = Color.Black;
            siticoneTileButton10.TooltipFont = new Font("Segoe UI", 9F);
            siticoneTileButton10.TooltipForeColor = Color.White;
            siticoneTileButton10.TooltipInitialDelay = 500;
            siticoneTileButton10.TooltipReshowDelay = 100;
            siticoneTileButton10.TooltipText = "";
            siticoneTileButton10.TopLeftRadius = 12F;
            siticoneTileButton10.TopRightRadius = 12F;
            siticoneTileButton10.UseGradient = false;
            // 
            // label21
            // 
            label21.Dock = DockStyle.Top;
            label21.Font = new Font("Century Gothic", 13.8F);
            label21.ForeColor = Color.White;
            label21.Location = new Point(9, 65);
            label21.Name = "label21";
            label21.Size = new Size(302, 25);
            label21.TabIndex = 23;
            label21.Text = "Status : Final";
            // 
            // label22
            // 
            label22.Dock = DockStyle.Top;
            label22.Font = new Font("Century Gothic", 13.8F);
            label22.ForeColor = Color.White;
            label22.Location = new Point(9, 41);
            label22.Name = "label22";
            label22.Size = new Size(302, 24);
            label22.TabIndex = 22;
            label22.Text = "Date Modified : 01/02/2024";
            // 
            // siticoneTileButton9
            // 
            siticoneTileButton9.AccessibleDescription = "A customizable tile button";
            siticoneTileButton9.AccessibleName = "TileButton";
            siticoneTileButton9.BackColor = Color.Transparent;
            siticoneTileButton9.BadgeColor = Color.Red;
            siticoneTileButton9.BadgeFont = "Segoe UI";
            siticoneTileButton9.BadgePosition = new Point(140, 5);
            siticoneTileButton9.BadgeText = "";
            siticoneTileButton9.BaseColor = Color.FromArgb(50, 150, 215);
            siticoneTileButton9.BorderWidth = 1F;
            siticoneTileButton9.BottomLeftRadius = 12F;
            siticoneTileButton9.BottomRightRadius = 12F;
            siticoneTileButton9.ColorTransitionSpeed = 0.15F;
            siticoneTileButton9.EnableRipple = true;
            siticoneTileButton9.Font = new Font("Segoe UI", 10F);
            siticoneTileButton9.ForeColor = Color.White;
            siticoneTileButton9.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneTileButton9.HoverColor = Color.FromArgb(70, 170, 235);
            siticoneTileButton9.Icon = null;
            siticoneTileButton9.IconAlignment = ContentAlignment.MiddleLeft;
            siticoneTileButton9.IconMargin = new Padding(5);
            siticoneTileButton9.IconPadding = 5;
            siticoneTileButton9.IconSize = new Size(24, 24);
            siticoneTileButton9.IsLoading = false;
            siticoneTileButton9.IsToggled = false;
            siticoneTileButton9.LoadingColor = Color.White;
            siticoneTileButton9.Location = new Point(162, 94);
            siticoneTileButton9.Margin = new Padding(3, 2, 3, 2);
            siticoneTileButton9.MaxRipples = 100;
            siticoneTileButton9.Name = "siticoneTileButton9";
            siticoneTileButton9.PersistState = false;
            siticoneTileButton9.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneTileButton9.RippleFadeStart = 0F;
            siticoneTileButton9.RippleOpacity = 0.1F;
            siticoneTileButton9.RippleSpeed = 20F;
            siticoneTileButton9.ShadowColor = Color.Black;
            siticoneTileButton9.ShadowDepth = 1;
            siticoneTileButton9.ShadowOffset = new Point(1, 1);
            siticoneTileButton9.ShadowOpacity = 0.3F;
            siticoneTileButton9.ShowBadge = false;
            siticoneTileButton9.ShowBorder = false;
            siticoneTileButton9.ShowTextShadow = true;
            siticoneTileButton9.Size = new Size(151, 29);
            siticoneTileButton9.TabIndex = 20;
            siticoneTileButton9.Text = "Delete";
            siticoneTileButton9.TooltipAlwaysShow = true;
            siticoneTileButton9.TooltipAutoPopDelay = 5000;
            siticoneTileButton9.TooltipBackColor = Color.Black;
            siticoneTileButton9.TooltipFont = new Font("Segoe UI", 9F);
            siticoneTileButton9.TooltipForeColor = Color.White;
            siticoneTileButton9.TooltipInitialDelay = 500;
            siticoneTileButton9.TooltipReshowDelay = 100;
            siticoneTileButton9.TooltipText = "";
            siticoneTileButton9.TopLeftRadius = 12F;
            siticoneTileButton9.TopRightRadius = 12F;
            siticoneTileButton9.UseGradient = false;
            // 
            // label23
            // 
            label23.Dock = DockStyle.Top;
            label23.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold);
            label23.ForeColor = Color.White;
            label23.Location = new Point(9, 8);
            label23.Name = "label23";
            label23.Size = new Size(302, 33);
            label23.TabIndex = 17;
            label23.Text = "\"Application Resume\"";
            label23.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(41, 128, 185);
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(label10);
            panel7.Controls.Add(label19);
            panel7.Controls.Add(siticoneTileButton5);
            panel7.Controls.Add(siticoneTileButton6);
            panel7.Controls.Add(label16);
            panel7.Location = new Point(671, 6);
            panel7.Margin = new Padding(4);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(9, 8, 9, 8);
            panel7.Size = new Size(324, 133);
            panel7.TabIndex = 17;
            // 
            // label10
            // 
            label10.Dock = DockStyle.Top;
            label10.Font = new Font("Century Gothic", 13.8F);
            label10.ForeColor = Color.White;
            label10.Location = new Point(9, 65);
            label10.Name = "label10";
            label10.Size = new Size(304, 25);
            label10.TabIndex = 23;
            label10.Text = "Status : Draft";
            // 
            // label19
            // 
            label19.Dock = DockStyle.Top;
            label19.Font = new Font("Century Gothic", 13.8F);
            label19.ForeColor = Color.White;
            label19.Location = new Point(9, 41);
            label19.Name = "label19";
            label19.Size = new Size(304, 24);
            label19.TabIndex = 22;
            label19.Text = "Date Modified : 12/02/2024";
            // 
            // siticoneTileButton5
            // 
            siticoneTileButton5.AccessibleDescription = "A customizable tile button";
            siticoneTileButton5.AccessibleName = "TileButton";
            siticoneTileButton5.BackColor = Color.Transparent;
            siticoneTileButton5.BadgeColor = Color.Red;
            siticoneTileButton5.BadgeFont = "Segoe UI";
            siticoneTileButton5.BadgePosition = new Point(140, 5);
            siticoneTileButton5.BadgeText = "";
            siticoneTileButton5.BaseColor = Color.FromArgb(50, 150, 215);
            siticoneTileButton5.BorderWidth = 1F;
            siticoneTileButton5.BottomLeftRadius = 12F;
            siticoneTileButton5.BottomRightRadius = 12F;
            siticoneTileButton5.ColorTransitionSpeed = 0.15F;
            siticoneTileButton5.EnableRipple = true;
            siticoneTileButton5.Font = new Font("Segoe UI", 10F);
            siticoneTileButton5.ForeColor = Color.White;
            siticoneTileButton5.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneTileButton5.HoverColor = Color.FromArgb(70, 170, 235);
            siticoneTileButton5.Icon = null;
            siticoneTileButton5.IconAlignment = ContentAlignment.MiddleLeft;
            siticoneTileButton5.IconMargin = new Padding(5);
            siticoneTileButton5.IconPadding = 5;
            siticoneTileButton5.IconSize = new Size(24, 24);
            siticoneTileButton5.IsLoading = false;
            siticoneTileButton5.IsToggled = false;
            siticoneTileButton5.LoadingColor = Color.White;
            siticoneTileButton5.Location = new Point(162, 94);
            siticoneTileButton5.Margin = new Padding(3, 2, 3, 2);
            siticoneTileButton5.MaxRipples = 100;
            siticoneTileButton5.Name = "siticoneTileButton5";
            siticoneTileButton5.PersistState = false;
            siticoneTileButton5.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneTileButton5.RippleFadeStart = 0F;
            siticoneTileButton5.RippleOpacity = 0.1F;
            siticoneTileButton5.RippleSpeed = 20F;
            siticoneTileButton5.ShadowColor = Color.Black;
            siticoneTileButton5.ShadowDepth = 1;
            siticoneTileButton5.ShadowOffset = new Point(1, 1);
            siticoneTileButton5.ShadowOpacity = 0.3F;
            siticoneTileButton5.ShowBadge = false;
            siticoneTileButton5.ShowBorder = false;
            siticoneTileButton5.ShowTextShadow = true;
            siticoneTileButton5.Size = new Size(151, 29);
            siticoneTileButton5.TabIndex = 20;
            siticoneTileButton5.Text = "Delete";
            siticoneTileButton5.TooltipAlwaysShow = true;
            siticoneTileButton5.TooltipAutoPopDelay = 5000;
            siticoneTileButton5.TooltipBackColor = Color.Black;
            siticoneTileButton5.TooltipFont = new Font("Segoe UI", 9F);
            siticoneTileButton5.TooltipForeColor = Color.White;
            siticoneTileButton5.TooltipInitialDelay = 500;
            siticoneTileButton5.TooltipReshowDelay = 100;
            siticoneTileButton5.TooltipText = "";
            siticoneTileButton5.TopLeftRadius = 12F;
            siticoneTileButton5.TopRightRadius = 12F;
            siticoneTileButton5.UseGradient = false;
            // 
            // siticoneTileButton6
            // 
            siticoneTileButton6.AccessibleDescription = "A customizable tile button";
            siticoneTileButton6.AccessibleName = "TileButton";
            siticoneTileButton6.BackColor = Color.Transparent;
            siticoneTileButton6.BadgeColor = Color.Red;
            siticoneTileButton6.BadgeFont = "Segoe UI";
            siticoneTileButton6.BadgePosition = new Point(134, 5);
            siticoneTileButton6.BadgeText = "";
            siticoneTileButton6.BaseColor = Color.FromArgb(50, 150, 215);
            siticoneTileButton6.BorderWidth = 1F;
            siticoneTileButton6.BottomLeftRadius = 12F;
            siticoneTileButton6.BottomRightRadius = 12F;
            siticoneTileButton6.ColorTransitionSpeed = 0.15F;
            siticoneTileButton6.EnableRipple = true;
            siticoneTileButton6.Font = new Font("Segoe UI", 10F);
            siticoneTileButton6.ForeColor = Color.White;
            siticoneTileButton6.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneTileButton6.HoverColor = Color.FromArgb(70, 170, 235);
            siticoneTileButton6.Icon = null;
            siticoneTileButton6.IconAlignment = ContentAlignment.MiddleLeft;
            siticoneTileButton6.IconMargin = new Padding(5);
            siticoneTileButton6.IconPadding = 5;
            siticoneTileButton6.IconSize = new Size(24, 24);
            siticoneTileButton6.IsLoading = false;
            siticoneTileButton6.IsToggled = false;
            siticoneTileButton6.LoadingColor = Color.White;
            siticoneTileButton6.Location = new Point(11, 94);
            siticoneTileButton6.Margin = new Padding(3, 2, 3, 2);
            siticoneTileButton6.MaxRipples = 100;
            siticoneTileButton6.Name = "siticoneTileButton6";
            siticoneTileButton6.PersistState = false;
            siticoneTileButton6.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneTileButton6.RippleFadeStart = 0F;
            siticoneTileButton6.RippleOpacity = 0.1F;
            siticoneTileButton6.RippleSpeed = 20F;
            siticoneTileButton6.ShadowColor = Color.Black;
            siticoneTileButton6.ShadowDepth = 1;
            siticoneTileButton6.ShadowOffset = new Point(1, 1);
            siticoneTileButton6.ShadowOpacity = 0.3F;
            siticoneTileButton6.ShowBadge = false;
            siticoneTileButton6.ShowBorder = false;
            siticoneTileButton6.ShowTextShadow = true;
            siticoneTileButton6.Size = new Size(145, 29);
            siticoneTileButton6.TabIndex = 19;
            siticoneTileButton6.Text = "Edit";
            siticoneTileButton6.TooltipAlwaysShow = true;
            siticoneTileButton6.TooltipAutoPopDelay = 5000;
            siticoneTileButton6.TooltipBackColor = Color.Black;
            siticoneTileButton6.TooltipFont = new Font("Segoe UI", 9F);
            siticoneTileButton6.TooltipForeColor = Color.White;
            siticoneTileButton6.TooltipInitialDelay = 500;
            siticoneTileButton6.TooltipReshowDelay = 100;
            siticoneTileButton6.TooltipText = "";
            siticoneTileButton6.TopLeftRadius = 12F;
            siticoneTileButton6.TopRightRadius = 12F;
            siticoneTileButton6.UseGradient = false;
            // 
            // label16
            // 
            label16.Dock = DockStyle.Top;
            label16.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold);
            label16.ForeColor = Color.White;
            label16.Location = new Point(9, 8);
            label16.Name = "label16";
            label16.Size = new Size(304, 33);
            label16.TabIndex = 17;
            label16.Text = "\"Application Resume\"";
            label16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(41, 128, 185);
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(label7);
            panel6.Controls.Add(label18);
            panel6.Controls.Add(siticoneTileButton3);
            panel6.Controls.Add(siticoneTileButton4);
            panel6.Controls.Add(label9);
            panel6.Location = new Point(339, 6);
            panel6.Margin = new Padding(4);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(9, 8, 9, 8);
            panel6.Size = new Size(324, 133);
            panel6.TabIndex = 16;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Top;
            label7.Font = new Font("Century Gothic", 13.8F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(9, 65);
            label7.Name = "label7";
            label7.Size = new Size(304, 25);
            label7.TabIndex = 23;
            label7.Text = "Status : Draft";
            // 
            // label18
            // 
            label18.Dock = DockStyle.Top;
            label18.Font = new Font("Century Gothic", 13.8F);
            label18.ForeColor = Color.White;
            label18.Location = new Point(9, 41);
            label18.Name = "label18";
            label18.Size = new Size(304, 24);
            label18.TabIndex = 22;
            label18.Text = "Date Modified : Today";
            // 
            // siticoneTileButton3
            // 
            siticoneTileButton3.AccessibleDescription = "A customizable tile button";
            siticoneTileButton3.AccessibleName = "TileButton";
            siticoneTileButton3.BackColor = Color.Transparent;
            siticoneTileButton3.BadgeColor = Color.Red;
            siticoneTileButton3.BadgeFont = "Segoe UI";
            siticoneTileButton3.BadgePosition = new Point(140, 5);
            siticoneTileButton3.BadgeText = "";
            siticoneTileButton3.BaseColor = Color.FromArgb(50, 150, 215);
            siticoneTileButton3.BorderWidth = 1F;
            siticoneTileButton3.BottomLeftRadius = 12F;
            siticoneTileButton3.BottomRightRadius = 12F;
            siticoneTileButton3.ColorTransitionSpeed = 0.15F;
            siticoneTileButton3.EnableRipple = true;
            siticoneTileButton3.Font = new Font("Segoe UI", 10F);
            siticoneTileButton3.ForeColor = Color.White;
            siticoneTileButton3.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneTileButton3.HoverColor = Color.FromArgb(70, 170, 235);
            siticoneTileButton3.Icon = null;
            siticoneTileButton3.IconAlignment = ContentAlignment.MiddleLeft;
            siticoneTileButton3.IconMargin = new Padding(5);
            siticoneTileButton3.IconPadding = 5;
            siticoneTileButton3.IconSize = new Size(24, 24);
            siticoneTileButton3.IsLoading = false;
            siticoneTileButton3.IsToggled = false;
            siticoneTileButton3.LoadingColor = Color.White;
            siticoneTileButton3.Location = new Point(162, 94);
            siticoneTileButton3.Margin = new Padding(3, 2, 3, 2);
            siticoneTileButton3.MaxRipples = 100;
            siticoneTileButton3.Name = "siticoneTileButton3";
            siticoneTileButton3.PersistState = false;
            siticoneTileButton3.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneTileButton3.RippleFadeStart = 0F;
            siticoneTileButton3.RippleOpacity = 0.1F;
            siticoneTileButton3.RippleSpeed = 20F;
            siticoneTileButton3.ShadowColor = Color.Black;
            siticoneTileButton3.ShadowDepth = 1;
            siticoneTileButton3.ShadowOffset = new Point(1, 1);
            siticoneTileButton3.ShadowOpacity = 0.3F;
            siticoneTileButton3.ShowBadge = false;
            siticoneTileButton3.ShowBorder = false;
            siticoneTileButton3.ShowTextShadow = true;
            siticoneTileButton3.Size = new Size(151, 29);
            siticoneTileButton3.TabIndex = 20;
            siticoneTileButton3.Text = "Delete";
            siticoneTileButton3.TooltipAlwaysShow = true;
            siticoneTileButton3.TooltipAutoPopDelay = 5000;
            siticoneTileButton3.TooltipBackColor = Color.Black;
            siticoneTileButton3.TooltipFont = new Font("Segoe UI", 9F);
            siticoneTileButton3.TooltipForeColor = Color.White;
            siticoneTileButton3.TooltipInitialDelay = 500;
            siticoneTileButton3.TooltipReshowDelay = 100;
            siticoneTileButton3.TooltipText = "";
            siticoneTileButton3.TopLeftRadius = 12F;
            siticoneTileButton3.TopRightRadius = 12F;
            siticoneTileButton3.UseGradient = false;
            // 
            // siticoneTileButton4
            // 
            siticoneTileButton4.AccessibleDescription = "A customizable tile button";
            siticoneTileButton4.AccessibleName = "TileButton";
            siticoneTileButton4.BackColor = Color.Transparent;
            siticoneTileButton4.BadgeColor = Color.Red;
            siticoneTileButton4.BadgeFont = "Segoe UI";
            siticoneTileButton4.BadgePosition = new Point(134, 5);
            siticoneTileButton4.BadgeText = "";
            siticoneTileButton4.BaseColor = Color.FromArgb(50, 150, 215);
            siticoneTileButton4.BorderWidth = 1F;
            siticoneTileButton4.BottomLeftRadius = 12F;
            siticoneTileButton4.BottomRightRadius = 12F;
            siticoneTileButton4.ColorTransitionSpeed = 0.15F;
            siticoneTileButton4.EnableRipple = true;
            siticoneTileButton4.Font = new Font("Segoe UI", 10F);
            siticoneTileButton4.ForeColor = Color.White;
            siticoneTileButton4.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneTileButton4.HoverColor = Color.FromArgb(70, 170, 235);
            siticoneTileButton4.Icon = null;
            siticoneTileButton4.IconAlignment = ContentAlignment.MiddleLeft;
            siticoneTileButton4.IconMargin = new Padding(5);
            siticoneTileButton4.IconPadding = 5;
            siticoneTileButton4.IconSize = new Size(24, 24);
            siticoneTileButton4.IsLoading = false;
            siticoneTileButton4.IsToggled = false;
            siticoneTileButton4.LoadingColor = Color.White;
            siticoneTileButton4.Location = new Point(11, 94);
            siticoneTileButton4.Margin = new Padding(3, 2, 3, 2);
            siticoneTileButton4.MaxRipples = 100;
            siticoneTileButton4.Name = "siticoneTileButton4";
            siticoneTileButton4.PersistState = false;
            siticoneTileButton4.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneTileButton4.RippleFadeStart = 0F;
            siticoneTileButton4.RippleOpacity = 0.1F;
            siticoneTileButton4.RippleSpeed = 20F;
            siticoneTileButton4.ShadowColor = Color.Black;
            siticoneTileButton4.ShadowDepth = 1;
            siticoneTileButton4.ShadowOffset = new Point(1, 1);
            siticoneTileButton4.ShadowOpacity = 0.3F;
            siticoneTileButton4.ShowBadge = false;
            siticoneTileButton4.ShowBorder = false;
            siticoneTileButton4.ShowTextShadow = true;
            siticoneTileButton4.Size = new Size(145, 29);
            siticoneTileButton4.TabIndex = 19;
            siticoneTileButton4.Text = "Edit";
            siticoneTileButton4.TooltipAlwaysShow = true;
            siticoneTileButton4.TooltipAutoPopDelay = 5000;
            siticoneTileButton4.TooltipBackColor = Color.Black;
            siticoneTileButton4.TooltipFont = new Font("Segoe UI", 9F);
            siticoneTileButton4.TooltipForeColor = Color.White;
            siticoneTileButton4.TooltipInitialDelay = 500;
            siticoneTileButton4.TooltipReshowDelay = 100;
            siticoneTileButton4.TooltipText = "";
            siticoneTileButton4.TopLeftRadius = 12F;
            siticoneTileButton4.TopRightRadius = 12F;
            siticoneTileButton4.UseGradient = false;
            // 
            // label9
            // 
            label9.Dock = DockStyle.Top;
            label9.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(9, 8);
            label9.Name = "label9";
            label9.Size = new Size(304, 33);
            label9.TabIndex = 17;
            label9.Text = "\"For Work Resume\"";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(41, 128, 185);
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(label15);
            panel8.Controls.Add(label17);
            panel8.Controls.Add(siticoneTileButton1);
            panel8.Controls.Add(siticoneTileButton2);
            panel8.Controls.Add(label13);
            panel8.Location = new Point(7, 6);
            panel8.Margin = new Padding(4);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(9, 8, 9, 8);
            panel8.Size = new Size(324, 133);
            panel8.TabIndex = 15;
            // 
            // label15
            // 
            label15.Dock = DockStyle.Top;
            label15.Font = new Font("Century Gothic", 13.8F);
            label15.ForeColor = Color.White;
            label15.Location = new Point(9, 65);
            label15.Name = "label15";
            label15.Size = new Size(304, 25);
            label15.TabIndex = 24;
            label15.Text = "Status : Final";
            // 
            // label17
            // 
            label17.Dock = DockStyle.Top;
            label17.Font = new Font("Century Gothic", 13.8F);
            label17.ForeColor = Color.White;
            label17.Location = new Point(9, 41);
            label17.Name = "label17";
            label17.Size = new Size(304, 24);
            label17.TabIndex = 23;
            label17.Text = "Date Modified : Yesterday";
            // 
            // siticoneTileButton1
            // 
            siticoneTileButton1.AccessibleDescription = "A customizable tile button";
            siticoneTileButton1.AccessibleName = "TileButton";
            siticoneTileButton1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            siticoneTileButton1.BackColor = Color.Transparent;
            siticoneTileButton1.BadgeColor = Color.Red;
            siticoneTileButton1.BadgeFont = "Segoe UI";
            siticoneTileButton1.BadgePosition = new Point(140, 5);
            siticoneTileButton1.BadgeText = "";
            siticoneTileButton1.BaseColor = Color.FromArgb(50, 150, 215);
            siticoneTileButton1.BorderWidth = 1F;
            siticoneTileButton1.BottomLeftRadius = 12F;
            siticoneTileButton1.BottomRightRadius = 12F;
            siticoneTileButton1.ColorTransitionSpeed = 0.15F;
            siticoneTileButton1.EnableRipple = true;
            siticoneTileButton1.Font = new Font("Segoe UI", 10F);
            siticoneTileButton1.ForeColor = Color.White;
            siticoneTileButton1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneTileButton1.HoverColor = Color.FromArgb(70, 170, 235);
            siticoneTileButton1.Icon = null;
            siticoneTileButton1.IconAlignment = ContentAlignment.MiddleLeft;
            siticoneTileButton1.IconMargin = new Padding(5);
            siticoneTileButton1.IconPadding = 5;
            siticoneTileButton1.IconSize = new Size(24, 24);
            siticoneTileButton1.IsLoading = false;
            siticoneTileButton1.IsToggled = false;
            siticoneTileButton1.LoadingColor = Color.White;
            siticoneTileButton1.Location = new Point(161, 94);
            siticoneTileButton1.Margin = new Padding(3, 2, 3, 2);
            siticoneTileButton1.MaxRipples = 100;
            siticoneTileButton1.Name = "siticoneTileButton1";
            siticoneTileButton1.PersistState = false;
            siticoneTileButton1.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneTileButton1.RippleFadeStart = 0F;
            siticoneTileButton1.RippleOpacity = 0.1F;
            siticoneTileButton1.RippleSpeed = 20F;
            siticoneTileButton1.ShadowColor = Color.Black;
            siticoneTileButton1.ShadowDepth = 1;
            siticoneTileButton1.ShadowOffset = new Point(1, 1);
            siticoneTileButton1.ShadowOpacity = 0.3F;
            siticoneTileButton1.ShowBadge = false;
            siticoneTileButton1.ShowBorder = false;
            siticoneTileButton1.ShowTextShadow = true;
            siticoneTileButton1.Size = new Size(151, 29);
            siticoneTileButton1.TabIndex = 20;
            siticoneTileButton1.Text = "Export";
            siticoneTileButton1.TooltipAlwaysShow = true;
            siticoneTileButton1.TooltipAutoPopDelay = 5000;
            siticoneTileButton1.TooltipBackColor = Color.Black;
            siticoneTileButton1.TooltipFont = new Font("Segoe UI", 9F);
            siticoneTileButton1.TooltipForeColor = Color.White;
            siticoneTileButton1.TooltipInitialDelay = 500;
            siticoneTileButton1.TooltipReshowDelay = 100;
            siticoneTileButton1.TooltipText = "";
            siticoneTileButton1.TopLeftRadius = 12F;
            siticoneTileButton1.TopRightRadius = 12F;
            siticoneTileButton1.UseGradient = false;
            // 
            // siticoneTileButton2
            // 
            siticoneTileButton2.AccessibleDescription = "A customizable tile button";
            siticoneTileButton2.AccessibleName = "TileButton";
            siticoneTileButton2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            siticoneTileButton2.BackColor = Color.Transparent;
            siticoneTileButton2.BadgeColor = Color.Red;
            siticoneTileButton2.BadgeFont = "Segoe UI";
            siticoneTileButton2.BadgePosition = new Point(134, 5);
            siticoneTileButton2.BadgeText = "";
            siticoneTileButton2.BaseColor = Color.FromArgb(50, 150, 215);
            siticoneTileButton2.BorderWidth = 1F;
            siticoneTileButton2.BottomLeftRadius = 12F;
            siticoneTileButton2.BottomRightRadius = 12F;
            siticoneTileButton2.ColorTransitionSpeed = 0.15F;
            siticoneTileButton2.EnableRipple = true;
            siticoneTileButton2.Font = new Font("Segoe UI", 10F);
            siticoneTileButton2.ForeColor = Color.White;
            siticoneTileButton2.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneTileButton2.HoverColor = Color.FromArgb(70, 170, 235);
            siticoneTileButton2.Icon = null;
            siticoneTileButton2.IconAlignment = ContentAlignment.MiddleLeft;
            siticoneTileButton2.IconMargin = new Padding(5);
            siticoneTileButton2.IconPadding = 5;
            siticoneTileButton2.IconSize = new Size(24, 24);
            siticoneTileButton2.IsLoading = false;
            siticoneTileButton2.IsToggled = false;
            siticoneTileButton2.LoadingColor = Color.White;
            siticoneTileButton2.Location = new Point(10, 94);
            siticoneTileButton2.Margin = new Padding(3, 2, 3, 2);
            siticoneTileButton2.MaxRipples = 100;
            siticoneTileButton2.Name = "siticoneTileButton2";
            siticoneTileButton2.PersistState = false;
            siticoneTileButton2.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneTileButton2.RippleFadeStart = 0F;
            siticoneTileButton2.RippleOpacity = 0.1F;
            siticoneTileButton2.RippleSpeed = 20F;
            siticoneTileButton2.ShadowColor = Color.Black;
            siticoneTileButton2.ShadowDepth = 1;
            siticoneTileButton2.ShadowOffset = new Point(1, 1);
            siticoneTileButton2.ShadowOpacity = 0.3F;
            siticoneTileButton2.ShowBadge = false;
            siticoneTileButton2.ShowBorder = false;
            siticoneTileButton2.ShowTextShadow = true;
            siticoneTileButton2.Size = new Size(145, 29);
            siticoneTileButton2.TabIndex = 19;
            siticoneTileButton2.Text = "Open";
            siticoneTileButton2.TooltipAlwaysShow = true;
            siticoneTileButton2.TooltipAutoPopDelay = 5000;
            siticoneTileButton2.TooltipBackColor = Color.Black;
            siticoneTileButton2.TooltipFont = new Font("Segoe UI", 9F);
            siticoneTileButton2.TooltipForeColor = Color.White;
            siticoneTileButton2.TooltipInitialDelay = 500;
            siticoneTileButton2.TooltipReshowDelay = 100;
            siticoneTileButton2.TooltipText = "";
            siticoneTileButton2.TopLeftRadius = 12F;
            siticoneTileButton2.TopRightRadius = 12F;
            siticoneTileButton2.UseGradient = false;
            // 
            // label13
            // 
            label13.Dock = DockStyle.Top;
            label13.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.White;
            label13.Location = new Point(9, 8);
            label13.Name = "label13";
            label13.Size = new Size(304, 33);
            label13.TabIndex = 17;
            label13.Text = "\"John_Doe_Resume\"";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Home
            // 
            BackColor = SystemColors.Control;
            Controls.Add(tableLayoutPanel3);
            Controls.Add(panel1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel5);
            Controls.Add(tableLayoutPanel2);
            Name = "Home";
            Size = new Size(1557, 907);
            tableLayoutPanel3.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel10.ResumeLayout(false);
            ((ISupportInitialize)pictureBox8).EndInit();
            panel4.ResumeLayout(false);
            ((ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            ((ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            ((ISupportInitialize)pictureBox2).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel8.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
