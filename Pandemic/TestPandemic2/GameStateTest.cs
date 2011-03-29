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


        /// <summary>
        ///A test for availableActions
        ///</summary>
        [TestMethod()]
        public void moveActionsTest()
        {

            City atlanta = new City("Atlanta", DiseaseColor.BLUE);
            City newyork = new City("NewYork", DiseaseColor.BLUE);
            City.makeAdjacent(atlanta, newyork);
            GameState gs = new GameState(atlanta, null);
            List<Action> actions = gs.availableActions();
            Assert.AreEqual(1, actions.Count);
            GameState newGs = actions[0].execute(gs);
            Assert.AreEqual(newyork, newGs.currentPlayer().position);
        }
    }
}
