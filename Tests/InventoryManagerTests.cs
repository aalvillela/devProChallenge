using NUnit.Framework;
using devProChallenge.LoggerApp;
using devProChallenge.Models;
using NUnit.Framework.Legacy;

namespace devProChallenge.Tests
{
    [TestFixture]
    public class InventoryManagerTests
    {
        [Test]
        public void TestSortProductsByPriceDescending()
        {
            List<Product> products = new List<Product>
            {
                new Product { Name = "Product A", Price = 100, Stock = 5 },
                new Product { Name = "Product B", Price = 200, Stock = 3 },
                new Product { Name = "Product C", Price = 50, Stock = 10 }
            };

            List<Product> sortedProducts = products.SortProducts("price", false);

            ClassicAssert.AreEqual("Product B", sortedProducts[0].Name);
            ClassicAssert.AreEqual("Product A", sortedProducts[1].Name);
            ClassicAssert.AreEqual("Product C", sortedProducts[2].Name);
        }

        [Test]
        public void TestSortProductsByNameAscending()
        {
            List<Product> products = new List<Product>
            {
                new Product { Name = "Product B", Price = 200, Stock = 3 },
                new Product { Name = "Product A", Price = 100, Stock = 5 },
                new Product { Name = "Product C", Price = 50, Stock = 10 }
            };

            List<Product> sortedProducts = products.SortProducts("name", true);

            ClassicAssert.AreEqual("Product A", sortedProducts[0].Name);
            ClassicAssert.AreEqual("Product B", sortedProducts[1].Name);
            ClassicAssert.AreEqual("Product C", sortedProducts[2].Name);
        }
    }
}
