using Pandemic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestPandemic2
{
    
    
    /// <summary>
    ///This is a test class for CityTest and is intended
    ///to contain all CityTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CityTest
    {


        private TestContext testContextInstance;
        private City newYork;

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
            newYork = new City("New York", DiseaseColor.BLUE);
        }
        /// <summary>
        ///A test for City Constructor
        ///</summary>
        [TestMethod()]
        public void CityConstructorTest()
        {
            string name = "New York";
            DiseaseColor color = DiseaseColor.BLACK;
            City target = new City(name, color);
            Assert.AreEqual(name, target.name);
            Assert.AreEqual(color, target.color);
        }

        [TestMethod()]
        public void CityAddAdj()
        {
            City newark = new City("Newark", DiseaseColor.BLUE);
            City.makeAdjacent(newark, newYork);
            Assert.IsTrue(newYork.isAdjacent(newark));
        }

        
    }
}
