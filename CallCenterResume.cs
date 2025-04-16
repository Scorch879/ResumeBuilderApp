using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectOOP2
{
    public class ProfessionalExperience
    {
        public string? Title { get; set; }
        public string? Company { get; set; }
        public string? Duration { get; set; }
        public List<string>? Responsibilities { get; set; }

        public ProfessionalExperience()
        {
            Responsibilities = new List<string>();
        }
    }

    public class CallCenterResume : Resume
    {
        public List<ProfessionalExperience> ProfessionalExperience { get; set; }

        public CallCenterResume(string name, string title, string summary)
            : base(name, title, summary)
        {
            ProfessionalExperience = new List<ProfessionalExperience>();
        }

        // Override GenerateHtml to provide specific HTML structure for Call Center Resume
        public override string GenerateHtml()
        {
            StringBuilder html = new StringBuilder();

            html.AppendLine($"<h1>{Name}</h1>");
            html.AppendLine($"<p>{Title}</p>");
            html.AppendLine($"<p>{Summary}</p>");

            html.AppendLine("<h2>Core Skills</h2>");
            foreach (var skill in CoreSkills)
            {
                html.AppendLine($"<p>{skill}</p>");
            }

            html.AppendLine("<h2>Professional Experience</h2>");
            foreach (var experience in ProfessionalExperience)
            {
                html.AppendLine($"<p>{experience.Title} – {experience.Company}</p>");
                html.AppendLine($"<p>{experience.Duration}</p>");
                html.AppendLine("<ul>");
                foreach (var responsibility in experience.Responsibilities)
                {
                    html.AppendLine($"<li>{responsibility}</li>");
                }
                html.AppendLine("</ul>");
            }

            return html.ToString();
        }
    }

    public class CallCenterTemplate : IResumeTemplate
    {
        private TextBox nameTbx = new();
        private TextBox titleTbx = new();
        private TextBox summaryTbx = new();
        private ListBox skillsList = new();
        private ListBox experienceList = new();

        public void LoadFields(TabPage personalInfoTab, TabPage skillsTab, TabPage experienceTab)
        {
            // PERSONAL INFO
            personalInfoTab.Controls.Clear();
            personalInfoTab.Controls.Add(new Label { Text = "Name", Location = new Point(10, 10) });
            nameTbx.Location = new Point(100, 10);
            personalInfoTab.Controls.Add(nameTbx);

            personalInfoTab.Controls.Add(new Label { Text = "Title", Location = new Point(10, 40) });
            titleTbx.Location = new Point(100, 40);
            personalInfoTab.Controls.Add(titleTbx);

            personalInfoTab.Controls.Add(new Label { Text = "Summary", Location = new Point(10, 70) });
            summaryTbx.Location = new Point(100, 70);
            summaryTbx.Size = new Size(300, 80);
            summaryTbx.Multiline = true;
            personalInfoTab.Controls.Add(summaryTbx);

            // SKILLS
            skillsTab.Controls.Clear();
            skillsTab.Controls.Add(new Label { Text = "Core Skills", Location = new Point(10, 10) });
            skillsList.Location = new Point(100, 10);
            skillsList.Size = new Size(200, 100);
            skillsTab.Controls.Add(skillsList);

            // EXPERIENCE
            experienceTab.Controls.Clear();
            experienceTab.Controls.Add(new Label { Text = "Experience", Location = new Point(10, 10) });
            experienceList.Location = new Point(100, 10);
            experienceList.Size = new Size(300, 100);
            experienceTab.Controls.Add(experienceList);
        }

        public Resume GetResumeData()
        {
            var resume = new CallCenterResume(nameTbx.Text, titleTbx.Text, summaryTbx.Text);

            foreach (var item in skillsList.Items)
                resume.CoreSkills.Add(item.ToString());

            foreach (var item in experienceList.Items)
                resume.ProfessionalExperience.Add(new ProfessionalExperience
                {
                    Title = item.ToString(),
                    Company = "Company Name Placeholder"
                });

            return resume;
        }

    }
}
