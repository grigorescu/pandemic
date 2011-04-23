using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Pandemic
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

            StartScreen start = new StartScreen();

            //GameEngine ge = new GameEngine();
            //GameBoard gb = new GameBoard(false, ge);

            //gb.update(ge.gs);
            Application.Run(start);
            
            
        }
    }
}
