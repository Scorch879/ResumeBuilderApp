using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FinalProjectOOP2.ResumeDatabase;

namespace FinalProjectOOP2
{
    public partial class Home : UserControl, ICurrentUsername
    {
        private string? currentUsername;
        private ResumeDatabase db = new ResumeDatabase();

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
                LoadRecentResumes(CurrentUsername);
            }
        }

        public void LoadRecentResumes(string currentUsername)
        {
            var db = new ResumeDatabase();
            int ownerId = db.GetCurrentUserID(currentUsername);
            var recentResumes = db.GetRecentResumesForUser(ownerId, 6);

           
            resumeCardFlowLayoutPanel.Controls.Clear();
            foreach (var resume in recentResumes)
            {
                var card = new ResumeCard(resume);
                card.DeleteClicked += (s, e) => DeleteResume(resume.ResumeID);
                resumeCardFlowLayoutPanel.Controls.Add(card);

            }
        }

        private void DeleteResume(int resumeId)
        {
            var confirm = MessageBox.Show("Are you sure you want to delete this resume?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes && CurrentUsername != null)
            {
                
                int ownerID = db.GetCurrentUserID(CurrentUsername);
                bool deleted = db.DeleteResume(resumeId);
                if (deleted)
                {
                    LoadRecentResumes(CurrentUsername);
                    db.DecrementResumesCreatedAndSaved(ownerID);
                    
                }
                this.Refresh();
                UpdateAnalyticsLabels(CurrentUsername);
            }
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            chartCreated = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel26 = new Panel();
            resumeCardFlowLayoutPanel = new FlowLayoutPanel();
            panel13 = new Panel();
            panel19 = new Panel();
            label21 = new Label();
            label22 = new Label();
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
            ((ISupportInitialize)chartCreated).BeginInit();
            panel26.SuspendLayout();
            panel19.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(10, 17, 40);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(userLbl);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1510, 112);
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
            tableLayoutPanel1.Padding = new Padding(13, 2, 3, 2);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 132F));
            tableLayoutPanel1.Size = new Size(649, 153);
            tableLayoutPanel1.TabIndex = 23;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(41, 128, 185);
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Controls.Add(label12);
            panel10.Controls.Add(resumesSentlbl);
            panel10.Controls.Add(pictureBox8);
            panel10.Location = new Point(482, 6);
            panel10.Margin = new Padding(4);
            panel10.Name = "panel10";
            panel10.Padding = new Padding(9);
            panel10.Size = new Size(147, 140);
            panel10.TabIndex = 18;
            // 
            // label12
            // 
            label12.Dock = DockStyle.Bottom;
            label12.Font = new Font("Century Gothic", 13.8F);
            label12.ForeColor = Color.White;
            label12.Location = new Point(9, 44);
            label12.Name = "label12";
            label12.Size = new Size(127, 57);
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
            resumesSentlbl.Size = new Size(127, 28);
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
            pictureBox8.Size = new Size(127, 36);
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
            panel4.Location = new Point(327, 6);
            panel4.Margin = new Padding(4);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(9, 8, 9, 8);
            panel4.Size = new Size(147, 140);
            panel4.TabIndex = 17;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Bottom;
            label5.Font = new Font("Century Gothic", 13.8F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(9, 43);
            label5.Name = "label5";
            label5.Size = new Size(127, 58);
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
            resumesExportlbl.Size = new Size(127, 29);
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
            pictureBox3.Size = new Size(127, 37);
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
            panel2.Location = new Point(17, 6);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(9, 8, 9, 8);
            panel2.Size = new Size(147, 140);
            panel2.TabIndex = 15;
            // 
            // label11
            // 
            label11.Dock = DockStyle.Bottom;
            label11.Font = new Font("Century Gothic", 13.8F);
            label11.ForeColor = Color.White;
            label11.Location = new Point(9, 43);
            label11.Name = "label11";
            label11.Size = new Size(127, 58);
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
            resumesCreatedlbl.Size = new Size(127, 29);
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
            pictureBox1.Size = new Size(127, 36);
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
            panel3.Location = new Point(172, 6);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(9, 8, 9, 8);
            panel3.Size = new Size(147, 140);
            panel3.TabIndex = 16;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Bottom;
            label2.Font = new Font("Century Gothic", 13.8F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(9, 43);
            label2.Name = "label2";
            label2.Size = new Size(127, 58);
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
            savedResumeslbl.Size = new Size(127, 29);
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
            pictureBox2.Size = new Size(127, 36);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            // 
            // panel14
            // 
            panel14.Controls.Add(chartCreated);
            panel14.Dock = DockStyle.Right;
            panel14.Location = new Point(649, 112);
            panel14.Name = "panel14";
            panel14.Size = new Size(861, 738);
            panel14.TabIndex = 30;
            // 
            // chartCreated
            // 
            chartArea1.Name = "ChartArea1";
            chartCreated.ChartAreas.Add(chartArea1);
            chartCreated.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chartCreated.Legends.Add(legend1);
            chartCreated.Location = new Point(0, 0);
            chartCreated.Name = "chartCreated";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartCreated.Series.Add(series1);
            chartCreated.Size = new Size(861, 738);
            chartCreated.TabIndex = 0;
            chartCreated.Text = "chart1";
            // 
            // panel26
            // 
            panel26.Controls.Add(resumeCardFlowLayoutPanel);
            panel26.Controls.Add(panel13);
            panel26.Controls.Add(panel19);
            panel26.Dock = DockStyle.Fill;
            panel26.Location = new Point(0, 265);
            panel26.Name = "panel26";
            panel26.Size = new Size(649, 585);
            panel26.TabIndex = 31;
            // 
            // resumeCardFlowLayoutPanel
            // 
            resumeCardFlowLayoutPanel.Dock = DockStyle.Fill;
            resumeCardFlowLayoutPanel.Location = new Point(0, 131);
            resumeCardFlowLayoutPanel.Name = "resumeCardFlowLayoutPanel";
            resumeCardFlowLayoutPanel.Size = new Size(649, 454);
            resumeCardFlowLayoutPanel.TabIndex = 34;
            // 
            // panel13
            // 
            panel13.BackColor = Color.FromArgb(0, 31, 84);
            panel13.Dock = DockStyle.Top;
            panel13.Location = new Point(0, 105);
            panel13.Name = "panel13";
            panel13.Size = new Size(649, 26);
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
            panel19.Size = new Size(649, 105);
            panel19.TabIndex = 32;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.Transparent;
            label21.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label21.ForeColor = Color.White;
            label21.Location = new Point(3, 60);
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
            label22.Location = new Point(3, 8);
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
            Controls.Add(panel1);
            Margin = new Padding(0);
            Name = "Home";
            Size = new Size(1510, 850);
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
            ((ISupportInitialize)chartCreated).EndInit();
            panel26.ResumeLayout(false);
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

            // Fetch monthly created trend
            var monthlyTrend = db.GetMonthlyCreatedTrend(userId);

            // Update the chart (assume chartCreated is set up as a line chart in the designer)
            chartCreated.Series[0].Points.Clear();
            chartCreated.Titles.Clear();
            chartCreated.Titles.Add("Resumes Created Per Month");
            chartCreated.ChartAreas[0].AxisX.Title = "Month";
            chartCreated.ChartAreas[0].AxisY.Title = "Created";
            chartCreated.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartCreated.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartCreated.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
            chartCreated.ChartAreas[0].AxisY.LabelStyle.Enabled = true;
            chartCreated.ChartAreas[0].AxisX.LineColor = Color.FromArgb(41, 128, 185);
            chartCreated.ChartAreas[0].AxisY.LineColor = Color.FromArgb(41, 128, 185);
            chartCreated.ChartAreas[0].BackColor = Color.FromArgb(216, 225, 233);

            foreach (var (month, count) in monthlyTrend)
            {
                chartCreated.Series[0].Points.AddXY(month, count);
            }
        }

      

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}