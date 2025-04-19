using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FinalProjectOOP2
{
    public partial class CreateResumes : UserControl, ICurrentUsername
    {
        ListBox? listCore, listTech, listLang, listInterests, listEdu, listResp, listCourse, listExperienceBlocks;
        TextBox? txtDegree, txtSchool, txtLocation, txtYear;
        TextBox? txtJobTitle, txtCompany, txtExpLocation, txtDuration, txtResponsibility, txtAchievement;
        TextBox? txtCoreSkill, txtTechSkill, txtLang, txtInterest, txtCourse;
        Button? btnAddExp;

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

            UserControl? selectedControl = null;

            switch (selectedTemplate)
            {
                case "Call Center Resume":
                    selectedControl = new CallCenterResume();
                    break;
                case "Engineer Resume":
//                    selectedControl = new EngineerResumeControl();
                    break;
                    // Add more cases...
            }

            if (selectedControl != null)
            {
                selectedControl.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(selectedControl);
            }
        }

        private void previewResume_Click(object sender, EventArgs e)
        {
            string resumeHtml = "<html> ... </html>";  // Replace with actual generated HTML
            ResumePreviewForm previewForm = new ResumePreviewForm(resumeHtml);
            previewForm.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public abstract class Resume
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public List<string> CoreSkills { get; set; }
        public List<string> Education { get; set; }
        public List<string> Languages { get; set; }
        public List<string> Interests { get; set; }

        public Resume(string name, string title, string summary)
        {
            Name = name;
            Title = title;
            Summary = summary;
            CoreSkills = new List<string>();
            Education = new List<string>();
            Languages = new List<string>();
            Interests = new List<string>();
        }

        public abstract string GenerateHtml();
    }
}
