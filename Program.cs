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
            //Application.Run(new Dashboard(""));
           Application.Run(new Login());

        }
    }
}