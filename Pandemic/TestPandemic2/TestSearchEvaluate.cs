
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

        [TestMethod]
        public void TestStationMove()
        {
            Map map = new Map();
            City newyork = map.addCity("NewYork", DiseaseColor.BLUE);
            City newark = map.addCity("Newark", DiseaseColor.BLUE);
            City rio = map.addCity("Rio", DiseaseColor.YELLOW);
            City.makeAdjacent(newyork, newark);

            GameState gs = new GameState(newyork, map);
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
        public void TestBasicMoveSearch()
        {
            Map map = new Map();
            City atlanta = map.addCity("Atlanta", DiseaseColor.BLUE);
            City newark = map.addCity("Newark", DiseaseColor.BLUE);
            City newyork = map.addCity("NewYork", DiseaseColor.BLUE);
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
    }
}
