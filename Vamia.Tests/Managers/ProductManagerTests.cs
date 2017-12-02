using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vamia.Domain.Managers;
using Vamia.Domain.Models;
using System.Threading.Tasks;
using Vamia.Tests.Mock.Repositories;

namespace Vamia.Tests.Managers
{
    [TestClass]
    public class ProductManagerTests
    {
        [TestMethod]
        public void ViewInventory()
        {
            //Arrange
            var mockProductRepo = new MockProductRepository();
            var manager = new ProductManager(mockProductRepo);

            //Act
            var products = manager.GetInventory();

            //Assert
            Assert.IsTrue(products.Length > 0, "No Products were returned");
        }
    }
}
