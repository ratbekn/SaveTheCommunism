using System;
using System.Windows.Forms;

namespace SaveTheCommunism
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new RenameMe();
            Application.Run(form);
        }
    }
}
