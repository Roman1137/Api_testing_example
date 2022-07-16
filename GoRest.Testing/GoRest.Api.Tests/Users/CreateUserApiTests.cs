using System;
using System.Net;
using System.Threading.Tasks;
using GoRest.Api.Client.Client;
using GoRest.Api.Client.Client.Interfaces.Controllers;
using GoRest.Api.Client.Client.Models.UsersApi;
using NUnit.Framework;

namespace ApiTests.Users
{
    [TestFixture]
    public class CreateUserApiTests
    {
        [Test]
        public async Task Verify_UserIsCreated()
        {
            // Arrange
            var userModel = new CreateUserModel()
            {
                Email =  new Random().Next(1111,5555) +"@gmail.com",
                Gender = Gender.Female,
                Name = Guid.NewGuid().ToString(),
                Status = Status.Active
            };

            // Act
            var response = await GoRestClient.For<IUsersApi>().CreateUser(userModel);

            // Assert
            Assert.That(response.Code, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(response.Data.Id, Is.Positive);
        }
    }
}