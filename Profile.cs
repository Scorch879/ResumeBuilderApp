using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectOOP2
{
    public partial class Profile : UserControl, ICurrentUsername
    {
        private string? currentUser;

        public string? CurrentUsername 
        {
            get => currentUser;
            set
            {
                currentUser = value;
                usernameLbl.Text = currentUser; // update the profile label or textbox
            }
        }

        public Profile(string username)
        {

            InitializeComponent();
            currentUser = username;

            var userDetails = new DatabaseHelper().GetUserDetailsByUsername(currentUser);
            usernameLbl.Text = userDetails.username;
            emaillbl.Text = userDetails.email;
            descriptionTbx.Text = userDetails.description;
            fullnameLbl.Text = userDetails.fullName;

            if (userDetails.profilePic != null && userDetails.profilePic.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(userDetails.profilePic))
                {
                    profilePic.Image = Image.FromStream(ms);
                }
            }
            else
            {
                // Set a default image if no profile picture is available
                profilePic.Image = Properties.Resources.default_profile; // Add a default image to your resources
            }
        }

        private void deleteAccBtn_Click(object sender, EventArgs e)
        {
            // Create a password input dialog
            using (var passwordDialog = new Form())
            {
                passwordDialog.Text = "Confirm Account Deletion";
                passwordDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                passwordDialog.MaximizeBox = false;
                passwordDialog.MinimizeBox = false;
                passwordDialog.StartPosition = FormStartPosition.CenterParent;
                passwordDialog.Width = 300;
                passwordDialog.Height = 150;

                // Create password label and textbox
                var lblPassword = new Label()
                {
                    Text = "Enter your password to confirm:",
                    Left = 20,
                    Top = 20,
                    Width = 250
                };

                var txtPassword = new TextBox()
                {
                    Left = 20,
                    Top = 50,
                    Width = 250,
                    PasswordChar = '*' // Hide password characters
                };

                // Create OK and Cancel buttons
                var btnOk = new Button()
                {
                    Text = "OK",
                    Left = 130,
                    Top = 80,
                    Width = 60,
                    DialogResult = DialogResult.OK
                };

                var btnCancel = new Button()
                {
                    Text = "Cancel",
                    Left = 200,
                    Top = 80,
                    Width = 60,
                    DialogResult = DialogResult.Cancel
                };

                // Add controls to the form
                passwordDialog.Controls.Add(lblPassword);
                passwordDialog.Controls.Add(txtPassword);
                passwordDialog.Controls.Add(btnOk);
                passwordDialog.Controls.Add(btnCancel);

                // Set accept and cancel buttons
                passwordDialog.AcceptButton = btnOk;
                passwordDialog.CancelButton = btnCancel;

                // Show dialog and check result
                if (passwordDialog.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(txtPassword.Text))
                    {
                        MessageBox.Show("Please enter your password", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var dbHelper = new DatabaseHelper();
                    if (dbHelper.DeleteAccount(currentUser, txtPassword.Text))
                    {
                        MessageBox.Show("Account deleted successfully", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Get reference to parent Dashboard
                        if (this.ParentForm is Dashboard dashboard)
                        {
                            // Close dashboard and show login
                            dashboard.CloseAndShowLogin();
                        }

                    }
                }
            }
        }

        private void updateProfileBtn_Click(object sender, EventArgs e)
        {
            var dashboard = this.FindForm() as Dashboard;
            if (dashboard == null || string.IsNullOrEmpty(dashboard.CurrentUser))
            {
                MessageBox.Show("Current user is not set.");
                return;
            }

            UpdateProfile updateForm = new UpdateProfile();
            updateForm.CurrentUsername = dashboard.CurrentUser;
            updateForm.Owner = dashboard;

            updateForm.ShowDialog();

            RefreshProfileData(); // Reload data after update
        }

        private void changeProfilePicBtn_Click(object sender, EventArgs e)
        {
            if (currentUser == null)
                throw new NullReferenceException("Current user is not set.");

            DatabaseHelper dbHelper = new DatabaseHelper();

            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] imageBytes = File.ReadAllBytes(ofd.FileName);
                bool updated = dbHelper.UpdateProfilePicture(currentUser, imageBytes);

                if (updated)
                {
                    profilePic.Image = Image.FromFile(ofd.FileName);
                    MessageBox.Show("Profile picture updated successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to update profile picture.");
                }
            }
        }

        private void RefreshProfileData()
        {
            var userDetails = new DatabaseHelper().GetUserDetailsByUsername(currentUser);
            usernameLbl.Text = userDetails.username;
            emaillbl.Text = userDetails.email;
            descriptionTbx.Text = userDetails.description;
            fullnameLbl.Text = userDetails.fullName;

            if (userDetails.profilePic != null && userDetails.profilePic.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(userDetails.profilePic))
                {
                    profilePic.Image = Image.FromStream(ms);
                }
            }
            else
            {
                profilePic.Image = Properties.Resources.default_profile;
            }
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            // Clear session or user-specific data
            currentUser = null;  // Reset the current user
            currentUsername = null;  // If you're using a property to hold the current username

            // Optionally, clear any UI elements that are user-specific
            usernameLbl.Text = "Guest";
            emaillbl.Text = "N/A";
            descriptionTbx.Text = "";
            fullnameLbl.Text = "N/A";
            profilePic.Image = Properties.Resources.default_profile;

            // Close the Dashboard (Parent Form)
            if (this.ParentForm is Dashboard dashboard)
            {
                dashboard.Close();  // Close the dashboard
            }

            // Show the Login Form
            Login loginForm = new Login();
            loginForm.Show();  // Open the login form to let the user log in again
        }
    }
}
