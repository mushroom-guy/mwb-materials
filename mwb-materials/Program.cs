using mwb_materials.MwbMats;
using System;
using System.Windows.Forms;

namespace mwb_materials
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        unsafe static void Main()
        {
            VtfLib.vlInitialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Console.ReadLine();
        }
    }
}
