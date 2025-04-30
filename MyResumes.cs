using static FinalProjectOOP2.ResumeDatabase; 

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

            if (dgvResumes.Columns["ResumeID"] != null)
            {
                dgvResumes.Columns["ResumeID"].Visible = false;
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
            MessageBox.Show("Not yet implemented");
        }


        private void exportResumeBtn_Click(object sender, EventArgs e)
        {
            if (dgvResumes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a resume to export.");
                return;
            }

            var selectedResume = dgvResumes.SelectedRows[0].DataBoundItem as ResumeSummary;
            if (selectedResume == null)
            {
                MessageBox.Show("Invalid resume selection.");
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.DefaultExt = "pdf";
                saveFileDialog.FileName = $"{selectedResume.Title}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var db = new ResumeDatabase();
                        int userId = db.GetCurrentUserID(currentUser);
                        var resumeData = db.LoadResume(selectedResume.ResumeID, selectedResume.TemplateType);
                        
                        if (resumeData != null && selectedResume.TemplateType != null)
                        {
                            var templateControl = CreateTemplateControl(selectedResume.TemplateType);

                            if (templateControl is IResumeExportable exportable)
                            {
                                exportable.ExportToPDF(saveFileDialog.FileName, selectedResume.ResumeID);
                                MessageBox.Show("Resume exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                db.IncrementResumesExported(userId); // userId = current user's ID
                            }
                            else
                            {
                                MessageBox.Show($"PDF export is not supported for this resume type. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Could not load resume data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting resume: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private UserControl CreateTemplateControl(string templateType)
        {
            return templateType switch
            {
                "CallCenter" => new CallCenterResume(),
                "ElectricalEngineering" => new ElectricalEngineeringTemplate(),
                "Doctor" => new DoctorResume(),
                "Attorney" => new AttorneyResume(),
                _ => throw new ArgumentException($"Unknown template type: {templateType}")
            };
        }

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
                    case "ElectricalEngineering":
                        resumeData = db.LoadEEResume(resumeSummary.ResumeID);
                        templateFileName = "ElectricalEngineeringTemplate.html";
                        break;
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
