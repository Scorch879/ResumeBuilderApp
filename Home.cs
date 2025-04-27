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
        private string? resumesCreated;
        private string? savedResumes;
        private string? resumesExported;
        private string? resumesSent;

        public string? CurrentUsername
        {
            get => currentUsername;
            set
            {
                currentUsername = value;
                userLbl.Text = $"Welcome, {currentUsername}!";
            }
        }

        public Home()
        {
            InitializeComponent();
            userLbl.Text = CurrentUsername;
        }

        public override void Refresh()
        {
            base.Refresh();
            if (!string.IsNullOrEmpty(CurrentUsername))
            {
                UpdateAnalyticsLabels(CurrentUsername); 
            }
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            savedResumeslbl = new Label();
            pictureBox2 = new PictureBox();
            panel14 = new Panel();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel26 = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            panel20 = new Panel();
            label23 = new Label();
            label29 = new Label();
            siticoneTileButton9 = new SiticoneNetCoreUI.SiticoneTileButton();
            siticoneTileButton10 = new SiticoneNetCoreUI.SiticoneTileButton();
            label30 = new Label();
            panel21 = new Panel();
            label31 = new Label();
            label32 = new Label();
            siticoneTileButton15 = new SiticoneNetCoreUI.SiticoneTileButton();
            siticoneTileButton16 = new SiticoneNetCoreUI.SiticoneTileButton();
            label33 = new Label();
            panel22 = new Panel();
            siticoneTileButton17 = new SiticoneNetCoreUI.SiticoneTileButton();
            label34 = new Label();
            label35 = new Label();
            siticoneTileButton18 = new SiticoneNetCoreUI.SiticoneTileButton();
            label36 = new Label();
            panel23 = new Panel();
            label37 = new Label();
            label38 = new Label();
            siticoneTileButton19 = new SiticoneNetCoreUI.SiticoneTileButton();
            siticoneTileButton20 = new SiticoneNetCoreUI.SiticoneTileButton();
            label39 = new Label();
            panel24 = new Panel();
            label40 = new Label();
            label41 = new Label();
            siticoneTileButton21 = new SiticoneNetCoreUI.SiticoneTileButton();
            siticoneTileButton22 = new SiticoneNetCoreUI.SiticoneTileButton();
            label42 = new Label();
            panel25 = new Panel();
            label43 = new Label();
            label44 = new Label();
            siticoneTileButton23 = new SiticoneNetCoreUI.SiticoneTileButton();
            siticoneTileButton24 = new SiticoneNetCoreUI.SiticoneTileButton();
            label45 = new Label();
            panel13 = new Panel();
            panel19 = new Panel();
            label21 = new Label();
            label22 = new Label();
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
            panel14.SuspendLayout();
            ((ISupportInitialize)chart1).BeginInit();
            panel26.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel20.SuspendLayout();
            panel21.SuspendLayout();
            panel22.SuspendLayout();
            panel23.SuspendLayout();
            panel24.SuspendLayout();
            panel25.SuspendLayout();
            panel19.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.FromArgb(216, 225, 233);
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.Controls.Add(panel12, 2, 0);
            tableLayoutPanel3.Controls.Add(panel11, 1, 0);
            tableLayoutPanel3.Controls.Add(panel9, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Bottom;
            tableLayoutPanel3.Location = new Point(0, 815);
            tableLayoutPanel3.Margin = new Padding(26, 22, 26, 22);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.Padding = new Padding(3, 2, 3, 2);
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(1557, 92);
            tableLayoutPanel3.TabIndex = 19;
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(41, 128, 185);
            panel12.BorderStyle = BorderStyle.FixedSingle;
            panel12.Controls.Add(iconButton2);
            panel12.Dock = DockStyle.Fill;
            panel12.Location = new Point(1039, 6);
            panel12.Margin = new Padding(4);
            panel12.Name = "panel12";
            panel12.Padding = new Padding(1);
            panel12.Size = new Size(511, 80);
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
            iconButton2.Padding = new Padding(140, 0, 0, 0);
            iconButton2.Size = new Size(507, 76);
            iconButton2.TabIndex = 24;
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
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(523, 6);
            panel11.Margin = new Padding(4);
            panel11.Name = "panel11";
            panel11.Padding = new Padding(1);
            panel11.Size = new Size(508, 80);
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
            iconButton1.Padding = new Padding(160, 0, 0, 0);
            iconButton1.Size = new Size(504, 76);
            iconButton1.TabIndex = 23;
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
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(7, 6);
            panel9.Margin = new Padding(4);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(1);
            panel9.Size = new Size(508, 80);
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
            homeBtn.Padding = new Padding(100, 0, 0, 0);
            homeBtn.Size = new Size(504, 76);
            homeBtn.TabIndex = 32;
            homeBtn.Text = " Create New Resume";
            homeBtn.TextAlign = ContentAlignment.MiddleLeft;
            homeBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            homeBtn.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 31, 84);
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
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
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
            userLbl.BackColor = Color.Transparent;
            userLbl.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userLbl.ForeColor = Color.White;
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
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 112);
            tableLayoutPanel1.Margin = new Padding(9, 8, 9, 8);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 132F));
            tableLayoutPanel1.Size = new Size(696, 155);
            tableLayoutPanel1.TabIndex = 23;
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
            resumesSentlbl.Text = "0";
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
            resumesExportlbl.Text = "0";
            // 
            // pictureBox3
            // 
            pictureBox3.Dock = DockStyle.Top;
            pictureBox3.Image = Properties.Resources._46076;
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
            resumesCreatedlbl.Text = "0";
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
            panel3.Controls.Add(savedResumeslbl);
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
            label2.Text = "SAVED\r\nRESUMES:\r\n";
            // 
            // savedResumeslbl
            // 
            savedResumeslbl.Dock = DockStyle.Bottom;
            savedResumeslbl.Font = new Font("Century Gothic", 13.8F);
            savedResumeslbl.ForeColor = Color.White;
            savedResumeslbl.Location = new Point(9, 101);
            savedResumeslbl.Name = "savedResumeslbl";
            savedResumeslbl.Size = new Size(143, 29);
            savedResumeslbl.TabIndex = 16;
            savedResumeslbl.Text = "0";
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
            // panel14
            // 
            panel14.Controls.Add(chart1);
            panel14.Dock = DockStyle.Right;
            panel14.Location = new Point(696, 112);
            panel14.Name = "panel14";
            panel14.Size = new Size(861, 703);
            panel14.TabIndex = 30;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(12, 6);
            chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart1.Series.Add(series2);
            chart1.Size = new Size(616, 457);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            // 
            // panel26
            // 
            panel26.Controls.Add(tableLayoutPanel4);
            panel26.Controls.Add(panel13);
            panel26.Controls.Add(panel19);
            panel26.Dock = DockStyle.Fill;
            panel26.Location = new Point(0, 267);
            panel26.Name = "panel26";
            panel26.Size = new Size(696, 548);
            panel26.TabIndex = 31;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.FromArgb(216, 225, 233);
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.Controls.Add(panel20, 1, 2);
            tableLayoutPanel4.Controls.Add(panel21, 0, 2);
            tableLayoutPanel4.Controls.Add(panel22, 1, 1);
            tableLayoutPanel4.Controls.Add(panel23, 0, 1);
            tableLayoutPanel4.Controls.Add(panel24, 1, 0);
            tableLayoutPanel4.Controls.Add(panel25, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 120);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.Size = new Size(696, 428);
            tableLayoutPanel4.TabIndex = 34;
            // 
            // panel20
            // 
            panel20.BackColor = Color.FromArgb(41, 128, 185);
            panel20.BorderStyle = BorderStyle.FixedSingle;
            panel20.Controls.Add(label23);
            panel20.Controls.Add(label29);
            panel20.Controls.Add(siticoneTileButton9);
            panel20.Controls.Add(siticoneTileButton10);
            panel20.Controls.Add(label30);
            panel20.Dock = DockStyle.Fill;
            panel20.Location = new Point(336, 288);
            panel20.Margin = new Padding(4);
            panel20.Name = "panel20";
            panel20.Padding = new Padding(9, 8, 9, 8);
            panel20.Size = new Size(356, 136);
            panel20.TabIndex = 27;
            // 
            // label23
            // 
            label23.Dock = DockStyle.Top;
            label23.Font = new Font("Century Gothic", 13.8F);
            label23.ForeColor = Color.White;
            label23.Location = new Point(9, 65);
            label23.Name = "label23";
            label23.Size = new Size(336, 25);
            label23.TabIndex = 23;
            label23.Text = "Status : Draft";
            // 
            // label29
            // 
            label29.Dock = DockStyle.Top;
            label29.Font = new Font("Century Gothic", 13.8F);
            label29.ForeColor = Color.White;
            label29.Location = new Point(9, 41);
            label29.Name = "label29";
            label29.Size = new Size(336, 24);
            label29.TabIndex = 22;
            label29.Text = "Date Modified : 12/02/2024";
            // 
            // siticoneTileButton9
            // 
            siticoneTileButton9.AccessibleDescription = "A customizable tile button";
            siticoneTileButton9.AccessibleName = "TileButton";
            siticoneTileButton9.BackColor = Color.Transparent;
            siticoneTileButton9.BadgeColor = Color.Red;
            siticoneTileButton9.BadgeFont = "Segoe UI";
            siticoneTileButton9.BadgePosition = new Point(134, 5);
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
            siticoneTileButton9.Location = new Point(168, 92);
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
            siticoneTileButton9.Size = new Size(145, 29);
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
            // siticoneTileButton10
            // 
            siticoneTileButton10.AccessibleDescription = "A customizable tile button";
            siticoneTileButton10.AccessibleName = "TileButton";
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
            siticoneTileButton10.Location = new Point(17, 94);
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
            siticoneTileButton10.TabIndex = 19;
            siticoneTileButton10.Text = "Edit";
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
            // label30
            // 
            label30.Dock = DockStyle.Top;
            label30.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold);
            label30.ForeColor = Color.White;
            label30.Location = new Point(9, 8);
            label30.Name = "label30";
            label30.Size = new Size(336, 33);
            label30.TabIndex = 17;
            label30.Text = "\"Application Resume\"";
            label30.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel21
            // 
            panel21.BackColor = Color.FromArgb(41, 128, 185);
            panel21.BorderStyle = BorderStyle.FixedSingle;
            panel21.Controls.Add(label31);
            panel21.Controls.Add(label32);
            panel21.Controls.Add(siticoneTileButton15);
            panel21.Controls.Add(siticoneTileButton16);
            panel21.Controls.Add(label33);
            panel21.Dock = DockStyle.Fill;
            panel21.Location = new Point(4, 288);
            panel21.Margin = new Padding(4);
            panel21.Name = "panel21";
            panel21.Padding = new Padding(9, 8, 9, 8);
            panel21.Size = new Size(324, 136);
            panel21.TabIndex = 26;
            // 
            // label31
            // 
            label31.Dock = DockStyle.Top;
            label31.Font = new Font("Century Gothic", 13.8F);
            label31.ForeColor = Color.White;
            label31.Location = new Point(9, 65);
            label31.Name = "label31";
            label31.Size = new Size(304, 25);
            label31.TabIndex = 23;
            label31.Text = "Status : Draft";
            // 
            // label32
            // 
            label32.Dock = DockStyle.Top;
            label32.Font = new Font("Century Gothic", 13.8F);
            label32.ForeColor = Color.White;
            label32.Location = new Point(9, 41);
            label32.Name = "label32";
            label32.Size = new Size(304, 24);
            label32.TabIndex = 22;
            label32.Text = "Date Modified : 12/02/2024";
            // 
            // siticoneTileButton15
            // 
            siticoneTileButton15.AccessibleDescription = "A customizable tile button";
            siticoneTileButton15.AccessibleName = "TileButton";
            siticoneTileButton15.BackColor = Color.Transparent;
            siticoneTileButton15.BadgeColor = Color.Red;
            siticoneTileButton15.BadgeFont = "Segoe UI";
            siticoneTileButton15.BadgePosition = new Point(140, 5);
            siticoneTileButton15.BadgeText = "";
            siticoneTileButton15.BaseColor = Color.FromArgb(50, 150, 215);
            siticoneTileButton15.BorderWidth = 1F;
            siticoneTileButton15.BottomLeftRadius = 12F;
            siticoneTileButton15.BottomRightRadius = 12F;
            siticoneTileButton15.ColorTransitionSpeed = 0.15F;
            siticoneTileButton15.EnableRipple = true;
            siticoneTileButton15.Font = new Font("Segoe UI", 10F);
            siticoneTileButton15.ForeColor = Color.White;
            siticoneTileButton15.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneTileButton15.HoverColor = Color.FromArgb(70, 170, 235);
            siticoneTileButton15.Icon = null;
            siticoneTileButton15.IconAlignment = ContentAlignment.MiddleLeft;
            siticoneTileButton15.IconMargin = new Padding(5);
            siticoneTileButton15.IconPadding = 5;
            siticoneTileButton15.IconSize = new Size(24, 24);
            siticoneTileButton15.IsLoading = false;
            siticoneTileButton15.IsToggled = false;
            siticoneTileButton15.LoadingColor = Color.White;
            siticoneTileButton15.Location = new Point(162, 94);
            siticoneTileButton15.Margin = new Padding(3, 2, 3, 2);
            siticoneTileButton15.MaxRipples = 100;
            siticoneTileButton15.Name = "siticoneTileButton15";
            siticoneTileButton15.PersistState = false;
            siticoneTileButton15.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneTileButton15.RippleFadeStart = 0F;
            siticoneTileButton15.RippleOpacity = 0.1F;
            siticoneTileButton15.RippleSpeed = 20F;
            siticoneTileButton15.ShadowColor = Color.Black;
            siticoneTileButton15.ShadowDepth = 1;
            siticoneTileButton15.ShadowOffset = new Point(1, 1);
            siticoneTileButton15.ShadowOpacity = 0.3F;
            siticoneTileButton15.ShowBadge = false;
            siticoneTileButton15.ShowBorder = false;
            siticoneTileButton15.ShowTextShadow = true;
            siticoneTileButton15.Size = new Size(151, 29);
            siticoneTileButton15.TabIndex = 20;
            siticoneTileButton15.Text = "Delete";
            siticoneTileButton15.TooltipAlwaysShow = true;
            siticoneTileButton15.TooltipAutoPopDelay = 5000;
            siticoneTileButton15.TooltipBackColor = Color.Black;
            siticoneTileButton15.TooltipFont = new Font("Segoe UI", 9F);
            siticoneTileButton15.TooltipForeColor = Color.White;
            siticoneTileButton15.TooltipInitialDelay = 500;
            siticoneTileButton15.TooltipReshowDelay = 100;
            siticoneTileButton15.TooltipText = "";
            siticoneTileButton15.TopLeftRadius = 12F;
            siticoneTileButton15.TopRightRadius = 12F;
            siticoneTileButton15.UseGradient = false;
            // 
            // siticoneTileButton16
            // 
            siticoneTileButton16.AccessibleDescription = "A customizable tile button";
            siticoneTileButton16.AccessibleName = "TileButton";
            siticoneTileButton16.BackColor = Color.Transparent;
            siticoneTileButton16.BadgeColor = Color.Red;
            siticoneTileButton16.BadgeFont = "Segoe UI";
            siticoneTileButton16.BadgePosition = new Point(134, 5);
            siticoneTileButton16.BadgeText = "";
            siticoneTileButton16.BaseColor = Color.FromArgb(50, 150, 215);
            siticoneTileButton16.BorderWidth = 1F;
            siticoneTileButton16.BottomLeftRadius = 12F;
            siticoneTileButton16.BottomRightRadius = 12F;
            siticoneTileButton16.ColorTransitionSpeed = 0.15F;
            siticoneTileButton16.EnableRipple = true;
            siticoneTileButton16.Font = new Font("Segoe UI", 10F);
            siticoneTileButton16.ForeColor = Color.White;
            siticoneTileButton16.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneTileButton16.HoverColor = Color.FromArgb(70, 170, 235);
            siticoneTileButton16.Icon = null;
            siticoneTileButton16.IconAlignment = ContentAlignment.MiddleLeft;
            siticoneTileButton16.IconMargin = new Padding(5);
            siticoneTileButton16.IconPadding = 5;
            siticoneTileButton16.IconSize = new Size(24, 24);
            siticoneTileButton16.IsLoading = false;
            siticoneTileButton16.IsToggled = false;
            siticoneTileButton16.LoadingColor = Color.White;
            siticoneTileButton16.Location = new Point(11, 94);
            siticoneTileButton16.Margin = new Padding(3, 2, 3, 2);
            siticoneTileButton16.MaxRipples = 100;
            siticoneTileButton16.Name = "siticoneTileButton16";
            siticoneTileButton16.PersistState = false;
            siticoneTileButton16.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneTileButton16.RippleFadeStart = 0F;
            siticoneTileButton16.RippleOpacity = 0.1F;
            siticoneTileButton16.RippleSpeed = 20F;
            siticoneTileButton16.ShadowColor = Color.Black;
            siticoneTileButton16.ShadowDepth = 1;
            siticoneTileButton16.ShadowOffset = new Point(1, 1);
            siticoneTileButton16.ShadowOpacity = 0.3F;
            siticoneTileButton16.ShowBadge = false;
            siticoneTileButton16.ShowBorder = false;
            siticoneTileButton16.ShowTextShadow = true;
            siticoneTileButton16.Size = new Size(145, 29);
            siticoneTileButton16.TabIndex = 19;
            siticoneTileButton16.Text = "Edit";
            siticoneTileButton16.TooltipAlwaysShow = true;
            siticoneTileButton16.TooltipAutoPopDelay = 5000;
            siticoneTileButton16.TooltipBackColor = Color.Black;
            siticoneTileButton16.TooltipFont = new Font("Segoe UI", 9F);
            siticoneTileButton16.TooltipForeColor = Color.White;
            siticoneTileButton16.TooltipInitialDelay = 500;
            siticoneTileButton16.TooltipReshowDelay = 100;
            siticoneTileButton16.TooltipText = "";
            siticoneTileButton16.TopLeftRadius = 12F;
            siticoneTileButton16.TopRightRadius = 12F;
            siticoneTileButton16.UseGradient = false;
            // 
            // label33
            // 
            label33.Dock = DockStyle.Top;
            label33.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold);
            label33.ForeColor = Color.White;
            label33.Location = new Point(9, 8);
            label33.Name = "label33";
            label33.Size = new Size(304, 33);
            label33.TabIndex = 17;
            label33.Text = "\"Application Resume\"";
            label33.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel22
            // 
            panel22.BackColor = Color.FromArgb(41, 128, 185);
            panel22.BorderStyle = BorderStyle.FixedSingle;
            panel22.Controls.Add(siticoneTileButton17);
            panel22.Controls.Add(label34);
            panel22.Controls.Add(label35);
            panel22.Controls.Add(siticoneTileButton18);
            panel22.Controls.Add(label36);
            panel22.Dock = DockStyle.Fill;
            panel22.Location = new Point(336, 146);
            panel22.Margin = new Padding(4);
            panel22.Name = "panel22";
            panel22.Padding = new Padding(9, 8, 9, 8);
            panel22.Size = new Size(356, 134);
            panel22.TabIndex = 22;
            // 
            // siticoneTileButton17
            // 
            siticoneTileButton17.AccessibleDescription = "A customizable tile button";
            siticoneTileButton17.AccessibleName = "TileButton";
            siticoneTileButton17.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            siticoneTileButton17.BackColor = Color.Transparent;
            siticoneTileButton17.BadgeColor = Color.Red;
            siticoneTileButton17.BadgeFont = "Segoe UI";
            siticoneTileButton17.BadgePosition = new Point(134, 5);
            siticoneTileButton17.BadgeText = "";
            siticoneTileButton17.BaseColor = Color.FromArgb(50, 150, 215);
            siticoneTileButton17.BorderWidth = 1F;
            siticoneTileButton17.BottomLeftRadius = 12F;
            siticoneTileButton17.BottomRightRadius = 12F;
            siticoneTileButton17.ColorTransitionSpeed = 0.15F;
            siticoneTileButton17.EnableRipple = true;
            siticoneTileButton17.Font = new Font("Segoe UI", 10F);
            siticoneTileButton17.ForeColor = Color.White;
            siticoneTileButton17.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneTileButton17.HoverColor = Color.FromArgb(70, 170, 235);
            siticoneTileButton17.Icon = null;
            siticoneTileButton17.IconAlignment = ContentAlignment.MiddleLeft;
            siticoneTileButton17.IconMargin = new Padding(5);
            siticoneTileButton17.IconPadding = 5;
            siticoneTileButton17.IconSize = new Size(24, 24);
            siticoneTileButton17.IsLoading = false;
            siticoneTileButton17.IsToggled = false;
            siticoneTileButton17.LoadingColor = Color.White;
            siticoneTileButton17.Location = new Point(30, 110);
            siticoneTileButton17.Margin = new Padding(3, 2, 3, 2);
            siticoneTileButton17.MaxRipples = 100;
            siticoneTileButton17.Name = "siticoneTileButton17";
            siticoneTileButton17.PersistState = false;
            siticoneTileButton17.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneTileButton17.RippleFadeStart = 0F;
            siticoneTileButton17.RippleOpacity = 0.1F;
            siticoneTileButton17.RippleSpeed = 20F;
            siticoneTileButton17.ShadowColor = Color.Black;
            siticoneTileButton17.ShadowDepth = 1;
            siticoneTileButton17.ShadowOffset = new Point(1, 1);
            siticoneTileButton17.ShadowOpacity = 0.3F;
            siticoneTileButton17.ShowBadge = false;
            siticoneTileButton17.ShowBorder = false;
            siticoneTileButton17.ShowTextShadow = true;
            siticoneTileButton17.Size = new Size(145, 152);
            siticoneTileButton17.TabIndex = 24;
            siticoneTileButton17.Text = "Open";
            siticoneTileButton17.TooltipAlwaysShow = true;
            siticoneTileButton17.TooltipAutoPopDelay = 5000;
            siticoneTileButton17.TooltipBackColor = Color.Black;
            siticoneTileButton17.TooltipFont = new Font("Segoe UI", 9F);
            siticoneTileButton17.TooltipForeColor = Color.White;
            siticoneTileButton17.TooltipInitialDelay = 500;
            siticoneTileButton17.TooltipReshowDelay = 100;
            siticoneTileButton17.TooltipText = "";
            siticoneTileButton17.TopLeftRadius = 12F;
            siticoneTileButton17.TopRightRadius = 12F;
            siticoneTileButton17.UseGradient = false;
            // 
            // label34
            // 
            label34.Dock = DockStyle.Top;
            label34.Font = new Font("Century Gothic", 13.8F);
            label34.ForeColor = Color.White;
            label34.Location = new Point(9, 65);
            label34.Name = "label34";
            label34.Size = new Size(336, 25);
            label34.TabIndex = 23;
            label34.Text = "Status : Final";
            // 
            // label35
            // 
            label35.Dock = DockStyle.Top;
            label35.Font = new Font("Century Gothic", 13.8F);
            label35.ForeColor = Color.White;
            label35.Location = new Point(9, 41);
            label35.Name = "label35";
            label35.Size = new Size(336, 24);
            label35.TabIndex = 22;
            label35.Text = "Date Modified : 01/02/2024";
            // 
            // siticoneTileButton18
            // 
            siticoneTileButton18.AccessibleDescription = "A customizable tile button";
            siticoneTileButton18.AccessibleName = "TileButton";
            siticoneTileButton18.BackColor = Color.Transparent;
            siticoneTileButton18.BadgeColor = Color.Red;
            siticoneTileButton18.BadgeFont = "Segoe UI";
            siticoneTileButton18.BadgePosition = new Point(134, 5);
            siticoneTileButton18.BadgeText = "";
            siticoneTileButton18.BaseColor = Color.FromArgb(50, 150, 215);
            siticoneTileButton18.BorderWidth = 1F;
            siticoneTileButton18.BottomLeftRadius = 12F;
            siticoneTileButton18.BottomRightRadius = 12F;
            siticoneTileButton18.ColorTransitionSpeed = 0.15F;
            siticoneTileButton18.EnableRipple = true;
            siticoneTileButton18.Font = new Font("Segoe UI", 10F);
            siticoneTileButton18.ForeColor = Color.White;
            siticoneTileButton18.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneTileButton18.HoverColor = Color.FromArgb(70, 170, 235);
            siticoneTileButton18.Icon = null;
            siticoneTileButton18.IconAlignment = ContentAlignment.MiddleLeft;
            siticoneTileButton18.IconMargin = new Padding(5);
            siticoneTileButton18.IconPadding = 5;
            siticoneTileButton18.IconSize = new Size(24, 24);
            siticoneTileButton18.IsLoading = false;
            siticoneTileButton18.IsToggled = false;
            siticoneTileButton18.LoadingColor = Color.White;
            siticoneTileButton18.Location = new Point(168, 94);
            siticoneTileButton18.Margin = new Padding(3, 2, 3, 2);
            siticoneTileButton18.MaxRipples = 100;
            siticoneTileButton18.Name = "siticoneTileButton18";
            siticoneTileButton18.PersistState = false;
            siticoneTileButton18.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneTileButton18.RippleFadeStart = 0F;
            siticoneTileButton18.RippleOpacity = 0.1F;
            siticoneTileButton18.RippleSpeed = 20F;
            siticoneTileButton18.ShadowColor = Color.Black;
            siticoneTileButton18.ShadowDepth = 1;
            siticoneTileButton18.ShadowOffset = new Point(1, 1);
            siticoneTileButton18.ShadowOpacity = 0.3F;
            siticoneTileButton18.ShowBadge = false;
            siticoneTileButton18.ShowBorder = false;
            siticoneTileButton18.ShowTextShadow = true;
            siticoneTileButton18.Size = new Size(145, 29);
            siticoneTileButton18.TabIndex = 20;
            siticoneTileButton18.Text = "Delete";
            siticoneTileButton18.TooltipAlwaysShow = true;
            siticoneTileButton18.TooltipAutoPopDelay = 5000;
            siticoneTileButton18.TooltipBackColor = Color.Black;
            siticoneTileButton18.TooltipFont = new Font("Segoe UI", 9F);
            siticoneTileButton18.TooltipForeColor = Color.White;
            siticoneTileButton18.TooltipInitialDelay = 500;
            siticoneTileButton18.TooltipReshowDelay = 100;
            siticoneTileButton18.TooltipText = "";
            siticoneTileButton18.TopLeftRadius = 12F;
            siticoneTileButton18.TopRightRadius = 12F;
            siticoneTileButton18.UseGradient = false;
            // 
            // label36
            // 
            label36.Dock = DockStyle.Top;
            label36.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold);
            label36.ForeColor = Color.White;
            label36.Location = new Point(9, 8);
            label36.Name = "label36";
            label36.Size = new Size(336, 33);
            label36.TabIndex = 17;
            label36.Text = "\"Application Resume\"";
            label36.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel23
            // 
            panel23.BackColor = Color.FromArgb(41, 128, 185);
            panel23.BorderStyle = BorderStyle.FixedSingle;
            panel23.Controls.Add(label37);
            panel23.Controls.Add(label38);
            panel23.Controls.Add(siticoneTileButton19);
            panel23.Controls.Add(siticoneTileButton20);
            panel23.Controls.Add(label39);
            panel23.Dock = DockStyle.Fill;
            panel23.Location = new Point(4, 146);
            panel23.Margin = new Padding(4);
            panel23.Name = "panel23";
            panel23.Padding = new Padding(9, 8, 9, 8);
            panel23.Size = new Size(324, 134);
            panel23.TabIndex = 21;
            // 
            // label37
            // 
            label37.Dock = DockStyle.Top;
            label37.Font = new Font("Century Gothic", 13.8F);
            label37.ForeColor = Color.White;
            label37.Location = new Point(9, 65);
            label37.Name = "label37";
            label37.Size = new Size(304, 25);
            label37.TabIndex = 23;
            label37.Text = "Status : Draft";
            // 
            // label38
            // 
            label38.Dock = DockStyle.Top;
            label38.Font = new Font("Century Gothic", 13.8F);
            label38.ForeColor = Color.White;
            label38.Location = new Point(9, 41);
            label38.Name = "label38";
            label38.Size = new Size(304, 24);
            label38.TabIndex = 22;
            label38.Text = "Date Modified : Today";
            // 
            // siticoneTileButton19
            // 
            siticoneTileButton19.AccessibleDescription = "A customizable tile button";
            siticoneTileButton19.AccessibleName = "TileButton";
            siticoneTileButton19.BackColor = Color.Transparent;
            siticoneTileButton19.BadgeColor = Color.Red;
            siticoneTileButton19.BadgeFont = "Segoe UI";
            siticoneTileButton19.BadgePosition = new Point(140, 5);
            siticoneTileButton19.BadgeText = "";
            siticoneTileButton19.BaseColor = Color.FromArgb(50, 150, 215);
            siticoneTileButton19.BorderWidth = 1F;
            siticoneTileButton19.BottomLeftRadius = 12F;
            siticoneTileButton19.BottomRightRadius = 12F;
            siticoneTileButton19.ColorTransitionSpeed = 0.15F;
            siticoneTileButton19.EnableRipple = true;
            siticoneTileButton19.Font = new Font("Segoe UI", 10F);
            siticoneTileButton19.ForeColor = Color.White;
            siticoneTileButton19.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneTileButton19.HoverColor = Color.FromArgb(70, 170, 235);
            siticoneTileButton19.Icon = null;
            siticoneTileButton19.IconAlignment = ContentAlignment.MiddleLeft;
            siticoneTileButton19.IconMargin = new Padding(5);
            siticoneTileButton19.IconPadding = 5;
            siticoneTileButton19.IconSize = new Size(24, 24);
            siticoneTileButton19.IsLoading = false;
            siticoneTileButton19.IsToggled = false;
            siticoneTileButton19.LoadingColor = Color.White;
            siticoneTileButton19.Location = new Point(162, 94);
            siticoneTileButton19.Margin = new Padding(3, 2, 3, 2);
            siticoneTileButton19.MaxRipples = 100;
            siticoneTileButton19.Name = "siticoneTileButton19";
            siticoneTileButton19.PersistState = false;
            siticoneTileButton19.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneTileButton19.RippleFadeStart = 0F;
            siticoneTileButton19.RippleOpacity = 0.1F;
            siticoneTileButton19.RippleSpeed = 20F;
            siticoneTileButton19.ShadowColor = Color.Black;
            siticoneTileButton19.ShadowDepth = 1;
            siticoneTileButton19.ShadowOffset = new Point(1, 1);
            siticoneTileButton19.ShadowOpacity = 0.3F;
            siticoneTileButton19.ShowBadge = false;
            siticoneTileButton19.ShowBorder = false;
            siticoneTileButton19.ShowTextShadow = true;
            siticoneTileButton19.Size = new Size(151, 29);
            siticoneTileButton19.TabIndex = 20;
            siticoneTileButton19.Text = "Delete";
            siticoneTileButton19.TooltipAlwaysShow = true;
            siticoneTileButton19.TooltipAutoPopDelay = 5000;
            siticoneTileButton19.TooltipBackColor = Color.Black;
            siticoneTileButton19.TooltipFont = new Font("Segoe UI", 9F);
            siticoneTileButton19.TooltipForeColor = Color.White;
            siticoneTileButton19.TooltipInitialDelay = 500;
            siticoneTileButton19.TooltipReshowDelay = 100;
            siticoneTileButton19.TooltipText = "";
            siticoneTileButton19.TopLeftRadius = 12F;
            siticoneTileButton19.TopRightRadius = 12F;
            siticoneTileButton19.UseGradient = false;
            // 
            // siticoneTileButton20
            // 
            siticoneTileButton20.AccessibleDescription = "A customizable tile button";
            siticoneTileButton20.AccessibleName = "TileButton";
            siticoneTileButton20.BackColor = Color.Transparent;
            siticoneTileButton20.BadgeColor = Color.Red;
            siticoneTileButton20.BadgeFont = "Segoe UI";
            siticoneTileButton20.BadgePosition = new Point(134, 5);
            siticoneTileButton20.BadgeText = "";
            siticoneTileButton20.BaseColor = Color.FromArgb(50, 150, 215);
            siticoneTileButton20.BorderWidth = 1F;
            siticoneTileButton20.BottomLeftRadius = 12F;
            siticoneTileButton20.BottomRightRadius = 12F;
            siticoneTileButton20.ColorTransitionSpeed = 0.15F;
            siticoneTileButton20.EnableRipple = true;
            siticoneTileButton20.Font = new Font("Segoe UI", 10F);
            siticoneTileButton20.ForeColor = Color.White;
            siticoneTileButton20.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneTileButton20.HoverColor = Color.FromArgb(70, 170, 235);
            siticoneTileButton20.Icon = null;
            siticoneTileButton20.IconAlignment = ContentAlignment.MiddleLeft;
            siticoneTileButton20.IconMargin = new Padding(5);
            siticoneTileButton20.IconPadding = 5;
            siticoneTileButton20.IconSize = new Size(24, 24);
            siticoneTileButton20.IsLoading = false;
            siticoneTileButton20.IsToggled = false;
            siticoneTileButton20.LoadingColor = Color.White;
            siticoneTileButton20.Location = new Point(11, 94);
            siticoneTileButton20.Margin = new Padding(3, 2, 3, 2);
            siticoneTileButton20.MaxRipples = 100;
            siticoneTileButton20.Name = "siticoneTileButton20";
            siticoneTileButton20.PersistState = false;
            siticoneTileButton20.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneTileButton20.RippleFadeStart = 0F;
            siticoneTileButton20.RippleOpacity = 0.1F;
            siticoneTileButton20.RippleSpeed = 20F;
            siticoneTileButton20.ShadowColor = Color.Black;
            siticoneTileButton20.ShadowDepth = 1;
            siticoneTileButton20.ShadowOffset = new Point(1, 1);
            siticoneTileButton20.ShadowOpacity = 0.3F;
            siticoneTileButton20.ShowBadge = false;
            siticoneTileButton20.ShowBorder = false;
            siticoneTileButton20.ShowTextShadow = true;
            siticoneTileButton20.Size = new Size(145, 29);
            siticoneTileButton20.TabIndex = 19;
            siticoneTileButton20.Text = "Edit";
            siticoneTileButton20.TooltipAlwaysShow = true;
            siticoneTileButton20.TooltipAutoPopDelay = 5000;
            siticoneTileButton20.TooltipBackColor = Color.Black;
            siticoneTileButton20.TooltipFont = new Font("Segoe UI", 9F);
            siticoneTileButton20.TooltipForeColor = Color.White;
            siticoneTileButton20.TooltipInitialDelay = 500;
            siticoneTileButton20.TooltipReshowDelay = 100;
            siticoneTileButton20.TooltipText = "";
            siticoneTileButton20.TopLeftRadius = 12F;
            siticoneTileButton20.TopRightRadius = 12F;
            siticoneTileButton20.UseGradient = false;
            // 
            // label39
            // 
            label39.Dock = DockStyle.Top;
            label39.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold);
            label39.ForeColor = Color.White;
            label39.Location = new Point(9, 8);
            label39.Name = "label39";
            label39.Size = new Size(304, 33);
            label39.TabIndex = 17;
            label39.Text = "\"For Work Resume\"";
            label39.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel24
            // 
            panel24.BackColor = Color.FromArgb(41, 128, 185);
            panel24.BorderStyle = BorderStyle.FixedSingle;
            panel24.Controls.Add(label40);
            panel24.Controls.Add(label41);
            panel24.Controls.Add(siticoneTileButton21);
            panel24.Controls.Add(siticoneTileButton22);
            panel24.Controls.Add(label42);
            panel24.Dock = DockStyle.Fill;
            panel24.Location = new Point(336, 4);
            panel24.Margin = new Padding(4);
            panel24.Name = "panel24";
            panel24.Padding = new Padding(9, 8, 9, 8);
            panel24.Size = new Size(356, 134);
            panel24.TabIndex = 20;
            // 
            // label40
            // 
            label40.Dock = DockStyle.Top;
            label40.Font = new Font("Century Gothic", 13.8F);
            label40.ForeColor = Color.White;
            label40.Location = new Point(9, 65);
            label40.Name = "label40";
            label40.Size = new Size(336, 25);
            label40.TabIndex = 23;
            label40.Text = "Status : Draft";
            // 
            // label41
            // 
            label41.Dock = DockStyle.Top;
            label41.Font = new Font("Century Gothic", 13.8F);
            label41.ForeColor = Color.White;
            label41.Location = new Point(9, 41);
            label41.Name = "label41";
            label41.Size = new Size(336, 24);
            label41.TabIndex = 22;
            label41.Text = "Date Modified : Today";
            // 
            // siticoneTileButton21
            // 
            siticoneTileButton21.AccessibleDescription = "A customizable tile button";
            siticoneTileButton21.AccessibleName = "TileButton";
            siticoneTileButton21.BackColor = Color.Transparent;
            siticoneTileButton21.BadgeColor = Color.Red;
            siticoneTileButton21.BadgeFont = "Segoe UI";
            siticoneTileButton21.BadgePosition = new Point(140, 5);
            siticoneTileButton21.BadgeText = "";
            siticoneTileButton21.BaseColor = Color.FromArgb(50, 150, 215);
            siticoneTileButton21.BorderWidth = 1F;
            siticoneTileButton21.BottomLeftRadius = 12F;
            siticoneTileButton21.BottomRightRadius = 12F;
            siticoneTileButton21.ColorTransitionSpeed = 0.15F;
            siticoneTileButton21.EnableRipple = true;
            siticoneTileButton21.Font = new Font("Segoe UI", 10F);
            siticoneTileButton21.ForeColor = Color.White;
            siticoneTileButton21.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneTileButton21.HoverColor = Color.FromArgb(70, 170, 235);
            siticoneTileButton21.Icon = null;
            siticoneTileButton21.IconAlignment = ContentAlignment.MiddleLeft;
            siticoneTileButton21.IconMargin = new Padding(5);
            siticoneTileButton21.IconPadding = 5;
            siticoneTileButton21.IconSize = new Size(24, 24);
            siticoneTileButton21.IsLoading = false;
            siticoneTileButton21.IsToggled = false;
            siticoneTileButton21.LoadingColor = Color.White;
            siticoneTileButton21.Location = new Point(168, 94);
            siticoneTileButton21.Margin = new Padding(3, 2, 3, 2);
            siticoneTileButton21.MaxRipples = 100;
            siticoneTileButton21.Name = "siticoneTileButton21";
            siticoneTileButton21.PersistState = false;
            siticoneTileButton21.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneTileButton21.RippleFadeStart = 0F;
            siticoneTileButton21.RippleOpacity = 0.1F;
            siticoneTileButton21.RippleSpeed = 20F;
            siticoneTileButton21.ShadowColor = Color.Black;
            siticoneTileButton21.ShadowDepth = 1;
            siticoneTileButton21.ShadowOffset = new Point(1, 1);
            siticoneTileButton21.ShadowOpacity = 0.3F;
            siticoneTileButton21.ShowBadge = false;
            siticoneTileButton21.ShowBorder = false;
            siticoneTileButton21.ShowTextShadow = true;
            siticoneTileButton21.Size = new Size(151, 29);
            siticoneTileButton21.TabIndex = 20;
            siticoneTileButton21.Text = "Delete";
            siticoneTileButton21.TooltipAlwaysShow = true;
            siticoneTileButton21.TooltipAutoPopDelay = 5000;
            siticoneTileButton21.TooltipBackColor = Color.Black;
            siticoneTileButton21.TooltipFont = new Font("Segoe UI", 9F);
            siticoneTileButton21.TooltipForeColor = Color.White;
            siticoneTileButton21.TooltipInitialDelay = 500;
            siticoneTileButton21.TooltipReshowDelay = 100;
            siticoneTileButton21.TooltipText = "";
            siticoneTileButton21.TopLeftRadius = 12F;
            siticoneTileButton21.TopRightRadius = 12F;
            siticoneTileButton21.UseGradient = false;
            // 
            // siticoneTileButton22
            // 
            siticoneTileButton22.AccessibleDescription = "A customizable tile button";
            siticoneTileButton22.AccessibleName = "TileButton";
            siticoneTileButton22.BackColor = Color.Transparent;
            siticoneTileButton22.BadgeColor = Color.Red;
            siticoneTileButton22.BadgeFont = "Segoe UI";
            siticoneTileButton22.BadgePosition = new Point(134, 5);
            siticoneTileButton22.BadgeText = "";
            siticoneTileButton22.BaseColor = Color.FromArgb(50, 150, 215);
            siticoneTileButton22.BorderWidth = 1F;
            siticoneTileButton22.BottomLeftRadius = 12F;
            siticoneTileButton22.BottomRightRadius = 12F;
            siticoneTileButton22.ColorTransitionSpeed = 0.15F;
            siticoneTileButton22.EnableRipple = true;
            siticoneTileButton22.Font = new Font("Segoe UI", 10F);
            siticoneTileButton22.ForeColor = Color.White;
            siticoneTileButton22.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneTileButton22.HoverColor = Color.FromArgb(70, 170, 235);
            siticoneTileButton22.Icon = null;
            siticoneTileButton22.IconAlignment = ContentAlignment.MiddleLeft;
            siticoneTileButton22.IconMargin = new Padding(5);
            siticoneTileButton22.IconPadding = 5;
            siticoneTileButton22.IconSize = new Size(24, 24);
            siticoneTileButton22.IsLoading = false;
            siticoneTileButton22.IsToggled = false;
            siticoneTileButton22.LoadingColor = Color.White;
            siticoneTileButton22.Location = new Point(11, 94);
            siticoneTileButton22.Margin = new Padding(3, 2, 3, 2);
            siticoneTileButton22.MaxRipples = 100;
            siticoneTileButton22.Name = "siticoneTileButton22";
            siticoneTileButton22.PersistState = false;
            siticoneTileButton22.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneTileButton22.RippleFadeStart = 0F;
            siticoneTileButton22.RippleOpacity = 0.1F;
            siticoneTileButton22.RippleSpeed = 20F;
            siticoneTileButton22.ShadowColor = Color.Black;
            siticoneTileButton22.ShadowDepth = 1;
            siticoneTileButton22.ShadowOffset = new Point(1, 1);
            siticoneTileButton22.ShadowOpacity = 0.3F;
            siticoneTileButton22.ShowBadge = false;
            siticoneTileButton22.ShowBorder = false;
            siticoneTileButton22.ShowTextShadow = true;
            siticoneTileButton22.Size = new Size(145, 29);
            siticoneTileButton22.TabIndex = 19;
            siticoneTileButton22.Text = "Edit";
            siticoneTileButton22.TooltipAlwaysShow = true;
            siticoneTileButton22.TooltipAutoPopDelay = 5000;
            siticoneTileButton22.TooltipBackColor = Color.Black;
            siticoneTileButton22.TooltipFont = new Font("Segoe UI", 9F);
            siticoneTileButton22.TooltipForeColor = Color.White;
            siticoneTileButton22.TooltipInitialDelay = 500;
            siticoneTileButton22.TooltipReshowDelay = 100;
            siticoneTileButton22.TooltipText = "";
            siticoneTileButton22.TopLeftRadius = 12F;
            siticoneTileButton22.TopRightRadius = 12F;
            siticoneTileButton22.UseGradient = false;
            // 
            // label42
            // 
            label42.Dock = DockStyle.Top;
            label42.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold);
            label42.ForeColor = Color.White;
            label42.Location = new Point(9, 8);
            label42.Name = "label42";
            label42.Size = new Size(336, 33);
            label42.TabIndex = 17;
            label42.Text = "\"For Work Resume\"";
            label42.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel25
            // 
            panel25.BackColor = Color.FromArgb(41, 128, 185);
            panel25.BorderStyle = BorderStyle.FixedSingle;
            panel25.Controls.Add(label43);
            panel25.Controls.Add(label44);
            panel25.Controls.Add(siticoneTileButton23);
            panel25.Controls.Add(siticoneTileButton24);
            panel25.Controls.Add(label45);
            panel25.Dock = DockStyle.Fill;
            panel25.Location = new Point(4, 4);
            panel25.Margin = new Padding(4);
            panel25.Name = "panel25";
            panel25.Padding = new Padding(9, 8, 9, 8);
            panel25.Size = new Size(324, 134);
            panel25.TabIndex = 15;
            // 
            // label43
            // 
            label43.Dock = DockStyle.Top;
            label43.Font = new Font("Century Gothic", 13.8F);
            label43.ForeColor = Color.White;
            label43.Location = new Point(9, 65);
            label43.Name = "label43";
            label43.Size = new Size(304, 25);
            label43.TabIndex = 24;
            label43.Text = "Status : Final";
            // 
            // label44
            // 
            label44.Dock = DockStyle.Top;
            label44.Font = new Font("Century Gothic", 13.8F);
            label44.ForeColor = Color.White;
            label44.Location = new Point(9, 41);
            label44.Name = "label44";
            label44.Size = new Size(304, 24);
            label44.TabIndex = 23;
            label44.Text = "Date Modified : Yesterday";
            // 
            // siticoneTileButton23
            // 
            siticoneTileButton23.AccessibleDescription = "A customizable tile button";
            siticoneTileButton23.AccessibleName = "TileButton";
            siticoneTileButton23.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            siticoneTileButton23.BackColor = Color.Transparent;
            siticoneTileButton23.BadgeColor = Color.Red;
            siticoneTileButton23.BadgeFont = "Segoe UI";
            siticoneTileButton23.BadgePosition = new Point(140, 5);
            siticoneTileButton23.BadgeText = "";
            siticoneTileButton23.BaseColor = Color.FromArgb(50, 150, 215);
            siticoneTileButton23.BorderWidth = 1F;
            siticoneTileButton23.BottomLeftRadius = 12F;
            siticoneTileButton23.BottomRightRadius = 12F;
            siticoneTileButton23.ColorTransitionSpeed = 0.15F;
            siticoneTileButton23.EnableRipple = true;
            siticoneTileButton23.Font = new Font("Segoe UI", 10F);
            siticoneTileButton23.ForeColor = Color.White;
            siticoneTileButton23.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneTileButton23.HoverColor = Color.FromArgb(70, 170, 235);
            siticoneTileButton23.Icon = null;
            siticoneTileButton23.IconAlignment = ContentAlignment.MiddleLeft;
            siticoneTileButton23.IconMargin = new Padding(5);
            siticoneTileButton23.IconPadding = 5;
            siticoneTileButton23.IconSize = new Size(24, 24);
            siticoneTileButton23.IsLoading = false;
            siticoneTileButton23.IsToggled = false;
            siticoneTileButton23.LoadingColor = Color.White;
            siticoneTileButton23.Location = new Point(188, 110);
            siticoneTileButton23.Margin = new Padding(3, 2, 3, 2);
            siticoneTileButton23.MaxRipples = 100;
            siticoneTileButton23.Name = "siticoneTileButton23";
            siticoneTileButton23.PersistState = false;
            siticoneTileButton23.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneTileButton23.RippleFadeStart = 0F;
            siticoneTileButton23.RippleOpacity = 0.1F;
            siticoneTileButton23.RippleSpeed = 20F;
            siticoneTileButton23.ShadowColor = Color.Black;
            siticoneTileButton23.ShadowDepth = 1;
            siticoneTileButton23.ShadowOffset = new Point(1, 1);
            siticoneTileButton23.ShadowOpacity = 0.3F;
            siticoneTileButton23.ShowBadge = false;
            siticoneTileButton23.ShowBorder = false;
            siticoneTileButton23.ShowTextShadow = true;
            siticoneTileButton23.Size = new Size(151, 92);
            siticoneTileButton23.TabIndex = 20;
            siticoneTileButton23.Text = "Export";
            siticoneTileButton23.TooltipAlwaysShow = true;
            siticoneTileButton23.TooltipAutoPopDelay = 5000;
            siticoneTileButton23.TooltipBackColor = Color.Black;
            siticoneTileButton23.TooltipFont = new Font("Segoe UI", 9F);
            siticoneTileButton23.TooltipForeColor = Color.White;
            siticoneTileButton23.TooltipInitialDelay = 500;
            siticoneTileButton23.TooltipReshowDelay = 100;
            siticoneTileButton23.TooltipText = "";
            siticoneTileButton23.TopLeftRadius = 12F;
            siticoneTileButton23.TopRightRadius = 12F;
            siticoneTileButton23.UseGradient = false;
            // 
            // siticoneTileButton24
            // 
            siticoneTileButton24.AccessibleDescription = "A customizable tile button";
            siticoneTileButton24.AccessibleName = "TileButton";
            siticoneTileButton24.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            siticoneTileButton24.BackColor = Color.Transparent;
            siticoneTileButton24.BadgeColor = Color.Red;
            siticoneTileButton24.BadgeFont = "Segoe UI";
            siticoneTileButton24.BadgePosition = new Point(134, 5);
            siticoneTileButton24.BadgeText = "";
            siticoneTileButton24.BaseColor = Color.FromArgb(50, 150, 215);
            siticoneTileButton24.BorderWidth = 1F;
            siticoneTileButton24.BottomLeftRadius = 12F;
            siticoneTileButton24.BottomRightRadius = 12F;
            siticoneTileButton24.ColorTransitionSpeed = 0.15F;
            siticoneTileButton24.EnableRipple = true;
            siticoneTileButton24.Font = new Font("Segoe UI", 10F);
            siticoneTileButton24.ForeColor = Color.White;
            siticoneTileButton24.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneTileButton24.HoverColor = Color.FromArgb(70, 170, 235);
            siticoneTileButton24.Icon = null;
            siticoneTileButton24.IconAlignment = ContentAlignment.MiddleLeft;
            siticoneTileButton24.IconMargin = new Padding(5);
            siticoneTileButton24.IconPadding = 5;
            siticoneTileButton24.IconSize = new Size(24, 24);
            siticoneTileButton24.IsLoading = false;
            siticoneTileButton24.IsToggled = false;
            siticoneTileButton24.LoadingColor = Color.White;
            siticoneTileButton24.Location = new Point(35, 110);
            siticoneTileButton24.Margin = new Padding(3, 2, 3, 2);
            siticoneTileButton24.MaxRipples = 100;
            siticoneTileButton24.Name = "siticoneTileButton24";
            siticoneTileButton24.PersistState = false;
            siticoneTileButton24.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneTileButton24.RippleFadeStart = 0F;
            siticoneTileButton24.RippleOpacity = 0.1F;
            siticoneTileButton24.RippleSpeed = 20F;
            siticoneTileButton24.ShadowColor = Color.Black;
            siticoneTileButton24.ShadowDepth = 1;
            siticoneTileButton24.ShadowOffset = new Point(1, 1);
            siticoneTileButton24.ShadowOpacity = 0.3F;
            siticoneTileButton24.ShowBadge = false;
            siticoneTileButton24.ShowBorder = false;
            siticoneTileButton24.ShowTextShadow = true;
            siticoneTileButton24.Size = new Size(145, 92);
            siticoneTileButton24.TabIndex = 19;
            siticoneTileButton24.Text = "Open";
            siticoneTileButton24.TooltipAlwaysShow = true;
            siticoneTileButton24.TooltipAutoPopDelay = 5000;
            siticoneTileButton24.TooltipBackColor = Color.Black;
            siticoneTileButton24.TooltipFont = new Font("Segoe UI", 9F);
            siticoneTileButton24.TooltipForeColor = Color.White;
            siticoneTileButton24.TooltipInitialDelay = 500;
            siticoneTileButton24.TooltipReshowDelay = 100;
            siticoneTileButton24.TooltipText = "";
            siticoneTileButton24.TopLeftRadius = 12F;
            siticoneTileButton24.TopRightRadius = 12F;
            siticoneTileButton24.UseGradient = false;
            // 
            // label45
            // 
            label45.Dock = DockStyle.Top;
            label45.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label45.ForeColor = Color.White;
            label45.Location = new Point(9, 8);
            label45.Name = "label45";
            label45.Size = new Size(304, 33);
            label45.TabIndex = 17;
            label45.Text = "\"John_Doe_Resume\"";
            label45.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel13
            // 
            panel13.BackColor = Color.FromArgb(0, 31, 84);
            panel13.Dock = DockStyle.Top;
            panel13.Location = new Point(0, 94);
            panel13.Name = "panel13";
            panel13.Size = new Size(696, 26);
            panel13.TabIndex = 33;
            // 
            // panel19
            // 
            panel19.BackColor = Color.FromArgb(41, 128, 185);
            panel19.Controls.Add(label21);
            panel19.Controls.Add(label22);
            panel19.Dock = DockStyle.Top;
            panel19.Location = new Point(0, 0);
            panel19.Margin = new Padding(3, 2, 3, 2);
            panel19.Name = "panel19";
            panel19.Size = new Size(696, 94);
            panel19.TabIndex = 32;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.Transparent;
            label21.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label21.ForeColor = Color.White;
            label21.Location = new Point(3, 57);
            label21.Name = "label21";
            label21.Size = new Size(253, 27);
            label21.TabIndex = 5;
            label21.Text = "\"Your recent resumes\"";
            label21.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.Transparent;
            label22.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label22.ForeColor = Color.White;
            label22.Location = new Point(3, 15);
            label22.Name = "label22";
            label22.Size = new Size(341, 47);
            label22.TabIndex = 3;
            label22.Text = "Recent Resumes";
            label22.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Home
            // 
            BackColor = Color.FromArgb(216, 225, 233);
            Controls.Add(panel26);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel14);
            Controls.Add(tableLayoutPanel3);
            Controls.Add(panel1);
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
            panel14.ResumeLayout(false);
            ((ISupportInitialize)chart1).EndInit();
            panel26.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            panel20.ResumeLayout(false);
            panel21.ResumeLayout(false);
            panel22.ResumeLayout(false);
            panel23.ResumeLayout(false);
            panel24.ResumeLayout(false);
            panel25.ResumeLayout(false);
            panel19.ResumeLayout(false);
            panel19.PerformLayout();
            ResumeLayout(false);
        }


        public void UpdateAnalyticsLabels(string currentUsername)
        {
            var db = new ResumeDatabase();
            int userId = db.GetCurrentUserID(currentUsername);
            var analytics = db.GetUserAnalytics(userId);

            resumesCreatedlbl.Text = analytics.resumesCreated.ToString();
            savedResumeslbl.Text = analytics.resumesSaved.ToString();
            resumesExportlbl.Text = analytics.resumesExported.ToString();
            resumesSentlbl.Text = analytics.resumesSent.ToString();
        }
    }
}
