﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FinalProjectOOP2.CallCenterResume;

namespace FinalProjectOOP2
{
    public partial class ElectricalEngineeringTemplate : UserControl
    {
        private List<string> tempResponsibilities = new List<string>();
        private DataGridViewRow? selectedExpRow = null;
        private DataGridViewRow? selectedTechRow;

        public ElectricalEngineeringTemplate()
        {
            InitializeComponent();
        }

        public void PreviewResume()
        {
            var resumeData = GetResumeData();
            string templateFileName = "ElectricalEngineeringTemplate.html";

            ResumePreviewForm previewForm = new ResumePreviewForm();
            previewForm.LoadResumePreview(resumeData, templateFileName);
            previewForm.Show();
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


        private List<string> GetListBoxItems(ListBox listBox)
        {
            return listBox.Items.Cast<string>().ToList();
        }

        #region fetching data from data grid methods
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
                ProfessionalDevelopment = GetListBoxItems(developmentLstBx)
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

            if (!dgvTechExpertise.Columns.Contains(expertiseType))
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

                if (row.Cells[expertiseType].Value == null || string.IsNullOrWhiteSpace(row.Cells[expertiseType].Value.ToString()))
                {
                    row.Cells[expertiseType].Value = detail;
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
                newRow.Cells[expertiseType].Value = detail;

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
            foreach (DataGridViewCell cell in dgvTechExpertise.SelectedCells)
            {
                cell.Value = null;
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

        //Responbilities
        private void addResponbilityBtn_Click(object sender, EventArgs e)
        {
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
            warning1EEProfExp.Text = "";
        }

        private void removeResponsibilityBtn_Click(object sender, EventArgs e)
        {
            if (selectedExpRow == null)
            {
                warnning2EERespo.Text = "Please select a job entry first.";
                warnning2EERespo.ForeColor = Color.Red;
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
                        warnning2EERespo.Text = ""; // Clear warning
                        return;
                    }
                }
            }

            warnning2EERespo.Text = "No responsibilities to remove.";
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

       
        #endregion
    }


    public class ElectricalEngineeringResumeModel : PersonalInfo
    {
        public List<string>? CoreSkills { get; set; }
        public List<string>? TechSkills { get; set; }
        public List<string>? ProfessionalDevelopment { get; set; }

        public TechExpertise? TechnicalExpertise { get; set; }

        public List<ExperienceItem>? Experience { get; set; }
        public List<EducationItem>? Education { get; set; }
        
    }

    public class TechExpertise
    {
        public List<string>? PLCs { get; set; } 
        public List<string>? DesignSkills { get; set; } 
        public List<string>? Methodologies { get; set; } 
        public List<string>? ProductionSkills { get; set; } 
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
