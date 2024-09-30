using PlantsRadiation;

namespace PlantRadiationTests
{
    [TestClass]
    public class PlantRadiationTests
    {
        [TestMethod]
        public void TestWorerootRadiationReactionAlpha()
        {
            Woreroot woreroot = new Woreroot("Test", 5);
            Alpha.Instance().ModifyNutrientLevel(woreroot);
            Assert.AreEqual(6, woreroot.NutrientLevel);
            Assert.IsTrue(woreroot.IsAlive);
        }

        [TestMethod]
        public void TestWomblerootRadiationReactionAlpha()
        {
            Wombleroot wombleroot = new Wombleroot("Test", 5);
            Alpha.Instance().ModifyNutrientLevel(wombleroot);
            Assert.AreEqual(7, wombleroot.NutrientLevel);
            Assert.IsTrue(wombleroot.IsAlive);
        }

        [TestMethod]
        public void TestWittentootRadiationReactionAlpha()
        {
            Wittenroot wittentoot = new Wittenroot("Test", 5);
            Alpha.Instance().ModifyNutrientLevel(wittentoot);
            Assert.AreEqual(2, wittentoot.NutrientLevel);
            Assert.IsTrue(wittentoot.IsAlive);
        }

        [TestMethod]
        public void TestWorerootRadiationReactionNoRadiation()
        {
            Woreroot woreroot = new Woreroot("Test", 5);
            NoRadiation.Instance().ModifyNutrientLevel(woreroot);
            Assert.AreEqual(4, woreroot.NutrientLevel);
            Assert.IsTrue(woreroot.IsAlive);
        }

        [TestMethod]
        public void TestWomblerootRadiationReactionNoRadiation()
        {
            Wombleroot wombleroot = new Wombleroot("Test", 5);
            NoRadiation.Instance().ModifyNutrientLevel(wombleroot);
            Assert.AreEqual(4, wombleroot.NutrientLevel);
            Assert.IsTrue(wombleroot.IsAlive);
        }

        [TestMethod]
        public void TestWittentootRadiationReactionNoRadiation()
        {
            Wittenroot wittentoot = new Wittenroot("Test", 5);
            NoRadiation.Instance().ModifyNutrientLevel(wittentoot);
            Assert.AreEqual(4, wittentoot.NutrientLevel);
            Assert.IsTrue(wittentoot.IsAlive);
        }

        [TestMethod]
        public void TestWorerootRadiationReactionNoRadiationToDeath()
        {
            Woreroot woreroot = new Woreroot("Test", 1);
            NoRadiation.Instance().ModifyNutrientLevel(woreroot);
            Assert.AreEqual(0, woreroot.NutrientLevel);
            Assert.IsFalse(woreroot.IsAlive);
        }

        [TestMethod]
        public void TestWomblerootRadiationReactionNoRadiationToDeath()
        {
            Wombleroot wombleroot = new Wombleroot("Test", 1);
            NoRadiation.Instance().ModifyNutrientLevel(wombleroot);
            Assert.AreEqual(0, wombleroot.NutrientLevel);
            Assert.IsFalse(wombleroot.IsAlive);
        }

        [TestMethod]
        public void TestWittentootRadiationReactionAlphaToDeath()
        {
            Wittenroot wittentoot = new Wittenroot("Test", 2);
            Alpha.Instance().ModifyNutrientLevel(wittentoot);
            Assert.AreEqual(-1, wittentoot.NutrientLevel);
            Assert.IsFalse(wittentoot.IsAlive);
        }

        [TestMethod]
        public void TestWomblerootRadiationDemand()
        {
            Wombleroot wombleroot = new Wombleroot("Test", 5);
            Assert.AreEqual(10, wombleroot.GetAlphaDemand());
            Assert.AreEqual(0, wombleroot.GetDeltaDemand());
        }

        [TestMethod]
        public void TestWittentootRadiationDemandLow()
        {
            Wittenroot wittentoot = new Wittenroot("TestWitLow", 4);
            Assert.AreEqual(4, wittentoot.GetDeltaDemand());
        }

        [TestMethod]
        public void TestWittentootRadiationDemandMid()
        {
            Wittenroot wittentoot = new Wittenroot("TestWitMid", 7);
            Assert.AreEqual(1, wittentoot.GetDeltaDemand());
        }

        [TestMethod]
        public void TestWittentootRadiationDemandHigh()
        {
            Wittenroot wittentoot = new Wittenroot("TestWitHigh", 11);
            Assert.AreEqual(0, wittentoot.GetDeltaDemand());
        }

        [TestMethod]
        public void TestMultiplePlantRadiationDemand()
        {
            var wombleroot = new Wombleroot("TestWom", 5);
            var wittenrootLow = new Wittenroot("TestWitLow", 4);
            var wittenrootMid = new Wittenroot("TestWitMid", 7);
            var wittenrootHigh = new Wittenroot("TestWitHigh", 11);
            var woreroot = new Woreroot("TestWor", 5);

            var plants = new List<Plant> { wombleroot, wittenrootLow, wittenrootMid, wittenrootHigh, woreroot };

            int totalAlphaDemand = 0;
            int totalDeltaDemand = 0;

            foreach (var plant in plants)
            {
                if (plant.IsAlive)
                {
                    totalAlphaDemand += plant.GetAlphaDemand();
                    totalDeltaDemand += plant.GetDeltaDemand();
                }
            }

            Assert.AreEqual(10, totalAlphaDemand);
            Assert.AreEqual(5, totalDeltaDemand);
        }
    }
}