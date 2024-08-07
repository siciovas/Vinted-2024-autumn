using AutoFixture;
using VintedBackend;

namespace VintedBackendTests
{
    public class DateTests
    {
        private readonly Fixture _fixture = new();

        [Fact]
        public void IsValidDate_DateIsValid_ReturnsTrue()
        {
            // Arrange
            var Date = _fixture.Create<DateTime>();

            // Act
            var isValidDate = Validators.IsValidDate(Date.ToString("yyyy-MM-dd"), out _);

            // Assert
            Assert.True(isValidDate);
        }

        [Fact]
        public void IsValidDate_DateIsEmpty_ReturnsFalse()
        {
            // Act
            var isValidDate = Validators.IsValidDate(string.Empty, out _);

            // Assert
            Assert.False(isValidDate);
        }
    }
}