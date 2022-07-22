using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
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
            var users = await GoRestClient.For<IUsersApi>().GetAll();
            
            // Assert
            users.Code.Should().Be(HttpStatusCode.OK);
            users.Meta.Should().NotBeNull();
            users.Data.Should().NotBeEmpty();
        }
        
        // verify pagination
        
    }
}