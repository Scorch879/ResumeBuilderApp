using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System.Data;

namespace FinalProjectOOP2
{
    public partial class SendResumeForm : Form
    {
        private string? resumePath;
        private string? currentUsername;
        private ResumeDatabase? db;
        private string? defaultMessageTemplate;
        private string? defaultSubject;
        private string? defaultCoverLetterTemplate;
       

        public SendResumeForm(string resumePath, string currentUsername)
        {
            InitializeComponent();
            this.resumePath = resumePath;
            this.currentUsername = currentUsername;
            this.db = new ResumeDatabase();
            
            // Initialize default templates
            InitializeDefaultTemplates();
            InitializeForm();
        }

        private void InitializeDefaultTemplates()
        {
            defaultSubject = "Job Application - Resume";
            
            defaultMessageTemplate = @"Dear Hiring Manager,

I am writing to express my interest in the position at your company. Please find my resume attached for your review.

I am confident that my skills and experience make me a strong candidate for this role. I would welcome the opportunity to discuss how I can contribute to your organization.

Thank you for your time and consideration.

Best regards,
[Your Name]";

            defaultCoverLetterTemplate = @"[Your Name]
            [Your Address]
            [Your Email]
            [Your Phone]
            [Date]

            [Hiring Manager's Name]
            [Company Name]
            [Company Address]

            Dear [Hiring Manager's Name],

            I am writing to express my strong interest in the [Position] position at [Company Name], as advertised on [Job Board/Company Website]. With my background in [relevant field] and proven track record of [key achievement], I am confident in my ability to contribute significantly to your team.

            In my current role at [Current/Previous Company], I have developed extensive experience in [relevant skills/responsibilities]. Some key achievements include:
            • [Achievement 1 with quantifiable results]
            • [Achievement 2 with quantifiable results]
            • [Achievement 3 with quantifiable results]

            What particularly draws me to [Company Name] is your [specific aspect of company - e.g., innovative approach to industry challenges, commitment to sustainability, market leadership in specific area]. I am excited about the opportunity to contribute to [specific company project or goal] and believe my experience in [relevant skill/experience] would be valuable in achieving these objectives.

            I am particularly skilled in:
            • [Key Skill 1]
            • [Key Skill 2]
            • [Key Skill 3]

            I would welcome the opportunity to discuss how my background and skills would benefit [Company Name]. Thank you for considering my application. I look forward to speaking with you about this opportunity.

            Sincerely,
            [Your Name]";
        }

        private void InitializeForm()
        {
            // Clear default text
            subjectTbx.Text = "";
            messageTbx.Text = "";
            coverLetterTbx.Text = "";
            
            // Set placeholder text
            subjectTbx.PlaceholderText = "Enter email subject or click Load Template";
            messageTbx.PlaceholderText = "Enter your message or click Load Template";
            coverLetterTbx.PlaceholderText = "Enter your cover letter or click Load Cover Letter Template";

            // Load recent recipients if any
            LoadRecentRecipients();
        }

        private void LoadRecentRecipients()
        {
            try
            {
                int userId = db.GetCurrentUserID(currentUsername);
                DataTable dt = db.LoadSentResumes(userId);
                
                if (dt.Rows.Count > 0)
                {
                    // Get unique recipients from the last 5 sent resumes
                    var recentRecipients = dt.AsEnumerable()
                        .Take(5)
                        .SelectMany(row => row.Field<string>("Recipients").Split(';'))
                        .Select(email => email.Trim())
                        .Distinct()
                        .ToList();

                    foreach (string recipient in recentRecipients)
                    {
                        recipientsLstBx.Items.Add(recipient);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading recent recipients: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void defaultTemplateBtn_Click(object sender, EventArgs e)
        {
            // Ask user if they want to load the default template
            if ((!string.IsNullOrWhiteSpace(subjectTbx.Text) || !string.IsNullOrWhiteSpace(messageTbx.Text)) &&
                MessageBox.Show("Loading the default template will replace your current message. Continue?",
                    "Confirm Template Load", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // Load default templates
            subjectTbx.Text = defaultSubject;
            messageTbx.Text = defaultMessageTemplate;

            // Try to replace [Your Name] with the user's name from personal info
            try
            {
                int userId = db.GetCurrentUserID(currentUsername);
                var personalInfo = db.LoadPersonalInfo(userId);
                if (personalInfo != null && !string.IsNullOrWhiteSpace(personalInfo.FirstName))
                {
                    string fullName = $"{personalInfo.FirstName} {personalInfo.LastName}".Trim();
                    messageTbx.Text = messageTbx.Text.Replace("[Your Name]", fullName);
                }
            }
            catch
            {
                // If we can't load the personal info, just leave [Your Name] as is
            }
        }

        private void loadCoverLetterTemplateBtn_Click(object sender, EventArgs e)
        {
            // Ask user if they want to load the default cover letter template
            if (!string.IsNullOrWhiteSpace(coverLetterTbx.Text) &&
                MessageBox.Show("Loading the default cover letter template will replace your current cover letter. Continue?",
                    "Confirm Template Load", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // Load default cover letter template
            coverLetterTbx.Text = defaultCoverLetterTemplate;

            // Try to replace placeholders with user's personal info
            try
            {
                int userId = db.GetCurrentUserID(currentUsername);
                var personalInfo = db.LoadPersonalInfo(userId);
                if (personalInfo != null)
                {
                    string fullName = $"{personalInfo.FirstName} {personalInfo.LastName}".Trim();
                    string address = personalInfo.Address ?? "";
                    string email = personalInfo.Email ?? "";
                    string phone = personalInfo.Phone ?? "";

                    coverLetterTbx.Text = coverLetterTbx.Text
                        .Replace("[Your Name]", fullName)
                        .Replace("[Your Address]", address)
                        .Replace("[Your Email]", email)
                        .Replace("[Your Phone]", phone)
                        .Replace("[Date]", DateTime.Now.ToString("MMMM dd, yyyy"));
                }
            }
            catch
            {
                // If we can't load the personal info, just leave placeholders as is
            }
        }

        private void addRecipientBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(recipientTbx.Text))
            {
                if (IsValidEmail(recipientTbx.Text))
                {
                    if (!recipientsLstBx.Items.Contains(recipientTbx.Text))
                    {
                        recipientsLstBx.Items.Add(recipientTbx.Text);
                        recipientTbx.Clear();
                    }
                    else
                    {
                        MessageBox.Show("This email address is already in the recipients list.",
                            "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid email address.", "Invalid Email",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void removeRecipientBtn_Click(object sender, EventArgs e)
        {
            if (recipientsLstBx.SelectedItem != null)
            {
                recipientsLstBx.Items.Remove(recipientsLstBx.SelectedItem);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private async void sendBtn_Click(object sender, EventArgs e)
        {
            if (recipientsLstBx.Items.Count == 0)
            {
                MessageBox.Show("Please add at least one recipient.", "No Recipients",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(subjectTbx.Text))
            {
                MessageBox.Show("Please enter a subject.", "Missing Subject",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(messageTbx.Text))
            {
                MessageBox.Show("Please enter a message.", "Missing Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if [Your Name] is still in the message
            if (messageTbx.Text.Contains("[Your Name]"))
            {
                MessageBox.Show("Please replace [Your Name] with your actual name in the message.",
                    "Template Not Customized", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Show loading screen
            LoadingForm loading = new LoadingForm();
            loading.Show();

            try
            {
                bool emailSent = false;
                await Task.Run(async () =>
                {
                    loading.UpdateProgress(10, "Preparing email...");

                    string recipients = string.Join(";", recipientsLstBx.Items.Cast<string>());
                    string coverLetterPath = null;

                    // Save cover letter to temp file if provided
                    if (!string.IsNullOrWhiteSpace(coverLetterTbx.Text) &&
                        coverLetterTbx.Text != coverLetterTbx.PlaceholderText)
                    {
                        coverLetterPath = Path.Combine(Path.GetTempPath(), "CoverLetter.txt");
                        File.WriteAllText(coverLetterPath, coverLetterTbx.Text);
                    }

                    loading.UpdateProgress(50, "Sending email...");

                    // Send email using database class
                    if (db.SendResumeEmail("scorch857@gmail.com", "Resume Builder App",
                        recipients, subjectTbx.Text, messageTbx.Text, resumePath, coverLetterPath))
                    {
                        // Track the sent resume
                        int userId = db.GetCurrentUserID(currentUsername);
                        db.TrackSentResume(userId, resumePath, recipients, subjectTbx.Text,
                            messageTbx.Text, !string.IsNullOrEmpty(coverLetterPath));

                        // Increment resumes sent count
                        db.IncrementResumesSent(userId);

                        loading.UpdateProgress(100, "Email sent successfully!");
                        emailSent = true;
                    }
                });

                if (emailSent)
                {
                    MessageBox.Show("Resume sent successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
            finally
            {
                loading.Close();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void PreFillRecipients(string recipients)
        {
            if (string.IsNullOrEmpty(recipients)) return;

            string[] emailList = recipients.Split(';');
            foreach (string email in emailList)
            {
                if (!string.IsNullOrWhiteSpace(email))
                {
                    recipientsLstBx.Items.Add(email.Trim());
                }
            }
        }

    }
} 