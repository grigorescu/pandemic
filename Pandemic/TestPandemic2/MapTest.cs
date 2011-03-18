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

            newYork.setDiseaseLevel(DiseaseColor.BLUE, 3);
            newark.setDiseaseLevel(DiseaseColor.BLUE, 3);
            atlanta.setDiseaseLevel(DiseaseColor.BLUE, 3);
            miami.setDiseaseLevel(DiseaseColor.ORANGE, 3);
        }

        /// <summary>
        ///A test for addDisease
        ///</summary>
        [TestMethod()]
        public void addDiseaseTest()
        {

            int outbreak = map.addDisease(newYork);

            Assert.AreEqual(3, outbreak);
            Assert.AreEqual(3, newYork.getDisease());
            Assert.AreEqual(3, newark.getDisease());
            Assert.AreEqual(3, atlanta.getDisease());
            Assert.AreEqual(1, chicago.getDisease());

        }

        [TestMethod()]
        public void addColorTest()
        {
            int outbreak = map.addDisease(newYork);

            Assert.AreEqual(3, outbreak);
            Assert.AreEqual(3, miami.getDisease());
            Assert.AreEqual(1, miami.getDisease(DiseaseColor.BLUE));
            outbreak = map.addDisease(miami);
            Assert.AreEqual(1, outbreak);
            Assert.AreEqual(1, atlanta.getDisease(DiseaseColor.ORANGE));
            Assert.AreEqual(3, miami.getDisease());
            Assert.AreEqual(0, newYork.getDisease(DiseaseColor.ORANGE));
        }
    }
}
