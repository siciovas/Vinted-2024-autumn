using VintedBackend.Enums;
using VintedBackend;

namespace VintedBackendTests
{
    public class ProviderTests
    {
        [Fact]
        public void IsValidProvider_ProviderIsLP_ReturnsTrue()
        {
            // Arrange
            var provider = Provider.LP;

            // Act
            var isValidProvider = Validators.IsValidProvider(provider.ToString(), out var actualProvider);

            // Assert
            Assert.True(isValidProvider);
            Assert.Equal(Provider.LP, actualProvider);
        }

        [Fact]
        public void IsValidProvider_ProviderIsMR_ReturnsTrue()
        {
            // Arrange
            var provider = Provider.MR;

            // Act
            var isValidProvider = Validators.IsValidProvider(provider.ToString(), out var actualProvider);

            // Assert
            Assert.True(isValidProvider);
            Assert.Equal(Provider.MR, actualProvider);
        }

        [Fact]
        public void IsValidProvider_ProviderIsEmpty_ReturnsFalse()
        {
            // Act
            var isValidProvider = Validators.IsValidProvider("", out _);

            // Assert
            Assert.False(isValidProvider);
        }

        [Fact]
        public void IsValidProvider_ProviderIsNotCorrect_ReturnsFalse()
        {
            // Act
            var isValidProvider = Validators.IsValidProvider("WrongProviderTest", out _);

            // Assert
            Assert.False(isValidProvider);
        }
    }
}
