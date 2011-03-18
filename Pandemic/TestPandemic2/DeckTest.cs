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
            newYork = new City("New York", DiseaseColor.BLUE);
            newark = new City("Newark", DiseaseColor.BLUE);
            atlanta = new City("Atlanta", DiseaseColor.BLUE);
            chicago = new City("Chicago", DiseaseColor.BLUE);
            miami = new City("Miami", DiseaseColor.ORANGE);
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
            List<City> cities = deck.drawFromBottom();
            Assert.AreEqual(1, cities.Count);
            Assert.AreEqual(miami, cities[0]);
            Assert.AreEqual(1, deck.discardDeck.Count);
            Assert.AreEqual(miami, deck.discardDeck[0]);
        }

        [TestMethod()]
        public void drawTest()
        {
            List<City> cities = deck.draw();

            Assert.AreEqual(1, cities.Count);
            Assert.AreEqual(newYork, cities[0]);
            Assert.AreEqual(1, deck.discardDeck.Count);
            Assert.AreEqual(newYork, deck.discardDeck[0]);
            
        }

        [TestMethod()]
        public void discardPileToDraw()
        {
            List<City> citites = deck.draw(2);
            deck.returnShuffledDiscard();

            Assert.AreEqual(0, deck.discardDeck.Count);
            Assert.AreEqual(5, deck.drawDeck.Count);
            Assert.AreEqual(newYork, deck.drawDeck[0]);
        }
    }
}
