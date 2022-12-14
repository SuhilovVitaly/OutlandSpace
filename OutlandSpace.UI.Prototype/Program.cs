using System;
using System.Windows.Forms;

namespace OutlandSpace.UI.Prototype
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ScreenCommonDialog(Global.GetGameSnapshot(), Global.GetDialog()));
            Application.Run(new ScreenSpacecraftCompartments(Global.GetSpacecraft()));
        }
    }
}
