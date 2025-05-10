using System.Data.OleDb;
using System.Data;
using System.Runtime.InteropServices;
using System.Drawing;

namespace FinalProjectOOP2
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            usernameTbx.BackColor = Color.White;
            panel2.BackColor = Color.White;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            if (Login.instance == null)
                return;

            if (Application.OpenForms.Count == 1)
                Application.Exit();

            Login.instance.Show();
            this.Close();
        }

        private void usernameTbx_Click(object sender, EventArgs e)
        {
            usernameTbx.BackColor = Color.White;
            panel2.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            passwordTbx.BackColor = SystemColors.Control;
            emailTbx.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;

        }

        private void passwordTbx_Click(object sender, EventArgs e)
        {
            passwordTbx.BackColor = Color.White;
            panel4.BackColor = Color.White;
            usernameTbx.BackColor = SystemColors.Control;
            panel2.BackColor = SystemColors.Control;
            emailTbx.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;

        }

        private void emailTbx_Click(object sender, EventArgs e)
        {
            emailTbx.BackColor = Color.White;
            panel3.BackColor = Color.White;
            usernameTbx.BackColor = SystemColors.Control;
            panel2.BackColor = SystemColors.Control;
            passwordTbx.BackColor = SystemColors.Control;
            panel4.BackColor = SystemColors.Control;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            passwordTbx.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            passwordTbx.UseSystemPasswordChar = true;
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            string username = usernameTbx.Text;
            string password = passwordTbx.Text;
            string email = emailTbx.Text;
            string? choice = "";

            if (adminRadioBtn.Checked == true)
            {
                choice += adminRadioBtn.Text;
            }
            else if (userRadioBtn.Checked == true)
            {
                choice += userRadioBtn.Text;
            }

         

            if (username != "" && password != "" && choice != "" && email != "" && !password.Any(char.IsWhiteSpace) && dbHelper.isValidEmail(email))
            {
                bool success = dbHelper.RegisterUser(username, password, choice, email);

                if (success)
                {
                    MessageBox.Show("Account Registered!", "Information", MessageBoxButtons.OK
                        , MessageBoxIcon.Information);
                }
                else
                {
                    return; 
                }

                //Let login form show again
                Login loginForm = new Login();
                loginForm.Show();
                this.Hide();
            }
            else
            {
                List<string> errors = new List<string>();

                if (!dbHelper.isValidEmail(email))
                    errors.Add("Email format is invalid!");
                if (string.IsNullOrWhiteSpace(usernameTbx.Text))
                    errors.Add("Username is required.");
                if (password.Any(char.IsWhiteSpace))
                    errors.Add("Pasword cannot contain spaces.");
                if (string.IsNullOrWhiteSpace(passwordTbx.Text))
                    errors.Add("Password is required.");
                if (string.IsNullOrWhiteSpace(choice))
                    errors.Add("Please select a role.");
                if (string.IsNullOrWhiteSpace(emailTbx.Text))
                    errors.Add("Please enter your email.");
                if (password.Length < 8)
                    errors.Add("Password must be atleast 8 spaces");

                if (errors.Count > 0)
                {
                    string message = string.Join(Environment.NewLine, errors);
                    MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {
            ImageAnimator.Animate(pictureBox1.Image, OnFrameChanged);
        }

        private void OnFrameChanged(object? o, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void Register_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                registerBtn_Click(sender, e);
            }
        }

        private void passwordTbx_TextChanged(object sender, EventArgs e)
        {

            string password = passwordTbx.Text;

            bool meetsLength = password.Length >= 8;
            bool noWhiteSpace = !password.Any(char.IsWhiteSpace);

            string criteriaMessage = "Note:\n";

            if (!meetsLength)
                criteriaMessage += "✗ At least 8 characters\n";

            if (!noWhiteSpace)
                criteriaMessage += "✗ No whitespaces allowed\n";

            if (string.IsNullOrEmpty(criteriaMessage) || criteriaMessage == "Note:\n")
            {
                criteriaMessage += "✓ Password meets all criteria!\n";
                warningLbl.ForeColor = Color.Green;
            }
            else
            {
                warningLbl.ForeColor = Color.Red;
            }

            warningLbl.Text = criteriaMessage;
        }
    }
}