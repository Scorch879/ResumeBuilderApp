using System;
using System.Windows.Forms;

namespace FinalProjectOOP2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           ApplicationConfiguration.Initialize();
            Dashboard dashboard = new Dashboard();
            Application.Run(new Login());
           //Application.Run(new Login());
        }
    }
}