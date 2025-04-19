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

namespace FinalProjectOOP2
{
    public partial class CallCenterResume : UserControl
    {
        public CallCenterResume()
        {
            InitializeComponent();
        }
    }

    public class CallCenter : Resume
    {
        public List<ProfessionalExperience> ProfessionalExperiences { get; set; }
        public List<string> TechSkills { get; set; }
        public List<Education> EducationEntry { get; set; }
        public List<string> Courses { get; set; }

        // Constructor simplified
        public CallCenter(string name, string title, string summary)
            : base(name, title, summary)
        {
            ProfessionalExperiences = new List<ProfessionalExperience>();
            TechSkills = new List<string>();
            EducationEntry = new List<Education>();
            Courses = new List<string>();
        }

        // Override GenerateHtml to provide specific HTML structure for Call Center Resume
        public override string GenerateHtml()
        {
            try
            {
                // Load the HTML template
                string template = System.IO.File.ReadAllText("CallCenterResumeTemplate.html");

                // Prepare data for template
                var resumeData = new
                {
                    Name = Name,
                    Title = Title,
                    Summary = Summary,
                    TechSkills = TechSkills,
                    Education = EducationEntry,
                    Experience = ProfessionalExperiences.Select(pe => new
                    {
                        Title = pe.Title,
                        Company = pe.Company,
                        Location = pe.Location ?? "Sometown, FL",  // Optional location
                        Duration = pe.Duration,
                        Responsibilities = pe.Responsibilities,
                        Achievement = pe.Achievement ?? "Example achievement" // Replace if actual data
                    }),
                    Courses = Courses
                };

                // Render the template
                var templateContext = new TemplateContext();
                string htmlOutput = Template.Parse(template).Render(resumeData);
                return htmlOutput;
            }
            catch (Exception ex)
            {
                // Handle any errors in reading the template or rendering it
                MessageBox.Show($"Error generating resume: {ex.Message}");
                return string.Empty;
            }
        }
    }

    public class ProfessionalExperience
    {
        public string? Title { get; set; }
        public string? Company { get; set; }
        public string? Location { get; set; }  // Allow dynamic location
        public string? Duration { get; set; }
        public List<string>? Responsibilities { get; set; }
        public string? Achievement { get; set; }  // Allow for dynamic achievement

        public ProfessionalExperience()
        {
            Responsibilities = new List<string>();
        }
    }

    public class Education
    {
        public string? Degree { get; set; }
        public string? School { get; set; }
        public string? Location { get; set; }
        public string? Year { get; set; }
    }
}
