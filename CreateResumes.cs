using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FinalProjectOOP2
{
    public partial class CreateResumes : UserControl, ICurrentUsername
    {

        private SavingForm? savingForm;
        private DatabaseHelper? dbHelper;
        private string? currentUser;
        public string? selectedTemplate => templateSelector?.SelectedItem?.ToString();
        public string? CurrentUsername
        {
            get => currentUser;
            set => currentUser = value;
        }

        public CreateResumes()
        {
            InitializeComponent();
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
                else
                {
                    MessageBox.Show("Preview not available for this resume type yet.");
                }
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class PersonalInfo //only constant between templates that does not get changed since it is personal info
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }
    }

}
