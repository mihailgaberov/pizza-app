using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using backend;

namespace PizzaVotes.Tests
{
    public class PizzaVotesTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public PizzaVotesTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetAllVotesAsync()
        {
            // Arrange
            var request = "/api/pizzavotes";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestGetUserVotesAsync()
        {
            // Arrange
            var request = "/api/pizzavotes/mihail.gaberov@gmail.com";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            Assert.Equal("Unauthorized", response.StatusCode.ToString());
        }

        [Fact]
        public async Task TestPostVoteAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/pizzavotes",
                Body = new
                {
                    Id = "mihail.gaberov1@gmail.com",
                    Value = 1,
                    DateTime = DateTime.Now
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("Unauthorized", response.StatusCode.ToString());

        }

        [Fact]
        public async Task TestPutUserVoteAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/pizzavotes/mihail.gaberov@gmail.com",
                Body = new
                {
                    Value = 2,
                    DateTime = DateTime.Now
                }
            };

            // Act
            var response = await Client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            Assert.Equal("Unauthorized", response.StatusCode.ToString());
        }
    }
}
