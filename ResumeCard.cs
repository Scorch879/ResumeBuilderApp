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
    public partial class ResumeCard : UserControl
    {
        public event EventHandler? EditClicked;
        public event EventHandler? DeleteClicked;

        public ResumeSummary? Summary { get; }

        public ResumeCard(ResumeSummary summary)
        {
        

            InitializeComponent();
            Summary = summary;

            lblTitle.Text = summary.Title;
            lblDate.Text = $"Date Modified: {summary.DateModified:yyyy-MM-dd}";
            lblStatus.Text = $"Status: {(summary.FilePath?.ToLower().Contains("final") == true ? "Final" : "Draft")}";

            btnDelete.Click += (s, e) => DeleteClicked?.Invoke(this, EventArgs.Empty);
        }       
    }
}