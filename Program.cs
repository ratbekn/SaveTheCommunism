//namespace SaveTheCommunism
//{
//    internal class Program
//    {
//        public static void Main(string[] args)
//        {
//        }
//    }
//}

using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveTheCommunism
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new GameForm();
            Application.Run(form);
        }
    }
}
