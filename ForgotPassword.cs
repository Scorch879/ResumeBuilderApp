using Microsoft.UI.Xaml.Controls;

namespace FinalProjectOOP2
{
    public partial class ForgotPassword : Form
    {
        private string user;

        public ForgotPassword(string username)
        {
            InitializeComponent();
            user = username;
        }

        private void newPasswordTbx_Click(object sender, EventArgs e)
        {
            newPasswordTbx.BackColor = Color.White;
            panel2.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            confirmPasswordTbx.BackColor = SystemColors.Control;
        }

        private void confirmPasswordTbx_Click(object sender, EventArgs e)
        {
            newPasswordTbx.BackColor = SystemColors.Control;
            panel2.BackColor = SystemColors.Control;
            panel4.BackColor = Color.White;
            confirmPasswordTbx.BackColor = Color.White;
        }

        public void passwordTbx_TextChanged(object sender, EventArgs e)
        {
            string newPassword = newPasswordTbx.Text;

            bool meetsLength = newPassword.Length >= 8;
            bool noWhiteSpace = !newPassword.Any(char.IsWhiteSpace);

         
            string criteriaMessage = "";

          
            if (meetsLength)
                criteriaMessage += "✓ At least 8 characters\n";
            else
                criteriaMessage += "✗ At least 8 characters\n";

          
            if (noWhiteSpace)
                criteriaMessage += "✓ No whitespaces allowed\n";
            else
                criteriaMessage += "✗ No whitespaces allowed\n";

          
            if (meetsLength && noWhiteSpace)
            {
                warningLbl.ForeColor = Color.Green;
                criteriaMessage += "\nPassword meets all criteria!";
            }
            else
            {
                warningLbl.ForeColor = Color.Red;
            }

          
            warningLbl.Text = criteriaMessage;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            confirmPasswordTbx.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            confirmPasswordTbx.UseSystemPasswordChar = true;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            newPasswordTbx.UseSystemPasswordChar = false;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            newPasswordTbx.UseSystemPasswordChar = true;
        }

        private void newPassword_Enter(object sender, EventArgs e)
        {
            if (newPasswordTbx.Text == "Enter New Password")
            {
                newPasswordTbx.Text = "";
                newPasswordTbx.UseSystemPasswordChar = true;
            }
        }

        private void newPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(newPasswordTbx.Text))
            {
                newPasswordTbx.UseSystemPasswordChar = false;
                newPasswordTbx.Text = "Enter New Password";
            }
        }

        private void currentPassword_Enter (object sender, EventArgs e)
        {
            if (confirmPasswordTbx.Text == "Confirm Password")
            {
                confirmPasswordTbx.Text = "";
                confirmPasswordTbx.UseSystemPasswordChar = true;
            }
        }

        private void currentPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(confirmPasswordTbx.Text))
            {
                confirmPasswordTbx.UseSystemPasswordChar = false;
                confirmPasswordTbx.Text = "Confirm Password";
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            if (Login.instance == null)
            {
                Application.Exit();
                return;
            }

            if (Application.OpenForms.Count == 1)
                Application.Exit();

            Login.instance.Show();
            this.Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string newPassword = newPasswordTbx.Text;
            string confirmPassword = confirmPasswordTbx.Text;

            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(newPassword) || newPassword == "Enter New Password")
                errors.Add("Please enter a new password.");
            if (string.IsNullOrWhiteSpace(confirmPassword) || confirmPassword == "Confirm Password")
                errors.Add("Please enter the same password.");
            if (newPassword.Trim().Length < 8 || confirmPassword.Trim().Length < 8)
                errors.Add("Password must atleast be 8 characters long");
            if (newPassword.Contains(" "))
                errors.Add("Password must not contain any spaces.");
            if (newPassword != confirmPassword)
                errors.Add("Passwords does not match!!");

            if (errors.Any())
            {
                MessageBox.Show(string.Join("\n", errors), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DatabaseHelper dbHelper = new DatabaseHelper();
            if (dbHelper.UpdatePass(user, newPassword) == true)
            {
                if (Login.instance == null)
                    return;

                Login.instance.Show();
                this.Close();
            }
        }
    }
}