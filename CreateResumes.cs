using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Windows.ApplicationModel.Contacts;
using static FinalProjectOOP2.ResumeDatabase;

namespace FinalProjectOOP2
{
    public partial class CreateResumes : UserControl, ICurrentUsername
    {
        private bool templateChosen = false;
        private SavingForm? savingForm;
        private DatabaseHelper? dbHelper;
        private ResumeDatabase? ResumeDB;
        private int currentUserID;

        private string? currentUser;
        public string? selectedTemplate => templateSelector?.SelectedItem?.ToString();
        public string? CurrentUsername
        {
            get => currentUser;
            set => currentUser = value;
        }

        public int CurrentUserID
        {
            get => currentUserID;
            set => currentUserID = value;
        }

        public CreateResumes()
        {
            InitializeComponent();

            CenterTemplateSelector();
            templatePanelCorner.Visible = false;
            saveResume.Enabled = false;
            previewResume.Enabled = false;
        }
        
        private void CenterTemplateSelector()
        {

            Panel centerTemplatePanel = templatePanel;

            centerTemplatePanel.Location = new Point(
                (contentPanel.Width - templatePanel.Width) / 2,
                (contentPanel.Height - templatePanel.Height) / 2
            );


            contentPanel.Resize += (s, e) =>
            {
                if (templatePanel.Parent == contentPanel)
                {
                    templatePanel.Location = new Point(
                        (contentPanel.Width - templatePanel.Width) / 2,
                        (contentPanel.Height - templatePanel.Height) / 2
                    );
                }
            };
        }

        private void centerTemplateSelectorCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (centerTemplateSelectorCbx.SelectedIndex >= 0)
            {
                templatePanel.Visible = false;

                templatePanelCorner.Visible = true;

                templateSelector.SelectedItem = centerTemplateSelectorCbx.SelectedItem;

                saveResume.Enabled = true;
                previewResume.Enabled = true;

            }
        }

        private void templateSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();

            string? selectedTemplate = templateSelector.SelectedItem?.ToString();
            UserControl? selectedControl = null;

            switch (selectedTemplate)
            {
                case "Call Center Resume":
                    var callCenterResume = new CallCenterResume();
                    callCenterResume.CurrentUsername = currentUser;
                    callCenterResume.LoadExistingPersonalInfo();
                    selectedControl = callCenterResume;

                    break;
                case "Electrical Engineer Resume":

                    var eeResume = new ElectricalEngineeringTemplate();
                    eeResume.CurrentUsername = currentUser;
                    eeResume.LoadExistingPersonalInfo();
                    selectedControl = eeResume;

                    break;

                case "Doctor Resume":
                    var doctorResume = new DoctorResume();
                    doctorResume.CurrentUsername = currentUser;
                    doctorResume.LoadExistingPersonalInfo();
                    selectedControl = doctorResume;

                    break;

                case "Attorney Resume":
                    var attorneyResume = new AttorneyResume();
                    attorneyResume.CurrentUsername = currentUser;
                    attorneyResume.LoadPersonalInfo();
                    selectedControl = attorneyResume;

                    break;
                //case "Academic Resume":
                //    selectedControl = new AcademicResume();
                //    break;
                default:
                    MessageBox.Show("Unknown template selected.");
                    break;
            }

            if (selectedControl != null)
            {
                selectedControl.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(selectedControl);
            }
        }

        #region Button Click Event Handlers
        private void previewResume_Click(object sender, EventArgs e)
        {
            if (contentPanel.Controls.Count > 0)
            {
                var activeControl = contentPanel.Controls[0];

                // Check if the active control is CallCenterResume
                if (activeControl is CallCenterResume callCenterControl)
                {
                    callCenterControl.PreviewResume();
                }
                else if (activeControl is ElectricalEngineeringTemplate electricalEngrControl)
                {
                    electricalEngrControl.PreviewResume();
                }
                else if (activeControl is DoctorResume doctorResume)
                {
                    doctorResume.PreviewResume();
                }
                else if (activeControl is AttorneyResume attorneyResume)
                {
                    attorneyResume.PreviewResume();
                }
                else
                {
                    MessageBox.Show("Preview not available for this resume type yet.");
                }
            }
        }

        private void saveResume_Click(object sender, EventArgs e)
        {
            if (contentPanel.Controls.Count > 0 && !string.IsNullOrEmpty(CurrentUsername))
            {
                var activeControl = contentPanel.Controls[0];

                if (activeControl is IResumeSaveable saveable)
                {

                    using (var dialog = new TitleInputDialog())
                    {
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            string resumeTitle = dialog.ResumeTitle;

                            if (saveable.SaveResume(CurrentUsername, resumeTitle) && currentUser != null)
                            {
                                ResumeDB = new ResumeDatabase();
                                currentUserID = ResumeDB.GetCurrentUserID(currentUser);
                                ResumeDB.IncrementResumesCreatedAndSaved(currentUserID);
                                MessageBox.Show("Resume saved successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        // else: user cancelled, do nothing
                    }
                }
                else
                {
                    MessageBox.Show("Saving not implemented for this resume type yet.");
                }
            }
            else
            {
                MessageBox.Show("Please select a template first or ensure you are logged in.");
            }
        }

        private void loadResumeBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentUsername))
            {
                MessageBox.Show("No user logged in.");
                return;
            }

            var db = new ResumeDatabase();
            int ownerId = db.GetCurrentUserID(CurrentUsername);
            var resumes = db.GetAllResumesForUser(ownerId);

            // Create a custom form with project's design style
            var selectForm = new Form 
            { 
                Text = "Select Resume", 
                Width = 800, 
                Height = 600, 
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.FromArgb(216, 225, 233),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            // Create header panel
            var headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(41, 128, 185)
            };

            var headerLabel = new Label
            {
                Text = "Select a Resume to Load",
                Font = new Font("Century Gothic", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            headerPanel.Controls.Add(headerLabel);

            // Create search panel
            var searchPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                Padding = new Padding(10)
            };

            var searchBox = new TextBox 
            { 
                Dock = DockStyle.Fill,
                Font = new Font("Century Gothic", 12),
                PlaceholderText = "Search by title...",
                BorderStyle = BorderStyle.FixedSingle
            };

            // Create DataGridView with project's design
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                DataSource = resumes,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.FromArgb(216, 225, 233),
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                Font = new Font("Century Gothic", 12),
                CellBorderStyle = DataGridViewCellBorderStyle.None,
                GridColor = Color.FromArgb(216, 225, 233)
            };

            dgv.RowTemplate.Height = 40; // Set row height for better readability

            // Style the DataGridView
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 31, 84);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 235, 240);
            dgv.RowsDefaultCellStyle.Padding = new Padding(5);

            // Hide columns and set headers after data binding
            dgv.DataBindingComplete += (s, ev) =>
            {
                if (dgv.Columns.Contains("FilePath")) dgv.Columns["FilePath"].Visible = false;
                if (dgv.Columns.Contains("ResumeID")) dgv.Columns["ResumeID"].Visible = false;
                if (dgv.Columns.Contains("DateModified")) dgv.Columns["DateModified"].HeaderText = "Date Modified";
                if (dgv.Columns.Contains("DateCreated")) dgv.Columns["DateCreated"].HeaderText = "Date Created";
                if (dgv.Columns.Contains("TemplateType")) dgv.Columns["TemplateType"].HeaderText = "Template Type";
                if (dgv.Columns.Contains("Title")) dgv.Columns["Title"].HeaderText = "Resume Title";
            };

            // Create button panel
            var buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                Padding = new Padding(10)
            };

            var okBtn = new Button 
            { 
                Text = "Load",
                Font = new Font("Century Gothic", 12),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(41, 128, 185),
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Right,
                Width = 100,
                Height = 40
            };

            var cancelBtn = new Button
            {
                Text = "Cancel",
                Font = new Font("Century Gothic", 12),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(41, 128, 185),
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Right,
                Width = 100,
                Height = 40,
                Margin = new Padding(0, 0, 10, 0)
            };

            // Add controls to panels
            searchPanel.Controls.Add(searchBox);
            buttonPanel.Controls.Add(okBtn);
            buttonPanel.Controls.Add(cancelBtn);

            // Add panels to form
            selectForm.Controls.Add(dgv);
            selectForm.Controls.Add(searchPanel);
            selectForm.Controls.Add(headerPanel);
            selectForm.Controls.Add(buttonPanel);

            // Search functionality
            searchBox.TextChanged += (s, ev) =>
            {
                dgv.DataSource = resumes
                    .Where(r => r.Title != null && r.Title.IndexOf(searchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            };

            ResumeSummary? selectedResume = null;

            // Double-click to select
            dgv.CellDoubleClick += (s, ev) =>
            {
                if (ev.RowIndex >= 0)
                {
                    selectedResume = dgv.Rows[ev.RowIndex].DataBoundItem as ResumeSummary;
                    selectForm.DialogResult = DialogResult.OK;
                    selectForm.Close();
                }
            };

            // Load button click
            okBtn.Click += (s, ev) =>
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    selectedResume = dgv.SelectedRows[0].DataBoundItem as ResumeSummary;
                    selectForm.DialogResult = DialogResult.OK;
                    selectForm.Close();
                }
                else
                {
                    MessageBox.Show("Please select a resume to load.");
                }
            };

            // Cancel button click
            cancelBtn.Click += (s, ev) =>
            {
                selectForm.DialogResult = DialogResult.Cancel;
                selectForm.Close();
            };

            if (selectForm.ShowDialog() == DialogResult.OK && selectedResume != null && selectedResume.TemplateType != null)
            {
                LoadTemplateForResume(selectedResume.TemplateType);

                if (contentPanel.Controls.Count > 0)
                {
                    var control = contentPanel.Controls[0];
                    if (control is IResumeSaveable saveable)
                    {
                        saveable.LoadResume(selectedResume);
                        saveResume.Enabled = true;
                        previewResume.Enabled = true;
                    }
                }
            }
        }

        #endregion

        public void LoadTemplateForResume(string templateType)
        { 
            contentPanel.Controls.Clear();

            UserControl? templateControl = null;
            switch (templateType)
            {
                case "Attorney":
                    templateControl = new AttorneyResume();
                   
                    break;
                case "Doctor":
                    templateControl = new DoctorResume();
                    break;
                case "ElectricalEngineering":
                    templateControl = new ElectricalEngineeringTemplate();
                    templateType = "Electrical Engineer";
                    break;
                case "CallCenter":
                    templateControl = new CallCenterResume();
                    templateType = "Call Center";
                    break;

                default:
                    MessageBox.Show($"Unknown or unsupported template type: {templateType}");
                    return;
            }
            
            if (templateControl != null)
            {
                templateControl.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(templateControl);

                // Hide the center selection panel if it's still visible
                templatePanel.Visible = false;
                templatePanelCorner.Visible = true; // Show the corner selector
                                                    // Optionally set the corner selector's value
                templateSelector.Text = $"{templateType} Resume";

                if (templateSelector.Items.Contains(templateType))
                {
                    templateSelector.SelectedItem = templateType;
                }
            }
        }

        private void seeSampleBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string? selectedTemplate = templateSelector.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedTemplate))
                {
                    MessageBox.Show("Please select a template first.");
                    return;
                }

                // Create a sample resume data object based on the selected template
                var sampleData = new PersonalInfo
                {
                    FirstName = "John",
                    MiddleName = "William",
                    LastName = "Doe",
                    Title = "Sample Title",
                    Email = "sample@email.com",
                    Phone = "123-456-7890",
                    Address = "Sample Address",
                    Summary = "Sample Summary"
                };

                // Load the sample template
                var previewForm = new ResumePreviewForm();
                previewForm.LoadResumePreview(sampleData, GetSampleTemplateFileName(selectedTemplate));
                previewForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load sample template: {ex.Message}");
            }
        }

        private string GetSampleTemplateFileName(string templateType)
        {
            switch (templateType)
            {
                case "Call Center Resume":
                    return "SampleCallCenter.html";
                case "Doctor Resume":
                    return "SampleDoctorTemplate.html";
                case "Attorney Resume":
                    return "SampleAttorneyTemplate.html";
                case "Electrical Engineer Resume":
                    return "SampleEETemplate.html";
                default:
                    return "Sample.html"; // fallback or handle as needed
            }
        }

    }

    public class PersonalInfo //only constant between templates that does not get changed since it is personal info
    {
        public int OwnerID { get; set; }

        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }

        public byte[]? ProfilePic { get; set; } // Add this property for profile picture
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