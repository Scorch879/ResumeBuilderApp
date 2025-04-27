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
    public partial class ContributionForm : Form
    {
        public List<string> Contributions { get; private set; } = new();

        public ContributionForm(List<string>? existingContributions = null)
        {
            InitializeComponent();
            if (existingContributions != null)
                foreach (var contrib in existingContributions)
                    contributionsListBox.Items.Add(contrib);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(contributionTextBox.Text))
            {
                contributionsListBox.Items.Add(contributionTextBox.Text.Trim());
                contributionTextBox.Clear();
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            var toRemove = contributionsListBox.SelectedItems.Cast<object>().ToList();
            foreach (var item in toRemove)
            {
                contributionsListBox.Items.Remove(item);
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            Contributions = contributionsListBox.Items.Cast<string>().ToList();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
