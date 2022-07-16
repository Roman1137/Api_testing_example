using System.Net;
using System.Threading.Tasks;
using GoRest.Api.Client.Client;
using GoRest.Api.Client.Client.Interfaces.Controllers;
using NUnit.Framework;

namespace ApiTests.Users
{
    [TestFixture]
    public class GetAllUsersApiTests
    {
        [Test]
        public async Task Verify_GetAllUsers_Endpoint_ReturnsInfo()
        {
            // Arrange & Act
            var client = await GoRestClient.For<IUsersApi>().GetAll();
            
            // Assert
            Assert.That(client.Code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(client.Meta, Is.Not.Null);
            Assert.That(client.Data, Is.Not.Empty);
        }
        
        // verify pagination
        
    }
}