using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectOOP2
{
    public partial class MyResumes : UserControl
    {
        private string? currentUser;

        public string? Username
        {
            get { return currentUser; }
            set { currentUser = value; }
        }

        public MyResumes()
        {
            InitializeComponent();
            this.Refresh();
        }

        public void LoadUserResumes(string currentUsername)
        {
            var db = new ResumeDatabase();
            int ownerId = db.GetCurrentUserID(currentUsername);
            if (ownerId == 0)
            {
                MessageBox.Show("Could not find user.");
                return;
            }

            var resumes = db.GetAllResumesForUser(ownerId);

            dgvResumes.DataSource = resumes;
            if (dgvResumes.Columns["FilePath"] != null)
            {
                dgvResumes.Columns["FilePath"].Visible = false;
            }
        }

        private void createNewBtn_Click(object sender, EventArgs e)
        {
            var dashboard = this.FindForm() as Dashboard;
            if (dashboard != null)
            {
                dashboard.createResumeBtn_Click(sender, e);
            }
        }

        private void sendResumeBtn_Click(object sender, EventArgs e)
        {

        }

        private void exportResumeBtn_Click(object sender, EventArgs e)
        {

        }

        //private void sendResumeBtn_Click(object sender, EventArgs e)
        //{
        //    if (dgvResumes.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("Please select a resume to send.");
        //        return;
        //    }
        //    int resumeId = (int)dgvResumes.SelectedRows[0].Cells["ResumeID"].Value;
        //    string recipientEmail = Microsoft.VisualBasic.Interaction.InputBox("Enter recipient email:", "Send Resume", "");
        //    if (string.IsNullOrWhiteSpace(recipientEmail))
        //        return;
        //    var db = new ResumeDatabase();
        //    string filePath = db.GetResumeFilePath(resumeId); // Implement this
        //    if (string.IsNullOrEmpty(filePath) || !System.IO.File.Exists(filePath))
        //    {
        //        MessageBox.Show("Resume file not found. Please export the resume first.");
        //        return;
        //    }
        //    bool sent = EmailHelper.SendEmailWithAttachment(recipientEmail, "My Resume", "Please find my resume attached.", filePath); // Implement this
        //    MessageBox.Show(sent ? "Resume sent successfully!" : "Failed to send resume.");
        //}

        private void deleteResumeBtn_Click(object sender, EventArgs e)
        {
            if (dgvResumes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a resume to delete.");
                return;
            }
            int resumeId = (int)dgvResumes.SelectedRows[0].Cells["ResumeID"].Value;
            var confirm = MessageBox.Show("Are you sure you want to delete this resume?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var db = new ResumeDatabase();
                bool deleted = db.DeleteResume(resumeId); // Implement this

                if (currentUser != null && Username != null)
                {
                    int ownerID = db.GetCurrentUserID(currentUser);
                    MessageBox.Show(deleted ? "Resume deleted." : "Failed to delete resume.");
                    if (deleted)
                    {
                        LoadUserResumes(Username);
                        db.DecrementResumesCreatedAndSaved(ownerID);
                    }
                }
            }
        }

        private void dgvResumes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvResumes.Rows[e.RowIndex];
                var resumeSummary = row.DataBoundItem as ResumeSummary;
                if (resumeSummary == null) return;

                // Load the full resume data based on template type
                var db = new ResumeDatabase();
                object resumeData = null;
                string templateFileName = "";

                switch (resumeSummary.TemplateType)
                {
                    case "Attorney":
                        resumeData = db.LoadAttorneyResume(resumeSummary.ResumeID);
                        templateFileName = "AttorneyTemplate.html";
                        break;
                    case "Doctor":
                        resumeData = db.LoadDoctorResume(resumeSummary.ResumeID);
                        templateFileName = "DoctorTemplate.html";
                        break;
                    case "CallCenter":
                        resumeData = db.LoadCallCenterResume(resumeSummary.ResumeID);
                        templateFileName = "CallCenterTemplate.html";
                        break;
                    //case "ElectricalEngineering":
                    //    resumeData = db.LoadElectricalEngineeringResume(resumeSummary.ResumeID);
                    //    templateFileName = "ElectricalEngineeringTemplate.html";
                    //    break;
                    //// Add more cases as needed
                    default:
                        MessageBox.Show("Unknown template type.");
                        return;
                }

                // Show the preview form
                var previewForm = new ResumePreviewForm();
                previewForm.LoadResumePreview(resumeData, templateFileName);
                previewForm.ShowDialog();
            }
        }
    }

   public class ResumeSummary()
    {
        public int ResumeID { get; set; }
        public string? Title { get; set; }
        public DateTime DateCreated { get; set; }
        public string? FilePath { get; set; }
        public string? TemplateType { get; set; }
        public DateTime DateModified { get; set; }
    }
}
