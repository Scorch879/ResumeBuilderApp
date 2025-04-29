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

                            if (saveable.SaveResume(CurrentUsername, resumeTitle))
                            {
                                ResumeDB = new ResumeDatabase();
                                currentUserID = ResumeDB.GetCurrentUserID(currentUser);
                                ResumeDB.IncrementResumesCreatedAndSaved(currentUserID);
                                MessageBox.Show("Resume saved successfully!");

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

            // Create a custom form
            var selectForm = new Form { Text = "Select Resume", Width = 600, Height = 400, StartPosition = FormStartPosition.CenterParent };
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                DataSource = resumes,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            //dgv.Columns["FilePath"].Visible = false; // Hide FilePath if not needed

           //Search
            var searchBox = new TextBox { Dock = DockStyle.Top, PlaceholderText = "Search by title..." };
            searchBox.TextChanged += (s, ev) =>
            {
                dgv.DataSource = resumes
                    .Where(r => r.Title != null && r.Title.IndexOf(searchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            };

            // Load button
            var okBtn = new Button { Text = "Load", Dock = DockStyle.Bottom, Height = 40, DialogResult = DialogResult.OK };
            selectForm.Controls.Add(dgv);
            selectForm.Controls.Add(searchBox);
            selectForm.Controls.Add(okBtn);

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
                }
                else
                {
                    MessageBox.Show("Please select a resume to load.");
                    selectForm.DialogResult = DialogResult.None;
                }
            };

            if (selectForm.ShowDialog() == DialogResult.OK && selectedResume != null)
            {
                LoadTemplateForResume(selectedResume.TemplateType);

                if (contentPanel.Controls.Count > 0)
                {
                    var control = contentPanel.Controls[0];
                    if (control is ResumeDatabase.IResumeSaveable saveable)
                    {
                        saveable.LoadResume(selectedResume);
                        saveResume.Enabled = true;
                        previewResume.Enabled = true;
                    }
                }
            }
        }

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
                    break;
                case "CallCenter":
                    templateControl = new CallCenterResume();
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