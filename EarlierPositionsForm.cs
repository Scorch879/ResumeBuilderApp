using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectOOP2
{
    public partial class EarlierPositionsForm : Form
    {
        // Private field to store the positions
        private List<EarlierPosition> earlierPositions;

        // Public property to access the positions
        public List<EarlierPosition> EarlierPositions 
        { 
            get { return earlierPositions; }
        }

        public EarlierPositionsForm(List<EarlierPosition>? existingPositions = null)
        {
            InitializeComponent();
            earlierPositions = existingPositions?.ToList() ?? new List<EarlierPosition>();
            SetupForm();
        }

        private void SetupForm()
        {
            // Set up DataGridView columns if not already set up in designer
            if (earlierPositionsDgv.Columns.Count == 0)
            {
                earlierPositionsDgv.Columns.AddRange(new DataGridViewColumn[]
                {
                    new DataGridViewTextBoxColumn
                    {
                        Name = "Position",
                        HeaderText = "Position",
                        DataPropertyName = "Position"
                    },
                    new DataGridViewTextBoxColumn
                    {
                        Name = "Company",
                        HeaderText = "Company",
                        DataPropertyName = "Company"
                    },
                    new DataGridViewTextBoxColumn
                    {
                        Name = "Location",
                        HeaderText = "Location",
                        DataPropertyName = "Location"
                    },
                    new DataGridViewTextBoxColumn
                    {
                        Name = "Duration",
                        HeaderText = "Duration",
                        DataPropertyName = "Duration"
                    }
                });
            }

            // Load existing positions if any
            LoadExistingPositions();
        }

        private void LoadExistingPositions()
        {
            earlierPositionsDgv.Rows.Clear();
            foreach (var position in earlierPositions)
            {
                earlierPositionsDgv.Rows.Add(
                    position.Position,
                    position.Company,
                    position.Location,
                    position.Duration
                );
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInputs())
                {
                    earlierPositionsDgv.Rows.Add(
                        positionTbx.Text.Trim(),
                        companyTbx.Text.Trim(),
                        locationTbx.Text.Trim(),
                        durationTbx.Text.Trim()
                    );

                    ClearInputs();
                    warningLbl.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding position: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (earlierPositionsDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a position to remove.", "No Selection", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to remove the selected position?",
                                       "Confirm Removal",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in earlierPositionsDgv.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        earlierPositionsDgv.Rows.Remove(row);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SavePositions())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool SavePositions()
        {
            try
            {
                earlierPositions.Clear();
                foreach (DataGridViewRow row in earlierPositionsDgv.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        earlierPositions.Add(new EarlierPosition
                        {
                            Position = row.Cells[0].Value?.ToString(),
                            Company = row.Cells[1].Value?.ToString(),
                            Location = row.Cells[2].Value?.ToString(),
                            Duration = row.Cells[3].Value?.ToString()
                        });
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving positions: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(positionTbx.Text))
            {
                warningLbl.Text = "Position is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(companyTbx.Text))
            {
                warningLbl.Text = "Company is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(locationTbx.Text))
            {
                warningLbl.Text = "Location is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(durationTbx.Text))
            {
                warningLbl.Text = "Duration is required.";
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            positionTbx.Clear();
            companyTbx.Clear();
            locationTbx.Clear();
            durationTbx.Clear();
        }
    }
}
