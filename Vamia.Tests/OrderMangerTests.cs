using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Vamia.Domain.Interface.Repositories;
using Vamia.Domain.Managers;
using Vamia.Models;

namespace Vamia.Tests
{
    [TestClass]
    public class OrderMangerTests
    {

        [TestMethod]
        public void EmptyShoppingCartShouldFail()
        {
        }

        [TestMethod]
        public void InvalidUserIdShouldFail()
        {
        }

        [TestMethod]
        public void ItemQuantitiesShouldBePositive()
        {
        }

        [TestMethod]
        public void OrderItem()
        {
            //Arrange
            var repoMock = new Mock<IOrderRepository>();

            //Setuip TestData

            var user = new UserModel
            {
                Email = "odytrice@gmail.com",
                UserId = System.Guid.NewGuid().ToString()
            };

            var items = new List<ItemModel> {
                new ItemModel
                {
                    ProductId = 1,
                    Quantity = 100
                }
            };

            repoMock.Setup(r => r.FetchUserById(user.UserId)).Returns(user);


            var manager = new OrderManager(repoMock.Object);

            //Act

            var order = manager.Order(user, items);

            //Assert
            Assert.AreEqual(items.Count, order.Items.Count, "Order is incomplete");
        }
    }
}
