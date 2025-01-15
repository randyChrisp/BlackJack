using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using BlackJack.Controllers;
using BlackJack.Models;

namespace BlackJack.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ShouldReturnViewResult_WithGameModel()
        {
            // Arrange
            var mockGame = new Mock<IGame>();
            var controller = new HomeController(mockGame.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<IGame>(viewResult.Model);
        }

        [Fact]
        public void Deal_ShouldRedirectToIndex()
        {
            // Arrange
            var mockGame = new Mock<IGame>();
            mockGame.Setup(g => g.Deal()).Returns(Game.Result.Shuffling);
            var controller = new HomeController(mockGame.Object);

            // Mock TempData
            var tempData = new Mock<ITempDataDictionary>();
            controller.TempData = tempData.Object;

            // Act
            var result = controller.Deal();

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
        }
    }
}