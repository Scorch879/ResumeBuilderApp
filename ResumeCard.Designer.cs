namespace FinalProjectOOP2
{
    partial class ResumeCard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnDelete;

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
            lblTitle = new Label();
            lblDate = new Label();
            lblStatus = new Label();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(270, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Resume Title";
            // 
            // lblDate
            // 
            lblDate.Font = new Font("Century Gothic", 9F);
            lblDate.ForeColor = Color.White;
            lblDate.Location = new Point(15, 40);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(200, 20);
            lblDate.TabIndex = 1;
            lblDate.Text = "Date Modified: 01/01/2024";
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Century Gothic", 9F);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(15, 65);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(200, 20);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status: Draft";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(161, 90);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(129, 25);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // ResumeCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 128, 185);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblTitle);
            Controls.Add(lblDate);
            Controls.Add(lblStatus);
            Controls.Add(btnDelete);
            Name = "ResumeCard";
            Size = new Size(300, 120);
            ResumeLayout(false);
        }

        #endregion
    }
}
