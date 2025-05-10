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
    public partial class TitleInputDialog : Form
    {
        public string ResumeTitle { get; private set; }

        public TitleInputDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(resumeTitleTbx.Text))
            {
                MessageBox.Show("Please enter a title.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ResumeTitle = resumeTitleTbx.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
