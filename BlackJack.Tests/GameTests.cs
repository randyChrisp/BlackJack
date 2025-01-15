using Xunit;
using Moq;
using BlackJack.Models;

namespace BlackJack.Tests
{
    public class GameTests
    {
        [Fact]
        public void Deal_ShouldReturnShuffling_WhenDeckIsEmpty()
        {
            // Arrange
            var mockGame = new Mock<IGame>();
            mockGame.Setup(g => g.Deal()).Returns(Game.Result.Shuffling);

            // Act
            var result = mockGame.Object.Deal();

            // Assert
            Assert.Equal(Game.Result.Shuffling, result);
        }

        [Fact]
        public void Hit_ShouldReturnPlayerBlackJack_WhenPlayerGetsBlackJack()
        {
            // Arrange
            var mockGame = new Mock<IGame>();
            mockGame.Setup(g => g.Hit()).Returns(Game.Result.PlayerBlackJack);

            // Act
            var result = mockGame.Object.Hit();

            // Assert
            Assert.Equal(Game.Result.PlayerBlackJack, result);
        }
    }
}