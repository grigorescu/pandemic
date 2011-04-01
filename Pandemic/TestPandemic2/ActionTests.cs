using Pandemic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestPandemic2
{
    
    
    /// <summary>
    ///This is a test class for MoveActionTest and is intended
    ///to contain all MoveActionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ActionTests
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
        ///A test for execute
        ///</summary>
        [TestMethod()]
        public void moveExecuteTest()
        {
            City atlanta = new City("Atlanta", DiseaseColor.BLUE);
            City newyork = new City("NewYork", DiseaseColor.BLUE);
            City.makeAdjacent(atlanta, newyork);
            GameState gs = new GameState(atlanta, null);
            MoveAction action = new MoveAction(gs.currentPlayer(), newyork);
            GameState newGs = action.execute(gs);
            Assert.AreEqual(newyork, newGs.currentPlayer().position);
            Assert.AreEqual(atlanta, gs.currentPlayer().position);

        }

        [TestMethod()]
        public void cureExecuteTest()
        {
            Map map = new Map();
            City atlanta = map.addCity("Atlanta", DiseaseColor.BLUE);
            City newyork = map.addCity("NewYork", DiseaseColor.BLUE);
            City.makeAdjacent(atlanta, newyork);
            map = map.addDisease(atlanta);
            GameState gs = new GameState(atlanta, map);
            CureAction action = new CureAction(atlanta, DiseaseColor.BLUE);
            GameState newGs = action.execute(gs);
            Assert.AreEqual(1, gs.map.diseaseLevel(atlanta, DiseaseColor.BLUE));
            Assert.AreEqual(atlanta, newGs.currentPlayer().position);
            Assert.AreEqual(0, newGs.map.diseaseLevel(atlanta, DiseaseColor.BLUE));

        }
    }
}
