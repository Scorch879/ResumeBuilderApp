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
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        public async Task StartLoadingAsync()
        {
            // Example: Simulating real loading steps
            await LoadDatabaseAsync();
            await LoadResourcesAsync();
        }

        private async Task LoadDatabaseAsync()
        {
            // Simulating database connection
            for (int i = 0; i <= 50; i += 10)
            {
                progressBar.Invoke(new Action(() => progressBar.Value = i));
                await Task.Delay(300); // Simulate loading delay
            }
        }

        private async Task LoadResourcesAsync()
        {
            // Simulating resource loading
            for (int i = 50; i <= 100; i += 10)
            {
                progressBar.Invoke(new Action(() => progressBar.Value = i));
                await Task.Delay(300);
            }
        }

        public void UpdateProgress(int value, string message)
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new Action(() =>
                {
                    progressBar.Value = value;
                    loadinglbl.Text = message;
                }));
            }
            else
            {
                progressBar.Value = value;
                loadinglbl.Text = message;
            }
        }
    }
}
