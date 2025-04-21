namespace FinalProjectOOP2
{
    partial class ResumePreviewForm
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
            iconButton1 = new FontAwesome.Sharp.IconButton();
            resumePreview = new Microsoft.Web.WebView2.WinForms.WebView2();
            panel1 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel2 = new Panel();
            panel5 = new Panel();
            ((System.ComponentModel.ISupportInitialize)resumePreview).BeginInit();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // iconButton1
            // 
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(264, 116);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(8, 8);
            iconButton1.TabIndex = 0;
            iconButton1.Text = "iconButton1";
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // resumePreview
            // 
            resumePreview.AllowExternalDrop = true;
            resumePreview.CreationProperties = null;
            resumePreview.DefaultBackgroundColor = Color.White;
            resumePreview.Dock = DockStyle.Fill;
            resumePreview.Location = new Point(5, 5);
            resumePreview.Name = "resumePreview";
            resumePreview.Size = new Size(801, 835);
            resumePreview.TabIndex = 1;
            resumePreview.ZoomFactor = 1D;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(967, 31);
            panel1.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 876);
            panel3.Name = "panel3";
            panel3.Size = new Size(967, 31);
            panel3.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 31);
            panel4.Name = "panel4";
            panel4.Size = new Size(72, 845);
            panel4.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(883, 31);
            panel2.Name = "panel2";
            panel2.Size = new Size(84, 845);
            panel2.TabIndex = 6;
            // 
            // panel5
            // 
            panel5.Controls.Add(resumePreview);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(72, 31);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(5);
            panel5.Size = new Size(811, 845);
            panel5.TabIndex = 7;
            // 
            // ResumePreviewForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(967, 907);
            Controls.Add(panel5);
            Controls.Add(panel2);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(iconButton1);
            Name = "ResumePreviewForm";
            Text = "Resume Preview";
            ((System.ComponentModel.ISupportInitialize)resumePreview).EndInit();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FontAwesome.Sharp.IconButton iconButton1;
        private Microsoft.Web.WebView2.WinForms.WebView2 resumePreview;
        private Panel panel1;
        private Panel panel3;
        private Panel panel4;
        private Panel panel2;
        private Panel panel5;
    }
}