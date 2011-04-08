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
            GameEngine ge = new GameEngine();
            GameBoard gb = new GameBoard(false, ge);
            

            gb.update(ge.gs);
            Application.Run(gb);
            
            

            //City newYork = new City("New York", DiseaseColor.BLUE);
            //City newark = new City("Newark", DiseaseColor.BLUE);
            //City atlanta = new City("Atlanta", DiseaseColor.BLUE);
            //City chicago = new City("Chicago", DiseaseColor.BLUE);
            //City miami = new City("Miami", DiseaseColor.ORANGE);
            //List<City> cities = new List<City>();
            //cities.Add(newYork);
            //cities.Add(newark);
            //cities.Add(atlanta);
            //cities.Add(chicago);
            //cities.Add(miami);
            //Deck<City> deck = new Deck<City>(cities, true);

            //deck.draw(3);

            //deck.printDeck();
        }
    }
}
