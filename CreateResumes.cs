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

    public interface IResumeTemplate
    {
        void LoadFields(TabPage personalInfoTab, TabPage skillsTab, TabPage experienceTab);
        Resume GetResumeData();
    }

    public partial class CreateResumes : UserControl, ICurrentUsername
    {
        private SavingForm? savingForm;
        private DatabaseHelper? dbHelper;
        private string? currentUser;
        public string? SelectedTemplateType => templateSelector?.SelectedItem?.ToString();

        public string? CurrentUsername
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
            }
        }

        public CreateResumes()
        {
            InitializeComponent();
        }

        private void templateSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selected = SelectedTemplateType;

            if (selected == "Call Center Resume")
            {

            }
        }

        /*private void saveResume_Click(object sender, EventArgs e)
        {
            try
            {
                dbHelper = new DatabaseHelper();

                if (string.IsNullOrEmpty(currentUser))
                    throw new Exception("No user logged in");

                // Input validation
                if (string.IsNullOrWhiteSpace(firstNameTbx.Text))
                {
                    MessageBox.Show("First name is required");
                    return;
                }

                if (string.IsNullOrWhiteSpace(emailTbx.Text) || !dbHelper.isValidEmail(emailTbx.Text))
                {
                    MessageBox.Show("Valid email is required");
                    return;
                }

                int currentUserId = dbHelper.GetCurrentUserID(currentUser);

                if (currentUserId == 0)
                    throw new Exception("User not found");

                bool success = new ResumeDatabase().SavePersonalInfo(
                    ownerId: currentUserId,
                    firstName: firstNameTbx.Text.Trim(),
                    middleName: middleNameTbx.Text.Trim(),
                    lastName: lastNameTbx.Text.Trim(),
                    email: emailTbx.Text.Trim(),
                    phoneNum: phoneNumTbx.Text.Trim(),
                    address: addressTbx.Text.Trim(),
                    designation: designationTbx.Text.Trim(),
                    summary: summaryTbx.Text.Trim()
                );

                MessageBox.Show(success ? "Personal info saved successfully!" : "No changes were made");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        } */


        private void saveResume_Click(object sender, EventArgs e)
        {
            try
            {
                dbHelper = new DatabaseHelper();

                if (string.IsNullOrEmpty(currentUser))
                    throw new Exception("No user logged in");

                // Input validation
                if (string.IsNullOrWhiteSpace(firstNameTbx.Text))
                {
                    MessageBox.Show("First name is required");
                    return;
                }

                if (string.IsNullOrWhiteSpace(emailTbx.Text) || !dbHelper.isValidEmail(emailTbx.Text))
                {
                    MessageBox.Show("Valid email is required");
                    return;
                }

                int currentUserId = dbHelper.GetCurrentUserID(currentUser);

                if (currentUserId == 0)
                    throw new Exception("User not found");

                // Based on the selected template, create the corresponding resume
                Resume resume = CreateResumeBasedOnTemplate();

                if (resume != null)
                {
                    // Save the generated resume or display the HTML
                    string generatedHtml = resume.GenerateHtml();
                    MessageBox.Show("Resume generated successfully!");
                    // Optionally, you could display the HTML in a WebView, or save it as a file, etc.
                }
                else
                {
                    MessageBox.Show("Invalid template selected");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private Resume CreateResumeBasedOnTemplate()
        {
            // Get the selected template
            string selectedTemplate = SelectedTemplateType ?? string.Empty;

            Resume? resume = null;

            // Here you can check the selected template and create the appropriate resume
            switch (selectedTemplate)
            {
                case "Call Center":
                    resume = CreateCallCenterResume();
                    break;
                case "Engineering":
                  //  resume = CreateEngineeringResume();
                    break;
                case "Doctor":
                   // resume = CreateDoctorResume();
                    break;
                // Add more cases for other templates as needed
                default:
                    MessageBox.Show("Template not recognized.");
                    break;
            }

            return resume;
        }

        private CallCenterResume CreateCallCenterResume()
        {
            // Create a CallCenterResume instance
            CallCenterResume resume = new CallCenterResume(
                firstNameTbx.Text, // Assuming you have firstNameTbx on your form
                titleTbx.Text, // Assuming titleTbx is the title text box
                summaryTbx.Text // Assuming summaryTbx is the summary text box
            );

            // Add other details such as core skills, professional experience, etc.
            resume.CoreSkills.Add("Customer Support");
            resume.CoreSkills.Add("Communication");
            resume.CoreSkills.Add("Problem Solving");

            resume.ProfessionalExperience.Add(new ProfessionalExperience
            {
                Title = "Call Center Representative",
                Company = "XYZ Corp",
                Duration = "2019 - Present",
                Responsibilities = new List<string>
                {
                    "Handle customer inquiries and complaints",
                    "Provide product information",
                    "Resolve customer issues"
                }
            });

            return resume;
        }

       /* private ElectricalEngineeringResume CreateEngineeringResume()
        {
            // Similarly, create the EngineeringResume object with relevant data
            // Implement similarly to CreateCallCenterResume method
            return new EngineeringResume("John Doe", "Software Engineer", "Passionate engineer with a focus on software development.");
        }

        private DoctorResume CreateDoctorResume()
        {
            // Similarly, create the DoctorResume object with relevant data
            // Implement similarly to CreateCallCenterResume method
            return new DoctorResume("Dr. Jane Smith", "Cardiologist", "Experienced Cardiologist with over 10 years in healthcare.");
        } */


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

        // Abstract method to be implemented in subclasses
        public abstract string GenerateHtml();
    }

}
