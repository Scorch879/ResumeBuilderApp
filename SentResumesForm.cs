using System.Data;
using System.Data.OleDb;

namespace FinalProjectOOP2
{
    public partial class SentResumesForm : Form
    {
        private string? currentUsername;
        private ResumeDatabase db;

        public SentResumesForm(string username)
        {
            InitializeComponent();
            currentUsername = username;
            db = new ResumeDatabase();
            LoadSentResumes();
        }

        private void LoadSentResumes()
        {
            try
            {
                int userId = db.GetCurrentUserID(currentUsername);
                DataTable dt = db.LoadSentResumes(userId);

                // Bind DataTable to DataGridView
                dgvSentResumes.DataSource = dt;

                // Configure columns
                dgvSentResumes.Columns["ID"].Visible = false;
                dgvSentResumes.Columns["ResumePath"].HeaderText = "Resume";
                dgvSentResumes.Columns["Recipients"].HeaderText = "Sent To";
                dgvSentResumes.Columns["Subject"].HeaderText = "Subject";
                dgvSentResumes.Columns["Message"].Visible = false;
                dgvSentResumes.Columns["HasCoverLetter"].HeaderText = "Cover Letter";
                dgvSentResumes.Columns["SentDate"].HeaderText = "Date Sent";

                // Format columns
                dgvSentResumes.Columns["SentDate"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dgvSentResumes.Columns["HasCoverLetter"].DefaultCellStyle.Format = "Yes;No;";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sent resumes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void viewDetailsBtn_Click(object sender, EventArgs e)
        {
            if (dgvSentResumes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a resume to view details.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvSentResumes.SelectedRows[0];
            string message = row.Cells["Message"].Value.ToString();
            string subject = row.Cells["Subject"].Value.ToString();
            string recipients = row.Cells["Recipients"].Value.ToString();
            DateTime sentDate = Convert.ToDateTime(row.Cells["SentDate"].Value);
            bool hasCoverLetter = Convert.ToBoolean(row.Cells["HasCoverLetter"].Value);

            string details = $"Sent Date: {sentDate:MM/dd/yyyy HH:mm}\n\n" +
                           $"To: {recipients}\n\n" +
                           $"Subject: {subject}\n\n" +
                           $"Message:\n{message}\n\n" +
                           $"Cover Letter Included: {(hasCoverLetter ? "Yes" : "No")}";

            MessageBox.Show(details, "Email Details", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void resendBtn_Click(object sender, EventArgs e)
        {
            if (dgvSentResumes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a resume to resend.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvSentResumes.SelectedRows[0];
            string resumePath = row.Cells["ResumePath"].Value.ToString();

            if (!File.Exists(resumePath))
            {
                MessageBox.Show("The resume file could not be found. It may have been moved or deleted.",
                    "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SendResumeForm sendForm = new SendResumeForm(resumePath, currentUsername))
            {
                // Pre-fill the form with the previous recipients
                sendForm.PreFillRecipients(row.Cells["Recipients"].Value.ToString());
                sendForm.ShowDialog();
            }

            // Refresh the grid after sending
            LoadSentResumes();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (dgvSentResumes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dgvSentResumes.SelectedRows[0].Cells["ID"].Value);
                    if (db.DeleteSentResume(id))
                    {
                        LoadSentResumes(); // Refresh the grid
                        MessageBox.Show("Record deleted successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete record.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting record: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoadSentResumes();
        }
    }
} 