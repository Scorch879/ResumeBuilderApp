using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FinalProjectOOP2
{
    public partial class Dashboard : Form
    {
        Color startColor = Color.Transparent;  // Original color
        Color targetColor = Color.LightCyan;         // Target hover color
        Color currentColor;
        bool isHovering = false;
        System.Windows.Forms.Timer colorFadeTimer = new System.Windows.Forms.Timer();
        int fadeSpeed = 10; // Adjust for speed (lower = faster)

        public Dashboard(string user)
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
