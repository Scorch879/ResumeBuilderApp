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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyResumes));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            images = new ImageList(components);
            userLbl = new Label();
            label1 = new Label();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel5 = new Panel();
            deleteResumeBtn = new FontAwesome.Sharp.IconButton();
            panel7 = new Panel();
            sendResumeBtn = new FontAwesome.Sharp.IconButton();
            panel6 = new Panel();
            exportResumeBtn = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            createNewResumeBtn = new FontAwesome.Sharp.IconButton();
            dgvResumes = new DataGridView();
            templatePanelCorner = new Panel();
            templateSelector = new ComboBox();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            siticoneTextBox1 = new SiticoneNetCoreUI.SiticoneTextBox();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResumes).BeginInit();
            templatePanelCorner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // images
            // 
            images.ColorDepth = ColorDepth.Depth32Bit;
            images.ImageStream = (ImageListStreamer)resources.GetObject("images.ImageStream");
            images.TransparentColor = Color.Transparent;
            images.Images.SetKeyName(0, "resumeIcon.png");
            // 
            // userLbl
            // 
            userLbl.AutoSize = true;
            userLbl.BackColor = Color.Transparent;
            userLbl.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userLbl.ForeColor = Color.White;
            userLbl.Location = new Point(18, 14);
            userLbl.Name = "userLbl";
            userLbl.Size = new Size(292, 47);
            userLbl.TabIndex = 3;
            userLbl.Text = "Your Resumes";
            userLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(18, 63);
            label1.Name = "label1";
            label1.Size = new Size(259, 27);
            label1.TabIndex = 4;
            label1.Text = "\"Here's your creations\"";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 128, 185);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(userLbl);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1510, 106);
            panel1.TabIndex = 20;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(0, 31, 84);
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(panel5, 3, 0);
            tableLayoutPanel1.Controls.Add(panel7, 2, 0);
            tableLayoutPanel1.Controls.Add(panel6, 1, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 763);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1510, 87);
            tableLayoutPanel1.TabIndex = 26;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(216, 225, 233);
            panel5.Controls.Add(deleteResumeBtn);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(1133, 2);
            panel5.Margin = new Padding(2);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(2);
            panel5.Size = new Size(375, 83);
            panel5.TabIndex = 10;
            // 
            // deleteResumeBtn
            // 
            deleteResumeBtn.BackColor = Color.IndianRed;
            deleteResumeBtn.Cursor = Cursors.Hand;
            deleteResumeBtn.Dock = DockStyle.Fill;
            deleteResumeBtn.FlatAppearance.BorderSize = 0;
            deleteResumeBtn.FlatStyle = FlatStyle.Flat;
            deleteResumeBtn.Font = new Font("Century Gothic", 13.8F);
            deleteResumeBtn.ForeColor = Color.White;
            deleteResumeBtn.IconChar = FontAwesome.Sharp.IconChar.Trash;
            deleteResumeBtn.IconColor = Color.FromArgb(216, 225, 233);
            deleteResumeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            deleteResumeBtn.IconSize = 50;
            deleteResumeBtn.ImageAlign = ContentAlignment.MiddleLeft;
            deleteResumeBtn.Location = new Point(2, 2);
            deleteResumeBtn.Name = "deleteResumeBtn";
            deleteResumeBtn.Padding = new Padding(69, 0, 0, 0);
            deleteResumeBtn.Size = new Size(371, 79);
            deleteResumeBtn.TabIndex = 26;
            deleteResumeBtn.Text = "Delete Resume";
            deleteResumeBtn.TextAlign = ContentAlignment.MiddleLeft;
            deleteResumeBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            deleteResumeBtn.UseVisualStyleBackColor = false;
            deleteResumeBtn.Click += deleteResumeBtn_Click;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(216, 225, 233);
            panel7.Controls.Add(sendResumeBtn);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(756, 2);
            panel7.Margin = new Padding(2);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(2);
            panel7.Size = new Size(373, 83);
            panel7.TabIndex = 9;
            // 
            // sendResumeBtn
            // 
            sendResumeBtn.BackColor = Color.FromArgb(41, 128, 185);
            sendResumeBtn.Cursor = Cursors.Hand;
            sendResumeBtn.Dock = DockStyle.Fill;
            sendResumeBtn.FlatAppearance.BorderSize = 0;
            sendResumeBtn.FlatStyle = FlatStyle.Flat;
            sendResumeBtn.Font = new Font("Century Gothic", 13.8F);
            sendResumeBtn.ForeColor = Color.White;
            sendResumeBtn.IconChar = FontAwesome.Sharp.IconChar.PaperPlane;
            sendResumeBtn.IconColor = Color.FromArgb(216, 225, 233);
            sendResumeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sendResumeBtn.IconSize = 50;
            sendResumeBtn.ImageAlign = ContentAlignment.MiddleLeft;
            sendResumeBtn.Location = new Point(2, 2);
            sendResumeBtn.Name = "sendResumeBtn";
            sendResumeBtn.Padding = new Padding(69, 0, 0, 0);
            sendResumeBtn.Size = new Size(369, 79);
            sendResumeBtn.TabIndex = 26;
            sendResumeBtn.Text = "Send Resume";
            sendResumeBtn.TextAlign = ContentAlignment.MiddleLeft;
            sendResumeBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            sendResumeBtn.UseVisualStyleBackColor = false;
            sendResumeBtn.Click += sendResumeBtn_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(216, 225, 233);
            panel6.Controls.Add(exportResumeBtn);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(379, 2);
            panel6.Margin = new Padding(2);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(2);
            panel6.Size = new Size(373, 83);
            panel6.TabIndex = 8;
            // 
            // exportResumeBtn
            // 
            exportResumeBtn.BackColor = Color.FromArgb(41, 128, 185);
            exportResumeBtn.Cursor = Cursors.Hand;
            exportResumeBtn.Dock = DockStyle.Fill;
            exportResumeBtn.FlatAppearance.BorderSize = 0;
            exportResumeBtn.FlatStyle = FlatStyle.Flat;
            exportResumeBtn.Font = new Font("Century Gothic", 13.8F);
            exportResumeBtn.ForeColor = Color.White;
            exportResumeBtn.IconChar = FontAwesome.Sharp.IconChar.Download;
            exportResumeBtn.IconColor = Color.FromArgb(216, 225, 233);
            exportResumeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            exportResumeBtn.IconSize = 50;
            exportResumeBtn.ImageAlign = ContentAlignment.MiddleLeft;
            exportResumeBtn.Location = new Point(2, 2);
            exportResumeBtn.Name = "exportResumeBtn";
            exportResumeBtn.Padding = new Padding(69, 0, 0, 0);
            exportResumeBtn.Size = new Size(369, 79);
            exportResumeBtn.TabIndex = 23;
            exportResumeBtn.Text = "Export Resume";
            exportResumeBtn.TextAlign = ContentAlignment.MiddleLeft;
            exportResumeBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            exportResumeBtn.UseVisualStyleBackColor = false;
            exportResumeBtn.Click += exportResumeBtn_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(216, 225, 233);
            panel2.Controls.Add(createNewResumeBtn);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(2, 2);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(2);
            panel2.Size = new Size(373, 83);
            panel2.TabIndex = 5;
            // 
            // createNewResumeBtn
            // 
            createNewResumeBtn.BackColor = Color.FromArgb(41, 128, 185);
            createNewResumeBtn.Cursor = Cursors.Hand;
            createNewResumeBtn.Dock = DockStyle.Fill;
            createNewResumeBtn.FlatAppearance.BorderSize = 0;
            createNewResumeBtn.FlatStyle = FlatStyle.Flat;
            createNewResumeBtn.Font = new Font("Century Gothic", 13.8F);
            createNewResumeBtn.ForeColor = Color.White;
            createNewResumeBtn.IconChar = FontAwesome.Sharp.IconChar.Add;
            createNewResumeBtn.IconColor = Color.FromArgb(216, 225, 233);
            createNewResumeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            createNewResumeBtn.IconSize = 50;
            createNewResumeBtn.ImageAlign = ContentAlignment.MiddleLeft;
            createNewResumeBtn.Location = new Point(2, 2);
            createNewResumeBtn.Name = "createNewResumeBtn";
            createNewResumeBtn.Padding = new Padding(30, 0, 0, 0);
            createNewResumeBtn.Size = new Size(369, 79);
            createNewResumeBtn.TabIndex = 23;
            createNewResumeBtn.Text = " Create New Resume";
            createNewResumeBtn.TextAlign = ContentAlignment.MiddleLeft;
            createNewResumeBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            createNewResumeBtn.UseVisualStyleBackColor = false;
            createNewResumeBtn.Click += createNewBtn_Click;
            // 
            // dgvResumes
            // 
            dgvResumes.AllowUserToAddRows = false;
            dgvResumes.AllowUserToDeleteRows = false;
            dgvResumes.AllowUserToResizeColumns = false;
            dgvResumes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(216, 225, 233);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dgvResumes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvResumes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResumes.BackgroundColor = Color.FromArgb(216, 225, 233);
            dgvResumes.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(10, 17, 40);
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvResumes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvResumes.ColumnHeadersHeight = 50;
            dgvResumes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(254, 252, 251);
            dataGridViewCellStyle3.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvResumes.DefaultCellStyle = dataGridViewCellStyle3;
            dgvResumes.Dock = DockStyle.Fill;
            dgvResumes.EnableHeadersVisualStyles = false;
            dgvResumes.GridColor = Color.FromArgb(0, 31, 84);
            dgvResumes.Location = new Point(0, 158);
            dgvResumes.Name = "dgvResumes";
            dgvResumes.ReadOnly = true;
            dgvResumes.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Font = new Font("Century Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvResumes.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvResumes.RowTemplate.Height = 50;
            dgvResumes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResumes.Size = new Size(1510, 605);
            dgvResumes.TabIndex = 30;
            dgvResumes.CellDoubleClick += dgvResumes_CellDoubleClick;
            // 
            // templatePanelCorner
            // 
            templatePanelCorner.BackColor = Color.FromArgb(10, 17, 40);
            templatePanelCorner.Controls.Add(templateSelector);
            templatePanelCorner.Controls.Add(iconPictureBox1);
            templatePanelCorner.Controls.Add(siticoneTextBox1);
            templatePanelCorner.Dock = DockStyle.Top;
            templatePanelCorner.Location = new Point(0, 106);
            templatePanelCorner.Name = "templatePanelCorner";
            templatePanelCorner.Padding = new Padding(3);
            templatePanelCorner.Size = new Size(1510, 52);
            templatePanelCorner.TabIndex = 31;
            // 
            // templateSelector
            // 
            templateSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            templateSelector.Font = new Font("Century Gothic", 13.8F);
            templateSelector.FormattingEnabled = true;
            templateSelector.Items.AddRange(new object[] { "Academic Resume", "Attorney Resume", "Call Center Resume", "Doctor Resume", "Electrical Engineer Resume" });
            templateSelector.Location = new Point(390, 6);
            templateSelector.Name = "templateSelector";
            templateSelector.Size = new Size(347, 35);
            templateSelector.Sorted = true;
            templateSelector.TabIndex = 3;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.Transparent;
            iconPictureBox1.Dock = DockStyle.Left;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Search;
            iconPictureBox1.IconColor = Color.White;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 46;
            iconPictureBox1.Location = new Point(3, 3);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(54, 46);
            iconPictureBox1.TabIndex = 1;
            iconPictureBox1.TabStop = false;
            // 
            // siticoneTextBox1
            // 
            siticoneTextBox1.AccessibleDescription = "A customizable text input field.";
            siticoneTextBox1.AccessibleName = "Text Box";
            siticoneTextBox1.AccessibleRole = AccessibleRole.Text;
            siticoneTextBox1.BackColor = Color.Transparent;
            siticoneTextBox1.BlinkCount = 3;
            siticoneTextBox1.BlinkShadow = false;
            siticoneTextBox1.BorderColor1 = Color.LightSlateGray;
            siticoneTextBox1.BorderColor2 = Color.LightSlateGray;
            siticoneTextBox1.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            siticoneTextBox1.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            siticoneTextBox1.CanShake = true;
            siticoneTextBox1.ContinuousBlink = false;
            siticoneTextBox1.CursorBlinkRate = 500;
            siticoneTextBox1.CursorColor = Color.Black;
            siticoneTextBox1.CursorHeight = 26;
            siticoneTextBox1.CursorOffset = 0;
            siticoneTextBox1.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            siticoneTextBox1.CursorWidth = 1;
            siticoneTextBox1.DisabledBackColor = Color.WhiteSmoke;
            siticoneTextBox1.DisabledBorderColor = Color.LightGray;
            siticoneTextBox1.DisabledTextColor = Color.Gray;
            siticoneTextBox1.EnableDropShadow = false;
            siticoneTextBox1.FillColor1 = Color.White;
            siticoneTextBox1.FillColor2 = Color.White;
            siticoneTextBox1.Font = new Font("Segoe UI", 9.5F);
            siticoneTextBox1.ForeColor = Color.DimGray;
            siticoneTextBox1.HoverBorderColor1 = Color.Gray;
            siticoneTextBox1.HoverBorderColor2 = Color.Gray;
            siticoneTextBox1.IsEnabled = true;
            siticoneTextBox1.Location = new Point(63, 6);
            siticoneTextBox1.Name = "siticoneTextBox1";
            siticoneTextBox1.PlaceholderColor = Color.Gray;
            siticoneTextBox1.PlaceholderText = "Enter text here...";
            siticoneTextBox1.ReadOnlyBorderColor1 = Color.LightGray;
            siticoneTextBox1.ReadOnlyBorderColor2 = Color.LightGray;
            siticoneTextBox1.ReadOnlyFillColor1 = Color.WhiteSmoke;
            siticoneTextBox1.ReadOnlyFillColor2 = Color.WhiteSmoke;
            siticoneTextBox1.ReadOnlyPlaceholderColor = Color.DarkGray;
            siticoneTextBox1.SelectionBackColor = Color.FromArgb(77, 77, 255);
            siticoneTextBox1.ShadowAnimationDuration = 1;
            siticoneTextBox1.ShadowBlur = 10;
            siticoneTextBox1.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            siticoneTextBox1.Size = new Size(312, 35);
            siticoneTextBox1.SolidBorderColor = Color.LightSlateGray;
            siticoneTextBox1.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            siticoneTextBox1.SolidBorderHoverColor = Color.Gray;
            siticoneTextBox1.SolidFillColor = Color.White;
            siticoneTextBox1.TabIndex = 2;
            siticoneTextBox1.Text = "siticoneTextBox1";
            siticoneTextBox1.TextPadding = new Padding(16, 0, 6, 0);
            siticoneTextBox1.ValidationErrorMessage = "Invalid input.";
            siticoneTextBox1.ValidationFunction = null;
            // 
            // MyResumes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvResumes);
            Controls.Add(templatePanelCorner);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Margin = new Padding(0);
            Name = "MyResumes";
            Size = new Size(1510, 850);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResumes).EndInit();
            templatePanelCorner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ImageList images;
        private SiticoneNetCoreUI.SiticoneSplitContainer siticoneSplitContainer1;
        private Label userLbl;
        private Label label1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel7;
        private Panel panel6;
        private FontAwesome.Sharp.IconButton exportResumeBtn;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton createNewResumeBtn;
        private Panel panel5;
        private FontAwesome.Sharp.IconButton sendResumeBtn;
        private FontAwesome.Sharp.IconButton deleteResumeBtn;
        private DataGridView dgvResumes;
        private Panel templatePanelCorner;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private SiticoneNetCoreUI.SiticoneTextBox siticoneTextBox1;
        private ComboBox templateSelector;
    }
}
