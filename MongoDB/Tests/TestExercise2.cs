using Microsoft.VisualStudio.TestTools.UnitTesting;
using mongo.Entitites;
using System;
using System.Threading;

namespace mongo.Tests
{
    [TestClass]
    public class TestExercise2
    {
        [TestMethod]
        public void Ex2_SuccesfulInsert()
        {
            var repo = new ProductRepository(TestDbFactory.Database);

            var product = repo.InsertProduct($"Teszt {Guid.NewGuid()}", "Toy", 10);

            Assert.IsNotNull(product);
            Assert.AreEqual("VAT", product.VAT.Name);
        }

        [TestMethod]
        public void Ex2_SuccesfulInsertWithExistingVAT()
        {
            var repo = new ProductRepository(TestDbFactory.Database);

            var product = repo.InsertProduct($"Teszt {Guid.NewGuid()}", "Toy", 27);

            Assert.AreEqual("Standard Rate", product.VAT.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Product alread exists")]
        public void Ex2_FailedInsertWithSameName()
        {
            var repo = new ProductRepository(TestDbFactory.Database);

            var guid = Guid.NewGuid();
            repo.InsertProduct($"Teszt {guid}", "Toy", 27);
            repo.InsertProduct($"Teszt {guid}", "Toy", 27);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Category not found")]
        public void Ex2_FailedInsertWithWrongCategory()
        {
            var repo = new ProductRepository(TestDbFactory.Database);

            repo.InsertProduct($"Teszt {Guid.NewGuid()}", "Wrong Category", 27);
        }
    }
}
