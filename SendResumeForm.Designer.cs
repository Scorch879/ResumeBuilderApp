using System;
using System.Drawing;
using System.Windows.Forms;

namespace FinalProjectOOP2
{
    public partial class SendResumeForm : Form
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
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            recipientsLstBx = new ListBox();
            label2 = new Label();
            recipientTbx = new TextBox();
            addRecipientBtn = new Button();
            removeRecipientBtn = new Button();
            label3 = new Label();
            subjectTbx = new TextBox();
            label4 = new Label();
            messageTbx = new TextBox();
            label5 = new Label();
            coverLetterTbx = new TextBox();
            sendBtn = new Button();
            cancelBtn = new Button();
            defaultTemplateBtn = new Button();
            loadCoverLetterTemplateBtn = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            
            // panel1 - Header
            panel1.BackColor = Color.FromArgb(0, 31, 84);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1000, 60);
            panel1.TabIndex = 0;
            
            // label1 - Title
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(20, 15);
            label1.Name = "label1";
            label1.Size = new Size(200, 34);
            label1.TabIndex = 0;
            label1.Text = "Send Resume";
            
            // panel2 - Main Content
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 60);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(20);
            panel2.Size = new Size(1000, 640);
            panel2.TabIndex = 1;
            
            // Recipients List Box
            recipientsLstBx.FormattingEnabled = true;
            recipientsLstBx.Location = new Point(20, 80);
            recipientsLstBx.Name = "recipientsLstBx";
            recipientsLstBx.Size = new Size(300, 104);
            recipientsLstBx.TabIndex = 12;
            
            // Recipients Label
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 20);
            label2.Name = "label2";
            label2.Size = new Size(89, 21);
            label2.TabIndex = 0;
            label2.Text = "Recipients:";
            
            // Recipient TextBox
            recipientTbx.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            recipientTbx.Location = new Point(20, 50);
            recipientTbx.Name = "recipientTbx";
            recipientTbx.Size = new Size(300, 28);
            recipientTbx.TabIndex = 1;
            recipientTbx.PlaceholderText = "Enter email address";
            
            // Add Recipient Button
            addRecipientBtn.BackColor = Color.FromArgb(0, 31, 84);
            addRecipientBtn.FlatStyle = FlatStyle.Flat;
            addRecipientBtn.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addRecipientBtn.ForeColor = Color.White;
            addRecipientBtn.Location = new Point(20, 190);
            addRecipientBtn.Name = "addRecipientBtn";
            addRecipientBtn.Size = new Size(145, 35);
            addRecipientBtn.TabIndex = 2;
            addRecipientBtn.Text = "Add Recipient";
            addRecipientBtn.UseVisualStyleBackColor = false;
            addRecipientBtn.Click += addRecipientBtn_Click;
            
            // Remove Recipient Button
            removeRecipientBtn.BackColor = Color.FromArgb(0, 31, 84);
            removeRecipientBtn.FlatStyle = FlatStyle.Flat;
            removeRecipientBtn.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            removeRecipientBtn.ForeColor = Color.White;
            removeRecipientBtn.Location = new Point(175, 190);
            removeRecipientBtn.Name = "removeRecipientBtn";
            removeRecipientBtn.Size = new Size(145, 35);
            removeRecipientBtn.TabIndex = 3;
            removeRecipientBtn.Text = "Remove Selected";
            removeRecipientBtn.UseVisualStyleBackColor = false;
            removeRecipientBtn.Click += removeRecipientBtn_Click;
            
            // Subject Label
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(20, 240);
            label3.Name = "label3";
            label3.Size = new Size(75, 21);
            label3.TabIndex = 4;
            label3.Text = "Subject:";
            
            // Subject TextBox
            subjectTbx.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subjectTbx.Location = new Point(20, 270);
            subjectTbx.Name = "subjectTbx";
            subjectTbx.Size = new Size(960, 28);
            subjectTbx.TabIndex = 5;
            subjectTbx.PlaceholderText = "Enter email subject";
            
            // Message Label
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(20, 310);
            label4.Name = "label4";
            label4.Size = new Size(85, 21);
            label4.TabIndex = 6;
            label4.Text = "Message:";
            
            // Default Template Button
            defaultTemplateBtn.BackColor = Color.FromArgb(0, 31, 84);
            defaultTemplateBtn.FlatStyle = FlatStyle.Flat;
            defaultTemplateBtn.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            defaultTemplateBtn.ForeColor = Color.White;
            defaultTemplateBtn.Location = new Point(115, 305);
            defaultTemplateBtn.Name = "defaultTemplateBtn";
            defaultTemplateBtn.Size = new Size(145, 28);
            defaultTemplateBtn.TabIndex = 13;
            defaultTemplateBtn.Text = "Load Template";
            defaultTemplateBtn.UseVisualStyleBackColor = false;
            defaultTemplateBtn.Click += defaultTemplateBtn_Click;
            
            // Message TextBox
            messageTbx.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            messageTbx.Location = new Point(20, 340);
            messageTbx.Multiline = true;
            messageTbx.Name = "messageTbx";
            messageTbx.Size = new Size(960, 100);
            messageTbx.TabIndex = 7;
            messageTbx.PlaceholderText = "Enter your message here...";
            
            // Cover Letter Label
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(20, 450);
            label5.Name = "label5";
            label5.Size = new Size(110, 21);
            label5.TabIndex = 8;
            label5.Text = "Cover Letter:";
            
            // Load Cover Letter Template Button
            loadCoverLetterTemplateBtn.BackColor = Color.FromArgb(0, 31, 84);
            loadCoverLetterTemplateBtn.FlatStyle = FlatStyle.Flat;
            loadCoverLetterTemplateBtn.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loadCoverLetterTemplateBtn.ForeColor = Color.White;
            loadCoverLetterTemplateBtn.Location = new Point(140, 445);
            loadCoverLetterTemplateBtn.Name = "loadCoverLetterTemplateBtn";
            loadCoverLetterTemplateBtn.Size = new Size(145, 28);
            loadCoverLetterTemplateBtn.TabIndex = 14;
            loadCoverLetterTemplateBtn.Text = "Load Template";
            loadCoverLetterTemplateBtn.UseVisualStyleBackColor = false;
            loadCoverLetterTemplateBtn.Click += loadCoverLetterTemplateBtn_Click;
            
            // Cover Letter TextBox
            coverLetterTbx.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            coverLetterTbx.Location = new Point(20, 480);
            coverLetterTbx.Multiline = true;
            coverLetterTbx.Name = "coverLetterTbx";
            coverLetterTbx.Size = new Size(960, 100);
            coverLetterTbx.TabIndex = 9;
            coverLetterTbx.PlaceholderText = "Enter your cover letter here...";
            
            // Send Button
            sendBtn.BackColor = Color.FromArgb(0, 31, 84);
            sendBtn.FlatStyle = FlatStyle.Flat;
            sendBtn.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sendBtn.ForeColor = Color.White;
            sendBtn.Location = new Point(20, 590);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(145, 35);
            sendBtn.TabIndex = 10;
            sendBtn.Text = "Send";
            sendBtn.UseVisualStyleBackColor = false;
            sendBtn.Click += sendBtn_Click;
            
            // Cancel Button
            cancelBtn.BackColor = Color.FromArgb(0, 31, 84);
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelBtn.ForeColor = Color.White;
            cancelBtn.Location = new Point(175, 590);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(145, 35);
            cancelBtn.TabIndex = 11;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            
            // Add controls to panels
            panel2.Controls.Add(recipientsLstBx);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(recipientTbx);
            panel2.Controls.Add(addRecipientBtn);
            panel2.Controls.Add(removeRecipientBtn);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(subjectTbx);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(messageTbx);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(coverLetterTbx);
            panel2.Controls.Add(sendBtn);
            panel2.Controls.Add(cancelBtn);
            panel2.Controls.Add(defaultTemplateBtn);
            panel2.Controls.Add(loadCoverLetterTemplateBtn);
            
            // SendResumeForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 700);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SendResumeForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Send Resume";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private ListBox recipientsLstBx;
        private Label label2;
        private TextBox recipientTbx;
        private Button addRecipientBtn;
        private Button removeRecipientBtn;
        private Label label3;
        private TextBox subjectTbx;
        private Label label4;
        private TextBox messageTbx;
        private Label label5;
        private TextBox coverLetterTbx;
        private Button sendBtn;
        private Button cancelBtn;
        private Button defaultTemplateBtn;
        private Button loadCoverLetterTemplateBtn;
    }
} 