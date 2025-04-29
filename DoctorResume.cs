using System.Data;
using static FinalProjectOOP2.ResumeDatabase;

namespace FinalProjectOOP2
{
    public partial class DoctorResume : UserControl, IResumeSaveable
    {
        public string? CurrentUsername { get; set; }

        public DoctorResume()
        {
            InitializeComponent();
            dgvProfExp.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvProfExp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            LoadExistingPersonalInfo();
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
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading personal information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region These methods are for the Button Click within the EditContributions Column
        private void dgvProfExp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure click is on a valid row
            if (e.RowIndex < 0) return;

            // Check if the column is the "Edit" button column
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

        private void dgvProfExp_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvProfExp.Columns.Contains("Contributions") &&
                dgvProfExp.Columns[e.ColumnIndex].Name == "Contributions")
            {
                var raw = dgvProfExp.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (!string.IsNullOrWhiteSpace(raw) && raw != "Edit")
                    e.ToolTipText = raw.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
            }
        }

        #endregion


        public void PreviewResume()
        {
            var resumeData = GetResumeData();
            string templateFileName = "DoctorTemplate.html";

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

            // 2. Check at least one clinical skill, med tech skill, education, experience, license, and affiliation
            if (coreSkillsLstBx.Items.Count == 0)
            {
                MessageBox.Show("Please add at least one Clinical Skill.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (techSkillsLstBx.Items.Count == 0)
            {
                MessageBox.Show("Please add at least one Medical Tech Skill.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (dgvAffiliate.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                MessageBox.Show("Please add at least one Affiliation entry.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // You can add more detailed checks for each section if needed

            return true;
        }

        //Saving
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
                
                // Save or update personal info
                int personalInfoId = db.SavePersonalInfo(personalInfo, currentUsername);
                if (personalInfoId == 0) return false;

                // Gather DoctorResume data
                var clinicalSkills = coreSkillsLstBx.Items.Cast<string>().ToList();
                var medTechSkills = techSkillsLstBx.Items.Cast<string>().ToList();
                var areasOfExpertise = expertiseLstBx.Items.Cast<string>().ToList();
                var experience = GetExperience();
                var licenses = GetLicenses();
                var affiliations = GetAffiliations();
                var education = GetEducationItems();

                // Save everything
                return db.SaveDoctorResume(personalInfoId,resumeTitle,clinicalSkills,medTechSkills,areasOfExpertise, experience,licenses,affiliations,education);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving resume: {ex.Message}");
                return false;
            }
        }

        //Loading daata
        public void LoadResume(ResumeSummary resume)
        {
            try
            {
                // Load resume data from database
                var db = new ResumeDatabase();
                var resumeModel = db.LoadDoctorResume(resume.ResumeID);

                // Populate personal info
                firstNameTbx.Text = resumeModel.FirstName;
                middleNameTbx.Text = resumeModel.MiddleName;
                lastNameTbx.Text = resumeModel.LastName;
                emailTbx.Text = resumeModel.Email;
                phoneNumTbx.Text = resumeModel.Phone;
                addressTbx.Text = resumeModel.Address;
                titleTbx.Text = resumeModel.Title;
                summaryTbx.Text = resumeModel.Summary;

                // Populate clinical skills
                coreSkillsLstBx.Items.Clear();
                if (resumeModel.ClinicalSkills != null)
                {
                    foreach (var skill in resumeModel.ClinicalSkills)
                    {
                        coreSkillsLstBx.Items.Add(skill);
                    }
                }

                // Populate medical tech skills
                techSkillsLstBx.Items.Clear();
                if (resumeModel.MedicalTech != null)
                {
                    foreach (var skill in resumeModel.MedicalTech)
                    {
                        techSkillsLstBx.Items.Add(skill);
                    }
                }

                // Populate expertise
                expertiseLstBx.Items.Clear();
                if (resumeModel.AreasOfExpertise != null)
                {
                    foreach (var exp in resumeModel.AreasOfExpertise)
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
                            education.Degree,
                            education.Institution,
                            education.Specialization,
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
                            license.InitialDate.ToShortDateString(),
                            license.LicenseNumber,
                            license.ExpiryDate.ToShortDateString()
                        );
                    }
                }

                // Populate affiliations
                dgvAffiliate.Rows.Clear();
                if (resumeModel.Affiliations != null)
                {
                    foreach (var affiliation in resumeModel.Affiliations)
                    {
                        dgvAffiliate.Rows.Add(
                            affiliation.Status,
                            affiliation.Institution
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading resume: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Fetching Data
        private DoctorResumeModel GetResumeData()
        {
            return new DoctorResumeModel
            {
                Name = $"{firstNameTbx.Text} {middleNameTbx.Text} {lastNameTbx.Text}".Trim(),
                Address = addressTbx.Text,
                Phone = phoneNumTbx.Text,
                Email = emailTbx.Text,
                Title = titleTbx.Text,
                Summary = summaryTbx.Text,
                ClinicalSkills = coreSkillsLstBx.Items.Cast<string>().ToList(),
                MedicalTech = techSkillsLstBx.Items.Cast<string>().ToList(),
                Licenses = GetLicenses(),
                AreasOfExpertise = expertiseLstBx.Items.Cast<string>().ToList(),
                Experience = GetExperience(),
                Education = GetEducationItems(),
                Affiliations = GetAffiliations()
            };
        }

        private List<DoctorExperienceItem> GetExperience()
        {
            var experienceList = new List<DoctorExperienceItem>();

            foreach (DataGridViewRow row in dgvProfExp.Rows)
            {
                if (row.IsNewRow) continue;

                string? position = row.Cells["JobTitle"]?.Value?.ToString();
                string? company = row.Cells["Company"]?.Value?.ToString();
                string? location = row.Cells["Location"]?.Value?.ToString();
                string? duration = row.Cells["Duration"]?.Value?.ToString();
                string? description = row.Cells["Description"]?.Value?.ToString(); // Optional

                // Prevent "Edit" from being treated as actual data
                string? contributionsRaw = row.Cells["Contributions"]?.Value?.ToString();
                List<string> contributions =
                    (string.IsNullOrWhiteSpace(contributionsRaw) || contributionsRaw.Trim() == "Edit")
                        ? new List<string>()
                        : contributionsRaw.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(s => s.Trim()).ToList();

                if (!string.IsNullOrWhiteSpace(position) && !string.IsNullOrWhiteSpace(company))
                {
                    experienceList.Add(new DoctorExperienceItem
                    {
                        Position = position,
                        Company = company,
                        Location = location,
                        Duration = duration,
                        Description = description,
                        Contributions = contributions
                    });
                }
            }

            return experienceList;
        }

        private List<DoctorEducationItem> GetEducationItems()
        {
            var list = new List<DoctorEducationItem>();

            foreach (DataGridViewRow row in dgvEducation.Rows)
            {
                if (row.IsNewRow) continue;

                var degree = row.Cells["Position"]?.Value?.ToString();
                var institution = row.Cells["Institution"]?.Value?.ToString();
                var specialization = row.Cells["Specialization"]?.Value?.ToString();
                var location = row.Cells["Location_Doc"]?.Value?.ToString();

                if (!string.IsNullOrWhiteSpace(degree) && !string.IsNullOrWhiteSpace(institution))
                {
                    list.Add(new DoctorEducationItem
                    {
                        Degree = degree,
                        Institution = institution,
                        Specialization = specialization,
                        Location = location
                    });
                }
            }

            return list;
        }

        private List<DoctorLicense> GetLicenses()
        {
            var list = new List<DoctorLicense>();

            foreach (DataGridViewRow row in licenseDgv.Rows)
            {
                if (row.IsNewRow) continue;

                var type = row.Cells["LiscenseType"]?.Value?.ToString();
                var licenseNo = row.Cells["LiscenseNo"]?.Value?.ToString();
                var initialDateStr = row.Cells["InitialLiscenseDate"]?.Value?.ToString();
                var expiryDateStr = row.Cells["ExpiryDate"]?.Value?.ToString();

                if (DateTime.TryParse(initialDateStr, out var initialDate) &&
                    DateTime.TryParse(expiryDateStr, out var expiryDate))
                {
                    list.Add(new DoctorLicense
                    {
                        Type = type,
                        LicenseNumber = licenseNo,
                        InitialDate = initialDate,
                        ExpiryDate = expiryDate
                    });
                }
            }

            return list;
        }

        private List<DoctorAffiliation> GetAffiliations()
        {
            var list = new List<DoctorAffiliation>();

            foreach (DataGridViewRow row in dgvAffiliate.Rows)
            {
                if (row.IsNewRow) continue;

                string? status = row.Cells["Status"].Value?.ToString();
                string? institution = row.Cells["InstitutionAffiliate"].Value?.ToString();

                if (!string.IsNullOrWhiteSpace(status) && !string.IsNullOrWhiteSpace(institution))
                {
                    list.Add(new DoctorAffiliation
                    {
                        Status = status,
                        Institution = institution
                    });
                }
            }

            return list;
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


        #region Button Methods

        //Skills
        private void btnAddClinicalSkill_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(coreSkillTbx.Text))
            {
                coreSkillsLstBx.Items.Add(coreSkillTbx.Text.Trim());
                coreSkillTbx.Clear();
            }
        }

        private void btnRemoveClinicalSkill_Click(object sender, EventArgs e)
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

        private void btnAddMedTechSkill_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(techSkillTbx.Text))
            {
                techSkillsLstBx.Items.Add(techSkillTbx.Text.Trim());
                techSkillTbx.Clear();
            }
        }

        private void btnRemoveMedTechSkill_Click(object sender, EventArgs e)
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


        //Experience
        private void addExperienceBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(positionTbx.Text) || string.IsNullOrWhiteSpace(companyTbx.Text))
            {
                MessageBox.Show("Please enter at least a Position and Company.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dgvProfExp.Rows.Add();
            var row = dgvProfExp.Rows[rowIndex];

            row.Cells["JobTitle"].Value = positionTbx.Text.Trim();
            row.Cells["Company"].Value = companyTbx.Text.Trim();
            row.Cells["Location"].Value = locationExpTbx.Text.Trim();
            row.Cells["Duration"].Value = durationTbx.Text.Trim();
            row.Cells["Description"].Value = descriptionTbx.Text.Trim();

            //  Defensive check for Contributions column
            if (dgvProfExp.Columns.Contains("Contributions"))
            {
                row.Cells["Contributions"].Value = ""; // Will be filled by popup later
            }
            else
            {
                MessageBox.Show("The 'Contributions' column is missing from the DataGridView.", "Column Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Optionally clear fields
            positionTbx.Clear();
            companyTbx.Clear();
            locationExpTbx.Clear();
            durationTbx.Clear();
            descriptionTbx.Clear();
        }

        private void removeExperienceBtn_Click(object sender, EventArgs e)
        {
            if (dgvProfExp.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvProfExp.SelectedRows)
                {
                    if (!row.IsNewRow)
                        dgvProfExp.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("Please select an experience to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       

        //Expertise
        private void addExpertiseBtn_Click(object sender, EventArgs e)
        {
            string selectedExpertise = expertiseCbx.Text.Trim();

            // Validate input: Only add if it's in the dropdown list
            if (!expertiseCbx.Items.Contains(selectedExpertise))
            {
                MessageBox.Show("Please select a valid area of expertise from the dropdown.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prevent duplicates
            if (expertiseLstBx.Items.Contains(selectedExpertise))
            {
                MessageBox.Show("This expertise is already in the list.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Add to list box
            expertiseLstBx.Items.Add(selectedExpertise);

            // Optionally clear selection
            expertiseCbx.SelectedIndex = -1;
        }

        private void removeExpertiseBtn_Click(object sender, EventArgs e)
        {
            if (expertiseLstBx.SelectedItem != null)
            {
                expertiseLstBx.Items.Remove(expertiseLstBx.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select an expertise to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //Liscense
        private void addLiscenseBtn_Click(object sender, EventArgs e)
        {
            string licenseType = liscenseTypeCbx.Text;
            string licenseNo = liscenseNoTbx.Text.Trim();
            DateTime initialDate = initialLiscenseDatePicker.Value;
            DateTime expiryDate = expiryDatePicker.Value;

            // Validate: Only allow license types from the list
            if (!liscenseTypeCbx.Items.Contains(licenseType))
            {
                MessageBox.Show("Please select a valid license type from the dropdown.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate: License number can't be empty
            if (string.IsNullOrWhiteSpace(licenseNo))
            {
                MessageBox.Show("Please enter a license number.", "Missing License No.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in licenseDgv.Rows)
            {
                if (!row.IsNewRow && row.Cells[2].Value?.ToString() == licenseNo) // Column index 2 = License No
                {
                    MessageBox.Show("This license number already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Add new row to DataGridView
            licenseDgv.Rows.Add(licenseType, initialDate.ToShortDateString(), licenseNo, expiryDate.ToShortDateString());

            // Clear inputs
            liscenseNoTbx.Clear();
            liscenseTypeCbx.SelectedIndex = -1;
        }

        private void removeLiscenseBtn_Click(object sender, EventArgs e)
        {
            if (licenseDgv.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in licenseDgv.SelectedRows)
                {
                    licenseDgv.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("Please select a license to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //Education
        private void addEducationBtn_Click(object sender, EventArgs e)
        {
            string degree = degreeTbx.Text.Trim();
            string institution = institutionTbx.Text.Trim();
            string specialization = specializationTbx.Text.Trim();
            string location = locationTbx.Text.Trim();

            if (string.IsNullOrWhiteSpace(degree) || string.IsNullOrWhiteSpace(institution) ||
                string.IsNullOrWhiteSpace(specialization) || string.IsNullOrWhiteSpace(location))
            {
                MessageBox.Show("Please fill in all the education fields.", "Incomplete Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dgvEducation.Rows)
            {
                if (!row.IsNewRow &&
                    row.Cells[0].Value?.ToString() == degree &&
                    row.Cells[1].Value?.ToString() == institution &&
                    row.Cells[2].Value?.ToString() == specialization &&
                    row.Cells[3].Value?.ToString() == location)
                {
                    MessageBox.Show("This education entry already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            dgvEducation.Rows.Add(degree, institution, specialization, location);

            degreeTbx.Clear();
            institutionTbx.Clear();
            specializationTbx.Clear();
            locationTbx.Clear();

        }

        private void removeEducationBtn_Click(object sender, EventArgs e)
        {
            if (dgvEducation.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvEducation.SelectedRows)
                {
                    dgvEducation.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("Please select an education entry to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //Affiliations
        private void addAffiliationBtn_Click(object sender, EventArgs e)
        {
            string status = statusTbx.Text.Trim();
            string institution = institutionOrgTbx.Text.Trim();

            // Validation: Check for empty input
            if (string.IsNullOrWhiteSpace(status) || string.IsNullOrWhiteSpace(institution))
            {
                MessageBox.Show("Please fill in both Status and Institution fields.", "Incomplete Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check for duplicates
            foreach (DataGridViewRow row in dgvAffiliate.Rows)
            {
                if (!row.IsNewRow &&
                    row.Cells[0].Value?.ToString() == status &&
                    row.Cells[1].Value?.ToString() == institution)
                {
                    MessageBox.Show("This affiliation already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

           
            dgvAffiliate.Rows.Add(status, institution);

        
            statusTbx.Clear();
            institutionOrgTbx.Clear();
        }

        private void removeAffiliationBtn_Click(object sender, EventArgs e)
        {
            if (dgvAffiliate.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvAffiliate.SelectedRows)
                {
                    dgvAffiliate.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("Please select an affiliation entry to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }

    public class DoctorResumeModel : PersonalInfo
    {
        public string? Name { get; set; }
        public List<string>? ClinicalSkills { get; set; }
        public List<string>? MedicalTech { get; set; }
        public List<DoctorLicense>? Licenses { get; set; }
        public List<string>? AreasOfExpertise { get; set; }

        public List<DoctorExperienceItem>? Experience { get; set; }
        public List<DoctorEducationItem>? Education { get; set; }
        public List<DoctorAffiliation>? Affiliations { get; set; }
    }

    public class DoctorEducationItem : EducationItem
    {
        public string? Institution { get; set; }
        public string? Specialization { get; set; }
    }

    public class DoctorExperienceItem
    {
        public string? Position { get; set; }
        public string? Company { get; set; }
        public string? Location { get; set; }
        public string? Duration { get; set; }
        public string? Description { get; set; }
        public List<string>? Contributions { get; set; }
    }
    
    public class DoctorLicense
    {
        public string? Type { get; set; }
        public string? LicenseNumber { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public string FormattedInitialDate => InitialDate.ToString("dd/MM/yyyy");
        public string FormattedExpiryDate => ExpiryDate.ToString("dd/MM/yyyy");
    }

    public class DoctorAffiliation
    {
        public string? Status { get; set; }
        public string? Institution { get; set; }
    }
}