using System.Data;
using static FinalProjectOOP2.ResumeDatabase;
using SelectPdf;

namespace FinalProjectOOP2
{
    public partial class ElectricalEngineeringTemplate : UserControl, IResumeSaveable, IResumeExportable
    {
        public string? CurrentUsername { get; set; }
        private List<string> tempResponsibilities = new List<string>();
        private DataGridViewRow? selectedExpRow = null;
        private DataGridViewRow? selectedTechRow;
        private ResumeDatabase? dbHelper;
        private byte[]? selectedProfilePicBytes = null;

        public ElectricalEngineeringTemplate()
        {
            InitializeComponent();
            chooseImgBtn.Click += chooseImgBtn_Click;
        }

        public void PreviewResume()
        {
            var resumeData = GetResumeData();
            string templateFileName = "ElectricalEngineeringTemplate.html";

            ResumePreviewForm previewForm = new ResumePreviewForm();
            previewForm.LoadResumePreview(resumeData, templateFileName);
            previewForm.Show();
        }

        private bool ValidateInputs()
        {
            // 1. Check personal info fields
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

            // 2. Check at least one entry for each required section
            if (coreSkillsLstBx.Items.Count == 0)
            {
                MessageBox.Show("Please add at least one Core Skill.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (techSkillsLstBx.Items.Count == 0)
            {
                MessageBox.Show("Please add at least one Technical Skill.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dgvTechExpertise.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                MessageBox.Show("Please add at least one Technical Expertise entry.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dgvProfExp.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                MessageBox.Show("Please add at least one Experience entry.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dgvEducation.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                MessageBox.Show("Please add at least one Education entry.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // You can add more detailed checks for each section if needed

            return true;
        }

        //Export Operation 
        public void ExportToPDF(string outputPath, int resumeId)
        {
            try
            {
                // Load the resume data from the database
                var db = new ResumeDatabase();
                var resumeData = db.LoadEEResume(resumeId);

                // Load the HTML template
                string templatePath = Path.Combine(Application.StartupPath, "Templates", "ElectricalEngineeringTemplate.html");
                string templateContent = File.ReadAllText(templatePath);

                // Create template data dictionary
                var templateData = new Dictionary<string, object>();

                // Copy all properties from resumeData to templateData
                foreach (var prop in resumeData.GetType().GetProperties())
                {
                    if (prop.Name == "ProfilePic" && prop.GetValue(resumeData) is byte[] profilePicBytes)
                    {
                        // Convert profile picture to base64
                        string mimeType = GetImageMimeType(profilePicBytes);
                        string base64Image = Convert.ToBase64String(profilePicBytes);
                        templateData["ProfilePicPath"] = $"data:{mimeType};base64,{base64Image}";
                    }
                    else if (prop.Name != "FirstName" && prop.Name != "MiddleName" && prop.Name != "LastName")
                    {
                        var value = prop.GetValue(resumeData);
                        if (value != null)
                        {
                            templateData[prop.Name] = value;
                        }
                    }
                }

                // If no profile picture was set, use a default image
                if (!templateData.ContainsKey("ProfilePicPath"))
                {
                    templateData["ProfilePicPath"] = "Assets/default-profile.png";
                }

                // Parse and render with Scriban
                var template = Scriban.Template.Parse(templateContent);
                string htmlContent = template.Render(templateData);

                // Convert HTML to PDF
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

        private string GetImageMimeType(byte[] imageBytes)
        {
            // Check the first few bytes to determine the image type
            if (imageBytes.Length >= 2)
            {
                if (imageBytes[0] == 0xFF && imageBytes[1] == 0xD8)
                    return "image/jpeg";
                if (imageBytes[0] == 0x89 && imageBytes[1] == 0x50)
                    return "image/png";
                if (imageBytes[0] == 0x47 && imageBytes[1] == 0x49)
                    return "image/gif";
            }
            return "image/jpeg"; // Default to JPEG if unknown
        }
       

        //FOr saving
        public bool SaveResume(string currentUsername, string resumeTitle)
        {
            if (!ValidateInputs())
                return false;

            try
            {
                dbHelper = new ResumeDatabase();

                // 1. Get the owner/user ID from the username
                int ownerId = dbHelper.GetCurrentUserID(currentUsername);
                if (ownerId == -1)
                {
                    MessageBox.Show("User not found.");
                    return false;
                }

                // 2. Gather all data from the form/model
                var resumeData = GetResumeData();
                resumeData.ProfilePic = selectedProfilePicBytes;

                // 3. Flatten technical expertise for DB
                var expertise = new List<(string Category, string Skill)>();
                if (resumeData.TechnicalExpertise != null)
                {
                    if (resumeData.TechnicalExpertise.PLCs != null)
                        expertise.AddRange(resumeData.TechnicalExpertise.PLCs.Select(skill => ("PLC", skill)));
                    if (resumeData.TechnicalExpertise.DesignSkills != null)
                        expertise.AddRange(resumeData.TechnicalExpertise.DesignSkills.Select(skill => ("Design", skill)));
                    if (resumeData.TechnicalExpertise.Methodologies != null)
                        expertise.AddRange(resumeData.TechnicalExpertise.Methodologies.Select(skill => ("Methodology", skill)));
                    if (resumeData.TechnicalExpertise.ProductionSkills != null)
                        expertise.AddRange(resumeData.TechnicalExpertise.ProductionSkills.Select(skill => ("Production", skill)));
                }

                // 4. Save to database
                return dbHelper.SaveElectricalEngineeringResume(
                    ownerId,
                    resumeTitle,
                    resumeData.CoreSkills ?? new List<string>(),
                    resumeData.TechSkills ?? new List<string>(),
                    expertise,
                    resumeData.Experience ?? new List<EEExperienceItem>(),
                    resumeData.Education ?? new List<EEEducationItem>(),
                    resumeData.ProfessionalDevelopment ?? new List<string>()
                );

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving resume: " + ex.Message);
                return false;
            }
        }

        //For Loading
        public void LoadResume(ResumeSummary resumeSummary)
        {
            try
            {
                var db = new ResumeDatabase();
                var resumeModel = db.LoadEEResume(resumeSummary.ResumeID);

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

                // Populate professional development
                developmentLstBx.Items.Clear();
                if (resumeModel.ProfessionalDevelopment != null)
                {
                    foreach (var dev in resumeModel.ProfessionalDevelopment)
                    {
                        developmentLstBx.Items.Add(dev);
                    }
                }

                // Populate technical expertise
                dgvTechExpertise.Rows.Clear();
                if (resumeModel.TechnicalExpertise != null)
                {
                    int maxRows = new[]
                    {
                        resumeModel.TechnicalExpertise.PLCs?.Count ?? 0,
                        resumeModel.TechnicalExpertise.DesignSkills?.Count ?? 0,
                        resumeModel.TechnicalExpertise.Methodologies?.Count ?? 0,
                        resumeModel.TechnicalExpertise.ProductionSkills?.Count ?? 0
                    }.Max();
                    for (int i = 0; i < maxRows; i++)
                    {
                        dgvTechExpertise.Rows.Add(
                            resumeModel.TechnicalExpertise.PLCs != null && i < resumeModel.TechnicalExpertise.PLCs.Count ? resumeModel.TechnicalExpertise.PLCs[i] : "",
                            resumeModel.TechnicalExpertise.DesignSkills != null && i < resumeModel.TechnicalExpertise.DesignSkills.Count ? resumeModel.TechnicalExpertise.DesignSkills[i] : "",
                            resumeModel.TechnicalExpertise.Methodologies != null && i < resumeModel.TechnicalExpertise.Methodologies.Count ? resumeModel.TechnicalExpertise.Methodologies[i] : "",
                            resumeModel.TechnicalExpertise.ProductionSkills != null && i < resumeModel.TechnicalExpertise.ProductionSkills.Count ? resumeModel.TechnicalExpertise.ProductionSkills[i] : ""
                        );
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
                        int rowIndex = dgvProfExp.Rows.Add(
                            exp.Position,
                            exp.Company,
                            exp.Location,
                            exp.Duration,
                            exp.Achievement
                        );
                        var row = dgvProfExp.Rows[rowIndex];
                        // Add contributions to columns if they exist
                        if (exp.Contributions != null)
                        {
                            for (int i = 0; i < exp.Contributions.Count; i++)
                            {
                                string colName = $"Contribution{i + 1}";
                                if (!dgvProfExp.Columns.Contains(colName))
                                {
                                    dgvProfExp.Columns.Add(colName, $"Contribution {i + 1}");
                                }
                                row.Cells[colName].Value = exp.Contributions[i];
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
                            if (personalInfo.ProfilePic != null)
                            {
                                using (var ms = new System.IO.MemoryStream(personalInfo.ProfilePic))
                                {
                                    var img = Image.FromStream(ms);
                                    imageNameTbx.Text = "Image Loaded";
                                    imageNameTbx.BackColor = Color.LightGreen;
                                    selectedProfilePicBytes = personalInfo.ProfilePic;
                                }
                            }
                            else
                            {
                                imageNameTbx.Text = "No Image";
                                imageNameTbx.BackColor = Color.White;
                                selectedProfilePicBytes = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading personal information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Selection changed handlers
        private void dgvProfExp_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProfExp.SelectedRows.Count > 0 && !dgvProfExp.SelectedRows[0].IsNewRow)
            {
                selectedExpRow = dgvProfExp.SelectedRows[0];
            }
        }

        private void dgvTechnicalExpertise_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTechExpertise.SelectedRows.Count > 0 && !dgvTechExpertise.SelectedRows[0].IsNewRow)
            {
                selectedTechRow = dgvTechExpertise.SelectedRows[0];
            }
        }

      

        #region fetching data from data grid methods
        public List<EEEducationItem> GetEducationFromGrid(DataGridView grid)
        {
            List<EEEducationItem> educationList = new List<EEEducationItem>();

            foreach (DataGridViewRow row in grid.Rows)
            {
                // Skip the new row placeholder
                if (row.IsNewRow) continue;

                educationList.Add(new EEEducationItem
                {
                    Degree = row.Cells["Degree"].Value?.ToString(),
                    School = row.Cells["School"].Value?.ToString(),
                    Location = row.Cells["Location_Educ"].Value?.ToString(),
                    Year = row.Cells["Year"].Value?.ToString()
                });
            }

            return educationList;
        }

        public List<EEExperienceItem> GetExperienceFromGrid(DataGridView grid)
        {
            List<EEExperienceItem> experienceList = new List<EEExperienceItem>();

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow) continue;

                // Grab all responsibility and contribution cells
                List<string> contributions = new();
                foreach (DataGridViewColumn col in grid.Columns)
                {
                    if (col.Name.StartsWith("Responsibility") || col.Name.StartsWith("Contribution"))
                    {
                        string? value = row.Cells[col.Name].Value?.ToString();
                        if (!string.IsNullOrWhiteSpace(value))
                        {
                            contributions.Add(value);
                        }
                    }
                }

                experienceList.Add(new EEExperienceItem
                {
                    Position = row.Cells["JobTitle"].Value?.ToString(),
                    Company = row.Cells["Company"].Value?.ToString(),
                    Location = row.Cells["Location"].Value?.ToString(),
                    Duration = row.Cells["Duration"].Value?.ToString(),
                    Achievement = row.Cells["Achievement"].Value?.ToString(),
                    Contributions = contributions
                });
            }

            return experienceList;
        }

        public TechExpertise GetTechExpertiseFromGrid(DataGridView grid)
        {
            var tech = new TechExpertise
            {
                PLCs = new List<string>(),
                DesignSkills = new List<string>(),
                Methodologies = new List<string>(),
                ProductionSkills = new List<string>()
            };

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow) continue;

                // Check and add non-empty cells
                string? plc = row.Cells["PLCs"]?.Value?.ToString();
                if (!string.IsNullOrWhiteSpace(plc))
                    tech.PLCs.Add(plc);

                string? design = row.Cells["DesignSkills"]?.Value?.ToString();
                if (!string.IsNullOrWhiteSpace(design))
                    tech.DesignSkills.Add(design);

                string? method = row.Cells["Methodologies"]?.Value?.ToString();
                if (!string.IsNullOrWhiteSpace(method))
                    tech.Methodologies.Add(method);

                string? production = row.Cells["ProductionSkills"]?.Value?.ToString();
                if (!string.IsNullOrWhiteSpace(production))
                    tech.ProductionSkills.Add(production);
            }

            return tech;

        }

        #endregion

        private List<string> GetListBoxItems(ListBox listBox)
        {
            return listBox.Items.Cast<string>().ToList();
        }

        public ElectricalEngineeringResumeModel GetResumeData()
        {
            return new ElectricalEngineeringResumeModel
            {
                Name = $"{firstNameTbx.Text} {middleNameTbx.Text} {lastNameTbx.Text}".Trim(),
                Address = addressTbx.Text,
                Phone = phoneNumTbx.Text,
                Email = emailTbx.Text,
                Title = titleTbx.Text,
                Summary = summaryTbx.Text,
                CoreSkills = GetListBoxItems(coreSkillsLstBx),
                TechSkills = GetListBoxItems(techSkillsLstBx),
                TechnicalExpertise = GetTechExpertiseFromGrid(dgvTechExpertise),
                Experience = GetExperienceFromGrid(dgvProfExp),
                Education = GetEducationFromGrid(dgvEducation),
                ProfessionalDevelopment = GetListBoxItems(developmentLstBx),
                ProfilePic = selectedProfilePicBytes
            };
        }

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


        #region Buttons for add / remove (except for tabs with data grid view)
        //Skills
        private void btnAddCoreSkill_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(coreSkillTbx.Text))
            {
                coreSkillsLstBx.Items.Add(coreSkillTbx.Text.Trim());
                coreSkillTbx.Clear();
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
                return; //do nothing if there's nothing selected
            }
        }

        private void btnAddTechSkill_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(techSkillTbx.Text))
            {
                techSkillsLstBx.Items.Add(techSkillTbx.Text.Trim());
                techSkillTbx.Clear();
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


        //Development Section
        private void addDevelopmentBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(developmentTbx.Text))
            {
                developmentLstBx.Items.Add(developmentTbx.Text.Trim());
                developmentTbx.Clear();
            }
        }

        private void removeDevelopmentBtn_Click(object sender, EventArgs e)
        {
            if (developmentLstBx.SelectedIndex != -1)
            {
                developmentLstBx.Items.RemoveAt(developmentLstBx.SelectedIndex);
            }
            else
            {
                return; //do nothing if there's nothing selected
            }
        }

        #endregion


        #region data grid view button controls
        //Expertise
        private void addExpertiseBtn_Click(object sender, EventArgs e)
        {
            string? expertiseType = expertiseComboBx.SelectedItem?.ToString();
            string detail = expertiseDetailsTbx.Text.Trim();

            if (string.IsNullOrEmpty(expertiseType) || string.IsNullOrEmpty(detail))
            {
                MessageBox.Show("Please select an expertise type and enter details.");
                return;
            }

            string actualColumnName = expertiseType switch
            {
                "PLC" => "PLCs",
                "Design" => "DesignSkills",
                "Methodologies" => "Methodologies",
                "Production" => "ProductionSkills",
                _ => expertiseType
            };

            if (!dgvTechExpertise.Columns.Contains(actualColumnName))
            {
                MessageBox.Show("Invalid expertise type selected.");
                return;
            }

            // Try to find an existing row with that column empty
            bool filled = false;
            foreach (DataGridViewRow row in dgvTechExpertise.Rows)
            {
                // Skip new row placeholder
                if (row.IsNewRow) continue;

                if (row.Cells[actualColumnName].Value == null || string.IsNullOrWhiteSpace(row.Cells[actualColumnName].Value.ToString()))
                {
                    row.Cells[actualColumnName].Value = detail;
                    filled = true;

                    // Visually scroll to it
                    dgvTechExpertise.ClearSelection();
                    row.Selected = true;
                    dgvTechExpertise.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }

            // If all existing rows are filled in that column, add a new row
            if (!filled)
            {
                int newRowIndex = dgvTechExpertise.Rows.Add();
                DataGridViewRow newRow = dgvTechExpertise.Rows[newRowIndex];
                newRow.Cells[actualColumnName].Value = detail;

                dgvTechExpertise.ClearSelection();
                newRow.Selected = true;
                dgvTechExpertise.FirstDisplayedScrollingRowIndex = newRow.Index;
            }

            // Clear input
            expertiseDetailsTbx.Clear();
            warningTechLbl.Text = "";
        }

        private void removeExpertiseBtn_Click(object sender, EventArgs e)
        {
            if (dgvTechExpertise.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select one or more cells to clear.");
                return;
            }

            // Clear selected cells
            foreach (DataGridViewRow row in dgvTechExpertise.SelectedRows)
            {
                bool isEmpty = true;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        isEmpty = false;
                        break;
                    }
                }

                if (isEmpty)
                {
                    dgvTechExpertise.Rows.Remove(row);
                }
                else
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Value = null;
                    }
                }
            }

            // Clean up rows that are now completely empty (go in reverse to avoid index issues)
            for (int i = dgvTechExpertise.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dgvTechExpertise.Rows[i];

                if (row.IsNewRow) continue;

                bool isEmpty = true;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        isEmpty = false;
                        break;
                    }
                }

                if (isEmpty)
                {
                    dgvTechExpertise.Rows.RemoveAt(i);
                }
            }

            dgvTechExpertise.ClearSelection();
        }


        //Experience
        private void btnAddExp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(jobTitleTbx.Text) ||
                string.IsNullOrWhiteSpace(companyTbx.Text) ||
                string.IsNullOrWhiteSpace(locationExpTbx.Text) ||
                string.IsNullOrWhiteSpace(durationTbx.Text) ||
                string.IsNullOrWhiteSpace(achievementTbx.Text))
            {
                warning1EEProfExp.Text = "Please fill in all fields before adding experience.";
                warning1EEProfExp.ForeColor = Color.Red;
                warning1EEProfExp.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                return;
            }

            // Add new row with job info
            int rowIndex = dgvProfExp.Rows.Add();
            DataGridViewRow newRow = dgvProfExp.Rows[rowIndex];

            newRow.Cells["JobTitle"].Value = jobTitleTbx.Text.Trim();
            newRow.Cells["Company"].Value = companyTbx.Text.Trim();
            newRow.Cells["Location"].Value = locationExpTbx.Text.Trim();
            newRow.Cells["Duration"].Value = durationTbx.Text.Trim();
            newRow.Cells["Achievement"].Value = achievementTbx.Text.Trim();

            // Add enough Responsibility columns if needed
            for (int i = 0; i < tempResponsibilities.Count; i++)
            {
                string colName = $"Responsibility{i + 1}";
                if (!dgvProfExp.Columns.Contains(colName))
                {
                    dgvProfExp.Columns.Add(colName, $"Responsibility {i + 1}");
                }

                // Optionally populate responsibilities directly if you want:
                // newRow.Cells[colName].Value = tempResponsibilities[i];
            }

            // Reset fields
            jobTitleTbx.Clear();
            companyTbx.Clear();
            locationExpTbx.Clear();
            durationTbx.Clear();
            achievementTbx.Clear();
            warning1EEProfExp.Text = "";
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


                warning1EEProfExp.Text = ""; // Clear any warning
            }
            else
            {
                warning1EEProfExp.Text = "Please select an experience to remove!";
                warning1EEProfExp.ForeColor = Color.Red;
                warning1EEProfExp.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            }
        }


        //Contributions
        private void addResponbilityBtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedExpRow = dgvProfExp.CurrentRow;

            if (selectedExpRow == null || selectedExpRow.IsNewRow)
            {
                warning1EEProfExp.Text = "Please select a job entry to add responsibilities.";
                warning1EEProfExp.ForeColor = Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(responsibilityTbx.Text))
            {
                warning1EEProfExp.Text = "Responsibility field is empty!";
                warning1EEProfExp.ForeColor = Color.Red;
                return;
            }

            int index = 1;
            string newColName;

            while (true)
            {
                newColName = $"Contribution{index}";
                if (!dgvProfExp.Columns.Contains(newColName))
                {
                    dgvProfExp.Columns.Add(newColName, $"Contribution {index}");
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
            warning1EEProfExp.Text = "";
        }

        private void removeResponsibilityBtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedExpRow = dgvProfExp.CurrentRow;

            if (selectedExpRow == null)
            {
                warnning2EERespo.Text = "Please select a job entry first.";
                warnning2EERespo.ForeColor = Color.Red;
                return;
            }

            if (selectedExpRow != null)
            {
                for (int i = dgvProfExp.Columns.Count - 1; i >= 0; i--)
                {
                    DataGridViewColumn col = dgvProfExp.Columns[i];
                    if (col.Name.StartsWith("Contribution") &&
                        selectedExpRow.Cells[col.Name].Value != null &&
                        !string.IsNullOrWhiteSpace(selectedExpRow.Cells[col.Name].Value.ToString()))
                    {
                        selectedExpRow.Cells[col.Name].Value = null;
                        warnning2EERespo.Text = "";
                        return;
                    }
                }

                warnning2EERespo.Text = "No Contribution to remove.";
            }

            warnning2EERespo.Text = "No Contribution to remove.";
            warnning2EERespo.ForeColor = Color.Red;
            warnning2EERespo.Font = new Font("Century Gothic", 10, FontStyle.Bold);
        }


        //Education
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

#endregion

        public void ExportToPDF(string outputPath)
        {
            try
            {
                // Get the resume data
                var resumeData = GetResumeData();

                // Load the HTML template
                string templatePath = Path.Combine(Application.StartupPath, "Templates", "ElectricalEngineeringTemplate.html");
                string htmlContent = File.ReadAllText(templatePath);

                // Replace placeholders with actual data
                htmlContent = htmlContent.Replace("{{Name}}", resumeData.Name ?? "")
                                       .Replace("{{Address}}", resumeData.Address ?? "")
                                       .Replace("{{Phone}}", resumeData.Phone ?? "")
                                       .Replace("{{Email}}", resumeData.Email ?? "")
                                       .Replace("{{Title}}", resumeData.Title ?? "")
                                       .Replace("{{Summary}}", resumeData.Summary ?? "");

                // Replace Core Skills
                string coreSkillsHtml = resumeData.CoreSkills != null ? 
                    string.Join("<br>", resumeData.CoreSkills.Select(s => $"• {s}")) : "";
                htmlContent = htmlContent.Replace("{{CoreSkills}}", coreSkillsHtml);

                // Replace Tech Skills
                string techSkillsHtml = resumeData.TechSkills != null ? 
                    string.Join("<br>", resumeData.TechSkills.Select(s => $"• {s}")) : "";
                htmlContent = htmlContent.Replace("{{TechSkills}}", techSkillsHtml);

                // Replace Professional Development
                string developmentHtml = resumeData.ProfessionalDevelopment != null ? 
                    string.Join("<br>", resumeData.ProfessionalDevelopment.Select(s => $"• {s}")) : "";
                htmlContent = htmlContent.Replace("{{ProfessionalDevelopment}}", developmentHtml);

                // Replace Technical Expertise
                if (resumeData.TechnicalExpertise != null)
                {
                    string plcsHtml = resumeData.TechnicalExpertise.PLCs != null ? 
                        string.Join("<br>", resumeData.TechnicalExpertise.PLCs.Select(s => $"• {s}")) : "";
                    string designHtml = resumeData.TechnicalExpertise.DesignSkills != null ? 
                        string.Join("<br>", resumeData.TechnicalExpertise.DesignSkills.Select(s => $"• {s}")) : "";
                    string methodsHtml = resumeData.TechnicalExpertise.Methodologies != null ? 
                        string.Join("<br>", resumeData.TechnicalExpertise.Methodologies.Select(s => $"• {s}")) : "";
                    string productionHtml = resumeData.TechnicalExpertise.ProductionSkills != null ? 
                        string.Join("<br>", resumeData.TechnicalExpertise.ProductionSkills.Select(s => $"• {s}")) : "";

                    htmlContent = htmlContent.Replace("{{PLCs}}", plcsHtml)
                                           .Replace("{{DesignSkills}}", designHtml)
                                           .Replace("{{Methodologies}}", methodsHtml)
                                           .Replace("{{ProductionSkills}}", productionHtml);
                }

                // Replace Education
                string educationHtml = "";
                if (resumeData.Education != null)
                {
                    foreach (var edu in resumeData.Education)
                    {
                        educationHtml += $@"
                            <div class='education-item'>
                                <strong>{edu.Degree}</strong><br>
                                {edu.School}<br>
                                {edu.Location} | {edu.Year}
                            </div>";
                    }
                }
                htmlContent = htmlContent.Replace("{{Education}}", educationHtml);

                // Replace Experience
                string experienceHtml = "";
                if (resumeData.Experience != null)
                {
                    foreach (var exp in resumeData.Experience)
                    {
                        string contributionsHtml = "";
                        if (exp.Contributions != null)
                        {
                            contributionsHtml = string.Join("<br>", exp.Contributions.Select(c => $"• {c}"));
                        }

                        experienceHtml += $@"
                            <div class='experience-item'>
                                <strong>{exp.Position}</strong><br>
                                {exp.Company} | {exp.Location} | {exp.Duration}<br>
                                {exp.Achievement}<br>
                                {contributionsHtml}
                            </div>";
                    }
                }
                htmlContent = htmlContent.Replace("{{Experience}}", experienceHtml);

                // Convert HTML to PDF using Select.HtmlToPdf
                var converter = new HtmlToPdf();
                var doc = converter.ConvertHtmlString(htmlContent);
                doc.Save(outputPath);
                doc.Close();

                MessageBox.Show("Resume exported to PDF successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.DefaultExt = "pdf";
                saveFileDialog.FileName = $"ElectricalEngineeringResume_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToPDF(saveFileDialog.FileName);
                }
            }
        }

        private void chooseImgBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedProfilePicBytes = System.IO.File.ReadAllBytes(ofd.FileName);
                    imageNameTbx.Text = System.IO.Path.GetFileName(ofd.FileName);
                    imageNameTbx.BackColor = Color.LightGreen;
                }
            }
        }
    }

    public class ElectricalEngineeringResumeModel : PersonalInfo
    {
        public string? Name { get; set; }
        public List<string>? CoreSkills { get; set; }
        public List<string>? TechSkills { get; set; }
        public List<string>? ProfessionalDevelopment { get; set; }

        public TechExpertise? TechnicalExpertise { get; set; }

        public List<EEExperienceItem>? Experience { get; set; }
        public List<EEEducationItem>? Education { get; set; }

    }

    public class TechExpertise
    {
        public List<string>? PLCs { get; set; } 
        public List<string>? DesignSkills { get; set; } 
        public List<string>? Methodologies { get; set; } 
        public List<string>? ProductionSkills { get; set; } 
    }

    public class EEEducationItem
    {
        public string? Degree { get; set; }
        public string? School { get; set; }
        public string? Location { get; set; }
        public string? Year { get; set; }
    }

    public class EEExperienceItem
    {
        public string? Position { get; set; }
        public string? Company { get; set; }
        public string? Location { get; set; }
        public string? Duration { get; set; }
        public List<string>? Contributions { get; set; }
        public string? Achievement { get; set; }
    }
}