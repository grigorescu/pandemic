
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pandemic;


namespace TestPandemic2
{
    [TestClass]
    public class TestSearchEvaluate
    {
        public class LikesCity : SearchEvaluate
        {
            City city;
            public LikesCity(City city)
            {
                this.city = city;
            }

            public override float evaluate(GameState gs)
            {
                if (gs.currentPlayer().position == city)
                    return 1;
                else
                    return 0;
            }
        }

        public class LikesCards : SearchEvaluate
        {
            int playerNum;

            public LikesCards(int playerNum)
            {
                this.playerNum = playerNum;
            }

            public override float evaluate(GameState gs)
            {
                return (float) gs.players[playerNum].cards.Count/100;
            }
        }



        public class LovesCures : SearchEvaluate
        {
            public override float evaluate(GameState gs)
            {
                return (float)gs.numCures() / 4;
            }
        }


        public class LikesStations : SearchEvaluate
        {
            int playerNum;

            public LikesStations(int playerNum)
            {
                this.playerNum = playerNum;
            }

            public override float evaluate(GameState gs)
            {
                float f = 0;
                foreach(City c in gs.map.allCities)
                {
                    if(gs.map.hasStation(c))
                    {
                        f++;
                    }
                }
                
                return f/ 100;
            }
        }

        City newyork, newark, newark1, newark2, newark3, newark4, newark5, newark6, newark7, newark8, newark9, newark10;




        Map map;
        GameState gs;

        public GameState doSteps(GameState initial, SearchEvaluate eval, int steps, int depth)
        {
            GameState current = initial;
            for (int i = 0; i < steps; i++)
            {
                Action move = eval.bfs_findbest(current, depth);
                current = move.execute(current);
            }
            return current;
        }

        [TestInitialize()]
        public void initialize()
        {
            map = new Map();
            newyork = map.addCity("NewYork", DiseaseColor.BLUE);
            newark = map.addCity("Newark", DiseaseColor.BLUE);
            newark1 = map.addCity("Newark1", DiseaseColor.BLUE);
            newark2 = map.addCity("Newark2", DiseaseColor.BLUE);
            newark3 = map.addCity("Newark3", DiseaseColor.BLUE);
            newark4 = map.addCity("Newark4", DiseaseColor.BLUE);
            newark5 = map.addCity("Newark5", DiseaseColor.BLUE);
            newark6 = map.addCity("Newark6", DiseaseColor.BLUE);
            newark7 = map.addCity("Newark7", DiseaseColor.BLUE);
            newark8 = map.addCity("Newark8", DiseaseColor.BLUE);
            newark9 = map.addCity("Newark9", DiseaseColor.BLUE);
            newark10 = map.addCity("Newark10", DiseaseColor.BLUE);
            City.makeAdjacent(newyork, newark);
            gs = new GameState(newyork, map);

        }

        [TestMethod]
        public void TestDisease()
        {
            City atlanta = map.addCity("Atlanta", DiseaseColor.BLUE);
            City.makeAdjacent(newyork, atlanta);
            map = map.addDisease(newyork);
            gs = new GameState(newyork, map, 1, 100);
            SearchEvaluate cleaner = new Pandemic.HatesDisease(1);
            Assert.AreEqual(1, Pandemic.HatesDisease.getTotalDisease(gs));
            Action action = cleaner.bfs_findbest(gs, 1);
            gs = action.execute(gs);
            Assert.AreEqual(0, Pandemic.HatesDisease.getTotalDisease(gs));
            gs = new GameState(gs, gs.map.addDisease(newark));
            Assert.AreEqual(1, Pandemic.HatesDisease.getTotalDisease(gs));
            gs = cleaner.bfs_findbest(gs, 2).execute(gs);
            gs = cleaner.bfs_findbest(gs, 2).execute(gs);
            Assert.AreEqual(0, Pandemic.HatesDisease.getTotalDisease(gs));
        }

        [TestMethod]
        public void TestStationMove()
        {
            City rio = map.addCity("Rio", DiseaseColor.YELLOW);
            
            SearchEvaluate likesRio = new LikesCity(rio);

            Action action = likesRio.bfs_findbest(gs, 1);
            GameState newGS = action.execute(gs);
            Assert.AreEqual(newark, newGS.currentPlayer().position);

            map = map.addStation(newyork);
            map = map.addStation(rio);
            gs = new GameState(newyork, map);
            action = likesRio.bfs_findbest(gs, 1);
            newGS = action.execute(gs);
            Assert.AreEqual(rio, newGS.currentPlayer().position);


        }

        [TestMethod]
        public void TestTwoPlayers()
        {
            City atlanta = map.addCity("Atlanta", DiseaseColor.BLUE);
            City.makeAdjacent(newyork, atlanta);
            map = map.addDisease(newark);
            map = map.addDisease(atlanta);
            gs = new GameState(newyork, map, 2, 2);
            gs = gs.setTurnAction(new DoNothingTurnAction());
            SearchEvaluate hatesDisease = new HatesDisease(2);
            GameState newGS = doSteps(gs, hatesDisease, 5, 5);
            Assert.AreEqual(0,HatesDisease.getTotalDisease(newGS));
        }

        [TestMethod]
        public void TestBasicMoveSearch()
        {
            City atlanta = map.addCity("Atlanta", DiseaseColor.BLUE);
            City chicago = map.addCity("Chicago", DiseaseColor.BLUE);

            City.makeAdjacent(atlanta, newark);
            City.makeAdjacent(atlanta, newyork);
            City.makeAdjacent(newyork, chicago);
            GameState gs = new GameState(atlanta, map);
            

            SearchEvaluate likesNY = new LikesCity(newyork);
            SearchEvaluate likesChicago = new LikesCity(chicago);

            Action action = likesNY.bfs_findbest(gs, 1);
            GameState newGS = action.execute(gs);
            Assert.AreEqual(newyork, newGS.currentPlayer().position);

            action = likesChicago.bfs_findbest(gs, 1);
            newGS = action.execute(gs);
            Assert.AreNotEqual(newyork, newGS.currentPlayer().position);

            action = likesChicago.bfs_findbest(gs, 2);
            newGS = action.execute(gs);
            Assert.AreEqual(newyork, newGS.currentPlayer().position);


        }

        [TestMethod]
        public void TestMoveToCard()
        {
            City rio = map.addCity("Rio", DiseaseColor.YELLOW);

            SearchEvaluate likesRio = new LikesCity(rio);
            Player pWithCard = gs.currentPlayer().addCard(rio);
            gs = gs.adjustPlayer(pWithCard);
            Action action = likesRio.bfs_findbest(gs,1);
            GameState newGS = action.execute(gs);
            Assert.AreEqual(1, pWithCard.cards.Count);
            Assert.AreEqual(rio, newGS.currentPlayer().position);
            Assert.AreEqual(0, newGS.currentPlayer().cards.Count);

        }

        [TestMethod]
        public void TestTurnAction()
        {
            Deck<City> infect = new Deck<City>(map.allCities, false);
            Deck<City> playerDeck = new Deck<City>(map.allCities, false);
            gs = new GameState(newyork, map, 1, 1, infect, playerDeck);
            GameState gs2 = gs.availableActions()[0].execute(gs);
            Assert.AreEqual(1, gs2.availableActions().Count);
            GameState gs3 = gs2.availableActions()[0].execute(gs2);
            Assert.AreEqual(12, infect.drawDeck.Count);
            Assert.AreEqual(0, infect.discardDeck.Count);
            Assert.AreEqual(10, gs3.infectionDeck.drawDeck.Count);
            Assert.AreEqual(2, gs3.infectionDeck.discardDeck.Count);
            Assert.AreEqual(1, gs3.map.diseaseLevel(newark, DiseaseColor.BLUE));
            Assert.AreEqual(1, gs3.map.diseaseLevel(newyork, DiseaseColor.BLUE));
        }

        [TestMethod]
        public void TestTrade()
        {
            gs = new GameState(newyork, map, 2, 1);
            Player p1 = gs.currentPlayer();
            Player p1wCard = p1.addCard(newyork);
            gs = gs.adjustPlayer(p1wCard);
            gs = gs.setTurnAction(new DoNothingTurnAction());
            SearchEvaluate likesCards = new LikesCards(1);
            List<Action> foo = gs.availableActions();
            Action action = likesCards.bfs_findbest(gs, 1);
            GameState newGS = action.execute(gs);
            Assert.AreEqual(0, newGS.players[0].cards.Count);
            Assert.AreEqual(1, newGS.players[1].cards.Count);

            gs = new GameState(newyork, map, 2, 1);
            p1 = gs.currentPlayer();
            p1wCard = p1.addCard(newark);
            gs = gs.adjustPlayer(p1wCard);
            gs = gs.setTurnAction(new DoNothingTurnAction());
            action = likesCards.bfs_findbest(gs, 5);
            newGS = action.execute(gs);
            Assert.AreEqual(1, newGS.players[0].cards.Count);
            Assert.AreEqual(0, newGS.players[1].cards.Count);
            newGS = doSteps(newGS, likesCards, 4, 5);
            Assert.AreEqual(0, newGS.players[0].cards.Count);
            Assert.AreEqual(0, newGS.players[1].cards.Count);

        }

        [TestMethod]
        public void TestCureDisease()
        {
            Player p = gs.currentPlayer();
            p = p.addCard(gs.map.addCity("Blue1", DiseaseColor.BLUE));
            p = p.addCard(gs.map.addCity("Blue2", DiseaseColor.BLUE));
            p = p.addCard(gs.map.addCity("Blue3", DiseaseColor.BLUE));
            p = p.addCard(gs.map.addCity("Blue4", DiseaseColor.BLUE));
            p = p.addCard(gs.map.addCity("Blue5", DiseaseColor.BLUE));
            gs = gs.adjustPlayer(p);
            gs = new GameState(gs, gs.map.addStation(newyork));
            SearchEvaluate eval = new LovesCures();
            Action action = eval.bfs_findbest(gs, 1);
            GameState newGS = action.execute(gs);
            Assert.AreEqual(1, newGS.numCures());
            Assert.AreEqual(0, newGS.currentPlayer().cards.Count);
        }

        [TestMethod]
        public void TestScientist()
        {
            Player p = gs.currentPlayer();
            
            p = p.addCard(gs.map.addCity("Blue1", DiseaseColor.BLUE));
            p = p.addCard(gs.map.addCity("Blue2", DiseaseColor.BLUE));
            p = p.addCard(gs.map.addCity("Blue3", DiseaseColor.BLUE));
            p = p.addCard(gs.map.addCity("Blue4", DiseaseColor.BLUE));
            p = p.addCard(gs.map.addCity("Blue5", DiseaseColor.BLUE));
            p.type = Player.Type.SCIENTIST;
            gs = gs.adjustPlayer(p);
            gs = new GameState(gs, gs.map.addStation(newyork));
            SearchEvaluate eval = new LovesCures();
            Action action = eval.bfs_findbest(gs, 1);
            GameState newGS = action.execute(gs);
            Assert.AreEqual(1, newGS.numCures());
            Assert.AreEqual(1, newGS.currentPlayer().cards.Count);
        }


        [TestMethod]
        public void TestMakeStationAction()
        {
            gs = new GameState(newyork, map, 2, 1);
            Player p1 = gs.currentPlayer();
            Player p1wCard = p1.addCard(newyork);
            gs = gs.adjustPlayer(p1wCard);
            gs = gs.setTurnAction(new DoNothingTurnAction());
            SearchEvaluate likesStations = new LikesStations(1);
            List<Action> foo = gs.availableActions();
            Action action = likesStations.bfs_findbest(gs, 1);
            GameState newGS = action.execute(gs);
            Assert.AreEqual(0, newGS.players[1].cards.Count);
           // Assert.AreEqual(0, newGS.players[1].cards.Count);
            Assert.AreEqual(true, newGS.map.hasStation(newyork));        
        }


        [TestMethod]
        public void TestmedSmartAi()
        {
            City newyork = map.addCity("ny", DiseaseColor.BLUE);
            City atl = map.addCity("atl", DiseaseColor.BLUE);
            City washington = map.addCity("washington", DiseaseColor.BLUE);
            City chicago = map.addCity("chicago", DiseaseColor.BLUE);


            City.makeAdjacent(newyork, atl);
            City.makeAdjacent(atl, washington);
            City.makeAdjacent(washington, chicago);
            //ny-->atl-->washington-->chicago

            map = map.addDisease(newyork, 3);


            gs = new GameState(newyork, map, 2);

            Player p1 = gs.currentPlayer();
            gs = gs.adjustPlayer(p1);
            gs = gs.setTurnAction(new DoNothingTurnAction());
            SearchEvaluate noOutbreaks = new outbreakHater(true);

            List<Action> foo = new List<Action>();
            Action q = new CureCityAction(newyork, newyork.color);
            GameState cured = q.execute(gs);
            float eval = outbreakHater.evalGame(cured);
            Action action = noOutbreaks.bfs_findbest(gs,1);
            GameState newGS = action.execute(gs);
            float eval2 = outbreakHater.evalGame(newGS);
            Assert.AreEqual(2, newGS.map.diseaseLevel(newyork, newyork.color));
            //Assert.AreEqual(1, gs.map.aboutToOutbreak.Count());

            

            //testing adding + removin disease from about to outbreak list
            newGS.map = newGS.map.addDisease(chicago, 3);

            Assert.AreEqual(2, gs.map.aboutToOutbreak.Count());

            newGS.map = newGS.map.removeDisease(chicago, chicago.color);

            Assert.AreEqual(1, gs.map.aboutToOutbreak.Count());

            newGS.map = newGS.map.removeDisease(chicago, chicago.color);
            Assert.AreEqual(1, gs.map.aboutToOutbreak.Count());
            Assert.AreEqual(0, gs.map.diseaseLevel(chicago, chicago.color));
        }
    }
}
