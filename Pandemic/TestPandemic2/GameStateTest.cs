using Pandemic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestPandemic2
{
    
    
    /// <summary>
    ///This is a test class for GameStateTest and is intended
    ///to contain all GameStateTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GameStateTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        Map map;
        City atlanta;
        City newyork;
        GameState gs;

        [TestInitialize]
        public void initialize()
        {
            map = new Map();
            atlanta = map.addCity("Atlanta", DiseaseColor.BLUE);
            newyork = map.addCity("NewYork", DiseaseColor.BLUE);
            City.makeAdjacent(atlanta, newyork);
            gs = new GameState(atlanta, map);
        }

        /// <summary>
        ///A test for availableActions
        ///</summary>
        [TestMethod()]
        public void moveActionsTest()
        {
            
            List<Action> actions = gs.availableActions();
            Assert.AreEqual(1, actions.Count);
            GameState newGs = actions[0].execute(gs);
            Assert.AreEqual(newyork, newGs.currentPlayer().position);
        }

        /// <summary>
        ///Check player changing;
        ///</summary>
        [TestMethod()]
        public void currentPlayerTest()
        {
            //3 players
            gs = new GameState(atlanta, map, 3, 1);
            Player startPlayer = gs.currentPlayer();
            Action someAction = gs.availableActions()[0];
            GameState newGS = someAction.execute(gs);
            Assert.AreNotEqual(startPlayer.playernum, newGS.currentPlayer().playernum);
            someAction = newGS.availableActions()[0];
            newGS = someAction.execute(newGS);
            Assert.AreNotEqual(startPlayer.playernum, newGS.currentPlayer().playernum);
            someAction = newGS.availableActions()[0];
            newGS = someAction.execute(newGS);
            Assert.AreEqual(startPlayer.playernum, newGS.currentPlayer().playernum);

            //2 moves per player
            gs = new GameState(atlanta, map, 2, 2);
            startPlayer = gs.currentPlayer();
            someAction = gs.availableActions()[0];
            newGS = someAction.execute(gs);
            Assert.AreEqual(startPlayer.playernum, newGS.currentPlayer().playernum);
            someAction = newGS.availableActions()[0];
            newGS = someAction.execute(newGS);
            Assert.AreNotEqual(startPlayer.playernum, newGS.currentPlayer().playernum);

        }
    }
}
