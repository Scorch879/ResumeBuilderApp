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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            images = new ImageList(components);
            userLbl = new Label();
            label1 = new Label();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel7 = new Panel();
            deleteResumeBtn = new FontAwesome.Sharp.IconButton();
            panel6 = new Panel();
            sendResumeBtn = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            dgvResumes = new DataGridView();
            templatePanelCorner = new Panel();
            clearFiltersBtn = new SiticoneNetCoreUI.SiticoneButton();
            label2 = new Label();
            templateSelector = new ComboBox();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            searchTbx = new SiticoneNetCoreUI.SiticoneTextBox();
            panel3 = new Panel();
            exportResumeBtn = new FontAwesome.Sharp.IconButton();
            createResumeBtn = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResumes).BeginInit();
            templatePanelCorner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            panel3.SuspendLayout();
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
            tableLayoutPanel1.Controls.Add(panel3, 0, 0);
            tableLayoutPanel1.Controls.Add(panel7, 3, 0);
            tableLayoutPanel1.Controls.Add(panel6, 2, 0);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 763);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1510, 87);
            tableLayoutPanel1.TabIndex = 26;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(216, 225, 233);
            panel7.Controls.Add(deleteResumeBtn);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(1133, 2);
            panel7.Margin = new Padding(2);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(2);
            panel7.Size = new Size(375, 83);
            panel7.TabIndex = 9;
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
            deleteResumeBtn.Padding = new Padding(70, 0, 0, 0);
            deleteResumeBtn.Size = new Size(371, 79);
            deleteResumeBtn.TabIndex = 27;
            deleteResumeBtn.Text = "Delete Resume";
            deleteResumeBtn.TextAlign = ContentAlignment.MiddleLeft;
            deleteResumeBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            deleteResumeBtn.UseVisualStyleBackColor = false;
            deleteResumeBtn.Click += deleteResumeBtn_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(216, 225, 233);
            panel6.Controls.Add(sendResumeBtn);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(756, 2);
            panel6.Margin = new Padding(2);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(2);
            panel6.Size = new Size(373, 83);
            panel6.TabIndex = 8;
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
            sendResumeBtn.Padding = new Padding(70, 0, 0, 0);
            sendResumeBtn.Size = new Size(369, 79);
            sendResumeBtn.TabIndex = 27;
            sendResumeBtn.Text = "Send Resume";
            sendResumeBtn.TextAlign = ContentAlignment.MiddleLeft;
            sendResumeBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            sendResumeBtn.UseVisualStyleBackColor = false;
            sendResumeBtn.Click += sendResumeBtn_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(216, 225, 233);
            panel2.Controls.Add(exportResumeBtn);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(379, 2);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(2);
            panel2.Size = new Size(373, 83);
            panel2.TabIndex = 5;
            // 
            // dgvResumes
            // 
            dgvResumes.AllowUserToAddRows = false;
            dgvResumes.AllowUserToDeleteRows = false;
            dgvResumes.AllowUserToResizeColumns = false;
            dgvResumes.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(216, 225, 233);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dgvResumes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvResumes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResumes.BackgroundColor = Color.FromArgb(216, 225, 233);
            dgvResumes.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(10, 17, 40);
            dataGridViewCellStyle6.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvResumes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvResumes.ColumnHeadersHeight = 50;
            dgvResumes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(254, 252, 251);
            dataGridViewCellStyle7.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgvResumes.DefaultCellStyle = dataGridViewCellStyle7;
            dgvResumes.Dock = DockStyle.Fill;
            dgvResumes.EnableHeadersVisualStyles = false;
            dgvResumes.GridColor = Color.FromArgb(0, 31, 84);
            dgvResumes.Location = new Point(0, 158);
            dgvResumes.Name = "dgvResumes";
            dgvResumes.ReadOnly = true;
            dgvResumes.RowHeadersWidth = 51;
            dataGridViewCellStyle8.Font = new Font("Century Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dgvResumes.RowsDefaultCellStyle = dataGridViewCellStyle8;
            dgvResumes.RowTemplate.Height = 50;
            dgvResumes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResumes.Size = new Size(1510, 605);
            dgvResumes.TabIndex = 30;
            dgvResumes.CellDoubleClick += dgvResumes_CellDoubleClick;
            // 
            // templatePanelCorner
            // 
            templatePanelCorner.BackColor = Color.FromArgb(10, 17, 40);
            templatePanelCorner.Controls.Add(clearFiltersBtn);
            templatePanelCorner.Controls.Add(label2);
            templatePanelCorner.Controls.Add(templateSelector);
            templatePanelCorner.Controls.Add(iconPictureBox1);
            templatePanelCorner.Controls.Add(searchTbx);
            templatePanelCorner.Dock = DockStyle.Top;
            templatePanelCorner.Location = new Point(0, 106);
            templatePanelCorner.Name = "templatePanelCorner";
            templatePanelCorner.Padding = new Padding(3);
            templatePanelCorner.Size = new Size(1510, 52);
            templatePanelCorner.TabIndex = 31;
            // 
            // clearFiltersBtn
            // 
            clearFiltersBtn.AccessibleDescription = "";
            clearFiltersBtn.AccessibleName = "Clear Filters";
            clearFiltersBtn.AutoSizeBasedOnText = false;
            clearFiltersBtn.BackColor = Color.Transparent;
            clearFiltersBtn.BadgeBackColor = Color.Red;
            clearFiltersBtn.BadgeFont = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clearFiltersBtn.BadgeValue = 0;
            clearFiltersBtn.BadgeValueForeColor = Color.White;
            clearFiltersBtn.BorderColor = Color.Transparent;
            clearFiltersBtn.BorderWidth = 2;
            clearFiltersBtn.ButtonBackColor = Color.FromArgb(41, 128, 185);
            clearFiltersBtn.ButtonImage = null;
            clearFiltersBtn.CanBeep = true;
            clearFiltersBtn.CanGlow = false;
            clearFiltersBtn.CanShake = true;
            clearFiltersBtn.ContextMenuStripEx = null;
            clearFiltersBtn.CornerRadiusBottomLeft = 0;
            clearFiltersBtn.CornerRadiusBottomRight = 0;
            clearFiltersBtn.CornerRadiusTopLeft = 0;
            clearFiltersBtn.CornerRadiusTopRight = 0;
            clearFiltersBtn.CustomCursor = Cursors.Default;
            clearFiltersBtn.DisabledTextColor = Color.FromArgb(150, 150, 150);
            clearFiltersBtn.EnableLongPress = false;
            clearFiltersBtn.EnablePressAnimation = true;
            clearFiltersBtn.EnableRippleEffect = true;
            clearFiltersBtn.EnableShadow = false;
            clearFiltersBtn.EnableTextWrapping = false;
            clearFiltersBtn.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clearFiltersBtn.GlowColor = Color.FromArgb(100, 255, 255, 255);
            clearFiltersBtn.GlowIntensity = 100;
            clearFiltersBtn.GlowRadius = 20F;
            clearFiltersBtn.GradientBackground = false;
            clearFiltersBtn.GradientColor = Color.FromArgb(114, 168, 255);
            clearFiltersBtn.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            clearFiltersBtn.HintText = null;
            clearFiltersBtn.HoverBackColor = Color.FromArgb(216, 225, 233);
            clearFiltersBtn.HoverFontStyle = FontStyle.Regular;
            clearFiltersBtn.HoverTextColor = Color.Black;
            clearFiltersBtn.HoverTransitionDuration = 250;
            clearFiltersBtn.ImageAlign = ContentAlignment.MiddleLeft;
            clearFiltersBtn.ImagePadding = 5;
            clearFiltersBtn.ImageSize = new Size(16, 16);
            clearFiltersBtn.IsRadial = false;
            clearFiltersBtn.IsReadOnly = false;
            clearFiltersBtn.IsToggleButton = false;
            clearFiltersBtn.IsToggled = false;
            clearFiltersBtn.Location = new Point(967, 6);
            clearFiltersBtn.LongPressDurationMS = 1000;
            clearFiltersBtn.Name = "clearFiltersBtn";
            clearFiltersBtn.NormalFontStyle = FontStyle.Regular;
            clearFiltersBtn.ParticleColor = Color.FromArgb(200, 200, 200);
            clearFiltersBtn.ParticleCount = 15;
            clearFiltersBtn.PressAnimationScale = 0.97F;
            clearFiltersBtn.PressedBackColor = Color.FromArgb(216, 225, 233);
            clearFiltersBtn.PressedFontStyle = FontStyle.Regular;
            clearFiltersBtn.PressTransitionDuration = 150;
            clearFiltersBtn.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            clearFiltersBtn.RippleColor = Color.FromArgb(255, 255, 255);
            clearFiltersBtn.RippleOpacity = 0.3F;
            clearFiltersBtn.RippleRadiusMultiplier = 0.6F;
            clearFiltersBtn.ShadowBlur = 5;
            clearFiltersBtn.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            clearFiltersBtn.ShadowOffset = new Point(2, 2);
            clearFiltersBtn.ShakeDuration = 500;
            clearFiltersBtn.ShakeIntensity = 5;
            clearFiltersBtn.Size = new Size(141, 36);
            clearFiltersBtn.TabIndex = 6;
            clearFiltersBtn.Text = "Clear Filters";
            clearFiltersBtn.TextAlign = ContentAlignment.MiddleCenter;
            clearFiltersBtn.TextColor = Color.White;
            clearFiltersBtn.TooltipText = null;
            clearFiltersBtn.UseAdvancedRendering = true;
            clearFiltersBtn.UseParticles = false;
            clearFiltersBtn.Click += clearFiltersBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(392, 9);
            label2.Name = "label2";
            label2.Size = new Size(194, 27);
            label2.TabIndex = 5;
            label2.Text = "Template Type :";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // templateSelector
            // 
            templateSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            templateSelector.Font = new Font("Century Gothic", 13.8F);
            templateSelector.FormattingEnabled = true;
            templateSelector.Items.AddRange(new object[] { "All", "Attorney", "CallCenter", "Doctor", "ElectricalEngineering" });
            templateSelector.Location = new Point(601, 7);
            templateSelector.Name = "templateSelector";
            templateSelector.Size = new Size(347, 35);
            templateSelector.Sorted = true;
            templateSelector.TabIndex = 3;
            templateSelector.SelectedIndexChanged += templateSelector_SelectedIndexChanged;
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
            // searchTbx
            // 
            searchTbx.AccessibleDescription = "A customizable text input field.";
            searchTbx.AccessibleName = "Text Box";
            searchTbx.AccessibleRole = AccessibleRole.Text;
            searchTbx.BackColor = Color.Transparent;
            searchTbx.BlinkCount = 3;
            searchTbx.BlinkShadow = false;
            searchTbx.BorderColor1 = Color.LightSlateGray;
            searchTbx.BorderColor2 = Color.LightSlateGray;
            searchTbx.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            searchTbx.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            searchTbx.CanShake = true;
            searchTbx.ContinuousBlink = false;
            searchTbx.CursorBlinkRate = 500;
            searchTbx.CursorColor = Color.Black;
            searchTbx.CursorHeight = 26;
            searchTbx.CursorOffset = 0;
            searchTbx.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            searchTbx.CursorWidth = 1;
            searchTbx.DisabledBackColor = Color.WhiteSmoke;
            searchTbx.DisabledBorderColor = Color.LightGray;
            searchTbx.DisabledTextColor = Color.Gray;
            searchTbx.EnableDropShadow = false;
            searchTbx.FillColor1 = Color.White;
            searchTbx.FillColor2 = Color.White;
            searchTbx.Font = new Font("Segoe UI", 9.5F);
            searchTbx.ForeColor = Color.DimGray;
            searchTbx.HoverBorderColor1 = Color.Gray;
            searchTbx.HoverBorderColor2 = Color.Gray;
            searchTbx.IsEnabled = true;
            searchTbx.Location = new Point(63, 7);
            searchTbx.Name = "searchTbx";
            searchTbx.PlaceholderColor = Color.Gray;
            searchTbx.PlaceholderText = "Search by Name";
            searchTbx.ReadOnlyBorderColor1 = Color.LightGray;
            searchTbx.ReadOnlyBorderColor2 = Color.LightGray;
            searchTbx.ReadOnlyFillColor1 = Color.WhiteSmoke;
            searchTbx.ReadOnlyFillColor2 = Color.WhiteSmoke;
            searchTbx.ReadOnlyPlaceholderColor = Color.DarkGray;
            searchTbx.SelectionBackColor = Color.FromArgb(77, 77, 255);
            searchTbx.ShadowAnimationDuration = 1;
            searchTbx.ShadowBlur = 10;
            searchTbx.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            searchTbx.Size = new Size(312, 35);
            searchTbx.SolidBorderColor = Color.LightSlateGray;
            searchTbx.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            searchTbx.SolidBorderHoverColor = Color.Gray;
            searchTbx.SolidFillColor = Color.White;
            searchTbx.TabIndex = 2;
            searchTbx.TextPadding = new Padding(16, 0, 6, 0);
            searchTbx.ValidationErrorMessage = "Invalid input.";
            searchTbx.ValidationFunction = null;
            searchTbx.TextChanged += searchTbx_TextChanged;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(216, 225, 233);
            panel3.Controls.Add(createResumeBtn);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(2, 2);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(2);
            panel3.Size = new Size(373, 83);
            panel3.TabIndex = 10;
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
            exportResumeBtn.Padding = new Padding(70, 0, 0, 0);
            exportResumeBtn.Size = new Size(369, 79);
            exportResumeBtn.TabIndex = 33;
            exportResumeBtn.Text = "Export Resume";
            exportResumeBtn.TextAlign = ContentAlignment.MiddleLeft;
            exportResumeBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            exportResumeBtn.UseVisualStyleBackColor = false;
            exportResumeBtn.Click += exportResumeBtn_Click;
            // 
            // createResumeBtn
            // 
            createResumeBtn.BackColor = Color.FromArgb(41, 128, 185);
            createResumeBtn.Cursor = Cursors.Hand;
            createResumeBtn.Dock = DockStyle.Fill;
            createResumeBtn.FlatAppearance.BorderSize = 0;
            createResumeBtn.FlatStyle = FlatStyle.Flat;
            createResumeBtn.Font = new Font("Century Gothic", 13.8F);
            createResumeBtn.ForeColor = Color.White;
            createResumeBtn.IconChar = FontAwesome.Sharp.IconChar.Add;
            createResumeBtn.IconColor = Color.FromArgb(216, 225, 233);
            createResumeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            createResumeBtn.IconSize = 50;
            createResumeBtn.ImageAlign = ContentAlignment.MiddleLeft;
            createResumeBtn.Location = new Point(2, 2);
            createResumeBtn.Margin = new Padding(2);
            createResumeBtn.Name = "createResumeBtn";
            createResumeBtn.Padding = new Padding(70, 0, 0, 0);
            createResumeBtn.Size = new Size(369, 79);
            createResumeBtn.TabIndex = 24;
            createResumeBtn.Text = " Create \r\n New Resume";
            createResumeBtn.TextAlign = ContentAlignment.MiddleLeft;
            createResumeBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            createResumeBtn.UseVisualStyleBackColor = false;
            createResumeBtn.Click += createNewBtn_Click;
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
            panel7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResumes).EndInit();
            templatePanelCorner.ResumeLayout(false);
            templatePanelCorner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            panel3.ResumeLayout(false);
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
        private Panel panel2;
        private DataGridView dgvResumes;
        private Panel templatePanelCorner;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private SiticoneNetCoreUI.SiticoneTextBox searchTbx;
        private ComboBox templateSelector;
        private Label label2;
        private FontAwesome.Sharp.IconButton deleteResumeBtn;
        private FontAwesome.Sharp.IconButton sendResumeBtn;
        private SiticoneNetCoreUI.SiticoneButton clearFiltersBtn;
        private Panel panel3;
        private FontAwesome.Sharp.IconButton exportResumeBtn;
        private FontAwesome.Sharp.IconButton createResumeBtn;
    }
}
