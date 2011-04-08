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
        SearchEvaluate ev;

        public GameEngine()
        {
           
            //initialize infection and player decks
            Map map = initializeCities();
            Deck<City> ideck = initializeInfectionDeck(map);
            gs = new GameState(atlanta, map, 4, 4, ideck);
            ev = new HatesDisease(100);
            //initialize board (before first turn)
        }

        public void runAction()
        {

            Action a = ev.bfs_findbest(gs, 8);
            gs = a.execute(gs);

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
            atlanta = m.addCity("Atlanta", DiseaseColor.BLUE, 0.165f, 0.417f);
            City newYork = m.addCity("NewYork", DiseaseColor.BLUE,0.266f,0.348f);
            City chicago = m.addCity("Chicago", DiseaseColor.BLUE, 0.123f, 0.352f);
            City washington = m.addCity("Washington", DiseaseColor.BLUE, 0.244f, 0.423f);
            City canadaCity = m.addCity("Toronto", DiseaseColor.BLUE, 0.196f, 0.352f);
            City sanFran = m.addCity("San Fransisco", DiseaseColor.BLUE, 0.042f, 0.394f);
            City losAngeles = m.addCity("Los Angeles", DiseaseColor.YELLOW, 0.055f, 0.471f);
            City miami = m.addCity("Miami", DiseaseColor.YELLOW, 0.221f, 0.486f);
            City mexicoCity = m.addCity("MexicoCity", DiseaseColor.YELLOW, 0.127f, 0.507f);

            City.makeAdjacent(newYork, washington);
            City.makeAdjacent(newYork, canadaCity);
            City.makeAdjacent(washington, atlanta);
            City.makeAdjacent(washington, miami);
            City.makeAdjacent(canadaCity, chicago);
            City.makeAdjacent(canadaCity, atlanta);
            City.makeAdjacent(chicago, losAngeles);
            City.makeAdjacent(sanFran, losAngeles);
            City.makeAdjacent(mexicoCity, losAngeles);
            City.makeAdjacent(chicago, sanFran);
            City.makeAdjacent(chicago, mexicoCity);
            City.makeAdjacent(atlanta, miami);
            City.makeAdjacent(mexicoCity, miami);

           m = m.addDisease(losAngeles,3);
           m = m.addDisease(losAngeles, 1);
           m = m.addDisease(chicago, 3);
           m = m.addDisease(chicago, 1);
           m = m.addStation(atlanta);
           m = m.addStation(newYork);

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
