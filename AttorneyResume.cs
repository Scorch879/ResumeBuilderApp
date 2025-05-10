using SelectPdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FinalProjectOOP2.ResumeDatabase;

namespace FinalProjectOOP2
{
    public partial class AttorneyResume : UserControl, IResumeSaveable, IResumeExportable
    {
        // Add constants for column indices
        private const int TYPE_COLUMN = 0;
        private const int INITIAL_DATE_COLUMN = 1;
        private const int LICENSE_NUMBER_COLUMN = 2;

        // Simplified column constants
        private const int DEGREE_POSITION_COLUMN = 0;
        private const int INSTITUTION_COLUMN = 1;
        private const int LOCATION_COLUMN = 2;

        private const int POSITION_COLUMN = 0;
        private const int COMPANY_COLUMN = 1;
        private const int DURATION_COLUMN = 3;
        private const int DESCRIPTION_COLUMN = 4;

        private List<EarlierPosition> earlierPositionsList = new List<EarlierPosition>();

        private string? currentUsername;
        public string? CurrentUsername
        {
            get
            {
                return currentUsername;
            }
            set
            {
                currentUsername = value;
            }
        }

        private byte[]? selectedProfilePicBytes = null;

        public AttorneyResume()
        {
            InitializeComponent();
            LoadPersonalInfo();
        }

        public void PreviewResume()
        {
            var resumeData = GetResumeData();
            string templateFileName = "AttorneyTemplate.html";

            ResumePreviewForm previewForm = new ResumePreviewForm();
            previewForm.LoadResumePreview(resumeData, templateFileName);
            previewForm.Show();
        }

        public void LoadPersonalInfo()
        {
            var db = new ResumeDatabase();

            if (currentUsername != null)
            {
                int ownerID = db.GetCurrentUserID(currentUsername);
                var model = db.LoadPersonalInfo(ownerID);
                // Populate personal info
                firstNameTbx.Text = model.FirstName;
                middleNameTbx.Text = model.MiddleName;
                lastNameTbx.Text = model.LastName;
                emailTbx.Text = model.Email;
                phoneNumTbx.Text = model.Phone;
                addressTbx.Text = model.Address;
                titleTbx.Text = model.Title;
                summaryTbx.Text = model.Summary;
                if (model.ProfilePic != null)
                {
                    // Use OLE extraction helper to get the actual image bytes
                    var extractedBytes = ResumeDatabase.ExtractImageFromOLEField(model.ProfilePic);
                    using (var ms = new System.IO.MemoryStream(extractedBytes))
                    {
                        var img = Image.FromStream(ms);
                        imageNameTbx.Text = "Image Loaded";
                        imageNameTbx.BackColor = Color.LightGreen;
                        selectedProfilePicBytes = extractedBytes;
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
                MessageBox.Show("Please add at least one Legal Tech Skill.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (barAdmissionsLstBx.Items.Count == 0)
            {
                MessageBox.Show("Please add at least one Bar Admission.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (expertiseLstBx.Items.Count == 0)
            {
                MessageBox.Show("Please add at least one Area of Expertise.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dgvEducation.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                MessageBox.Show("Please add at least one Education entry.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dgvProfExp.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                MessageBox.Show("Please add at least one Experience entry.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (licenseDgv.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                MessageBox.Show("Please add at least one License entry.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // You can add more detailed checks for each section if needed

            return true;
        }


        public void ExportToPDF(string outputPath, int resumeId)
        {
            try
            {
                // Load the resume data from the database (not from the form)
                var db = new ResumeDatabase();
                var resumeData = db.LoadAttorneyResume(resumeId);

                // Ensure all job.Contributions are never null
                if (resumeData.Experience != null)
                {
                    foreach (var job in resumeData.Experience)
                    {
                        if (job.Contributions == null)
                            job.Contributions = new List<string>();
                    }
                }

                // Load the HTML template
                string templatePath = Path.Combine(Application.StartupPath, "Templates", "AttorneyTemplate.html");
                string templateContent = File.ReadAllText(templatePath);

                // Create template data dictionary
                var templateData = new Dictionary<string, object>();

                // Copy all properties from resumeData to templateData
                foreach (var prop in resumeData.GetType().GetProperties())
                {
                    if (prop.Name != "FirstName" && prop.Name != "MiddleName" && prop.Name != "LastName")
                    {
                        var value = prop.GetValue(resumeData);
                        if (value != null)
                        {
                            templateData[prop.Name] = value;
                        }
                    }
                }

                // Always get the profile picture from PersonalInfo (current user)
                string? currentUsername = this.CurrentUsername;
                byte[]? profilePicBytes = null;
                if (!string.IsNullOrEmpty(currentUsername))
                {
                    int userId = db.GetCurrentUserID(currentUsername);
                    var personalInfo = db.LoadPersonalInfo(userId);
                    profilePicBytes = personalInfo?.ProfilePic;
                }

                if (profilePicBytes != null && profilePicBytes.Length > 0)
                {
                    string mimeType = GetImageMimeType(profilePicBytes);
                    string base64Image = Convert.ToBase64String(profilePicBytes);
                    templateData["ProfilePicPath"] = $"data:{mimeType};base64,{base64Image}";
                }
                else
                {
                    templateData["ProfilePicPath"] = "Assets/default-profile.png";
                }

                // Render HTML with Scriban
                var template = Scriban.Template.Parse(templateContent);
                var htmlOutput = template.Render(templateData);

                // Convert HTML to PDF
                HtmlToPdf converter = new HtmlToPdf();
                PdfDocument doc = converter.ConvertHtmlString(htmlOutput);
                doc.Save(outputPath);
                doc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}");
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


        //Saving Resume to database
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
                    Summary = summaryTbx.Text,
                    ProfilePic = selectedProfilePicBytes
                };

                // Save or update personal info
                int personalInfoId = db.SavePersonalInfo(personalInfo, currentUsername);
                if (personalInfoId == 0) return false;

                // Gather AttorneyResume data from controls
                var coreSkills = coreSkillsLstBx.Items.Cast<string>().ToList();
                var legalTech = techSkillsLstBx.Items.Cast<string>().ToList();
                var barAdmissions = barAdmissionsLstBx.Items.Cast<string>().ToList();
                var expertise = expertiseLstBx.Items.Cast<string>().ToList();
                var education = GetAttorneyEducation();
                var experience = GetExperiences();
                var licenses = GetAttorneyLicenses();
                var earlierPositions = earlierPositionsList;

                // Save everything
                return db.SaveAttorneyResume(personalInfoId, resumeTitle, coreSkills, legalTech, barAdmissions, expertise, education, experience, licenses, earlierPositions);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving resume: {ex.Message}");
                return false;
            }
        }

        //Loading Resume from Database
        public void LoadResume(ResumeSummary resume)
        {
            try
            {
                // Load resume data from database
                var db = new ResumeDatabase();

                var resumeModel = db.LoadAttorneyResume(resume.ResumeID);

                // Populate personal info
                firstNameTbx.Text = resumeModel.FirstName;
                middleNameTbx.Text = resumeModel.MiddleName;
                lastNameTbx.Text = resumeModel.LastName;
                emailTbx.Text = resumeModel.Email;
                phoneNumTbx.Text = resumeModel.Phone;
                addressTbx.Text = resumeModel.Address;
                titleTbx.Text = resumeModel.Title;
                summaryTbx.Text = resumeModel.Summary;

                // Populate skills
                coreSkillsLstBx.Items.Clear();
                if (resumeModel.CoreSkills != null)
                {
                    foreach (var skill in resumeModel.CoreSkills)
                    {
                        coreSkillsLstBx.Items.Add(skill);
                    }
                }

                techSkillsLstBx.Items.Clear();
                if (resumeModel.LegalTech != null)
                {
                    foreach (var skill in resumeModel.LegalTech)
                    {
                        techSkillsLstBx.Items.Add(skill);
                    }
                }

                barAdmissionsLstBx.Items.Clear();
                if (resumeModel.BarAdmissions != null)
                {
                    foreach (var admission in resumeModel.BarAdmissions)
                    {
                        barAdmissionsLstBx.Items.Add(admission);
                    }
                }

                expertiseLstBx.Items.Clear();
                if (resumeModel.Expertise != null)
                {
                    foreach (var exp in resumeModel.Expertise)
                    {
                        expertiseLstBx.Items.Add(exp);
                    }
                }

                // Populate education
                dgvEducation.Rows.Clear();
                if (resumeModel.Education != null)
                {
                    foreach (var education in resumeModel.Education)
                    {
                        dgvEducation.Rows.Add(
                            education.DegreePosition,
                            education.Institution,
                            education.Location
                        );
                    }
                }

                // Populate experience
                dgvProfExp.Rows.Clear();
                if (resumeModel.Experience != null)
                {
                    foreach (var experience in resumeModel.Experience)
                    {
                        dgvProfExp.Rows.Add(
                            experience.Position,
                            experience.Company,
                            experience.Location,
                            experience.Duration,
                            experience.Description,
                            string.Join("\n", experience.Contributions ?? new List<string>())
                        );
                    }
                }

                // Populate licenses
                licenseDgv.Rows.Clear();
                if (resumeModel.Licenses != null)
                {
                    foreach (var license in resumeModel.Licenses)
                    {
                        licenseDgv.Rows.Add(
                            license.Type,
                            license.AdmissionDate.ToShortDateString(),
                            license.LicenseNumber
                        );
                    }
                }

                // Populate earlier positions
                earlierPositionsList.Clear();
                if (resumeModel.EarlierPositions != null)
                {
                    earlierPositionsList.AddRange(resumeModel.EarlierPositions);
                }

                // Update resume title
                //txtResumeTitle.Text = resume.Title;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading resume: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProfExp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex >= 0 && dgvProfExp.Columns.Contains("EditContributions") &&
                dgvProfExp.Columns[e.ColumnIndex].Name == "EditContributions")
            {
                var row = dgvProfExp.Rows[e.RowIndex];
                string? raw = row.Cells["Contributions"]?.Value?.ToString();

                var existing = string.IsNullOrWhiteSpace(raw)
                    ? new List<string>()
                    : raw.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();

                using var form = new ContributionForm(existing);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    row.Cells["Contributions"].Value = string.Join("\n", form.Contributions);
                }
            }
        }


        private AttorneyResumeModel GetResumeData()
        {
            return new AttorneyResumeModel
            {
                Name = $"{firstNameTbx.Text} {middleNameTbx.Text} {lastNameTbx.Text}".Trim(),
                Address = addressTbx.Text,
                Phone = phoneNumTbx.Text,
                Email = emailTbx.Text,
                Title = titleTbx.Text,
                Summary = summaryTbx.Text,
                CoreSkills = coreSkillsLstBx.Items.Cast<string>().ToList(),
                LegalTech = techSkillsLstBx.Items.Cast<string>().ToList(),
                BarAdmissions = barAdmissionsLstBx.Items.Cast<string>().ToList(),
                Expertise = expertiseLstBx.Items.Cast<string>().ToList(),
                EarlierPositions = earlierPositionsList,
                Licenses = GetAttorneyLicenses(),
                Education = GetAttorneyEducation(),
                Experience = GetExperiences(),
                ProfilePic = selectedProfilePicBytes,
                CurrentUsername = this.CurrentUsername
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

        private void clinicalSkillTbx_Enter(object sender, EventArgs e)
        {
            HandleEnter(clinicalSkillTbx, "Enter your skill");
        }

        private void clinicalSkillTbxx_Leave(object sender, EventArgs e)
        {
            HandleLeave(clinicalSkillTbx, "Enter your skill");
        }

        private void legalTechSkillTbx_Enter(object sender, EventArgs e)
        {
            HandleEnter(techSkillTbx, "Enter your skill");
        }

        private void legalTechSkillTbx_Leave(object sender, EventArgs e)
        {
            HandleLeave(techSkillTbx, "Enter your skill");
        }
        #endregion


        #region Fetching data from the data grids

        public List<AttorneyEducation> GetAttorneyEducation()
        {
            var educationList = new List<AttorneyEducation>();

            foreach (DataGridViewRow row in dgvEducation.Rows)
            {
                if (row.IsNewRow) continue;

                try
                {
                    var education = new AttorneyEducation
                    {
                        DegreePosition = row.Cells[DEGREE_POSITION_COLUMN].Value?.ToString()?.Trim(),
                        Institution = row.Cells[INSTITUTION_COLUMN].Value?.ToString()?.Trim(),
                        Location = row.Cells[LOCATION_COLUMN].Value?.ToString()?.Trim()
                    };

                    if (education.IsValid())
                    {
                        educationList.Add(education);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid education data found for {education.DegreePosition} at {education.Institution}",
                                      "Data Error",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading education data: {ex.Message}",
                                  "Data Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }

            return educationList;
        }

        public List<AttorneyLicense> GetAttorneyLicenses()
        {
            var licenses = new List<AttorneyLicense>();

            foreach (DataGridViewRow row in licenseDgv.Rows)
            {
                if (row.IsNewRow) continue;

                try
                {
                    var license = new AttorneyLicense
                    {
                        Type = row.Cells[TYPE_COLUMN].Value?.ToString(),
                        AdmissionDate = DateTime.Parse(row.Cells[INITIAL_DATE_COLUMN].Value?.ToString() ??
                                                  throw new Exception("Invalid Admission date")),
                        LicenseNumber = row.Cells[LICENSE_NUMBER_COLUMN].Value?.ToString(),
                    };

                    if (license.IsValid())
                    {
                        licenses.Add(license);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid license data found for license number {license.LicenseNumber}",
                                      "Data Error",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                        throw new Exception($"Invalid license data found for license number {license.LicenseNumber}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading license data: {ex.Message}",
                                  "Data Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }

            return licenses;
        }

        public List<AttorneyExperience> GetExperiences()
        {
            var experiences = new List<AttorneyExperience>();

            foreach (DataGridViewRow row in dgvProfExp.Rows)
            {
                if (row.IsNewRow) continue;

                try
                {
                    var experience = new AttorneyExperience
                    {
                        Position = row.Cells[POSITION_COLUMN].Value?.ToString()?.Trim(),
                        Company = row.Cells[COMPANY_COLUMN].Value?.ToString()?.Trim(),
                        Location = row.Cells[LOCATION_COLUMN].Value?.ToString()?.Trim(),
                        Duration = row.Cells[DURATION_COLUMN].Value?.ToString()?.Trim(),
                        Description = row.Cells[DESCRIPTION_COLUMN].Value?.ToString()?.Trim(),
                        Contributions = new List<string>()  // Initialize empty contributions list
                    };

                    string? contributionsRaw = row.Cells["Contributions"]?.Value?.ToString();
                    List<string> contributions =
                        (string.IsNullOrWhiteSpace(contributionsRaw) || contributionsRaw.Trim() == "Edit")
                            ? new List<string>()
                            : contributionsRaw.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(s => s.Trim()).ToList();

                    experience.Contributions = contributions ?? new List<string>();

                    if (IsValidExperience(experience))
                    {
                        experiences.Add(experience);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid experience data found for position {experience.Position} at {experience.Company}",
                                      "Data Error",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading experience data: {ex.Message}",
                                  "Data Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }

            return experiences;
        }

        private bool IsValidExperience(AttorneyExperience experience)
        {
            return !string.IsNullOrWhiteSpace(experience.Position) &&
                   !string.IsNullOrWhiteSpace(experience.Company) &&
                   !string.IsNullOrWhiteSpace(experience.Duration);
        }

        #endregion

        #region Button Methods

        //Skills
        private void btnAddCoreSkill_Click(object sender, EventArgs e)
        {
            string skill = clinicalSkillTbx.Text.Trim();
            if (string.IsNullOrWhiteSpace(skill) || clinicalSkillTbx.Text == "Enter your skill")
            {
                MessageBox.Show("Please enter a core skill.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!coreSkillsLstBx.Items.Contains(skill))
            {
                coreSkillsLstBx.Items.Add(skill);
                clinicalSkillTbx.Clear();
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

        private void btnAddTechSkill_Click(object sender, EventArgs e)
        {
            string skill = techSkillTbx.Text.Trim();
            if (string.IsNullOrWhiteSpace(skill) || techSkillTbx.Text == "Enter your skill")
            {
                MessageBox.Show("Please enter a legal tech skill.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!techSkillsLstBx.Items.Contains(skill))
            {
                techSkillsLstBx.Items.Add(skill);
                techSkillTbx.Clear();
            }
            else
            {
                MessageBox.Show("This legal tech skill already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Please select a legal tech skill to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Expertise
        private void addExpertiseBtn_Click(object sender, EventArgs e)
        {
            string input = expertiseCbx.Text.Trim();

            // Check if input is in the valid list
            if (expertiseCbx.Text.Contains(input))
            {
                if (!expertiseLstBx.Items.Contains(input) && expertiseCbx.Text != "")
                {
                    expertiseLstBx.Items.Add(input);
                }
                else
                {
                    warningAttorneyExpertiseLbl.Text = "Please fill in all fields before adding experience.";
                    warningAttorneyExpertiseLbl.ForeColor = Color.Red;
                    warningAttorneyExpertiseLbl.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                }
            }
            else
            {
                warningAttorneyExpertiseLbl.Text = "Please enter a valid area of legal expertise.";
                warningAttorneyExpertiseLbl.ForeColor = Color.Red;
                warningAttorneyExpertiseLbl.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            }

            expertiseCbx.Text = "";
        }

        private void removeExpertiseBtn_Click(object sender, EventArgs e)
        {
            var selectedItems = expertiseLstBx.SelectedItems.Cast<object>().ToList();
            foreach (var item in selectedItems)
            {
                expertiseLstBx.Items.Remove(item);
            }
        }


        //Experience
        private void addExpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string position = positionTbx.Text.Trim();
                string company = companyTbx.Text.Trim();
                string location = locationExpTbx.Text.Trim();
                string duration = durationTbx.Text.Trim();
                string description = descriptionTbx.Text.Trim();

                // Validate inputs
                if (string.IsNullOrWhiteSpace(position))
                {
                    MessageBox.Show("Please enter a position.", "Missing Position", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(company))
                {
                    MessageBox.Show("Please enter a company.", "Missing Company", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(duration))
                {
                    MessageBox.Show("Please enter a duration.", "Missing Duration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (IsDuplicateExperience(position, company))
                {
                    MessageBox.Show("This experience entry already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                dgvProfExp.Rows.Add(position, company, location, duration, description);


                ClearExperienceInputs();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding experience: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeExpBtn_Click(object sender, EventArgs e)
        {
            if (dgvProfExp.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an experience entry to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to remove the selected experience entry(s)?",
                                       "Confirm Removal",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvProfExp.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        dgvProfExp.Rows.Remove(row);
                    }
                }
            }
        }

        // Helper methods for Experience
        private bool IsDuplicateExperience(string position, string company)
        {
            return dgvProfExp.Rows.Cast<DataGridViewRow>()
                .Any(row => !row.IsNewRow &&
                           row.Cells[POSITION_COLUMN].Value?.ToString()?.Trim() == position &&
                           row.Cells[COMPANY_COLUMN].Value?.ToString()?.Trim() == company);
        }

        private void ClearExperienceInputs()
        {
            positionTbx.Clear();
            companyTbx.Clear();
            locationExpTbx.Clear();
            durationTbx.Clear();
            descriptionTbx.Clear();
        }

        private void btnAddPreviousPosition_Click(object sender, EventArgs e)
        {
            try
            {
                using (var earlierPositionsForm = new EarlierPositionsForm(earlierPositionsList))
                {
                    if (earlierPositionsForm.ShowDialog() == DialogResult.OK)
                    {
                        earlierPositionsList = earlierPositionsForm.EarlierPositions.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error managing earlier positions: {ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }



        //Liscense
        private void addLiscenseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string licenseType = licenseTypeCbx.Text;
                string licenseNo = licenseNoTbx.Text.Trim();
                DateTime admissionDate = admissionDatePicker.Value;


                // Validate all inputs
                if (string.IsNullOrWhiteSpace(licenseType))
                {
                    MessageBox.Show("Please select a license type.", "Missing Type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!licenseTypeCbx.Items.Contains(licenseType))
                {
                    MessageBox.Show("Please select a valid license type from the dropdown.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(licenseNo))
                {
                    MessageBox.Show("Please enter a license number.", "Missing License No.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check for duplicate license numbers
                if (IsDuplicateLicense(licenseNo))
                {
                    MessageBox.Show("This license number already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Add the new license
                licenseDgv.Rows.Add(licenseType, admissionDate.ToShortDateString(), licenseNo);

                // Clear inputs
                ClearLicenseInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding license: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeLiscenseBtn_Click(object sender, EventArgs e)
        {
            if (licenseDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a license to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to remove the selected license(s)?",
                                       "Confirm Removal",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in licenseDgv.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        licenseDgv.Rows.Remove(row);
                    }
                }
            }
        }

        //Helper methods for license
        private bool IsDuplicateLicense(string licenseNo)
        {
            return licenseDgv.Rows.Cast<DataGridViewRow>()
                .Any(row => !row.IsNewRow &&
                           row.Cells[LICENSE_NUMBER_COLUMN].Value?.ToString() == licenseNo);
        }

        private void ClearLicenseInputs()
        {
            licenseNoTbx.Clear();
            licenseTypeCbx.SelectedIndex = -1;
            admissionDatePicker.Value = DateTime.Today;
        }


        //Education
        private void btnAddEducation_Click(object sender, EventArgs e)
        {
            try
            {
                string degreePosition = degreeTbx.Text.Trim();
                string institution = institutionTbx.Text.Trim();
                string location = locationTbx.Text.Trim();

                if (string.IsNullOrWhiteSpace(degreePosition))
                {
                    MessageBox.Show("Please enter a degree/position.", "Missing Degree/Position", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(institution))
                {
                    MessageBox.Show("Please enter an institution.", "Missing Institution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (IsDuplicateEducation(degreePosition, institution))
                {
                    MessageBox.Show("This education entry already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvEducation.Rows.Add(degreePosition, institution, location);

                ClearEducationInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding education: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveEducation_Click(object sender, EventArgs e)
        {
            if (dgvEducation.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an education entry to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to remove the selected education entry(s)?",
                                       "Confirm Removal",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvEducation.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        dgvEducation.Rows.Remove(row);
                    }
                }
            }
        }

        //Helper methods for Education
        private bool IsDuplicateEducation(string degreePosition, string institution)
        {
            return dgvEducation.Rows.Cast<DataGridViewRow>()
                .Any(row => !row.IsNewRow &&
                           row.Cells[DEGREE_POSITION_COLUMN].Value?.ToString()?.Trim() == degreePosition &&
                           row.Cells[INSTITUTION_COLUMN].Value?.ToString()?.Trim() == institution);
        }

        private void ClearEducationInputs()
        {
            degreeTbx.Clear();
            institutionTbx.Clear();
            locationTbx.Clear();
        }

        //Bar Admissions
        private void btnAddAdmission_Click(object sender, EventArgs e)
        {
            try
            {
                string admission = admissionTbx.Text.Trim();

                // Validate input
                if (string.IsNullOrWhiteSpace(admission))
                {
                    warningAdmissionLbl.Text = "Please enter a bar admission.";
                    warningAdmissionLbl.ForeColor = Color.Red;
                    warningAdmissionLbl.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                    return;
                }

                // Check for duplicates
                if (barAdmissionsLstBx.Items.Contains(admission))
                {
                    warningAdmissionLbl.Text = "This bar admission already exists.";
                    warningAdmissionLbl.ForeColor = Color.Red;
                    warningAdmissionLbl.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                    return;
                }

                // Add to ListBox
                barAdmissionsLstBx.Items.Add(admission);

                // Clear input and warning
                admissionTbx.Clear();
                warningAdmissionLbl.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding bar admission: {ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private void btnRemoveAdmission_Click(object sender, EventArgs e)
        {
            try
            {
                if (barAdmissionsLstBx.SelectedItems.Count == 0)
                {
                    warningAdmissionLbl.Text = "Please select a bar admission to remove.";
                    warningAdmissionLbl.ForeColor = Color.Red;
                    warningAdmissionLbl.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to remove the selected bar admission(s)?",
                                           "Confirm Removal",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var selectedItems = barAdmissionsLstBx.SelectedItems.Cast<object>().ToList();
                    foreach (var item in selectedItems)
                    {
                        barAdmissionsLstBx.Items.Remove(item);
                    }
                    warningAdmissionLbl.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing bar admission: {ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
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

        #endregion

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class AttorneyResumeModel : PersonalInfo
    {
        public string? Name { get; set; }
        public List<string>? CoreSkills { get; set; }
        public List<string>? LegalTech { get; set; }
        public List<string>? BarAdmissions { get; set; }
        public List<string>? Expertise { get; set; }
        public List<EarlierPosition>? EarlierPositions { get; set; }
        public List<AttorneyLicense>? Licenses { get; set; }
        public List<AttorneyEducation>? Education { get; set; }
        public List<AttorneyExperience>? Experience { get; set; }
        public byte[]? ProfilePic { get; set; }
        public string? CurrentUsername { get; set; }
    }

    public class AttorneyExperience
    {

        public string? Position { get; set; }
        public string? Company { get; set; }
        public string? Location { get; set; }
        public string? Duration { get; set; }
        public string? Description { get; set; }
        public List<string>? Contributions { get; set; }

        public AttorneyExperience()
        {
            Contributions = new List<string>();
        }
    }

    public class EarlierPosition
    {
        public string? Company { get; set; }
        public string? Location { get; set; }
        public string? Duration { get; set; }
        public string? Position { get; set; }
    }

    public class AttorneyLicense
    {
        private DateTime _admissionDate;
        private DateTime _expiryDate;

        public string? Type { get; set; }
        public string? LicenseNumber { get; set; }
        
        public DateTime AdmissionDate
        {
            get => _admissionDate;
            set => _admissionDate = value;
        }
        

        public string FormattedInitialDate => _admissionDate.ToString("dd/MM/yyyy");

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Type) &&
                   !string.IsNullOrWhiteSpace(LicenseNumber);
        }
    }

    public class AttorneyEducation
    {
        public string? DegreePosition { get; set; }  // Changed to DegreePosition to reflect dual purpose
        public string? Institution { get; set; }
        public string? Location { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(DegreePosition) &&
                   !string.IsNullOrWhiteSpace(Institution);
        }
    }
}