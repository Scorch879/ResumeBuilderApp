using System.Net.Mail;
using System.Net;
using System.Net.Mime;

namespace FinalProjectOOP2
{
    public partial class VerifyUser : Form
    {
        private string username = ""; 
        private string? randomCode;
        private readonly string appPassword = "geuj lqnj rkfo prvs";
        private bool codeSent = false;
        private DateTime expiryTime;

        public VerifyUser()
        {
            InitializeComponent();
            codeTbx.Enabled = true; //Prevent to click verify even without email sent
            verifyBtn.Enabled = false;
            emailTbx.BackColor = Color.White;
            panel2.BackColor = Color.White;
        }

        private void emailTbx_Click(object sender, EventArgs e)
        {
            emailTbx.BackColor = Color.White;
            panel2.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            codeTbx.BackColor = SystemColors.Control;
        }

        private void codeTbx_Click(object sender, EventArgs e)
        {
            emailTbx.BackColor = SystemColors.Control;
            panel2.BackColor = SystemColors.Control;
            panel4.BackColor = Color.White;
            codeTbx.BackColor = Color.White;
        }

        private void sendCodeBtn_Click(object sender, EventArgs e)
        {
            string email = emailTbx.Text;

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter an email address!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (isValidEmail(email) == false)
            {
                MessageBox.Show("Please enter a valid email address!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //this is to check if the email is in the database or not
            DatabaseHelper dbHelper = new DatabaseHelper();
            username = dbHelper.GetUserNameByEmail(email);

            if (username == "User")
            {
                MessageBox.Show("User with that email does not exist.", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Random rand = new Random();
            randomCode = rand.Next(100000, 999999).ToString();
            expiryTime = DateTime.Now.AddMinutes(5); // 5 min expiry;

            // Create a new MailMessage object
            MailMessage message = new MailMessage();
            message.To.Add(email);
            message.From = new MailAddress("scorch857@gmail.com", "Resume Builder Support"); // Your Gmail address
            message.Subject = "🔐 Resume Builder App - Your Password Reset Code!";

            message.IsBodyHtml = true; // HTML content

            string htmlBody = $@"
            <html>
              <body style='font-family: Arial, sans-serif; background-color: #f9f9f9; padding: 20px; color: #333;'>
                <div style='max-width: 600px; margin: auto; background-color: #ffffff; padding: 20px; border-radius: 10px; box-shadow: 0 2px 5px rgba(0,0,0,0.1);'>
      
                  <div style='text-align: center; margin-bottom: 20px;'>
                    <img src='cid:LogoImage' alt='Logo' style='width: 150px; height: 150px;'>
                  </div>
      
                  <h2 style='color: #4CAF50; text-align: center;'>Password Reset Request</h2>

                  <p>Hello <strong>{username}</strong>,</p>
      
                  <p>We received a request to reset your password for your <strong>Resume Builder App</strong> account.</p>

                  <p style='margin: 20px 0;'>Please use the verification code below to reset your password:</p>

                  <div style='font-size: 28px; font-weight: bold; background-color: #f1f1f1; color: #333; padding: 15px 25px; border-radius: 8px; text-align: center; letter-spacing: 3px;'>
                    {randomCode}
                  </div>

                  <p style='margin-top: 20px;'>This code will expire after <strong>5 minutes</strong> at {expiryTime.ToString("hh:mm tt")}.</p>

                  <p>If you did not request a password reset, you can safely ignore this email.</p>

                  <hr style='margin: 30px 0; border: none; border-top: 1px solid #eee;'>

                  <p style='font-size: 12px; color: #888; text-align: center;'>
                    © {DateTime.Now.Year} Resume Builder App. All rights reserved.<br>
                    Need help? Contact us at <a href='mailto:jobertdamian.gamboa@cit.edu'>jobertdamian.gamboa@cit.edu</a>
                  </p>
                </div>
              </body>
            </html>";

            //alternate view for HTML
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);

            string logoPath = @"D:\C# Codes\FinalProjectOOP2\bin\Debug\logo.png"; 
            LinkedResource logo = new LinkedResource(logoPath, MediaTypeNames.Image.Png)
            {
                ContentId = "LogoImage", 
                TransferEncoding = TransferEncoding.Base64
            };
            htmlView.LinkedResources.Add(logo);
            message.AlternateViews.Add(htmlView);

            // Configure SMTP client
            using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
            {
                client.Port = 587;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;

                client.Credentials = new NetworkCredential("scorch857@gmail.com", appPassword); //MA CHANGE PANI

                try
                {
                    client.Send(message);
                    MessageBox.Show("Verification code sent successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    codeSent = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending email: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    codeSent = false;
                }
                finally
                {
                    if (codeSent)
                    {
                        codeTbx.Enabled = true;
                        verifyBtn.Enabled = true;
                    }
                }
            }
        }

        private void verifyBtn_Click(object sender, EventArgs e)
        {
            string enteredCode = codeTbx.Text.Trim();

            if (string.IsNullOrEmpty(randomCode))
            {
                MessageBox.Show("Please request a verification code first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DateTime.Now > expiryTime)
            {
                MessageBox.Show("The verification code has expired. Please request a new one.", "Code Expired",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                randomCode = null;
                expiryTime = DateTime.MinValue;

                return;
            }

            if (enteredCode == randomCode)
            {
                MessageBox.Show("Code verified successfully!", "Success",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                ForgotPassword forgotPassword = new ForgotPassword(username);
                forgotPassword.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid code. Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void emailTbx_Enter(object sender, EventArgs e)
        {
            if (emailTbx.Text == "Enter registered email")
            {
                emailTbx.Text = "";
            }
        }

        private void emailTbx_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailTbx.Text))
            {
                emailTbx.Text = "Enter registered email";
            }
        }

        private void codeTbx_Enter(object sender, EventArgs e)
        {
            if (codeTbx.Text == "Enter Code")
            {
                codeTbx.Text = "";
            }
        }

        private void codeTbx_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(codeTbx.Text))
            {
                codeTbx.Text = "Enter Code";
            }
        }

        private bool isValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}