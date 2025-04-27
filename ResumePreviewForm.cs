using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scriban;
using System.IO;
using System.Reflection;

namespace FinalProjectOOP2
{
    public partial class ResumePreviewForm : Form
    {
        public ResumePreviewForm()
        {
            InitializeComponent();
        }

        public void LoadResumePreview(object resumeData, string templateFileName)
        {
            try
            {

                var resourceName = $"FinalProjectOOP2.Resources.Templates.{templateFileName}";
                var assembly = Assembly.GetExecutingAssembly();

                using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                        throw new FileNotFoundException("Template not found: " + resourceName);

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        var templateContent = reader.ReadToEnd();
                        var template = Scriban.Template.Parse(templateContent);



                        var htmlOutput = template.Render(resumeData, member => member.Name);

                        string tempPath = Path.Combine(Path.GetTempPath(), "resume_preview.html");
                        File.WriteAllText(tempPath, htmlOutput);

                        resumePreview.Source = new Uri(tempPath); // Assuming WebView2 or similar
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Preview failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
