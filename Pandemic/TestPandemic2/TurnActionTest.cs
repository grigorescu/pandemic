using Pandemic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestPandemic2
{
    
    
    /// <summary>
    ///This is a test class for TurnActionTest and is intended
    ///to contain all TurnActionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TurnActionTest
    {

        /// <summary>
        ///A test for execute
        ///</summary>
        [TestMethod()]
        public void epidemicTest()
        {
            Map map = new Map();
            City atl = map.addCity("Atlanta", DiseaseColor.BLUE);
            City ny = map.addCity("New York", DiseaseColor.BLUE);
            City.makeAdjacent(atl,ny);
            Deck<City> playerDeck = new Deck<City>(map.allCities);
            int infectRate;
            GameState gs = new GameState(atl, map, 1, 4, new Deck<City>(map.allCities), playerDeck);
            infectRate = gs.map.infectionRate;
            gs.epidemicCard();
            
            Assert.IsTrue(gs.map.diseaseLevel(atl, DiseaseColor.BLUE) == 3 || gs.map.diseaseLevel(ny, DiseaseColor.BLUE) == 3);
            Assert.AreEqual(infectRate + 1, gs.map.infectionRate);
        }

        [TestMethod()]
        public void epidemicDrawTest()
        {
            Map map = new Map();
            City atl = map.addCity("Atlanta", DiseaseColor.BLUE);
            City ny = map.addCity("New York", DiseaseColor.BLUE);
            City.makeAdjacent(atl, ny);
            Deck<City> playerDeck = new Deck<City>(map.allCities, false, true);
            int infectRate;
            GameState gs = new GameState(atl, map, 1, 4, new Deck<City>(map.allCities), playerDeck);
            infectRate = gs.map.infectionRate;
            playerDeck.epidemicCards.Add(1);
            GameState newGS = new TurnAction().execute(gs);
            Assert.IsTrue(newGS.map.diseaseLevel(atl, DiseaseColor.BLUE) == 3 || newGS.map.diseaseLevel(ny, DiseaseColor.BLUE) == 3);
            Assert.AreEqual(infectRate + 1, newGS.map.infectionRate);
        }
    }
}
