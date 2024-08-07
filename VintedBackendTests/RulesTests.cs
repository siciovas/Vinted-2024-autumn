using AutoFixture;
using VintedBackend;
using VintedBackend.Enums;
using VintedBackend.Rules;

namespace VintedBackendTests
{
    public class RulesTests
    {
        private readonly Fixture _fixture = new();

        [Fact]
        public void ApplyDiscount_FirstRule_ReturnsCorrectValue()
        {
            // Arrange
            var rule = new FirstRule();
            var shipment = new Shipment(new DateTime(), Size.S, Provider.MR);
            var discountCalculation = new DiscountCalculation();
            var currentPrice = 2;

            // Act
            rule.ApplyDiscount(shipment, discountCalculation, currentPrice);

            // Arrange
            Assert.Equal(1.50m, shipment.DiscountPrice);
            Assert.Equal(0.5m, shipment.Discount);
        }

        [Fact]
        public void ApplyDiscount_SecondRule_ReturnsCorrectValue()
        {
            // Arrange
            var rule = new SecondRule();
            var shipment = new Shipment(new DateTime(), Size.L, Provider.LP);
            var discountCalculation = _fixture.Build<DiscountCalculation>()
                .With(x => x.LpShipmentTimes, 2)
                .Create();
            var currentPrice = 6.90m;

            // Act
            rule.ApplyDiscount(shipment, discountCalculation, currentPrice);

            // Arrange
            Assert.Equal(0, shipment.DiscountPrice);
            Assert.Equal(6.9m, shipment.Discount);
        }

        [Fact]
        public void ApplyDiscount_PartialDiscount_ReturnsCorrectValue()
        {
            // Arrange
            var rule = new FirstRule();
            var shipment = new Shipment(new DateTime(), Size.S, Provider.MR);
            var discountCalculation = new DiscountCalculation();
            var currentPrice = 20;

            // Act
            rule.ApplyDiscount(shipment, discountCalculation, currentPrice);

            // Arrange
            Assert.Equal(10, shipment.DiscountPrice);
            Assert.Equal(10, shipment.Discount);
        }
    }
}
