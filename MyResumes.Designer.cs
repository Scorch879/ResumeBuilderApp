namespace FinalProjectOOP2
{
    partial class MyResumes
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
            components = new System.ComponentModel.Container();
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "John_Doe_Resume" }, 0, Color.Empty, Color.Empty, new Font("Century Gothic", 13.8F, FontStyle.Bold));
            ListViewItem listViewItem2 = new ListViewItem(new string[] { "Resume" }, 0, Color.Empty, Color.Empty, new Font("Century Gothic", 13.8F, FontStyle.Bold));
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyResumes));
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
            listView1 = new ListView();
            columnHeader = new ColumnHeader();
            images = new ImageList(components);
            tableLayoutPanel3.SuspendLayout();
            panel12.SuspendLayout();
            panel11.SuspendLayout();
            panel9.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.FromArgb(216, 225, 233);
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 383F));
            tableLayoutPanel3.Controls.Add(panel12, 2, 0);
            tableLayoutPanel3.Controls.Add(panel11, 1, 0);
            tableLayoutPanel3.Controls.Add(panel9, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Bottom;
            tableLayoutPanel3.Location = new Point(0, 800);
            tableLayoutPanel3.Margin = new Padding(30, 29, 30, 29);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.Padding = new Padding(3);
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 101F));
            tableLayoutPanel3.Size = new Size(1550, 107);
            tableLayoutPanel3.TabIndex = 24;
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(41, 128, 185);
            panel12.BorderStyle = BorderStyle.FixedSingle;
            panel12.Controls.Add(iconButton2);
            panel12.Location = new Point(768, 8);
            panel12.Margin = new Padding(5);
            panel12.Name = "panel12";
            panel12.Padding = new Padding(1);
            panel12.Size = new Size(370, 90);
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
            iconButton2.Name = "iconButton2";
            iconButton2.Padding = new Padding(69, 0, 0, 0);
            iconButton2.Size = new Size(366, 86);
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
            panel11.Location = new Point(388, 8);
            panel11.Margin = new Padding(5);
            panel11.Name = "panel11";
            panel11.Padding = new Padding(1);
            panel11.Size = new Size(370, 90);
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
            iconButton1.Name = "iconButton1";
            iconButton1.Padding = new Padding(69, 0, 0, 0);
            iconButton1.Size = new Size(366, 86);
            iconButton1.TabIndex = 22;
            iconButton1.Text = "Export Resume";
            iconButton1.TextAlign = ContentAlignment.MiddleLeft;
            iconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton1.UseVisualStyleBackColor = false;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(41, 128, 185);
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(homeBtn);
            panel9.Location = new Point(8, 8);
            panel9.Margin = new Padding(5);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(1);
            panel9.Size = new Size(370, 90);
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
            homeBtn.Name = "homeBtn";
            homeBtn.Padding = new Padding(29, 0, 0, 0);
            homeBtn.Size = new Size(366, 86);
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
            panel1.Name = "panel1";
            panel1.Size = new Size(1550, 125);
            panel1.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(41, 128, 185);
            label1.Location = new Point(3, 76);
            label1.Name = "label1";
            label1.Size = new Size(474, 27);
            label1.TabIndex = 4;
            label1.Text = "\"Here's a quick overview of your activity\"";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // userLbl
            // 
            userLbl.AutoSize = true;
            userLbl.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userLbl.ForeColor = Color.FromArgb(41, 128, 185);
            userLbl.Location = new Point(3, 20);
            userLbl.Name = "userLbl";
            userLbl.Size = new Size(292, 47);
            userLbl.TabIndex = 3;
            userLbl.Text = "Your Resumes";
            userLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            listView1.BackColor = Color.FromArgb(216, 225, 233);
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader });
            listView1.Dock = DockStyle.Left;
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2 });
            listView1.Location = new Point(0, 125);
            listView1.Margin = new Padding(3, 4, 3, 4);
            listView1.Name = "listView1";
            listView1.Size = new Size(308, 675);
            listView1.SmallImageList = images;
            listView1.Sorting = SortOrder.Ascending;
            listView1.TabIndex = 25;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader
            // 
            columnHeader.Text = "Name";
            columnHeader.Width = 300;
            // 
            // images
            // 
            images.ColorDepth = ColorDepth.Depth32Bit;
            images.ImageStream = (ImageListStreamer)resources.GetObject("images.ImageStream");
            images.TransparentColor = Color.Transparent;
            images.Images.SetKeyName(0, "resumeIcon.png");
            // 
            // MyResumes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listView1);
            Controls.Add(tableLayoutPanel3);
            Controls.Add(panel1);
            Name = "MyResumes";
            Size = new Size(1550, 907);
            tableLayoutPanel3.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel12;
        private FontAwesome.Sharp.IconButton iconButton2;
        private Panel panel11;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Panel panel9;
        private FontAwesome.Sharp.IconButton homeBtn;
        private Panel panel1;
        private Label label1;
        private Label userLbl;
        private ListView listView1;
        private ImageList images;
        private ColumnHeader columnHeader;
        private SiticoneNetCoreUI.SiticoneSplitContainer siticoneSplitContainer1;
    }
}
