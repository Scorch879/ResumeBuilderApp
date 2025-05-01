using System;
using System.Drawing;
using System.Windows.Forms;

namespace FinalProjectOOP2
{
    public class UpdateUserDialog : Form
    {
        private TextBox emailBox;
        private ComboBox roleBox;
        private TextBox fullNameBox;
        private TextBox descriptionBox;
        private Button okBtn;
        private Button cancelBtn;
        private UserRow originalUser;
        public UserRow UpdatedUser { get; private set; }

        public UpdateUserDialog(UserRow user)
        {
            this.Text = $"Update User: {user.Username}";
            this.Size = new Size(400, 350);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.originalUser = user;
            InitializeUI();
        }

        private void InitializeUI()
        {
            Label emailLbl = new Label { Text = "Email:", Location = new Point(20, 20), AutoSize = true };
            emailBox = new TextBox { Location = new Point(120, 18), Size = new Size(230, 28), Text = originalUser.Email };

            Label roleLbl = new Label { Text = "Role:", Location = new Point(20, 60), AutoSize = true };
            roleBox = new ComboBox { Location = new Point(120, 58), Size = new Size(230, 28), DropDownStyle = ComboBoxStyle.DropDownList };
            roleBox.Items.AddRange(new string[] { "User", "Admin" });
            roleBox.SelectedItem = originalUser.Role;

            Label fullNameLbl = new Label { Text = "Full Name:", Location = new Point(20, 100), AutoSize = true };
            fullNameBox = new TextBox { Location = new Point(120, 98), Size = new Size(230, 28), Text = originalUser.FullName };

            Label descLbl = new Label { Text = "Description:", Location = new Point(20, 140), AutoSize = true };
            descriptionBox = new TextBox { Location = new Point(120, 138), Size = new Size(230, 60), Text = originalUser.Description, Multiline = true };

            okBtn = new Button { Text = "OK", Location = new Point(120, 220), Size = new Size(80, 35), DialogResult = DialogResult.OK };
            cancelBtn = new Button { Text = "Cancel", Location = new Point(220, 220), Size = new Size(80, 35), DialogResult = DialogResult.Cancel };

            okBtn.Click += OkBtn_Click;

            this.Controls.Add(emailLbl);
            this.Controls.Add(emailBox);
            this.Controls.Add(roleLbl);
            this.Controls.Add(roleBox);
            this.Controls.Add(fullNameLbl);
            this.Controls.Add(fullNameBox);
            this.Controls.Add(descLbl);
            this.Controls.Add(descriptionBox);
            this.Controls.Add(okBtn);
            this.Controls.Add(cancelBtn);
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            UpdatedUser = new UserRow
            {
                Username = originalUser.Username,
                Email = emailBox.Text.Trim(),
                Role = roleBox.SelectedItem?.ToString() ?? "User",
                FullName = fullNameBox.Text.Trim(),
                Description = descriptionBox.Text.Trim()
            };
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
} 