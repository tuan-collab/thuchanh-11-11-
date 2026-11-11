using System;
using System.Windows.Forms;
using HRMManagement.GUI;

namespace HRMManagement
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormHRM());
        }
    }
}