using System.Data;
using static FinalProjectOOP2.ResumeDatabase;
using SelectPdf;

namespace FinalProjectOOP2
{
    public partial class CallCenterResume : UserControl, IResumeSaveable, IResumeExportable
    {
        public string? CurrentUsername { get; set; }
        private List<string> tempResponsibilities = new List<string>();
        private DataGridViewRow? selectedExpRow = null;
        private ResumeDatabase _db;

        public CallCenterResume()
        {
            InitializeComponent();
            _db = new ResumeDatabase();
        }


        public void PreviewResume()
        {
            var resumeData = GetResumeData();
            string templateFileName = "CallCenterTemplate.html"; // Adjust if needed

            ResumePreviewForm previewForm = new ResumePreviewForm();
            previewForm.LoadResumePreview(resumeData, templateFileName);
            previewForm.Show();
        }

        private bool ValidateInputs()
        {
            // Example: Check if personal info fields are not empty
            if (string.IsNullOrWhiteSpace(firstNameTbx.Text) ||
                string.IsNullOrWhiteSpace(lastNameTbx.Text) ||
                string.IsNullOrWhiteSpace(emailTbx.Text) ||
                string.IsNullOrWhiteSpace(phoneNumTbx.Text) ||
                string.IsNullOrWhiteSpace(addressTbx.Text) ||
                string.IsNullOrWhiteSpace(titleTbx.Text) ||
                string.IsNullOrWhiteSpace(summaryTbx.Text))
            {
                MessageBox.Show("Please fill in all personal information fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (coreSkillsLstBx.Items.Count == 0 ||
                techSkillsLstBx.Items.Count == 0 ||
                languageLstBx.Items.Count == 0 ||
                dgvEducation.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow) ||
                dgvProfExp.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                MessageBox.Show("Please add at least one entry for each section (skills, education, experience, etc.).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void dgvProfExp_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProfExp.SelectedRows.Count > 0 && !dgvProfExp.SelectedRows[0].IsNewRow)
            {
                selectedExpRow = dgvProfExp.SelectedRows[0];
            }

            warningResponsibilityLbl.Text = "";
            warningJobLbl.Text = "";
        }

        //For saving
        public bool SaveResume(string currentUsername, string resumeTitle)
        {
            if (!ValidateInputs())
                return false;
            try
            {
                var db = new ResumeDatabase();

                // Create PersonalInfo object
                var personalInfo = new PersonalInfo
                {
                    FirstName = firstNameTbx.Text,
                    MiddleName = middleNameTbx.Text,
                    LastName = lastNameTbx.Text,
                    Email = emailTbx.Text,
                    Phone = phoneNumTbx.Text,
                    Address = addressTbx.Text,
                    Title = titleTbx.Text,
                    Summary = summaryTbx.Text
                };

                // First save personal info using the existing method
                int personalInfoId = db.SavePersonalInfo(personalInfo, currentUsername);
                if (personalInfoId == 0) return false;

                // Get template-specific data from controls
                var coreSkills = GetListBoxItems(coreSkillsLstBx);
                var techSkills = GetListBoxItems(techSkillsLstBx);
                var languages = GetListBoxItems(languageLstBx);
                var education = GetEducationFromGrid(dgvEducation);
                var experience = GetExperienceFromGrid(dgvProfExp);

                // Save template-specific data
                return db.SaveCallCenterResume(_db.GetCurrentUserID(currentUsername), resumeTitle, coreSkills, techSkills, languages, education, experience);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving resume: {ex.Message}");
                return false;
            }
        }

        //For loading data
        public void LoadResume(ResumeSummary resumeSummary)
        {
            try
            {
                var db = new ResumeDatabase();
                var resumeModel = db.LoadCallCenterResume(resumeSummary.ResumeID);

                // Populate personal info
                firstNameTbx.Text = resumeModel.FirstName;
                middleNameTbx.Text = resumeModel.MiddleName;
                lastNameTbx.Text = resumeModel.LastName;
                emailTbx.Text = resumeModel.Email;
                phoneNumTbx.Text = resumeModel.Phone;
                addressTbx.Text = resumeModel.Address;
                titleTbx.Text = resumeModel.Title;
                summaryTbx.Text = resumeModel.Summary;

                // Populate core skills
                coreSkillsLstBx.Items.Clear();
                if (resumeModel.CoreSkills != null)
                {
                    foreach (var skill in resumeModel.CoreSkills)
                    {
                        coreSkillsLstBx.Items.Add(skill);
                    }
                }

                // Populate tech skills
                techSkillsLstBx.Items.Clear();
                if (resumeModel.TechSkills != null)
                {
                    foreach (var skill in resumeModel.TechSkills)
                    {
                        techSkillsLstBx.Items.Add(skill);
                    }
                }

                // Populate languages
                languageLstBx.Items.Clear();
                if (resumeModel.Languages != null)
                {
                    foreach (var lang in resumeModel.Languages)
                    {
                        languageLstBx.Items.Add(lang);
                    }
                }

                // Populate education
                dgvEducation.Rows.Clear();
                if (resumeModel.Education != null)
                {
                    foreach (var edu in resumeModel.Education)
                    {
                        dgvEducation.Rows.Add(
                            edu.Degree,
                            edu.School,
                            edu.Location,
                            edu.Year
                        );
                    }
                }

                // Populate experience
                dgvProfExp.Rows.Clear();
                if (resumeModel.Experience != null)
                {
                    foreach (var exp in resumeModel.Experience)
                    {
                        // Add experience row
                        int rowIndex = dgvProfExp.Rows.Add(
                            exp.Title,
                            exp.Company,
                            exp.Location,
                            exp.Duration,
                            exp.Achievement
                        );
                        var row = dgvProfExp.Rows[rowIndex];
                        // Add responsibilities to columns if they exist
                        if (exp.Responsibilities != null)
                        {
                            for (int i = 0; i < exp.Responsibilities.Count; i++)
                            {
                                string colName = $"Responsibility{i + 1}";
                                if (!dgvProfExp.Columns.Contains(colName))
                                {
                                    dgvProfExp.Columns.Add(colName, $"Responsibility {i + 1}");
                                }
                                row.Cells[colName].Value = exp.Responsibilities[i];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading resume: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportToPDF(string outputPath, int resumeId)
        {
            try
            {
                var db = new ResumeDatabase();

                var resumeData = db.LoadCallCenterResume(resumeId);

                string templatePath = Path.Combine(Application.StartupPath, "Templates", "CallCenterTemplate.html");
                string templateContent = File.ReadAllText(templatePath);

                var template = Scriban.Template.Parse(templateContent);
                string htmlContent = template.Render(resumeData, member => member.Name);

                var converter = new HtmlToPdf();
                var doc = converter.ConvertHtmlString(htmlContent);
                doc.Save(outputPath);
                doc.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region fetching data 
        public void LoadExistingPersonalInfo()
        {
            try
            {
                var db = new ResumeDatabase();
                string? username = this.CurrentUsername;
                if (!string.IsNullOrEmpty(username))
                {
                    int userId = db.GetCurrentUserID(username);
                    if (userId > 0)
                    {
                        var personalInfo = db.LoadPersonalInfo(userId);
                        if (personalInfo != null)
                        {
                            firstNameTbx.Text = personalInfo.FirstName ?? "";
                            middleNameTbx.Text = personalInfo.MiddleName ?? "";
                            lastNameTbx.Text = personalInfo.LastName ?? "";
                            emailTbx.Text = personalInfo.Email ?? "";
                            phoneNumTbx.Text = personalInfo.Phone ?? "";
                            addressTbx.Text = personalInfo.Address ?? "";
                            titleTbx.Text = personalInfo.Title ?? "";
                            summaryTbx.Text = personalInfo.Summary ?? "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading personal information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<string> GetListBoxItems(ListBox listBox)
        {
            return listBox.Items.Cast<string>().ToList();
        }

        public List<EducationItem> GetEducationFromGrid(DataGridView grid)
        {
            List<EducationItem> educationList = new List<EducationItem>();

            foreach (DataGridViewRow row in grid.Rows)
            {
                // Skip the new row placeholder
                if (row.IsNewRow) continue;

                educationList.Add(new EducationItem
                {
                    Degree = row.Cells["Degree"].Value?.ToString(),
                    School = row.Cells["School"].Value?.ToString(),
                    Location = row.Cells["Location_Educ"].Value?.ToString(),
                    Year = row.Cells["Year"].Value?.ToString()
                });
            }

            return educationList;
        }

        public List<ExperienceItem> GetExperienceFromGrid(DataGridView grid)
        {
            List<ExperienceItem> experienceList = new List<ExperienceItem>();

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow) continue;

                // Grab all responsibility cells
                List<string> responsibilities = new();
                foreach (DataGridViewColumn col in grid.Columns)
                {
                    if (col.Name.StartsWith("Responsibility"))
                    {
                        var value = row.Cells[col.Name].Value?.ToString();
                        if (!string.IsNullOrWhiteSpace(value))
                        {
                            responsibilities.Add(value);
                        }
                    }
                }

                experienceList.Add(new ExperienceItem
                {
                    Title = row.Cells["JobTitle"].Value?.ToString(),
                    Company = row.Cells["Company"].Value?.ToString(),
                    Location = row.Cells["Location"].Value?.ToString(),
                    Duration = row.Cells["Duration"].Value?.ToString(),
                    Achievement = row.Cells["Achievement"].Value?.ToString(),
                    Responsibilities = responsibilities
                });
            }

            return experienceList;
        }

        public CallCenterResumeModel GetResumeData()
        {
            return new CallCenterResumeModel
            {
                Name = $"{firstNameTbx.Text} {middleNameTbx.Text} {lastNameTbx.Text}".Trim(),
                Address = addressTbx.Text,
                Phone = phoneNumTbx.Text,
                Email = emailTbx.Text,
                Title = titleTbx.Text,
                Summary = summaryTbx.Text,
                CoreSkills = GetListBoxItems(coreSkillsLstBx),
                TechSkills = GetListBoxItems(techSkillsLstBx),
                Languages = GetListBoxItems(languageLstBx),
                Experience = GetExperienceFromGrid(dgvProfExp),
                Education = GetEducationFromGrid(dgvEducation)
            };
        }
        #endregion

        #region For cursor enter and leave methods to replace the placeholder text 

        private void HandleEnter(TextBox tbx, string placeholder)
        {
            if (tbx.Text == placeholder)
            {
                tbx.Text = "";
                tbx.ForeColor = Color.Black;
            }
        }

        private void HandleLeave(TextBox tbx, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(tbx.Text))
            {
                tbx.Text = placeholder;
                tbx.ForeColor = Color.Gray;
            }
        }

        private void coreSkillTbx_Enter(object sender, EventArgs e)
        {
            HandleEnter(coreSkillTbx, "Enter your skill");
        }

        private void coreSkillTbx_Leave(object sender, EventArgs e)
        {
            HandleLeave(coreSkillTbx, "Enter your skill");
        }

        private void techSkillTbx_Enter(object sender, EventArgs e)
        {
            HandleEnter(techSkillTbx, "Enter your skill");
        }

        private void techSkillTbx_Leave(object sender, EventArgs e)
        {
            HandleLeave(techSkillTbx, "Enter your skill");
        }
        #endregion

        #region Methods for add and remove 

        //Core Skills Section
        private void btnAddCoreSkill_Click(object sender, EventArgs e)
        {
            string skill = coreSkillTbx.Text;
            if (string.IsNullOrWhiteSpace(coreSkillTbx.Text) || skill == "Enter your skill")
            {
                MessageBox.Show("Please enter a core skill.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
               
            }
            if (!coreSkillsLstBx.Items.Contains(skill))
            {
                coreSkillsLstBx.Items.Add(coreSkillTbx.Text.Trim());
                coreSkillTbx.Clear();
            }
            else
            {
                MessageBox.Show("This core skill already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemoveCoreSkill_Click(object sender, EventArgs e)
        {
            if (coreSkillsLstBx.SelectedIndex != -1)
            {
                coreSkillsLstBx.Items.RemoveAt(coreSkillsLstBx.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Please select a core skill to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Tech Skill Section
        private void btnAddTechSkill_Click(object sender, EventArgs e)
        {
            string skill = techSkillTbx.Text;
            if (string.IsNullOrEmpty(techSkillTbx.Text) || skill == "Enter your skill")
            {
                MessageBox.Show("Please enter a Tech skill.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!techSkillsLstBx.Items.Contains(skill))
            {
                techSkillsLstBx.Items.Add(techSkillTbx.Text.Trim());
                techSkillTbx.Clear();
            }
            else
            {
                MessageBox.Show("This core skill already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemoveTechSkilln4_Click(object sender, EventArgs e)
        {
            if (techSkillsLstBx.SelectedIndex != -1)
            {
                techSkillsLstBx.Items.RemoveAt(techSkillsLstBx.SelectedIndex);
            }
            else
            {
                return; //do nothing if there's nothing selected
            }
        }

        //Language Section
        private void btnLangAdd_Click(object sender, EventArgs e)
        {
            string lang = languageTbx.Text;
            if (string.IsNullOrEmpty(lang))
            {
                MessageBox.Show("Please enter a language.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!languageLstBx.Items.Contains(lang))
            {
                languageLstBx.Items.Add(languageTbx.Text.Trim());
                languageTbx.Clear();
            }
            else
            {
                MessageBox.Show("This language is already in the list.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        

        private void btnLangRemove_Click(object sender, EventArgs e)
        {
            if (languageLstBx.SelectedIndex != -1)
            {
                languageLstBx.Items.RemoveAt(languageLstBx.SelectedIndex);
            }
            else
            {
                return; //do nothing if there's nothing selected
            }
        }
        #endregion

        #region Data Grid Sections

        //Education Section
        private void btnAddEduc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(degreeTbx.Text) ||
                string.IsNullOrWhiteSpace(schoolTbx.Text) ||
                string.IsNullOrWhiteSpace(locationTbx.Text) ||
                string.IsNullOrWhiteSpace(yearTbx.Text))
            {
                warningLbl.Text = "Please fill up necessary details!";
                warningLbl.ForeColor = Color.Red;
                warningLbl.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                return;
            }

            dgvEducation.Rows.Add(
              degreeTbx.Text.Trim(),
              schoolTbx.Text.Trim(),
              locationTbx.Text.Trim(),
              yearTbx.Text.Trim()
            );

            degreeTbx.Text = "";
            schoolTbx.Text = "";
            locationTbx.Text = "";
            yearTbx.Text = "";
        }

        private void btnRemoveEduc_Click(object sender, EventArgs e)
        {
            if (dgvEducation.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvEducation.SelectedRows)
                {
                    if (!row.IsNewRow)
                        dgvEducation.Rows.Remove(row);
                }
            }
            else
            {
                warningLbl.Text = "Please select a row to remove!";
                warningLbl.ForeColor = Color.Red;
                warningLbl.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            }
        }

        //Experience & Responbilities Section
        private void btnAddExp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(jobTitleTbx.Text) ||
                string.IsNullOrWhiteSpace(companyTbx.Text) ||
                string.IsNullOrWhiteSpace(locationExpTbx.Text) ||
                string.IsNullOrWhiteSpace(durationTbx.Text) ||
                string.IsNullOrWhiteSpace(achievementTbx.Text))
            {
                warningJobLbl.Text = "Please fill in all fields before adding experience.";
                warningJobLbl.ForeColor = Color.Red;
                warningJobLbl.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                return;
            }

            // 1. Ensure we have enough Responsibility columns
            for (int i = 0; i < tempResponsibilities.Count; i++)
            {
                string colName = $"Responsibility{i + 1}";
                if (!dgvProfExp.Columns.Contains(colName))
                {
                    dgvProfExp.Columns.Add(colName, $"Responsibility {i + 1}");
                }
            }

            List<object> rowValues = new()
            {
                jobTitleTbx.Text.Trim(),
                companyTbx.Text.Trim(),
                locationExpTbx.Text.Trim(),
                durationTbx.Text.Trim(),
                achievementTbx.Text.Trim()
            };

            rowValues.AddRange(tempResponsibilities);

            int expectedColumnCount = dgvProfExp.Columns.Count;
            while (rowValues.Count < expectedColumnCount)
            {
                rowValues.Add("");
            }

            dgvProfExp.Rows.Add(rowValues.ToArray());

            int newRowIdx = dgvProfExp.Rows.Count - 1;
            if (newRowIdx >= 0 && !dgvProfExp.Rows[newRowIdx].IsNewRow)
            {
                dgvProfExp.ClearSelection();
                dgvProfExp.Rows[newRowIdx].Selected = true;
                selectedExpRow = dgvProfExp.Rows[newRowIdx];
            }

            jobTitleTbx.Clear();
            companyTbx.Clear();
            locationExpTbx.Clear();
            durationTbx.Clear();
            achievementTbx.Clear();
            tempResponsibilities.Clear();
            warningJobLbl.Text = "";
        }

        private void btnRemoveExp_Click(object sender, EventArgs e)
        {
            if (dgvProfExp.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvProfExp.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        dgvProfExp.Rows.Remove(row);
                    }
                }

                // Optional: Clear selected row reference after deletion
                selectedExpRow = null;

                // Optional: Hide unused responsibility columns (if you've implemented that)
                // HideEmptyResponsibilityColumns();

                warningJobLbl.Text = ""; // Clear any warning
            }
            else
            {
                warningJobLbl.Text = "Please select an experience to remove!";
                warningJobLbl.ForeColor = Color.Red;
                warningJobLbl.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            }
        }

        //Responbilities
        private void addResponbilityBtn_Click(object sender, EventArgs e)
        {
            if (selectedExpRow == null || selectedExpRow.IsNewRow)
            {
                warningJobLbl.Text = "Please select a job entry to add responsibilities.";
                warningJobLbl.ForeColor = Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(responsibilityTbx.Text))
            {
                warningJobLbl.Text = "Responsibility field is empty!";
                warningJobLbl.ForeColor = Color.Red;
                return;
            }

            // 1. Find the next available Responsibility column
            int index = 1;
            string newColName;

            while (true)
            {
                newColName = $"Responsibility{index}";
                if (!dgvProfExp.Columns.Contains(newColName))
                {
                    dgvProfExp.Columns.Add(newColName, $"Responsibility {index}");
                }

                // If this cell is empty in the selected row, use it
                if (string.IsNullOrWhiteSpace(selectedExpRow.Cells[newColName].Value?.ToString()))
                {
                    selectedExpRow.Cells[newColName].Value = responsibilityTbx.Text.Trim();
                    break;
                }

                index++;
            }

            responsibilityTbx.Clear();
            warningResponsibilityLbl.Text = "";
        }

        private void removeResponsibilityBtn_Click(object sender, EventArgs e)
        {
            if (selectedExpRow == null)
            {
                warningResponsibilityLbl.Text = "Please select a job entry first.";
                warningResponsibilityLbl.ForeColor = Color.Red;
                return;
            }

            // Go through Responsibility columns in reverse to find the last non-empty one
            for (int i = dgvProfExp.Columns.Count - 1; i >= 0; i--)
            {
                DataGridViewColumn col = dgvProfExp.Columns[i];
                if (col.Name.StartsWith("Responsibility"))
                {
                    var cellValue = selectedExpRow.Cells[col.Name].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(cellValue))
                    {
                        selectedExpRow.Cells[col.Name].Value = "";
                        warningResponsibilityLbl.Text = ""; // Clear warning
                        return;
                    }
                }
            }

            warningResponsibilityLbl.Text = "No responsibilities to remove.";
            warningResponsibilityLbl.ForeColor = Color.Red;
            warningResponsibilityLbl.Font = new Font("Century Gothic", 10, FontStyle.Bold);
        }
        #endregion

        #region Template Specific Information seperated into classes (maybe kind of similar but is not)
        public class CallCenterResumeModel : PersonalInfo
        {
            public string? Name { get; set; }
            public List<string>? CoreSkills { get; set; }
            public List<string>? TechSkills { get; set; }
            public List<string>? Languages { get; set; }

            public List<ExperienceItem>? Experience { get; set; }
            public List<EducationItem>? Education { get; set; }
        }

        public class ExperienceItem
        {

            public string? Title { get; set; }
            public string? Company { get; set; }
            public string? Location { get; set; }
            public string? Duration { get; set; }
            public List<string>? Responsibilities { get; set; }
            public string? Achievement { get; set; }
        }

        public class EducationItem
        {
            public string? Degree { get; set; }
            public string? School { get; set; }
            public string? Location { get; set; }
            public string? Year { get; set; }
        }
        #endregion

        
    }
}