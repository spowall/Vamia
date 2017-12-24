using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vamia.Domain.Managers;
using Vamia.Domain.Models;
using Vamia.Infrastructure.Utilities;
using Vamia.Tests.Mock.Repositories;

namespace Vamia.Tests.Managers
{
    [TestClass]
    public class UserManagerTests
    {
        [TestMethod]
        public void RegisterUser()
        {
            //Arrange
            var mockRepo = new MockUserRepository();
            var manager = new UserManager(mockRepo, new MD5Encryption());

            //Test Data
            var userModel = new UserModel
            {
                Email = "temp@gmail.com",
                FirstName = "Sample",
                LastName = "User",
            };

            //Act
            manager.RegisterUser(userModel, "password");

            //Assert
            Assert.IsTrue(mockRepo.GetUser(userModel.Email) != null, "User Not Added");
        }

        [TestMethod]
        public void RegisterAsExistingUser()
        {
            //Arrange
            var mockRepo = new MockUserRepository();
            var manager = new UserManager(mockRepo, new MD5Encryption());

            //Test Data
            var userModel = new UserModel
            {
                Email = "temp@gmail.com",
                FirstName = "Sample",
                LastName = "User",
            };

            mockRepo.Create(userModel);

            //Act
            var operation = Operation.Create(() => manager.RegisterUser(userModel, "password"));

            //Assert
            Assert.IsFalse(operation.Succeeded, "User was Registered Twice");
        }
    }
}
