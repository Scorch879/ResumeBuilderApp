using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static FinalProjectOOP2.ResumeDatabase;

namespace FinalProjectOOP2
{
    public partial class CreateResumes : UserControl, ICurrentUsername
    {
        private bool templateChosen = false;
        private SavingForm? savingForm;
        private DatabaseHelper? dbHelper;
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
            loadResumeBtn.Enabled = false;
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
                // Hide the center panel
                templatePanel.Visible = false;

                // Show the top right ComboBox
                templatePanelCorner.Visible = true;

                // Set the selected item to match
                templateSelector.SelectedItem = centerTemplateSelectorCbx.SelectedItem;

                saveResume.Enabled = true;
                previewResume.Enabled = true;
                loadResumeBtn.Enabled = true;
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
                    selectedControl = new CallCenterResume();
                    break;
                case "Electrical Engineer Resume":
                    selectedControl = new ElectricalEngineeringTemplate();
                    break;
                case "Doctor Resume":
                    selectedControl = new DoctorResume();
                    break;
                case "Attorney Resume":
                    selectedControl = new AttorneyResume();
                    break;
                case "Academic Resume":
                    selectedControl = new AcademicResume();
                    break;
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
