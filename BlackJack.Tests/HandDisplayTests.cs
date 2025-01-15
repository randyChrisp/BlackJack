using Xunit;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using BlackJack.Components;
using BlackJack.Models;

namespace BlackJack.Tests
{
    public class HandDisplayTests
    {
        [Fact]
        public void Invoke_ShouldReturnView_WithHandModel()
        {
            // Arrange
            var hand = new Hand();
            var component = new HandDisplay();

            // Act
            var result = component.Invoke(hand);

            // Assert
            var viewResult = Assert.IsType<ViewViewComponentResult>(result);
            Assert.IsAssignableFrom<Hand>(viewResult.ViewData.Model);
        }
    }
}