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
            Map m = new Map();

            atlanta = m.addCity("Atlanta", DiseaseColor.BLUE, 0.115f, 0.415f);
            City newYork = m.addCity("New York", DiseaseColor.BLUE,0.191f,0.334f);
            City chicago = m.addCity("Chicago", DiseaseColor.BLUE, 0.088f, 0.341f); 
            City washington = m.addCity("Washington", DiseaseColor.BLUE, 0.175f, 0.413f);
            City toronto = m.addCity("Toronto", DiseaseColor.BLUE, 0.139f, 0.342f);
            City sanFran = m.addCity("San Fransisco", DiseaseColor.BLUE, 0.025f, 0.383f);
            City losAngeles = m.addCity("Los Angeles", DiseaseColor.YELLOW, 0.034f, 0.459f);
            City miami = m.addCity("Miami", DiseaseColor.YELLOW, 0.154f, 0.482f);
            City mexicoCity = m.addCity("Mexico City", DiseaseColor.YELLOW, 0.083f, 0.495f);

            City.makeAdjacent(newYork, washington);
            City.makeAdjacent(newYork, toronto);
            City.makeAdjacent(washington, atlanta);
            City.makeAdjacent(washington, miami);
            City.makeAdjacent(washington, toronto);
            City.makeAdjacent(toronto, chicago);
            City.makeAdjacent(chicago, losAngeles);
            City.makeAdjacent(chicago, sanFran);
            City.makeAdjacent(chicago, mexicoCity);
            City.makeAdjacent(chicago, atlanta);
            City.makeAdjacent(sanFran, losAngeles);
            City.makeAdjacent(mexicoCity, losAngeles);           
            City.makeAdjacent(atlanta, miami);
            City.makeAdjacent(mexicoCity, miami);


            //South America
            City bogota = m.addCity("Bogota", DiseaseColor.YELLOW, 0.153f, 0.561f);
            City lima = m.addCity("Lima", DiseaseColor.YELLOW, 0.116f, 0.668f);
            City buenosAires = m.addCity("Buenos Aires", DiseaseColor.YELLOW, 0.191f, 0.766f);
            City santiago = m.addCity("Santiago", DiseaseColor.YELLOW, 0.136f, 0.777f);
            City saopaulo = m.addCity("Sau Paulo", DiseaseColor.YELLOW, 0.221f, 0.692f);

            //Africa
            City lagos = m.addCity("Lagos", DiseaseColor.YELLOW, 0.327f, 0.554f);
            City kinshasa = m.addCity("Kinshasa", DiseaseColor.YELLOW, 0.358f, 0.635f);
            City johannesburg = m.addCity("Johannesburg", DiseaseColor.YELLOW, 0.389f, 0.721f);
            City khartoum = m.addCity("Khartoum", DiseaseColor.YELLOW, 0.404f, 0.547f);
            
            //Europe
            City madrid = m.addCity("Madrid", DiseaseColor.BLUE, 0.279f, 0.387f);
            City london = m.addCity("London", DiseaseColor.BLUE, 0.284f, 0.272f);
            City paris = m.addCity("Paris", DiseaseColor.BLUE, 0.330f, 0.330f);
            City essen = m.addCity("Essen", DiseaseColor.BLUE, 0.346f, 0.246f);
            City stpetersburg = m.addCity("St. Petersburg", DiseaseColor.BLUE, 0.405f, 0.231f);
            City milan = m.addCity("Milan", DiseaseColor.BLUE, 0.374f, 0.317f); //TODO get the xy for this

            //Middle East/India/Moscow
            City moscow = m.addCity("Moscow", DiseaseColor.BLACK, 0.443f, 0.285f);
            City istanbul = m.addCity("Istanbul", DiseaseColor.BLACK, 0.396f, 0.374f);
            City algiers = m.addCity("Algiers", DiseaseColor.BLACK, 0.332f, 0.440f);
            City cairo = m.addCity("Cairo", DiseaseColor.BLACK, 0.381f, 0.470f);
            City baghdad = m.addCity("Baghdad", DiseaseColor.BLACK, 0.433f, 0.416f);
            City riyadh = m.addCity("Riyadh", DiseaseColor.BLACK, 0.442f, 0.507f);
            City karachi = m.addCity("Karachi", DiseaseColor.BLACK, 0.478f, 0.439f);
            City mumbai = m.addCity("Mumbai", DiseaseColor.BLACK, 0.489f, 0.536f);
            City dehli = m.addCity("Dehli", DiseaseColor.BLACK, 0.528f, 0.400f);
            City kolkata = m.addCity("Kolkata", DiseaseColor.BLACK, 0.575f, 0.448f);
            City tehran = m.addCity("Tehran", DiseaseColor.BLACK, 0.478f, 0.345f);
            City chennai = m.addCity("Chennai", DiseaseColor.BLACK, 0.536f, 0.590f);

            //Asia
            City bangkok = m.addCity("Bangkok", DiseaseColor.ORANGE, 0.578f, 0.535f);
            City hongkong = m.addCity("Hong Kong", DiseaseColor.ORANGE, 0.613f, 0.481f);
            City jakarta = m.addCity("Jakarta", DiseaseColor.ORANGE, 0.584f, 0.643f);
            City sydney = m.addCity("Sydney", DiseaseColor.ORANGE, 0.719f, 0.762f);
            City hochi = m.addCity("Ho Chi Minh City", DiseaseColor.ORANGE, 0.624f, 0.582f);
            City manila = m.addCity("Manila", DiseaseColor.ORANGE, 0.676f, 0.576f);
            City shanghai = m.addCity("Shanghai", DiseaseColor.ORANGE, 0.613f, 0.408f);
            City taipei = m.addCity("Taipei", DiseaseColor.ORANGE, 0.671f, 0.485f);
            City osaka = m.addCity("Osaka", DiseaseColor.ORANGE, 0.697f, 0.436f);
            City tokyo = m.addCity("Tokyo", DiseaseColor.ORANGE, 0.693f, 0.369f);
            City seoul = m.addCity("Seoul", DiseaseColor.ORANGE, 0.661f, 0.315f);
            City beijing = m.addCity("Beijing", DiseaseColor.ORANGE, 0.600f, 0.324f);

            City.makeAdjacent(bogota, miami);
            City.makeAdjacent(bogota, mexicoCity);
            City.makeAdjacent(bogota, saopaulo);
            City.makeAdjacent(bogota, buenosAires);
            City.makeAdjacent(bogota, lima);
            City.makeAdjacent(lima, mexicoCity);
            City.makeAdjacent(lima, santiago);
            City.makeAdjacent(buenosAires, saopaulo);
            City.makeAdjacent(saopaulo, lagos);
            City.makeAdjacent(saopaulo, madrid);
            City.makeAdjacent(lagos, khartoum);
            City.makeAdjacent(lagos, kinshasa);
            City.makeAdjacent(kinshasa, khartoum);
            City.makeAdjacent(kinshasa, johannesburg);
            City.makeAdjacent(khartoum, cairo);
            City.makeAdjacent(khartoum, johannesburg);
            City.makeAdjacent(madrid, newYork);
            City.makeAdjacent(madrid, algiers);
            City.makeAdjacent(madrid, paris);
            City.makeAdjacent(madrid, london);
            City.makeAdjacent(london, paris);
            City.makeAdjacent(london, newYork);
            City.makeAdjacent(london, essen);
            City.makeAdjacent(paris, essen);
            City.makeAdjacent(paris, milan);
            City.makeAdjacent(paris, algiers);
            City.makeAdjacent(essen, milan);
            City.makeAdjacent(essen, stpetersburg);
            City.makeAdjacent(stpetersburg, moscow);
            City.makeAdjacent(stpetersburg, istanbul);
            City.makeAdjacent(moscow, tehran);
            City.makeAdjacent(moscow, baghdad);
            City.makeAdjacent(moscow, istanbul);
            City.makeAdjacent(istanbul, baghdad);
            City.makeAdjacent(istanbul, cairo);
            City.makeAdjacent(istanbul, algiers);
            City.makeAdjacent(algiers, cairo);
            City.makeAdjacent(cairo, baghdad);
            City.makeAdjacent(cairo, riyadh);
            City.makeAdjacent(baghdad, tehran);
            City.makeAdjacent(baghdad, karachi);
            City.makeAdjacent(baghdad, riyadh);
            City.makeAdjacent(riyadh, karachi);
            City.makeAdjacent(karachi, dehli);
            City.makeAdjacent(karachi, mumbai);
            City.makeAdjacent(dehli, kolkata);
            City.makeAdjacent(dehli, mumbai);
            City.makeAdjacent(dehli, chennai);
            City.makeAdjacent(mumbai, chennai);
            City.makeAdjacent(kolkata, chennai);
            City.makeAdjacent(kolkata, bangkok);
            City.makeAdjacent(kolkata, hongkong);
            City.makeAdjacent(tehran, dehli);
            City.makeAdjacent(tehran, karachi);
            City.makeAdjacent(chennai, bangkok);
            City.makeAdjacent(chennai, jakarta);
            City.makeAdjacent(bangkok, hongkong);
            City.makeAdjacent(bangkok, jakarta);
            City.makeAdjacent(bangkok, hochi);
            City.makeAdjacent(hongkong, shanghai);
            City.makeAdjacent(hongkong, taipei);
            City.makeAdjacent(hongkong, manila);
            City.makeAdjacent(hongkong, hochi);
            City.makeAdjacent(jakarta, hochi);
            City.makeAdjacent(jakarta, sydney);
            City.makeAdjacent(sydney, losAngeles);
            City.makeAdjacent(hochi, manila);
            City.makeAdjacent(manila, taipei);
            City.makeAdjacent(manila, sydney);
            City.makeAdjacent(manila, sanFran);
            City.makeAdjacent(shanghai, beijing);
            City.makeAdjacent(shanghai, seoul);
            City.makeAdjacent(shanghai, tokyo);
            City.makeAdjacent(shanghai, taipei);
            City.makeAdjacent(taipei, osaka);
            City.makeAdjacent(osaka, tokyo);
            City.makeAdjacent(tokyo, seoul);
            City.makeAdjacent(tokyo, sanFran);
            City.makeAdjacent(seoul, beijing);

            return m;
        }

        private Map initializeCitiesTest()
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
            City.makeAdjacent(washington, canadaCity);
            City.makeAdjacent(canadaCity, chicago);
            City.makeAdjacent(chicago, losAngeles);
            City.makeAdjacent(chicago, sanFran);
            City.makeAdjacent(chicago, mexicoCity);
            City.makeAdjacent(chicago, atlanta);
            City.makeAdjacent(sanFran, losAngeles);
            City.makeAdjacent(mexicoCity, losAngeles);
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
