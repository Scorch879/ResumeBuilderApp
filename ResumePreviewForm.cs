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
    public partial class ResumePreviewForm : Form
    {
        public ResumePreviewForm(string htmlContent)
        {
            InitializeComponent();
            LoadHtml(htmlContent);
        }

        private async void LoadHtml(string html)
        {
            await resumePreview.EnsureCoreWebView2Async();
            resumePreview.NavigateToString(html);
        }

    }
}
