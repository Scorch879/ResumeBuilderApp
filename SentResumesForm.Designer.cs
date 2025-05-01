namespace FinalProjectOOP2
{
    partial class SentResumesForm
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
            dgvSentResumes = new DataGridView();
            viewDetailsBtn = new Button();
            resendBtn = new Button();
            deleteBtn = new Button();
            refreshBtn = new Button();
            panel1 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSentResumes).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvSentResumes
            // 
            dgvSentResumes.AllowUserToAddRows = false;
            dgvSentResumes.AllowUserToDeleteRows = false;
            dgvSentResumes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSentResumes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSentResumes.BackgroundColor = SystemColors.Control;
            dgvSentResumes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSentResumes.Location = new Point(14, 80);
            dgvSentResumes.Margin = new Padding(3, 4, 3, 4);
            dgvSentResumes.MultiSelect = false;
            dgvSentResumes.Name = "dgvSentResumes";
            dgvSentResumes.ReadOnly = true;
            dgvSentResumes.RowHeadersWidth = 51;
            dgvSentResumes.RowTemplate.Height = 25;
            dgvSentResumes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSentResumes.Size = new Size(887, 452);
            dgvSentResumes.TabIndex = 0;
            // 
            // viewDetailsBtn
            // 
            viewDetailsBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            viewDetailsBtn.Location = new Point(14, 553);
            viewDetailsBtn.Margin = new Padding(3, 4, 3, 4);
            viewDetailsBtn.Name = "viewDetailsBtn";
            viewDetailsBtn.Size = new Size(114, 31);
            viewDetailsBtn.TabIndex = 1;
            viewDetailsBtn.Text = "View Details";
            viewDetailsBtn.UseVisualStyleBackColor = true;
            viewDetailsBtn.Click += viewDetailsBtn_Click;
            // 
            // resendBtn
            // 
            resendBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            resendBtn.Location = new Point(135, 553);
            resendBtn.Margin = new Padding(3, 4, 3, 4);
            resendBtn.Name = "resendBtn";
            resendBtn.Size = new Size(114, 31);
            resendBtn.TabIndex = 2;
            resendBtn.Text = "Resend";
            resendBtn.UseVisualStyleBackColor = true;
            resendBtn.Click += resendBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            deleteBtn.Location = new Point(256, 553);
            deleteBtn.Margin = new Padding(3, 4, 3, 4);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(114, 31);
            deleteBtn.TabIndex = 3;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // refreshBtn
            // 
            refreshBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            refreshBtn.Location = new Point(786, 553);
            refreshBtn.Margin = new Padding(3, 4, 3, 4);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(114, 31);
            refreshBtn.TabIndex = 4;
            refreshBtn.Text = "Refresh";
            refreshBtn.UseVisualStyleBackColor = true;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 31, 84);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(914, 60);
            panel1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(14, 14);
            label1.Name = "label1";
            label1.Size = new Size(200, 34);
            label1.TabIndex = 0;
            label1.Text = "Sent Resumes";
            // 
            // SentResumesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(panel1);
            Controls.Add(refreshBtn);
            Controls.Add(deleteBtn);
            Controls.Add(resendBtn);
            Controls.Add(viewDetailsBtn);
            Controls.Add(dgvSentResumes);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(930, 636);
            Name = "SentResumesForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sent Resumes";
            ((System.ComponentModel.ISupportInitialize)dgvSentResumes).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSentResumes;
        private Button viewDetailsBtn;
        private Button resendBtn;
        private Button deleteBtn;
        private Button refreshBtn;
        private Panel panel1;
        private Label label1;
    }
} 