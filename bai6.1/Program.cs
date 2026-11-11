using System;
using System.Windows.Forms;
using SalesManagement.GUI;

namespace SalesManagement
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormBanHang());
        }
    }
}