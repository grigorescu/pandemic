using Pandemic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestPandemic2
{
    
    
    /// <summary>
    ///This is a test class for DeckTest and is intended
    ///to contain all DeckTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DeckTest
    {
        City newYork;
        City atlanta;
        City newark;
        City chicago;
        City miami;
        Deck<City> deck;

        [TestInitialize()]
        public void initialize()
        {
            newYork = new City("New York", DiseaseColor.BLUE,0);
            newark = new City("Newark", DiseaseColor.BLUE, 1);
            atlanta = new City("Atlanta", DiseaseColor.BLUE, 2);
            chicago = new City("Chicago", DiseaseColor.BLUE, 3);
            miami = new City("Miami", DiseaseColor.ORANGE, 4);
            List<City> cities = new List<City>();
            cities.Add(newYork);
            cities.Add(newark);
            cities.Add(atlanta);
            cities.Add(chicago);
            cities.Add(miami);
            deck = new Deck<City>(cities, false);

        }

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


        [TestMethod()]
        public void drawFromBottomTest()
        {
            Deck<City> newDeck = deck.drawFromBottom();
            List<City> cities = newDeck.discardDeck;
            Assert.AreEqual(1, cities.Count);
            Assert.AreEqual(miami, cities[0]);
            Assert.AreEqual(1, newDeck.discardDeck.Count);
            Assert.AreEqual(miami, newDeck.discardDeck[0]);
        }

        [TestMethod()]
        public void drawTest()
        {
            Deck<City> newDeck = deck.draw();
            List<City> cities = newDeck.discardDeck;

            Assert.AreEqual(1, cities.Count);
            Assert.AreEqual(newYork, cities[0]);
            Assert.AreEqual(1, newDeck.discardDeck.Count);
            Assert.AreEqual(newYork, newDeck.discardDeck[0]);
            
        }

        [TestMethod()]
        public void discardPileToDraw()
        {
            Deck<City> newDeck = deck.draw(2);
            List<City> citites = deck.discardDeck;
            Deck<City> reshuffed = newDeck.returnShuffledDiscard();

            Assert.AreEqual(0, reshuffed.discardDeck.Count);
            Assert.AreEqual(5, reshuffed.drawDeck.Count);
            Assert.AreEqual(newYork, reshuffed.drawDeck[0]);
        }
    }
}
