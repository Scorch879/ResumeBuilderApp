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
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;

namespace FinalProjectOOP2
{
    public partial class ResumePreviewForm : Form
    {
        private string? tempProfilePicPath;

        public ResumePreviewForm()
        {
            InitializeComponent();
            InitializeWebView();
        }

        private async void InitializeWebView()
        {
            try
            {
                await resumePreview.EnsureCoreWebView2Async();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize WebView2: {ex.Message}");
            }
        }

        public async void LoadResumePreview(object resumeData, string templateFileName)
        {
            try
            {
                // Ensure WebView2 is initialized
                if (resumePreview.CoreWebView2 == null)
                {
                    await resumePreview.EnsureCoreWebView2Async();
                }

                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = $"FinalProjectOOP2.Resources.Templates.{templateFileName}";

                using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                        throw new FileNotFoundException($"Template not found: {resourceName}");

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        var templateContent = reader.ReadToEnd();
                        var template = Scriban.Template.Parse(templateContent);

                        // Create a dictionary with the resume data and profile picture path
                        var templateData = new Dictionary<string, object>();

                        // Copy all properties from resumeData to templateData
                        foreach (var prop in resumeData.GetType().GetProperties())
                        {
                            if (prop.Name != "FirstName" && prop.Name != "MiddleName" && prop.Name != "LastName")
                            {
                                var value = prop.GetValue(resumeData);
                                if (value != null)
                                {
                                    templateData[prop.Name] = value;
                                }
                            }
                        }

                        // Always get the profile picture from PersonalInfo (current user)
                        string? currentUsername = null;
                        if (resumeData is PersonalInfo pi && !string.IsNullOrEmpty(pi.Email))
                        {
                            // Try to get username from the resumeData if possible
                            currentUsername = pi.Email;
                        }
                        else if (resumeData.GetType().GetProperty("CurrentUsername") != null)
                        {
                            currentUsername = resumeData.GetType().GetProperty("CurrentUsername")?.GetValue(resumeData)?.ToString();
                        }
                        // Fallback: try to get from a static/global if you have one
                        // currentUsername = AppGlobals.CurrentUsername ?? currentUsername;

                        byte[]? profilePicBytes = null;
                        if (!string.IsNullOrEmpty(currentUsername))
                        {
                            var db = new ResumeDatabase();
                            int userId = db.GetCurrentUserID(currentUsername);
                            var personalInfo = db.LoadPersonalInfo(userId);
                            profilePicBytes = personalInfo?.ProfilePic;
                        }

                        if (profilePicBytes != null && profilePicBytes.Length > 0)
                        {
                            string base64String = Convert.ToBase64String(profilePicBytes);
                            string mimeType = GetImageMimeType(profilePicBytes);
                            templateData["ProfilePicPath"] = $"data:{mimeType};base64,{base64String}";
                        }
                        else
                        {
                            templateData["ProfilePicPath"] = "Assets/default-profile.png";
                        }

                        var htmlOutput = template.Render(templateData);
                        resumePreview.NavigateToString(htmlOutput);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Preview failed: {ex.Message}");
            }
        }

        private string GetImageMimeType(byte[] imageBytes)
        {
            // Check the first few bytes to determine the image type
            if (imageBytes.Length >= 2)
            {
                if (imageBytes[0] == 0xFF && imageBytes[1] == 0xD8)
                    return "image/jpeg";
                if (imageBytes[0] == 0x89 && imageBytes[1] == 0x50)
                    return "image/png";
                if (imageBytes[0] == 0x47 && imageBytes[1] == 0x49)
                    return "image/gif";
            }
            return "image/jpeg"; // Default to JPEG if unknown
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            
            // Clean up temporary files
            try
            {
                if (File.Exists(tempProfilePicPath))
                {
                    File.Delete(tempProfilePicPath);
                }
            }
            catch { }
        }
    }
}
