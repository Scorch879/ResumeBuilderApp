using SelectPdf;
using static FinalProjectOOP2.ResumeDatabase; 

namespace FinalProjectOOP2
{
    public partial class MyResumes : UserControl
    {
        private string? currentUser;
        private List<ResumeSummary> allResumes = new List<ResumeSummary>();

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

        private void FilterResumesInGrid()
        {
            var currentList = allResumes; // Always filter from the full list!
            if (currentList == null) return;

            string searchText = searchTbx.Text.Trim();
            if (string.Equals(searchText, "Search by Name", StringComparison.OrdinalIgnoreCase))
                searchText = "";
            searchText = searchText.ToLower();

            string? selectedTemplate = templateSelector.SelectedItem?.ToString();

            var filtered = currentList.Where(resume =>
                (string.IsNullOrEmpty(searchText) || (resume.Title != null && resume.Title.ToLower().Contains(searchText))) &&
                (string.IsNullOrEmpty(selectedTemplate) || selectedTemplate == "All" || resume.TemplateType == selectedTemplate)
            ).ToList();

            dgvResumes.DataSource = null;
            dgvResumes.DataSource = filtered;

            if (dgvResumes.Columns["FilePath"] != null)
                dgvResumes.Columns["FilePath"].Visible = false;
            if (dgvResumes.Columns["ResumeID"] != null)
                dgvResumes.Columns["ResumeID"].Visible = false;
        }

        private void searchTbx_TextChanged(object sender, EventArgs e)
        {
            FilterResumesInGrid();
        }

        private void templateSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterResumesInGrid();
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

            allResumes = db.GetAllResumesForUser(ownerId);
            dgvResumes.DataSource = allResumes;
            dgvResumes.Columns["FilePath"].Visible = false;
            dgvResumes.Columns["ResumeID"].Visible = false;
        }


        #region Button Event Handlers

        private void clearFiltersBtn_Click(object sender, EventArgs e)
        {
            searchTbx.Text = "";
            templateSelector.SelectedIndex = 0; // Assuming 'All' is at index 0
            FilterResumesInGrid();
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
            if (dgvResumes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a resume to send.", "No Resume Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedResume = dgvResumes.SelectedRows[0].DataBoundItem as ResumeSummary;
            if (selectedResume == null)
            {
                MessageBox.Show("Invalid resume selection.");
                return;
            }

            // First export the resume to a temporary PDF file
            string tempPdfPath = Path.Combine(Path.GetTempPath(), $"{selectedResume.Title}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

            try
            {
                var db = new ResumeDatabase();
                int userId = db.GetCurrentUserID(currentUser);
                var resumeData = db.LoadResume(selectedResume.ResumeID, selectedResume.TemplateType);

                if (resumeData != null && selectedResume.TemplateType != null)
                {
                    var templateControl = CreateTemplateControl(selectedResume.TemplateType);
                    if (templateControl != null)
                    {
                        if (templateControl is IResumeExportable exportable)
                        {
                            exportable.ExportToPDF(tempPdfPath, selectedResume.ResumeID);

                            // Show the send resume form
                            using (SendResumeForm sendForm = new SendResumeForm(tempPdfPath, currentUser))
                            {
                                if (sendForm.ShowDialog() == DialogResult.OK)
                                {
                                    // Refresh the grid to show updated sent count
                                    LoadUserResumes(currentUser);

                                    // Update analytics display if we're in the Dashboard
                                    var dashboard = this.FindForm() as Dashboard;
                                    if (dashboard?.Home != null)
                                    {
                                        dashboard.Home.UpdateAnalyticsLabels(currentUser);
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("This resume template does not support PDF export.", "Export Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error preparing resume for sending: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Clean up the temporary file after sending
                try
                {
                    if (File.Exists(tempPdfPath))
                    {
                        File.Delete(tempPdfPath);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting temporary file: {ex.Message}");
                }
            }
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

        #endregion


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
