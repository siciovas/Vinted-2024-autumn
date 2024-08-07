using VintedBackend;
using VintedBackend.Enums;

namespace VintedBackendTests
{
    public class SizeTests
    {
        [Fact]
        public void IsValidSize_SizeIsS_ReturnsTrue()
        {

            var size = Size.S;

            // Act
            var isValidSize = Validators.IsValidSize(size.ToString(), out var actualSize);

            // Assert
            Assert.True(isValidSize);
            Assert.Equal(size, actualSize);
        }

        [Fact]
        public void IsValidSize_SizeIsM_ReturnsTrue()
        {
            // Arrange
            var size = Size.M;

            // Act
            var isValidSize = Validators.IsValidSize(size.ToString(), out var actualSize);

            // Assert
            Assert.True(isValidSize);
            Assert.Equal(size, actualSize);
        }

        [Fact]
        public void IsValidSize_SizeIsL_ReturnsTrue()
        {
            // Arrange
            var size = Size.L;

            // Act
            var isValidSize = Validators.IsValidSize(size.ToString(), out var actualSize);

            // Assert
            Assert.True(isValidSize);
            Assert.Equal(size, actualSize);
        }

        [Fact]
        public void IsValidSize_SizeIsEmpty_ReturnsFalse()
        {
            // Act
            var isValidSize = Validators.IsValidSize("", out _);

            // Assert
            Assert.False(isValidSize);
        }

        [Fact]
        public void IsValidSize_SizeIsNotCorrect_ReturnsFalse()
        {
            // Act
            var isValidSize = Validators.IsValidSize("WrongSizeTest", out _);

            // Assert
            Assert.False(isValidSize);
        }
    }
}
