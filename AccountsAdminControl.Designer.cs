namespace FinalProjectOOP2
{
    partial class AccountsAdminControl
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
            this.headerLabel = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.usersGrid = new System.Windows.Forms.DataGridView();
            this.updateBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.headerLabel.Location = new System.Drawing.Point(40, 20);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(480, 47);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "User Accounts Management";
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchBox.Location = new System.Drawing.Point(40, 75);
            this.searchBox.Name = "searchBox";
            this.searchBox.PlaceholderText = "Search by username, email, or role...";
            this.searchBox.Size = new System.Drawing.Size(400, 32);
            this.searchBox.TabIndex = 1;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // usersGrid
            // 
            this.usersGrid.AllowUserToAddRows = false;
            this.usersGrid.AllowUserToDeleteRows = false;
            this.usersGrid.AllowUserToResizeRows = false;
            this.usersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.usersGrid.BackgroundColor = System.Drawing.Color.White;
            this.usersGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersGrid.Location = new System.Drawing.Point(40, 120);
            this.usersGrid.MultiSelect = false;
            this.usersGrid.Name = "usersGrid";
            this.usersGrid.ReadOnly = true;
            this.usersGrid.RowHeadersVisible = false;
            this.usersGrid.RowTemplate.Height = 29;
            this.usersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usersGrid.Size = new System.Drawing.Size(1420, 600);
            this.usersGrid.TabIndex = 2;
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.updateBtn.FlatAppearance.BorderSize = 0;
            this.updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.updateBtn.ForeColor = System.Drawing.Color.White;
            this.updateBtn.Location = new System.Drawing.Point(40, 740);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(180, 45);
            this.updateBtn.TabIndex = 3;
            this.updateBtn.Text = "Update Selected";
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.deleteBtn.FlatAppearance.BorderSize = 0;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.deleteBtn.ForeColor = System.Drawing.Color.White;
            this.deleteBtn.Location = new System.Drawing.Point(240, 740);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(180, 45);
            this.deleteBtn.TabIndex = 4;
            this.deleteBtn.Text = "Delete Selected";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // AccountsAdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(216, 225, 233);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.usersGrid);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.deleteBtn);
            this.Name = "AccountsAdminControl";
            this.Size = new System.Drawing.Size(1510, 850);
            ((System.ComponentModel.ISupportInitialize)(this.usersGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.DataGridView usersGrid;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button deleteBtn;
    }
} 