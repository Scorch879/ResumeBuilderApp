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

                        // Recursively convert resumeData to a dictionary
                        var templateData = ObjectToDictionary(resumeData);

                        // Always get the profile picture from PersonalInfo (current user)
                        string? currentUsername = null;
                        if (resumeData is PersonalInfo pi && !string.IsNullOrEmpty(pi.Email))
                        {
                            currentUsername = pi.Email;
                        }

                        else if (resumeData.GetType().GetProperty("CurrentUsername") != null)
                        {
                            currentUsername = resumeData.GetType().GetProperty("CurrentUsername")?.GetValue(resumeData)?.ToString();
                        }

                        // Always get the profile picture from the resume data first, then fallback to DB
                        byte[]? profilePicBytes = null;

                        // 1. Try to get from resumeData if it has a ProfilePic property
                        var profilePicProp = resumeData.GetType().GetProperty("ProfilePic");
                        if (profilePicProp != null)
                        {
                            profilePicBytes = profilePicProp.GetValue(resumeData) as byte[];
                        }

                        // 2. If not found, get from DB using currentUsername
                        if ((profilePicBytes == null || profilePicBytes.Length == 0) && !string.IsNullOrEmpty(currentUsername))
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

        // Recursively convert an object to a dictionary for Scriban
        private Dictionary<string, object> ObjectToDictionary(object obj)
        {
            var dict = new Dictionary<string, object>();
            if (obj == null) return dict;
            var type = obj.GetType();
            foreach (var prop in type.GetProperties())
            {
                if (prop.Name == "FirstName" || prop.Name == "MiddleName" || prop.Name == "LastName")
                    continue;
                var value = prop.GetValue(obj);
                if (value == null) continue;
                if (value is string || value.GetType().IsValueType)
                {
                    dict[prop.Name] = value;
                }
                else if (value is System.Collections.IEnumerable enumerable && !(value is string))
                {
                    var list = new List<object>();
                    foreach (var item in enumerable)
                    {
                        if (item == null) continue;
                        if (item is string || item.GetType().IsValueType)
                        {
                            list.Add(item);
                        }
                        else
                        {
                            list.Add(ObjectToDictionary(item));
                        }
                    }
                    dict[prop.Name] = list;
                }
                else // nested object
                {
                    dict[prop.Name] = ObjectToDictionary(value);
                }
            }
            return dict;
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
