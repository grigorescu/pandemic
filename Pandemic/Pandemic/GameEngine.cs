using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pandemic
{
    public class GameEngine
    {
        public GameState gs;
        City atlanta;

        public GameEngine()
        {
           
            //initialize infection and player decks
            Map map = initializeCities();
            Deck<City> ideck = initializeInfectionDeck(map);
            gs = new GameState(atlanta, map, 2, 4, ideck);

            //initialize board (before first turn)
        }

        public void runGame()
        {
            while (gs.curesFound != 4 || gs.map.outbreakCount !=9) //or all cubes gone or all player deck has been drawn
            {


            }

            //throw up some GUI
            if (gs.curesFound == 4)
            {
                //YOU WON OMG
            }
            else if (gs.map.outbreakCount == 9)
            {
                //YOU LOST!!!
            }
        }

        private Map initializeCities()
        {
            //north america 
            //TODO rename CanadaCity to whatever. Add San Fran
            Map m = new Map();
            atlanta = m.addCity("Atlanta", DiseaseColor.BLUE, 0.25f, 0.25f);
            City newYork = m.addCity("NewYork", DiseaseColor.BLUE,0.5f,0.5f);
            City chicago = m.addCity("Chicago", DiseaseColor.BLUE);
            City washington = m.addCity("Washington", DiseaseColor.BLUE);
            City canadaCity = m.addCity("CanadaCity", DiseaseColor.YELLOW);
            City losAngeles = m.addCity("LosAngeles", DiseaseColor.YELLOW);
            City miami = m.addCity("Miami", DiseaseColor.YELLOW);
            City mexicoCity = m.addCity("MexicoCity", DiseaseColor.YELLOW);

            City.makeAdjacent(newYork, washington);
            City.makeAdjacent(newYork, canadaCity);
            City.makeAdjacent(washington, atlanta);
            City.makeAdjacent(washington, miami);
            City.makeAdjacent(canadaCity, chicago);
            City.makeAdjacent(canadaCity, atlanta);
            City.makeAdjacent(chicago, losAngeles);
            City.makeAdjacent(chicago, mexicoCity);
            City.makeAdjacent(atlanta, miami);
            City.makeAdjacent(mexicoCity, miami);

            return m;
        }

        private Deck<City> initializeInfectionDeck(Map map)
        {
            List<City> cities = new List<City>();
            cities.AddRange(map.allCities);

            Deck<City> infectionDeck = new Deck<City>(cities, true);
            return infectionDeck;
        }
    }
}
