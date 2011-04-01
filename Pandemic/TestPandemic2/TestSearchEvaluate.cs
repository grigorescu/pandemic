
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

        public class HatesDisease : SearchEvaluate
        {
            int diseaseMax;
            public HatesDisease(int diseaseMax)
            {
                this.diseaseMax = diseaseMax;
            }

            public static int getTotalDisease(GameState gs)
            {
                int totalDisease = 0;
                foreach (City c in gs.map.allCities)
                {
                    totalDisease += gs.map.diseaseLevel(c, DiseaseColor.BLACK);
                    totalDisease += gs.map.diseaseLevel(c, DiseaseColor.BLUE);
                    totalDisease += gs.map.diseaseLevel(c, DiseaseColor.YELLOW);
                    totalDisease += gs.map.diseaseLevel(c, DiseaseColor.ORANGE);
                }
                return totalDisease;
            }

            public override float evaluate(GameState gs)
            {
                return 1 - (float)getTotalDisease(gs) / diseaseMax;

            }
        }

        City newyork, newark;
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
            City.makeAdjacent(newyork, newark);
            gs = new GameState(newyork, map);

        }

        [TestMethod]
        public void TestDisease()
        {
            City atlanta = map.addCity("Atlanta", DiseaseColor.BLUE);
            City.makeAdjacent(newyork, atlanta);
            map = map.addDisease(newyork);
            gs = new GameState(newyork, map);
            SearchEvaluate cleaner = new HatesDisease(1);
            Assert.AreEqual(1, HatesDisease.getTotalDisease(gs));
            Action action = cleaner.bfs_findbest(gs, 1);
            gs = action.execute(gs);
            Assert.AreEqual(0, HatesDisease.getTotalDisease(gs));
            gs = new GameState(gs, gs.map.addDisease(newark));
            Assert.AreEqual(1, HatesDisease.getTotalDisease(gs));
            gs = cleaner.bfs_findbest(gs, 2).execute(gs);
            gs = cleaner.bfs_findbest(gs, 2).execute(gs);
            Assert.AreEqual(0, HatesDisease.getTotalDisease(gs));
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
            SearchEvaluate hatesDisease = new HatesDisease(2);
            GameState newGS = doSteps(gs, hatesDisease, 4, 4);
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
            gs = new GameState(gs,pWithCard);
            Action action = likesRio.bfs_findbest(gs,1);
            GameState newGS = action.execute(gs);
            Assert.AreEqual(1, pWithCard.cards.Count);
            Assert.AreEqual(rio, newGS.currentPlayer().position);
            Assert.AreEqual(0, newGS.currentPlayer().cards.Count);

        }
    }
}
