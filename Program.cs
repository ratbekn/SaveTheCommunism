using System;
using System.Windows.Forms;
using SaveTheCommunism.View;

namespace SaveTheCommunism
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Square());
        }
    }
}
