
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
        public void TestBasicMoveSearch()
        {
            City atlanta = new City("Atlanta", DiseaseColor.BLUE);
            City newark = new City("Newark", DiseaseColor.BLUE);
            City newyork = new City("NewYork", DiseaseColor.BLUE);
            City chicago = new City("Chicago", DiseaseColor.BLUE);

            City.makeAdjacent(atlanta, newark);
            City.makeAdjacent(atlanta, newyork);
            City.makeAdjacent(newyork, chicago);
            GameState gs = new GameState(atlanta, null);
            

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
