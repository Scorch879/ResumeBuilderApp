using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FinalProjectOOP2
{
    public partial class UpdateProfile : Form, ICurrentUsername
    {
        private DatabaseHelper dbHelper;
        private string? currentUser;


        public string? UpdatedUsername { get; private set; }

        public string CurrentUser { get; set; }

        public string? CurrentUsername
        {
            get => currentUser;
            set => currentUser = value;
        }

        public UpdateProfile()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void usernameUpdate_Click(object sender, EventArgs e)
        {
            if (currentUser == null)
                throw new NullReferenceException("Current user is not set.");

            string newUsername = usernameTbx.Text.Trim();
            if (string.IsNullOrWhiteSpace(newUsername))
            {
                MessageBox.Show("Please enter a username!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool updated = dbHelper.UpdateUsername(newUsername, currentUser);
            if (updated)
            {
                MessageBox.Show("Username updated successfully!");
                this.UpdatedUsername = newUsername;
                currentUser = newUsername;
            }
            else
            {
                MessageBox.Show("Failed to update username.");
            }
        }

        private void emailUpdate_Click(object sender, EventArgs e)
        {
            if (currentUser == null)
                throw new NullReferenceException("Current user is not set.");

            string newEmail = emailTbx.Text.Trim();
            if (string.IsNullOrWhiteSpace(newEmail))
            {
                MessageBox.Show("Please enter an email!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool updated = dbHelper.UpdateEmail(newEmail, currentUser);
            MessageBox.Show(updated ? "Email updated successfully!" : "Failed to update email.");
        }

        private void descriptionUpdate_Click(object sender, EventArgs e)
        {
            if (currentUser == null)
                throw new NullReferenceException("Current user is not set.");

            string newDescription = descriptionRtbx.Text.Trim();
            if (string.IsNullOrWhiteSpace(newDescription))
            {
                MessageBox.Show("Please enter a description!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool updated = dbHelper.UpdateDescription(currentUser, newDescription);
            MessageBox.Show(updated ? "Description updated successfully!" : "Failed to update description.");
        }


        private void doneBtn_Click(object sender, EventArgs e)
        {
            if (currentUser == null)
            {
                MessageBox.Show("Current user is not set.");
                return;
            }

            string newUsername = usernameTbx.Text.Trim();
            string newEmail = emailTbx.Text.Trim();
            string newDescription = descriptionRtbx.Text.Trim();
            string newFullName = fullnameTbx.Text.Trim(); // Added for full name update

            bool allSuccess = true;
            string failedUpdates = "";

            // Attempt to update email if it's not empty
            if (!string.IsNullOrWhiteSpace(newEmail))
            {
                bool emailUpdated = dbHelper.UpdateEmail(newEmail, currentUser);
                if (!emailUpdated)
                {
                    failedUpdates += "Email update failed.\n";
                    allSuccess = false;
                }
            }

            // Attempt to update description if it's not empty
            if (!string.IsNullOrWhiteSpace(newDescription))
            {
                bool descriptionUpdated = dbHelper.UpdateDescription(currentUser, newDescription);
                if (!descriptionUpdated)
                {
                    failedUpdates += "Description update failed.\n";
                    allSuccess = false;
                }
            }

            // Attempt to update full name if it's not empty
            if (!string.IsNullOrWhiteSpace(newFullName))
            {
                bool fullNameUpdated = dbHelper.UpdateFullName(newFullName, currentUser);
                if (!fullNameUpdated)
                {
                    failedUpdates += "Full name update failed.\n";
                    allSuccess = false;
                }
            }

            // Attempt to update username last if it's not empty
            if (!string.IsNullOrWhiteSpace(newUsername))
            {
                bool usernameUpdated = dbHelper.UpdateUsername(newUsername, currentUser);
                if (!usernameUpdated)
                {
                    failedUpdates += "Username update failed.\n";
                    allSuccess = false;
                }
                else
                {
                    currentUser = newUsername; // Update reference if username was changed
                }
            }

            // Check if all updates were successful
            if (allSuccess)
            {
                MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.UpdatedUsername = newUsername;
                currentUser = newUsername; // Update reference if username was changed
                this.Close();
            }
            else
            {
                MessageBox.Show($"Some updates failed:\n{failedUpdates}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void fullNameUpdate_Click(object sender, EventArgs e)
        {
            if (currentUser == null)
                throw new NullReferenceException("Current user is not set.");

            string newFullName = fullnameTbx.Text.Trim();
            if (string.IsNullOrWhiteSpace(newFullName))
            {
                MessageBox.Show("Please enter your full name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool updated = dbHelper.UpdateFullName(newFullName, currentUser);
            MessageBox.Show(updated ? "Full name updated successfully!" : "Failed to update full name.");
        }
    }
}
