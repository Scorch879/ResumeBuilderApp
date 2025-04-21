using Scriban;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FinalProjectOOP2
{
    public partial class CallCenterResume : UserControl
    {
        private List<string> tempResponsibilities = new List<string>();
        private DataGridViewRow? selectedExpRow = null;


        public CallCenterResume()
        {
            InitializeComponent();
        }

        public void PreviewResume()
        {
            var resumeData = GetResumeData();
            string templateFileName = "CallCenterTemplate.html"; // Adjust if needed

            ResumePreviewForm previewForm = new ResumePreviewForm();
            previewForm.LoadResumePreview(resumeData, templateFileName);
            previewForm.Show();
        }

        public List<string> GetListBoxItems(ListBox listBox)
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
                CoreSkills = GetListBoxItems(coreSkillsLstBx), // Fill this from your UI
                TechSkills = GetListBoxItems(techSkillsLstBx),
                Languages = GetListBoxItems(languageLstBx),
                Experience = GetExperienceFromGrid(dgvProfExp),
                Education = GetEducationFromGrid(dgvEducation)
            };
        }

        private void dgvProfExp_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProfExp.SelectedRows.Count > 0)
            {
                selectedExpRow = dgvProfExp.SelectedRows[0];
            }
        }

        /// <summary>
        /// This is where the cursor or the et cetera methods are
        /// </summary>
        /// 

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

        /// <summary>
        ///  End of the et cetera code block
        /// </summary>




        //Core Skills Section
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

        //Tech Skill Section
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

        //Language Section
        private void btnLangAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(languageTbx.Text))
            {
                languageLstBx.Items.Add(languageTbx.Text.Trim());
                languageTbx.Clear();
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

        ///<summary>
        /// Data Grid Sections
        /// </summary>

        //Education Section
        private void btnAddEduc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(degreeTbx.Text) ||
                string.IsNullOrWhiteSpace(schoolTbx.Text) ||
                string.IsNullOrWhiteSpace(locationTbx.Text) ||
                string.IsNullOrWhiteSpace(yearTbx.Text))
            {
                warningLbl.Text = "One of the inputs are empty, please fill up necessary details!";
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

            int newRowIdx = dgvProfExp.Rows.Count - 1; //auto selects the new row
            if (newRowIdx >= 0)
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
            if (selectedExpRow == null)
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
        }


        public class CallCenterResumeModel : PersonalInfo
        {
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
    }
}
