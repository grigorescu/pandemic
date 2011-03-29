using Pandemic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestPandemic2
{
    
    
    /// <summary>
    ///This is a test class for MapTest and is intended
    ///to contain all MapTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MapTest
    {
        Map map;
        City newYork;
        City atlanta;
        City newark;
        City chicago;
        City miami;

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

        [TestInitialize()]
        public void initialize()
        {
            map = new Map();

            newYork = map.addCity("New York", DiseaseColor.BLUE);
            newark = map.addCity("Newark", DiseaseColor.BLUE);
            atlanta = map.addCity("Atlanta", DiseaseColor.BLUE);
            chicago = map.addCity("Chicago", DiseaseColor.BLUE);
            miami = map.addCity("Miami", DiseaseColor.ORANGE);

            City.makeAdjacent(newYork, newark);
            City.makeAdjacent(newark, atlanta);
            City.makeAdjacent(atlanta, newYork);
            City.makeAdjacent(newark, chicago);
            City.makeAdjacent(atlanta, miami);


            for (int i = 0; i < 3; i++)
            {
                map = map.addDisease(newYork);
                map = map.addDisease(newark);
                map = map.addDisease(atlanta);
                map = map.addDisease(miami);
            }

         }

        /// <summary>
        ///A test for addDisease
        ///</summary>
        [TestMethod()]
        public void addDiseaseTest()
        {
            Assert.AreEqual(3, map.diseaseLevel(newYork, DiseaseColor.BLUE));
            Assert.AreEqual(0, map.diseaseLevel(chicago, DiseaseColor.BLUE));
            Assert.AreEqual(0, map.outbreakCount);
            Map result = map.addDisease(newYork);
            Assert.AreEqual(0, map.outbreakCount);
            Assert.AreEqual(3, result.outbreakCount);
            Assert.AreEqual(3, result.diseaseLevel(newYork, DiseaseColor.BLUE));
            Assert.AreEqual(3, result.diseaseLevel(newark, DiseaseColor.BLUE));
            Assert.AreEqual(3, result.diseaseLevel(atlanta, DiseaseColor.BLUE));
            Assert.AreEqual(1, result.diseaseLevel(chicago, DiseaseColor.BLUE));
            Assert.AreEqual(0, map.diseaseLevel(chicago, DiseaseColor.BLUE));
        }

        [TestMethod()]
        public void addColorTest()
        {
            Map result = map.addDisease(newYork);
            Assert.AreEqual(1, result.diseaseLevel(miami, DiseaseColor.BLUE));
            Assert.AreEqual(3, result.outbreakCount);
            result = result.addDisease(miami);
            Assert.AreEqual(4, result.outbreakCount);
            Assert.AreEqual(3, result.diseaseLevel(miami, DiseaseColor.ORANGE));
            Assert.AreEqual(1, result.diseaseLevel(atlanta, DiseaseColor.ORANGE));
            Assert.AreEqual(0, result.diseaseLevel(newYork, DiseaseColor.ORANGE));
        }


        [TestMethod()]
        public void addStationTest()
        {
            Assert.IsFalse(map.hasStation(newYork));
            Map result = map.addStation(newYork);
            Assert.IsTrue(result.hasStation(newYork));
            Assert.IsFalse(map.hasStation(newYork));
            result = result.addStation(miami);
            Assert.AreEqual(2, result.stations.Count);
        }
    }
}
