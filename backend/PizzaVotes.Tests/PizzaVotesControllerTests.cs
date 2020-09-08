using System.Collections.Generic;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backend
{
    public class PizzaVotesControllerTests
    {
        private IPizzaVotesRepository _votesRepository;

        [Fact]
        public async Task PizzaVotesActionResult_ReturnsNotFoundObjectResultForNonexistentSession()
        {
            // Arrange
            var mockRepo = new Mock<IPizzaVotesRepository>();
            var controller = new PizzaVotesController(mockRepo.Object);
            var nonExistentSessionId = "nonexisting@user.com";

            // Act
            var result = await controller.Get(nonExistentSessionId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<List<PizzaVotes>>>(result);
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }
    }
}