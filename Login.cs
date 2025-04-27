namespace FinalProjectOOP2
{
    public partial class Login : Form
    {
        public static Login? instance;

        public Login()
        {
            InitializeComponent();
            instance = this;

            //preload  dashboard
           // Dashboard dashboard = new Dashboard();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usernameTbx_Click(object sender, EventArgs e)
        {
            usernameTbx.BackColor = Color.White;
            panel2.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            passwordTbx.BackColor = SystemColors.Control;

        }

        private void passwordTbx_Click(object sender, EventArgs e)
        {
            passwordTbx.BackColor = Color.White;
            panel4.BackColor = Color.White;
            usernameTbx.BackColor = SystemColors.Control;
            panel2.BackColor = SystemColors.Control;
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
            Register registerForm = new Register();
            registerForm.Show();
            usernameTbx.Text = "";
            passwordTbx.Text = "";
            this.Hide();
        }

        private void loginBtn_Click(object? sender, EventArgs e)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            loginBtn.Enabled = false;

            try
            {
                if (string.IsNullOrWhiteSpace(usernameTbx.Text) || string.IsNullOrWhiteSpace(passwordTbx.Text))
                {
                    MessageBox.Show($"Please enter your username and password!", "Error", MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                }

                else if (dbHelper.LoginUser(usernameTbx.Text, passwordTbx.Text))
                {
                    string currentUser = usernameTbx.Text;
                    Dashboard dashboard = new Dashboard();
                    dashboard.CurrentUser = currentUser;

                    MessageBox.Show("Login Successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    usernameTbx.Text = "";
                    passwordTbx.Text = "";
                    this.Hide();
                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show($"Please check your username or password!", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                }
            }
            finally
            {
                loginBtn.Enabled = true;
            }
        }

        private void forgotPassword_Click(object sender, EventArgs e)
        {
            VerifyUser verifyForm = new VerifyUser();
            verifyForm.Show();
            usernameTbx.Text = "";
            passwordTbx.Text = "";
            this.Hide();
        }

        private void testConnection_Click(object sender, EventArgs e)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            dbHelper.TestConnection();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginBtn_Click(sender, e);
            }
        }
    }
}