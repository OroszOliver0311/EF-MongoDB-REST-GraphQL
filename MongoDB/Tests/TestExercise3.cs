using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mongo.Tests
{
    [TestClass]
    public class TestExercise3
    {
        [TestMethod]
        public void Ex3_ProductsCumulativeVolume()
        {
            var repo = new ProductRepository(TestDbFactory.Database);

            var totalVolume = repo.GetAllProductsCumulativeVolume();

            Assert.AreEqual(2.9541, totalVolume);
        }
    }
}
