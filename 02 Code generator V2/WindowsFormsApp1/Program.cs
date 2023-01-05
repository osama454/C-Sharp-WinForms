using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        
        static void Main(String[] args)
        {
            if (args != null && args.Length > 0)
            {
                String[] files = args;
                FilenNames = args;
                Form1 mf = new Form1();
                // mf.IsArgumentNull = false;
                //mf.OpenAssociatedFiles_WhenApplicationStarts(files);
                Application.EnableVisualStyles();
                
                Application.Run(mf);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
               Application.Run(new Form1());
            // Application.Run(new Form2());
            }
        }
        public static string[] FilenNames;
    }
}
