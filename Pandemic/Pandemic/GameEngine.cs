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
        public Action lastAction;
        public Random rand = new Random();


        public GameEngine()
        {

            //initialize infection and player decks and map
            Map map = initializeCities();
            Deck<City> ideck = initializeInfectionDeck(map);
            //initialize player deck
            Deck<City> pDeck = initializePlayerDeck(map); 
            gs = new GameState(atlanta, map, 4, 4, ideck, pDeck);

            foreach (Player p in gs.players)
            {
                gs = gs.drawPlayerCards(p);
            }
            gs.playerDeck.eCards = makeEpidemicCards(pDeck.drawDeck.Count);

            ev = new HatesDisease(100);

        }

        public void runAction()
        {

            Action a = ev.bfs_findbest(gs, 4);
            lastAction = a;
            gs = a.execute(gs);

            //throw up some GUI
            if (gs.numCures() == 4)
            {
                //YOU WON OMG
            }
            else if (gs.map.outbreakCount == 9)
            {
                //YOU LOST!!!
            }


        }

        private List<int> makeEpidemicCards(int pDeckSize, int numE = 4)
        {
            List<int> epidemicCards = new List<int>();

            int sectionSize = pDeckSize / numE;
            int section = 0;

            for (int j = 0; j < numE; j++)
            {
                epidemicCards.Add(rand.Next(section, (section + sectionSize)));
                section += sectionSize;
            }

            return epidemicCards;
        }

        private Map initializeCities()
        {
            //north america 
            //TODO rename CanadaCity to whatever. Add San Fran
            Map m = new Map();
            atlanta = m.addCity("Atlanta", DiseaseColor.BLUE, 0.115f, 0.415f);
            City newYork = m.addCity("NewYork", DiseaseColor.BLUE, 0.191f, 0.334f);
            City chicago = m.addCity("Chicago", DiseaseColor.BLUE, 0.088f, 0.341f);
            City washington = m.addCity("Washington", DiseaseColor.BLUE, 0.175f, 0.413f);
            City canadaCity = m.addCity("Toronto", DiseaseColor.BLUE, 0.139f, 0.342f);
            City sanFran = m.addCity("San Fransisco", DiseaseColor.BLUE, 0.025f, 0.383f);
            City losAngeles = m.addCity("Los Angeles", DiseaseColor.YELLOW, 0.034f, 0.459f);
            City miami = m.addCity("Miami", DiseaseColor.YELLOW, 0.154f, 0.482f);
            City mexicoCity = m.addCity("MexicoCity", DiseaseColor.YELLOW, 0.083f, 0.495f);

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

            m = m.addDisease(losAngeles, 3);
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

        private Deck<City> initializePlayerDeck(Map map)
        {
            List<City> cities = new List<City>();
            cities.AddRange(map.allCities);

            Deck<City> playerDeck = new Deck<City>(cities, true);
            return playerDeck;
        }
    }
}
