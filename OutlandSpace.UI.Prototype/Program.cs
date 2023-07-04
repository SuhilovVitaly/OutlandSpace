using System;
using System.Windows.Forms;
using OutlandSpace.UI.Prototype.InternalUniverse.Engine;

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
            //Application.Run(new ScreenSpacecraftCompartments(Global.GetSpacecraft()));
            //var x = ("generation_key");

            //var baseRandom = 415006353; //x.GetHashCode();

            //var baseRandom1 = x.GetHashCode();
            //var baseRandom2 = x.GetHashCode();
            //var baseRandom3 = x.GetHashCode();



            //Random RandomBase1 = new Random(baseRandom);
            //Random RandomBase2 = new Random(baseRandom);

            //var x1 = RandomBase1.Next(10);
            //var x2 = RandomBase2.Next(10);

            //var y1 = RandomBase1.Next(100);
            //var y2 = RandomBase2.Next(100);

            //var z1 = RandomBase1.NextDouble();
            //var z2 = RandomBase2.NextDouble();

            //GeneralBoard
            var starSystem = new BasicStarSystemFactory().Generate(415006354);

            Application.Run(new GeneralBoard(starSystem));
        }
    }
}
